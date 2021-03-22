
namespace Tools.Animations
{
    partial class AnimationRepositoryControl
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
            this.listBoxAnimations = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCreateAnimation = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.animationEditControl = new Tools.Animations.AnimationEditControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxAnimations
            // 
            this.listBoxAnimations.DisplayMember = "Name";
            this.listBoxAnimations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAnimations.FormattingEnabled = true;
            this.listBoxAnimations.Location = new System.Drawing.Point(3, 3);
            this.listBoxAnimations.Name = "listBoxAnimations";
            this.listBoxAnimations.Size = new System.Drawing.Size(108, 244);
            this.listBoxAnimations.TabIndex = 0;
            this.listBoxAnimations.ValueMember = "Name";
            this.listBoxAnimations.SelectedIndexChanged += new System.EventHandler(this.listBoxAnimations_SelectedIndexChanged);
            this.listBoxAnimations.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxAnimations_MouseDown);
            this.listBoxAnimations.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxAnimations_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(279, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 292);
            this.panel1.TabIndex = 3;
            // 
            // buttonCreateAnimation
            // 
            this.buttonCreateAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateAnimation.Location = new System.Drawing.Point(3, 253);
            this.buttonCreateAnimation.Name = "buttonCreateAnimation";
            this.buttonCreateAnimation.Size = new System.Drawing.Size(108, 36);
            this.buttonCreateAnimation.TabIndex = 4;
            this.buttonCreateAnimation.Text = "Create Animation";
            this.buttonCreateAnimation.UseVisualStyleBackColor = true;
            this.buttonCreateAnimation.Click += new System.EventHandler(this.buttonCreateAnimation_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.86282F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.13718F));
            this.tableLayoutPanel1.Controls.Add(this.animationEditControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxAnimations, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateAnimation, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.61644F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.38356F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 292);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // animationEditControl
            // 
            this.animationEditControl.Animation = null;
            this.animationEditControl.Location = new System.Drawing.Point(117, 3);
            this.animationEditControl.Name = "animationEditControl";
            this.tableLayoutPanel1.SetRowSpan(this.animationEditControl, 2);
            this.animationEditControl.Size = new System.Drawing.Size(293, 286);
            this.animationEditControl.TabIndex = 0;
            this.animationEditControl.TextureRepository = null;
            // 
            // AnimationRepositoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "AnimationRepositoryControl";
            this.Size = new System.Drawing.Size(503, 292);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAnimations;
        private System.Windows.Forms.Panel panel1;
        private AnimationEditControl animationEditControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCreateAnimation;
    }
}
