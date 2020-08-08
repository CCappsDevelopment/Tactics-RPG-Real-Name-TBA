using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using TacticsRPG_GameEngine.Tilemaps;

// BEGIN TilesetExtensions.cs
namespace TacticsRPG_WorldEditor.Extensions
{
    /// <summary>
    /// TilesetExtensions static class
    /// Extension class for adding extra functionality
    /// to Rectangle objects.
    /// </summary>
    static class TilesetExtensions
    {
        // Dictionary for caching the Tileset Images once loaded.
        private static Dictionary<Texture2D, Image> imageCache = new Dictionary<Texture2D, Image>();

        /// <summary>
        /// GetImageFromTexture(this Tileset)
        /// Extension method that returns an Image object from the given Tileset object.
        /// </summary>
        /// <param name="tileset">(Tileset) - The Tileset to get an Image from.</param>
        /// <returns>Image - png image of the given Tileset</returns>
        public static Image GetImageFromTexture(this Tileset tileset)
        {
            // Open a MemoryStream to get Image from texure
            using(MemoryStream stream = new MemoryStream())
            {
                Texture2D tilesetTexture = tileset.Texture; // Get Tileset Texture
                // If image already cached, return cached Image
                if (imageCache.ContainsKey(tilesetTexture))
                {
                    return imageCache[tilesetTexture];
                }
                
                // Save Texture as a PNG Image
                tileset.Texture.SaveAsPng(stream, tileset.Texture.Width, tileset.Texture.Height);
                Image image =  new Bitmap(stream); // Create BMP from PNG
                
                imageCache.Add(tilesetTexture, image); // Add Image to cache

                return image; // Return Image.
            } 
        }

    }
}
// END TilesetExtensions.cs
