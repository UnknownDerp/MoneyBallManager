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
using System.Windows.Shapes;
using Entities.Entities;

namespace Frontend.Dialogs
{
    /// <summary>
    /// Interaction logic for AddClubDialog.xaml
    /// </summary>
    public partial class AddClubDialog : Window
    {
        public Club Club => new Club()
        {
            Name = NameTextBox.ComponentText,
            HomeColor = HomeColorPicker.ColorPickedHex,
            AwayColor = AwayColorPicker.ColorPickedHex,
            ThirdColor = ThirdColorPicker.ColorPickedHex
        };

        public AddClubDialog()
        {
            InitializeComponent();
        }

        private void AddClubClick(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                DialogResult = true;
            }
        }

        private bool IsValid()
        {
            if (NameTextBox.IsNullOrEmpty())
            {
                NameTextBox.HintText.Foreground = Brushes.Red;
                return false;
            }
            return true;
        }
    }
}
