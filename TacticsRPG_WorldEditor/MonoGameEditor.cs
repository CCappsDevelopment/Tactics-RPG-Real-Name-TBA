using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Input;
using MonoGame.Forms.Controls;
using TacticsRPG_GameEngine;
using TacticsRPG_GameEngine.Tilemaps;

// BEGIN MonoGameEditor.cs
namespace TacticsRPG_WorldEditor
{
    /// <summary>
    /// MonoGameEditor class is the main MonoGame loop for the 
    /// Game Editor. Handles events associated with editing the Game
    /// Map within the editor's MonoGame preview window.
    /// </summary>
    class MonoGameEditor : MonoGameControl
    {
        // Delegate for handling functions on New Map creation.
        public delegate void OnNewMapHandler(Map newMap);
        // Event for handling new Map creation.
        public event OnNewMapHandler NewMap;

        public Bootstrap Bootstrap { get; set; } // Instance of GameEngine.Bootstrap for working with Tilesets operation.
        public Tile BrushTile { get; set; } // The current Brush Tile for painting on the Map interface.
        public int ActiveLayer { get; set; } // The currently selected layer in the layer comboBox.

        private Map worldMap; // The current world map.
        private Form form; // The main Editor Form.
        private Size2 viewportSize; // The Size of the MonoGame previewer
        private OrthographicCamera camera; // The Camera for viewing the Map

        /// <summary>
        /// Initialize()
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Create new instance of GameEngine.Bootstrap and set the GraphicsDevice and Content path.
            Bootstrap = new Bootstrap(GraphicsDevice, @"..\..\..\Content");
            
            CreateMap(16, 16, 32, 32); // Create default new Map
            form = FindForm(); // Get the Form the MonoGame previewer is on.

            // Set the zoom levels for the Camera
            camera = new OrthographicCamera(GraphicsDevice)
            {
                MinimumZoom = 0.25f,
                MaximumZoom = 1.25f
            };

            base.Initialize(); // Call built in MonoGame Initialize method.
        }

        /// <summary>
        /// Update(GameTime)
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">(GameTime) - Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime); // Call built-in MonoGame Update method.

            if (!form.ContainsFocus)
                return;

            HandleViewportSizeChange(); // Check for window size change and handle it.

            MouseStateExtended mouseState = MouseExtended.GetState(); // Get the current state of the mouse
            Point mousePos = mouseState.Position; // Get current position of the mouse
            // Get the position of the mouse in the world relative to the absolute screen position.
            Vector2 worldPos = camera.ScreenToWorld(mousePos.ToVector2()); 

            // Get the Tile and positional data associated with it (if any) at the mouse position in the world.
            TileLayer.TilePositionDetail tilePositionDetail = worldMap.GetTileAtPosition(worldPos, ActiveLayer);
            Tile tile = tilePositionDetail.Tile;

            // Handle User input
            #region Handle input
            // if right mouse button is clicked allow the camera to be dragged along with the mouse.
            if (mouseState.IsButtonDown(MouseButton.Right))
            {
                // move camera with respect to mouse postion and zoom level.
                camera.Move(mouseState.DeltaPosition.ToVector2() / camera.Zoom);
            }
            else if(mouseState.DeltaScrollWheelValue != 0) // if mouse wheel is scrolled, change zoom level
            {
                // change the camera zoom level based on scroll wheel direciton
                // clamped between min and max zoom levels.
                camera.Zoom = MathHelper.Clamp(
                    camera.Zoom - mouseState.DeltaScrollWheelValue * 0.001f, 
                    camera.MinimumZoom,
                    camera.MaximumZoom
                );
            }
            else if (mouseState.IsButtonDown(MouseButton.Left)) // if left mouse button clicked
            {
                if(tile != null && BrushTile != null) // check for tile at the current position and if brush tile selected.
                {
                    // Set the Tile at the clicked position to the Brush Tile.
                    tile.TilesetIndex = BrushTile.TilesetIndex;
                    tile.TileIndex = BrushTile.TileIndex;
                }
            }
            #endregion

            // If a brush Tile is selected and is a valid position. Show brush Tile at map position.
            if (BrushTile != null && tilePositionDetail.IsValidPosition)
            {
                // Add the Brush Tile to the Map's selected Tile for display at mouse position.
                worldMap.AddSelectedTile(
                    tilePositionDetail.Coordinates.X, 
                    tilePositionDetail.Coordinates.Y, 
                    BrushTile
                );
            }
        }

        /// <summary>
        /// Draw()
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw()
        {
            base.Draw(); // call built-in MonoGame draw mehtod.
            worldMap.Draw(Editor.spriteBatch, camera, Bootstrap.Tilesets); // Draw the Map to the screen
        }

        /// <summary>
        /// CreateMap(int, int, int, int)
        /// Creates a new Map with given parameters
        /// </summary>
        /// <param name="mapWidth">(int) - Number of collumns in the Map</param>
        /// <param name="mapHeight">(int) - Number of rows in the Map</param>
        /// <param name="tileWidth">(int) - Width of each Tile</param>
        /// <param name="tileHeight">(int) - Height of each TIle</param>
        public void CreateMap(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            // Create map with given parameters.
            worldMap = new Map(tileWidth, tileHeight, mapWidth, mapHeight);
            NewMap?.Invoke(worldMap); // Invoke the NewMapHandler 
        }

        /// <summary>
        /// SaveMap(Stream) - Saves the current Map to .map file
        /// </summary>
        /// <param name="stream">(Stream) - Binary File Stream for wrting to .map File</param>
        public void SaveMap(Stream stream)
        {
            worldMap.Save(stream); // Handle saving Map to .map file
        }

        /// <summary>
        /// LoadMap(Stream) - Loads new Map into the editor
        /// </summary>
        /// <param name="stream">(Stream) - Binary File Stream for reading from .map File</param>
        public void LoadMap(Stream stream)
        {
            worldMap = new Map(stream); // Create new Map from stream data
            NewMap?.Invoke(worldMap); // Invoke NewMapHandler
        }

        /// <summary>
        /// HandleViewportSizeChange()
        /// Handles recentering the Camera and resizing the MonoGame
        /// viewport when the window size is changed. 
        /// </summary>
        private void HandleViewportSizeChange()
        { 
            // Get current size of the window.
            Size2 graphicsDeviceSize = new Size2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            // if window size has changed recenter camera
            if(viewportSize != graphicsDeviceSize)
            {
                Vector2 cameraCenter = camera.Center; // Get camera center
                // Set camera origin to center of graphics device
                camera.Origin = new Vector2(graphicsDeviceSize.Width / 2, graphicsDeviceSize.Height / 2);
                camera.LookAt(cameraCenter); // Refocus camera on new center

                // Set the MonoGame viewport to the graphics device's size.
                viewportSize = graphicsDeviceSize;
            }
        }
    }
}
// END MonoGameEditor.cs
