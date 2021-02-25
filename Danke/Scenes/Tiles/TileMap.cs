using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Danke.Scenes.Tiles
{
    public class TileMapLayer
    {
        public int[][] Tiles { get; set; }
    }

    public class TileMap<T>
    {
        public Guid Id { get; set; }

        public int TileDimension { get => TileSet.TileDimension; }

        public TileSet<T> TileSet { get; set; }

        public int Height { get => Layers[0].Tiles.Length; }

        public int Width { get => Layers[0].Tiles[0].Length; }

        public TileMapLayer[] Layers { get; protected set; } = new TileMapLayer[2];

        public TileMap(int height, int width)
        {
            Layers[0] = new TileMapLayer()
            {
                Tiles = new int[height][]
            };

            Layers[1] = new TileMapLayer()
            {
                Tiles = new int[height][]
            };

            for (int i = 0; i < height; i++)
            {
                Layers[0].Tiles[i] = new int[width];
                Layers[1].Tiles[i] = new int[width];

                for (int j = 0; j < width; j++)
                {
                    Layers[0].Tiles[i][j] = -1;
                    Layers[1].Tiles[i][j] = -1;
                }
            }
        }

        public TileMap(int[][] backgroundLayer)
        {
            Layers[0] = new TileMapLayer()
            {
                Tiles = backgroundLayer
            };

            int[][] foregroundLayer = new int[Height][];

            for (int i = 0; i < backgroundLayer.Length; i++)
            {
                foregroundLayer[i] = new int[Width];

                for (int j = 0; j < Width; j++)
                {
                    foregroundLayer[i][j] = -1;
                }
            }

            Layers[1] = new TileMapLayer()
            {
                Tiles = foregroundLayer
            };
        }

        public TileMap(int[][] backgroundLayer, int[][] foregroundLayer)
        {
            Layers[0] = new TileMapLayer()
            {
                Tiles = backgroundLayer
            };

            Layers[1] = new TileMapLayer()
            {
                Tiles = foregroundLayer
            };
        }

        public Tile TileAt(int row, int column, TileMapLayers layer)
        {
            if (row >= Layers[(int)layer].Tiles.Length || column >= Layers[(int)layer].Tiles[row].Length)
            {
                return null;
            }

            int tileIndex = Layers[(int)layer].Tiles[row][column];

            if (tileIndex < 0 || tileIndex >= TileSet.Columns * TileSet.Columns)
            {
                return null;
            }

            return TileSet[tileIndex];
        }

        public int[][] GetLayerTiles(TileMapLayers layer)
        {
            return Layers[(int)layer].Tiles;
        }
    }

    public enum TileMapLayers
    {
        Background = 0,
        Foreground = 1
    }

}
