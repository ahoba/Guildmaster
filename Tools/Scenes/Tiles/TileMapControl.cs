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
        private int _tileDimension;

        public int TileDimension 
        { 
            get => _tileDimension; 
            set
            {
                _tileDimension = value;

                AdjustSize();
            }
        }

        private TileSet _tileSet;

        public TileSet TileSet
        {
            get => _tileSet;
            set
            {
                _tileSet = value;
            }
        }

        private TileMapLayer[] _layers;

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

                for (int layer = 0; layer < _layers.Length; layer++)
                {
                    if (_layers[layer].Tiles == null)
                    {
                        _layers[layer].Tiles = new int[_rowCount][];

                        for (int i = 0; i < _rowCount; i++)
                        {
                            _layers[layer].Tiles[i] = new int[_columnCount];
                        }
                    }
                    else
                    {
                        int[][] newTiles = new int[_rowCount][];

                        for (int i = 0; i < Math.Max(_rowCount, _layers[layer].Tiles.Length); i++)
                        {
                            if (i >= _rowCount)
                            {
                                break;
                            }

                            newTiles[i] = i >= _layers[layer].Tiles.Length ?
                                CreateEmptyRow(_columnCount) : _layers[layer].Tiles[i];
                        }

                        _layers[layer].Tiles = newTiles;
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

                for (int layer = 0; layer < _layers.Length; layer++)
                {
                    if (_layers[layer].Tiles == null)
                    {
                        _layers[layer].Tiles = new int[_rowCount][];

                        for (int i = 0; i < _rowCount; i++)
                        {
                            _layers[layer].Tiles[i] = CreateEmptyRow(_columnCount);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _rowCount; i++)
                        {
                            if (_layers[layer].Tiles[i] == null)
                            {
                                _layers[layer].Tiles[i] = CreateEmptyRow(_columnCount);
                            }
                            else
                            {
                                int[] newRow = new int[_columnCount];

                                for (int j = 0; j < Math.Max(_rowCount, _layers[layer].Tiles[i].Length); j++)
                                {
                                    if (j >= _columnCount)
                                    {
                                        break;
                                    }

                                    newRow[j] = j >= _layers[layer].Tiles[i].Length ? -1 : _layers[layer].Tiles[i][j];
                                }

                                _layers[layer].Tiles[i] = newRow;
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

            _layers = new TileMapLayer[2];

            _layers[0] = new TileMapLayer();
            _layers[1] = new TileMapLayer();
        }

        private void AdjustSize()
        {
            pictureBoxMap.SuspendLayout();

            pictureBoxMap.Height = _rowCount * _tileDimension;
            pictureBoxMap.Width = _columnCount * _tileDimension;

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
                            g.DrawRectangle(Pens.Black, new Rectangle(j * TileDimension, i * TileDimension, TileDimension, TileDimension));
                        }
                    }
                }

                pictureBoxMap.Image = image;
            }

            pictureBoxMap.ResumeLayout();
        }

        public void SetTile(int layer, int row, int column, int tileId)
        {
            if (layer < _layers.Length &&
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
                    pictureBoxMap.Image = new Bitmap(ColumnCount * TileDimension, RowCount * TileDimension);
                }

                _layers[layer].Tiles[row][column] = tileId;
                
                for (int i = 0; i < TileDimension; i++)
                {
                    for (int j = 0; j < TileDimension; j++)
                    {
                        (pictureBoxMap.Image as Bitmap).SetPixel(column * TileDimension + j, row * TileDimension + i, Color.Transparent);
                    }
                }
                
                Graphics g = Graphics.FromImage(pictureBoxMap.Image);

                for (int k = 0; k < _layers.Length; k++)
                {
                    tileId = _layers[k].Tiles[row][column];

                    Tile tile = TileSet[tileId];

                    Rectangle r = new Rectangle(column * TileDimension, row * TileDimension, TileDimension, TileDimension);
                    
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
            int selectedRow = e.Y / TileDimension;

            int selectedColumn = e.X / TileDimension;

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
