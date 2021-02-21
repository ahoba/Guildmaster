using Danke.Animations;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Content;
using Tools.Util;

namespace Tools.Animations
{
    public partial class AnimationControl : UserControl
    {
        private string _sourceTextureId;

        private Image _sourceTexture;

        private int _width = 0;

        private int _height = 0;

        private List<Rectangle> _sprites;

        public int? SelectedFrame { get; set; }

        public Rectangle[] Sprites => _sprites?.ToArray();

        public AnimationControl()
        {
            InitializeComponent();

            _sprites = new List<Rectangle>();
        }

        public void SetAnimation(Animation animation)
        {
            _sprites.Clear();

            _width = 0;

            _height = 0;

            SelectedFrame = null;

            if (animation == null)
            {
                SetSourceTexture(string.Empty, null);
            }
            else
            {
                SetSourceTexture(animation.SourceTextureId, animation.SourceTexture);

                foreach (var sprite in animation.Sprites)
                {
                    AddSprite(XnaToDrawing.Rectangle(sprite));
                }
            }
        }

        public void SetSourceTexture(string sourceTextureId, Image sourceTexture)
        {
            _sourceTextureId = sourceTextureId;

            _sourceTexture = sourceTexture;

            DrawSprites();
        }

        public void AddSprite(Rectangle sprite)
        {
            _sprites.Add(sprite);

            _width += sprite.Width;

            _height = Math.Max(_height, sprite.Height);

            DrawSprites();
        }

        public void RemoveSprite(int index)
        {
            if (_sprites != null && _sprites.Count > index)
            {
                _width -= _sprites[index].Width;

                _sprites.RemoveAt(index);

                if (index == SelectedFrame)
                {
                    SelectedFrame = null;
                }

                if (_sprites.Count == 0)
                {
                    pictureBoxAnimation.Image = null;

                    SelectedFrame = null;
                }
                else
                {
                    DrawSprites();
                }
            }
        }

        private void DrawSprites()
        {
            if (_sourceTexture != null && _sprites.Count > 0)
            {
                Image image = new Bitmap(_width, _height);

                pictureBoxAnimation.Width = _width;
                pictureBoxAnimation.Height = _height;

                Graphics g = Graphics.FromImage(image);

                int offset = 0;

                int selectionOffset = 0;

                int index = 0;

                foreach (Rectangle sprite in _sprites)
                {
                    Rectangle bound = new Rectangle(offset, 0, sprite.Width, sprite.Height);

                    g.DrawImage(
                        _sourceTexture,
                        bound,
                        sprite,
                        GraphicsUnit.Pixel);

                    g.DrawRectangle(Pens.Black, bound);

                    if (SelectedFrame.HasValue && SelectedFrame.Value == index)
                    {
                        selectionOffset = offset;
                    }

                    offset += sprite.Width;

                    index++;
                }

                if (SelectedFrame.HasValue)
                {
                    Rectangle sprite = _sprites[SelectedFrame.Value];

                    g.DrawRectangle(Pens.White, new Rectangle(selectionOffset, 0, sprite.Width, sprite.Height));
                }

                if (pictureBoxAnimation.Image != null)
                {
                    pictureBoxAnimation.Image.Dispose();
                }

                pictureBoxAnimation.Image = image;
            }
            else
            {
                pictureBoxAnimation.Image = null;
            }
        }

        private void pictureBoxAnimation_MouseClick(object sender, MouseEventArgs e)
        {
            if (_sprites != null && _sprites.Count() > 0 && pictureBoxAnimation.Image != null)
            {
                int offset = 0;

                int index = 0;

                foreach (Rectangle sprite in _sprites)
                {
                    if (offset <= e.X && offset + sprite.Width >= e.X)
                    {
                        SelectedFrame = index;

                        DrawSprites();

                        return;
                    }

                    index++;

                    offset += sprite.Width;
                }
            }
        }
    }
}
