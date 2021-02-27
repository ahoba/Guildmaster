
namespace Tools
{
    partial class MainForm
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
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTextureRepository = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTileSetRepository = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMapEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTextureRepository,
            this.toolStripButtonTileSetRepository,
            this.toolStripButtonMapEditor});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(800, 25);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButtonTextureRepository
            // 
            this.toolStripButtonTextureRepository.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTextureRepository.Image = global::Tools.Properties.Resources.images;
            this.toolStripButtonTextureRepository.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTextureRepository.Name = "toolStripButtonTextureRepository";
            this.toolStripButtonTextureRepository.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTextureRepository.Text = "Texture Repository";
            this.toolStripButtonTextureRepository.Click += new System.EventHandler(this.toolStripButtonTextureRepository_Click);
            // 
            // toolStripButtonTileSetRepository
            // 
            this.toolStripButtonTileSetRepository.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTileSetRepository.Image = global::Tools.Properties.Resources.table;
            this.toolStripButtonTileSetRepository.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTileSetRepository.Name = "toolStripButtonTileSetRepository";
            this.toolStripButtonTileSetRepository.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTileSetRepository.Text = "Tile Set Repository";
            this.toolStripButtonTileSetRepository.Click += new System.EventHandler(this.toolStripButtonTileSetRepository_Click);
            // 
            // toolStripButtonMapEditor
            // 
            this.toolStripButtonMapEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMapEditor.Image = global::Tools.Properties.Resources.map__pencil;
            this.toolStripButtonMapEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMapEditor.Name = "toolStripButtonMapEditor";
            this.toolStripButtonMapEditor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMapEditor.Text = "Map Editor";
            this.toolStripButtonMapEditor.Click += new System.EventHandler(this.toolStripButtonMapEditor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripMain);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonTextureRepository;
        private System.Windows.Forms.ToolStripButton toolStripButtonTileSetRepository;
        private System.Windows.Forms.ToolStripButton toolStripButtonMapEditor;
    }
}

