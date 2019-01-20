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
    /// Interaction logic for ClubsTabControl.xaml
    /// </summary>
    public partial class ClubsTabControl : UserControl
    {
        private readonly ObservableCollection<Club> _clubs;
        public ClubsTabControl()
        {
            InitializeComponent();
            var dbCommun = new DatabaseCommunicator();
            _clubs = new ObservableCollection<Club>(dbCommun.GetAll<Club>());
            ClubsListBox.ItemsSource = _clubs;
            DataContext = this;
        }

        //public void ListBoxResize(double height)
        //{
        //    var newValue = height - 133;
        //    if (newValue > 0)
        //    {
        //        ClubsListBox.Height = newValue;
        //    }
        //}

        private void AddClubButtonClick(object sender, RoutedEventArgs e)
        {
            var addClubDialog = new AddClubDialog() { Owner = Window.GetWindow(this) };
            var result = addClubDialog.ShowDialog();
            if (result != null && result == true)
            {
                _clubs.AddAndSave(addClubDialog.Club);
            }
        }

        private void SaveClubsButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ImportClubsButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
