using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Entities.Enums;
using Frontend.MatchPitch;

namespace Frontend.Pages
{
    public partial class TacticsTabControl : UserControl
    {
        public TacticsTabControl()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Pitch.Render();
        }

        private void Save_ButtonCLick(object sender, RoutedEventArgs e)
        {
            var players = Pitch.GetCurrentFormation();
            if (players.Count == 11)
            {
                Pitch.Render(players);
            }
        }

        private void Tactic_ButtonClick(object sender, RoutedEventArgs e)
        {
            var players = new[]
            {
                new Position(){PitchPosition = PitchPositionLine.Central, PlayerPosition = PlayerPositionLine.Goalkeeper},
                new Position(){PitchPosition = PitchPositionLine.RightWing, PlayerPosition = PlayerPositionLine.Defender},
                new Position(){PitchPosition = PitchPositionLine.RightCentralInner, PlayerPosition = PlayerPositionLine.Defender},
                new Position(){PitchPosition = PitchPositionLine.LeftCentralInner, PlayerPosition = PlayerPositionLine.Defender},
                new Position(){PitchPosition = PitchPositionLine.LeftWing, PlayerPosition = PlayerPositionLine.Defender},

                new Position(){PitchPosition = PitchPositionLine.LeftCentralOuter, PlayerPosition = PlayerPositionLine.Midfielder},
                new Position(){PitchPosition = PitchPositionLine.Central, PlayerPosition = PlayerPositionLine.Midfielder},
                new Position(){PitchPosition = PitchPositionLine.RightCentralOuter, PlayerPosition = PlayerPositionLine.Midfielder},

                new Position(){PitchPosition = PitchPositionLine.LeftCentralOuter, PlayerPosition = PlayerPositionLine.Forward},
                new Position(){PitchPosition = PitchPositionLine.Central, PlayerPosition = PlayerPositionLine.Forward},
                new Position(){PitchPosition = PitchPositionLine.RightCentralOuter, PlayerPosition = PlayerPositionLine.Forward},
            };
            Pitch.Render(players);
        }
    }
}
