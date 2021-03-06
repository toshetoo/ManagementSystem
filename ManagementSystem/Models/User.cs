﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int CityID { get; set; }
        public virtual City City { get; set; }

    }
}