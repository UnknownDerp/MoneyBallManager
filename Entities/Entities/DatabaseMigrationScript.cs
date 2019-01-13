using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class DatabaseMigrationScript : ISqLiteEntity
    {
        public int? Id { get; set; }
        public string FileName { get; set; }
        public string MigrationDate { get; set; }
    }
}
