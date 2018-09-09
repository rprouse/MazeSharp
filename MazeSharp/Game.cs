using System;
using SkiaSharp;

namespace MazeSharp
{
    public class Game
    {
        public void OnPaintSurface(SKSurface surface, SKImageInfo info)
        {
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
