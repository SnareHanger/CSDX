using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
