using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Entities.Interfaces
{
    public interface ISqLiteEntity
    {
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }
    }
}
