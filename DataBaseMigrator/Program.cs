using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandQuery.DatabaseContext;
using DataBaseMigrator;

namespace DatabaseMigrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var upgrade = new DbUpgrade();
            upgrade.Run();
        }
    }
}
