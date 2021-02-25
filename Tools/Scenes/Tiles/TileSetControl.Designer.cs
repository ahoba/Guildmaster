
namespace Tools.Scenes.Tiles
{
    partial class TileSetControl
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.tileTextureControl = new Tools.Util.TileTextureControl();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.DisplayMember = "Name";
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(0, 0);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(216, 21);
            this.comboBox.TabIndex = 0;
            this.comboBox.ValueMember = "Name";
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // tileTextureControl
            // 
            this.tileTextureControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTextureControl.Location = new System.Drawing.Point(0, 21);
            this.tileTextureControl.Name = "tileTextureControl";
            this.tileTextureControl.Size = new System.Drawing.Size(216, 243);
            this.tileTextureControl.TabIndex = 1;
            this.tileTextureControl.TileDimension = 16;
            // 
            // TileSetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileTextureControl);
            this.Controls.Add(this.comboBox);
            this.Name = "TileSetControl";
            this.Size = new System.Drawing.Size(216, 264);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private Util.TileTextureControl tileTextureControl;
    }
}
