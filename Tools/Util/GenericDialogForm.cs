using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Util
{
    public partial class GenericDialogForm : Form
    {
        public Control Control 
        { 
            get => panelControl.Controls.Count > 0 ? panelControl.Controls[0] : null; 
            set
            {
                if (panelControl.Controls.Count > 0)
                {
                    panelControl.Controls.Clear();
                }

                panelControl.Controls.Add(value);
            }
        }

        public GenericDialogForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
