using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Util
{
    public partial class TileTextureControl : UserControl
    {
        public Image Texture { get; private set; }

        public string TextureId { get; private set; }

        private int _tileDimension = 16;

        public int TileDimension 
        { 
            get => _tileDimension;
            set
            {
                _tileDimension = value;
            }
        }

        private Point _selectionStart;

        private Point _selectionEnd;

        private bool _selection;

        public Rectangle Selection
        {
            get
            {
                Rectangle[] rects = new Rectangle[]
                {
                    new Rectangle(
                        _selectionStart.X * TileDimension,
                        _selectionStart.Y * TileDimension,
                        TileDimension,
                        TileDimension),
                    new Rectangle(
                        _selectionEnd.X * TileDimension,
                        _selectionEnd.Y * TileDimension,
                        TileDimension,
                        TileDimension)
                };

                int x0 = rects.Min(r => r.X);
                int y0 = rects.Min(r => r.Y);

                int x1 = rects.Max(r => r.Right);
                int y1 = rects.Max(r => r.Bottom);

                return new Rectangle(x0, y0, x1 - x0, y1 - y0);
            }
        }

        public IEnumerable<Rectangle> SelectedTiles
        {
            get
            {
                for (int i = 0; i * TileDimension < Selection.Height; i++)
                {
                    for (int j = 0; j * TileDimension < Selection.Width; j++)
                    {
                        yield return new Rectangle(
                            i * TileDimension,
                            j * TileDimension,
                            TileDimension,
                            TileDimension);
                    }
                }
            }
        }

        public IEnumerable<int> SelectedTileIds
        {
            get
            {
                int columns = Texture.Width / TileDimension;

                for (int i = Math.Min(_selectionStart.Y, _selectionEnd.Y); i <= Math.Max(_selectionStart.Y, _selectionEnd.Y); i++)
                {
                    for (int j = Math.Min(_selectionStart.X, _selectionEnd.X); j <= Math.Max(_selectionStart.X, _selectionEnd.X); j++)
                    {
                        yield return i * columns + j;
                    }
                }
            }
        }

        public int[][] SelectionMatrix
        {
            get
            {
                int[][] ret = new int[Math.Abs(_selectionStart.Y - _selectionEnd.Y) + 1][];

                int x = Math.Min(_selectionStart.X, _selectionEnd.X);
                int y = Math.Min(_selectionStart.Y, _selectionEnd.Y);

                int columns = Texture.Width / TileDimension;

                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = new int[Math.Abs(_selectionStart.X - _selectionEnd.X) + 1];

                    for (int j = 0; j < ret[i].Length; j++)
                    {
                        ret[i][j] = x + j + (y + i) * columns;
                    }
                }

                return ret;
            }
        }

        public TileTextureControl()
        {
            InitializeComponent();
        }

        public void SetTexture(string textureId, Image texture)
        {
            TextureId = textureId;

            Texture = (Image)texture.Clone();

            pictureBox.Image = Texture;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                for (int i = 0; i * TileDimension < pictureBox.Image.Height; i++)
                {
                    for (int j = 0; j * TileDimension < pictureBox.Image.Width; j++)
                    {
                        Rectangle rectangle = new Rectangle(
                            j * TileDimension,
                            i * TileDimension,
                            TileDimension,
                            TileDimension);

                        e.Graphics.DrawRectangle(Pens.Black, rectangle);
                    }
                }

                e.Graphics.DrawRectangle(Pens.White, Selection);
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                _selection = true;

                _selectionStart = new Point(e.X / TileDimension, e.Y / TileDimension);
                _selectionEnd = new Point(e.X / TileDimension, e.Y / TileDimension);

                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image != null && _selection)
            {
                int x = Math.Min(Math.Max(0, e.X), pictureBox.Image.Width);
                int y = Math.Min(Math.Max(0, e.Y), pictureBox.Image.Height);

                _selectionEnd = new Point(x / TileDimension, y / TileDimension);

                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _selection = false;
        }
    }
}
