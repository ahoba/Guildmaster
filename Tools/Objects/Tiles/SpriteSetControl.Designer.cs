
namespace Tools.Objects.Tiles
{
    partial class SpriteSetControl
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
            this.tileAnimationControl1 = new Tools.Objects.Tiles.SpritesAnimationControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tileSpritesControl1 = new Tools.Objects.Tiles.SpritesSourceControl();
            this.buttonAddSprite = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tileAnimationControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(319, 237);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tileAnimationControl1
            // 
            this.tileAnimationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileAnimationControl1.Location = new System.Drawing.Point(162, 3);
            this.tileAnimationControl1.Name = "tileAnimationControl1";
            this.tileAnimationControl1.Size = new System.Drawing.Size(154, 231);
            this.tileAnimationControl1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tileSpritesControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddSprite, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.81818F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(153, 231);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tileSpritesControl1
            // 
            this.tileSpritesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSpritesControl1.GraphicsDevice = null;
            this.tileSpritesControl1.Location = new System.Drawing.Point(3, 3);
            this.tileSpritesControl1.Name = "tileSpritesControl1";
            this.tileSpritesControl1.Size = new System.Drawing.Size(147, 182);
            this.tileSpritesControl1.SourceImage = null;
            this.tileSpritesControl1.TabIndex = 0;
            this.tileSpritesControl1.TileDimension = 16;
            // 
            // buttonAddSprite
            // 
            this.buttonAddSprite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddSprite.Location = new System.Drawing.Point(3, 191);
            this.buttonAddSprite.Name = "buttonAddSprite";
            this.buttonAddSprite.Size = new System.Drawing.Size(147, 37);
            this.buttonAddSprite.TabIndex = 1;
            this.buttonAddSprite.Text = "Add Sprite";
            this.buttonAddSprite.UseVisualStyleBackColor = true;
            this.buttonAddSprite.Click += new System.EventHandler(this.button1_Click);
            // 
            // TileObjectSpritesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TileObjectSpritesControl";
            this.Size = new System.Drawing.Size(319, 237);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SpritesAnimationControl tileAnimationControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private SpritesSourceControl tileSpritesControl1;
        private System.Windows.Forms.Button buttonAddSprite;
    }
}
