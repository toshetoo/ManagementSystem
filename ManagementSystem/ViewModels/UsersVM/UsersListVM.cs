using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementSystem.Models;

namespace ManagementSystem.ViewModels.UsersVM
{
    public class UsersListVM:ListVM
    {
        public List<User> Users { get; set; }
    }
}