
namespace Tools.Objects
{
    partial class ObjectRepositoryControl
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
            this.listBoxObjects = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tileObjectControl = new Tools.Objects.TileObjectControl();
            this.buttonAddObject = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxObjects
            // 
            this.listBoxObjects.DisplayMember = "Name";
            this.listBoxObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxObjects.FormattingEnabled = true;
            this.listBoxObjects.Location = new System.Drawing.Point(3, 3);
            this.listBoxObjects.Name = "listBoxObjects";
            this.listBoxObjects.Size = new System.Drawing.Size(106, 260);
            this.listBoxObjects.TabIndex = 0;
            this.listBoxObjects.ValueMember = "Name";
            this.listBoxObjects.SelectedIndexChanged += new System.EventHandler(this.listBoxObjects_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxObjects, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tileObjectControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddObject, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(375, 296);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tileObjectControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tileObjectControl, 2);
            this.tileObjectControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileObjectControl.Location = new System.Drawing.Point(115, 3);
            this.tileObjectControl.Name = "tileObjectControl";
            this.tileObjectControl.Size = new System.Drawing.Size(257, 260);
            this.tileObjectControl.TabIndex = 1;
            this.tileObjectControl.TileData = null;
            this.tileObjectControl.TileHeight = 0;
            this.tileObjectControl.TileWidth = 0;
            // 
            // buttonAddObject
            // 
            this.buttonAddObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddObject.Location = new System.Drawing.Point(3, 269);
            this.buttonAddObject.Name = "buttonAddObject";
            this.buttonAddObject.Size = new System.Drawing.Size(106, 24);
            this.buttonAddObject.TabIndex = 2;
            this.buttonAddObject.Text = "Add Object";
            this.buttonAddObject.UseVisualStyleBackColor = true;
            this.buttonAddObject.Click += new System.EventHandler(this.buttonAddObject_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(246, 269);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(126, 24);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ObjectRepositoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ObjectRepositoryControl";
            this.Size = new System.Drawing.Size(375, 296);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxObjects;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TileObjectControl tileObjectControl;
        private System.Windows.Forms.Button buttonAddObject;
        private System.Windows.Forms.Button buttonSave;
    }
}
