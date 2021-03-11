using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Scenes.Tiles
{
    public class TileMapRepository : Danke.Scenes.Tiles.TileMapRepository<Image>
    {
        public BindingList<TileMap> Maps { get; }

        public TileMapRepository()
        {
            Maps = new BindingList<TileMap>();
        }

        public void AddMap(TileMap map)
        {
            _maps[map.Id] = map;

            Maps.Add(map);
        }
    }
}
