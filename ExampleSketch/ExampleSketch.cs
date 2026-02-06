using CSDX;
using System;
using System.Drawing;

namespace ExampleSketch
{
    /// <summary>
    /// Basic example showing the use of rect and ellipse
    /// </summary>
    public class ExampleSketch : Core
    {
        public override void Setup() {
            SetWindowSize(500, 500, Color.White);
            base.Setup();
        }

        public override void Draw() {
            int count = 0;
            Random rand = new Random();

            for (int j = 0; j < 400; j++) {
                point((float)(rand.NextDouble() * j), (float)(rand.NextDouble() * j),
                      Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));
            }

            for (int i = 0; i < 10; i++) {

                float x = i * 50;
                float y = x;

                if (count % 2 == 0) {
                    roundRect(x, y, i * 10, i * 10, 6, 20, Color.Black);
                } else {
                    rect(x, y, i * 10, i * 10, Color.Blue);
                }
                count++;
            }

            base.Draw();
        }
    }
}
