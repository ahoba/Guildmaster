using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Animations;
using Tools.Content;

namespace Tools.Factories
{
    public class AnimationRepositoryControlFactory : AbstractControlFactory<ControlFactoryArgs>
    {
        private TextureRepository _textureRepository;

        private AnimationRepository _animationRepository;

        public AnimationRepositoryControlFactory(
            TextureRepository textureRepository,
            AnimationRepository animationRepository)
        {
            _textureRepository = textureRepository;

            _animationRepository = animationRepository;
        }

        public override Control CreateControl(ControlFactoryArgs args)
        {
            return new AnimationRepositoryControl()
            {
                TextureRepository = _textureRepository,
                AnimationRepository = _animationRepository
            };
        }
    }
}
