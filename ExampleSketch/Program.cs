using System;

namespace ExampleSketch
{
    class Program
    {
        [STAThread]
        private static void Main() {
            ExampleSketch sketch = new ExampleSketch();
            sketch.Setup();
            sketch.StartDraw();
        }
    }
}
