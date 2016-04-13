using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementSystem.Repositories
{
    public class BaseRepository<T> where T:BaseModel, new()
    {

        private readonly DbSet<T> dbSet;
        private readonly ManagementSystemContext context;
        protected UnitOfWork unitOfWork;

        public BaseRepository()
        {
            this.context = new ManagementSystemContext();
            this.dbSet = context.Set<T>();
        }

        public BaseRepository(UnitOfWork unitOfWork)
        {
            this.context = new ManagementSystemContext();
            this.dbSet = context.Set<T>();
            this.unitOfWork = unitOfWork;
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
            if (item.ID!=0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            dbSet.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}