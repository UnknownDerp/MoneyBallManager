using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
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
using Entities.Extensions;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for ManagerProfileTabControl.xaml
    /// </summary>
    public partial class ManagerProfileTabControl : UserControl
    {
        private readonly ManagerProfile _managerProfile;
        public ManagerProfileTabControl(ManagerProfile managerProfile, Panel owner)
        {
            InitializeComponent();

            Init(managerProfile);
            CreateButtons(owner);
        }

        private void CreateButtons(Panel owner)
        {
            ButtonsWrapPanel.Children.Add(new Buttons(this, owner, Save, IsValid, ButtonTypes.Cancel));
        }

        private void Init(ManagerProfile managerProfile)
        {
            if (managerProfile == null)
            {
                managerProfile = new ManagerProfile();
            }

            SetManagerProfileValues(managerProfile);
        }

        private void Save()
        {
            var mbm = new MbmDbContext();
            var managerProfile = new ManagerProfile()
            {
                Name = ProfileNameTextBox.Text,
                Created = DateTime.Now.ToMbmString()
            };

            mbm.ManagerProfiles.Add(managerProfile);
            mbm.SaveChanges();
        }

        private bool IsValid()
        {
            return !string.IsNullOrEmpty(ProfileNameTextBox.Text);
        }

        private void SetManagerProfileValues(ManagerProfile managerProfile)
        {
            ProfileNameTextBox.Text = managerProfile.Name;
        }
    }
}
