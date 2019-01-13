using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Entities.Entities;
using Entities.Enums;

namespace Frontend.Dialogs
{
    /// <summary>
    /// Interaction logic for AddPlayerDialog.xaml
    /// </summary>
    public partial class AddPlayerDialog : Window
    {
        public Player Player => new Player
        {
            Name = NameTextBox.ComponentText,
            Club = string.IsNullOrEmpty(ClubTextBox.ComponentText) ? "Free Agent" : ClubTextBox.ComponentText,
            Height = int.Parse(HeightTextBox.ComponentText),
            Weight = int.Parse(WeightTextBox.ComponentText)
        };

        public AddPlayerDialog()
        {
            InitializeComponent();
            PositionComboBox.ItemsSource = Enum.GetValues(typeof(PositionTypes)).Cast<PositionTypes>();
            RoleComboBox.ItemsSource = Enum.GetValues(typeof(PlayerRoleTypes)).Cast<PlayerRoleTypes>();
        }

        private void AddPlayerClick(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                DialogResult = true;
            }
        }

        private bool IsValid()
        {
            var valid = true;
            if (NameTextBox.IsNullOrEmpty())
            {
                NameTextBox.HintText.Foreground = Brushes.Red;
                valid = false;
            }
            if (HeightTextBox.IsNullOrEmpty())
            {
                HeightTextBox.HintText.Foreground = Brushes.Red;
                valid = false;
            }
            if (WeightTextBox.IsNullOrEmpty())
            {
                WeightTextBox.HintText.Foreground = Brushes.Red;
                valid = false;
            }
            if (PositionComboBox.SelectedItem == null || RoleComboBox.SelectedItem == null)
            {
                valid = false;
            }

            return valid;
        }
    }
}
