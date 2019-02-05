using Entities.Enums;

namespace Entities.Entities
{
    public class Position
    {
        public PlayerPositionLine PlayerPosition { get; set; }
        public PitchPositionLine PitchPosition { get; set; }
        public virtual Tactic Tactic { get; set; }
    }
}
