
namespace Tools.Scenes.Tiles
{
    partial class TileMapEditorControl
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonErase = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxMapName = new System.Windows.Forms.TextBox();
            this.comboBoxLayer = new System.Windows.Forms.ComboBox();
            this.tileMapControl = new Tools.Scenes.Tiles.TileMapControl();
            this.tileSetControl = new Tools.Scenes.Tiles.TileSetControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tileMapControl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tileSetControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 343);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonErase});
            this.toolStrip.Location = new System.Drawing.Point(278, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(279, 34);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonErase
            // 
            this.toolStripButtonErase.CheckOnClick = true;
            this.toolStripButtonErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonErase.Image = global::Tools.Properties.Resources.eraser;
            this.toolStripButtonErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonErase.Name = "toolStripButtonErase";
            this.toolStripButtonErase.Size = new System.Drawing.Size(23, 31);
            this.toolStripButtonErase.Text = "Erase";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownHeight, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownWidth, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSave, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMapName, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxLayer, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(278, 274);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 69);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(3, 37);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownHeight.TabIndex = 0;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(72, 37);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownWidth.TabIndex = 1;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width";
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(210, 37);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(66, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxMapName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxMapName, 2);
            this.textBoxMapName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMapName.Location = new System.Drawing.Point(141, 3);
            this.textBoxMapName.Name = "textBoxMapName";
            this.textBoxMapName.Size = new System.Drawing.Size(135, 20);
            this.textBoxMapName.TabIndex = 5;
            // 
            // comboBoxLayer
            // 
            this.comboBoxLayer.FormattingEnabled = true;
            this.comboBoxLayer.Location = new System.Drawing.Point(141, 37);
            this.comboBoxLayer.Name = "comboBoxLayer";
            this.comboBoxLayer.Size = new System.Drawing.Size(63, 21);
            this.comboBoxLayer.TabIndex = 6;
            // 
            // tileMapControl
            // 
            this.tileMapControl.AllowDrop = true;
            this.tileMapControl.ColumnCount = 10;
            this.tileMapControl.Location = new System.Drawing.Point(281, 37);
            this.tileMapControl.Name = "tileMapControl";
            this.tileMapControl.RowCount = 10;
            this.tileMapControl.SelectedColumn = null;
            this.tileMapControl.SelectedRow = null;
            this.tileMapControl.Size = new System.Drawing.Size(273, 234);
            this.tileMapControl.TabIndex = 2;
            this.tileMapControl.TileSet = null;
            this.tileMapControl.SelectedTileChanged += new System.EventHandler<Tools.Scenes.Tiles.SelectedTileChangedEventArgs>(this.tileMapControl_SelectedTileChanged);
            this.tileMapControl.SelectedTileStart += new System.EventHandler<Tools.Scenes.Tiles.SelectedTileChangedEventArgs>(this.tileMapControl_SelectedTileStart);
            this.tileMapControl.SelectedTileEnd += new System.EventHandler<Tools.Scenes.Tiles.SelectedTileChangedEventArgs>(this.tileMapControl_SelectedTileEnd);
            this.tileMapControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.tileMapControl_DragDrop);
            this.tileMapControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.tileMapControl_DragEnter);
            // 
            // tileSetControl
            // 
            this.tileSetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSetControl.Location = new System.Drawing.Point(3, 3);
            this.tileSetControl.Name = "tileSetControl";
            this.tableLayoutPanel1.SetRowSpan(this.tileSetControl, 3);
            this.tileSetControl.Size = new System.Drawing.Size(272, 337);
            this.tileSetControl.TabIndex = 3;
            this.tileSetControl.TileSetRepository = null;
            this.tileSetControl.SelectedTileSetChanged += new System.EventHandler<Tools.Scenes.Tiles.SelectedTileSetChangedEventArgs>(this.tileSetControl_SelectedTileSetChanged);
            // 
            // TileMapEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TileMapEditorControl";
            this.Size = new System.Drawing.Size(557, 343);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private TileMapControl tileMapControl;
        private TileSetControl tileSetControl;
        private System.Windows.Forms.ToolStripButton toolStripButtonErase;
        private System.Windows.Forms.TextBox textBoxMapName;
        private System.Windows.Forms.ComboBox comboBoxLayer;
    }
}
