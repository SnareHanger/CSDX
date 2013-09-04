using CSDX;
using CSDX.Shapes;
using SharpDX;
using System.Collections.Generic;

namespace ExampleSketch
{
    /// <summary>
    /// Basic example showing the use of rect and ellipse
    /// </summary>
    public class ExampleSketch : CSDXCore
    {
        public override void Setup() {
            SetWindowSize(500, 500, Color.Blue);
            base.Setup();
        }

        public override void Draw() {
            int count = 0;
            for (int i = 0; i < 10; i++) {

                float x = i * 50;
                float y = x;

                if (count % 2 == 0) {
                    rect(x, y, i * 10, i * 10, Color.Black);
                } else {
                    ellipse(x, y, i * 10, i * 10, Color.White);
                }
                count++;
            }

            base.Draw();
        }
    }
}
