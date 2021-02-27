using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Content;
using Tools.Scenes.Tiles;

namespace Tools.Factories
{
    public class TileSetRepositoryControlFactory : IControlFactory
    {
        private TileSetRepository _tileSetRepository;

        private TextureRepository _textureRepository;

        public TileSetRepositoryControlFactory(TileSetRepository tileSetRepository, TextureRepository textureRepository)
        {
            _tileSetRepository = tileSetRepository;

            _textureRepository = textureRepository;
        }

        public Control CreateControl()
        {
            return new TileSetRepositoryControl
            {
                TileSetRepository = _tileSetRepository,
                TextureRepository = _textureRepository,
                TileDimension = 16
            };
        }
    }
}
