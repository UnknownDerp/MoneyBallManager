using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommandQuery.DatabaseContext;

namespace Frontend.Extensions
{
    public static class ObservableCollectionExtension
    {
        public static void AddAndSave<T>(this ObservableCollection<T> collection, T item) where T : class
        {
            var dbCommunicator = new DatabaseCommunicator();
            dbCommunicator.Add(item);
            collection.Add(item);
        }
    }
}
