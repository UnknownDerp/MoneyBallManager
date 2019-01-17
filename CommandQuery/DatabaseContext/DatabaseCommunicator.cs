using System.Collections.Generic;
using System.Linq;
using Entities.Entities;

namespace CommandQuery.DatabaseContext
{
    public class DatabaseCommunicator
    {
        private readonly MbmDbContext _dbContext;

        public DatabaseCommunicator()
        {
            _dbContext = new MbmDbContext();
        }

        public List<ManagerProfile> GetManagerProfiles()
        {
            return _dbContext.ManagerProfiles.Select(x => x).ToList();
        }

        public List<Player> GetPlayersList()
        {
            return _dbContext.Players.Select(x => x).ToList();
        }
        public List<Club> GetClubsList()
        {
            return _dbContext.Clubs.Select(x => x).ToList();
        }

        public void ResetDatabase()
        {
            _dbContext.ClearDb();
        }

    }
}
