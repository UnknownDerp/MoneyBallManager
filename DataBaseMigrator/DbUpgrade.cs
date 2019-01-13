using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandQuery.DatabaseContext;
using Entities.Entities;

namespace DataBaseMigrator
{
    public class DbUpgrade
    {
        private readonly MbmDbContext _dbContext;
        public DbUpgrade()
        {
            _dbContext = new MbmDbContext();
        }
        public void Run()
        {
            RunInitialCreation();
            RunDatabaseMigration();
        }

        private void RunInitialCreation()
        {
            var query = "SELECT name FROM sqlite_master WHERE type='table' AND name='DatabaseMigrationScript';"; //
            var name = _dbContext.Database.SqlQuery<string>(query).FirstOrDefault();
            if (name == null)
            {
                var scripts = GetFiles("InitialScripts").ToList();
                RunUpgrade(scripts, false);
            }
        }

        private void RunDatabaseMigration()
        {
            var scripts = GetFiles("Scripts").ToList();
            RunUpgrade(scripts, true);
        }

        private void AddFileToMigratedList(string script)
        {
            var filename = script.Split('\\')[1];
            var migrationScript = new DatabaseMigrationScript(){FileName = script, MigrationDate = DateTime.Now.ToString("dd MMM yyyy HH:mm") };
            _dbContext.MigrationScripts.Add(migrationScript);
            _dbContext.SaveChanges();
        }

        private void RunUpgrade(List<string> scripts, bool logAsUpgrade)
        {
            foreach (var script in scripts)
            {
                var content = File.ReadAllText(script);
                try
                {
                    //_dbContext.Database.ExecuteSqlCommand(content);
                    if (logAsUpgrade)
                    {
                        AddFileToMigratedList(script);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private static IEnumerable<string> GetFiles(string directory)
        {
            return Directory.GetFiles(@"./../../" + directory);
        }
    }
}
