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
    public partial class TileMapEditorControl : UserControl
    {
        public TileSetRepository TileSetRepository
        {
            get => tileSetControl.TileSetRepository;
            set => tileSetControl.TileSetRepository = value;
        }

        public int TileDimension
        {
            get => tileMapControl.TileDimension;
            set
            {
                tileMapControl.TileDimension = value;
            }
        }

        public TileMapEditorControl()
        {
            InitializeComponent();

            numericUpDownWidth.Value = 10;
            numericUpDownHeight.Value = 10;

            comboBoxLayer.DataSource = Enum.GetValues(typeof(Danke.Scenes.Tiles.TileMapLayers));
        }

        private void tileSetControl_SelectedTileSetChanged(object sender, SelectedTileSetChangedEventArgs e)
        {
            tileMapControl.TileSet = e.TileSet;
        }

        private void tileMapControl_SelectedTileChanged(object sender, SelectedTileChangedEventArgs e)
        {
            if (comboBoxLayer.SelectedItem is Danke.Scenes.Tiles.TileMapLayers layer)
            {
                //tileMapControl.SetTile((int)layer, e.Row, e.Column, _eraser ? -1 : tileSetControl.SelectedTileId);

                if (toolStripButtonErase.Checked)
                {
                    tileMapControl.SetTile((int)layer, e.Row, e.Column, -1);
                }
                else
                {
                    int[][] selectedTiles = tileSetControl.SelectionMatrix;

                    if (selectedTiles != null && selectedTiles.Length > 0 && selectedTiles[0].Length > 0)
                    {
                        for (int i = 0; i < selectedTiles.Length; i++)
                        {
                            if (e.Row + i >= tileMapControl.RowCount)
                            {
                                break;
                            }

                            for (int j = 0; j < selectedTiles[i].Length; j++)
                            {
                                if (e.Column + j >= tileMapControl.ColumnCount)
                                {
                                    break;
                                }

                                tileMapControl.SetTile((int)layer, e.Row + i, e.Column + j, selectedTiles[i][j]);
                            }
                        }
                    }
                }
            }
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            tileMapControl.RowCount = (int)numericUpDownHeight.Value;
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            tileMapControl.ColumnCount = (int)numericUpDownWidth.Value;
        }
    }
}
