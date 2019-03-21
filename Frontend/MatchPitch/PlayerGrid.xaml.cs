using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Entities.Enums;

namespace Frontend.MatchPitch
{
    /// <summary>
    /// Interaction logic for PlayerGrid.xaml
    /// </summary>
    public partial class PlayerGrid : UserControl
    {
        private readonly List<HorizontalLine> _horizontalLines;
        private readonly List<VerticalLine> _verticaLines;
        private readonly List<PlayerCircle> _playerCircles;
        public PlayerGrid()
        {
            InitializeComponent();
            _horizontalLines = new List<HorizontalLine>();
            _verticaLines = new List<VerticalLine>();
            _playerCircles = new List<PlayerCircle>();

            InitializeVerticalLines();
            InitializeHorizontalLines();
            InitializePlayerCircles();
            Render();
        }

        public void Render()
        {
            var circles = _playerCircles.Select(x => x.GetPlayerCircle(Pitch.PitchHeight)).ToList();
            Pitch.Render(circles);
        }

        public void Render(IEnumerable<Position> formation)
        {
            var circles = GetPlayerCirclesFormation(formation.ToList()).Select(x => x.GetPlayerCircle(Pitch.PitchHeight)).ToList();
            Pitch.Render(circles);
        }

        public List<Position> GetCurrentFormation()
        {
            return _playerCircles
                .Select(x => new Position() { PitchPosition = x.PitchPosition, PlayerPosition = x.PlayerPosition })
                .ToList();
        }

        private IEnumerable<PlayerCircle> GetPlayerCirclesFormation(IList<Position> positions)
        {
            var result = new List<PlayerCircle>();
            foreach (var position in positions)
            {
                //Get all the positions for center, if two use 1 and 3, if three use 0, 2 and 4
                var horizontalLine = _horizontalLines.First(x => position.PlayerPosition == x.PlayerPosition);
                var verticalLine = _verticaLines.First(x => position.PitchPosition == x.PitchPosition);
                var intersection = GetIntersection(horizontalLine, verticalLine);
                result.Add(new PlayerCircle(intersection, position.PlayerPosition, position.PitchPosition));
            }
            return result;
        }

        private void InitializePlayerCircles()
        {
            foreach (var verticaLine in _verticaLines)
            {
                foreach (var horizontalLine in _horizontalLines)
                {
                    var intersection = GetIntersection(horizontalLine, verticaLine);
                    if (ShouldAddPlayerCircle(horizontalLine.PlayerPosition, verticaLine.PitchPosition))
                    {
                        _playerCircles.Add(new PlayerCircle(intersection, horizontalLine.PlayerPosition, verticaLine.PitchPosition, true));
                    }
                }
            }
        }

        private void InitializeVerticalLines()
        {
            var smallWidth = Pitch.PitchWidth / 5;
            var bigWidth = Pitch.PitchWidth - (smallWidth * 2);

            _verticaLines.Add(new VerticalLine()
            {
                X = smallWidth / 2 + Pitch.PitchSideMargin,
                PitchPosition = PitchPositionLine.LeftWing
            });

            const int numOfCentralLines = 5;
            var middleMargin = bigWidth / numOfCentralLines;
            for (var i = 0; i < numOfCentralLines; i++)
            {
                var x = bigWidth / 2 + (middleMargin * i);
                PitchPositionLine line;
                if (i < 2)
                {
                    line = PitchPositionLine.LeftCentral;
                }
                else if (i > 2)
                {
                    line = PitchPositionLine.RightCentral;
                }
                else
                {
                    line = PitchPositionLine.Central;
                }
                _verticaLines.Add(new VerticalLine()
                {
                    X = x,
                    PitchPosition = line
                });
            }

            _verticaLines.Add(new VerticalLine()
            {
                X = Pitch.PitchWidth - smallWidth / 2 + Pitch.PitchSideMargin,
                PitchPosition = PitchPositionLine.RightWing
            });

        }

        private void InitializeHorizontalLines()
        {
            for (var i = 7; i > 0; i--)
            {
                var playerPosition = (PlayerPositionLine)i;
                _horizontalLines.Add(new HorizontalLine()
                {
                    Y = GetPositionLineHeight(playerPosition),
                    PlayerPosition = playerPosition

                });
            }
        }

        private double GetPositionLineHeight(PlayerPositionLine position)
        {
            var bottomLine = Pitch.PitchHeight + Pitch.PitchTopMargin;
            switch (position)
            {
                case PlayerPositionLine.Goalkeeper:
                    return bottomLine * 0.97;
                case PlayerPositionLine.Libro:
                    return bottomLine * 0.88;
                case PlayerPositionLine.Defender:
                    return bottomLine * 0.78;
                case PlayerPositionLine.DefensiveMidfielder:
                    return bottomLine * 0.65;
                case PlayerPositionLine.Midfielder:
                    return bottomLine * 0.5;
                case PlayerPositionLine.OffensiveMidfielder:
                    return bottomLine * 0.35;
                case PlayerPositionLine.Forward:
                    return bottomLine * 0.15;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }
        }

        private static bool ShouldAddPlayerCircle(PlayerPositionLine playerPosition, PitchPositionLine pitchPosition)
        {
            switch (playerPosition)
            {
                case PlayerPositionLine.Goalkeeper:
                case PlayerPositionLine.Libro:
                    return pitchPosition == PitchPositionLine.Central;
                case PlayerPositionLine.Forward:
                    return pitchPosition == PitchPositionLine.Central ||
                           pitchPosition == PitchPositionLine.LeftCentral ||
                           pitchPosition == PitchPositionLine.RightCentral;
            }
            return true;
        }

        private static Point GetIntersection(HorizontalLine horizontal, VerticalLine vertical)
        {
            return new Point(vertical.X, horizontal.Y);
        }
    }

    public class HorizontalLine
    {
        public double Y { get; set; }
        public PlayerPositionLine PlayerPosition { get; set; }
    }

    public class VerticalLine
    {
        public double X { get; set; }
        public PitchPositionLine PitchPosition { get; set; }
    }

    public class Position
    {
        public PitchPositionLine PitchPosition { get; set; }
        public PlayerPositionLine PlayerPosition { get; set; }
    }
}
