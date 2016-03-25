using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.ViewModels.CountriesVM
{
    public class CountriesEditVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}