using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Scenes.Tiles;

namespace Tools.Factories
{
    public class TileMapEditorControlFactory : IControlFactory
    {
        private TileSetRepository _tileSetRepository;

        public TileMapEditorControlFactory(TileSetRepository tileSetRepository)
        {
            _tileSetRepository = tileSetRepository;
        }

        public Control CreateControl()
        {
            return new TileMapEditorControl()
            {
                TileSetRepository = _tileSetRepository,
                TileDimension = 16,
            };
        }
    }
}
