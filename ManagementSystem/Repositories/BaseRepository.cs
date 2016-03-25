using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementSystem.Repositories
{
    public abstract class BaseRepository<T> where T:BaseModel, new()
    {

        private readonly DbSet<T> dbSet;
        private readonly ManagementSystemContext context;

        public BaseRepository()
        {
            this.context = new ManagementSystemContext();
            this.dbSet = context.Set<T>();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        private void Insert(T item)
        {
            dbSet.Add(item);
        }

        private void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Save(T item)
        {
            if (item.ID>=0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
        }

        public void Delete(int id)
        {
            dbSet.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}