using System;
using MazeSharp.Algorithms;
using SkiaSharp;

namespace MazeSharp
{
    public abstract class CanvasView : ICanvasView
    {
        Maze _maze;
        IMazeGenerator _algorithm;

        public abstract SKSize CanvasSize { get; }
        public abstract bool IgnorePixelScaling { get; set; }
        public abstract double Dpi { get; }

        public abstract event EventHandler<PaintSurfaceEventArgs> PaintSurface;

        public abstract void Invalidate();

        public abstract void Dispose();

        public void Init(Maze maze, IMazeGenerator algorithm)
        {
            _maze = maze;
            _algorithm = algorithm;
        }

        public void Draw(SKSurface surface, SKImageInfo info)
        {
            // the the canvas and properties
            var canvas = surface.Canvas;

            var cellW = (float)info.Width / _maze.Columns;
            var cellH = (float)info.Height / _maze.Rows;

            DrawBackground(surface.Canvas);
            DrawBorder(surface.Canvas, info);
            if(!_algorithm.MazeComplete)
                DrawCurrentCell(surface.Canvas, _algorithm.CurrentCell, cellW, cellH);
            DrawMaze(surface.Canvas, cellW, cellH);
        }

        void DrawBackground(SKCanvas canvas)
        {
            canvas.Clear(SKColors.White);
        }

        void DrawBorder(SKCanvas canvas, SKImageInfo info)
        {
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 2,
                StrokeCap = SKStrokeCap.Butt
            };
            canvas.DrawLine(0, 0, info.Width, 0, paint);
            canvas.DrawLine(info.Width, 0, info.Width, info.Height, paint);
            canvas.DrawLine(0, 0, 0, info.Height, paint);
            canvas.DrawLine(0, info.Height, info.Width, info.Height, paint);
        }

        void DrawCurrentCell(SKCanvas canvas, Cell cell, float cellW, float cellH)
        {
            var paint = new SKPaint
            {
                Color = SKColors.Red,
                IsAntialias = true,
                Style = SKPaintStyle.Fill
            };
            canvas.DrawRect(cell.X * cellW, cell.Y * cellH, cellW, cellH, paint);
        }

        void DrawMaze(SKCanvas canvas, float cellW, float cellH)
        {
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 1,
                StrokeCap = SKStrokeCap.Butt
            };
            foreach (var cell in _maze.AllCells)
            {
                var x0 = cellW * cell.X;
                var y0 = cellH * cell.Y;
                var x1 = x0 + cellW;
                var y1 = y0 + cellH;
                var east = cell.East;
                if (east != null && !cell.Linked(east))
                    canvas.DrawLine(x1, y0, x1, y1, paint);
                var south = cell.South;
                if (south != null && !cell.Linked(south))
                    canvas.DrawLine(x1, y1, x0, y1, paint);
            }
        }
    }
}
