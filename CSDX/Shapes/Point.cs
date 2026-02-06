using Color = System.Drawing.Color;

namespace CSDX.Shapes
{
    internal class Point : ShapeBase, IShape
    {
        private Ellipse _ellipse;

        public Point(float x, float y) : base() {
            _ellipse = new Ellipse(x, y, 1, 1);
        }

        public void Draw(Color fillColor) {
            _ellipse.Draw(fillColor);
        }
    }
}
