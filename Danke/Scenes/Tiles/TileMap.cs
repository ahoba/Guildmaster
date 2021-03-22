using Danke.Objects.Tiles;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Danke.Scenes.Tiles
{
    [Serializable]
    public class TileMapLayer
    {
        public int[][] Tiles { get; set; }
    }

    [Serializable]
    public class TileMap<T>
    {
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        public TileSet<T> TileSet { get; set; }

        public int Height { get => Layers[0].Tiles.Length; }

        public int Width { get => Layers[0].Tiles[0].Length; }

        public virtual TileMapLayer[] Layers { get; protected set; } = new TileMapLayer[Enum.GetNames(typeof(TileMapLayers)).Length];

        public List<TileObjectInstance<T>> Objects { get; } = new List<TileObjectInstance<T>>();

        public TileMap(int height, int width)
        {
            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i] = new TileMapLayer()
                {
                    Tiles = new int[height][]
                };
                
                for (int j = 0; j < height; j++)
                {
                    Layers[i].Tiles[j] = new int[width];
                    
                    for (int k = 0; k < width; k++)
                    {
                        Layers[i].Tiles[j][k] = -1;
                    }
                }
            }
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

        public enum AddObjectError
        {
            None,
            BlockingBackground,
            BlockingForeground,
            BlockingObject,
            MapWidthError,
            MapHeightError
        }

        public bool TryAddObjectInstance(TileObjectInstance<T> tileObjectInstance, out AddObjectError error)
        {
            error = AddObjectError.None;

            if (tileObjectInstance.Y + tileObjectInstance.TileHeight > Height)
            {
                error = AddObjectError.MapHeightError;

                return false;
            }

            if (tileObjectInstance.X + tileObjectInstance.TileWidth > Width)
            {
                error = AddObjectError.MapWidthError;

                return false;
            }

            for (int y = 0; y < tileObjectInstance.TileHeight; y++)
            {
                for (int x = 0; x < tileObjectInstance.TileWidth; x++)
                {
                    Tile tile = TileAt(tileObjectInstance.Y + y, tileObjectInstance.X + x, TileMapLayers.Background);

                    if (tile != null && tile.Type != TileType.Floor)
                    {
                        error = AddObjectError.BlockingBackground;

                        return false;
                    }

                    tile = TileAt(tileObjectInstance.Y + y, tileObjectInstance.X + x, TileMapLayers.Foreground);

                    if (tile != null)
                    {
                        error = AddObjectError.BlockingForeground;

                        return false;
                    }

                    // To do: Check if there is an object already
                }
            }

            int index = Objects.Count;

            Objects.Add(tileObjectInstance);

            return true;
        }
    }

    public enum TileMapLayers
    {
        Background = 0,
        Foreground = 1
    }
}
