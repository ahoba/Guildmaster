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

            OpenFileDialog fileDialog = new OpenFileDialog();
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    Texture2D sourceTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

                    TileSet tileSet = new TileSet(sourceTexture, 16);

                    mapEditorControl1.TileSet = tileSet;

                    Tile[][] map = new Tile[10][];

                    for (int i = 0; i < 10; i++)
                    {
                        map[i] = new Tile[10];
                    }

                    mapEditorControl1.Map = map;
                }
            }
        }
    }
}
