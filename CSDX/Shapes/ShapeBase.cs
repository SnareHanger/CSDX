using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDX.Shapes
{
    internal class ShapeBase
    {
        internal Factory factory;
        internal RenderTarget renderTarget;

        public ShapeBase() {
            this.factory = CSDXCore.D2DFactory;
            this.renderTarget = CSDXCore.D2DRenderTarget;
        }

        public void Draw(Geometry geometry, Color fillColor) {
            this.renderTarget.FillGeometry(geometry, new SolidColorBrush(this.renderTarget, fillColor));
        }

    }
}
