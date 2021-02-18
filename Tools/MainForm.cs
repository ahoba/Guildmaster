using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
using ToolMock;

namespace Tools
{
    public partial class MainForm : Form
    {
        private GraphicsDevice GraphicsDevice { get; }

        public MainForm()
        {
            MockGame mockGame = new MockGame();

            mockGame.RunOneFrame();

            GraphicsDevice = mockGame.GraphicsDevice;

            InitializeComponent();

            mapEditorControl1.GraphicsDevice = GraphicsDevice;

            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    Texture2D sourceTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

                    TileSet tileSet = new TileSet(fileDialog.SafeFileName, sourceTexture, 16);

                    mapEditorControl1.TileSet = tileSet;

                    int[][] tiles = new int[100][];

                    for (int i = 0; i < 100; i++)
                    {
                        tiles[i] = new int[100];

                        for (int j = 0; j < 100; j++)
                        {
                            tiles[i][j] = -1;
                        }
                    }

                    TileMap map = new TileMap(tiles)
                    {
                        TileSet = tileSet
                    };

                    mapEditorControl1.Map = map;
                }
            }
        }
    }
}
