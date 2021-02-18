using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tools.Scenes
{
    public partial class MapEditorControl : UserControl
    {
        private TileSet _tileSet;

        private MapEditMode EditMode { get; set; } = MapEditMode.Add;

        public GraphicsDevice GraphicsDevice { get; set; }

        public TileSet TileSet 
        {
            get => _tileSet; 
            set
            {
                _tileSet = value;

                if (_tileSet != null)
                {
                    int[][] map = new int[_tileSet.Rows][];

                    int k = 0;

                    for (int i = 0; i < _tileSet.Rows; i++)
                    {
                        map[i] = new int[_tileSet.Columns];

                        for (int j = 0; j < _tileSet.Columns; j++)
                        {
                            map[i][j] = k;

                            k++;
                        }
                    }

                    tileSetControlTileSet.Map = new TileMap(map)
                    {
                        TileSet = _tileSet
                    };

                    tileControl.TileSet = _tileSet;

                    if (tileSetControlMap.Map != null)
                    {
                        tileSetControlMap.Map.TileSet = _tileSet;
                    }
                }
            }
        }

        public TileMap Map
        {
            get => tileSetControlMap.Map;
            set
            {
                tileSetControlMap.Map = value;

                if (tileSetControlMap.Map != null)
                {
                    numericUpDownMapHeight.Value = Map.Height;
                    numericUpDownMapWidth.Value = Map.Width;
                }
            }
        }

        public MapEditorControl()
        {
            InitializeComponent();

            comboBoxLayers.DataSource = Enum.GetValues(typeof(TileMapLayers));
            comboBoxLayers.SelectedIndex = 0;
            
            comboBoxLayers.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                tileSetControlMap.Layer = (TileMapLayers)comboBoxLayers.SelectedItem;
            };
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
            int previousWidth = Map.Width;

            for (int i = 0; i < Map.Height; i++)
            {
                Array.Resize(ref Map.Layers[(int)TileMapLayers.Background].Tiles[i], newWidth);
                Array.Resize(ref Map.Layers[(int)TileMapLayers.Foreground].Tiles[i], newWidth);

                for (int j = previousWidth; j < newWidth; j++)
                {
                    Map.Layers[(int)TileMapLayers.Background].Tiles[i][j] = -1;
                    Map.Layers[(int)TileMapLayers.Foreground].Tiles[i][j] = -1;
                }
            }

            Map = Map;
        }

        private void numericUpDownMapHeight_ValueChanged(object sender, EventArgs e)
        {
            int newHeight = (int)((NumericUpDown)sender).Value;

            int[][] background = new int[newHeight][];
            int[][] foreground = new int[newHeight][];

            for (int i = 0; i < newHeight; i++)
            {
                if (i >= Map.Height)
                {
                    background[i] = new int[Map.Width];
                    foreground[i] = new int[Map.Width];

                    for (int j = 0; j < Map.Width; j++)
                    {
                        background[i][j] = -1;
                        foreground[i][j] = -1;
                    }
                }
                else
                {
                    background[i] = Map.Layers[0].Tiles[i];
                    foreground[i] = Map.Layers[1].Tiles[i];
                }
            }

            Map = new TileMap(background, foreground)
            {
                TileSet = TileSet
            };
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

            tileControl.Tile = tileSetControlTileSet.SelectedTile;
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".xml"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                if (tileSetControlMap.Map != null)
                {
                    var serializer = new DataContractSerializer(typeof(TileMap));

                    var settings = new XmlWriterSettings { Indent = true };

                    using (var stream = XmlWriter.Create(dialog.FileName, settings))
                    {
                        serializer.WriteObject(stream, tileSetControlMap.Map);
                    }
                }

                Cursor = Cursors.Arrow;
            }
        }

        private void toolStripButtonOpenMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Select the map xml data",
                Filter = "XML serialized data (*.xml)|*.xml"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(TileMap));

                        TileMap map = (TileMap)serializer.ReadObject(reader, true);

                        map.TileSet = TileSet;

                        tileSetControlMap.Map = map;

                        numericUpDownMapHeight.Value = map.Height;
                        numericUpDownMapWidth.Value = map.Width;
                    }
                }
                
                Cursor = Cursors.Arrow;
            }
        }

        private void toolStripButtonExportTileSet_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".xml"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                if (TileSet != null)
                {
                    var serializer = new DataContractSerializer(typeof(TileSet));

                    var settings = new XmlWriterSettings { Indent = true };

                    using (var stream = XmlWriter.Create(dialog.FileName, settings))
                    {
                        serializer.WriteObject(stream, TileSet);
                    }
                }

                Cursor = Cursors.Arrow;
            }
        }

        private void toolStripButtonOpenTileSet_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Select the tile xml data",
                Filter = "XML serialized data (*.xml)|*.xml"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                TileSet tileSet;

                try
                {
                    using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open))
                    {
                        using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()))
                        {
                            DataContractSerializer serializer = new DataContractSerializer(typeof(TileSet));

                            tileSet = (TileSet)serializer.ReadObject(reader, true);
                            
                            for (int i = 0; i < tileSet.Rows; i++)
                            {
                                if (i < TileSet.Rows)
                                {
                                    for (int j = 0; j < tileSet.Columns; j++)
                                    {
                                        if (j < TileSet.Columns)
                                        {
                                            CopyTileProperties(tileSet.Tiles[i][j], TileSet.Tiles[i][j]);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

                Cursor = Cursors.Arrow;
            }
        }

        private void CopyTileProperties(Tile source, Tile destination)
        {
            destination.EnabledDirections = source.EnabledDirections;

            destination.Type = source.Type;
        }

        private void toolStripButtonTileSetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    Texture2D sourceTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

                    TileSet.SetTexture(sourceTexture);
                }
            }
        }
    }
}
