using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class Player : ISqLiteEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Club { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public PositionTypes Position { get; set; }
        public PlayerRoleTypes PlayerRole { get; set; }
    }
}
