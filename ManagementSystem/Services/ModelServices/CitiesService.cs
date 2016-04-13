using ManagementSystem.Models;
using ManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Services.ModelServices
{
    public class CitiesService : BaseService<City>
    {
        public CitiesService() : base() { }
        public CitiesService(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}