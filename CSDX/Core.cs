using Vortice.Mathematics;
using Vortice.DXGI;
using Vortice.Direct2D1;
using Vortice.Direct3D11;
using Vortice.Direct3D;
using System;
using System.Diagnostics;
using System.Windows.Forms;

using D3D11Device = Vortice.Direct3D11.ID3D11Device;
using D2D1Factory = Vortice.Direct2D1.ID2D1Factory;

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


        public static ID2D1RenderTarget D2DRenderTarget;
        public static D2D1Factory D2DFactory;
        internal Form form;
        internal IDXGISwapChain swapChain;
        internal D3D11Device device;
        internal ID3D11RenderTargetView renderView;
        internal ID3D11Texture2D backBuffer;
        internal IDXGIFactory1 factory;

        private Stopwatch sw;
        private bool isRunning;

        /// <summary>
        /// Initialization
        /// </summary>
        public virtual void Setup() {
            form = new Form();
            form.Text = Window.Title;
            form.SetBounds(Window.Left, Window.Top, Window.Width, Window.Height);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            sw = new Stopwatch();

            SwapChainDescription desc = new SwapChainDescription()
            {
                BufferCount = 1,
                BufferDescription = new ModeDescription(Window.Width, Window.Height, new Rational(FrameRate, 1), Format.R8G8B8A8_UNorm),
                IsWindowed = true,
                OutputWindow = form.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                BufferUsage = Usage.RenderTargetOutput
            };

            D3D11.CreateDeviceAndSwapChain(
                null,
                DriverType.Hardware,
                DeviceCreationFlags.BgraSupport,
                null,
                desc,
                out device,
                out swapChain);

            D2DFactory = D2D1.CreateFactory<D2D1Factory>(FactoryType.SingleThreaded);

            factory = swapChain.GetParent<IDXGIFactory1>();
            factory.MakeWindowAssociation(form.Handle, WindowAssociationFlags.IgnoreAll);

            backBuffer = swapChain.GetBuffer<ID3D11Texture2D>(0);
            renderView = device.CreateRenderTargetView(backBuffer);

            using (IDXGISurface surface = backBuffer.QueryInterface<IDXGISurface>())
            {
                RenderTargetProperties rtProps = new RenderTargetProperties(
                    RenderTargetType.Default,
                    new Vortice.DCommon.PixelFormat(Format.Unknown, Vortice.DCommon.AlphaMode.Premultiplied),
                    0, 0,
                    RenderTargetUsage.None,
                    FeatureLevel.Default);

                D2DRenderTarget = D2DFactory.CreateDxgiSurfaceRenderTarget(surface, rtProps);
            }
        }

        /// <summary>
        /// Sets the size of the rendering window (should be called in setup before base call)
        /// </summary>
        /// <param name="width">Width of the window</param>
        /// <param name="height">Height of the window</param>
        public void SetWindowSize(int width, int height, Color4 backgroundColor) {

            Window.Width = width;
            Window.Height = height;
            Window.BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Sets up and starts the Render Loop
        /// </summary>
        public void StartDraw() {
            sw.Start();
            isRunning = true;

            form.Show();
            form.FormClosed += (sender, args) => isRunning = false;

            while (isRunning && !form.IsDisposed)
            {
                Application.DoEvents();

                D2DRenderTarget.BeginDraw();
                D2DRenderTarget.Clear(Window.BackgroundColor);
                Draw();

                D2DRenderTarget.EndDraw();
                swapChain.Present(0, PresentFlags.None);
                FrameCount++;
            }

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
        public static void rect(float x, float y, float w, float h, Color4 fillColor) {
            Shapes.Rectangle rectangle = new Shapes.Rectangle(x, y, w, h);
            rectangle.Draw(fillColor);
        }

        public static void roundRect(float x, float y, float w, float h, float xRadius, float yRadius, Color4 fillColor) {
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
        public static void ellipse(float x, float y, float w, float h, Color4 fillColor) {
            Shapes.Ellipse ellipse = new Shapes.Ellipse(x, y, w, h);
            ellipse.Draw(fillColor);
        }

        /// <summary>
        /// Draws a point.  (Faking it by calling ellipse, until I figure out how to do something so utterly simple.)
        /// </summary>
        /// <param name="x">Horizontal value of the point's position</param>
        /// <param name="y">Vertical value of the point's position</param>
        /// <param name="color">Color of the point</param>
        public static void point(float x, float y, Color4 color) {
            ellipse(x, y, 1, 1, color);
        }

        public void Dispose() {
            D2DRenderTarget?.Dispose();
            D2DFactory?.Dispose();
            renderView?.Dispose();
            backBuffer?.Dispose();
            device?.Dispose();
            swapChain?.Dispose();
            factory?.Dispose();
        }
    }
}
