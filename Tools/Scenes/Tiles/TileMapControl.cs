using Danke.Scenes.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Scenes.Tiles
{
    public partial class TileMapControl : UserControl
    {
        private TileSet _tileSet;

        public TileSet TileSet
        {
            get => _tileSet;
            set
            {
                _tileSet = value;
            }
        }

        public TileMapLayer[] Layers { get; private set; }

        private int _rowCount;

        public int RowCount
        {
            get => _rowCount;
            set
            {
                if (_rowCount == value)
                {
                    return;
                }

                _rowCount = value;

                for (int layer = 0; layer < Layers.Length; layer++)
                {
                    if (Layers[layer].Tiles == null)
                    {
                        Layers[layer].Tiles = new int[_rowCount][];

                        for (int i = 0; i < _rowCount; i++)
                        {
                            Layers[layer].Tiles[i] = new int[_columnCount];
                        }
                    }
                    else
                    {
                        int[][] newTiles = new int[_rowCount][];

                        for (int i = 0; i < Math.Max(_rowCount, Layers[layer].Tiles.Length); i++)
                        {
                            if (i >= _rowCount)
                            {
                                break;
                            }

                            newTiles[i] = i >= Layers[layer].Tiles.Length ?
                                CreateEmptyRow(_columnCount) : Layers[layer].Tiles[i];
                        }

                        Layers[layer].Tiles = newTiles;
                    }
                }

                AdjustSize();
            }
        }

        private int _columnCount;

        public int ColumnCount
        {
            get => _columnCount;
            set
            {
                if (_columnCount == value)
                {
                    return;
                }

                _columnCount = value;

                for (int layer = 0; layer < Layers.Length; layer++)
                {
                    if (Layers[layer].Tiles == null)
                    {
                        Layers[layer].Tiles = new int[_rowCount][];

                        for (int i = 0; i < _rowCount; i++)
                        {
                            Layers[layer].Tiles[i] = CreateEmptyRow(_columnCount);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _rowCount; i++)
                        {
                            if (Layers[layer].Tiles[i] == null)
                            {
                                Layers[layer].Tiles[i] = CreateEmptyRow(_columnCount);
                            }
                            else
                            {
                                int[] newRow = new int[_columnCount];

                                for (int j = 0; j < Math.Max(_rowCount, Layers[layer].Tiles[i].Length); j++)
                                {
                                    if (j >= _columnCount)
                                    {
                                        break;
                                    }

                                    newRow[j] = j >= Layers[layer].Tiles[i].Length ? -1 : Layers[layer].Tiles[i][j];
                                }

                                Layers[layer].Tiles[i] = newRow;
                            }
                        }
                    }
                }

                AdjustSize();
            }
        }

        private int[] CreateEmptyRow(int width)
        {
            int[] row = new int[width];

            for (int i = 0; i < width; i++)
            {
                row[i] = -1;
            }

            return row;
        }

        private bool _selection;

        public int? SelectedRow { get; set; }

        public int? SelectedColumn { get; set; }

        public event EventHandler<SelectedTileChangedEventArgs> SelectedTileChanged;

        public TileMapControl()
        {
            InitializeComponent();

            Layers = new TileMapLayer[2];

            Layers[0] = new TileMapLayer();
            Layers[1] = new TileMapLayer();
        }

        private void AdjustSize()
        {
            pictureBoxMap.SuspendLayout();

            pictureBoxMap.Height = _rowCount * TileScene.TileDimension;
            pictureBoxMap.Width = _columnCount * TileScene.TileDimension;

            if (pictureBoxMap.Height > 0 && pictureBoxMap.Width > 0)
            {
                Image image = new Bitmap(pictureBoxMap.Width, pictureBoxMap.Height);

                if (pictureBoxMap.Image != null)
                {
                    Graphics g = Graphics.FromImage(image);

                    g.DrawImage(pictureBoxMap.Image, new Point(0, 0));

                    for (int i = 0; i < _rowCount; i++)
                    {
                        for (int j = 0; j < _columnCount; j++)
                        {
                            g.DrawRectangle(Pens.Black, new Rectangle(j * TileScene.TileDimension, i * TileScene.TileDimension, TileScene.TileDimension, TileScene.TileDimension));
                        }
                    }
                }

                pictureBoxMap.Image = image;
            }

            pictureBoxMap.ResumeLayout();
        }

        public void SetTile(int layer, int row, int column, int tileId)
        {
            if (layer < Layers.Length &&
                row < RowCount &&
                column < ColumnCount &&
                TileSet != null)
            {
                row = Math.Max(row, 0);
                row = Math.Min(row, _rowCount - 1);

                column = Math.Max(column, 0);
                column = Math.Min(column, _columnCount - 1);

                if (pictureBoxMap.Image == null)
                {
                    pictureBoxMap.Image = new Bitmap(ColumnCount * TileScene.TileDimension, RowCount * TileScene.TileDimension);
                }

                Layers[layer].Tiles[row][column] = tileId;
                
                for (int i = 0; i < TileScene.TileDimension; i++)
                {
                    for (int j = 0; j < TileScene.TileDimension; j++)
                    {
                        (pictureBoxMap.Image as Bitmap).SetPixel(column * TileScene.TileDimension + j, row * TileScene.TileDimension + i, Color.Transparent);
                    }
                }
                
                Graphics g = Graphics.FromImage(pictureBoxMap.Image);

                for (int k = 0; k < Layers.Length; k++)
                {
                    tileId = Layers[k].Tiles[row][column];

                    Tile tile = TileSet[tileId];

                    Rectangle r = new Rectangle(column * TileScene.TileDimension, row * TileScene.TileDimension, TileScene.TileDimension, TileScene.TileDimension);
                    
                    if (tile != null)
                    {
                        g.DrawImage(
                            TileSet.Texture,
                            r,
                            Util.XnaToDrawing.Rectangle(tile.Rectangle),
                            GraphicsUnit.Pixel);
                    }

                    g.DrawRectangle(Pens.Black, r);
                }

                pictureBoxMap.Refresh();
            }
        }

        public void SetMap(TileMap map)
        {
            _tileSet = (TileSet)map.TileSet;

            _rowCount = map.Height;
            _columnCount = map.Width;

            Layers[0] = new TileMapLayer()
            {
                Tiles = map.GetLayerTiles(TileMapLayers.Background).Select(x => x.ToArray()).ToArray()
            };

            Layers[1] = new TileMapLayer()
            {
                Tiles = map.GetLayerTiles(TileMapLayers.Foreground).Select(x => x.ToArray()).ToArray()
            };

            pictureBoxMap.SuspendLayout();

            pictureBoxMap.Image = new Bitmap(ColumnCount * TileScene.TileDimension, RowCount * TileScene.TileDimension);

            if (_tileSet != null)
            {
                Graphics g = Graphics.FromImage(pictureBoxMap.Image);

                for (int layer = 0; layer < Layers.Length; layer++)
                {
                    for (int i = 0; i < _rowCount; i++)
                    {
                        for (int j = 0; j < _columnCount; j++)
                        {
                            int tileId = Layers[layer].Tiles[i][j];

                            Tile tile = TileSet[tileId];

                            g.DrawImage(
                                _tileSet.Texture,
                                new Rectangle(j * TileScene.TileDimension, i * TileScene.TileDimension, TileScene.TileDimension, TileScene.TileDimension),
                                Util.XnaToDrawing.Rectangle(tile.Rectangle),
                                GraphicsUnit.Pixel);
                        }
                    }
                }   
            }

            pictureBoxMap.ResumeLayout();

            AdjustSize();
        }

        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            _selection = true;
            
            HandleSelection(e);
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selection)
            {
                HandleSelection(e);
            }
        }

        private void HandleSelection(MouseEventArgs e)
        {
            int selectedRow = e.Y / TileScene.TileDimension;

            int selectedColumn = e.X / TileScene.TileDimension;

            if (SelectedRow.HasValue && SelectedColumn.HasValue)
            {
                if (SelectedColumn.Value != selectedColumn ||
                    SelectedRow.Value != selectedRow)
                {
                    SelectedRow = selectedRow;

                    SelectedColumn = selectedColumn;

                    SelectedTileChanged?.Invoke(this, new SelectedTileChangedEventArgs(SelectedRow.Value, SelectedColumn.Value));
                }
            }

            SelectedRow = selectedRow;

            SelectedColumn = selectedColumn;
        }

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            _selection = false;
        }
    }

    public class SelectedTileChangedEventArgs
    {
        public int Row { get; }

        public int Column { get; }

        public SelectedTileChangedEventArgs(int row, int column)
        {
            Row = row;

            Column = column;
        }
    }
}
