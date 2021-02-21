
namespace Tools.Scenes
{
    partial class MapEditorControl
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tileSetControlTileSet = new Tools.Scenes.TileSetControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMapWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMapHeight = new System.Windows.Forms.NumericUpDown();
            this.comboBoxLayers = new System.Windows.Forms.ComboBox();
            this.tileControl = new Tools.Scenes.TileControl();
            this.tileSetControlMap = new Tools.Scenes.TileSetControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonTileSetImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExportTileSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenTileSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonEraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenMap = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapHeight)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tileSetControlMap, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 324);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tileSetControlTileSet, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tileControl, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(246, 324);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tileSetControlTileSet
            // 
            this.tileSetControlTileSet.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tileSetControlTileSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSetControlTileSet.Layer = Danke.Scenes.Tiles.TileMapLayers.Background;
            this.tileSetControlTileSet.Location = new System.Drawing.Point(3, 3);
            this.tileSetControlTileSet.Map = null;
            this.tileSetControlTileSet.Name = "tileSetControlTileSet";
            this.tileSetControlTileSet.SelectedTile = null;
            this.tileSetControlTileSet.Size = new System.Drawing.Size(240, 198);
            this.tileSetControlTileSet.TabIndex = 0;
            this.tileSetControlTileSet.SelectedTileChanged += new System.EventHandler<System.EventArgs>(this.tileSetControlTileSet_SelectedTileChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownMapWidth, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownMapHeight, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxLayers, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 301);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // numericUpDownMapWidth
            // 
            this.numericUpDownMapWidth.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownMapWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMapWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMapWidth.Name = "numericUpDownMapWidth";
            this.numericUpDownMapWidth.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownMapWidth.TabIndex = 0;
            this.numericUpDownMapWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMapWidth.ValueChanged += new System.EventHandler(this.numericUpDownMapWidth_ValueChanged);
            // 
            // numericUpDownMapHeight
            // 
            this.numericUpDownMapHeight.Location = new System.Drawing.Point(85, 3);
            this.numericUpDownMapHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMapHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMapHeight.Name = "numericUpDownMapHeight";
            this.numericUpDownMapHeight.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownMapHeight.TabIndex = 1;
            this.numericUpDownMapHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMapHeight.ValueChanged += new System.EventHandler(this.numericUpDownMapHeight_ValueChanged);
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.Location = new System.Drawing.Point(167, 3);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(76, 21);
            this.comboBoxLayers.TabIndex = 2;
            // 
            // tileControl
            // 
            this.tileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl.Location = new System.Drawing.Point(3, 207);
            this.tileControl.Name = "tileControl";
            this.tileControl.Size = new System.Drawing.Size(240, 91);
            this.tileControl.TabIndex = 2;
            this.tileControl.Tile = null;
            this.tileControl.TileSet = null;
            // 
            // tileSetControlMap
            // 
            this.tileSetControlMap.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tileSetControlMap.Layer = Danke.Scenes.Tiles.TileMapLayers.Background;
            this.tileSetControlMap.Location = new System.Drawing.Point(249, 3);
            this.tileSetControlMap.Map = null;
            this.tileSetControlMap.Name = "tileSetControlMap";
            this.tileSetControlMap.SelectedTile = null;
            this.tileSetControlMap.Size = new System.Drawing.Size(241, 318);
            this.tileSetControlMap.TabIndex = 1;
            this.tileSetControlMap.SelectedTileChanged += new System.EventHandler<System.EventArgs>(this.tileSetControlMap_SelectedTileChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButtonTileSetImage,
            this.toolStripButtonExportTileSet,
            this.toolStripButtonOpenTileSet,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripButtonEraser,
            this.toolStripButtonExport,
            this.toolStripButtonOpenMap});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(493, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel2.Text = "Tile Set";
            // 
            // toolStripButtonTileSetImage
            // 
            this.toolStripButtonTileSetImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTileSetImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTileSetImage.Name = "toolStripButtonTileSetImage";
            this.toolStripButtonTileSetImage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTileSetImage.Text = "Tile Set Image";
            this.toolStripButtonTileSetImage.Click += new System.EventHandler(this.toolStripButtonTileSetImage_Click);
            // 
            // toolStripButtonExportTileSet
            // 
            this.toolStripButtonExportTileSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportTileSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportTileSet.Name = "toolStripButtonExportTileSet";
            this.toolStripButtonExportTileSet.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportTileSet.Text = "Export Tile Set";
            this.toolStripButtonExportTileSet.Click += new System.EventHandler(this.toolStripButtonExportTileSet_Click);
            // 
            // toolStripButtonOpenTileSet
            // 
            this.toolStripButtonOpenTileSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenTileSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenTileSet.Name = "toolStripButtonOpenTileSet";
            this.toolStripButtonOpenTileSet.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenTileSet.Text = "Open Tile Set";
            this.toolStripButtonOpenTileSet.Click += new System.EventHandler(this.toolStripButtonOpenTileSet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "Map";
            // 
            // toolStripButtonEraser
            // 
            this.toolStripButtonEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEraser.Name = "toolStripButtonEraser";
            this.toolStripButtonEraser.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEraser.Text = "Eraser";
            this.toolStripButtonEraser.Click += new System.EventHandler(this.toolStripButtonEraser_Click);
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExport.Text = "Export Map";
            this.toolStripButtonExport.Click += new System.EventHandler(this.toolStripButtonExport_Click);
            // 
            // toolStripButtonOpenMap
            // 
            this.toolStripButtonOpenMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenMap.Name = "toolStripButtonOpenMap";
            this.toolStripButtonOpenMap.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenMap.Text = "Open Map";
            this.toolStripButtonOpenMap.Click += new System.EventHandler(this.toolStripButtonOpenMap_Click);
            // 
            // MapEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MapEditorControl";
            this.Size = new System.Drawing.Size(493, 349);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapHeight)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private TileSetControl tileSetControlTileSet;
        private TileSetControl tileSetControlMap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numericUpDownMapWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownMapHeight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEraser;
        private System.Windows.Forms.ComboBox comboBoxLayers;
        private TileControl tileControl;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenMap;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportTileSet;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenTileSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonTileSetImage;
    }
}
