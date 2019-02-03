using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Frontend.Colors;

namespace Frontend.MatchPitch
{
    public class PlayerCircle
    {
        public Brush Fill { get; set; }
        private bool _isActive;
        private readonly Point _position;
        private readonly PlayerPositionLine _playerPosition;
        private readonly PitchPositionLine _pitchPosition;
        private readonly double _radius;

        public PlayerCircle(Point position, PlayerPositionLine playerPosition, PitchPositionLine pitchPosition, double pitchHeight)
        {
            _isActive = false;
            _position = position;
            _playerPosition = playerPosition;
            _pitchPosition = pitchPosition;
            _radius = pitchHeight * 0.03;
        }

        public Ellipse GetPlayerCircle()
        {
            var playerCircle = new Ellipse
            {
                Width = _radius * 2,
                Height = _radius * 2,
                Fill = ColorConstants.DarkBackground,
                StrokeThickness = 1.5,
                Stroke = ColorConstants.Black,
                Margin = new Thickness(_position.X - _radius, _position.Y - _radius, 0, 0)
            };
            if (_playerPosition != PlayerPositionLine.Goalkeeper)
            {
                playerCircle.MouseUp += OnClick;
                playerCircle.Opacity = 0.5;
                playerCircle.Fill = ColorConstants.Background;
            }
            return playerCircle;
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            var playerCircle = sender as Ellipse;
            if (playerCircle != null)
            {
                playerCircle.Opacity = !_isActive ? 1 : 0.5;
                _isActive = !_isActive;
            }
        }
    }
}
