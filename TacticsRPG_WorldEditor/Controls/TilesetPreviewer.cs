using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TacticsRPG_GameEngine.Tilemaps;
using TacticsRPG_WorldEditor.Extensions;

# region Specifically defined object types
using MonoGamePoint = Microsoft.Xna.Framework.Point;
using MonogameRectangle = Microsoft.Xna.Framework.Rectangle;
using SystemRectangle = System.Drawing.Rectangle;
#endregion

// BEGIN TilesetPreviewer.cs
namespace TacticsRPG_WorldEditor.Controls
{
    /// <summary>
    /// TilesetPreviewer : Panel class
    /// Handles all operations of the Tileset Previewer component of the editor.
    /// </summary>
    class TilesetPreviewer : Panel
    {
        // All possible zoom levels for the TilesetPreviewer
        private readonly List<float> zoomLevels = new List<float>()
        {
            0.25f, // Min Zoom
            0.5f,
            0.75f,
            1.0f,  // Standard Zoom
            1.25f, 
            1.5f, 
            1.75f,
            2.0f   // Max Zoon
        };  

        private PictureBox tilesetPictureBox; // Picturebox containing Tileset image
        private Tileset tileset; // Tileset being previewed
        private int selectedFrameIndex = -1; // index of Tileset currently selected
        private Size originalSize; // Original size of Tileset
        private int currentZoomLevel; // Current zoom level of the Tileset Previewer

        // Delegate for handling Tile selection
        public delegate void OnTileSelectHandler(Tileset tileset, int frameIndex);
        public event OnTileSelectHandler TileSelect; // Event triggered on Tile selction

        // Current Tileset
        public Tileset Tileset
        {
            get
            {
                return tileset;
            }

            set
            {
                tileset = value;
                OnTilsetChange(); // Update previewer to show new Tileset
            }
        }

        /// <summary>
        /// TilesetPreviewer() - Constructor
        /// Intitalize PictureBox Component
        /// </summary>
        public TilesetPreviewer()
        {
            AutoScroll = true; // Allow AutoScroll

            tilesetPictureBox = new PictureBox(); // Init new PictureBox
            tilesetPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Set size mode to zoom
            Controls.Add(tilesetPictureBox); // Add tilesetPictureBox to Controls.
        }

        /// <summary>
        /// RefreshFrames() - Invalidate the tilesetPictureBox to redraw image
        /// </summary>
        public void RefreshFrames()
        {
            tilesetPictureBox.Invalidate(); // Redraw tilesetPictureBox
        }

        /// <summary>
        /// OnCreateControl() - Called when the control is created
        /// Adds handler methods to PictureBox events.
        /// </summary>
        protected override void OnCreateControl()
        {
            if (!DesignMode) // Property of PictureBox component
            {
                tilesetPictureBox.Click += TilesetPictureBox_Click;
                tilesetPictureBox.Paint += TilesetPictureBox_Paint;
                tilesetPictureBox.MouseWheel += TilesetPictureBox_MouseWheel;
            }
        }

        /// <summary>
        /// TilesetPictureBox_Click(object, EventArgs)
        /// Handler for when the Tileset Previewer is clicked.
        /// If a Tileset is selected in the previewer, select the
        /// clicked frame within the Tileset.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void TilesetPictureBox_Click(object sender, EventArgs e)
        {
            // If no Tileset is presently selected, return.
            if (tileset == null)
                return;

            MouseEventArgs mouseArgs = (MouseEventArgs)e; // Get data from mouse event
            MonoGamePoint mousePoint = new MonoGamePoint(mouseArgs.X, mouseArgs.Y); // Get position of mouse click

            List<MonogameRectangle> frameRects = tileset.Frames; // Get List of frames in the Tileset

            // Loop through each frame in the Tileset, if frame contains mouse point, select Tile in the frame.
            for (int i = 0; i < frameRects.Count; i++)
            {
                // Get corrently scaled rectangle based on current zoom level.
                MonogameRectangle scaledRect = frameRects[i].Scale(zoomLevels[currentZoomLevel]);
                // If mouse Point lies within the scaled rectangle, select frame
                if (scaledRect.Contains(mousePoint))
                {
                    selectedFrameIndex = i; // Get selected frame.

                    // Invoke TileSelectHandler, changes BrushTile to selected frame Tile.
                    TileSelect?.Invoke(tileset, selectedFrameIndex);

                    RefreshFrames(); // Redraw the updated frames to show selection.
                }
            }
        }

        /// <summary>
        /// TilesetPictureBox_Paint(object, PaintEventArgs)
        /// Handler for when the TilesetPicureBox is drawn to the screen.
        /// Colors each frame of the Tileset based on whether or not it is selected.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void TilesetPictureBox_Paint(object sender, PaintEventArgs e)
        {
            // If no Tileset selected return
            if (tileset == null)
                return;

            // Get List of frames in the Tileset
            List<MonogameRectangle> frameRects = tileset.Frames;

            // loop through each frame, draw a colored rectangle over each; red == selected, blue otherwise.
            for(int i = 0; i < frameRects.Count; i++)
            {
                // Get frame rectangle, based on current zoom level.
                MonogameRectangle frameRect = frameRects[i].Scale(zoomLevels[currentZoomLevel]);
                // Create Rectangle to draw over the frame
                SystemRectangle drawingRect = new SystemRectangle(
                                                    frameRect.X, 
                                                    frameRect.Y, 
                                                    frameRect.Width - 1, 
                                                    frameRect.Height - 1
                                              );
                
                // Color frame based on whether or not it is selected 
                if(selectedFrameIndex == i)
                    e.Graphics.DrawRectangle(Pens.Red, drawingRect); // If selected, Color RED
                else
                    e.Graphics.DrawRectangle(Pens.Blue, drawingRect); // If not selected, Color BLUE

            }
        }

        /// <summary>
        /// TilesetPictureBox_MouseWheel(object, MouseEventArgs)
        /// Handler for when the Mouse Wheel is activated while the
        /// TilesetPictureBox is in context. Controls zooming in and out
        /// of the Tileset within the PictureBox when the Shoft key is held.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void TilesetPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            // If the Shift key isn't held, return.
            if (ModifierKeys != Keys.Shift)
                return;

            // Get data associated with mouse scroll event.
            HandledMouseEventArgs handledArgs = (HandledMouseEventArgs)e; 
            handledArgs.Handled = true;

            // Check for scrolling.
            if (e.Delta > 0)
            {
                // Zoom in
                currentZoomLevel = Math.Min(currentZoomLevel + 1, zoomLevels.Count - 1);
            }
            else
            {
                // Zoom out
                currentZoomLevel = Math.Max(currentZoomLevel - 1, 0);

            }

            // Resize PictureBox image to fit current zoom level.
            tilesetPictureBox.Size = new Size(
                (int)(originalSize.Width * zoomLevels[currentZoomLevel]),
                (int)(originalSize.Height * zoomLevels[currentZoomLevel])
            );
        }

        /// <summary>
        /// OnTilsetChange() - Update Previewer to show new Tileset
        /// </summary>
        private void OnTilsetChange()
        {
            // If no Tileset selected, set PictureBox image to null, return.
            if (Tileset == null)
            {
                tilesetPictureBox.Image = null;
                return;
            }

            Image tilesetImage = tileset.GetImageFromTexture(); // Get Tileset Image from its Texture
            tilesetPictureBox.Image = tilesetImage; // Change PictureBox Image to selected Tileset
            tilesetPictureBox.Size = new Size(tilesetImage.Width, tilesetImage.Height); // Set PB Size to Tileset Size
            originalSize = tilesetPictureBox.Size; // Set new originalSize for PictureBox
            currentZoomLevel = 3; // 1.0f zoom
        }

    }
}
// END TilesetPreviewer.cs
