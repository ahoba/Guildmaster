
namespace Tools.Scenes.Tiles
{
    partial class TileMapRepositoryControl
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
            this.listBoxMaps = new System.Windows.Forms.ListBox();
            this.tileMapEditorControl = new Tools.Scenes.Tiles.TileMapEditorControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCreateMap = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMaps
            // 
            this.listBoxMaps.DisplayMember = "Name";
            this.listBoxMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMaps.FormattingEnabled = true;
            this.listBoxMaps.Location = new System.Drawing.Point(3, 3);
            this.listBoxMaps.Name = "listBoxMaps";
            this.listBoxMaps.Size = new System.Drawing.Size(127, 315);
            this.listBoxMaps.TabIndex = 0;
            this.listBoxMaps.ValueMember = "Name";
            this.listBoxMaps.SelectedIndexChanged += new System.EventHandler(this.listBoxMaps_SelectedIndexChanged);
            // 
            // tileMapEditorControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tileMapEditorControl, 2);
            this.tileMapEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileMapEditorControl.Location = new System.Drawing.Point(136, 3);
            this.tileMapEditorControl.Map = null;
            this.tileMapEditorControl.Name = "tileMapEditorControl";
            this.tableLayoutPanel1.SetRowSpan(this.tileMapEditorControl, 2);
            this.tileMapEditorControl.Size = new System.Drawing.Size(528, 340);
            this.tileMapEditorControl.TabIndex = 1;
            this.tileMapEditorControl.TileSetRepository = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.tileMapEditorControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxMaps, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateMap, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 346);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonCreateMap
            // 
            this.buttonCreateMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateMap.Location = new System.Drawing.Point(3, 324);
            this.buttonCreateMap.Name = "buttonCreateMap";
            this.buttonCreateMap.Size = new System.Drawing.Size(127, 19);
            this.buttonCreateMap.TabIndex = 2;
            this.buttonCreateMap.Text = "Create Map";
            this.buttonCreateMap.UseVisualStyleBackColor = true;
            this.buttonCreateMap.Click += new System.EventHandler(this.buttonCreateMap_Click);
            // 
            // TileMapRepositoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TileMapRepositoryControl";
            this.Size = new System.Drawing.Size(667, 346);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMaps;
        private TileMapEditorControl tileMapEditorControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCreateMap;
    }
}
