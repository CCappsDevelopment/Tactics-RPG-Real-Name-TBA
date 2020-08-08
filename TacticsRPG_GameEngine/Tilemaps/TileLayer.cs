using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

// BEGIN Tilelayer.cs
namespace TacticsRPG_GameEngine.Tilemaps
{
    /// <summary>
    /// Tilelayer class - Handles individual layers in 
    /// the game Map. Implements the Saving/Loading feature for
    /// each layer of the Map, as well as Drawing the layer and
    /// getting data for each Tile in the layer.
    /// </summary>
    public class TileLayer
    {
        /// <summary>
        /// TilePositionDetail class - holds positional data for a requested tile
        /// on the Map object; Holds the requested Tile, the Coordinates given for 
        /// the tile, and a boolean for whether the Coordinates given are a valid 
        /// location within the Map objhect.
        /// </summary>
        public class TilePositionDetail
        {
            public Tile Tile { get; set; } // Tile requested
            public Point Coordinates { get; set; } // Coordinates of tile within the Map
            public bool IsValidPosition { get; set; } // Check for valid Coordinates
        }

        // Name of the TileLayer, displayed in layer selection panel in the editor
        public string Name { get; set; } 

        // Size of each Tile in the layer
        private int tileWidth;
        private int tileHeight;

        // Array of Map Tiles that make up the layer 
        private Tile[,] mapTiles;

        /// <summary>
        /// Tilelayer(int, int, int, int, string) - Constructor
        /// Initializes layer dimensions and associated data.
        /// Populates array of Tiles that make up the layer.
        /// </summary>
        /// <param name="tWidth"> (int) - Width of each tile in the layer.</param>
        /// <param name="tHeight">(int) - Height of each tile in the layer.</param>
        /// <param name="numCol"> (int) - Number of tiles across in the layer.</param>
        /// <param name="numRow"> (int) - Number of tiles down in the layer.</param>
        /// <param name="name">(string) - Name associated with the Tile layer.</param>
        public TileLayer(int tWidth, int tHeight, int numCol, int numRow, string name)
        {
            // Initialize layer fields
            this.tileWidth = tWidth;
            this.tileHeight = tHeight;
            Name = name;
            mapTiles = new Tile[numCol, numRow];
            
            // Populate the Map Tiles at each position (col, row) in the layer
            for (int col = 0; col < mapTiles.GetLength(0); col++)
            {
                for (int row = 0; row < mapTiles.GetLength(1); row++)
                {
                    mapTiles[col, row] = new Tile();
                }
            }
        }

        /// <summary>
        /// TileLayer(BinaryReader) - Constructor
        /// Creates new TileLayer by reading from a .map file/
        /// </summary>
        /// <param name="reader">(BinaryReader) - reads Layer data from a .map file</param>
        internal TileLayer(BinaryReader reader)
        {
            Load(reader); // Handle loading TileLayer data from .map file
        }

        /// <summary>
        /// GetTileAtPosition(Vector2) - Gets the positional data for a
        /// Tile within the Map object from the given position. Checks for whether
        /// the position given is a valid position within the Map; returns detail.
        /// </summary>
        /// <param name="position">(Vector2) - Potential absolute position (in pixels) within the Map object.</param>
        /// <returns>TilePositionDetail - Object for holding positional data for a Tile on the Map</returns>
        public TilePositionDetail GetTileAtPosition(Vector2 position)
        {
            // Object for holding positional detail for a Tile
            TilePositionDetail detail = new TilePositionDetail();

            // get the positional index for finding the Tile
            int x = (int)position.X / tileWidth;
            int y = (int)position.Y / tileHeight;

            // Set detail Coordinates to the index (x, y) given by the position vector. 
            detail.Coordinates = new Point(x, y);

            // if coordinates are NOT within the bounds of the Map, set IsValidPositon to false; return detail. 
            if (x < 0 || y < 0 || x > mapTiles.GetUpperBound(0) || y > mapTiles.GetUpperBound(1))
            {
                detail.IsValidPosition = false; // Coordinates NOT within the Map.
                return detail;
            }

            // Tile found at position
            detail.IsValidPosition = true; // Coordinates ARE within the Map.
            detail.Tile = mapTiles[x, y]; // Update TilePositionDetail with found Tile.

            return detail; // return detail
        }

        /// <summary>
        /// Draw(SpriteBatch, List<Tileset>)
        /// Loops through each Map index and draws the Tile
        /// at each position.
        /// </summary>
        /// <param name="spriteBatch">(SpriteBatch) - The SpriteBatch to be drawn to screen</param>
        /// <param name="tilesets"> (List<Tileset>) - The list of Tilesets used in the Map.</param>
        public void Draw(SpriteBatch spriteBatch, List<Tileset> tilesets)
        {
            // Loop though each Map index, drawing the Tile at each position
            for (int col = 0; col < mapTiles.GetLength(0); col++)
            {
                for (int row = 0; row < mapTiles.GetLength(1); row++)
                {
                    // Get absolute position (in pixel) for the current Map index
                    Vector2 tilePos = new Vector2(col * tileWidth, row * tileHeight);
                    Tile tile = mapTiles[col, row]; // Get Tile at current Map index

                    // Draw the Tile to the screen at position.
                    tile.Draw(spriteBatch, tilePos, tileWidth, tileHeight, tilesets);
                }
            }
        }

        /// <summary>
        /// ToString() - Override of the ToString()
        /// medthod to jusy return the Name string for the layer.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name; // Return name of layer.
        }

        /// <summary>
        /// Save(BinaryWriter)
        /// Handles writing Map data for the layer to a .map file.
        /// </summary>
        /// <param name="writer">(BinaryWriter) - Writes binary data to .map FileStream</param>
        internal void Save(BinaryWriter writer)
        {
            // Write Map properties for the layer
            writer.Write(tileWidth);
            writer.Write(tileHeight);
            writer.Write(Name);
            writer.Write(mapTiles.GetLength(0));
            writer.Write(mapTiles.GetLength(1));

            // Write the Tileset and Tile indices for each mapTile in the layer
            for (int col = 0; col < mapTiles.GetLength(0); col++)
            {
                for (int row = 0; row < mapTiles.GetLength(1); row++)
                {
                    writer.Write(mapTiles[col, row].TilesetIndex);
                    writer.Write(mapTiles[col, row].TileIndex);
                }
            }
        }

        /// <summary>
        /// Load(BinaryReader)
        /// Handles reading Map data for the layer from a .map file.
        /// </summary>
        /// <param name="reader">(BinaryReader) - Reads binary data from .map FileStream</param>
        private void Load(BinaryReader reader)
        {
            // Read Map properties from the FileStream.
            tileWidth = reader.ReadInt32();
            tileHeight = reader.ReadInt32();
            Name = reader.ReadString();

            int numCol = reader.ReadInt32();
            int numRow = reader.ReadInt32();

            // Create new Map Tile array for the layer to be loaded
            mapTiles = new Tile[numCol, numRow];

            // Read the Tileset and Tile indices for each mapTile in the layer and update mapTile[col,row]
            for (int col = 0; col < mapTiles.GetLength(0); col++)
            {
                for (int row = 0; row < mapTiles.GetLength(1); row++)
                {
                    mapTiles[col, row] = new Tile()
                    {
                        TilesetIndex = reader.ReadInt32(),
                        TileIndex = reader.ReadInt32()
                    };
                }
            }
        }
    }
}
// END TileLayer.cs
