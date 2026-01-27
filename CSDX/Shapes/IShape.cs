using Vortice.Mathematics;
using Vortice.Direct2D1;
using System;

namespace CSDX.Shapes
{
    internal interface IShape
    {
        void Draw(ID2D1Geometry geometry, Color4 fillColor);
    }
}
