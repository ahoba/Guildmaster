
namespace Tools.Content
{
    partial class TextureRepositoryControl
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxTextures = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxTexture = new System.Windows.Forms.PictureBox();
            this.toolStripButtonOpenTexture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveTexture = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpenTexture,
            this.toolStripButtonRemoveTexture});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(289, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxTextures, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(289, 280);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // listBoxTextures
            // 
            this.listBoxTextures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTextures.FormattingEnabled = true;
            this.listBoxTextures.Location = new System.Drawing.Point(3, 3);
            this.listBoxTextures.Name = "listBoxTextures";
            this.listBoxTextures.Size = new System.Drawing.Size(138, 246);
            this.listBoxTextures.TabIndex = 0;
            this.listBoxTextures.SelectedIndexChanged += new System.EventHandler(this.listBoxTextures_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBoxTexture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(147, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 246);
            this.panel1.TabIndex = 1;
            // 
            // pictureBoxTexture
            // 
            this.pictureBoxTexture.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBoxTexture.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTexture.Name = "pictureBoxTexture";
            this.pictureBoxTexture.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxTexture.TabIndex = 0;
            this.pictureBoxTexture.TabStop = false;
            // 
            // toolStripButtonOpenTexture
            // 
            this.toolStripButtonOpenTexture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenTexture.Image = global::Tools.Properties.Resources.blue_folder_open;
            this.toolStripButtonOpenTexture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenTexture.Name = "toolStripButtonOpenTexture";
            this.toolStripButtonOpenTexture.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenTexture.Text = "Open Texture";
            this.toolStripButtonOpenTexture.Click += new System.EventHandler(this.toolStripButtonOpenTexture_Click);
            // 
            // toolStripButtonRemoveTexture
            // 
            this.toolStripButtonRemoveTexture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveTexture.Image = global::Tools.Properties.Resources.blue_document_hf_delete_footer;
            this.toolStripButtonRemoveTexture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveTexture.Name = "toolStripButtonRemoveTexture";
            this.toolStripButtonRemoveTexture.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemoveTexture.Text = "Remove Texture";
            this.toolStripButtonRemoveTexture.Click += new System.EventHandler(this.toolStripButtonRemoveTexture_Click);
            // 
            // TextureRepositoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TextureRepositoryControl";
            this.Size = new System.Drawing.Size(289, 305);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxTextures;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxTexture;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenTexture;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveTexture;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
