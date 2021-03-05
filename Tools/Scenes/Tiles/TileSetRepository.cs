using Danke.Scenes.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Scenes.Tiles
{
    [Serializable]
    public class TileSetRepository : TileSetRepository<Image>
    {
        public BindingList<TileSet> TileSets { get; } = new BindingList<TileSet>();

        public void AddTileSet(TileSet tileSet)
        {
            _tileSets[tileSet.Id] = tileSet;

            TileSets.Add(tileSet);
        }
    }
}
