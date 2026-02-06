using Vortice.Direct2D1;
using System.Numerics;
using Color = System.Drawing.Color;

namespace CSDX.Shapes
{
    internal class Ellipse : ShapeBase, IShape
    {
        private Vortice.Direct2D1.Ellipse _ellipse;

        public Ellipse(float x, float y, float xRadius, float yRadius) : base() {
            _ellipse = new Vortice.Direct2D1.Ellipse(new Vector2(x, y), xRadius, yRadius);
        }

        public void Draw(Color fillColor) {
            using var brush = renderTarget.CreateSolidColorBrush(Core.ToColor4(fillColor));
            renderTarget.FillEllipse(_ellipse, brush);
        }
    }
}
