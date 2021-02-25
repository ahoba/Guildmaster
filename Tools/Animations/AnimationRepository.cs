using Danke.Animations;
using Danke.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Animations
{
    public class AnimationRepository : AnimationRepository<Image>
    {
        public BindingList<Animation> Animations { get; } = new BindingList<Animation>();

        public AnimationRepository() : base()
        {

        }

        public void AddAnimation(Animation animation)
        {
            _animations[animation.Id] = animation;

            Animations.Add(animation);
        }
    }
}