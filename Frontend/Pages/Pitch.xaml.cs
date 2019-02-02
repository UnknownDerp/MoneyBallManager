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
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using UserControl = System.Windows.Controls.UserControl;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for Pitch.xaml
    /// </summary>
    public partial class Pitch : UserControl
    {
        private readonly double _height;
        private readonly double _width;
        public double PitchHeight { get; private set; }
        public double PitchWidth { get; private set; }
        public double PitchTopMargin { get; private set; }
        public double PitchSideMargin { get; private set; }

        private readonly List<UIElement> _elements;
        public Pitch()
        {
            InitializeComponent();
            _height = 950.0;
            _width = _height * 0.66;
            _elements = new List<UIElement>();

            DrawPitch();
            DrawLines();
        }

        public void Render()
        {
            ClearCanvas();
            RenderElements();
        }

        public void Render(IEnumerable<IEnumerable<UIElement>> items)
        {
            foreach (var item in items)
            {
                AddElementsToCanvas(item);
            }
            ClearCanvas();
            RenderElements();
        }

        private void ClearCanvas()
        {
            Canvas.Children.Clear();
        }

        public void AddElementToCanvas(UIElement element)
        {
            _elements.Add(element);
        }

        public void AddElementsToCanvas(IEnumerable<UIElement> elements)
        {
            foreach (var element in elements)
            {
                AddElementToCanvas(element);
            }
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

            _elements.Add(new Rectangle() { Height = _height, Width = _width, Fill = Brushes.ForestGreen });
            for (var i = 0; i < darkPieces; i++)
            {
                if (i % 2 == 0)
                {
                    _elements.Add(new Rectangle() { Height = darkMargin, Width = _width, Fill = Brushes.DarkGreen, Margin = new Thickness(0, darkMargin * i, 0, 0) });
                }
            }
        }

        private void DrawLines()
        {
            PitchWidth = _width * 0.93;
            PitchSideMargin = (_width - PitchWidth) / 2;
            PitchHeight = _height * 0.95;
            PitchTopMargin = (_height - PitchHeight) / 2;
            var circleDiameter = PitchWidth * 0.25;
            var penaltyAreaHeight = PitchHeight * 0.16;
            var penaltyAreaWidth = PitchWidth / 2;
            var penaltySpot = PitchHeight * 0.09;
            var goalLineBoxWidth = penaltyAreaWidth * 0.4;
            var goalLineBoxHeight = penaltyAreaHeight / 3;

            _elements.Add(new Rectangle() { Height = PitchHeight, Width = PitchWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(PitchSideMargin, PitchTopMargin, 0, 0) });
            _elements.Add(new Line() { X1 = PitchSideMargin, X2 = PitchWidth + PitchSideMargin, Y1 = _height / 2, Y2 = _height / 2, StrokeThickness = 2, Stroke = Brushes.White });
            _elements.Add(new Ellipse() { Height = circleDiameter, Width = circleDiameter, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - circleDiameter / 2, _height / 2 - circleDiameter / 2, 0, 0) });
            _elements.Add(new Ellipse() { Height = 5, Width = 5, StrokeThickness = 2, Fill = Brushes.White, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - 5.0 / 2, _height / 2 - 5.0 / 2, 0, 0) });
            _elements.Add(new Ellipse() { Height = 5, Width = 5, StrokeThickness = 2, Fill = Brushes.White, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - 5.0 / 2, PitchTopMargin + penaltySpot, 0, 0) });
            _elements.Add(new Ellipse() { Height = 5, Width = 5, StrokeThickness = 2, Fill = Brushes.White, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - 5.0 / 2, _height - PitchTopMargin - penaltySpot, 0, 0) });
            _elements.Add(new Rectangle() { Height = penaltyAreaHeight, Width = penaltyAreaWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width * 0.25 + PitchSideMargin / 2, PitchTopMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = penaltyAreaHeight, Width = penaltyAreaWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width * 0.25 + PitchSideMargin / 2, _height - penaltyAreaHeight - PitchTopMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = goalLineBoxHeight, Width = goalLineBoxWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - goalLineBoxWidth / 2, PitchTopMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = goalLineBoxHeight, Width = goalLineBoxWidth, StrokeThickness = 2, Stroke = Brushes.White, Margin = new Thickness(_width / 2 - goalLineBoxWidth / 2, _height - goalLineBoxHeight - PitchTopMargin, 0, 0) });
        }
    }
}
