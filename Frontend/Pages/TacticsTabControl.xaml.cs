using System.Windows;
using System.Windows.Controls;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for TacticsTabControl.xaml
    /// </summary>
    public partial class TacticsTabControl : UserControl
    {
        public TacticsTabControl()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Pitch.Render();
        }

        private void Save_ButtonCLick(object sender, RoutedEventArgs e)
        {
            var players = Pitch.GetCurrentFormation();
            if (players.Count == 11)
            {

            }
        }

        private void Tactic_ButtonClick(object sender, RoutedEventArgs e)
        {
            var players = Pitch.GetCurrentFormation();
            Pitch.Render(players);
        }
    }
}
