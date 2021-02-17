
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
            this.mapEditorControl1 = new Tools.Scenes.MapEditorControl();
            this.SuspendLayout();
            // 
            // mapEditorControl1
            // 
            this.mapEditorControl1.Location = new System.Drawing.Point(109, 25);
            this.mapEditorControl1.Name = "mapEditorControl1";
            this.mapEditorControl1.Size = new System.Drawing.Size(493, 349);
            this.mapEditorControl1.TabIndex = 0;
            this.mapEditorControl1.TileSet = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mapEditorControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Scenes.MapEditorControl mapEditorControl1;
    }
}

