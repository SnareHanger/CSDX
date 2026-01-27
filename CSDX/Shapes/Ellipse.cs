using Vortice.Mathematics;
using Vortice.Direct2D1;
using System;
using System.Numerics;

namespace CSDX.Shapes
{
    internal class Ellipse : ShapeBase
    {
        public ID2D1EllipseGeometry ellipseGeometry;

        public Ellipse(float x, float y, float xRadius, float yRadius) : base() {
            Vector2 center = new Vector2(x, y);
            Vortice.Direct2D1.Ellipse ellipse = new Vortice.Direct2D1.Ellipse(center, xRadius, yRadius);
            ellipseGeometry = this.factory.CreateEllipseGeometry(ellipse);
        }

        public void Draw(Color4 fillColor) {
            base.Draw(ellipseGeometry, fillColor);
        }
    }
}
