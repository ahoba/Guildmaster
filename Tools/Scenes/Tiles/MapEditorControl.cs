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

namespace Tools.Scenes
{
    public partial class MapEditorControl : UserControl
    {
        private TileSet _tileSet;

        private MapEditMode EditMode { get; set; } = MapEditMode.Add;

        public TileSet TileSet 
        {
            get => _tileSet; 
            set
            {
                _tileSet = value;

                if (_tileSet != null)
                {
                    tileSetControlTileSet.Tiles = _tileSet.Tiles;
                }
            }
        }

        public Tile[][] Map 
        {
            get => tileSetControlMap.Tiles;
            set
            { 
                tileSetControlMap.Tiles = value;

                if (tileSetControlMap.Tiles != null && tileSetControlMap.Tiles[0] != null)
                {
                    numericUpDownMapHeight.Value = tileSetControlMap.Tiles.Length;

                    numericUpDownMapWidth.Value = tileSetControlMap.Tiles[0].Length;
                }
            }
        }
        
        public MapEditorControl()
        {
            InitializeComponent();
        }

        private void tileSetControlMap_SelectedTileChanged(object sender, EventArgs e)
        {
            if (EditMode == MapEditMode.Add)
            {
                if (tileSetControlTileSet.SelectedTile != null)
                {
                    tileSetControlMap.SelectedTile = tileSetControlTileSet.SelectedTile;
                }
            }
            else if (EditMode == MapEditMode.Erase)
            {
                tileSetControlMap.SelectedTile = null;
            }
        }

        private void numericUpDownMapWidth_ValueChanged(object sender, EventArgs e)
        {
            int newWidth = (int)((NumericUpDown)sender).Value;

            for (int i = 0; i < Map.Length; i++)
            {
                Array.Resize(ref Map[i], newWidth);
            }

            Map = Map; // Force Refresh
        }

        private void numericUpDownMapHeight_ValueChanged(object sender, EventArgs e)
        {
            int newHeight = (int)((NumericUpDown)sender).Value;

            Tile[][] newMap = new Tile[newHeight][];

            for (int i = 0; i < newHeight; i++)
            {
                newMap[i] = i >= Map.Length ? 
                    new Tile[Map[0].Length] :
                    Map[i];
            }

            Map = newMap;
        }

        private enum MapEditMode
        {
            Add,
            Erase
        }

        private void toolStripButtonEraser_Click(object sender, EventArgs e)
        {
            EditMode = MapEditMode.Erase;
        }

        private void tileSetControlTileSet_SelectedTileChanged(object sender, EventArgs e)
        {
            EditMode = MapEditMode.Add;
        }
    }
}
