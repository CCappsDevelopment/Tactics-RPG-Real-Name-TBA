using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using TacticsRPG_GameEngine.Tilemaps;

// BEGIN EditTIlesetDialog.cs
namespace TacticsRPG_WorldEditor.Menus
{
    /// <summary>
    /// EditTilesetDialog : Form partial class
    /// Contains controls for the dialog that appears
    /// when the 'Edit Tileset' button is clicked.
    /// </summary>
    public partial class EditTilesetDialog : Form
    {
        private Tileset sourceTileset; // The Tileset to be editied
        public Tileset SourceTileset {
            get
            {
                return sourceTileset;
            }
            set
            {
                sourceTileset = value;
                ModifiedTileset = new Tileset(sourceTileset); // initialize modified Tileset
            }
        }

        public Tileset ModifiedTileset { get; set; } // Modified Tileset for apply changes

        // Boolean value for if any changes have been made to the source Tileset
        public bool HasChanges
        {
            get
            {
                // return the value for whether any frames in the SourceTileset differs from the ModifiedTileset
                return ModifiedTileset.Frames.Except(SourceTileset.Frames).Any();
            }
        }

        /// <summary>
        /// EditTilesetDialog() - Default contructor
        /// </summary>
        public EditTilesetDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// EditTilesetDialog_Load(object, EventArgs)
        /// Called once dialog has loaded, sets the Tileset displayed
        /// in the preivewer to the ModifiedTileset
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void EditTilesetDialog_Load(object sender, EventArgs e)
        {
            tilesetPreviewer.Tileset = ModifiedTileset; // Set previewer Tileset to ModifiedTileset
        }

        /// <summary>
        /// buttonGenerateFrames_Click(object, EventArgs)
        /// Handler for when the 'Generate Frames' button is clicked.
        /// Opens the GenreateFramesDialog, upon receiveing results from 
        /// the dialog, divides the ModifiedTileset into frames based on the input
        /// number of rows and collumns and input tile dimensions. 
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void buttonGenerateFrames_Click(object sender, EventArgs e)
        {
            // Create instance of the GenerateFramesDialog
            GenerateFramesDialog dialog = new GenerateFramesDialog();

            // Open dialog, upon results divide ModifiedTileset into frames.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ModifiedTileset.Frames.Clear(); // Clear current frames for updating.
                int tileWidth = dialog.generationDetails.TileWidth; // Get submitted Tile width from dialog
                int tileHeight = dialog.generationDetails.TileHeight; // Get submitted Tile height from dialog
                int numFramesHorizontal = ModifiedTileset.Texture.Width / tileWidth; // Get num horizontal frames
                int numFramesVertical = ModifiedTileset.Texture.Height / tileHeight; // Get num vertial frames

                // Loop through each frame index (Vertical and Horizontal);
                // Creating a new frame and adding it to the Frames list at each index.
                for (int row = 0; row < numFramesVertical; row++)
                {
                    for (int col = 0; col < numFramesHorizontal; col++)
                    {
                        // Create new frame at the current row and col of the Tileset
                        Rectangle frame = new Rectangle(col * tileWidth, row * tileHeight, tileWidth, tileHeight);
                        ModifiedTileset.Frames.Add(frame); // Add frame to the ModifiedTileset
                    }
                }

                tilesetPreviewer.RefreshFrames(); // Update the preivewer to show new frames.
                UpdateButtonState(); // Update the 'OK' button to disabled until more changes have been made.
            }
        }

        /// <summary>
        /// UpdateButtonState() - Enables/Diables 'OK' based on whether or not 
        /// there are pending changes to the Tileset Frames.
        /// </summary>
        private void UpdateButtonState()
        {
            buttonOK.Enabled = HasChanges;
        }
    }
}
// END EditTilesetDialog.cs
