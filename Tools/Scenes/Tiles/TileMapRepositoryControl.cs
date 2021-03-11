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
    public partial class TileMapRepositoryControl : UserControl
    {
        private TileMapRepository _tileMapRepository;

        public TileMapRepository TileMapRepository
        {
            get => _tileMapRepository;
            set
            {
                _tileMapRepository = value;

                listBoxMaps.DataSource = _tileMapRepository.Maps;
            }
        }

        public TileSetRepository TileSetRepository
        {
            get => tileMapEditorControl.TileSetRepository;
            set => tileMapEditorControl.TileSetRepository = value;
        }

        public TileMapRepositoryControl()
        {
            InitializeComponent();
        }

        private void listBoxMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMaps.SelectedItem is TileMap map)
            {
                tileMapEditorControl.Map = map;
            }
        }

        private void buttonCreateMap_Click(object sender, EventArgs e)
        {
            TileMap map = new TileMap(10, 10)
            {
                Id = Guid.NewGuid(),
                Name = "New Map"
            };

            _tileMapRepository.AddMap(map);
        }
    }
}
