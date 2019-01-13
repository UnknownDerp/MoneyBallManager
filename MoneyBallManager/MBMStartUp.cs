using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseMigrator;

namespace MoneyBallManager
{
    public class MbmStartUp
    {
        public void Run()
        {
            var upgrader = new DbUpgrade();
            upgrader.Run();
        }
    }
}
