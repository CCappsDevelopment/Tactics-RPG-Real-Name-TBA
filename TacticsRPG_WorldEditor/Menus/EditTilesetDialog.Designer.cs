namespace TacticsRPG_WorldEditor.Menus
{
    partial class EditTilesetDialog
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
            this.buttonGenerateFrames = new System.Windows.Forms.Button();
            this.tilesetPreviewer = new TacticsRPG_WorldEditor.Controls.TilesetPreviewer();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGenerateFrames
            // 
            this.buttonGenerateFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGenerateFrames.Location = new System.Drawing.Point(12, 513);
            this.buttonGenerateFrames.Name = "buttonGenerateFrames";
            this.buttonGenerateFrames.Size = new System.Drawing.Size(128, 36);
            this.buttonGenerateFrames.TabIndex = 1;
            this.buttonGenerateFrames.Text = "Generate Frames";
            this.buttonGenerateFrames.UseVisualStyleBackColor = true;
            this.buttonGenerateFrames.Click += new System.EventHandler(this.buttonGenerateFrames_Click);
            // 
            // tilesetPreviewer
            // 
            this.tilesetPreviewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesetPreviewer.AutoScroll = true;
            this.tilesetPreviewer.Location = new System.Drawing.Point(12, 12);
            this.tilesetPreviewer.Name = "tilesetPreviewer";
            this.tilesetPreviewer.Size = new System.Drawing.Size(760, 495);
            this.tilesetPreviewer.TabIndex = 0;
            this.tilesetPreviewer.Tileset = null;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(670, 513);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 36);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(562, 513);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(102, 36);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // EditTilesetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGenerateFrames);
            this.Controls.Add(this.tilesetPreviewer);
            this.Name = "EditTilesetDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditTilesetDialog";
            this.Load += new System.EventHandler(this.EditTilesetDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TilesetPreviewer tilesetPreviewer;
        private System.Windows.Forms.Button buttonGenerateFrames;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}