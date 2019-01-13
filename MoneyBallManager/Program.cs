using System;
using CommandQuery.DatabaseContext;
using Entities.Entities;
using Entities.Enums;

namespace MoneyBallManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mgm = new MbmDbContext();

            mgm.ClearDb();
            var p1 = new Player(){Name = "Marco Asensio", Position = PositionTypes.Midfielder, PlayerRole = PlayerRoleTypes.Creative, Height = 182, Club = "Real Madrid", Weight = 76};
            mgm.Players.Add(p1);
            mgm.SaveChanges();
            Console.Read();
        }
    }
}
