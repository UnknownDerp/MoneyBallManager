using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class Note : ISqLiteEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string DateEdited { get; set; }
    }
}
