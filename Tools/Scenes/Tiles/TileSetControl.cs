using Danke.Scenes.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Scenes
{
    public partial class TileSetControl : UserControl
    {
        private Tile[][] _tiles;

        private int OffsetX { get; set; }

        private int OffsetY { get; set; }

        private int SelectedRow { get; set; }
        
        private int SelectedColumn { get; set; }

        public int TileDimension { get; set; } = 16;

        public Tile SelectedTile
        {
            get => _tiles[SelectedRow][SelectedColumn];
            set
            {
                _tiles[SelectedRow][SelectedColumn] = value;

                SetTileImageToImage(_tiles[SelectedRow][SelectedColumn], (Bitmap)pictureBox.Image, SelectedRow, SelectedColumn);

                pictureBox.Refresh();
            }
        }

        public event EventHandler<EventArgs> SelectedTileChanged;

        public Tile[][] Tiles 
        { 
            get => _tiles; 
            set
            {
                _tiles = value;

                if (_tiles != null && _tiles[0] != null)
                {
                    Bitmap image = new Bitmap(_tiles[0].Length * TileDimension, _tiles.Length * TileDimension);

                    for (int i = 0; i < _tiles.Length; i++)
                    {
                        for (int j = 0; j < _tiles[i].Length; j++)
                        {
                            SetTileImageToImage(_tiles[i][j], image, i, j);
                        }
                    }

                    pictureBox.Image = image;
                }
            }
        }

        public TileSetControl()
        {
            InitializeComponent();
        }

        private void SetTileImageToImage(Tile tile, Bitmap image, int row, int column)
        {
            if (tile == null)
            {
                for (int i = 0; i < TileDimension; i++)
                {
                    for (int j = 0; j < TileDimension; j++)
                    {
                        image.SetPixel(column * TileDimension + j, row * TileDimension + i, Color.Black);
                    }
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    tile.Texture.SaveAsPng(ms, TileDimension, TileDimension);

                    Bitmap tileData = new Bitmap(ms);

                    for (int i = 0; i < TileDimension; i++)
                    {
                        for (int j = 0; j < TileDimension; j++)
                        {
                            image.SetPixel(column * TileDimension + j, row * TileDimension + i, tileData.GetPixel(j, i));
                        }
                    }
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedRow = Math.Max(Math.Min(e.Y / TileDimension, Tiles.Length - 1), 0);

            SelectedColumn = Math.Max(Math.Min(e.X / TileDimension, Tiles[0].Length - 1), 0);

            pictureBox.Refresh();

            SelectedTileChanged?.Invoke(this, new EventArgs());
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(SelectedColumn * TileDimension, SelectedRow * TileDimension, TileDimension, TileDimension);

            e.Graphics.DrawRectangle(Pens.White, r);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox_MouseClick(sender, e);
            }
        }
    }
}
