using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CommandQuery.DatabaseContext;
using Entities.Entities;
using Frontend.Dialogs;
using Frontend.Extensions;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for PlayersAndMatchesControl.xaml
    /// </summary>
    public partial class PlayersAndMatchesControl : UserControl
    {
        private readonly ObservableCollection<Player> _players;
        public PlayersAndMatchesControl()
        {
            InitializeComponent();
            var dbCommun = new DatabaseCommunicator();
            _players = new ObservableCollection<Player>(dbCommun.GetAll<Player>());
            PlayersListBox.ItemsSource = _players;
            DataContext = this;
        }
        //public void ListBoxResize(double height)
        //{
        //    var newValue = height - 133;
        //    if (newValue > 0)
        //    {
        //        PlayersListBox.Height = newValue;
        //    }
        //}
        private void AddPlayerButtonClick(object sender, RoutedEventArgs e)
        {
            var addPlayerDialog = new AddPlayerDialog() { Owner = Window.GetWindow(this) };
            var result = addPlayerDialog.ShowDialog();
            if (result != null && result == true)
            {
                _players.AddAndSave(addPlayerDialog.Player);
            }
        }

        private void SavePlayersButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void ImportPlayersButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
