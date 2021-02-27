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
using Tools.Animations;

namespace Tools.Objects
{
    public partial class TileObjectControl : UserControl
    {
        private TileObject _tileObject;

        public BindingList<Animation> Animations { get; } = new BindingList<Animation>();

        private int _tileHeight;

        public int TileHeight 
        { 
            get => _tileHeight; 
            set
            {
                _tileHeight = value;

                TileData = new TileType[_tileHeight][];
            
                for (int i = 0; i < _tileHeight; i++)
                {
                    TileData[i] = new TileType[_tileWidth];
                }
            }
        }

        private int _tileWidth;

        public int TileWidth 
        { 
            get => _tileWidth; 
            set
            {
                _tileWidth = value;

                TileData = new TileType[_tileHeight][];

                for (int i = 0; i < _tileHeight; i++)
                {
                    TileData[i] = new TileType[_tileWidth];
                }
            }
        }

        public int TileDimension { get; set; } = 16;

        public TileType[][] TileData { get; set; }

        public void SetTileObject(TileObject tileObject)
        {
            _tileObject = tileObject;

            Animations.Clear();

            int w = 0;
            int h = 0;

            foreach (Animation animation in tileObject.Animations)
            {
                w = Math.Max(animation.Sprites.Max(x => x.Width), w);
                h = Math.Max(animation.Sprites.Max(x => x.Height), h);

                Animations.Add(animation);
            }

            _tileWidth = w;
            _tileHeight = h;

            TileData = new TileType[_tileHeight][];

            for (int i = 0; i < _tileHeight; i++)
            {
                TileData[i] = new TileType[_tileWidth];
            }
        }

        private int? _selectedRow;
        private int? _selectedColumn;

        public TileObjectControl()
        {
            InitializeComponent();
        }

        public void SaveTileObject()
        {
            _tileObject.Name = textBoxName.Text;
            _tileObject.Animations = (listBoxAnimations.DataSource as IEnumerable<Animation>).ToArray();
            _tileObject.TileData = TileData;
        }

        private void listBoxAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAnimations.SelectedItem is Animation animation)
            {
                Rectangle sprite = Util.XnaToDrawing.Rectangle(animation.Sprites[0]);

                Image image = new Bitmap(sprite.Width, sprite.Height);

                Graphics g = Graphics.FromImage(image);

                g.DrawImage(
                    animation.SourceTexture,
                    new Rectangle(0, 0, sprite.Width, sprite.Height),
                    sprite,
                    GraphicsUnit.Pixel);

                pictureBox.Width = image.Width;
                pictureBox.Height = image.Height;

                for (int i = 0; i < _tileHeight; i++)
                {
                    for (int j = 0; j < _tileWidth; j++)
                    {
                        Rectangle r = new Rectangle(i * TileDimension, j * TileDimension, TileDimension, TileDimension);

                        g.DrawRectangle(Pens.Black, r);
                    }
                }

                _selectedRow = null;
                _selectedColumn = null;

                pictureBox.Image = image;
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            _selectedRow = e.Y / TileDimension;
            _selectedColumn = e.X / TileDimension;

            if (pictureBox.Image != null)
            {
                Graphics g = Graphics.FromImage(pictureBox.Image);
                
                for (int i = 0; i < _selectedRow.Value; i++)
                {
                    for (int j = 0; j < _tileWidth; j++)
                    {
                        Rectangle r = new Rectangle(i * TileDimension, j * TileDimension, TileDimension, TileDimension);

                        g.DrawRectangle(Pens.Black, r);
                    }
                }

                g.DrawRectangle(
                    Pens.White,
                    new Rectangle(
                        _selectedColumn.Value * TileDimension,
                        _selectedRow.Value * TileDimension,
                        TileDimension,
                        TileDimension));
            }
        }

        private void comboBoxTileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTileType.SelectedValue is TileType tileType &&
                _selectedRow.HasValue &&
                _selectedColumn.HasValue)
            {
                TileData[_selectedRow.Value][_selectedColumn.Value] = tileType;
            }
        }
    }
}
