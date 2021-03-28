using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Actions;

namespace Tools.Actors
{
    public partial class ActorRepositoryControl : UserControl
    {
        public ActionRepository ActionRepository
        {
            get => actorControl.ActionRepository;
            set => actorControl.ActionRepository = value;
        }

        private ActorRepository _actorRepository;

        public ActorRepository ActorRepository
        {
            get => _actorRepository;
            set
            {
                _actorRepository = value;

                listBoxActors.DataSource = _actorRepository.Actors;
            }
        }

        public ActorRepositoryControl()
        {
            InitializeComponent();
        }

        private void buttonAddActor_Click(object sender, EventArgs e)
        {
            _actorRepository.AddActor(new Actor()
            {
                Name = "New Actor",
                Id = Guid.NewGuid()
            });
        }

        private void listBoxActors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxActors.SelectedItem is Actor actor)
            {
                actorControl.Actor = actor;
            }
            else
            {
                actorControl.Actor = null;
            }
        }
    }
}
