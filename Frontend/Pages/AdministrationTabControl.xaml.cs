using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CommandQuery.DatabaseContext;
using Entities.Entities;
using Frontend.Dialogs;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class AdministrationTabControl : UserControl
    {
        public List<Club> Clubs { get; }
        public AdministrationTabControl()
        {
            InitializeComponent();
            var communicator = new DatabaseCommunicator();
            Clubs = communicator.GetAll<Club>();
            ClubsComboBox.SelectedValue = communicator.Get<Club>(x => x.IsDefault).Id;
            DataContext = this;
        }

        private void ResetDatabase_buttonClick(object sender, RoutedEventArgs e)
        {
            var confirmDialog = new ConfirmDialog() { Owner = Window.GetWindow(this) };
            confirmDialog.ShowDialog();
            if (confirmDialog.DialogResult != null && confirmDialog.DialogResult == true)
            {
                var dbCommun = new DatabaseCommunicator();
                dbCommun.ResetDatabase();
            }
        }

        private void SetDefaultClub_Event(object sender, RoutedEventArgs e)
        {
            var dbComm = new DatabaseCommunicator();
            var clubs = dbComm.GetAll<Club>();
            foreach (var club in clubs)
            {
                club.IsDefault = false;
            }
            var selectedClub = clubs.First(x => x.Id == (int)ClubsComboBox.SelectedValue);
            selectedClub.IsDefault = true;
            dbComm.SaveChanges();
        }
    }
}
