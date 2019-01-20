using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;
using Entities.Interfaces;
using SQLite;

namespace Entities.Entities
{
    public class Log : ISqLiteEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Date { get; set; }
        public LogSeverity Severity { get; set; }
    }
}
