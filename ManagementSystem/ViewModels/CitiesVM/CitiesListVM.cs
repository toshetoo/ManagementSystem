using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementSystem.Models;

namespace ManagementSystem.ViewModels.CitiesVM
{
    public class CitiesListVM : ListVM
    {
        public List<City> Cities { get; set; }
    }
}