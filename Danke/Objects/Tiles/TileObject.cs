﻿using Danke.Animations;
using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects.Tiles
{
    public class TileObject<T> : GameObject
    {
        public Animation<T>[] Animations { get; set; }

        public int TileWidth { get; set; }

        public int TileHeight { get; set; }

        public TileType[][] TileData { get; set; }
    }
}