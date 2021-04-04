using Danke.Characters;
using Danke.Quests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Quests.Rolls
{
    public partial class RollControl : UserControl
    {
        private Roll _roll;

        public Roll Roll
        {
            get => _roll;
            set
            {
                _roll = value;

                if (_roll != null)
                {
                    textBoxBeforeRoll.Text = _roll.TextBeforeRoll.Text;
                    textBoxOnRollSuccess.Text = _roll.TextOnSuccess.Text;
                    textBoxOnRollFailure.Text = _roll.TextOnFailure.Text;

                    comboBoxTestedStat.SelectedItem = _roll.TestedStat;
                    comboBoxRollType.SelectedItem = _roll.RollType;

                    numericUpDownThreshold.Value = _roll.Threshold;
                    numericUpDownBaseHpDamage.Value = _roll.BaseHpDamage;
                    numericUpDownBaseStaminaDamage.Value = _roll.BaseStaminaDamage;

                    listBoxConsumables.DataSource = (IList<Consumable>)_roll.Consumables;
                }
            }
        }

        public RollControl()
        {
            InitializeComponent();

            comboBoxRollType.DataSource = Enum.GetValues(typeof(RollType));
            comboBoxTestedStat.DataSource = Enum.GetValues(typeof(Stats));
        }

        private void textBoxBeforeRoll_TextChanged(object sender, EventArgs e)
        {
            if (_roll != null)
            {
                _roll.TextBeforeRoll.Text = textBoxBeforeRoll.Text;
            }
        }

        private void textBoxOnRollSuccess_TextChanged(object sender, EventArgs e)
        {
            if (_roll != null)
            {
                _roll.TextOnSuccess.Text = textBoxOnRollSuccess.Text;
            }
        }

        private void textBoxOnRollFailure_TextChanged(object sender, EventArgs e)
        {
            if (_roll != null)
            {
                _roll.TextOnFailure.Text = textBoxOnRollFailure.Text;
            }
        }

        private void comboBoxTestedStat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_roll != null && comboBoxTestedStat.SelectedItem is Stats stat)
            {
                _roll.TestedStat = stat;
            }
        }

        private void comboBoxRollType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_roll != null && comboBoxRollType.SelectedItem is RollType rollType)
            {
                _roll.RollType = rollType;
            }
        }

        private void numericUpDownThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (_roll != null)
            {
                _roll.Threshold = (int)numericUpDownThreshold.Value;
            }
        }

        private void numericUpDownBaseHpDamage_ValueChanged(object sender, EventArgs e)
        {
            if (_roll != null)
            {
                _roll.BaseHpDamage = (int)numericUpDownBaseHpDamage.Value;
            }
        }

        private void numericUpDownBaseStaminaDamage_ValueChanged(object sender, EventArgs e)
        {
            if (_roll != null)
            {
                _roll.BaseStaminaDamage = (int)numericUpDownBaseStaminaDamage.Value;
            }
        }
    }
}
