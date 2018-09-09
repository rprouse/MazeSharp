using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;

using MazeSharp;

using SkiaSharp;
using SkiaSharp.Views.UWP;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MazeSharp.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Game _game;

        public MainPage()
        {
            _game = new Game();
            InitializeComponent();
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            _game.OnPaintSurface(e.Surface, e.Info);
        }
    }
}
