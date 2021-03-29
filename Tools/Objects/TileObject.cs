using Danke.Objects.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Objects
{
    [Serializable]
    public class TileObject : TileObject<Image>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    [Serializable]
    public class TileObjectInstance : TileObjectInstance<Image>
    {
        public TileObjectInstance(TileObject obj, int row, int column)
        {
            Y = row;
            X = column;

            Id = obj.Id;
            Animations = obj.Animations;
            TileWidth = obj.TileWidth;
            TileHeight = obj.TileHeight;
            TileData = obj.TileData;
        }
    }
}
