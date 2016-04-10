using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.ViewModels.AccountsVM
{
    public class AccountRegisterVM
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityID { get; set; }
    }
}