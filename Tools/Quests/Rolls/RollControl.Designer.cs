
namespace Tools.Quests.Rolls
{
    partial class RollControl
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
            this.listBoxConsumables = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownBaseStaminaDamage = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownBaseHpDamage = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownThreshold = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxRollType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTestedStat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOnRollFailure = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOnRollSuccess = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBeforeRoll = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseStaminaDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseHpDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxConsumables);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.numericUpDownBaseStaminaDamage);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.numericUpDownBaseHpDamage);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericUpDownThreshold);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxRollType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxTestedStat);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxOnRollFailure);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxOnRollSuccess);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxBeforeRoll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 385);
            this.panel1.TabIndex = 0;
            // 
            // listBoxConsumables
            // 
            this.listBoxConsumables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxConsumables.FormattingEnabled = true;
            this.listBoxConsumables.Location = new System.Drawing.Point(0, 279);
            this.listBoxConsumables.Name = "listBoxConsumables";
            this.listBoxConsumables.Size = new System.Drawing.Size(772, 106);
            this.listBoxConsumables.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Consumables";
            // 
            // numericUpDownBaseStaminaDamage
            // 
            this.numericUpDownBaseStaminaDamage.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownBaseStaminaDamage.Location = new System.Drawing.Point(0, 246);
            this.numericUpDownBaseStaminaDamage.Name = "numericUpDownBaseStaminaDamage";
            this.numericUpDownBaseStaminaDamage.Size = new System.Drawing.Size(772, 20);
            this.numericUpDownBaseStaminaDamage.TabIndex = 15;
            this.numericUpDownBaseStaminaDamage.ValueChanged += new System.EventHandler(this.numericUpDownBaseStaminaDamage_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Base Stamina Damage";
            // 
            // numericUpDownBaseHpDamage
            // 
            this.numericUpDownBaseHpDamage.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownBaseHpDamage.Location = new System.Drawing.Point(0, 213);
            this.numericUpDownBaseHpDamage.Name = "numericUpDownBaseHpDamage";
            this.numericUpDownBaseHpDamage.Size = new System.Drawing.Size(772, 20);
            this.numericUpDownBaseHpDamage.TabIndex = 13;
            this.numericUpDownBaseHpDamage.ValueChanged += new System.EventHandler(this.numericUpDownBaseHpDamage_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Base Hp Damage";
            // 
            // numericUpDownThreshold
            // 
            this.numericUpDownThreshold.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownThreshold.Location = new System.Drawing.Point(0, 180);
            this.numericUpDownThreshold.Name = "numericUpDownThreshold";
            this.numericUpDownThreshold.Size = new System.Drawing.Size(772, 20);
            this.numericUpDownThreshold.TabIndex = 11;
            this.numericUpDownThreshold.ValueChanged += new System.EventHandler(this.numericUpDownThreshold_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Threshold";
            // 
            // comboBoxRollType
            // 
            this.comboBoxRollType.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxRollType.FormattingEnabled = true;
            this.comboBoxRollType.Location = new System.Drawing.Point(0, 146);
            this.comboBoxRollType.Name = "comboBoxRollType";
            this.comboBoxRollType.Size = new System.Drawing.Size(772, 21);
            this.comboBoxRollType.TabIndex = 9;
            this.comboBoxRollType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRollType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Roll Type";
            // 
            // comboBoxTestedStat
            // 
            this.comboBoxTestedStat.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTestedStat.FormattingEnabled = true;
            this.comboBoxTestedStat.Location = new System.Drawing.Point(0, 112);
            this.comboBoxTestedStat.Name = "comboBoxTestedStat";
            this.comboBoxTestedStat.Size = new System.Drawing.Size(772, 21);
            this.comboBoxTestedStat.TabIndex = 7;
            this.comboBoxTestedStat.SelectedIndexChanged += new System.EventHandler(this.comboBoxTestedStat_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tested Stat";
            // 
            // textBoxOnRollFailure
            // 
            this.textBoxOnRollFailure.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxOnRollFailure.Location = new System.Drawing.Point(0, 79);
            this.textBoxOnRollFailure.Name = "textBoxOnRollFailure";
            this.textBoxOnRollFailure.Size = new System.Drawing.Size(772, 20);
            this.textBoxOnRollFailure.TabIndex = 5;
            this.textBoxOnRollFailure.TextChanged += new System.EventHandler(this.textBoxOnRollFailure_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Text on Roll Failure";
            // 
            // textBoxOnRollSuccess
            // 
            this.textBoxOnRollSuccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxOnRollSuccess.Location = new System.Drawing.Point(0, 46);
            this.textBoxOnRollSuccess.Name = "textBoxOnRollSuccess";
            this.textBoxOnRollSuccess.Size = new System.Drawing.Size(772, 20);
            this.textBoxOnRollSuccess.TabIndex = 3;
            this.textBoxOnRollSuccess.TextChanged += new System.EventHandler(this.textBoxOnRollSuccess_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text on Roll Success";
            // 
            // textBoxBeforeRoll
            // 
            this.textBoxBeforeRoll.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxBeforeRoll.Location = new System.Drawing.Point(0, 13);
            this.textBoxBeforeRoll.Name = "textBoxBeforeRoll";
            this.textBoxBeforeRoll.Size = new System.Drawing.Size(772, 20);
            this.textBoxBeforeRoll.TabIndex = 1;
            this.textBoxBeforeRoll.TextChanged += new System.EventHandler(this.textBoxBeforeRoll_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text Before Roll";
            // 
            // RollControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "RollControl";
            this.Size = new System.Drawing.Size(772, 385);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseStaminaDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseHpDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxBeforeRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxOnRollFailure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOnRollSuccess;
        private System.Windows.Forms.ComboBox comboBoxTestedStat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxRollType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownThreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownBaseHpDamage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownBaseStaminaDamage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBoxConsumables;
        private System.Windows.Forms.Label label9;
    }
}
