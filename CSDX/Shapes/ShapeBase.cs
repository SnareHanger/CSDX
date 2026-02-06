using Vortice.Direct2D1;

namespace CSDX.Shapes
{
    internal class ShapeBase
    {
        internal ID2D1Factory factory;
        internal ID2D1RenderTarget renderTarget;

        public ShapeBase() {
            this.factory = Core.D2DFactory;
            this.renderTarget = Core.D2DRenderTarget;
        }
    }
}
