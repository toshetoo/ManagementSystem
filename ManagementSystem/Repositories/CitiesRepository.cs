using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Repositories
{
    public class CitiesRepository: BaseRepository<City>
    {
        public CitiesRepository() : base() { }
        
        public CitiesRepository(UnitOfWork UnitOfWork) : base(UnitOfWork) { }
    }
}