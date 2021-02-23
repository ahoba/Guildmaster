using Danke.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Animations
{
    public class AnimationRepository<T>
    {
        protected TextureRepository<T> _textureRepository;

        protected Dictionary<Guid, Animation<T>> _animations;

        public AnimationRepository(TextureRepository<T> textureRepository)
        {
            _textureRepository = textureRepository;

            _animations = new Dictionary<Guid, Animation<T>>();
        }

        public bool TryGetAnimation(Guid animationId, out Animation<T> animation)
        {
            if (_animations.ContainsKey(animationId))
            {
                animation = _animations[animationId];

                if (animation.SourceTexture == null)
                {
                    if (_textureRepository.TryGetTexture(animation.SourceTextureId, out T texture))
                    {
                        animation.SourceTexture = texture;
                    }
                    else
                    {
                        return false;
                    }

                    return true;
                }

                return true;
            }

            animation = null;

            return false;
        }
    }
}
