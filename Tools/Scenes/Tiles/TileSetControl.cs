using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Scenes.Tiles
{
    public partial class TileSetControl : UserControl
    {
        private TileSetRepository _tileSetRepository;

        public TileSetRepository TileSetRepository
        {
            get => _tileSetRepository;
            set
            {
                _tileSetRepository = value;

                if (_tileSetRepository != null)
                {
                    comboBox.DataSource = _tileSetRepository.TileSets;
                }
            }
        }

        public string TextureId => tileTextureControl.TextureId;

        public Image Texture => tileTextureControl.Texture;

        public event EventHandler<SelectedTileSetChangedEventArgs> SelectedTileSetChanged;

        public int SelectedTileId => tileTextureControl.SelectedTileIds.ElementAt(0);

        public int[][] SelectionMatrix => tileTextureControl.SelectionMatrix;

        public TileSetControl()
        {
            InitializeComponent();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem is TileSet tileSet)
            {
                tileTextureControl.SetTexture(tileSet.TextureId, tileSet.Texture);

                SelectedTileSetChanged?.Invoke(this, new SelectedTileSetChangedEventArgs(tileSet));
            }
        }
    }

    public class SelectedTileSetChangedEventArgs : EventArgs
    {
        public TileSet TileSet { get; }

        public SelectedTileSetChangedEventArgs(TileSet tileSet)
        {
            TileSet = tileSet;
        }
    }
}
