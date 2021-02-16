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
        private int? SelectedRow { get; set; } = null;

        private int? SelectedColumn { get; set; } = null;

        private PictureBox SelectedPicture { get; set; }

        private TileSet TileSet { get; set; }

        private TileGridData[][] GridData { get; set; }

        public Tile SelectedTile { get; set; }

        public TileSetControl()
        {
            InitializeComponent();

            hScrollBar.Visible = false;
            vScrollBar.Visible = false;
        }

        private void TableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (SelectedColumn.HasValue && SelectedRow.HasValue)
            {
                if (e.Row == SelectedRow.Value && e.Column == SelectedColumn.Value)
                {
                    Graphics g = e.Graphics;

                    Rectangle r = e.CellBounds;

                    g.DrawRectangle(Pens.White, r);
                }
            }
        }

        public TileSetControl SetTileSet(TileSet tileSet)
        {
            TileSet = tileSet;

            hScrollBar.Visible = true;
            vScrollBar.Visible = true;

            UpdateLayout();

            hScrollBar.Scroll += Scroll;
            vScrollBar.Scroll += Scroll;

            return this;
        }

        private void Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                UpdateTableLayout();
                
                tableLayoutPanel.ResumeLayout();
            }
            else
            {
                tableLayoutPanel.SuspendLayout();
            }
        }

        private void UpdateLayout()
        {
            if (TileSet != null)
            {
                tableLayoutPanel.RowCount = tableLayoutPanel.Height / TileSet.TileDimension;
                tableLayoutPanel.ColumnCount = tableLayoutPanel.Height / TileSet.TileDimension;

                hScrollBar.Minimum = 0;
                hScrollBar.Maximum = TileSet.Columns - tableLayoutPanel.ColumnCount / 2;

                vScrollBar.Minimum = 0;
                vScrollBar.Maximum = TileSet.Rows - tableLayoutPanel.RowCount / 2;

                GridData = new TileGridData[tableLayoutPanel.RowCount][];

                for(int row = 0; row < tableLayoutPanel.RowCount; row++)
                {
                    GridData[row] = new TileGridData[tableLayoutPanel.ColumnCount];
                }

                foreach (ColumnStyle columnStyle in tableLayoutPanel.ColumnStyles)
                {
                    columnStyle.SizeType = SizeType.Absolute;
                    columnStyle.Width = TileSet.TileDimension;
                }

                foreach (RowStyle rowStyle in tableLayoutPanel.RowStyles)
                {
                    rowStyle.SizeType = SizeType.Absolute;
                    rowStyle.Height = TileSet.TileDimension;
                }

                UpdateTableLayout();
            }
        }

        private void UpdateTableLayout()
        {
            for (int row = 0; row < tableLayoutPanel.RowCount; row++)
            {
                for (int column = 0; column < tableLayoutPanel.ColumnCount; column++)
                {
                    Tile tile = (vScrollBar.Value + row >= TileSet.Tiles.Length || hScrollBar.Value + column >= TileSet.Tiles[vScrollBar.Value + row].Length) ?
                        null : TileSet.Tiles[vScrollBar.Value + row][hScrollBar.Value + column];

                    if (GridData[row][column] == null)
                    {
                        PictureBox picture = new PictureBox()
                        {
                            Width = TileSet.TileDimension,
                            Height = TileSet.TileDimension,
                            Margin = new Padding(0),
                            Padding = new Padding(0),
                            Tag = tile
                        };

                        picture.Click += Picture_Click;

                        if (tile != null)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                tile.Texture.SaveAsJpeg(memoryStream, TileSet.TileDimension, TileSet.TileDimension);

                                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(memoryStream);

                                picture.Image = bmp;
                            }
                        }

                        GridData[row][column] = new TileGridData()
                        {
                            PictureBox = picture,
                            Tile = tile
                        };

                        tableLayoutPanel.Controls.Add(picture);
                    }
                    else
                    {
                        if (tile == null)
                        {
                            GridData[row][column].PictureBox.Image = null;

                            GridData[row][column].PictureBox.Refresh();
                        }
                        else
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                tile.Texture.SaveAsJpeg(memoryStream, TileSet.TileDimension, TileSet.TileDimension);

                                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(memoryStream);

                                GridData[row][column].PictureBox.Image = bmp;

                                GridData[row][column].PictureBox.Refresh();
                            }
                        }

                        GridData[row][column].Tile = tile;
                    }
                }
            }
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            if (SelectedPicture != null)
            {
                SelectedPicture.Paint -= SelectedPicture_Paint;

                PictureBox previous = SelectedPicture;

                SelectedPicture = null;

                previous.Refresh();
            }

            SelectedPicture = (PictureBox)sender;

            if (SelectedPicture.Tag is Tile tile)
            {
                SelectedTile = tile;
            }

            SelectedPicture.Paint += SelectedPicture_Paint;

            SelectedPicture.Refresh();
        }

        private void SelectedPicture_Paint(object sender, PaintEventArgs e)
        {
            if (sender == SelectedPicture)
            {
                Graphics g = e.Graphics;

                Rectangle r = e.ClipRectangle;
                
                r.Inflate(-1, -1);
                
                g.DrawRectangle(Pens.White, r);
            }
        }

        private class TileGridData
        {
            public PictureBox PictureBox { get; set; }

            public Tile Tile { get; set; }
        }
    }
}
