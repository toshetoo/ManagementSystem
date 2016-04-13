using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementSystem.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public ManagementSystemContext Context { get; set; }
        DbContextTransaction transaction = null;

        public UnitOfWork()
        {
            this.Context = new ManagementSystemContext();
            transaction = this.Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction = null;
            }

        }

        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
        }

        public void Dispose()
        {
            Commit();
            Context.Dispose();
        }
    }
}