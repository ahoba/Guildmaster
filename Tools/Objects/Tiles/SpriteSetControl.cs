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

namespace Tools.Objects.Tiles
{
    public partial class SpriteSetControl : UserControl
    {
        GraphicsDevice _graphicsDevice;

        public GraphicsDevice GraphicsDevice
        {
            get => _graphicsDevice;
            set
            {
                _graphicsDevice = value;

                tileSpritesControl1.GraphicsDevice = _graphicsDevice;
            }
        }

        public SpriteSetControl()
        {
            InitializeComponent();

            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    Image image = Image.FromStream(fileStream);

                    tileSpritesControl1.SourceImage = image;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tileSpritesControl1.TryCreateSpriteData(out SpriteData data))
            {
                tileAnimationControl1.AddSprite(data);
            }
        }
    }
}
