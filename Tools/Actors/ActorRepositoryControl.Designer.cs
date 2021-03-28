
namespace Tools.Actors
{
    partial class ActorRepositoryControl
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
            this.listBoxActors = new System.Windows.Forms.ListBox();
            this.buttonAddActor = new System.Windows.Forms.Button();
            this.actorControl = new Tools.Actors.ActorControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxActors, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddActor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.actorControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listBoxActors
            // 
            this.listBoxActors.DisplayMember = "Name";
            this.listBoxActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxActors.FormattingEnabled = true;
            this.listBoxActors.Location = new System.Drawing.Point(3, 3);
            this.listBoxActors.Name = "listBoxActors";
            this.listBoxActors.Size = new System.Drawing.Size(123, 392);
            this.listBoxActors.TabIndex = 0;
            this.listBoxActors.ValueMember = "Name";
            this.listBoxActors.SelectedIndexChanged += new System.EventHandler(this.listBoxActors_SelectedIndexChanged);
            // 
            // buttonAddActor
            // 
            this.buttonAddActor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddActor.Location = new System.Drawing.Point(3, 401);
            this.buttonAddActor.Name = "buttonAddActor";
            this.buttonAddActor.Size = new System.Drawing.Size(123, 39);
            this.buttonAddActor.TabIndex = 1;
            this.buttonAddActor.Text = "Create Actor";
            this.buttonAddActor.UseVisualStyleBackColor = true;
            this.buttonAddActor.Click += new System.EventHandler(this.buttonAddActor_Click);
            // 
            // actorControl
            // 
            this.actorControl.ActionRepository = null;
            this.actorControl.Actor = null;
            this.actorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actorControl.Location = new System.Drawing.Point(132, 3);
            this.actorControl.Name = "actorControl";
            this.actorControl.Size = new System.Drawing.Size(254, 392);
            this.actorControl.TabIndex = 2;
            // 
            // ActorRepositoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ActorRepositoryControl";
            this.Size = new System.Drawing.Size(389, 443);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxActors;
        private System.Windows.Forms.Button buttonAddActor;
        private ActorControl actorControl;
    }
}
