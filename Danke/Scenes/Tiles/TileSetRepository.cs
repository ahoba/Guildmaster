using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Scenes.Tiles
{
    public class TileSetRepository<T>
    {
        protected Dictionary<Guid, TileSet<T>> _tilesets;
    }
}
