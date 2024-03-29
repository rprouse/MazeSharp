﻿using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(800, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        async void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            _game = new Game(new UwpCanvasView(_canvas));
            await _game.AnimationLoop();
        }

        void OnPageUnloaded(object sender, RoutedEventArgs e)
        {
            _game?.Dispose();
            _game = null;
        }
    }
}
