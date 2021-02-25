using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Scenes.Tiles;

namespace Tools.Factories
{
    public class TileMapEditorControlFactory : AbstractControlFactory<MapEditorFactoryArgs>
    {
        private TileSetRepository _tileSetRepository;

        public TileMapEditorControlFactory(TileSetRepository tileSetRepository)
        {
            _tileSetRepository = tileSetRepository;
        }

        public override Control CreateControl(MapEditorFactoryArgs args)
        {
            return new TileMapEditorControl()
            {
                TileSetRepository = _tileSetRepository,
                TileDimension = args.TileDimension
            };
        }
    }

    public class MapEditorFactoryArgs : ControlFactoryArgs
    {
        public int TileDimension { get; set; } = 16;
    }
}
