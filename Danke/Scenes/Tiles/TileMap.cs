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

        public int Height { get => TileLayers[0].Tiles.Length; }

        public int Width { get => TileLayers[0].Tiles[0].Length; }

        public virtual TileMapLayer[] TileLayers { get; protected set; } = new TileMapLayer[Enum.GetNames(typeof(TileMapLayers)).Length];

        public List<TileObjectInstance<T>> Objects { get; } = new List<TileObjectInstance<T>>();

        public TileMapLayer ObjectsLayer { get; protected set; }

        public TileMap(int height, int width)
        {
            for (int i = 0; i < TileLayers.Length; i++)
            {
                TileLayers[i] = new TileMapLayer()
                {
                    Tiles = new int[height][]
                };
                
                for (int j = 0; j < height; j++)
                {
                    TileLayers[i].Tiles[j] = new int[width];
                    
                    for (int k = 0; k < width; k++)
                    {
                        TileLayers[i].Tiles[j][k] = -1;
                    }
                }
            }

            ObjectsLayer = new TileMapLayer()
            {
                Tiles = new int[height][]
            };

            for (int i = 0; i < height; i++)
            {
                ObjectsLayer.Tiles[i] = new int[width];

                for (int j = 0; j < width; j++)
                {
                    ObjectsLayer.Tiles[i][j] = -1;
                }
            }
        }

        public Tile TileAt(int row, int column, TileMapLayers layer)
        {
            if (row >= TileLayers[(int)layer].Tiles.Length || column >= TileLayers[(int)layer].Tiles[row].Length)
            {
                return null;
            }

            int tileIndex = TileLayers[(int)layer].Tiles[row][column];

            if (tileIndex < 0 || tileIndex >= TileSet.Columns * TileSet.Columns)
            {
                return null;
            }

            return TileSet[tileIndex];
        }

        public int[][] GetLayerTiles(TileMapLayers layer)
        {
            return TileLayers[(int)layer].Tiles;
        }

        public TileObjectInstance<T> ObjectAt(int row, int column)
        {
            if (row >= Height || column >= Width)
            {
                return null;
            }

            int objIndex = ObjectsLayer.Tiles[row][column];

            if (objIndex < 0 || objIndex >= Objects.Count)
            {
                return null;
            }

            return Objects[objIndex];
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
                    if (ObjectsLayer.Tiles[tileObjectInstance.Y + y][tileObjectInstance.X + x] >= 0)
                    {
                        error = AddObjectError.BlockingObject;

                        return false;
                    }
                }
            }

            int index = Objects.Count;

            for (int y = 0; y < tileObjectInstance.TileHeight; y++)
            {
                for (int x = 0; x < tileObjectInstance.TileWidth; x++)
                {
                    ObjectsLayer.Tiles[tileObjectInstance.Y + y][tileObjectInstance.X + x] = index;
                }
            }

            Objects.Add(tileObjectInstance);

            return true;
        }

        public void RemoveObject(int row, int column)
        {
            if (row >= Height || column >= Width)
            {
                return;
            }

            int index = ObjectsLayer.Tiles[row][column];

            if (index < 0 || index >= Objects.Count)
            {
                // To do: Error!

                return;
            }

            TileObjectInstance<T> obj = Objects[index];

            if (obj != null)
            {
                for (int y = 0; y < obj.TileHeight; y++)
                {
                    for (int x = 0; x < obj.TileWidth; x++)
                    {
                        ObjectsLayer.Tiles[obj.Y + y][obj.X + x] = -1;
                    }
                }

                Objects[index] = null;
            }
        }
    }

    public enum TileMapLayers
    {
        Background = 0,
        Foreground = 1
    }
}
