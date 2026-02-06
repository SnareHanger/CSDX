using Vortice.Direct2D1;
using Color = System.Drawing.Color;

namespace CSDX.Shapes
{
    internal class Rectangle : ShapeBase, IShape
    {
        private System.Drawing.RectangleF _rect;
        private RoundedRectangle? _roundedRect;

        public Rectangle(float x, float y, float w, float h, float xRadius = 0, float yRadius = 0)
            : base() {
            _rect = new System.Drawing.RectangleF(x, y, w, h);
            if (xRadius > 0 || yRadius > 0) {
                _roundedRect = new RoundedRectangle(_rect, xRadius, yRadius);
            }
        }

        public void Draw(Color fillColor) {
            using var brush = renderTarget.CreateSolidColorBrush(Core.ToColor4(fillColor));
            if (_roundedRect.HasValue) {
                renderTarget.FillRoundedRectangle(_roundedRect.Value, brush);
            } else {
                renderTarget.FillRectangle(_rect, brush);
            }
        }
    }
}
