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
        private int SelectedRow { get; set; }
        
        private int SelectedColumn { get; set; }

        private TileMap _map;

        public TileMap Map
        {
            get => _map;
            set
            {
                _map = value;

                if (_map != null)
                {
                    Bitmap image = new Bitmap(_map.Width * _map.TileDimension, _map.Height * _map.TileDimension);

                    for (int i = 0; i < _map.Height; i++)
                    {
                        for (int j = 0; j < _map.Width; j++)
                        {
                            Tile tile = _map.TileAt(i, j, TileMapLayers.Background);

                            SetTileImageToImage(tile, image, i, j);

                            Image foreground = ImageFromTile(Map.TileAt(i, j, TileMapLayers.Foreground));

                            using (Graphics g = Graphics.FromImage(image))
                            {
                                g.DrawImage(foreground, SelectedColumn * Map.TileDimension, SelectedRow * Map.TileDimension);
                            }
                        }
                    }

                    pictureBox.Image = image;

                    pictureBox.Refresh();
                }
            }
        }

        public TileMapLayers Layer { get; set; } = TileMapLayers.Background;

        public Tile SelectedTile
        {
            get => Map.TileAt(SelectedRow, SelectedColumn, Layer);
            set
            {
                Map.Layers[(int)Layer].Tiles[SelectedRow][SelectedColumn] = value == null ? -1 : value.ID;

                SetTileImageToImage(Map.TileAt(SelectedRow, SelectedColumn, TileMapLayers.Background), (Bitmap)pictureBox.Image, SelectedRow, SelectedColumn);

                Image foreground = ImageFromTile(Map.TileAt(SelectedRow, SelectedColumn, TileMapLayers.Foreground));

                using (Graphics g = Graphics.FromImage(pictureBox.Image))
                {
                    g.DrawImage(foreground, SelectedColumn * Map.TileDimension, SelectedRow * Map.TileDimension);
                }

                pictureBox.Refresh();
            }
        }

        public event EventHandler<EventArgs> SelectedTileChanged;

        public TileSetControl()
        {
            InitializeComponent();
        }

        private Image ImageFromTile(Tile tile)
        {
            if (tile == null)
            {
                Bitmap image = new Bitmap(Map.TileDimension, Map.TileDimension);

                for (int i = 0; i < Map.TileDimension; i++)
                {
                    for (int j = 0; j < Map.TileDimension; j++)
                    {
                        image.SetPixel(j, i, Color.Transparent);
                    }
                }

                return image;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    tile.Texture.SaveAsPng(ms, Map.TileDimension, Map.TileDimension);

                    Bitmap tileData = new Bitmap(ms);

                    return tileData;
                }
            }
        }

        private void SetTileImageToImage(Tile tile, Bitmap image, int row, int column)
        {
            if (tile == null)
            {
                for (int i = 0; i < Map.TileDimension; i++)
                {
                    for (int j = 0; j < Map.TileDimension; j++)
                    {
                        image.SetPixel(column * Map.TileDimension + j, row * Map.TileDimension + i, Color.Transparent);
                    }
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    tile.Texture.SaveAsPng(ms, Map.TileDimension, Map.TileDimension);

                    Bitmap tileData = new Bitmap(ms);

                    for (int i = 0; i < Map.TileDimension; i++)
                    {
                        for (int j = 0; j < Map.TileDimension; j++)
                        {
                            image.SetPixel(column * Map.TileDimension + j, row * Map.TileDimension + i, tileData.GetPixel(j, i));
                        }
                    }
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedRow = Math.Max(Math.Min(e.Y / Map.TileDimension, Map.Height - 1), 0);

            SelectedColumn = Math.Max(Math.Min(e.X / Map.TileDimension, Map.Width - 1), 0);

            pictureBox.Refresh();

            SelectedTileChanged?.Invoke(this, new EventArgs());
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (Map != null)
            {
                Rectangle r = new Rectangle(SelectedColumn * Map.TileDimension, SelectedRow * Map.TileDimension, Map.TileDimension, Map.TileDimension);

                e.Graphics.DrawRectangle(Pens.White, r);
            }
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
