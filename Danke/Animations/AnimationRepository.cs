using Danke.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Animations
{
    public class AnimationRepository
    {
        private TextureRepository<Texture2D> _textureRepository;
        
        private Dictionary<Guid, Animation<Texture2D>> _animations;

        public AnimationRepository(TextureRepository<Texture2D> textureRepository, IEnumerable<Animation<Texture2D>> data)
        {
            _textureRepository = textureRepository;

            _animations = new Dictionary<Guid, Animation<Texture2D>>();

            foreach (Animation<Texture2D> animation in data)
            {
                _animations[animation.Id] = animation;
            }
        }

        public bool TryGetAnimation(Guid animationId, out Animation<Texture2D> animation)
        {
            if (_animations.ContainsKey(animationId))
            {
                animation = _animations[animationId];

                if (animation.SourceTexture == null)
                {
                    if (_textureRepository.TryGetTexture(animation.SourceTextureId, out Texture2D texture))
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
