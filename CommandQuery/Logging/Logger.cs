using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandQuery.DatabaseContext;
using Entities.Entities;
using Entities.Enums;

namespace CommandQuery.Logging
{
    public static class Logger
    {
        public static void Log(string text, LogSeverity severity = LogSeverity.Info)
        {
            var logMessage = new Log()
            {
                Text1 = text,
                Date = CreateDate(),
                Severity = severity
            };
            Add(logMessage);
        }

        public static void Log(string text1, string text2, LogSeverity severity = LogSeverity.Info)
        {
            var logMessage = new Log()
            {
                Text1 = text1,
                Text2 = text2,
                Date = CreateDate(),
                Severity = severity
            };

            Add(logMessage);
        }

        private static string CreateDate()
        {
            return DateTime.Now.ToString("dd MMM yyyy HH:mm");
        }

        private static void Add(Log message)
        {
            var context = new MbmDbContext();
            context.LogMessages.Add(message);
            context.SaveChanges();
        }
    }
}
