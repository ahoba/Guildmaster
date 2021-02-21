
namespace Tools.Animations
{
    partial class AnimationEditControl
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
            this.buttonAddSprite = new System.Windows.Forms.Button();
            this.buttonRemoveSprite = new System.Windows.Forms.Button();
            this.animationControl = new Tools.Animations.AnimationControl();
            this.tileTextureSelector = new Tools.Content.TileTextureSelector();
            this.textBoxAnimationName = new System.Windows.Forms.TextBox();
            this.buttonSaveAnimation = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAddSprite, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonRemoveSprite, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.animationControl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tileTextureSelector, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAnimationName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveAnimation, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 262);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonAddSprite
            // 
            this.buttonAddSprite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddSprite.Location = new System.Drawing.Point(197, 225);
            this.buttonAddSprite.Name = "buttonAddSprite";
            this.buttonAddSprite.Size = new System.Drawing.Size(91, 34);
            this.buttonAddSprite.TabIndex = 2;
            this.buttonAddSprite.Text = "Add Sprite";
            this.buttonAddSprite.UseVisualStyleBackColor = true;
            this.buttonAddSprite.Click += new System.EventHandler(this.buttonAddSprite_Click);
            // 
            // buttonRemoveSprite
            // 
            this.buttonRemoveSprite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveSprite.Location = new System.Drawing.Point(294, 225);
            this.buttonRemoveSprite.Name = "buttonRemoveSprite";
            this.buttonRemoveSprite.Size = new System.Drawing.Size(93, 34);
            this.buttonRemoveSprite.TabIndex = 3;
            this.buttonRemoveSprite.Text = "Remove Sprite";
            this.buttonRemoveSprite.UseVisualStyleBackColor = true;
            this.buttonRemoveSprite.Click += new System.EventHandler(this.buttonRemoveSprite_Click);
            // 
            // animationControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.animationControl, 2);
            this.animationControl.Location = new System.Drawing.Point(197, 29);
            this.animationControl.Name = "animationControl";
            this.animationControl.SelectedFrame = null;
            this.animationControl.Size = new System.Drawing.Size(190, 190);
            this.animationControl.TabIndex = 1;
            // 
            // tileTextureSelector
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tileTextureSelector, 2);
            this.tileTextureSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTextureSelector.Location = new System.Drawing.Point(3, 3);
            this.tileTextureSelector.Name = "tileTextureSelector";
            this.tableLayoutPanel1.SetRowSpan(this.tileTextureSelector, 2);
            this.tileTextureSelector.Size = new System.Drawing.Size(188, 216);
            this.tileTextureSelector.TabIndex = 0;
            this.tileTextureSelector.TextureRepository = null;
            // 
            // textBoxAnimationName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxAnimationName, 2);
            this.textBoxAnimationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAnimationName.Location = new System.Drawing.Point(197, 3);
            this.textBoxAnimationName.Name = "textBoxAnimationName";
            this.textBoxAnimationName.Size = new System.Drawing.Size(190, 20);
            this.textBoxAnimationName.TabIndex = 4;
            // 
            // buttonSaveAnimation
            // 
            this.buttonSaveAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveAnimation.Location = new System.Drawing.Point(3, 225);
            this.buttonSaveAnimation.Name = "buttonSaveAnimation";
            this.buttonSaveAnimation.Size = new System.Drawing.Size(91, 34);
            this.buttonSaveAnimation.TabIndex = 5;
            this.buttonSaveAnimation.Text = "Save Animation";
            this.buttonSaveAnimation.UseVisualStyleBackColor = true;
            this.buttonSaveAnimation.Click += new System.EventHandler(this.buttonSaveAnimation_Click);
            // 
            // AnimationEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AnimationEditControl";
            this.Size = new System.Drawing.Size(390, 262);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Content.TileTextureSelector tileTextureSelector;
        private AnimationControl animationControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAddSprite;
        private System.Windows.Forms.Button buttonRemoveSprite;
        private System.Windows.Forms.TextBox textBoxAnimationName;
        private System.Windows.Forms.Button buttonSaveAnimation;
    }
}
