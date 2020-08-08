using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// BEGIN GenerateFrameDialog.cs
namespace TacticsRPG_WorldEditor.Menus
{
    /// <summary>
    /// GenerateFramesDialog : Form partial class
    /// Handles events associated with the GenerateFramesDialog
    /// </summary>
    public partial class GenerateFramesDialog : Form
    {
        /// <summary>
        /// GenerationDetails class
        /// Used to store Tile dimensions when dividing Tileset into Frames.
        /// </summary>
        public class GenerationDetails
        {
            public int TileWidth { get; set; }
            public int TileHeight { get; set; }
        }

        public GenerationDetails generationDetails { get; private set; }

        /// <summary>
        /// GenerateFramesDialog() - Default constructor
        /// </summary>
        public GenerateFramesDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// numericUpDown_Enter(object, EventArgs)
        /// Handler for when a NumericUpDown box is selected,
        /// highlights the entire contents of the box.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            NumericUpDown numericControl = (NumericUpDown)sender; // get the NumericUpDown component
            numericControl.Select(0, numericControl.Text.Length); // Select all text in the box
        }

        /// <summary>
        /// buttonOkay_Click(object, EventArgs)
        /// Handler for when the 'OK' button is clicked in the GenerateFramesDialog;
        /// Creates instance of generationDetails, getting values from the NumericUpDown boxes.
        /// Closes then dialog.
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            // Create new generationDetails object from data returned form NumericUpDown boxes
            generationDetails = new GenerationDetails()
            {
                TileWidth = (int)numericTileWidth.Value,
                TileHeight = (int)numericTileHeight.Value
            };

            Close(); // Close the dialog.
        }

        /// <summary>
        /// buttonCancel_Click(object, EventArgs)
        /// Handler for when the 'Cancel' button is clicked; closes the dialog.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close(); // Close the dialog.
        }
    }
}
// END GenerateFrameDialog.cs
