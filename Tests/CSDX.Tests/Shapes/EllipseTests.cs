using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSDX.Shapes;
using SharpDX.Direct2D1;

namespace CSDX.Tests.Shapes
{
    [TestClass]
    public class EllipseTests
    {
        [TestMethod]
        public void Constructor_SetsEllipseGeometry()
        {
            var ellipse = new CSDX.Shapes.Ellipse(10, 20, 30, 40);
            Assert.IsNotNull(ellipse.ellipseGeometry);
        }

        [TestMethod]
        public void Draw_DoesNotThrow()
        {
            var ellipse = new Ellipse(10, 20, 30, 40);
            ellipse.Draw(Color.Red);
        }
    }
}