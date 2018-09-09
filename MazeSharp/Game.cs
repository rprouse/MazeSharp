using System;
using SkiaSharp;

namespace MazeSharp
{
    public class Game
    {
        ICanvasView _canvas;

        public Game(ICanvasView canvas)
        {
            _canvas = canvas;
            _canvas.PaintSurface += OnPaintSurface;
        }

        public void OnPaintSurface(object sender, PaintSurfaceEventArgs args)
        {
            var surface = args.Surface;
            var info = args.Info;

            // the the canvas and properties
            var canvas = surface.Canvas;

            // make sure the canvas is blank
            canvas.Clear(SKColors.White);

            // draw some text
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Center,
                TextSize = 24
            };
            var coord = new SKPoint(info.Width / 2, (info.Height + paint.TextSize) / 2);
            canvas.DrawText("Hello SkiaSharp", coord, paint);
        }
    }
}
