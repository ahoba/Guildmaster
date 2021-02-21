using Danke.Animations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                if (_animationRepository != null)
                {
                    foreach (Animation animation in _animationRepository.Animations)
                    {
                        (listBoxAnimations.DataSource as IList<Animation>).Add(animation);
                    }
                }
            }
        }

        public AnimationRepositoryControl()
        {
            InitializeComponent();

            listBoxAnimations.DataSource = new BindingList<Animation>();
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

            (listBoxAnimations.DataSource as IList<Animation>).Add(animation);
        }
    }
}
