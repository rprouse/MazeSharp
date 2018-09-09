using System;
using SkiaSharp;
using SkiaSharp.Views.UWP;

namespace MazeSharp.UWP
{
    public class UwpCanvasView : CanvasView
    {
        SKXamlCanvas _canvas;

        public UwpCanvasView(SKXamlCanvas canvas)
        {
            _canvas = canvas;
            _canvas.PaintSurface += OnPaintSurface;
        }

        public override void Dispose()
        {
            _canvas.PaintSurface -= OnPaintSurface;
        }

        public override event EventHandler<PaintSurfaceEventArgs> PaintSurface;

        public override SKSize CanvasSize => _canvas.CanvasSize;

        public override bool IgnorePixelScaling
        {
            get => _canvas.IgnorePixelScaling;
            set => _canvas.IgnorePixelScaling = value;
        }

        public override double Dpi => _canvas.Dpi;

        public override void Invalidate()
        {
            _canvas.Invalidate();
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            PaintSurface?.Invoke(sender, new PaintSurfaceEventArgs(e.Surface, e.Info));
        }
    }
}
