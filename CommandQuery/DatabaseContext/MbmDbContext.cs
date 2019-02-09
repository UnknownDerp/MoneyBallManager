using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using Entities.Entities;

namespace CommandQuery.DatabaseContext
{
    public class MbmDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<ManagerProfile> ManagerProfiles { get; set; }
        public DbSet<DatabaseMigrationScript> MigrationScripts { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Log> LogMessages { get; set; }
        public DbSet<Note> Notes { get; set; }

        public MbmDbContext() : base(new SQLiteConnection()
        {

            ConnectionString = new SQLiteConnectionStringBuilder
            {
                DataSource = "C:\\Users\\Goustmachine\\Documents\\Genvägar\\Programming\\MoneyBallManager\\database.db",
                ForeignKeys = true
            }.ConnectionString
        }, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasRequired<Club>(x => x.Club)
                .WithMany(y => y.Players)
                .HasForeignKey<int>(z => z.ClubId);
        }

        public void ClearDb()
        {
            Players.RemoveRange(Players);
            ManagerProfiles.RemoveRange(ManagerProfiles);
            Clubs.RemoveRange(Clubs);
            Clubs.Add(new Club() { Id = 1, Name = "Free Agent", HomeColor = "#00FFFFFF", AwayColor = "#00FFFFFF", ThirdColor = "#00FFFFFF", IsDefault = true });
            SaveChanges();
        }
    }
}
