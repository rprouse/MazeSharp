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

            _maze = new Maze(32, 32);
            _algorithm = new RecursiveBacktracker(_maze);
            _canvas.Init(_maze, _algorithm);
        }

        public async Task AnimationLoop()
        {
            _stopwatch.Start();
            while(IsActive)
            {
                if (!_algorithm.MazeComplete)
                    _algorithm.Step();

                _canvas.Invalidate();
                await Task.Delay(TimeSpan.FromMilliseconds(1.0));
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
