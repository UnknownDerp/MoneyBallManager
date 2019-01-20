using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CommandQuery.Logging;
using Entities.Entities;
using Entities.Interfaces;

namespace CommandQuery.DatabaseContext
{
    public class DatabaseCommunicator
    {
        private readonly MbmDbContext _dbContext;

        public DatabaseCommunicator()
        {
            _dbContext = new MbmDbContext();
        }

        public List<T> GetAll<T>() where T : class
        {
            var items = _dbContext.Set<T>().Select(x => x).ToList();
            return items;
        }
        public List<T> GetCollections<T>(Expression<Func<T, T>> predicate) where T : class
        {
            var items = _dbContext.Set<T>().Select(predicate).ToList();
            return items;
        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var item = _dbContext.Set<T>().FirstOrDefault(predicate);
            if (item == null)
            {
                throw new NoEntityFoundException();
            }
            return item;
        }

        //public void Set<T>(Expression<Func<T>> predicate) where T : class
        //{
        //    _dbContext.
        //}

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            Logger.Log($"{entity.GetType()}");
        }

        public void ResetDatabase()
        {
            _dbContext.ClearDb();
        }

    }

    public class NoEntityFoundException : Exception
    {
        public NoEntityFoundException() : base()
        {
            
        }
    }
}
