using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSDX.Shapes;
using SharpDX;
using SharpDX.Direct2D1;

namespace CSDX.Tests.Shapes
{
    [TestClass]
    public class ShapeBaseTests
    {
        [TestMethod]
        public void Draw_WithGeometry_DoesNotThrow()
        {
            var shape = new ShapeBase();
            var ellipse = new EllipseGeometry(shape.factory, new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(0, 0), 1, 1));
            shape.Draw(ellipse, Color.Yellow);
        }
    }
}