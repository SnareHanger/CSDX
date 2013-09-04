using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDX.Shapes
{
    internal class Ellipse : ShapeBase
    {
        public EllipseGeometry ellipseGeometry;

        public Ellipse(float x, float y, float xRadius, float yRadius) : base() {
            Vector2 center = new Vector2(x, y);
            ellipseGeometry = new EllipseGeometry(this.factory, new SharpDX.Direct2D1.Ellipse(center, xRadius, yRadius));
        }

        public void Draw(Color fillColor) {
            base.Draw(ellipseGeometry, fillColor);
        }
    }
}
