using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDX.Shapes
{
    internal class ShapeBase : IShape
    {
        internal Factory factory;
        internal RenderTarget renderTarget;

        public ShapeBase() {
            this.factory = Core.D2DFactory;
            this.renderTarget = Core.D2DRenderTarget;
        }

        public void Draw(Geometry geometry, Color fillColor) {
            this.renderTarget.FillGeometry(geometry, new SolidColorBrush(this.renderTarget, fillColor));
        }

    }
}
