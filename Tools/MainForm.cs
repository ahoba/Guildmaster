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
using Tools.Animations;
using Tools.Content;
using Tools.Factories;
using Tools.Objects;
using Tools.Scenes.Tiles;

namespace Tools
{
    public partial class MainForm : Form
    {
        private TextureRepository _textureRepository;

        private AnimationRepository _animationRepository;

        private TileSetRepository _tileSetRepository;

        private GameObjectRepository _objectRepository;

        private Dictionary<string, IControlFactory> _controlFactories;

        public MainForm()
        {
            InitializeComponent();

            _textureRepository = new TextureRepository();

            _animationRepository = new AnimationRepository();

            _tileSetRepository = new TileSetRepository();

            _objectRepository = new GameObjectRepository();

            _controlFactories = new Dictionary<string, IControlFactory>();
            _controlFactories[nameof(TextureRepositoryControl)] = new TextureRepositoryControlFactory(_textureRepository);
            _controlFactories[nameof(TileSetRepositoryControl)] = new TileSetRepositoryControlFactory(_tileSetRepository, _textureRepository);
            _controlFactories[nameof(TileMapEditorControl)] = new TileMapEditorControlFactory(_tileSetRepository);
            _controlFactories[nameof(AnimationRepositoryControl)] = new AnimationRepositoryControlFactory(_textureRepository, _animationRepository);
            _controlFactories[nameof(ObjectRepositoryControl)] = new ObjectRepositoryControlFactory(_objectRepository);
        }

        private void ShowControlOnForm(Control control)
        {
            control.Dock = DockStyle.Fill;

            Form form = new Form();

            form.Controls.Add(control);

            form.Show();
        }

        private void toolStripButtonTextureRepository_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(TextureRepositoryControl)].CreateControl();

            ShowControlOnForm(control);
        }

        private void toolStripButtonTileSetRepository_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(TileSetRepositoryControl)].CreateControl();
            
            ShowControlOnForm(control);
        }

        private void toolStripButtonMapEditor_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(TileMapEditorControl)].CreateControl();

            ShowControlOnForm(control);
        }

        private void toolStripButtonAnimations_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(AnimationRepositoryControl)].CreateControl();

            ShowControlOnForm(control);
        }

        private void toolStripButtonObjects_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(ObjectRepositoryControl)].CreateControl();

            ShowControlOnForm(control);
        }
    }
}
