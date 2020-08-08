using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

// BEGIN Map.cs
namespace TacticsRPG_GameEngine.Tilemaps
{
    /// <summary>
    /// Map class - contains fields and methods for the
    /// shared Map object used my TacticsRPG and TacticsRPG_GameEditor.
    /// Consists of a grid of Tile objects with a specified tile size.
    /// Handles Saving/Loading Maps in TacticsRPG_GameEditor
    /// </summary>
    public class Map
    {
        // List of each TileLayer that makes up a Map
        public List<TileLayer> Layers { get; private set; }

        // Map dimensions
        private int tileWidth; // Width of each tile in the map
        private int tileHeight; // Height of each tile in the map
        private int numCol; // Width of a Map in number of tiles horizontally across
        private int numRow; // Height of a Map in number of tiles vertically down

        // Tile the user's mouse is currently hovering over with the Brush Tile.
        private List<Tuple<int, int, Tile>> selectedTiles = new List<Tuple<int, int, Tile>>();

        /// <summary>
        /// Map(int, int, int, int) - Constructor [Overloaded]
        /// Initializes new Map from the given dimensions. 
        /// Adds each TileLayer to the Map
        /// <param name="tWidth"> (int) - Width of each tile in the map</param>
        /// <param name="tHeight">(int) - Height of each tile in the map</param>
        /// <param name="numCol"> (int) - Width of a Map in number of tiles horizontally across</param>
        /// <param name="numRow"> (int) - Height of a Map in number of tiles vertically down</param>
        /// </summary>
        public Map(int tWidth, int tHeight, int numCol, int numRow)
        {
            // Set Map dimensions
            this.tileWidth = tWidth;
            this.tileHeight = tHeight;
            this.numCol = numCol;
            this.numRow = numRow;

            // Create empty list of TileLayers to add to
            this.Layers = new List<TileLayer>();

            // Currently Hardcoded base and top layers
            // TODO: Create generic layer upon Map creation
            // TODO: Add functionality to add new TileLayers manually
            Layers.Add(new TileLayer(
                this.tileWidth, 
                this.tileHeight, 
                this.numCol, 
                this.numRow,
                "Base Layer"
            ));
            Layers.Add(new TileLayer(
                this.tileWidth,
                this.tileHeight,
                this.numCol,
                this.numRow,
                "Top Layer"
            ));
        }

        /// <summary>
        /// Map(Stream) - Constructor [Overloaded]
        /// Initializes new Map from the given Stream (FileStream from saved .map file)
        /// <param name="stream">(Stream) - File Stream for Loading Map objetc data from .map file</param>
        /// </summary>
        public Map(Stream stream)
        {
            // Clear Layers for new Map creation
            Layers = new List<TileLayer>();

            // Load Map object data from File Stream (.map)
            Load(stream);
        }

        /// <summary>
        /// GetTileAtPosition(Vector2, int) - Gets Tile at given coordinates along with its positional data 
        /// from the TileLayer at the given index. 
        /// </summary>
        /// <param name="position">(Vector2) - Absolute position (in pixels) of a tile within the Map</param>
        /// <param name="layerIndex">(int) - Index for the layer the requested Tile is on</param>
        /// <returns>TileLayer.TilePositionDetail - Object for holding positional data for a Tile on the Map</returns>
        public TileLayer.TilePositionDetail GetTileAtPosition(Vector2 position, int layerIndex)
        {
            // if layerIndex is not between 0 and total number of layers in Map return null
            if (layerIndex < 0 || layerIndex >= this.Layers.Count)
                return null;

            // Return the Tile at requested position on the Map from its Layer.
            return this.Layers[layerIndex].GetTileAtPosition(position);
        }

        /// <summary>
        /// AddSelectedTile(int, int, Tile) - Adds the current Tile the
        /// user's mouse is hovering over to the selectedTiles List.
        /// </summary>
        /// <param name="col"> (int)  - Collumn of the Map the given Tile is on.</param>
        /// <param name="row"> (int)  - Row of the Map the given Tile is on.</param>
        /// <param name="tile">(Tile) - The Tile to be added to selectedTiles List</param>
        public void AddSelectedTile(int col, int row, Tile tile)
        {
            selectedTiles.Add(new Tuple<int, int, Tile>(col, row, tile));
        }

        /// <summary>
        /// Draw(SpriteBatch, Camera<Vector2>, List<Tileset>)
        /// Handles drawing the contents of the Map to the screen each tick.
        /// First draws a solid gray rectangle the size of the entire Map
        /// Then Draws each TileLayer showing the completed map.
        /// If there are selectedTiles in the editor, they will be drawn 
        /// on top of completed Map. 
        /// </summary>
        /// <param name="spriteBatch">(SpriteBatch) - Sprite Batch to be be drawn</param>
        /// <param name="tilesets"> (List<Tileset>) - The available List of TileSets given to the Editor</param>
        public void Draw(SpriteBatch spriteBatch, Camera<Vector2> camera, List<Tileset> tilesets)
        {
            // Start SpriteBatch Draw cycle, given the transformation matrix 
            // of the Camera for drawing in the correct location.
            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            // Draw a solid gray rectangle as background for Map
            spriteBatch.FillRectangle(Vector2.Zero, new Size2(this.tileWidth * this.numCol, this.tileHeight * this.numRow), Color.Gray);

            // Loop through Layers of the Map and draw each sequentially
            for (int i = 0; i < this.Layers.Count; i++)
            {
                // Layer object handles actual Drawing of Map; 
                // Tile Object handles drawing of Tile at each position.
                this.Layers[i].Draw(spriteBatch, tilesets);
            }

            // Loop through eact selected Tile within the Map object and
            // draw the Brush Tile in the selected Tiles locations.
            for (int i = 0; i < this.selectedTiles.Count; i++)
            {
                var (col, row, tile) = this.selectedTiles[i]; // temp object for holding Tile data
                Vector2 tilePos = new Vector2(col * this.tileWidth, row * this.tileHeight); // Vector containing absolute position of selected Tile

                // Draw selected Tile to the Map
                tile.Draw(spriteBatch, tilePos, this.tileWidth, this.tileHeight, tilesets);
            }

            spriteBatch.End(); // End drawing of SpriteBatch
            this.selectedTiles.Clear(); // Empty list of Selected Tiles
        }

        /// <summary>
        /// Save(Stream) - Handles saving Map data to a FileStream
        /// Creates a BinaryWriter to write data associated with the
        /// game Map to a .map file.
        /// </summary>
        /// <param name="stream">(Stream) - File Stream for Saving/Loading Map information</param>
        public void Save(Stream stream)
        {
            // Create a BinaryWriter to write Map data to the FileStream
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                // Write Map data
                writer.Write(this.numCol);
                writer.Write(this.numRow);
                writer.Write(this.tileWidth);
                writer.Write(this.tileHeight);
                writer.Write(this.Layers.Count);

                // Loop through each Layer and write Tile data for each Map Tile in the layer
                for(int i = 0; i < this.Layers.Count; i++)
                {
                    this.Layers[i].Save(writer); // TileLayer object handles saving individual Tile data to .map file.
                }
            }
        }

        /// Save(Stream) - Handles loading Map data from a FileStream
        /// Creates a BinaryReader to read data associated with the
        /// game Map from a .map file.
        /// </summary>
        /// <param name="stream">(Stream) - File Stream for Saving/Loading Map information</param>
        private void Load(Stream stream)
        {
            // Create a BinaryReader to read Map data from the FileStream
            using (BinaryReader reader = new BinaryReader(stream))
            {
                // Read each line and extract the Map data
                this.numCol = reader.ReadInt32();
                this.numRow = reader.ReadInt32();
                this.tileWidth = reader.ReadInt32();
                this.tileHeight = reader.ReadInt32();
                int layerCount = reader.ReadInt32();

                // Loop through each TileLayer and read Tile data for each Map Tile in the layer
                for (int i = 0; i < layerCount; i++)
                {
                    Layers.Add(new TileLayer(reader)); // TileLayer object handles loading individual Tile data from the .map file.
                }
            }
        }
    }

}
// END Map.cs
