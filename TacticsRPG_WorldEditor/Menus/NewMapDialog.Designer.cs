﻿namespace TacticsRPG_WorldEditor.Menus
{
    partial class NewMapDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericMapWidth = new System.Windows.Forms.NumericUpDown();
            this.numericTileHeight = new System.Windows.Forms.NumericUpDown();
            this.numericTileWidth = new System.Windows.Forms.NumericUpDown();
            this.numericMapHeight = new System.Windows.Forms.NumericUpDown();
            this.labelMapWidth = new System.Windows.Forms.Label();
            this.labelMapHeight = new System.Windows.Forms.Label();
            this.labelTileWidth = new System.Windows.Forms.Label();
            this.labelTileHeight = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOkay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericMapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMapHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // numericMapWidth
            // 
            this.numericMapWidth.Location = new System.Drawing.Point(80, 16);
            this.numericMapWidth.Name = "numericMapWidth";
            this.numericMapWidth.Size = new System.Drawing.Size(120, 20);
            this.numericMapWidth.TabIndex = 0;
            this.numericMapWidth.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericTileHeight
            // 
            this.numericTileHeight.Location = new System.Drawing.Point(80, 94);
            this.numericTileHeight.Name = "numericTileHeight";
            this.numericTileHeight.Size = new System.Drawing.Size(120, 20);
            this.numericTileHeight.TabIndex = 3;
            this.numericTileHeight.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericTileWidth
            // 
            this.numericTileWidth.Location = new System.Drawing.Point(80, 68);
            this.numericTileWidth.Name = "numericTileWidth";
            this.numericTileWidth.Size = new System.Drawing.Size(120, 20);
            this.numericTileWidth.TabIndex = 2;
            this.numericTileWidth.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericMapHeight
            // 
            this.numericMapHeight.Location = new System.Drawing.Point(80, 42);
            this.numericMapHeight.Name = "numericMapHeight";
            this.numericMapHeight.Size = new System.Drawing.Size(120, 20);
            this.numericMapHeight.TabIndex = 1;
            this.numericMapHeight.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // labelMapWidth
            // 
            this.labelMapWidth.AutoSize = true;
            this.labelMapWidth.Location = new System.Drawing.Point(12, 18);
            this.labelMapWidth.Name = "labelMapWidth";
            this.labelMapWidth.Size = new System.Drawing.Size(62, 13);
            this.labelMapWidth.TabIndex = 4;
            this.labelMapWidth.Text = "Map Width:";
            // 
            // labelMapHeight
            // 
            this.labelMapHeight.AutoSize = true;
            this.labelMapHeight.Location = new System.Drawing.Point(12, 44);
            this.labelMapHeight.Name = "labelMapHeight";
            this.labelMapHeight.Size = new System.Drawing.Size(65, 13);
            this.labelMapHeight.TabIndex = 5;
            this.labelMapHeight.Text = "Map Height:";
            // 
            // labelTileWidth
            // 
            this.labelTileWidth.AutoSize = true;
            this.labelTileWidth.Location = new System.Drawing.Point(12, 70);
            this.labelTileWidth.Name = "labelTileWidth";
            this.labelTileWidth.Size = new System.Drawing.Size(58, 13);
            this.labelTileWidth.TabIndex = 6;
            this.labelTileWidth.Text = "Tile Width:";
            // 
            // labelTileHeight
            // 
            this.labelTileHeight.AutoSize = true;
            this.labelTileHeight.Location = new System.Drawing.Point(12, 96);
            this.labelTileHeight.Name = "labelTileHeight";
            this.labelTileHeight.Size = new System.Drawing.Size(61, 13);
            this.labelTileHeight.TabIndex = 7;
            this.labelTileHeight.Text = "Tile Height:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(115, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOkay
            // 
            this.buttonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOkay.Location = new System.Drawing.Point(19, 123);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(85, 23);
            this.buttonOkay.TabIndex = 8;
            this.buttonOkay.Text = "OK";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // NewMapDialog
            // 
            this.AcceptButton = this.buttonOkay;
            this.ClientSize = new System.Drawing.Size(219, 161);
            this.Controls.Add(this.buttonOkay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTileHeight);
            this.Controls.Add(this.labelTileWidth);
            this.Controls.Add(this.labelMapHeight);
            this.Controls.Add(this.labelMapWidth);
            this.Controls.Add(this.numericMapHeight);
            this.Controls.Add(this.numericTileWidth);
            this.Controls.Add(this.numericTileHeight);
            this.Controls.Add(this.numericMapWidth);
            this.Name = "NewMapDialog";
            this.Text = "New Map";
            ((System.ComponentModel.ISupportInitialize)(this.numericMapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMapHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericMapWidth;
        private System.Windows.Forms.NumericUpDown numericTileHeight;
        private System.Windows.Forms.NumericUpDown numericTileWidth;
        private System.Windows.Forms.NumericUpDown numericMapHeight;
        private System.Windows.Forms.Label labelMapWidth;
        private System.Windows.Forms.Label labelMapHeight;
        private System.Windows.Forms.Label labelTileWidth;
        private System.Windows.Forms.Label labelTileHeight;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOkay;
    }
}