using System;
using SkiaSharp;

namespace MazeSharp
{
    public class PaintSurfaceEventArgs : EventArgs
    {
        public PaintSurfaceEventArgs(SKSurface surface, SKImageInfo info)
        {
            Surface = surface;
            Info = info;
        }

        /// <summary>
        /// Gets the surface that is currently being drawn on.
        /// </summary>
        public SKSurface Surface { get; }

        /// <summary>
        /// Gets the information about the surface that is currently being drawn.
        /// </summary>
        public SKImageInfo Info { get; }
    }
}
