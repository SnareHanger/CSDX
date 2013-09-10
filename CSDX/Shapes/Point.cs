using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDX.Shapes
{
    internal class Point : ShapeBase
    {
        Ellipse pointGeometry;
        public Point(float x, float y) : base() {            
            pointGeometry = new Ellipse(x, y, 1, 1);
        }

        public void Draw(Color fillColor) {
            base.Draw(pointGeometry.ellipseGeometry, fillColor);
        }
    }
}
