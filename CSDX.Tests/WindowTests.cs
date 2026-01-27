using Vortice.Mathematics;
using Xunit;

namespace CSDX.Tests
{
    public class WindowTests
    {
        [Fact]
        public void Window_DefaultWidth_Is500()
        {
            var window = new Window();
            Assert.Equal(500, window.Width);
        }

        [Fact]
        public void Window_DefaultHeight_Is500()
        {
            var window = new Window();
            Assert.Equal(500, window.Height);
        }

        [Fact]
        public void Window_DefaultLeft_Is10()
        {
            var window = new Window();
            Assert.Equal(10, window.Left);
        }

        [Fact]
        public void Window_DefaultTop_Is10()
        {
            var window = new Window();
            Assert.Equal(10, window.Top);
        }

        [Fact]
        public void Window_DefaultTitle_IsMyRenderer()
        {
            var window = new Window();
            Assert.Equal("My Renderer", window.Title);
        }

        [Fact]
        public void Window_DefaultBackgroundColor_IsDefault()
        {
            var window = new Window();
            Assert.Equal(default(Color4), window.BackgroundColor);
        }

        [Fact]
        public void Window_SetWidth_UpdatesValue()
        {
            var window = new Window();
            window.Width = 800;
            Assert.Equal(800, window.Width);
        }

        [Fact]
        public void Window_SetHeight_UpdatesValue()
        {
            var window = new Window();
            window.Height = 600;
            Assert.Equal(600, window.Height);
        }

        [Fact]
        public void Window_SetLeft_UpdatesValue()
        {
            var window = new Window();
            window.Left = 100;
            Assert.Equal(100, window.Left);
        }

        [Fact]
        public void Window_SetTop_UpdatesValue()
        {
            var window = new Window();
            window.Top = 50;
            Assert.Equal(50, window.Top);
        }

        [Fact]
        public void Window_SetTitle_UpdatesValue()
        {
            var window = new Window();
            window.Title = "Test Window";
            Assert.Equal("Test Window", window.Title);
        }

        [Fact]
        public void Window_SetBackgroundColor_UpdatesValue()
        {
            var window = new Window();
            var color = new Color4(1.0f, 0.5f, 0.25f, 1.0f);
            window.BackgroundColor = color;
            Assert.Equal(color, window.BackgroundColor);
        }

        [Fact]
        public void Window_SetNegativeWidth_AllowsValue()
        {
            var window = new Window();
            window.Width = -100;
            Assert.Equal(-100, window.Width);
        }

        [Fact]
        public void Window_SetZeroWidth_AllowsValue()
        {
            var window = new Window();
            window.Width = 0;
            Assert.Equal(0, window.Width);
        }

        [Fact]
        public void Window_SetEmptyTitle_AllowsValue()
        {
            var window = new Window();
            window.Title = "";
            Assert.Equal("", window.Title);
        }

        [Fact]
        public void Window_SetNullTitle_AllowsValue()
        {
            var window = new Window();
            window.Title = null;
            Assert.Null(window.Title);
        }
    }
}
