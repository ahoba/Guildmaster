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
using Tools.Objects;

namespace Tools.Scenes.Tiles
{
    public partial class TileMapEditorControl : UserControl
    {
        private TileMap _map;

        public TileMap Map
        {
            get => _map;
            set
            {
                _map = value;

                if (_map != null)
                {
                    textBoxMapName.Text = _map.Name;

                    numericUpDownHeight.Value = _map.Height;
                    numericUpDownWidth.Value = _map.Width;

                    tileMapControl.SetMap(_map);
                }
            }
        }

        public TileSetRepository TileSetRepository
        {
            get => tileSetControl.TileSetRepository;
            set => tileSetControl.TileSetRepository = value;
        }

        public TileMapEditorControl()
        {
            InitializeComponent();

            numericUpDownWidth.Value = 10;
            numericUpDownHeight.Value = 10;

            comboBoxLayer.DataSource = Enum.GetValues(typeof(TileMapLayers));
        }

        private void tileSetControl_SelectedTileSetChanged(object sender, SelectedTileSetChangedEventArgs e)
        {
            tileMapControl.TileSet = e.TileSet;
        }

        private void tileMapControl_SelectedTileChanged(object sender, SelectedTileChangedEventArgs e)
        {
            if (selectedObject == null && comboBoxLayer.SelectedItem is TileMapLayers layer)
            {
                if (toolStripButtonErase.Checked)
                {
                    if (!tileMapControl.TryRemoveObject(e.Row, e.Column))
                    {
                        tileMapControl.SetTile((int)layer, e.Row, e.Column, -1);
                    }
                }
                else if (tileSetControl.Texture != null)
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _map.TileLayers[0] = tileMapControl.Layers[0];
            _map.TileLayers[1] = tileMapControl.Layers[1];

            _map.TileSet = tileMapControl.TileSet;

            _map.ClearObjects();

            foreach (TileObjectInstance instance in tileMapControl.Objects)
            {
                if(!_map.TryAddObjectInstance(instance, out var error))
                {
                    // Error! To do;
                }
            }

            _map.Name = textBoxMapName.Text;
        }

        private void tileMapControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(TileObject)) is TileObject tileObject)
            {
                Point controlPoint = tileMapControl.PointToClient(new Point(e.X, e.Y));

                TileObjectInstance instance = new TileObjectInstance(
                    tileObject,
                    controlPoint.Y / TileScene.TileDimension,
                    controlPoint.X / TileScene.TileDimension);

                tileMapControl.TryAddObject(instance);
            }
        }

        private void tileMapControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(TileObject)) is TileObject)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private TileObjectInstance selectedObject;

        private void tileMapControl_SelectedTileStart(object sender, SelectedTileChangedEventArgs e)
        {
            Cursor.Current = Cursors.Hand;

            tileMapControl.TryGetObject(e.Row, e.Column, out selectedObject);
        }

        private void tileMapControl_SelectedTileEnd(object sender, SelectedTileChangedEventArgs e)
        {
            if (selectedObject != null)
            {
                int x = selectedObject.X;
                int y = selectedObject.Y;

                if (x != e.Row || y != e.Column)
                {
                    if (tileMapControl.TryRemoveObject(y, x))
                    {
                        selectedObject.X = e.Column;
                        selectedObject.Y = e.Row;

                        if (tileMapControl.TryAddObject(selectedObject))
                        {
                            selectedObject = null;
                        }
                        else
                        {
                            selectedObject.X = x;
                            selectedObject.Y = y;

                            tileMapControl.TryAddObject(selectedObject);

                            selectedObject = null;
                        }
                    }
                    else
                    {
                        selectedObject = null;
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
