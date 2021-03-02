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
                DoDragDrop(animation, DragDropEffects.Move);
            }
        }
    }
}
