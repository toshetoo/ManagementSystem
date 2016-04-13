using ManagementSystem.Models;
using ManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Services.ModelServices
{
    public class UsersService : BaseService<User>
    {
        public UsersService() : base() { }
        public UsersService(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public User GetByGuid(string guid)
        {
            return GetAll().FirstOrDefault(u => u.Password == guid);
        }
    }
}