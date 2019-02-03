using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Frontend.Colors;
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
            _height = 700.0;
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

        public void Render(IEnumerable<UIElement> items)
        {

            AddElementsToCanvas(items);
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

            _elements.Add(new Rectangle() { Height = _height, Width = _width, Fill = ColorConstants.Green1 });
            for (var i = 0; i < darkPieces; i++)
            {
                if (i % 2 == 0)
                {
                    _elements.Add(new Rectangle() { Height = darkMargin, Width = _width, Fill = ColorConstants.Green2, Margin = new Thickness(0, darkMargin * i, 0, 0) });
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
            var color = ColorConstants.White;
            var lineThickness = _height <= 500 ? 1 : 2;

            _elements.Add(new Rectangle() { Height = PitchHeight, Width = PitchWidth, StrokeThickness = lineThickness, Stroke = color, Margin = new Thickness(PitchSideMargin, PitchTopMargin, 0, 0) });
            _elements.Add(new Line() { X1 = PitchSideMargin, X2 = PitchWidth + PitchSideMargin, Y1 = _height / 2, Y2 = _height / 2, StrokeThickness = lineThickness, Stroke = color });
            _elements.Add(new Ellipse() { Height = circleDiameter, Width = circleDiameter, StrokeThickness = lineThickness, Stroke = color, Margin = new Thickness(_width / 2 - circleDiameter / 2, _height / 2 - circleDiameter / 2, 0, 0) });
            _elements.Add(new Ellipse() { Height = 5, Width = 5, StrokeThickness = lineThickness, Fill = color, Stroke = color, Margin = new Thickness(_width / 2 - 5.0 / 2, _height / 2 - 5.0 / 2, 0, 0) });
            _elements.Add(new Ellipse() { Height = 5, Width = 5, StrokeThickness = lineThickness, Fill = color, Stroke = color, Margin = new Thickness(_width / 2 - 5.0 / 2, PitchTopMargin + penaltySpot, 0, 0) });
            _elements.Add(new Ellipse() { Height = 5, Width = 5, StrokeThickness = lineThickness, Fill = color, Stroke = color, Margin = new Thickness(_width / 2 - 5.0 / 2, _height - PitchTopMargin - penaltySpot, 0, 0) });
            _elements.Add(new Rectangle() { Height = penaltyAreaHeight, Width = penaltyAreaWidth, StrokeThickness = lineThickness, Stroke = color, Margin = new Thickness(_width * 0.25 + PitchSideMargin / 2, PitchTopMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = penaltyAreaHeight, Width = penaltyAreaWidth, StrokeThickness = lineThickness, Stroke = color, Margin = new Thickness(_width * 0.25 + PitchSideMargin / 2, _height - penaltyAreaHeight - PitchTopMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = goalLineBoxHeight, Width = goalLineBoxWidth, StrokeThickness = lineThickness, Stroke = color, Margin = new Thickness(_width / 2 - goalLineBoxWidth / 2, PitchTopMargin, 0, 0) });
            _elements.Add(new Rectangle() { Height = goalLineBoxHeight, Width = goalLineBoxWidth, StrokeThickness = lineThickness, Stroke = color, Margin = new Thickness(_width / 2 - goalLineBoxWidth / 2, _height - goalLineBoxHeight - PitchTopMargin, 0, 0) });
            _elements.Add(CreateArc(goalLineBoxWidth, penaltyAreaHeight + PitchTopMargin, goalLineBoxWidth, color, lineThickness, SweepDirection.Counterclockwise));
            _elements.Add(CreateArc(goalLineBoxWidth, _height - penaltyAreaHeight - PitchTopMargin, goalLineBoxWidth, color, lineThickness, SweepDirection.Clockwise));

        }

        private Path CreateArc(double width, double height, double boxWidth, Brush color, int lineThickness, SweepDirection direction)
        {
            var streamGeometry = new StreamGeometry();
            using (var gc = streamGeometry.Open())
            {
                gc.BeginFigure(new Point(_width / 2 - width / 2, height), false, false);
                gc.ArcTo(new Point(_width / 2 - width / 2 + boxWidth, height), new Size(100, 100), 0, false, direction, true, false);
            }
            return new Path() { Stroke = color, StrokeThickness = lineThickness, Data = streamGeometry };
        }
    }
}
