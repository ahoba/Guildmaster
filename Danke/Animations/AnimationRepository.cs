using Danke.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Animations
{
    [Serializable]
    public class AnimationRepository<T>
    {   
        public Dictionary<Guid, Animation<T>> AnimationsById { get; protected set; }

        public AnimationRepository()
        {
            AnimationsById = new Dictionary<Guid, Animation<T>>();
        }

        public bool TryGetAnimation(Guid animationId, out Animation<T> animation)
        {
            if (AnimationsById.ContainsKey(animationId))
            {
                animation = AnimationsById[animationId];

                return true;
            }

            animation = null;

            return false;
        }
    }
}
