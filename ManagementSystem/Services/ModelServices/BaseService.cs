using ManagementSystem.Models;
using ManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Services.ModelServices
{
    public abstract class BaseService<T> where T:BaseModel, new()
    {
        private readonly BaseRepository<T> repo;
        protected UnitOfWork unitOfWork;

        public BaseService()
        {
            this.unitOfWork = new UnitOfWork();
            this.repo = new BaseRepository<T>(this.unitOfWork);
        }
        public BaseService(UnitOfWork unitOfWork)            
        {
            this.unitOfWork = unitOfWork;
            this.repo = new BaseRepository<T>(this.unitOfWork);
        }

        public T GetById(int id)
        {
            return this.repo.GetById(id);
        }

        public List<T> GetAll()
        {
            return this.repo.GetAll();
        }      

        public void Save(T item)
        {
            try
            {
                this.repo.Save(item);
                unitOfWork.Commit();
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
            }
            
        }

        public void Delete(int id)
        {
            try
            {
                this.repo.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
            }
        }
    }
}