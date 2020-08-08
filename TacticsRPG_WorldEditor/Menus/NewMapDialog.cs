using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// BEGIN NewMapDialog.cs
namespace TacticsRPG_WorldEditor.Menus
{
    /// <summary>
    /// NewMapDialog : Form partial class
    /// Contains controls for the dialog that appears
    /// when the 'New' option from the toolbar is clicked.
    /// </summary>
    public partial class NewMapDialog : Form
    {
        /// <summary>
        /// NewMapDialog.CreationDetails class
        /// Holds data for Map and Tile dimensions used in 
        /// creating a new Map,
        /// </summary>
        public class CreationDetails
        {
            public int MapWidth { get; set; }
            public int MapHeight { get; set; }
            public int TileWidth { get; set; }
            public int TileHeight { get; set; }
        }

        public CreationDetails creationDetails { get; private set; } // Dimensions for new Map

        /// <summary>
        /// NewMapDialog() - Default constructor
        /// </summary>
        public NewMapDialog()
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
        /// Handler for when the OK button is clicked in the NewMapDialog;
        /// Creates instance of creationDetails, getting values from the NumericUpDown boxes.
        /// Closes then dialog.
        /// </summary>
        /// <param name="sender">(object) - The object signaling the event.</param>
        /// <param name="e">(EventArgs) - The type of event being sent.</param>
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            // Create new creationDetails object from data returned form NumericUpDown boxes
            creationDetails = new CreationDetails()
            {
                MapWidth = (int)numericMapWidth.Value,
                MapHeight = (int)numericMapHeight.Value,
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
// END NewMapDialog.cs
