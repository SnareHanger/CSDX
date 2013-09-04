using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDX.Shapes
{
    internal class Rectangle : ShapeBase
    {
        public RectangleGeometry rectGeometry;

        public Rectangle(float x, float y, float w, float h)
            : base() {
            rectGeometry = new RectangleGeometry(factory, new RectangleF(x, y, w, h));
        }

        public void Draw(Color fillColor) {
            base.Draw(rectGeometry, fillColor);
        }
    }
}
