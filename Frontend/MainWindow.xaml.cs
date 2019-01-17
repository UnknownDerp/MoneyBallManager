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
            
            Thread.Sleep(3000);
            //test.Close(TimeSpan.FromSeconds(3));
            SizeToContent = SizeToContent.WidthAndHeight;
            this.Width = 1320;
            this.Height = 768;
        }

        private void MoveElements(double width, double height)
        {
            Clock.MoveClock(width);
            PlayersAndMatchesControl.ListBoxResize(height);
            ClubsTabControl.ListBoxResize(height);
#if DEBUG
            Console.Out.WriteLine($"{width}x {height}y");
#endif
        }
        
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainWindowChangedSize(object sender, SizeChangedEventArgs e)
        {
            MoveElements(this.Width, this.Height);
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            MoveElements(this.Width, this.Height);
        }

        private void MainTabs_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
