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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for Buttons.xaml
    /// </summary>
    public partial class Buttons : UserControl
    {
        private readonly UserControl _userControl;
        private readonly Panel _owner;
        private readonly Action _onSave;
        private readonly Func<bool> _isValid;
        public bool Result { get; private set; }

        public Buttons(UserControl control, Panel owner, Action onSave, Func<bool> isValid = null, ButtonTypes type = ButtonTypes.Close)
        {
            InitializeComponent();
            Result = false;
            _userControl = control;
            _owner = owner;
            _onSave = onSave;
            _isValid = isValid;
            SetupButtons(type);
        }

        private void SetupButtons(ButtonTypes type)
        {
            if (type == ButtonTypes.Close)
            {
                CancelButton.Visibility = Visibility.Collapsed;
            }
            else if (type == ButtonTypes.Cancel)
            {
                CloseButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                CancelButton.Visibility = Visibility.Collapsed;
                CloseButton.Visibility = Visibility.Collapsed;
            }
        }

        private bool ShouldSave()
        {
            return _isValid == null || _isValid();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (ShouldSave())
            {
                _onSave();
                Result = true;
                Collapse();
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Result = false;
            Collapse();
        }
        private void Collapse()
        {
            _userControl.Visibility = Visibility.Collapsed;
            _owner.Visibility = Visibility.Visible;
        }
    }

    public enum ButtonTypes
    {
        Close = 0,
        Cancel = 1,
        Save = 2
    }
}
