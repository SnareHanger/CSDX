using Vortice.DXGI;
using Vortice.Direct2D1;
using Vortice.Direct3D;
using Vortice.Direct3D11;
using Vortice.Mathematics;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using Color = System.Drawing.Color;

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
        public static ID2D1Factory D2DFactory;
        internal Form form;
        internal IDXGISwapChain swapChain;
        internal ID3D11Device device;
        internal ID3D11DeviceContext deviceContext;
        internal IDXGIFactory1 dxgiFactory;

        private Stopwatch sw;
        /// <summary>
        /// Initialization
        /// </summary>
        public virtual void Setup() {
            form = new Form();
            form.Text = Window.Title;
            form.SetBounds(Window.Left, Window.Top, Window.Width, Window.Height);
            sw = new Stopwatch();

            // Create DXGI Factory
            dxgiFactory = DXGI.CreateDXGIFactory1<IDXGIFactory1>();

            // Create D3D11 Device
            D3D11.D3D11CreateDevice(
                null,
                DriverType.Hardware,
                DeviceCreationFlags.BgraSupport,
                null,
                out device,
                out _,
                out deviceContext
            );

            // Create Swap Chain
            var desc = new SwapChainDescription()
            {
                BufferCount = 1,
                BufferDescription = new ModeDescription((uint)Window.Width, (uint)Window.Height, new Rational((uint)FrameRate, 1), Format.R8G8B8A8_UNorm),
                Windowed = true,
                OutputWindow = form.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                BufferUsage = Usage.RenderTargetOutput
            };

            swapChain = dxgiFactory.CreateSwapChain(device, desc);
            dxgiFactory.MakeWindowAssociation(form.Handle, WindowAssociationFlags.IgnoreAll);

            // Create D2D1 Factory
            D2DFactory = D2D1.D2D1CreateFactory<ID2D1Factory>(FactoryType.SingleThreaded);

            // Get backbuffer surface and create D2D render target
            using var backBuffer = swapChain.GetBuffer<ID3D11Texture2D>(0);
            using var surface = backBuffer.QueryInterface<IDXGISurface>();

            D2DRenderTarget = D2DFactory.CreateDxgiSurfaceRenderTarget(
                surface,
                new RenderTargetProperties(new Vortice.DCommon.PixelFormat(Format.Unknown, Vortice.DCommon.AlphaMode.Premultiplied))
            );
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
            form.Show();
            while (form.Created) {
                Application.DoEvents();
                if (!form.Visible) continue;

                D2DRenderTarget.BeginDraw();
                D2DRenderTarget.Clear(ToColor4(Window.BackgroundColor));
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

        internal static Color4 ToColor4(Color c) {
            return new Color4(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
        }

        public void Dispose() {
            D2DRenderTarget?.Dispose();
            D2DFactory?.Dispose();
            deviceContext?.Dispose();
            device?.Dispose();
            swapChain?.Dispose();
            dxgiFactory?.Dispose();
        }
    }
}
