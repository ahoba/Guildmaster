using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Objects.Tiles
{
    public partial class SpritesAnimationControl : UserControl
    {
        public List<SpriteData> Animation { get; } = new List<SpriteData>();

        public SpriteData SelectedSpriteData { get; private set; }

        public SpritesAnimationControl()
        {
            InitializeComponent();
        }

        public void AddSprite(SpriteData spriteData)
        {
            Animation.Add(spriteData);

            Bitmap image = new Bitmap(Animation.Count * spriteData.Sprite.Width, spriteData.Sprite.Height);

            int offset = 0;

            foreach(SpriteData data in Animation)
            {
                Graphics g = Graphics.FromImage(image);

                g.DrawImage(data.Sprite, offset, 0);

                if (data == SelectedSpriteData)
                {
                    g.DrawRectangle(Pens.White, new Rectangle(offset, 0, spriteData.Rectangle.Width, spriteData.Rectangle.Height));
                }
                else
                {
                    g.DrawRectangle(Pens.Black, new Rectangle(offset, 0, spriteData.Rectangle.Width, spriteData.Rectangle.Height));
                }

                offset += data.Sprite.Width;
            }

            pictureBox1.Image = image;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int offset = 0;

            Image image = pictureBox1.Image;

            Graphics g = Graphics.FromImage(image);

            Rectangle? selection = null;

            foreach (SpriteData spriteData in Animation)
            {
                if (e.X > offset && e.X < offset + spriteData.Rectangle.Width)
                {
                    SelectedSpriteData = spriteData;

                    selection = new Rectangle(offset, 0, spriteData.Rectangle.Width, spriteData.Rectangle.Height);
                }
                else
                {
                    g.DrawRectangle(Pens.Black, new Rectangle(offset, 0, spriteData.Rectangle.Width, spriteData.Rectangle.Height));
                }

                offset += spriteData.Rectangle.Width;
            }

            if (selection.HasValue)
            {
                g.DrawRectangle(Pens.White, selection.Value);
            }

            pictureBox1.Refresh();
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if (SelectedSpriteData != null)
            {
                Animation.Remove(SelectedSpriteData);

                int offset = 0;

                Image image = pictureBox1.Image;

                Graphics g = Graphics.FromImage(image);

                g.Clear(Color.Transparent);

                foreach (SpriteData spriteData in Animation)
                {
                    g.DrawImage(spriteData.Sprite, offset, 0);

                    g.DrawRectangle(Pens.Black, new Rectangle(offset, 0, spriteData.Rectangle.Width, spriteData.Rectangle.Height));

                    offset += spriteData.Rectangle.Width;
                }

                pictureBox1.Refresh();

                SelectedSpriteData = null;
            }
        }

        public IEnumerable<Rectangle> CreateSprites()
        {
            return Animation.Select(x => x.Rectangle);
        }
    }
}
