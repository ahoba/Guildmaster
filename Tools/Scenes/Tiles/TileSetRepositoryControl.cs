using Danke.Scenes.Tiles;
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

namespace Tools.Scenes.Tiles
{
    public partial class TileSetRepositoryControl : UserControl
    {
        private TileSetRepository _tileSetRepository;

        public TileSetRepository TileSetRepository
        {
            get => _tileSetRepository;
            set
            {
                _tileSetRepository = value;

                listBoxTileSets.DataSource = _tileSetRepository.TileSets;
            }
        }

        public TextureRepository TextureRepository
        {
            get => tileTextureSelector.TextureRepository;

            set => tileTextureSelector.TextureRepository = value;
        }

        private int _tileDimension = 16;

        public int TileDimension
        {
            get => _tileDimension;
            set
            {
                _tileDimension = value;

                tileTextureSelector.TileTextureControl.TileDimension = _tileDimension;
            }
        }

        public TileSetRepositoryControl()
        {
            InitializeComponent();
        }

        private void buttonCreateTileSet_Click(object sender, EventArgs e)
        {
            TileSet tileSet = new TileSet(_tileDimension, string.Empty, null, 0, 0)
            {
                Id = new Guid(),
                TileDimension = _tileDimension
            };

            _tileSetRepository.AddTileSet(tileSet);

            listBoxTileSets.SelectedItem = tileSet;
        }

        private void buttonSaveTileSet_Click(object sender, EventArgs e)
        {
            if (listBoxTileSets.SelectedItem is TileSet tileSet)
            {
                tileSet.Name = textBoxTileSetName.Text;

                tileSet.Texture = tileTextureSelector.TileTextureControl.Texture;
                tileSet.TextureId = tileTextureSelector.TileTextureControl.TextureId;
            }
        }

        private void listBoxTileSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTileSets.SelectedItem is TileSet tileSet)
            {
                textBoxTileSetName.Text = tileSet.Name;

                tileTextureSelector.TileTextureControl.SetTexture(tileSet.TextureId, tileSet.Texture);
            }
        }
    }
}
