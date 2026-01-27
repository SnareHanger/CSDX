using Vortice.Mathematics;
using Xunit;

namespace CSDX.Tests
{
    public class CoreTests
    {
        [Fact]
        public void Core_DefaultFrameRate_Is60()
        {
            var core = new Core();
            Assert.Equal(60, core.FrameRate);
        }

        [Fact]
        public void Core_DefaultFrameCount_IsZero()
        {
            var core = new Core();
            Assert.Equal(0, core.FrameCount);
        }

        [Fact]
        public void Core_Window_IsNotNull()
        {
            var core = new Core();
            Assert.NotNull(core.Window);
        }

        [Fact]
        public void Core_Window_HasDefaultValues()
        {
            var core = new Core();
            Assert.Equal(500, core.Window.Width);
            Assert.Equal(500, core.Window.Height);
            Assert.Equal("My Renderer", core.Window.Title);
        }

        [Fact]
        public void Core_SetFrameRate_UpdatesValue()
        {
            var core = new Core();
            core.FrameRate = 30;
            Assert.Equal(30, core.FrameRate);
        }

        [Fact]
        public void Core_SetWindow_UpdatesValue()
        {
            var core = new Core();
            var newWindow = new Window { Width = 1024, Height = 768 };
            core.Window = newWindow;
            Assert.Equal(1024, core.Window.Width);
            Assert.Equal(768, core.Window.Height);
        }

        [Fact]
        public void Core_SetWindowSize_UpdatesWindowProperties()
        {
            var core = new Core();
            var bgColor = new Color4(0.2f, 0.3f, 0.4f, 1.0f);
            core.SetWindowSize(1920, 1080, bgColor);

            Assert.Equal(1920, core.Window.Width);
            Assert.Equal(1080, core.Window.Height);
            Assert.Equal(bgColor, core.Window.BackgroundColor);
        }

        [Fact]
        public void Core_ImplementsIDisposable()
        {
            var core = new Core();
            Assert.IsAssignableFrom<System.IDisposable>(core);
        }
    }
}
