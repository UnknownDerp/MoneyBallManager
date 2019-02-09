using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using CommandQuery.DatabaseContext;
using Entities.Entities;
using Frontend.Dialogs;
using Frontend.Pages;
using MediatR;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            //var test = new SplashScreen("Logos/Spashscreen.png");
            //test.Show(false);
            InitializeComponent();

            //Thread.Sleep(3000);
            //test.Close(TimeSpan.FromSeconds(3));
            SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.CanMinimize;
            MoveElements(this.Width, this.Height);
        }

        private void MoveElements(double width, double height)
        {
            Clock.MoveClock(width);
            //PlayersAndMatchesControl.ListBoxResize(height);
            //ClubsTabControl.ListBoxResize(height);
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainTabs_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
