using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Objects
{
    public partial class ObjectRepositoryControl : UserControl
    {
        public GameObjectRepository _objectRepository;

        public GameObjectRepository ObjectRepository
        {
            get => _objectRepository;
            set
            {
                _objectRepository = value;

                if (_objectRepository != null)
                {
                    listBoxObjects.DataSource = _objectRepository.Objects;
                }
            }
        }

        public ObjectRepositoryControl()
        {
            InitializeComponent();
        }

        private void buttonAddObject_Click(object sender, EventArgs e)
        {
            _objectRepository.AddObject(new TileObject()
            {
                Id = Guid.NewGuid(),
                Animations = new Danke.Animations.Animation<Image>[0],
                Name = "New Object"
            });
        }

        private void listBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem is TileObject obj)
            {
                tileObjectControl.SetTileObject(obj);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            tileObjectControl.SaveTileObject();
        }
    }
}
