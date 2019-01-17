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

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for ManagerProfilesTab.xaml
    /// </summary>
    public partial class ManagerProfilesTab : UserControl
    {
        private readonly ObservableCollection<ManagerProfile> _managerProfiles;
        public ManagerProfilesTab()
        {
            InitializeComponent();
            var dbCommunicator = new DatabaseCommunicator();
            _managerProfiles = new ObservableCollection<ManagerProfile>(dbCommunicator.GetAll<ManagerProfile>());
            ManagerProfilesListBox.ItemsSource = _managerProfiles;
            DataContext = this;
        }
        
        private void CreateNewManagerProfileClick(object sender, RoutedEventArgs e)
        {
            ShowManagerProfileWindow(null, CreateProfileView);
        }

        private void ShowManagerProfileWindow(ManagerProfile managerProfile, Panel owner)
        {
            owner.Visibility = Visibility.Collapsed;
            ManagerProfileTabControl.Children.Add(new ManagerProfileTabControl(managerProfile, owner));
        }

        private void EditManagerProfileClick(object sender, RoutedEventArgs e)
        {
            var profile = ManagerProfilesListBox.SelectedItem as ManagerProfile; 
            ShowManagerProfileWindow(profile, CreateProfileView);
        }
    }
}
