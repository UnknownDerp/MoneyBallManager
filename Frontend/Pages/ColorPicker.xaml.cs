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
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public string ColorPickedHex { get; private set; }
        public class ColorType
        {
            public Color Color { get; set; }
            public string Name { get; set; }
        }

        public List<ColorType> Colors;

        public ColorPicker()
        {
            InitializeComponent();
            Colors = new List<ColorType> {new ColorType() {Color = Color.FromScRgb(0, 255, 255, 255), Name = "None"}};
            Colors.AddRange(InitilizeColors());
            ComboBox.ItemsSource = Colors;
            ComboBox.SelectedIndex = 0;
            ComboBox.SelectionChanged += ColorPicker_SelectionChanged;
        }
        private void ColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var color = (ColorType)ComboBox.SelectedItem;
            ColorPickedHex = new SolidColorBrush(color.Color).ToString();
            Console.WriteLine(ColorPickedHex);
        }

        private static IEnumerable<ColorType> InitilizeColors()
        {
            var colors = new List<ColorType>
            {
                new ColorType() {Color = Color.FromRgb(150, 0, 0), Name = "Wine Red"},
                new ColorType() {Color = Color.FromRgb(200, 0, 0), Name = "Red"},
                new ColorType() {Color = Color.FromRgb(0, 150, 0), Name = "Green"},
                new ColorType() {Color = Color.FromRgb(240, 240, 240), Name = "White"},
                new ColorType() {Color = Color.FromRgb(30, 30, 30), Name = "Black"},
                new ColorType() {Color = Color.FromRgb(100, 200, 255), Name = "Sky Blue"},
                new ColorType() {Color = Color.FromRgb(0, 0, 100), Name = "Dark Blue"},
                new ColorType() {Color = Color.FromRgb(0, 0, 220), Name = "Blue"},
            };
            return colors.OrderBy(x => x.Name).ToList();
        }

    }
}
