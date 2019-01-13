using System;
using System.Windows;
using System.Windows.Controls;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for HintTextBox.xaml
    /// </summary>
    public partial class HintTextBox : UserControl
    {
        public string ComponentText => TextBox.Text;
        public string FieldName { get; set; }
        public Visibility VisibleLabel { get; set; }
        public InputType InputType { get; set; }
        public TextBoxSize Size { get; set; }
        public bool? VisibleHintText { get; set; }
        public HintTextBox()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += UserControlLoaded;
        }

        private void UserControlLoaded(object sender, RoutedEventArgs e)
        {
            SetTextAlignment();
            UpdateSize();
            VisibleHintText = VisibleHintText == null;
            HintText.Visibility = VisibleHintText.Value ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SetTextAlignment()
        {
            TextBox.HorizontalContentAlignment = InputType == InputType.String
                ? HorizontalAlignment.Left
                : HorizontalAlignment.Right;
            HintText.HorizontalAlignment = InputType == InputType.String
                ? HorizontalAlignment.Left
                : HorizontalAlignment.Right;
        }

        private void UpdateSize()
        {
            if (Size == 0)
            {
                Size = TextBoxSize.Normal;
            }
            this.TextBox.Width = (int) Size;
        }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(ComponentText);
        }
    }

    public enum InputType
    {
        String = 0,
        Integer = 1,
        Double = 2
    }

    public enum TextBoxSize
    {
        Tiny = 50,
        Small = 100,
        Normal = 150,
        Large = 200,
    }
}
