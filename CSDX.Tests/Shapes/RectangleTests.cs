using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSDX.Shapes;
using SharpDX;

namespace CSDX.Tests.Shapes
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void Constructor_SetsRectGeometry()
        {
            var rect = new Rectangle(1, 2, 3, 4);
            Assert.IsNotNull(rect.rectGeometry);
            Assert.IsNull(rect.roundRectGeometry);
        }

        [TestMethod]
        public void Constructor_SetsRoundRectGeometry_WhenRadiiProvided()
        {
            var rect = new Rectangle(1, 2, 3, 4, 5, 6);
            Assert.IsNotNull(rect.roundRectGeometry);
        }

        [TestMethod]
        public void Draw_DoesNotThrow()
        {
            var rect = new Rectangle(1, 2, 3, 4);
            rect.Draw(Color.Green);
        }

        [TestMethod]
        public void Draw_Rounded_DoesNotThrow()
        {
            var rect = new Rectangle(1, 2, 3, 4, 5, 6);
            rect.Draw(Color.Blue);
        }
    }
}