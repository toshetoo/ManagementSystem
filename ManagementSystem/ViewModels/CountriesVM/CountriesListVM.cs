using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementSystem.Models;

namespace ManagementSystem.ViewModels.CountriesVM
{
    public class CountriesListVM:ListVM
    {
        public List<Country> Countries { get; set; }
    }
}