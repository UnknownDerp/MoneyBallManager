using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class Club: ISqLiteEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string HomeColor { get; set; }
        public string AwayColor { get; set; }
        public string ThirdColor { get; set; }
    }
}
