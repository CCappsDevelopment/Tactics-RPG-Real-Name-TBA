using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using TacticsRPG_GameEngine.Tilemaps;

// BEGIN Bootstrap.cs
namespace TacticsRPG_GameEngine
{
    /// <summary>
    /// Bootstrap class
    /// Helper class that acts as a common way for the game project
    /// and the editor project to find game content such as Tilesets.
    /// </summary>
    public class Bootstrap
    {
        private GraphicsDevice gDevice; // Graphics Device for loading Texutres to
        private string contentPath; // Directory for the Game/Editor Assets (../../../Content)
        public List<Tileset> Tilesets { get; private set; } // List of Tilesets found in content directory

        /// <summary>
        /// Bootstrap(GraphicsDevice, string) - Constructor
        /// Initializes Bootstrap data, sanitizes contentPath string,
        /// and Loads the list of Tilesets in the contentPath.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="path"></param>
        public Bootstrap(GraphicsDevice device, string path)
        {
            this.gDevice = device;
            this.contentPath = path;

            SanitizeContentPath(); // Sanitize content path string for use in loading Tilesets
            LoadTilesets(); // Load all Tilesets found in the Content directory.
        }

        /// <summary>
        /// SanatizeContentPath() - Formats contentPath string to ensure 
        /// a "\" is the last character.
        /// </summary>
        public void SanitizeContentPath()
        {
            // If "\" is not the last character of the contentPath string, add one to the end.
            if (contentPath.LastIndexOf(@"\") != contentPath.Length - 1)
            {
                contentPath += @"\";
            }
        }

        /// <summary>
        /// SaveTilesets() - Create JSON file for each Tileset
        /// in the content directory.
        /// </summary>
        public void SaveTilesets()
        {
            for (int i = 0; i < Tilesets.Count; i++)
            {
                Tilesets[i].SaveToJson();
            }
        }

        /// <summary>
        /// LoadTilesets() - Load all Tilesets in the content directory 
        /// from their JSON files.
        /// </summary>
        private void LoadTilesets()
        {
            Tilesets = new List<Tileset>(); // create new List of Tilesets to load

            // Add the Tilesets directory to the contentPath string
            string tilesetPath = contentPath + @"Tilesets\"; 
            // Get a list of paths to each JSON 
            List<String> jsonPaths = Directory.GetFiles(tilesetPath, "*.json").ToList();

            for(int i = 0; i < jsonPaths.Count; i++)
            {
                string jsonPath = jsonPaths[i];

                Tileset tilesetInstance = Tileset.FromJsonFile(jsonPath, gDevice);

                Tilesets.Add(tilesetInstance);
            }
        }
    }
}
// END Bootstrap.cs