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

namespace Tools
{
    public partial class MainForm : Form
    {
        private TextureRepository _textureRepository;

        private AnimationRepository _animationRepository;
        public MainForm()
        {
            InitializeComponent();

            _textureRepository = new TextureRepository();

            _animationRepository = new AnimationRepository(_textureRepository);
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

                    animationRepositoryControl1.TextureRepository = _textureRepository;
                    animationRepositoryControl1.AnimationRepository = _animationRepository;

                    //tileImageControl1.SetTexture(openFileDialog.SafeFileName, texture);
                }
            }
        }
    }
}
