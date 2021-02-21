using Danke.Animations;
using Danke.Content;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Animations
{
    public class AnimationRepository : AnimationRepository<Image>
    {
        public AnimationRepository(TextureRepository<Image> textureRepository) : base(textureRepository)
        {

        }

        public void AddAnimation(Animation animation)
        {
            _animations[animation.Id] = animation;
        }
    }
}
