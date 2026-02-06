using System.Drawing;

namespace CSDX
{
    public class Window
    {
        private int _width = 500;
        /// <summary>
        /// Width of the rendering window
        /// </summary>
        public int Width {
            get { return _width; }
            set { _width = value; }
        }

        private int _height = 500;
        /// <summary>
        /// Height of the rendering window
        /// </summary>
        public int Height {
            get { return _height; }
            set { _height = value; }
        }

        private int _left = 10;
        /// <summary>
        ///  distance from left
        /// </summary>
        public int Left {
            get { return _left; }
            set { _left = value; }
        }

        private int _top = 10;
        /// <summary>
        ///  distance from top
        /// </summary>
        public int Top {
            get { return _top; }
            set { _top = value; }
        }

        private string _title = "My Renderer";
        /// <summary>
        /// Title to appear in the title bar
        /// </summary>
        public string Title {
            get { return _title; }
            set {
                _title = value;
            }
        }

        private Color _backgroundColor;
        /// <summary>
        /// Background color of the sketch
        /// </summary>
        public Color BackgroundColor {
            get {
                return _backgroundColor;
            }
            set { _backgroundColor = value; }
        }
    }
}
