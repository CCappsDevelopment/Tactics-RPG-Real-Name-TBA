using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

// BEGIN Tileset.cs
namespace TacticsRPG_GameEngine.Tilemaps
{
    /// <summary>
    /// Tileset class - Houses data for tilesets used by the Editor and the game Map.
    /// Handles Saving/Loading/Modifying JSON files associated with each imported TileSet
    /// </summary>
    public class Tileset
    {
        public string FilePath { get; set; } // The file path for a TileSet (looks in ../Content/Tilesets/)
        public string Name { get; set; } // Name associated with the TileSet

        [JsonIgnore]
        public Texture2D Texture { get; set; } // Texture for TileSet image 
        public List<Rectangle> Frames { get; set; } // List containing the Rectangles that make up each Tile frame in a TileSet image

        /// <summary>
        /// Tileset() - Default constructor
        /// </summary>
        public Tileset()
        {

        }

        /// <summary>
        /// Tileset(Tileset) - Overloaded constructor
        /// Used to update a Tileset when generating Tile Frames.
        /// </summary>
        /// <param name="source">(Tileset) - The TileSet to be updated by the 'Edit Tileset...' menu</param>
        public Tileset(Tileset source)
        {
            Apply(source); // Update the given TileSet
        }

        /// <summary>
        /// FromJsonFile(string, GraphicsDevice)
        /// Returns an instance of a TileSet read from the JSON
        /// file associated with the TileSet image.
        /// </summary>
        /// <param name="filePath">File path to the TileSet image and JSON files.</param>
        /// <param name="gDevice">The main graphics device for the game.</param>
        /// <returns></returns>
        public static Tileset FromJsonFile(string filePath, GraphicsDevice gDevice)
        {
            // Create TileSet object from JSON file data
            Tileset tilesetInstance = JsonConvert.DeserializeObject<Tileset>(
                File.ReadAllText(filePath)
            );

            // Change file extension of filepath: .json -> .png for getting TileSet image
            string pngPath = Path.ChangeExtension(filePath, ".png");
            tilesetInstance.FilePath = filePath; // Set the FilePath of the tilesetInstance to the .png

            // Create file Stream to read Texture data from the TileSet image
            using (Stream fileStream = File.OpenRead(pngPath))
            {
                // Read the Texture data from the File Stream and save in the tilesetInstance
                tilesetInstance.Texture = Texture2D.FromStream(gDevice, fileStream);
            }

            // return the tilesetInstance
            return tilesetInstance;
        }

        /// <summary>
        /// Apply(Tileset) - Updates the Name, Texture,
        /// and List of Frames of the source Tileset.
        /// </summary>
        /// <param name="source">(Tileset) - The TileSet to be updated by the 'Edit Tileset...' menu</param>
        public void Apply(Tileset source)
        {
            // Update Name, Texture, and Frames of the source Tileset 
            Name = source.Name;
            Texture = source.Texture;
            Frames = new List<Rectangle>(source.Frames);
        }

        /// <summary>
        /// SaveToJson() - Creates a JSON file that is to be associated with
        /// the Tileset image file, properly formatted.
        /// </summary>
        public void SaveToJson()
        {
            // Create/Update JSON file associated with Tileset
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        /// <summary>
        /// ToString() - Overide the ToString method to only return the Name of the Tileset.
        /// </summary>
        /// <returns>string Name - name of the Tileset</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
// END Tileset.cs