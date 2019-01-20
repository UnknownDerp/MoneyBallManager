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
    /// Interaction logic for Pitch.xaml
    /// </summary>
    public partial class Pitch : UserControl
    {
        private readonly double _height;
        private readonly double _width;
        private readonly List<UIElement> _elements;
        public Pitch()
        {
            InitializeComponent();
            _height = 950.0;
            _width = _height * 0.66;
            _elements = new List<UIElement>();

            DrawPitch();
            DrawLines();
            RenderElements();
        }

        private void RenderElements()
        {
            foreach (var uiElement in _elements)
            {
                Canvas.Children.Add(uiElement);
            }
        }

        private void DrawPitch()
        {
            const int darkPieces = 20;
            var darkMargin = _height / darkPieces;

            _elements.Add(new Rectangle(){Height = _height, Width = _width, Fill = Brushes.ForestGreen});
            for (var i = 0; i < darkPieces; i++)
            {
                if (i % 2 == 0)
                {
                    _elements.Add(new Rectangle() { Height = darkMargin, Width = _width, Fill = Brushes.DarkGreen, Margin = new Thickness(0, darkMargin * i, 0, 0)});
                }
            }
        }

        private void DrawLines()
        {
            var outlineWidth = _width * 0.93;
            var sideMargin = (_width - outlineWidth) / 2;
            var outlineHeight = _height * 0.95;
            var topMargin = (_height - outlineHeight) / 2;
            var circleDiameter = outlineWidth * 0.25;
            var penaltyAreaHeight = outlineHeight * 0.16;
            var penaltyAreaWidth = outlineWidth / 2;
            var penaltySpot = outlineHeight * 0.09;
            var goalLineBoxWidth = penaltyAreaWidth * 0.4;
            var goalLineBoxHeight = penaltyAreaHeight / 3;

            _elements.Add(new Rectangle() { Height = outlineHeight, Width = outlineWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(sideMargin, topMargin, 0, 0) });
            _elements.Add(new Line(){ X1 = sideMargin, X2 = outlineWidth + sideMargin, Y1 = _height / 2, Y2 = _height / 2, StrokeThickness = 2, Stroke = Brushes.White});
            _elements.Add(new Ellipse(){Height = circleDiameter, Width = circleDiameter, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - circleDiameter / 2, _height / 2 - circleDiameter / 2, 0, 0)});
            _elements.Add(new Ellipse(){Height = 5, Width = 5, StrokeThickness = 2, Fill = Brushes.White, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - 5.0 / 2, _height / 2 - 5.0 / 2, 0, 0) });
            _elements.Add(new Ellipse(){Height = 5, Width = 5, StrokeThickness = 2, Fill = Brushes.White, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - 5.0 / 2, topMargin + penaltySpot, 0, 0) });
            _elements.Add(new Ellipse(){Height = 5, Width = 5, StrokeThickness = 2, Fill = Brushes.White, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - 5.0 / 2, _height - topMargin - penaltySpot, 0, 0) });
            _elements.Add(new Rectangle() { Height = penaltyAreaHeight, Width = penaltyAreaWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width * 0.25 + sideMargin / 2, topMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = penaltyAreaHeight, Width = penaltyAreaWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width * 0.25 + sideMargin / 2, _height - penaltyAreaHeight - topMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = goalLineBoxHeight, Width = goalLineBoxWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - goalLineBoxWidth / 2, topMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = goalLineBoxHeight, Width = goalLineBoxWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - goalLineBoxWidth / 2, _height - goalLineBoxHeight - topMargin, 0, 0) });
        }
    }
}
