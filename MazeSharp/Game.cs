using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MazeSharp.Algorithms;
using SkiaSharp;

namespace MazeSharp
{
    public class Game : IDisposable
    {
        ICanvasView _canvas;
        Maze _maze;
        IMazeGenerator _algorithm;
        Stopwatch _stopwatch = new Stopwatch();

        public bool IsActive { get; set; }

        public Game(ICanvasView canvas)
        {
            IsActive = true;
            _canvas = canvas;
            _canvas.PaintSurface += OnPaintSurface;

            _maze = new Maze(128, 128);
            _algorithm = new RecursiveBacktracker(_maze);
        }

        public async Task AnimationLoop()
        {
            _stopwatch.Start();
            while(IsActive)
            {
                _canvas.Invalidate();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
            _stopwatch.Stop();
        }

        void OnPaintSurface(object sender, PaintSurfaceEventArgs args)
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
            canvas.DrawText($"Hello SkiaSharp {_stopwatch.Elapsed.TotalSeconds:0.00} sec", coord, paint);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    IsActive = false;
                    _canvas.PaintSurface -= OnPaintSurface;
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
