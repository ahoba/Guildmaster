
namespace Tools.Actors
{
    partial class ActorControl
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.animationControl = new Tools.Animations.AnimationControl();
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemClearAnimation = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxActorName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.animationControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxActions, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxActorName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(248, 306);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // animationControl
            // 
            this.animationControl.AllowDrop = true;
            this.tableLayoutPanel1.SetColumnSpan(this.animationControl, 2);
            this.animationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animationControl.Location = new System.Drawing.Point(3, 3);
            this.animationControl.Name = "animationControl";
            this.animationControl.SelectedFrame = null;
            this.animationControl.Size = new System.Drawing.Size(242, 147);
            this.animationControl.TabIndex = 0;
            this.animationControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.animationControl_DragDrop);
            this.animationControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.animationControl_DragEnter);
            // 
            // listBoxActions
            // 
            this.listBoxActions.ContextMenuStrip = this.contextMenuStrip;
            this.listBoxActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.Location = new System.Drawing.Point(3, 156);
            this.listBoxActions.Name = "listBoxActions";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxActions, 2);
            this.listBoxActions.Size = new System.Drawing.Size(118, 147);
            this.listBoxActions.TabIndex = 1;
            this.listBoxActions.SelectedIndexChanged += new System.EventHandler(this.listBoxActions_SelectedIndexChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClearAnimation});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 26);
            // 
            // toolStripMenuItemClearAnimation
            // 
            this.toolStripMenuItemClearAnimation.Name = "toolStripMenuItemClearAnimation";
            this.toolStripMenuItemClearAnimation.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemClearAnimation.Text = "Clear Animation";
            this.toolStripMenuItemClearAnimation.Click += new System.EventHandler(this.toolStripMenuItemClearAnimation_Click);
            // 
            // textBoxActorName
            // 
            this.textBoxActorName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxActorName.Location = new System.Drawing.Point(127, 156);
            this.textBoxActorName.Name = "textBoxActorName";
            this.textBoxActorName.Size = new System.Drawing.Size(118, 20);
            this.textBoxActorName.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(127, 278);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(118, 25);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ActorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ActorControl";
            this.Size = new System.Drawing.Size(248, 306);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Animations.AnimationControl animationControl;
        private System.Windows.Forms.ListBox listBoxActions;
        private System.Windows.Forms.TextBox textBoxActorName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearAnimation;
        private System.Windows.Forms.Button buttonSave;
    }
}
