using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class Tactic : ISqLiteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Formation { get; set; }
        public string DateCreated { get; set; }
        public virtual List<Position> Positions { get; set; }
    }
}
