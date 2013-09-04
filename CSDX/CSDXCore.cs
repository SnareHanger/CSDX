using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;
using SharpDX.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Device1 = SharpDX.Direct3D11.Device;
using System.Diagnostics;
using SharpDX.Toolkit;

using Shapes = CSDX.Shapes;

namespace CSDX
{
    /// <summary>
    /// Core class for CSDX
    /// </summary>
    public class CSDXCore
    {
        private int _windowWidth = 500;
        /// <summary>
        /// Width of the rendering window
        /// </summary>
        public int WindowWidth {
            get { return _windowWidth; }
            private set { _windowWidth = value; }
        }

        private int _windowHeight = 500;
        /// <summary>
        /// Height of the rendering window
        /// </summary>
        public int WindowHeight {
            get { return _windowHeight; }
            private set { _windowHeight = value; }
        }

        private int _windowLeft = 10;
        /// <summary>
        /// Window distance from left
        /// </summary>
        public int WindowLeft {
            get { return _windowLeft; }
            private set { _windowLeft = value; }
        }

        private int _windowTop = 10;
        /// <summary>
        /// Window distance from top
        /// </summary>
        public int WindowTop {
            get { return _windowTop; }
            private set { _windowTop = value; }
        }

        private string _windowTitle = "My Renderer";
        /// <summary>
        /// Title to appear in the title bar
        /// </summary>
        public string WindowTitle {
            get { return _windowTitle; }
            private set {
                _windowTitle = value;
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

        private int _frameCount;
        /// <summary>
        /// Current frame count
        /// </summary>
        public int FrameCount {
            get { return _frameCount; }
            private set { _frameCount = value; }
        }


        private int _frameRate = 60;

        public int FrameRate {
            get { return _frameRate; }
            set { _frameRate = value; }
        }


        public static RenderTarget D2DRenderTarget;
        public static SharpDX.Direct2D1.Factory D2DFactory;
        internal RenderForm form;
        internal SwapChain swapChain;
        internal Device1 device;
        internal RenderTargetView renderView;
        internal Texture2D backBuffer;
        internal SharpDX.DXGI.Factory factory;
        internal GameTime timing;

        private Stopwatch sw;
        /// <summary>
        /// Initialization
        /// </summary>
        public virtual void Setup() {
            form = new RenderForm(WindowTitle);
            form.SetBounds(WindowLeft, WindowTop, WindowWidth, WindowHeight);
            sw = new Stopwatch();

            timing = new GameTime();

            SwapChainDescription desc = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(WindowWidth, WindowHeight, new Rational(FrameRate, 1), Format.R8G8B8A8_UNorm),
                IsWindowed = true,
                OutputHandle = form.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };


            Device1.CreateWithSwapChain(SharpDX.Direct3D.DriverType.Hardware, DeviceCreationFlags.BgraSupport, desc, out device, out swapChain);

            D2DFactory = new SharpDX.Direct2D1.Factory();

            factory = swapChain.GetParent<SharpDX.DXGI.Factory>();
            factory.MakeWindowAssociation(form.Handle, WindowAssociationFlags.IgnoreAll);

            backBuffer = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
            renderView = new RenderTargetView(device, backBuffer);

            Surface surface = backBuffer.QueryInterface<Surface>();

            D2DRenderTarget = new RenderTarget(D2DFactory, surface, new RenderTargetProperties(new PixelFormat(Format.Unknown, AlphaMode.Premultiplied)));


        }

        /// <summary>
        /// Sets the size of the rendering window (should be called in setup before base call)
        /// </summary>
        /// <param name="width">Width of the window</param>
        /// <param name="height">Height of the window</param>
        public void SetWindowSize(int width, int height, Color backgroundColor) {
            WindowWidth = width;
            WindowHeight = height;
            BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Sets up and starts the Render Loop
        /// </summary>
        public void StartDraw() {
            sw.Start();
            RenderLoop.Run(form, () => {
                D2DRenderTarget.BeginDraw();
                D2DRenderTarget.Clear(BackgroundColor);
                Draw();

                D2DRenderTarget.EndDraw();
                swapChain.Present(0, PresentFlags.None);
                FrameCount++;
            });

            renderView.Dispose();
            backBuffer.Dispose();
            device.Dispose();
            swapChain.Dispose();
            factory.Dispose();
        }

        /// <summary>
        /// Draw method will be filled by the user
        /// </summary>
        public virtual void Draw() {
            //User code goes here
        }

        /// <summary>
        /// Draws a rectangle
        /// </summary>
        /// <param name="x">The leftmost point of the rectangle</param>
        /// <param name="y">The topmost point of the rectangle</param>
        /// <param name="w">The width of the rectangle</param>
        /// <param name="h">The height of the rectangle</param>
        /// <param name="fillColor">Fill color of the rectangle</param>
        public static void rect(float x, float y, float w, float h, Color fillColor) {
            Shapes.Rectangle rectangle = new Shapes.Rectangle(x, y, w, h);
            rectangle.Draw(fillColor);
        }

        /// <summary>
        /// Draws an ellipse
        /// </summary>
        /// <param name="x">The center X coordinate of the ellipse</param>
        /// <param name="y">The center Y coordinate of the ellipse</param>
        /// <param name="w">The width of the ellipse</param>
        /// <param name="h">The height of the ellipse</param>
        /// <param name="fillColor">Fill color of the ellipse</param>
        public static void ellipse(float x, float y, float w, float h, Color fillColor) {
            Shapes.Ellipse ellipse = new Shapes.Ellipse(x, y, w, h);
            ellipse.Draw(fillColor);
        }
    }
}
