using Entities.Enums;
using Entities.Interfaces;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Entities.Entities
{
    public class Player : ISqLiteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClubId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public PositionTypes Position { get; set; }
        public PlayerRoleTypes PlayerRole { get; set; }
        public virtual Club Club { get; set; }
    }
}
