﻿using Newtonsoft.Json;
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
    public class TileMapRepository : Danke.Scenes.Tiles.TileMapRepository<Image>
    {
        [JsonIgnore]
        public BindingList<TileMap> Maps { get; }

        public TileMapRepository()
        {
            Maps = new BindingList<TileMap>();
        }

        public void AddMap(TileMap map)
        {
            base.MapsById[map.Id] = map;

            Maps.Add(map);
        }
    }
}
