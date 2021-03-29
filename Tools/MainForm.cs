using Danke.Animations;
using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Actions;
using Tools.Actors;
using Tools.Animations;
using Tools.Content;
using Tools.Factories;
using Tools.Objects;
using Tools.Scenes.Tiles;
using Tools.Serialization;

namespace Tools
{
    public partial class MainForm : Form
    {
        private TextureRepository _textureRepository;

        private AnimationRepository _animationRepository;

        private TileSetRepository _tileSetRepository;

        private TileMapRepository _tileMapRepository;

        private GameObjectRepository _objectRepository;

        private ActorRepository _actorRepository;

        private ActionRepository _actionRepository;

        private readonly object[] _toSerialize;

        private Dictionary<string, IControlFactory> _controlFactories;

        public MainForm()
        {
            InitializeComponent();

            _textureRepository = new TextureRepository();

            _animationRepository = new AnimationRepository();

            _tileSetRepository = new TileSetRepository();

            _tileMapRepository = new TileMapRepository();

            _objectRepository = new GameObjectRepository();

            _actorRepository = new ActorRepository();

            _actionRepository = new ActionRepository();

            _toSerialize = new object[]
            {
                _animationRepository,
                _tileSetRepository,
                _tileMapRepository,
                _objectRepository,
                _actorRepository,
                _actionRepository
            };

            _controlFactories = new Dictionary<string, IControlFactory>();
            _controlFactories[nameof(TextureRepositoryControl)] = new TextureRepositoryControlFactory(_textureRepository);
            _controlFactories[nameof(TileSetRepositoryControl)] = new TileSetRepositoryControlFactory(_tileSetRepository, _textureRepository);
            _controlFactories[nameof(TileMapEditorControl)] = new TileMapEditorControlFactory(_tileSetRepository, _tileMapRepository);
            _controlFactories[nameof(AnimationRepositoryControl)] = new AnimationRepositoryControlFactory(_textureRepository, _animationRepository);
            _controlFactories[nameof(ObjectRepositoryControl)] = new ObjectRepositoryControlFactory(_objectRepository);
            _controlFactories[nameof(ActorRepositoryControl)] = new ActorRepositoryControlFactory(_actorRepository, _actionRepository);
        }

        private void ShowControlOnForm(Control control, string text)
        {
            control.Dock = DockStyle.Fill;

            Form form = new Form()
            {
                Text = text
            };

            form.Controls.Add(control);

            form.Show();
        }

        private void toolStripButtonTextureRepository_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(TextureRepositoryControl)].CreateControl();

            ShowControlOnForm(control, "Textures");
        }

        private void toolStripButtonTileSetRepository_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(TileSetRepositoryControl)].CreateControl();
            
            ShowControlOnForm(control, "Tile Sets");
        }

        private void toolStripButtonMapEditor_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(TileMapEditorControl)].CreateControl();

            ShowControlOnForm(control, "Tile Maps");
        }

        private void toolStripButtonAnimations_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(AnimationRepositoryControl)].CreateControl();

            ShowControlOnForm(control, "Animations");
        }

        private void toolStripButtonObjects_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(ObjectRepositoryControl)].CreateControl();

            ShowControlOnForm(control, "Objects");
        }

        private void toolStripButtonActors_Click(object sender, EventArgs e)
        {
            Control control = _controlFactories[nameof(ActorRepositoryControl)].CreateControl();

            ShowControlOnForm(control, "Actors");
        }

        private void toolStripButtonSerialize_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SerializeTextures(dialog.SelectedPath);

                foreach (object obj in _toSerialize)
                {
                    Serialize(obj, obj.GetType().Name, dialog.SelectedPath);
                }
            }
        }

        private IContractResolver GetContractResolver(object obj)
        {
            Type type = obj.GetType();
            
            if (type == typeof(GameObjectRepository))
            {
                return new NestedObjectIdOnlyContractSerializer(new Type[]
                {
                    typeof(Animation)
                });
            }
            else if (type == typeof(TileMapRepository))
            {
                return new NestedObjectIdOnlyContractSerializer(new Type[]
                {
                    typeof(TileSet),
                    typeof(TileObjectInstance)
                },
                new string[]
                {
                    "X",
                    "Y"
                });
            }
            else if (type == typeof(ActorRepository))
            {
                return new NestedObjectIdOnlyContractSerializer(new Type[]
                {
                    typeof(Animation)
                });
            }

            return new DefaultContractResolver();
        }

        private void SerializeTextures(string filePath)
        {
            Serialize(_textureRepository, nameof(TextureRepository), filePath);

            Directory.CreateDirectory($@"{filePath}/Textures");

            foreach (string textureId in _textureRepository.TextureIds)
            {
                if (_textureRepository.TryGetTexture(textureId, out Image image))
                {
                    image.Save($@"{filePath}/Textures/{textureId}");
                }
            }
        }

        private void Serialize(object obj, string objName, string filepath)
        {
            using (StreamWriter file = File.CreateText($@"{filepath}/{objName}.json"))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = GetContractResolver(obj)
                };

                settings.Converters.Add(new NullableJsonConverter(new Type[]
                {
                    typeof(Bitmap)
                }));

                JsonSerializer serializer = JsonSerializer.Create(settings);

                serializer.Serialize(file, obj);
            }
        }

        private void toolStripButtonDeserialize_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in Directory.GetFiles(folderDialog.SelectedPath, "*.json"))
                {
                    if (Regex.IsMatch(fileName, nameof(TextureRepository)))
                    {
                        RestoreTextureRepository(folderDialog.SelectedPath, fileName);
                    }
                    //else if (Regex.IsMatch(fileName, nameof(TextureRepository)))
                    //{
                    //    RestoreTextureRepository(fileName);
                    //}
                }
            }
        }

        private void RestoreTextureRepository(string folderPath, string fileName)
        {
            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                
                TextureRepository deserialized = (TextureRepository)serializer.Deserialize(file, typeof(TextureRepository));

                _textureRepository.FromDeserialized(deserialized);

                foreach (string textureId in _textureRepository.TextureIds)
                {
                    using (Stream fileStream = new FileStream($@"{folderPath}/Textures/{textureId}", FileMode.Open))
                    {
                        _textureRepository.Textures[textureId] = Image.FromStream(fileStream);
                    }
                }
            }
        }
    }
}
