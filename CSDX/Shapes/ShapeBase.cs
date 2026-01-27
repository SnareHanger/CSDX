using Vortice.Mathematics;
using Vortice.Direct2D1;
using System;

namespace CSDX.Shapes
{
    internal class ShapeBase : IShape
    {
        internal ID2D1Factory factory;
        internal ID2D1RenderTarget renderTarget;

        public ShapeBase() {
            this.factory = Core.D2DFactory;
            this.renderTarget = Core.D2DRenderTarget;
        }

        public void Draw(ID2D1Geometry geometry, Color4 fillColor) {
            using (ID2D1SolidColorBrush brush = this.renderTarget.CreateSolidColorBrush(fillColor))
            {
                this.renderTarget.FillGeometry(geometry, brush);
            }
        }
    }
}
