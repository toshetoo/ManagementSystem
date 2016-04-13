using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementSystem.ViewModels.CitiesVM
{
    public class CitiesEditVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Please enter a city name!")]
        [RegularExpression(@"^([A-z]+)$", ErrorMessage = "Name should consist only letters!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The city name should contain between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage="Please enter a post code!")]
        [RegularExpression(@"^([0-9]+)$", ErrorMessage = "Post code should consist only digits!")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "Post code should contain between 3 and 5 digits")]
        public int PostCode { get; set; }

         [Required(ErrorMessage = "Please select a country!")]
        public int CountryID { get; set; }
    }
}