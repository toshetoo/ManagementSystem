﻿using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Repositories
{
    public class UsersRepository:BaseRepository<User>
    {
        public UsersRepository() : base() { }

        public UsersRepository(UnitOfWork UnitOfWork) : base(UnitOfWork) { }

        public User GetByGuid(string guid)
        {
            return GetAll().FirstOrDefault(u => u.Password == guid);
        }


    }
}