using Danke.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Animations
{
    public class AnimationRepository<T>
    {   
        protected Dictionary<Guid, Animation<T>> _animations;

        public AnimationRepository()
        {
            _animations = new Dictionary<Guid, Animation<T>>();
        }

        public bool TryGetAnimation(Guid animationId, out Animation<T> animation)
        {
            if (_animations.ContainsKey(animationId))
            {
                animation = _animations[animationId];

                return true;
            }

            animation = null;

            return false;
        }
    }
}
