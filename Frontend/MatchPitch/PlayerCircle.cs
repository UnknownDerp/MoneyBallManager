using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Frontend.MatchPitch
{
    public class PlayerCircle
    {
        //public double Height { get; set; }
        //public double Width { get; set; }
        //public Brush Fill { get; set; }
        private bool _isActive;

        private readonly Point _position;

        public PlayerCircle(Point position)
        {
            _isActive = false;
            _position = position;
        }

        public Ellipse GetPlayerCircle()
        {
            var playerCircle = new Ellipse() { Width = 50, Height = 50, Fill = Brushes.Brown, StrokeThickness = 2, Stroke = Brushes.Black, Margin = new Thickness(_position.X, _position.Y, 0, 0), Opacity = 0.5 };
            playerCircle.MouseUp += OnClick;
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
