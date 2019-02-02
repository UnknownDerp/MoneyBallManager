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

namespace Frontend.MatchPitch
{
    /// <summary>
    /// Interaction logic for PlayerGrid.xaml
    /// </summary>
    public partial class PlayerGrid : UserControl
    {
        private readonly List<Line> _horizontalLines;
        private readonly List<Line> _verticaLines;
        private readonly List<PlayerCircle> _playerCircles;
        public PlayerGrid()
        {
            InitializeComponent();
            _horizontalLines = new List<Line>();
            _verticaLines = new List<Line>();
            _playerCircles = new List<PlayerCircle>();

            InitializeVerticalLines();
            InitializeHorizontalLines();
            InitializePlayerCircles();
            //Pitch.AddElementToCanvas(new PlayerCircle().GetPlayerCircle(new Thickness(0)));
            //Pitch.AddElementToCanvas(new PlayerCircle().GetPlayerCircle(new Thickness(100)));
            Pitch.Render(new[] { _horizontalLines, _verticaLines });
        }

        private void InitializePlayerCircles()
        {
            foreach (var verticaLine in _verticaLines)
            {
                foreach (var horizontalLine in _horizontalLines)
                {
                    var intersection = GetIntersection(horizontalLine, verticaLine);

                }
            }
        }

        private void InitializeVerticalLines()
        {
            var smallWidth = Pitch.PitchWidth / 5;
            var bigWidth = Pitch.PitchWidth - (smallWidth * 2);
            var height = Pitch.PitchHeight + Pitch.PitchTopMargin;

            _verticaLines.Add(new Line()
            {
                Y1 = Pitch.PitchTopMargin,
                Y2 = height,
                X1 = smallWidth / 2 + Pitch.PitchSideMargin,
                X2 = smallWidth / 2 + Pitch.PitchSideMargin,
                StrokeThickness = 2,
                Stroke = Brushes.Magenta
            });

            var middleMargin = bigWidth / 3;
            for (var i = 0; i < 3; i++)
            {
                var x = bigWidth / 2 + Pitch.PitchSideMargin + (middleMargin * i);
                _verticaLines.Add(new Line()
                {
                    Y1 = Pitch.PitchTopMargin,
                    Y2 = height,
                    X1 = x,
                    X2 = x,
                    StrokeThickness = 2,
                    Stroke = Brushes.Magenta
                });
            }

            _verticaLines.Add(new Line()
            {
                Y1 = Pitch.PitchTopMargin,
                Y2 = height,
                X1 = Pitch.PitchWidth - smallWidth / 2 + Pitch.PitchSideMargin,
                X2 = Pitch.PitchWidth - smallWidth / 2 + Pitch.PitchSideMargin,
                StrokeThickness = 2,
                Stroke = Brushes.Magenta
            });

        }

        private void InitializeHorizontalLines()
        {
            var x1 = Pitch.PitchSideMargin;
            var x2 = Pitch.PitchWidth + Pitch.PitchSideMargin;
            var startingHeight = (Pitch.PitchHeight - Pitch.PitchTopMargin * 1.5) / 6;
            for (var i = 7; i > 0; i--)
            {
                _horizontalLines.Add(new Line() { X1 = x1, X2 = x2, Y1 = startingHeight * i, Y2 = startingHeight * i, StrokeThickness = 2, Stroke = Brushes.Magenta });
            }
        }

        private Point GetIntersection(Line horizontal, Line vertical)
        {
            return new Point(vertical.X1, horizontal.Y1);
        }
    }
}
