using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementSystem.ViewModels.CountriesVM
{
    public class CountriesEditVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a country name!")]
        [RegularExpression(@"^([A-z]+)$", ErrorMessage = "Name should consist only letters!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The country name should contain between 3 and 50 characters")]
        public string Name { get; set; }


        public List<City> Cities { get; set; }
    }
}