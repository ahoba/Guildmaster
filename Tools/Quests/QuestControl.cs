using System;
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
        private Pen _greenPen = new Pen(Color.Green, 3);
        
        private Pen _redPen = new Pen(Color.Red, 3);

        private Pen _blackPen = new Pen(Color.Black, 3);

        private Control _initialStageControl = null;

        public QuestControl()
        {
            InitializeComponent();

            comboBoxInitialStageType.DataSource = Enum.GetValues(typeof(QuestStageType));

            panelStages.Paint += PanelStages_Paint;
        }

        #region PaintLogic

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
                            _greenPen,
                            new Point(binaryStageControl.Right, binaryStageControl.Bottom),
                            new Point(binaryStageControl.SuccessStageControl.Left, binaryStageControl.SuccessStageControl.Top));
                    }

                    if (binaryStageControl.FailureStageControl != null)
                    {
                        e.Graphics.DrawLine(
                            _redPen,
                            new Point(binaryStageControl.Left, binaryStageControl.Bottom),
                            new Point(binaryStageControl.FailureStageControl.Right, binaryStageControl.FailureStageControl.Top));
                    }
                }
                else if (control is LinearQuestStageControl linearStageControl)
                {
                    if (linearStageControl.NextStageControl != null)
                    {
                        e.Graphics.DrawLine(
                            _blackPen,
                            new Point(linearStageControl.Left + linearStageControl.Width / 2, linearStageControl.Bottom),
                            new Point(linearStageControl.NextStageControl.Left + linearStageControl.Width / 2, linearStageControl.NextStageControl.Top));
                    }
                }
            }
        }

        private void AdjustLocations(Control newControl)
        {
            foreach (Control control in panelStages.Controls)
            {
                if (newControl != control && newControl.Tag is Control parent0 && control.Tag is Control parent1)
                {
                    if (RectangleFromControl(newControl).IntersectsWith(RectangleFromControl(control)))
                    {
                        if (parent0.Right > parent1.Right)
                        {
                            newControl.Location = new Point(control.Right + 10, newControl.Location.Y);

                            AdjustLocations(newControl);
                        }
                        else if (parent0 == parent1 && parent0 is BinaryQuestStageControl binaryStageControl)
                        {
                            if (newControl == binaryStageControl.FailureStageControl)
                            {
                                control.Location = new Point(newControl.Right + 10, newControl.Location.Y);

                                AdjustLocations(control);
                            }
                            else
                            {
                                newControl.Location = new Point(control.Right + 10, newControl.Location.Y);

                                AdjustLocations(newControl);
                            }
                        }
                        else
                        {
                            control.Location = new Point(newControl.Right + 10, newControl.Location.Y);

                            AdjustLocations(control);
                        }

                        break;
                    }
                    else if (parent0.Top == parent1.Top && parent0.Right > parent1.Right && newControl.Right < control.Right)
                    {
                        newControl.Location = new Point(control.Right + 10, newControl.Location.Y);

                        AdjustLocations(newControl);

                        break;
                    }
                    else if (parent0.Top == parent1.Top && parent0.Right < parent1.Right && newControl.Right > control.Right)
                    {
                        control.Location = new Point(newControl.Right + 10, newControl.Location.Y);

                        AdjustLocations(control);

                        break;
                    }
                }
            }
        }

        private Rectangle RectangleFromControl(Control control)
        {
            return new Rectangle(control.Left, control.Top, control.Right - control.Left, control.Bottom - control.Top);
        }

        #endregion

        #region BinaryQuestStageControl

        private BinaryQuestStageControl CreateBinaryStageControl()
        {
            BinaryQuestStageControl control = new BinaryQuestStageControl();

            control.FailureControlRequest += Control_FailureControlRequest;
            control.SuccessControlRequest += Control_SuccessControlRequest;

            return control;
        }

        private void Control_SuccessControlRequest(object sender, NextStageControlRequest e)
        {
            if (sender is BinaryQuestStageControl binaryStageControl)
            {
                if (binaryStageControl.SuccessStageControl != null)
                {
                    Clean(binaryStageControl.SuccessStageControl);
                }

                Control control = GetControl(e.StageType);

                if (control == null)
                {
                    binaryStageControl.SuccessStageControl = null;
                }
                else
                {
                    control.Tag = binaryStageControl;

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

                if (control == null)
                {
                    binaryStageControl.FailureStageControl = null;
                }
                else
                {
                    control.Tag = binaryStageControl;

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

        #endregion

        #region LinearQuestStageControl

        private LinearQuestStageControl CreateLinearStageControl()
        {
            LinearQuestStageControl control = new LinearQuestStageControl();

            control.NextControlRequest += Control_NextControlRequest;

            return control;
        }

        private void Control_NextControlRequest(object sender, NextStageControlRequest e)
        {
            if (sender is LinearQuestStageControl linearStageControl)
            {
                if (linearStageControl.NextStageControl != null)
                {
                    Clean(linearStageControl.NextStageControl);
                }

                Control control = GetControl(e.StageType);

                if (control == null)
                {
                    linearStageControl.NextStageControl = null;
                }
                else
                {
                    control.Tag = linearStageControl;

                    control.Location = new Point()
                    {
                        X = linearStageControl.Left,
                        Y = linearStageControl.Bottom + 50
                    };

                    AdjustLocations(control);

                    linearStageControl.NextStageControl = control;

                    panelStages.Controls.Add(control);
                }
            }

            panelStages.Refresh();
        }

        #endregion

        #region TerminalQuestStageControl

        private TerminalQuestStageControl CreateTerminalStageControl()
        {
            TerminalQuestStageControl control = new TerminalQuestStageControl();
            
            return control;
        }

        #endregion

        private void comboBoxInitialStageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInitialStageType.SelectedItem is QuestStageType stageType)
            {
                if (_initialStageControl != null)
                {
                    Clean(_initialStageControl);
                }

                _initialStageControl = GetControl(stageType);
                
                if (_initialStageControl != null)
                {
                    _initialStageControl.Location = new Point(panelStages.Width / 2 - _initialStageControl.Width / 2, 3);

                    panelStages.Controls.Add(_initialStageControl);
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

                panelStages.Controls.Remove(control);

                if (binaryStageControl.SuccessStageControl != null)
                {
                    Clean(binaryStageControl.SuccessStageControl);
                }

                if (binaryStageControl.FailureStageControl != null)
                {
                    Clean(binaryStageControl.FailureStageControl);
                }
            }
            else if (control is LinearQuestStageControl linearStageControl)
            {
                panelStages.Controls.Remove(control);

                if (linearStageControl.NextStageControl != null)
                {
                    Clean(linearStageControl.NextStageControl);
                }
            }
            else if (control is TerminalQuestStageControl terminalStageControl)
            {
                panelStages.Controls.Remove(control);
            }
        }
    }
}
