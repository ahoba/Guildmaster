
namespace Tools.Content
{
    partial class TileTextureSelector
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
            this.comboBoxTextureIds = new System.Windows.Forms.ComboBox();
            this.tileTextureControl = new Tools.Util.TileTextureControl();
            this.SuspendLayout();
            // 
            // comboBoxTextureIds
            // 
            this.comboBoxTextureIds.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTextureIds.FormattingEnabled = true;
            this.comboBoxTextureIds.Location = new System.Drawing.Point(0, 0);
            this.comboBoxTextureIds.Name = "comboBoxTextureIds";
            this.comboBoxTextureIds.Size = new System.Drawing.Size(283, 21);
            this.comboBoxTextureIds.TabIndex = 0;
            this.comboBoxTextureIds.SelectedIndexChanged += new System.EventHandler(this.comboBoxTextureIds_SelectedIndexChanged);
            // 
            // tileTextureControl
            // 
            this.tileTextureControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTextureControl.Location = new System.Drawing.Point(0, 21);
            this.tileTextureControl.Name = "tileTextureControl";
            this.tileTextureControl.Size = new System.Drawing.Size(283, 262);
            this.tileTextureControl.TabIndex = 1;
            this.tileTextureControl.TileDimension = 16;
            // 
            // TileTextureSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileTextureControl);
            this.Controls.Add(this.comboBoxTextureIds);
            this.Name = "TileTextureSelector";
            this.Size = new System.Drawing.Size(283, 283);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTextureIds;
        private Util.TileTextureControl tileTextureControl;
    }
}
