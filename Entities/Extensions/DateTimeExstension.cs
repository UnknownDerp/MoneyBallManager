using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Extensions
{
    public static class DateTimeExstension
    {
        public static string ToMbmString(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMM yyyy HH:mm");
        }
    }
}
