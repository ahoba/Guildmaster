
namespace Tools.Scenes.Tiles
{
    partial class TileRepositoryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxTileSetName = new System.Windows.Forms.TextBox();
            this.buttonCreateTileSet = new System.Windows.Forms.Button();
            this.buttonSaveTileSet = new System.Windows.Forms.Button();
            this.listBoxTileSets = new System.Windows.Forms.ListBox();
            this.tileTextureSelector = new Tools.Content.TileTextureSelector();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxTileSetName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateTileSet, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveTileSet, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxTileSets, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tileTextureSelector, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 278);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxTileSetName
            // 
            this.textBoxTileSetName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTileSetName.Location = new System.Drawing.Point(155, 3);
            this.textBoxTileSetName.Name = "textBoxTileSetName";
            this.textBoxTileSetName.Size = new System.Drawing.Size(147, 20);
            this.textBoxTileSetName.TabIndex = 0;
            // 
            // buttonCreateTileSet
            // 
            this.buttonCreateTileSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateTileSet.Location = new System.Drawing.Point(3, 252);
            this.buttonCreateTileSet.Name = "buttonCreateTileSet";
            this.buttonCreateTileSet.Size = new System.Drawing.Size(146, 23);
            this.buttonCreateTileSet.TabIndex = 1;
            this.buttonCreateTileSet.Text = "Create Tile Set";
            this.buttonCreateTileSet.UseVisualStyleBackColor = true;
            this.buttonCreateTileSet.Click += new System.EventHandler(this.buttonCreateTileSet_Click);
            // 
            // buttonSaveTileSet
            // 
            this.buttonSaveTileSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveTileSet.Location = new System.Drawing.Point(155, 252);
            this.buttonSaveTileSet.Name = "buttonSaveTileSet";
            this.buttonSaveTileSet.Size = new System.Drawing.Size(147, 23);
            this.buttonSaveTileSet.TabIndex = 2;
            this.buttonSaveTileSet.Text = "Save Tile Set";
            this.buttonSaveTileSet.UseVisualStyleBackColor = true;
            this.buttonSaveTileSet.Click += new System.EventHandler(this.buttonSaveTileSet_Click);
            // 
            // listBoxTileSets
            // 
            this.listBoxTileSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTileSets.FormattingEnabled = true;
            this.listBoxTileSets.Location = new System.Drawing.Point(3, 3);
            this.listBoxTileSets.Name = "listBoxTileSets";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxTileSets, 2);
            this.listBoxTileSets.Size = new System.Drawing.Size(146, 243);
            this.listBoxTileSets.TabIndex = 3;
            this.listBoxTileSets.SelectedIndexChanged += new System.EventHandler(this.listBoxTileSets_SelectedIndexChanged);
            // 
            // tileTextureSelector
            // 
            this.tileTextureSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTextureSelector.Location = new System.Drawing.Point(155, 30);
            this.tileTextureSelector.Name = "tileTextureSelector";
            this.tileTextureSelector.Size = new System.Drawing.Size(147, 216);
            this.tileTextureSelector.TabIndex = 4;
            this.tileTextureSelector.TextureRepository = null;
            // 
            // TileRepositoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TileRepositoryControl";
            this.Size = new System.Drawing.Size(305, 278);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxTileSetName;
        private System.Windows.Forms.Button buttonCreateTileSet;
        private System.Windows.Forms.Button buttonSaveTileSet;
        private System.Windows.Forms.ListBox listBoxTileSets;
        private Content.TileTextureSelector tileTextureSelector;
    }
}
