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
            _canvas.Init(_maze);
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
            _canvas.Draw(args.Surface, args.Info);
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
