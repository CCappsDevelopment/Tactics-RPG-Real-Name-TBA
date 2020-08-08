namespace TacticsRPG_WorldEditor
{
    partial class TacticsRPG_GameEditor_MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TacticsRPG_GameEditor_MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxTilesets = new System.Windows.Forms.ComboBox();
            this.labelTilesetList = new System.Windows.Forms.Label();
            this.buttonEditTileset = new System.Windows.Forms.Button();
            this.listBoxLayers = new System.Windows.Forms.ListBox();
            this.labelLayers = new System.Windows.Forms.Label();
            this.tilesetPreviewer = new TacticsRPG_WorldEditor.Controls.TilesetPreviewer();
            this.monoGameEditor = new TacticsRPG_WorldEditor.MonoGameEditor();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // comboBoxTilesets
            // 
            this.comboBoxTilesets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTilesets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTilesets.FormattingEnabled = true;
            this.comboBoxTilesets.Location = new System.Drawing.Point(676, 47);
            this.comboBoxTilesets.Name = "comboBoxTilesets";
            this.comboBoxTilesets.Size = new System.Drawing.Size(215, 21);
            this.comboBoxTilesets.TabIndex = 5;
            this.comboBoxTilesets.SelectedIndexChanged += new System.EventHandler(this.comboBoxTilesets_SelectedIndexChanged);
            // 
            // labelTilesetList
            // 
            this.labelTilesetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTilesetList.AutoSize = true;
            this.labelTilesetList.Location = new System.Drawing.Point(629, 50);
            this.labelTilesetList.Name = "labelTilesetList";
            this.labelTilesetList.Size = new System.Drawing.Size(41, 13);
            this.labelTilesetList.TabIndex = 6;
            this.labelTilesetList.Text = "Tileset:";
            // 
            // buttonEditTileset
            // 
            this.buttonEditTileset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditTileset.Enabled = false;
            this.buttonEditTileset.Location = new System.Drawing.Point(632, 380);
            this.buttonEditTileset.Name = "buttonEditTileset";
            this.buttonEditTileset.Size = new System.Drawing.Size(259, 25);
            this.buttonEditTileset.TabIndex = 7;
            this.buttonEditTileset.Text = "Edit Tileset...";
            this.buttonEditTileset.UseVisualStyleBackColor = true;
            this.buttonEditTileset.Click += new System.EventHandler(this.buttonEditTileset_Click);
            // 
            // listBoxLayers
            // 
            this.listBoxLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLayers.FormattingEnabled = true;
            this.listBoxLayers.Location = new System.Drawing.Point(632, 434);
            this.listBoxLayers.Name = "listBoxLayers";
            this.listBoxLayers.Size = new System.Drawing.Size(259, 108);
            this.listBoxLayers.TabIndex = 8;
            this.listBoxLayers.SelectedIndexChanged += new System.EventHandler(this.listBoxLayers_SelectedIndexChanged);
            // 
            // labelLayers
            // 
            this.labelLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLayers.AutoSize = true;
            this.labelLayers.Location = new System.Drawing.Point(629, 418);
            this.labelLayers.Name = "labelLayers";
            this.labelLayers.Size = new System.Drawing.Size(44, 13);
            this.labelLayers.TabIndex = 9;
            this.labelLayers.Text = "Layers: ";
            // 
            // tilesetPreviewer
            // 
            this.tilesetPreviewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesetPreviewer.AutoScroll = true;
            this.tilesetPreviewer.Location = new System.Drawing.Point(632, 74);
            this.tilesetPreviewer.Name = "tilesetPreviewer";
            this.tilesetPreviewer.Size = new System.Drawing.Size(259, 300);
            this.tilesetPreviewer.TabIndex = 4;
            this.tilesetPreviewer.Tileset = null;
            this.tilesetPreviewer.TileSelect += new TacticsRPG_WorldEditor.Controls.TilesetPreviewer.OnTileSelectHandler(this.tilesetPreviewer_TileSelect);
            // 
            // monoGameEditor
            // 
            this.monoGameEditor.ActiveLayer = 0;
            this.monoGameEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monoGameEditor.Bootstrap = null;
            this.monoGameEditor.BrushTile = null;
            this.monoGameEditor.Location = new System.Drawing.Point(0, 27);
            this.monoGameEditor.MouseHoverUpdatesOnly = false;
            this.monoGameEditor.Name = "monoGameEditor";
            this.monoGameEditor.Size = new System.Drawing.Size(626, 527);
            this.monoGameEditor.TabIndex = 0;
            this.monoGameEditor.Text = "monoGameEditor";
            this.monoGameEditor.NewMap += new TacticsRPG_WorldEditor.MonoGameEditor.OnNewMapHandler(this.monoGameEditor_NewMap);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // TacticsRPG_GameEditor_MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 554);
            this.Controls.Add(this.labelLayers);
            this.Controls.Add(this.listBoxLayers);
            this.Controls.Add(this.buttonEditTileset);
            this.Controls.Add(this.labelTilesetList);
            this.Controls.Add(this.comboBoxTilesets);
            this.Controls.Add(this.tilesetPreviewer);
            this.Controls.Add(this.monoGameEditor);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TacticsRPG_GameEditor_MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tactics RPG Game Editor";
            this.Load += new System.EventHandler(this.TacticsRPG_GameEditor_MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TacticsRPG_WorldEditor.MonoGameEditor monoGameEditor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private Controls.TilesetPreviewer tilesetPreviewer;
        private System.Windows.Forms.ComboBox comboBoxTilesets;
        private System.Windows.Forms.Label labelTilesetList;
        private System.Windows.Forms.Button buttonEditTileset;
        private System.Windows.Forms.ListBox listBoxLayers;
        private System.Windows.Forms.Label labelLayers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}

