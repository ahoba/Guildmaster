﻿using Danke.Scenes.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Animations;

namespace Tools.Objects
{
    public partial class TileObjectControl : UserControl
    {
        private TileObject _tileObject;

        public BindingList<Animation> Animations { get; } = new BindingList<Animation>();

        private int _tileHeight;

        public int TileHeight 
        { 
            get => _tileHeight; 
            set
            {
                _tileHeight = value;

                TileData = new TileType[_tileHeight][];
            
                for (int i = 0; i < _tileHeight; i++)
                {
                    TileData[i] = new TileType[_tileWidth];
                }
            }
        }

        private int _tileWidth;

        public int TileWidth 
        { 
            get => _tileWidth; 
            set
            {
                _tileWidth = value;

                TileData = new TileType[_tileHeight][];

                for (int i = 0; i < _tileHeight; i++)
                {
                    TileData[i] = new TileType[_tileWidth];
                }
            }
        }

        public TileType[][] TileData { get; set; }

        public void SetTileObject(TileObject tileObject)
        {
            _tileObject = tileObject;

            textBoxName.Text = _tileObject?.Name;

            pictureBox.Image = null;

            Animations.Clear();

            int w = 0;
            int h = 0;

            if (tileObject.Animations != null)
            {
                foreach (Animation animation in tileObject.Animations)
                {
                    w = Math.Max(animation.Sprites.Max(x => x.Width), w);
                    h = Math.Max(animation.Sprites.Max(x => x.Height), h);

                    Animations.Add(animation);
                }
            }

            _tileWidth = w;
            _tileHeight = h;

            if (_tileObject.TileData == null)
            {
                TileData = new TileType[_tileHeight][];

                for (int i = 0; i < _tileHeight; i++)
                {
                    TileData[i] = new TileType[_tileWidth];
                }
            }
            else
            {
                TileData = _tileObject.TileData;
            }
        }

        private int? _selectedRow;
        private int? _selectedColumn;

        public TileObjectControl()
        {
            InitializeComponent();

            listBoxAnimations.DataSource = Animations;
        }

        public void SaveTileObject()
        {
            if (_tileObject != null)
            {
                _tileObject.Animations = listBoxAnimations.DataSource == null ? null :(listBoxAnimations.DataSource as IEnumerable<Animation>).ToArray();
                _tileObject.TileData = TileData;
                _tileObject.Name = textBoxName.Text;
            }
        }

        private void listBoxAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAnimations.SelectedItem is Animation animation && animation.Sprites?.Length > 0)
            {
                Rectangle sprite = Util.XnaToDrawing.Rectangle(animation.Sprites[0]);

                Image image = new Bitmap(sprite.Width, sprite.Height);

                Graphics g = Graphics.FromImage(image);

                g.DrawImage(
                    animation.SourceTexture,
                    new Rectangle(0, 0, sprite.Width, sprite.Height),
                    sprite,
                    GraphicsUnit.Pixel);

                pictureBox.Width = image.Width;
                pictureBox.Height = image.Height;

                for (int i = 0; i < _tileHeight; i++)
                {
                    for (int j = 0; j < _tileWidth; j++)
                    {
                        Rectangle r = new Rectangle(i * TileScene.TileDimension, j * TileScene.TileDimension, TileScene.TileDimension, TileScene.TileDimension);

                        g.DrawRectangle(Pens.Black, r);
                    }
                }

                _selectedRow = null;
                _selectedColumn = null;

                pictureBox.Image = image;
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            _selectedRow = e.Y / TileScene.TileDimension;
            _selectedColumn = e.X / TileScene.TileDimension;

            if (pictureBox.Image != null)
            {
                Graphics g = Graphics.FromImage(pictureBox.Image);
                
                for (int i = 0; i < _selectedRow.Value; i++)
                {
                    for (int j = 0; j < _tileWidth; j++)
                    {
                        Rectangle r = new Rectangle(i * TileScene.TileDimension, j * TileScene.TileDimension, TileScene.TileDimension, TileScene.TileDimension);

                        g.DrawRectangle(Pens.Black, r);
                    }
                }

                g.DrawRectangle(
                    Pens.White,
                    new Rectangle(
                        _selectedColumn.Value * TileScene.TileDimension,
                        _selectedRow.Value * TileScene.TileDimension,
                        TileScene.TileDimension,
                        TileScene.TileDimension));
            }
        }

        private void comboBoxTileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTileType.SelectedValue is TileType tileType &&
                _selectedRow.HasValue &&
                _selectedColumn.HasValue)
            {
                TileData[_selectedRow.Value][_selectedColumn.Value] = tileType;
            }
        }

        private void listBoxAnimations_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Animation)) is Animation animation)
            {
                if (!Animations.Contains(animation))
                {
                    Animations.Add(animation);

                    _tileObject.TileHeight = Math.Max(
                        _tileObject.TileHeight, animation.Sprites.Max(x => x.Height / TileScene.TileDimension));

                    _tileObject.TileWidth = Math.Max(
                        _tileObject.TileWidth, animation.Sprites.Max(x => x.Width / TileScene.TileDimension));
                }
            }
        }

        private void listBoxAnimations_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Animation)) is Animation animation)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listBoxAnimations_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBoxAnimations.ContextMenu == null)
                {
                    listBoxAnimations.ContextMenu = new ContextMenu();
                    listBoxAnimations.ContextMenu.MenuItems.Add(new MenuItem("Remove", (object s, EventArgs args) =>
                    {
                        if (listBoxAnimations.SelectedItem is Animation animation)
                        {
                            Animations.Remove(animation);
                        }
                    }));
                }

                listBoxAnimations.ContextMenu.Show(listBoxAnimations, new Point(e.X, e.Y));
            }
        }
    }
}
