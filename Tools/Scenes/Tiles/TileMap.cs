using Danke.Scenes.Tiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Scenes.Tiles
{
    [Serializable]
    public class TileMap : Danke.Scenes.Tiles.TileMap<Image>, INotifyPropertyChanged
    {
        [JsonIgnore]
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

        public void ClearObjects()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    ObjectsLayer.Tiles[i][j] = -1;
                }
            }

            Objects.Clear();
        }
    }
}
