using Danke.Animations;
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
using Tools.Animations;
using Tools.Content;
using Tools.Factories;
using Tools.Scenes.Tiles;

namespace Tools
{
    public partial class MainForm : Form
    {
        private TextureRepository _textureRepository;

        private AnimationRepository _animationRepository;

        private TileSetRepository _tileSetRepository;

        private TileMapEditorControlFactory _tileMapEditorFactory;

        public MainForm()
        {
            InitializeComponent();

            _textureRepository = new TextureRepository();

            _animationRepository = new AnimationRepository();

            _tileSetRepository = new TileSetRepository();

            _tileMapEditorFactory = new TileMapEditorControlFactory(_tileSetRepository);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    Image texture = Image.FromStream(fileStream);

                    _textureRepository.AddTexture(openFileDialog.SafeFileName, texture);

                    _tileSetRepository.AddTileSet(
                        new TileSet(16, openFileDialog.SafeFileName, texture, texture.Height / 16, texture.Width / 16)
                        {
                            Id = Guid.NewGuid()
                        });

                    this.Controls.Add(_tileMapEditorFactory.CreateControl(new MapEditorFactoryArgs()
                    {
                        TileDimension = 16
                    }));
                    //tileImageControl1.SetTexture(openFileDialog.SafeFileName, texture);
                }
            }
        }
    }
}
