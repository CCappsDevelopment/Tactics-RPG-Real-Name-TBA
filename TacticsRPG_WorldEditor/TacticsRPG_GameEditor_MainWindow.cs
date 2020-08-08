using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TacticsRPG_GameEngine.Tilemaps;
using TacticsRPG_WorldEditor.Extensions;
using TacticsRPG_WorldEditor.Menus;

// BEGIN TacticsRPG_GameEditor_MainWindow.cs
namespace TacticsRPG_WorldEditor
{
    /// <summary>
    /// TacticsRPG_GameEditor_MainWindow : Form partial class
    /// Handles all events associated with interacting with the
    /// GameEditor Main Window GUI. 
    /// </summary>
    public partial class TacticsRPG_GameEditor_MainWindow : Form
    {
        /// <summary>
        /// TacticsRPG_GameEditor_MainWindow() - Constructor
        /// Initializes the Forms components.
        /// </summary>
        public TacticsRPG_GameEditor_MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TacticsRPG_GameEditor_MainWindow_Load(object, EventArgs)
        /// Called upon the Form loading, initializes Tilesets for display in comboBox.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void TacticsRPG_GameEditor_MainWindow_Load(object sender, EventArgs e)
        {
            // Get available Tilesets and add them to the comboBox
            List<Tileset> tilesets = monoGameEditor.Bootstrap.Tilesets;
            comboBoxTilesets.Items.AddRange(tilesets.ToArray());
        }

        /// <summary>
        /// newToolStripMenuItem_Click(object, EventArgs)
        /// Handler for when the 'New' option is chosen from the toolbar.
        /// Opens NewMapDialog for creating new game Map.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create instance of NewMapDialog
            NewMapDialog dialog = new NewMapDialog();

            // Open dialog and wait for submitted results.
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                // Once dialog reterns results create a new Map based on given dimensions.
                monoGameEditor.CreateMap(
                    dialog.creationDetails.MapWidth,
                    dialog.creationDetails.MapHeight,
                    dialog.creationDetails.TileWidth,
                    dialog.creationDetails.TileHeight
                );
            }
        }

        /// <summary>
        /// saveToolStripMenuItem_Click(object, EventArgs)
        /// Handler for when the 'Save' option is selected from the toolbar.
        /// Opens up a SaveFileDialog and waits for the user to name the file and
        /// submit with the Save button. Saves current Map properties to .map file.
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create instance of a SaveFileDialog, only show .map files in the file filter.
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "TacticsRPG Game Map (*.map)|*.map"
            };

            // Wait for SaveFileDialog results, save Map properties to newly created .map file.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Open a FileStream and write Map data to .map file.
                using (FileStream fStream = File.OpenWrite(dialog.FileName))
                {
                    monoGameEditor.SaveMap(fStream); // Handles saving Map properties.
                }   
            }

        }

        /// <summary>
        /// loadToolStripMenuItem_Click(object, EventArgs)
        /// Handler for when the 'Load' option is selected from the toolbar.
        /// Opens an instance of OpenFileDialog and prompts users to select
        /// a .map file to load into the editor.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create instance of an OpenFileDialog and filter for only selecting a single .map file.
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "TacticsRPG Game Map (*.map)|*.map",
                Multiselect = false,
                CheckFileExists = true
            };

            // Open dialog and wait for results, open a FileStream to load Map details from .Map file.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Open FileStream and read Map properties from .map file.
                using (FileStream fStream = File.OpenRead(dialog.FileName))
                {
                    monoGameEditor.LoadMap(fStream); // Handles Loading Map data into the editor.
                }
            }
        }

        /// <summary>
        /// comboBoxTilesets_SelectedIndexChanged(object, EventArgs)
        /// Handler for when the Tilset comboBox is changed.
        /// Loads selected Tileset to the tilesetPreviewer.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void comboBoxTilesets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the Tileset, based on the Name in the comboBox, to the selected item.
            Tileset tileset = comboBoxTilesets.SelectedItem as Tileset;

            // Enable or Disable the 'Edit Tileset' button based on whether a Tileset is selected.
            buttonEditTileset.Enabled = tileset != null;
            if(tileset == null) // if no Tileset return
                return;

            // Show the selected Tileset in the tilesetPreviewer.
            tilesetPreviewer.Tileset = tileset;
        }

        /// <summary>
        /// tilesetPreviewer_TileSelect(Tileset, int)
        /// Handler for when a Tile frame is selcted within the tilesetPreviewer.
        /// Sets the brushTile to the selected frame for editing the Map. 
        /// </summary>
        /// <param name="tileset">(Tileset) - The current tileset selected.</param>
        /// <param name="frameIndex">(int) - The index of the selected frame of the Tileset</param>
        private void tilesetPreviewer_TileSelect(Tileset tileset, int frameIndex)
        {
            // Create new brushTile from the given Tileset at the selected frameIndex.
            Tile brushTile = new Tile()
            {
                TilesetIndex = monoGameEditor.Bootstrap.Tilesets.IndexOf(tileset),
                TileIndex = frameIndex
            };

            // Set the Editor's BrushTile to the created brushTile.
            monoGameEditor.BrushTile = brushTile;
        }

        /// <summary>
        /// buttonEditTileset_Click(object, EventArgs)
        /// Handler for then the 'Edit Tileset' button is clicked.
        /// Opens an EditTilesetDialog in which the user can divide the
        /// Tileset into seperate, selectable frames.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void buttonEditTileset_Click(object sender, EventArgs e)
        {
            // Create an instance of EditTilesetDialog with the currently selected Tileset (comboBox)
            EditTilesetDialog dialog = new EditTilesetDialog()
            {
                SourceTileset = (Tileset)comboBoxTilesets.SelectedItem
            };

            // Open dialog and wait for results, update Tileset based on the changes made in the dialog.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.SourceTileset.Apply(dialog.ModifiedTileset); // Apply changes to the SourceTileset
                tilesetPreviewer.RefreshFrames(); // Update Tileset frames based on changes.
                monoGameEditor.Bootstrap.SaveTilesets(); // Save updated Tileset data in a JSON file.

            }
        }

        /// <summary>
        /// monoGameEditor_NewMap(Map)
        /// Handler called upon loading a new Map into the editor.
        /// Updates the contents of the layer listBox to show the
        /// layers for the loaded Map.
        /// </summary>
        /// <param name="newMap">(Map) - the newly created Map to be loaded.</param>
        private void monoGameEditor_NewMap(Map newMap)
        {
            // Clear the listBox before showing updated layer info
            listBoxLayers.Items.Clear();

            // Loop through each layer in the new Map and add each to the listBox
            for(int i = 0; i < newMap.Layers.Count; i++)
            {
                listBoxLayers.Items.Add(newMap.Layers[i]);
            }

            // Select the first Layer index by default.
            listBoxLayers.SelectedIndex = 0;

        }

        /// <summary>
        /// listBoxLayers_SelectedIndexChanged(object, EventArgs)
        /// Handler for when a layer is selected in the layer listBox.
        /// Sets active layer to selected layer.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void listBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set active layer in the editor to the selected layer in the listBox.
            monoGameEditor.ActiveLayer = listBoxLayers.SelectedIndex;
        }
    }
}
// END TacticsRPG_GameEditor_MainWindow.cs
