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
    public class Core : IDisposable
    {
        private Window _window = new Window();
        /// <summary>
        /// Holds properties of the rendering window
        /// </summary>
        public Window Window {
            get { return _window; }
            set { _window = value; }
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
            form = new RenderForm(Window.Title);
            form.SetBounds(Window.Left, Window.Top, Window.Width, Window.Height);
            sw = new Stopwatch();

            timing = new GameTime();

            SwapChainDescription desc = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(Window.Width, Window.Height, new Rational(FrameRate, 1), Format.R8G8B8A8_UNorm),
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

            Window.Width = width;
            Window.Height = height;
            Window.BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Sets up and starts the Render Loop
        /// </summary>
        public void StartDraw() {
            sw.Start();
            RenderLoop.Run(form, () => {
                D2DRenderTarget.BeginDraw();
                D2DRenderTarget.Clear(Window.BackgroundColor);
                Draw();

                D2DRenderTarget.EndDraw();
                swapChain.Present(0, PresentFlags.None);
                FrameCount++;
            });

            Dispose();
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

        public static void roundRect(float x, float y, float w, float h, float xRadius, float yRadius, Color fillColor) {
            Shapes.Rectangle rectangle = new Shapes.Rectangle(x, y, w, h, xRadius, yRadius);
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

        /// <summary>
        /// Draws a point.  (Faking it by calling ellipse, until I figure out how to do something so utterly simple.)
        /// </summary>
        /// <param name="x">Horizontal value of the point's position</param>
        /// <param name="y">Vertical value of the point's position</param>
        /// <param name="color">Color of the point</param>
        public static void point(float x, float y, Color color) {
            ellipse(x, y, 1, 1, color);
        }

        public void Dispose() {
            renderView.Dispose();
            backBuffer.Dispose();
            device.Dispose();
            swapChain.Dispose();
            factory.Dispose();
        }
    }
}
