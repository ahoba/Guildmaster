
namespace Tools.Quests
{
    partial class BinaryQuestStageControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxAddFailureStage = new System.Windows.Forms.ComboBox();
            this.comboBoxAddSuccessStage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFailureText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSuccessText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonNextStageRoll = new System.Windows.Forms.Button();
            this.listBoxTests = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStartingText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.textBoxFailureText);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxSuccessText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonNextStageRoll);
            this.panel1.Controls.Add(this.listBoxTests);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxStartingText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(240, 280);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxAddFailureStage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxAddSuccessStage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 231);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(236, 46);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // comboBoxAddFailureStage
            // 
            this.comboBoxAddFailureStage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxAddFailureStage.FormattingEnabled = true;
            this.comboBoxAddFailureStage.Location = new System.Drawing.Point(0, 25);
            this.comboBoxAddFailureStage.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxAddFailureStage.Name = "comboBoxAddFailureStage";
            this.comboBoxAddFailureStage.Size = new System.Drawing.Size(118, 21);
            this.comboBoxAddFailureStage.TabIndex = 0;
            this.comboBoxAddFailureStage.SelectedIndexChanged += new System.EventHandler(this.comboBoxAddFailureStage_SelectedIndexChanged);
            // 
            // comboBoxAddSuccessStage
            // 
            this.comboBoxAddSuccessStage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxAddSuccessStage.FormattingEnabled = true;
            this.comboBoxAddSuccessStage.Location = new System.Drawing.Point(118, 25);
            this.comboBoxAddSuccessStage.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxAddSuccessStage.Name = "comboBoxAddSuccessStage";
            this.comboBoxAddSuccessStage.Size = new System.Drawing.Size(118, 21);
            this.comboBoxAddSuccessStage.TabIndex = 1;
            this.comboBoxAddSuccessStage.SelectedIndexChanged += new System.EventHandler(this.comboBoxAddSuccessStage_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightCoral;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(0, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Add Failure Stage";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.OliveDrab;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(118, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Add Success Stage";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxFailureText
            // 
            this.textBoxFailureText.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxFailureText.Location = new System.Drawing.Point(1, 211);
            this.textBoxFailureText.Name = "textBoxFailureText";
            this.textBoxFailureText.Size = new System.Drawing.Size(236, 20);
            this.textBoxFailureText.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(1, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Failure Text";
            // 
            // textBoxSuccessText
            // 
            this.textBoxSuccessText.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSuccessText.Location = new System.Drawing.Point(1, 178);
            this.textBoxSuccessText.Name = "textBoxSuccessText";
            this.textBoxSuccessText.Size = new System.Drawing.Size(236, 20);
            this.textBoxSuccessText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(1, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Success Text";
            // 
            // buttonNextStageRoll
            // 
            this.buttonNextStageRoll.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNextStageRoll.Location = new System.Drawing.Point(1, 142);
            this.buttonNextStageRoll.Name = "buttonNextStageRoll";
            this.buttonNextStageRoll.Size = new System.Drawing.Size(236, 23);
            this.buttonNextStageRoll.TabIndex = 4;
            this.buttonNextStageRoll.Text = "Next Stage Roll";
            this.buttonNextStageRoll.UseVisualStyleBackColor = true;
            // 
            // listBoxTests
            // 
            this.listBoxTests.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxTests.FormattingEnabled = true;
            this.listBoxTests.Location = new System.Drawing.Point(1, 47);
            this.listBoxTests.Name = "listBoxTests";
            this.listBoxTests.Size = new System.Drawing.Size(236, 95);
            this.listBoxTests.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(1, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tests";
            // 
            // textBoxStartingText
            // 
            this.textBoxStartingText.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxStartingText.Location = new System.Drawing.Point(1, 14);
            this.textBoxStartingText.Name = "textBoxStartingText";
            this.textBoxStartingText.Size = new System.Drawing.Size(236, 20);
            this.textBoxStartingText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting Text";
            // 
            // BinaryQuestStageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel1);
            this.Name = "BinaryQuestStageControl";
            this.Size = new System.Drawing.Size(240, 280);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxStartingText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxTests;
        private System.Windows.Forms.Button buttonNextStageRoll;
        private System.Windows.Forms.TextBox textBoxSuccessText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFailureText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxAddFailureStage;
        private System.Windows.Forms.ComboBox comboBoxAddSuccessStage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
