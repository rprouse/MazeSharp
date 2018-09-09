using System;
using SkiaSharp;

namespace MazeSharp
{
    public interface ICanvasView
    {
        /// <summary>
        /// Gets the current canvas size.
        /// </summary>
        /// <remarks>
        /// The canvas size may be different to the view size as a result of the current
        /// device's pixel density.
        /// </remarks>
        SKSize CanvasSize { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the drawing canvas should be resized
        /// on high resolution displays.
        /// </summary>
        /// <remarks>
        /// By default, when false, the canvas is resized to 1 canvas pixel per display pixel.
        /// When true, the canvas is resized to device independent pixels, and then stretched
        /// to fill the view. Although performance is improved and all objects are the same
        /// size on different display densities, blurring and pixelation may occur.
        /// </remarks>
        bool IgnorePixelScaling { get; set; }

        /// <summary>
        /// Gets the current DPI for the canvas.
        /// </summary>
        double Dpi { get; }


        /// <summary>
        /// Occurs when the surface needs to be redrawn.
        /// </summary>
        /// <remarks>
        /// There are two ways to draw on this surface: by overriding the SkiaSharp.Views.UWP.SKXamlCanvas.OnPaintSurface(SkiaSharp.Views.UWP.SKPaintSurfaceEventArgs)
        /// method, or by attaching a handler to the SkiaSharp.Views.UWP.SKXamlCanvas.PaintSurface
        /// event.
        /// </remarks>
        event EventHandler<PaintSurfaceEventArgs> PaintSurface;


        /// <summary>
        /// Invalidates the entire surface of the control and causes the control to be redrawn.
        /// </summary>
        void Invalidate();
    }
}
