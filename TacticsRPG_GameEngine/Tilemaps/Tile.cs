using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using TacticsRPG_GameEngine.Tilemaps;

// BEGIN Tile.cs
namespace TacticsRPG_GameEngine.Tilemaps
{
    /// <summary>
    /// Tile class - Handles drawing of a Tile to the Map
    /// Tile Texture is gathered from a given TileSet via the
    /// TilesetIndex and the TileIndex
    /// </summary>
    public class Tile
    {
        // The index for the currently selected TileSet in the Editor's TilesetPreviewer
        public int TilesetIndex { get; set; } = -1;
        // The index for the specific Tile within the current Tileset
        public int TileIndex { get; set; } = -1;

        /// <summary>
        /// Draw(SpriteBatch, Vector2, int, int, List<TileSet>)
        /// Handles drawing Tiles to the game Map
        /// If no Tile has been specified for the given location a
        /// white rectangle will be drawn in its place.
        /// Otherwise, the Texture (image) for the Tile will be drawn
        /// onto the game Map at the given coordinates.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="tilePos"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <param name="tilesets"></param>
        public void Draw(SpriteBatch spriteBatch, Vector2 tilePos, int tileWidth, int tileHeight, List<Tileset> tilesets)
        {
            // If no tile exists a the given position, Draw a white Rectangle at the Map location.
            spriteBatch.DrawRectangle(tilePos, new Size2(tileWidth, tileHeight), Color.White);

            // If a painted Tile exists at the given location, draw the Tile Texture.
            if (TilesetIndex != -1 && TileIndex != -1)
            {
                Tileset tileset = tilesets[TilesetIndex]; // Get TileSet used to paint Tile
                spriteBatch.Draw(tileset.Texture, tilePos, tileset.Frames[TileIndex], Color.White); // Draw Tile Texture at Map position.
            }
              
        }
    }
}
// END Tile.cs
