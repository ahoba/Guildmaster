using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Tools.Content;

namespace Tools.Animations
{
    public partial class AnimationRepositoryControl : UserControl
    {
        private AnimationRepository _animationRepository;

        private Timer _dragDropTimer = new Timer();
        public TextureRepository TextureRepository
        {
            get => animationEditControl.TextureRepository;
            set => animationEditControl.TextureRepository = value;
        }

        public AnimationRepository AnimationRepository
        {
            get => _animationRepository;
            set
            {
                _animationRepository = value;

                listBoxAnimations.DataSource = _animationRepository.Animations;
            }
        }

        public AnimationRepositoryControl()
        {
            InitializeComponent();

            _dragDropTimer.Interval = 100;
            _dragDropTimer.Tick += _dragDropTimer_Tick;
        }

        private void _dragDropTimer_Tick(object sender, EventArgs e)
        {
            if (listBoxAnimations.SelectedItem is Animation animation)
            {
                this.Invoke((MethodInvoker)delegate 
                {
                    _dragDropTimer.Stop();

                    DoDragDrop(animation, DragDropEffects.Move);
                });
            }
        }

        private void listBoxAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAnimations.SelectedItem is Animation animation)
            {
                animationEditControl.Animation = animation;
            }
        }

        private void buttonCreateAnimation_Click(object sender, EventArgs e)
        {
            Animation animation = new Animation()
            {
                Id = Guid.NewGuid(),
                Name = "New Animation",
                SourceTexture = null,
                SourceTextureId = null,
                Sprites = new Microsoft.Xna.Framework.Rectangle[] { }
            };

            AnimationRepository.AddAnimation(animation);

            listBoxAnimations.SelectedItem = animation;
        }

        private void listBoxAnimations_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxAnimations.SelectedItem is Animation animation)
            {
                _dragDropTimer.Start();
            }
        }

        private void listBoxAnimations_MouseMove(object sender, MouseEventArgs e)
        {
            _dragDropTimer.Stop();
        }
    }
}
