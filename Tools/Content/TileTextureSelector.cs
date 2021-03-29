using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Util;

namespace Tools.Content
{
    public partial class TileTextureSelector : UserControl
    {
        private TextureRepository _textureRepository;

        public TileTextureControl TileTextureControl => tileTextureControl;

        public TextureRepository TextureRepository
        {
            get => _textureRepository;
            set
            {
                _textureRepository = value;

                if (_textureRepository != null)
                {
                    comboBoxTextureIds.DataSource = _textureRepository.TextureIds;
                }
            }
        }

        public event EventHandler<SelectedTextureChangedEventArgs> SelectedTextureChanged;

        public TileTextureSelector()
        {
            InitializeComponent();
        }

        public void SetTexture(string textureId, Image texture)
        {
            if (_textureRepository != null)
            {
                if (!string.IsNullOrEmpty(textureId) && _textureRepository.TextureIds.Contains(textureId))
                {
                    comboBoxTextureIds.SelectedItem = textureId;
                }
                else
                {
                    comboBoxTextureIds.SelectedItem = null;
                }

                tileTextureControl.SetTexture(textureId, texture);
            }
        }

        private void comboBoxTextureIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTextureIds.SelectedItem is string textureId &&
                _textureRepository.TryGetTexture(textureId, out Image texture))
            {
                tileTextureControl.SetTexture(textureId, texture);

                SelectedTextureChanged?.Invoke(this, new SelectedTextureChangedEventArgs(textureId, texture));
            }
        }
    }

    public class SelectedTextureChangedEventArgs : EventArgs
    {
        public string TextureId { get; }

        public Image Texture { get; }

        public SelectedTextureChangedEventArgs(string textureId, Image texture)
        {
            TextureId = textureId;

            Texture = texture;
        }
    }
}
