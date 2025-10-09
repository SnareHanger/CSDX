using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSDX.Shapes;
using SharpDX;

namespace CSDX.Tests.Shapes
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void Constructor_CreatesPoint()
        {
            var point = new Point(5, 15);
            Assert.IsNotNull(point);
        }

        [TestMethod]
        public void Draw_DoesNotThrow()
        {
            var point = new Point(5, 15);
            point.Draw(Color.Blue);
        }
    }
}