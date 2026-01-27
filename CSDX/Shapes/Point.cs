using Vortice.Mathematics;
using Vortice.Direct2D1;
using System;

namespace CSDX.Shapes
{
    internal class Point : ShapeBase
    {
        Ellipse pointGeometry;
        public Point(float x, float y) : base() {
            pointGeometry = new Ellipse(x, y, 1, 1);
        }

        public void Draw(Color4 fillColor) {
            base.Draw(pointGeometry.ellipseGeometry, fillColor);
        }
    }
}
