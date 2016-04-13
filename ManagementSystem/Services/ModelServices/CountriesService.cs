using ManagementSystem.Models;
using ManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Services.ModelServices
{
    public class CountriesService : BaseService<Country>
    {
         public CountriesService() : base() { }
         public CountriesService(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}