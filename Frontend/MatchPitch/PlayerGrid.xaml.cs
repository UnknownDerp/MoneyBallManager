using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        public void Render(List<PlayerCircle> formation)
        {
            var circles = formation.Select(x => x.GetPlayerCircle(Pitch.PitchHeight)).ToList();
            Pitch.Render(circles);
        }


        public List<PlayerCircle> GetCurrentFormation()
        {
            return _playerCircles.Where(x => x.IsActive).ToList();
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
                        _playerCircles.Add(new PlayerCircle(intersection, horizontalLine.PlayerPosition, verticaLine.PitchPosition));
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

            var numOfCentralLines = 5;
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

    public enum PlayerPositionLine
    {
        Goalkeeper = 7,
        Libro = 6,
        Defender = 5,
        DefensiveMidfielder = 4,
        Midfielder = 3,
        OffensiveMidfielder = 2,
        Forward = 1
    }

    public enum PitchPositionLine
    {
        LeftWing = 0,
        LeftCentral = 1,
        Central = 2,
        RightCentral = 3,
        RightWing = 4,
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
