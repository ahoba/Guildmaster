
namespace Tools.Scenes
{
    partial class TileControl
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
            this.pictureBoxTile = new System.Windows.Forms.PictureBox();
            this.comboBoxTileTypes = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxRight = new System.Windows.Forms.CheckBox();
            this.checkBoxLeft = new System.Windows.Forms.CheckBox();
            this.checkBoxDown = new System.Windows.Forms.CheckBox();
            this.checkBoxUp = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTileTypes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxTile
            // 
            this.pictureBoxTile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxTile.Location = new System.Drawing.Point(0, 50);
            this.pictureBoxTile.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTile.Name = "pictureBoxTile";
            this.pictureBoxTile.Size = new System.Drawing.Size(16, 50);
            this.pictureBoxTile.TabIndex = 0;
            this.pictureBoxTile.TabStop = false;
            // 
            // comboBoxTileTypes
            // 
            this.comboBoxTileTypes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxTileTypes.FormattingEnabled = true;
            this.comboBoxTileTypes.Location = new System.Drawing.Point(19, 64);
            this.comboBoxTileTypes.Name = "comboBoxTileTypes";
            this.comboBoxTileTypes.Size = new System.Drawing.Size(114, 21);
            this.comboBoxTileTypes.TabIndex = 1;
            this.comboBoxTileTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxTileTypes_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.checkBoxRight, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxLeft, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxDown, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxUp, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(139, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(118, 150);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // checkBoxRight
            // 
            this.checkBoxRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxRight.AutoSize = true;
            this.checkBoxRight.Location = new System.Drawing.Point(3, 122);
            this.checkBoxRight.Name = "checkBoxRight";
            this.checkBoxRight.Size = new System.Drawing.Size(51, 17);
            this.checkBoxRight.TabIndex = 7;
            this.checkBoxRight.Text = "Right";
            this.checkBoxRight.UseVisualStyleBackColor = true;
            this.checkBoxRight.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxLeft
            // 
            this.checkBoxLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxLeft.AutoSize = true;
            this.checkBoxLeft.Location = new System.Drawing.Point(3, 84);
            this.checkBoxLeft.Name = "checkBoxLeft";
            this.checkBoxLeft.Size = new System.Drawing.Size(44, 17);
            this.checkBoxLeft.TabIndex = 6;
            this.checkBoxLeft.Text = "Left";
            this.checkBoxLeft.UseVisualStyleBackColor = true;
            this.checkBoxLeft.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxDown
            // 
            this.checkBoxDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxDown.AutoSize = true;
            this.checkBoxDown.Location = new System.Drawing.Point(3, 47);
            this.checkBoxDown.Name = "checkBoxDown";
            this.checkBoxDown.Size = new System.Drawing.Size(54, 17);
            this.checkBoxDown.TabIndex = 5;
            this.checkBoxDown.Text = "Down";
            this.checkBoxDown.UseVisualStyleBackColor = true;
            this.checkBoxDown.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxUp
            // 
            this.checkBoxUp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxUp.AutoSize = true;
            this.checkBoxUp.Location = new System.Drawing.Point(3, 10);
            this.checkBoxUp.Name = "checkBoxUp";
            this.checkBoxUp.Size = new System.Drawing.Size(40, 17);
            this.checkBoxUp.TabIndex = 4;
            this.checkBoxUp.Text = "Up";
            this.checkBoxUp.UseVisualStyleBackColor = true;
            this.checkBoxUp.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // TileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TileControl";
            this.Size = new System.Drawing.Size(257, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxTile;
        private System.Windows.Forms.ComboBox comboBoxTileTypes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxRight;
        private System.Windows.Forms.CheckBox checkBoxLeft;
        private System.Windows.Forms.CheckBox checkBoxDown;
        private System.Windows.Forms.CheckBox checkBoxUp;
    }
}
