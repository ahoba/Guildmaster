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
        public TextureRepository TextureRepository
        {
            get => tileTextureSelector.TextureRepository;
            set => tileTextureSelector.TextureRepository = value;
        }

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
    }
}
