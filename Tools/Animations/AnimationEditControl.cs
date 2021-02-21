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
    public partial class AnimationEditControl : UserControl
    {
        private Animation _animation;

        public Animation Animation
        {
            get => _animation;
            set
            {
                _animation = value;

                animationControl.SetAnimation(_animation);

                textBoxAnimationName.Text = _animation?.Name;

                buttonAddSprite.Enabled = _animation != null;
                buttonRemoveSprite.Enabled = _animation != null;
            }
        }

        public TextureRepository TextureRepository
        {
            get => tileTextureSelector.TextureRepository;
            set => tileTextureSelector.TextureRepository = value;
        }

        public event EventHandler<EventArgs> AnimationSaved;

        public AnimationEditControl()
        {
            InitializeComponent();

            tileTextureSelector.SelectedTextureChanged += TileTextureSelector_SelectedTextureChanged;
        }

        private void TileTextureSelector_SelectedTextureChanged(object sender, Content.SelectedTextureChangedEventArgs e)
        {
            animationControl.SetSourceTexture(e.TextureId, e.Texture);
        }

        private void buttonAddSprite_Click(object sender, EventArgs e)
        {
            animationControl.AddSprite(tileTextureSelector.TileTextureControl.Selection);
        }

        private void buttonRemoveSprite_Click(object sender, EventArgs e)
        {
            if (animationControl.SelectedFrame.HasValue)
            {
                animationControl.RemoveSprite(animationControl.SelectedFrame.Value);
            }
        }

        private void buttonSaveAnimation_Click(object sender, EventArgs e)
        {
            if (_animation != null)
            {
                _animation.Name = textBoxAnimationName.Text;
                _animation.SourceTexture = tileTextureSelector.TileTextureControl.Texture;
                _animation.SourceTextureId = tileTextureSelector.TileTextureControl.TextureId;
                _animation.Sprites = animationControl.Sprites.Select(x => Util.DrawingToXna.Rectangle(x)).ToArray();

                AnimationSaved?.Invoke(this, new EventArgs());
            }
        }
    }
}
