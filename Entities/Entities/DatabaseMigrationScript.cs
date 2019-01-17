using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;
using SQLite;

namespace Entities.Entities
{
    public class DatabaseMigrationScript : ISqLiteEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string MigrationDate { get; set; }
    }
}
