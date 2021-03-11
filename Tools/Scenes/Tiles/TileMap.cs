using Danke.Scenes.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Scenes.Tiles
{
    public class TileMap : Danke.Scenes.Tiles.TileMap<Image>, INotifyPropertyChanged
    {
        private string _name;

        public override string Name 
        { 
            get => _name; 
            set
            {
                _name = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TileMap(int height, int width) : base(height, width)
        {

        }

        public TileMap(int[][] backgroundLayer) : base(backgroundLayer)
        {

        }

        public TileMap(int[][] backgroundLayer, int[][] foregroundLayer) : base(backgroundLayer, foregroundLayer)
        {

        }
    }
}
