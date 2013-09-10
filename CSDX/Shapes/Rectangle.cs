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
        public RoundedRectangleGeometry roundRectGeometry = null;

        public Rectangle(float x, float y, float w, float h, float xRadius = 0, float yRadius = 0)
            : base() {
            RectangleF rect =  new RectangleF(x, y, w, h);
            rectGeometry = new RectangleGeometry(factory, rect);
            if (xRadius > 0 || yRadius > 0) {
                roundRectGeometry = new RoundedRectangleGeometry(factory, new RoundedRectangle() { Rect = rect, RadiusX = xRadius, RadiusY = yRadius });
            }

        }

        public void Draw(Color fillColor) {
            if (roundRectGeometry != null) {
                base.Draw(roundRectGeometry, fillColor);
            } else {
                base.Draw(rectGeometry, fillColor);
            }
        }
    }
}
