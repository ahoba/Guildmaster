
namespace Tools.Quests
{
    partial class TerminalQuestStageControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxStageEndText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonNextStageRoll = new System.Windows.Forms.Button();
            this.listBoxTests = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStartingText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.textBoxStageEndText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonNextStageRoll);
            this.panel1.Controls.Add(this.listBoxTests);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxStartingText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 232);
            this.panel1.TabIndex = 0;
            // 
            // textBoxStageEndText
            // 
            this.textBoxStageEndText.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxStageEndText.Location = new System.Drawing.Point(0, 177);
            this.textBoxStageEndText.Name = "textBoxStageEndText";
            this.textBoxStageEndText.Size = new System.Drawing.Size(231, 20);
            this.textBoxStageEndText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ending Text";
            // 
            // buttonNextStageRoll
            // 
            this.buttonNextStageRoll.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNextStageRoll.Location = new System.Drawing.Point(0, 141);
            this.buttonNextStageRoll.Name = "buttonNextStageRoll";
            this.buttonNextStageRoll.Size = new System.Drawing.Size(231, 23);
            this.buttonNextStageRoll.TabIndex = 4;
            this.buttonNextStageRoll.Text = "Next Stage Roll";
            this.buttonNextStageRoll.UseVisualStyleBackColor = true;
            // 
            // listBoxTests
            // 
            this.listBoxTests.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxTests.FormattingEnabled = true;
            this.listBoxTests.Location = new System.Drawing.Point(0, 46);
            this.listBoxTests.Name = "listBoxTests";
            this.listBoxTests.Size = new System.Drawing.Size(231, 95);
            this.listBoxTests.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tests";
            // 
            // textBoxStartingText
            // 
            this.textBoxStartingText.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxStartingText.Location = new System.Drawing.Point(0, 13);
            this.textBoxStartingText.Name = "textBoxStartingText";
            this.textBoxStartingText.Size = new System.Drawing.Size(231, 20);
            this.textBoxStartingText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting Text";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Location = new System.Drawing.Point(0, 197);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(231, 31);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Stage Fails Quest";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // TerminalQuestStageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TerminalQuestStageControl";
            this.Size = new System.Drawing.Size(231, 232);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxStartingText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxTests;
        private System.Windows.Forms.Button buttonNextStageRoll;
        private System.Windows.Forms.TextBox textBoxStageEndText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
