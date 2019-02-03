﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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

        public PlayerCircle(Point position, PlayerPositionLine playerPosition, PitchPositionLine pitchPosition)
        {
            IsActive = false;
            _position = position;
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
            playerCircle.Opacity = 0.5;
            playerCircle.Fill = ColorConstants.Background;
            return playerCircle;
        }

        private void ToggleActive()
        {
            IsActive = !IsActive;
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            var playerCircle = sender as Ellipse;
            if (playerCircle != null)
            {
                playerCircle.Opacity = !IsActive ? 1 : 0.5;
                ToggleActive();
            }
        }
    }
}
