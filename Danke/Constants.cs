using System;
using System.Collections.Generic;
using System.Text;

namespace Danke
{
    public class Constants
    {
        public const string MoveUp = nameof(MoveUp);
        public const string MoveDown = nameof(MoveDown);
        public const string MoveLeft = nameof(MoveLeft);
        public const string MoveRight = nameof(MoveRight);

        public static readonly string[] DefaultActions =
        {
            MoveUp,
            MoveDown,
            MoveLeft,
            MoveRight
        };
    }
}
