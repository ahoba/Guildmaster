﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Quests
{
    public partial class QuestControl : UserControl
    {
        public QuestControl()
        {
            InitializeComponent();

            comboBoxInitialStageType.DataSource = Enum.GetValues(typeof(QuestStageType));

            panelStages.Paint += PanelStages_Paint;
        }

        private void PanelStages_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control control in panelStages.Controls)
            {
                if (!control.Visible)
                {
                    continue;
                }

                if (control is BinaryQuestStageControl binaryStageControl)
                {
                    if (binaryStageControl.SuccessStageControl != null)
                    {
                        e.Graphics.DrawLine(
                            Pens.Black,
                            new Point(binaryStageControl.Right, binaryStageControl.Bottom),
                            new Point(binaryStageControl.SuccessStageControl.Left, binaryStageControl.SuccessStageControl.Top));
                    }

                    if (binaryStageControl.FailureStageControl != null)
                    {
                        e.Graphics.DrawLine(
                            Pens.Black,
                            new Point(binaryStageControl.Left, binaryStageControl.Bottom),
                            new Point(binaryStageControl.FailureStageControl.Right, binaryStageControl.FailureStageControl.Top));
                    }
                }
                else if (control is LinearQuestStageControl linearStageControl)
                {
                    if (linearStageControl.NextStageControl != null)
                    {
                        e.Graphics.DrawLine(
                            Pens.Black,
                            new Point(linearStageControl.Left + linearStageControl.Width / 2, linearStageControl.Bottom),
                            new Point(linearStageControl.NextStageControl.Left + linearStageControl.Width / 2, linearStageControl.NextStageControl.Top));
                    }
                }
            }
        }

        private void Control_SuccessControlRequest(object sender, NextStageControlRequest e)
        {
            if (sender is BinaryQuestStageControl binaryStageControl)
            {
                if (binaryStageControl.SuccessStageControl != null)
                {
                    panelStages.Controls.Remove(binaryStageControl.SuccessStageControl);

                    Clean(binaryStageControl.SuccessStageControl);
                }

                Control control = GetControl(e.StageType);

                control.Tag = binaryStageControl;

                if (control == null)
                {
                    binaryStageControl.SuccessStageControl = null;
                }
                else
                {
                    control.Location = new Point()
                    {
                        X = binaryStageControl.Right + 50,
                        Y = binaryStageControl.Bottom + 50
                    };

                    AdjustLocations(control);

                    binaryStageControl.SuccessStageControl = control;

                    panelStages.Controls.Add(control);
                }
            }

            panelStages.Refresh();
        }

        private void Control_FailureControlRequest(object sender, NextStageControlRequest e)
        {
            if (sender is BinaryQuestStageControl binaryStageControl)
            {
                if (binaryStageControl.FailureStageControl != null)
                {
                    panelStages.Controls.Remove(binaryStageControl.FailureStageControl);

                    Clean(binaryStageControl.FailureStageControl);
                }

                Control control = GetControl(e.StageType);
                
                control.Tag = binaryStageControl;

                if (control == null)
                {
                    binaryStageControl.FailureStageControl = null;
                }
                else
                {
                    int x = binaryStageControl.Left - control.Width - 50;

                    if (x < 50)
                    {
                        foreach (Control c in panelStages.Controls)
                        {
                            c.Location = new Point(c.Location.X + 50 - x, c.Location.Y);
                        }
                    }

                    control.Location = new Point()
                    {
                        X = binaryStageControl.Left - control.Width - 50,
                        Y = binaryStageControl.Bottom + 50
                    };

                    AdjustLocations(control);

                    binaryStageControl.FailureStageControl = control;

                    panelStages.Controls.Add(control);
                }
            }

            panelStages.Refresh();
        }

        private void AdjustLocations(Control newControl)
        {
            foreach (Control control in panelStages.Controls)
            {
                if (newControl.Tag is Control parent0 && control.Tag is Control parent1)
                {
                    if (newControl != control && RectangleFromControl(newControl).IntersectsWith(RectangleFromControl(control)))
                    {
                        if (parent0.Right > parent1.Right)
                        {
                            newControl.Location = new Point(control.Right + 10, newControl.Location.Y);

                            AdjustLocations(newControl);
                        }
                        else
                        {
                            control.Location = new Point(newControl.Right + 10, newControl.Location.Y);

                            AdjustLocations(control);
                        }

                        break;
                    }
                }
            }
        }

        private Rectangle RectangleFromControl(Control control)
        {
            return new Rectangle(control.Left, control.Top, control.Right - control.Left, control.Bottom - control.Top);
        }

        private BinaryQuestStageControl CreateBinaryStageControl()
        {
            BinaryQuestStageControl control = new BinaryQuestStageControl();

            control.FailureControlRequest += Control_FailureControlRequest;
            control.SuccessControlRequest += Control_SuccessControlRequest;

            return control;
        }

        private LinearQuestStageControl CreateLinearStageControl()
        {
            LinearQuestStageControl control = new LinearQuestStageControl();

            return control;
        }

        private TerminalQuestStageControl CreateTerminalStageControl()
        {
            TerminalQuestStageControl control = new TerminalQuestStageControl();
            
            return control;
        }

        private void comboBoxInitialStageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInitialStageType.SelectedItem is QuestStageType stageType)
            {
                Control control = GetControl(stageType);
                
                if (control != null)
                {
                    control.Location = new Point(panelStages.Width / 2 - control.Width / 2, 3);

                    panelStages.Controls.Add(control);

                    comboBoxInitialStageType.Enabled = false;
                }
            }
        }

        private Control GetControl(QuestStageType stageType)
        {
            Control control = null;

            switch (stageType)
            {
                case QuestStageType.Binary:
                    control = CreateBinaryStageControl();
                    break;
                case QuestStageType.Linear:
                    control = CreateLinearStageControl();
                    break;
                case QuestStageType.Terminal:
                    control = CreateTerminalStageControl();
                    break;
            }

            return control;
        }

        private void Clean(Control control)
        {
            if (control is BinaryQuestStageControl binaryStageControl)
            {
                binaryStageControl.FailureControlRequest -= Control_FailureControlRequest;
                binaryStageControl.SuccessControlRequest -= Control_SuccessControlRequest;
            }
        }
    }
}