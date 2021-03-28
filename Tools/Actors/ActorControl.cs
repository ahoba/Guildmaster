using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Actions;
using Tools.Animations;

namespace Tools.Actors
{
    public partial class ActorControl : UserControl
    {
        private ActionRepository _actionRepository;

        public ActionRepository ActionRepository
        {
            get => _actionRepository;
            set
            {
                _actionRepository = value;

                listBoxActions.DataSource = _actionRepository?.Actions;
            }
        }

        private Actor _actor;

        public Actor Actor
        {
            get => _actor;
            set
            {
                _actor = value;

                textBoxActorName.Text = _actor?.Name;
            }
        }

        public ActorControl()
        {
            InitializeComponent();
        }

        private void listBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_actor != null)
            {
                if (listBoxActions.SelectedItem is string action)
                {
                    if (_actor.Animations.ContainsKey(action))
                    {
                        animationControl.SetAnimation((Animation)_actor.Animations[action]);
                    }
                    else
                    {
                        animationControl.SetAnimation(null);
                    }
                }
            }
        }

        private void animationControl_DragEnter(object sender, DragEventArgs e)
        {
            if (_actor != null)
            {
                if (e.Data.GetData(typeof(Animation)) is Animation)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void animationControl_DragDrop(object sender, DragEventArgs e)
        {
            if (_actor != null)
            {
                if (e.Data.GetData(typeof(Animation)) is Animation animation)
                {
                    if (listBoxActions.SelectedItem is string animationName)
                    {
                        _actor.Animations[animationName] = animation;
                    }
                }
            }
        }

        private void toolStripMenuItemClearAnimation_Click(object sender, EventArgs e)
        {
            if (_actor != null)
            {
                if (listBoxActions.SelectedItem is string animationName)
                {
                    _actor.Animations[animationName] = null;

                    animationControl.SetAnimation(null);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _actor.Name = textBoxActorName.Text;
        }
    }
}
