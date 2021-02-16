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
    public partial class MapControl : UserControl
    {
        private int _mapWidth = 0;

        private int _mapHeight = 0;
        
        public TileWrapper[][] Map { get; private set; }

        public int OffsetX { get; set; }

        public int OffsetY { get; set; }

        public int TileDimension { get; set; }

        public int MapWidth
        {
            get => _mapWidth;
            set
            {
                _mapWidth = value;

                int nRow = 0;

                foreach (TileWrapper[] row in Map)
                {
                    TileWrapper[] newRow = new TileWrapper[_mapWidth];

                    for (int i = 0; i < _mapWidth; i++)
                    {
                        newRow[i] = i >= row.Length ?
                            null : row[i];
                    }

                    Map[nRow] = newRow;

                    nRow++;
                }
            }
        }

        public int MapHeight
        {
            get => _mapHeight;
            set
            {
                _mapHeight = value;

                TileWrapper[][] newMap = new TileWrapper[_mapHeight][];

                for (int i = 0; i < _mapHeight; i++)
                {
                    newMap[i] = i >= Map.Length ?
                        null : Map[i];
                }

                Map = newMap;
            }
        }

        public MapControl()
        {
            InitializeComponent();

            Map = new TileWrapper[0][];
            Map[0] = new TileWrapper[0];
        }

        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            for (int row = OffsetY; row < Map.Length; row++)
            {
                for (int column = OffsetX; column < Map[row].Length; column++)
                {
                    TileWrapper tile = Map[row][column];

                    if (tile != null)
                    {

                    }
                }
            }
        }

        public class TileWrapper
        {
            public Tile Tile { get; }

            public Image Image { get; }

            public TileWrapper(Tile tile)
            {
                Tile = tile;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    tile.Texture.SaveAsJpeg(memoryStream, Tile.Texture.Width, Tile.Texture.Height);

                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(memoryStream);

                    Image = bmp;
                }
            }
        }
    }
}
