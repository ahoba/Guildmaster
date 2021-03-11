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

        private TileMapRepository _tileMapRepository;

        public TileMapEditorControlFactory(
            TileSetRepository tileSetRepository,
            TileMapRepository tileMapRepository)
        {
            _tileSetRepository = tileSetRepository;

            _tileMapRepository = tileMapRepository;
        }

        public Control CreateControl()
        {
            return new TileMapRepositoryControl()
            {
                TileSetRepository = _tileSetRepository,
                TileMapRepository = _tileMapRepository
            };
        }
    }
}
