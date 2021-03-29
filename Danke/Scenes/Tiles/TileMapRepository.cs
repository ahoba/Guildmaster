using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Scenes.Tiles
{
    [Serializable]
    public class TileMapRepository<T>
    {
        public Dictionary<Guid, TileMap<T>> MapsById { get; protected set; }

        public TileMapRepository()
        {
            MapsById = new Dictionary<Guid, TileMap<T>>();
        }
    }
}
