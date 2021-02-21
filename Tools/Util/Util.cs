using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Util
{
    public static class DrawingToXna
    {
        public static Microsoft.Xna.Framework.Rectangle Rectangle(System.Drawing.Rectangle src)
        {
            return new Microsoft.Xna.Framework.Rectangle(
                src.X,
                src.Y,
                src.Width,
                src.Height);
        }
    }

    public static class XnaToDrawing
    {
        public static System.Drawing.Rectangle Rectangle(Microsoft.Xna.Framework.Rectangle src)
        {
            return new System.Drawing.Rectangle(
                src.X,
                src.Y,
                src.Width,
                src.Height);
        }
    }
}
