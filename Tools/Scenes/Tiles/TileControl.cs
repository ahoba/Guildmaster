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
    public partial class TileControl : UserControl
    {
        private Tile _tile;

        public TileSet TileSet { get; set; }

        public Tile Tile
        {
            get => _tile;
            set
            {
                _tile = value;

                if (_tile == null)
                {
                    comboBoxTileTypes.Enabled = false;

                    checkBoxUp.Enabled = false;
                    checkBoxDown.Enabled = false;
                    checkBoxLeft.Enabled = false;
                    checkBoxRight.Enabled = false;

                    pictureBoxTile.Image = null;
                }
                else
                {
                    comboBoxTileTypes.Enabled = true;

                    checkBoxUp.Enabled = true;
                    checkBoxDown.Enabled = true;
                    checkBoxLeft.Enabled = true;
                    checkBoxRight.Enabled = true;

                    if (TileSet != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            _tile.Texture.SaveAsPng(ms, TileSet.TileDimension, TileSet.TileDimension);

                            pictureBoxTile.Image = new Bitmap(ms);
                        }
                    }

                    comboBoxTileTypes.SelectedItem = _tile.Type;

                    checkBoxUp.Checked = _tile.EnabledDirections[0];
                    checkBoxDown.Checked = _tile.EnabledDirections[1];
                    checkBoxLeft.Checked = _tile.EnabledDirections[2];
                    checkBoxRight.Checked = _tile.EnabledDirections[3];
                }
            }
        }

        public TileControl()
        {
            InitializeComponent();

            comboBoxTileTypes.DataSource = Enum.GetValues(typeof(TileType));
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_tile != null)
            {
                if (sender == checkBoxUp)
                {
                    _tile.EnabledDirections[0] = checkBoxUp.Checked;
                }
                else if (sender == checkBoxDown)
                {
                    _tile.EnabledDirections[1] = checkBoxDown.Checked;
                }
                else if (sender == checkBoxLeft)
                {
                    _tile.EnabledDirections[2] = checkBoxLeft.Checked;
                }
                else if (sender == checkBoxRight)
                {
                    _tile.EnabledDirections[3] = checkBoxRight.Checked;
                }
            }
        }

        private void comboBoxTileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tile != null)
            {
                _tile.Type = (TileType)comboBoxTileTypes.SelectedItem;
            }
        }
    }
}