using System;
using SkiaSharp;

namespace MazeSharp
{
    public abstract class CanvasView : ICanvasView
    {
        public abstract SKSize CanvasSize { get; }
        public abstract bool IgnorePixelScaling { get; set; }
        public abstract double Dpi { get; }

        public abstract event EventHandler<PaintSurfaceEventArgs> PaintSurface;

        public abstract void Invalidate();

        public abstract void Dispose();
    }
}
