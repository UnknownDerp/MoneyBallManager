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
    public partial class PlayersAndMatchesControl : UserControl
    {
        private readonly ObservableCollection<Player> _players;

        public PlayersAndMatchesControl()
        {
            InitializeComponent();
            var dbCommunicator = new DatabaseCommunicator();
            _players = new ObservableCollection<Player>(dbCommunicator.GetAll<Player>());
            PlayersListBox.ItemsSource = _players;
            DataContext = this;
        }

        private void AddPlayerButtonClick(object sender, RoutedEventArgs e)
        {
            var addPlayerDialog = new AddPlayerDialog() { Owner = Window.GetWindow(this) };
            var result = addPlayerDialog.ShowDialog();
            if (result.HasValue && result.Value)
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

        private void PlayersListBox_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PlayersListBox.Items.Refresh();
        }

        private void PlayersListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayersListBox.SelectedItem is Player selectedPlayer)
            {
                InformationPanel.Visibility = Visibility.Visible;
                NameLabel.Content = selectedPlayer.Name;
                ClubLabel.Content = selectedPlayer.Club.Name;
                HeightLabel.Content = $"{selectedPlayer.Height} cm";
                WeightLabel.Content = $"{selectedPlayer.Weight} kg";
                PositionLabel.Content = $"{selectedPlayer.PlayerRole.ToString()} {selectedPlayer.Position.ToString()}";
            }
        }

        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                DefaultExt = ".png",
                Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg",
                Multiselect = false,
                Title = "Upload Player Picture"
            };
            var result = fileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var filename = fileDialog.FileName;
            }
        }
    }
}
