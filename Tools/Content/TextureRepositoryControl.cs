using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Content
{
    public partial class TextureRepositoryControl : UserControl
    {
        private TextureRepository _textureRepository;

        public TextureRepository TextureRepository
        {
            get => _textureRepository;
            set
            {
                _textureRepository = value;

                listBoxTextures.DataSource = _textureRepository.TextureIds;
            }
        }

        public TextureRepositoryControl()
        {
            InitializeComponent();
        }

        private void toolStripButtonOpenTexture_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    Image image = Image.FromStream(fileStream);

                    _textureRepository.AddTexture(openFileDialog.SafeFileName, image);
                }
            }
        }

        private void listBoxTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTextures.SelectedItem is string textureId && _textureRepository.TryGetTexture(textureId, out Image texture))
            {
                pictureBoxTexture.SuspendLayout();

                pictureBoxTexture.Image = texture;
                pictureBoxTexture.Width = texture.Width;
                pictureBoxTexture.Height = texture.Height;

                pictureBoxTexture.ResumeLayout();
            }
        }

        private void toolStripButtonRemoveTexture_Click(object sender, EventArgs e)
        {
            if (listBoxTextures.SelectedItem is string textureId)
            {
                _textureRepository.RemoveTexture(textureId);
            }
        }
    }
}
