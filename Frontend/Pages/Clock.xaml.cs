using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : UserControl
    {
        public Clock()
        {
            InitializeComponent();
            var dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                DateText.Text = DateTime.Now.ToString("dd MMM yyyy");
                TimeText.Text = DateTime.Now.ToString("HH:mm:ss tt");
            }, Dispatcher);
        }

        public void MoveClock(double width)
        {
            var newValue = width - 240;
            if (newValue < 30)
            {
                TimeText.Visibility = Visibility.Hidden;
                DateText.Visibility = Visibility.Hidden;
            }
            if (newValue != TimeText.Margin.Left && newValue > 30)
            {
                if (TimeText.Visibility == Visibility.Hidden)
                {
                    TimeText.Visibility = Visibility.Visible;
                    DateText.Visibility = Visibility.Visible;
                }
                TimeText.Padding = new Thickness(newValue, 0, 10, 0);
                DateText.Padding = new Thickness(newValue, 0, 10, 0);
            }
        }
    }
}
