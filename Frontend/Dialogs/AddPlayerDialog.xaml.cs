using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using CommandQuery.DatabaseContext;
using Entities.Entities;
using Entities.Enums;
using Frontend.Colors;

namespace Frontend.Dialogs
{
    /// <summary>
    /// Interaction logic for AddPlayerDialog.xaml
    /// </summary>
    public partial class AddPlayerDialog : Window
    {
        public List<Club> Clubs { get; }

        public Player Player
        {
            get
            {
                var club = new DatabaseCommunicator().Get<Club>(x => x.Id == (int)ClubsComboBox.SelectedValue);
                return new Player()
                {
                    Name = NameTextBox.ComponentText,
                    ClubId = club.Id,
                    Height = int.Parse(HeightTextBox.ComponentText),
                    Weight = int.Parse(WeightTextBox.ComponentText),
                    PlayerRole = (PlayerRoleTypes)RoleComboBox.SelectedItem,
                    Position = (PositionTypes) PositionComboBox.SelectedItem,
                };
            }
        }

        public AddPlayerDialog()
        {
            InitializeComponent();
            var communicator = new DatabaseCommunicator();
            PositionComboBox.ItemsSource = Enum.GetValues(typeof(PositionTypes)).Cast<PositionTypes>();
            RoleComboBox.ItemsSource = Enum.GetValues(typeof(PlayerRoleTypes)).Cast<PlayerRoleTypes>();
            DataContext = this;
            Clubs = communicator.GetAll<Club>();
            ClubsComboBox.SelectedValue = communicator.Get<Club>(x => x.IsDefault).Id;
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
                NameTextBox.HintText.Foreground = ColorConstants.WarningRed;
                valid = false;
            }
            if (HeightTextBox.IsNullOrEmpty())
            {
                HeightTextBox.HintText.Foreground = ColorConstants.WarningRed;
                valid = false;
            }
            if (WeightTextBox.IsNullOrEmpty())
            {
                WeightTextBox.HintText.Foreground = ColorConstants.WarningRed;
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
