using Vortice.Mathematics;
using Vortice.Direct2D1;
using System;
using System.Drawing;

namespace CSDX.Shapes
{
    internal class Rectangle : ShapeBase
    {
        public ID2D1RectangleGeometry rectGeometry;
        public ID2D1RoundedRectangleGeometry roundRectGeometry = null;

        public Rectangle(float x, float y, float w, float h, float xRadius = 0, float yRadius = 0)
            : base() {
            RectangleF rect = new RectangleF(x, y, w, h);
            Vortice.RawRectF vorticeRect = new Vortice.RawRectF(x, y, x + w, y + h);
            rectGeometry = factory.CreateRectangleGeometry(vorticeRect);
            if (xRadius > 0 || yRadius > 0) {
                RoundedRectangle roundedRect = new RoundedRectangle()
                {
                    Rect = vorticeRect,
                    RadiusX = xRadius,
                    RadiusY = yRadius
                };
                roundRectGeometry = factory.CreateRoundedRectangleGeometry(roundedRect);
            }
        }

        public void Draw(Color4 fillColor) {
            if (roundRectGeometry != null) {
                base.Draw(roundRectGeometry, fillColor);
            } else {
                base.Draw(rectGeometry, fillColor);
            }
        }
    }
}
