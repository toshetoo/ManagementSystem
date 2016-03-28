using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementSystem.Models;
using ManagementSystem.Repositories;

namespace ManagementSystem.Services
{
    public static class AuthenticationService
    {
        public static User LoggedUser { get; set; }

        public static void AuthenticateUser(string username, string password)
        {
            LoggedUser = new UsersRepository().GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public static void Logout()
        {
            LoggedUser = null;
        }
    }
}