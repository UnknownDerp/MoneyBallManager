using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;
using SQLite;

namespace Entities.Entities
{
    public class ManagerProfile : ISqLiteEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Created { get; set; }
    }
}
