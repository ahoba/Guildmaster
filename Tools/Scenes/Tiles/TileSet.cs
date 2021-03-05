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
    public class TileSet : TileSet<Image>, INotifyPropertyChanged
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

        [JsonIgnore]
        private Image _texture;

        [JsonIgnore]
        public override Image Texture 
        { 
            get => _texture; 
            set
            {
                _texture = value;

                if (_texture != null)
                {
                    int rows = _texture.Height / TileDimension;
                    int columns = _texture.Width / TileDimension;

                    Tiles = new Tile[rows][];

                    for (int i = 0; i < rows; i++)
                    {
                        Tiles[i] = new Tile[columns];

                        for (int j = 0; j < columns; j++)
                        {
                            Tiles[i][j] = new Tile()
                            {
                                EnabledDirections = new bool[4],
                                Rectangle = new Microsoft.Xna.Framework.Rectangle(
                                    j * TileDimension,
                                    i * TileDimension,
                                    TileDimension,
                                    TileDimension)
                            };
                        }
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TileSet(int tileDimension, string textureId, Image texture, int rows, int columns) : base(tileDimension, textureId, texture, rows, columns)
        {

        }
    }
}
