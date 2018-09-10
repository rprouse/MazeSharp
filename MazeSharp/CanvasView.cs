using System;
using MazeSharp.Algorithms;
using SkiaSharp;

namespace MazeSharp
{
    public abstract class CanvasView : ICanvasView
    {
        Maze _maze;

        public abstract SKSize CanvasSize { get; }
        public abstract bool IgnorePixelScaling { get; set; }
        public abstract double Dpi { get; }

        public abstract event EventHandler<PaintSurfaceEventArgs> PaintSurface;

        public abstract void Invalidate();

        public abstract void Dispose();

        public void Init(Maze maze)
        {
            _maze = maze;
        }

        public void Draw(SKSurface surface, SKImageInfo info)
        {
            // the the canvas and properties
            var canvas = surface.Canvas;

            DrawBackground(surface, info);
            DrawBorder(surface, info);
            DrawCurrentCell(surface, info);
            DrawMaze(surface, info);

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
            canvas.DrawText($"Hello Maze", coord, paint);
        }

        void DrawBackground(SKSurface surface, SKImageInfo info)
        {
            surface.Canvas.Clear(SKColors.White);
        }

        void DrawBorder(SKSurface surface, SKImageInfo info)
        {

        }

        void DrawCurrentCell(SKSurface surface, SKImageInfo info)
        {

        }

        void DrawMaze(SKSurface surface, SKImageInfo info)
        {

        }

        void DrawCell(SKSurface surface, SKImageInfo info)
        {

        }
    }
}
