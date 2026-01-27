using CSDX;
using Vortice.Mathematics;
using System;

namespace ExampleSketch
{
    /// <summary>
    /// Basic example showing the use of rect and ellipse
    /// </summary>
    public class ExampleSketch : Core
    {
        private Random rand = new Random();

        public override void Setup() {
            SetWindowSize(500, 500, new Color4(1f, 1f, 1f, 1f)); // White
            base.Setup();
        }

        public override void Draw() {
            int count = 0;

            for (int j = 0; j < 400; j++) {
                point(NextFloat(0, j), NextFloat(0, j), NextColor());
            }

            for (int i = 0; i < 10; i++) {

                float x = i * 50;
                float y = x;

                if (count % 2 == 0) {
                    roundRect(x, y, i * 10, i * 10, 6, 20, new Color4(0f, 0f, 0f, 1f)); // Black
                } else {
                    rect(x, y, i * 10, i * 10, new Color4(0f, 0f, 1f, 1f)); // Blue
                }
                count++;
            }

            base.Draw();
        }

        private float NextFloat(float min, float max) {
            return (float)(rand.NextDouble() * (max - min) + min);
        }

        private Color4 NextColor() {
            return new Color4(
                (float)rand.NextDouble(),
                (float)rand.NextDouble(),
                (float)rand.NextDouble(),
                1f);
        }
    }
}
