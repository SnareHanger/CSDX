# CSDX

[![Build and Test](https://github.com/SnareHanger/CSDX/actions/workflows/test.yml/badge.svg)](https://github.com/SnareHanger/CSDX/actions/workflows/test.yml)
[![codecov](https://codecov.io/gh/SnareHanger/CSDX/branch/main/graph/badge.svg)](https://codecov.io/gh/SnareHanger/CSDX)

C#/DirectX based graphics coding framework using [Vortice.Windows](https://github.com/amerkoleci/Vortice.Windows).

The idea behind this project was to create a new graphics coding framework in the same vein as Processing, openFrameworks and Cinder, for C# and .NET programmers or those wanting to learn C# as well as the workings of DirectX.

## Requirements

- Windows 10/11
- .NET 8.0 SDK
- DirectX 11 compatible GPU

## The Current Codebase

### CSDX

This is the main library. Contains calls to Vortice/DirectX functionality and abstracts a lot of the time-consuming and difficult stuff.

`Core` is the main class of the library. Used to create the DX window and contains static calls to other classes in the library.

### ExampleSketch

The ExampleSketch is fairly basic. `Program.cs` creates a reference to the main class where all setup and drawing will be done and then calls `Setup()` and `StartDraw()` to begin the render loop.

`ExampleSketch.cs` inherits from `Core` and overrides the `Setup()` and `Draw()` calls. These two methods will be where most of the work is done and are both required.

## Usage

Currently, I'd suggest copying the ExampleSketch project and replace the code in `Setup()` and `Draw()` in ExampleSketch, but do not forget to make the base calls.

```csharp
public class MySketch : Core
{
    public override void Setup()
    {
        SetWindowSize(800, 600, new Color4(0.1f, 0.1f, 0.1f, 1.0f));
        base.Setup();
    }

    public override void Draw()
    {
        // Draw a red rectangle
        rect(100, 100, 200, 150, new Color4(1.0f, 0.0f, 0.0f, 1.0f));

        // Draw a blue ellipse
        ellipse(400, 300, 100, 80, new Color4(0.0f, 0.0f, 1.0f, 1.0f));
    }
}
```

## Building

```bash
dotnet build
```

## Running Tests

```bash
dotnet test
```

## Future Plans

- Add more shape primitives (lines, polygons, bezier curves)
- Add stroke/outline support for shapes
- Add text rendering
- Add image/texture support
- Create project templates for easy setup
