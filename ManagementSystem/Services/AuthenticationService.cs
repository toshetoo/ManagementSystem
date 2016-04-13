using System.Linq;
using ManagementSystem.Models;
using ManagementSystem.Services.ModelServices;

namespace ManagementSystem.Services
{
    public static class AuthenticationService
    {
        public static User LoggedUser { get; set; }

        public static void AuthenticateUser(string username, string password)
        {
            LoggedUser = new UsersService().GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public static void Logout()
        {
            LoggedUser = null;
        }
    }
}