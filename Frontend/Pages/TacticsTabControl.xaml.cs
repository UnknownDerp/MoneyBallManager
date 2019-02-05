using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Entities.Enums;
using Frontend.MatchPitch;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for TacticsTabControl.xaml
    /// </summary>
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

            }
        }

        private void Tactic_ButtonClick(object sender, RoutedEventArgs e)
        {
            var players = new[]
            {
                new Position(){PitchPosition = PitchPositionLine.Central, PlayerPosition = PlayerPositionLine.Goalkeeper},
                new Position(){PitchPosition = PitchPositionLine.RightWing, PlayerPosition = PlayerPositionLine.Defender},
                new Position(){PitchPosition = PitchPositionLine.RightCentral, PlayerPosition = PlayerPositionLine.Defender},
                new Position(){PitchPosition = PitchPositionLine.LeftCentral, PlayerPosition = PlayerPositionLine.Defender},
                new Position(){PitchPosition = PitchPositionLine.LeftWing, PlayerPosition = PlayerPositionLine.Defender},
                new Position(){PitchPosition = PitchPositionLine.RightWing, PlayerPosition = PlayerPositionLine.Midfielder},
                new Position(){PitchPosition = PitchPositionLine.RightCentral, PlayerPosition = PlayerPositionLine.Midfielder},
                new Position(){PitchPosition = PitchPositionLine.LeftCentral, PlayerPosition = PlayerPositionLine.Midfielder},
                new Position(){PitchPosition = PitchPositionLine.LeftWing, PlayerPosition = PlayerPositionLine.Midfielder},
                new Position(){PitchPosition = PitchPositionLine.RightCentral, PlayerPosition = PlayerPositionLine.Forward},
                new Position(){PitchPosition = PitchPositionLine.LeftCentral, PlayerPosition = PlayerPositionLine.Forward},
            };
            Pitch.Render(players);
        }
    }
}
