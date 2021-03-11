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

        public TileSetRepositoryControl()
        {
            InitializeComponent();
        }

        private void buttonCreateTileSet_Click(object sender, EventArgs e)
        {
            TileSet tileSet = new TileSet(string.Empty, null, 0, 0)
            {
                Id = Guid.NewGuid(),
                Name = "New TileSet"
            };

            _tileSetRepository.AddTileSet(tileSet);

            listBoxTileSets.SelectedItem = tileSet;
        }

        private void buttonSaveTileSet_Click(object sender, EventArgs e)
        {
            if (listBoxTileSets.SelectedItem is TileSet tileSet)
            {
                tileSet.Texture = tileTextureSelector.TileTextureControl.Texture;
                tileSet.TextureId = tileTextureSelector.TileTextureControl.TextureId;
                tileSet.Name = textBoxTileSetName.Text;
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
