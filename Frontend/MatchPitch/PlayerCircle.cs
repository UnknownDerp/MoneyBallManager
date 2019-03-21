using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Entities.Enums;
using Frontend.Colors;

namespace Frontend.MatchPitch
{
    public class PlayerCircle
    {
        public Brush Fill { get; set; }

        private readonly Point _position;
        public PlayerPositionLine PlayerPosition { get; }
        public PitchPositionLine PitchPosition { get; }
        public bool IsActive { get; private set; }
        private readonly bool _clickable;

        public PlayerCircle(Point position, PlayerPositionLine playerPosition, PitchPositionLine pitchPosition, bool active = false)
        {
            IsActive = active;
            _position = position;
            _clickable = active;
            PlayerPosition = playerPosition;
            PitchPosition = pitchPosition;
        }

        public Ellipse GetPlayerCircle(double pitchHeight)
        {
            var radius = pitchHeight * 0.03;
            if (PlayerPosition == PlayerPositionLine.Goalkeeper)
            {
                ToggleActive();
                return new Ellipse
                {
                    Width = radius * 2,
                    Height = radius * 2,
                    Fill = ColorConstants.DarkBackground,
                    StrokeThickness = 1.5,
                    Stroke = ColorConstants.Black,
                    Margin = new Thickness(_position.X - radius, _position.Y - radius, 0, 0),

                };
            }

            var playerCircle = new Ellipse
            {
                Width = radius * 2,
                Height = radius * 2,
                Fill = ColorConstants.DarkBackground,
                StrokeThickness = 1.5,
                Stroke = ColorConstants.Black,
                Margin = new Thickness(_position.X - radius, _position.Y - radius, 0, 0),

            };
            playerCircle.MouseUp += OnClick;
            playerCircle.Opacity = GetOpacity();
            playerCircle.Fill = ColorConstants.Background;
            return playerCircle;
        }

        private void ToggleActive()
        {
            IsActive = !IsActive;
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (!_clickable)
            {
                return;
            }

            var playerCircle = sender as Ellipse;
            if (playerCircle != null)
            {
                ToggleActive();
                playerCircle.Opacity = GetOpacity();
            }
        }

        private double GetOpacity()
        {
            return !IsActive ? 1 : 0.5;
        }
    }
}
