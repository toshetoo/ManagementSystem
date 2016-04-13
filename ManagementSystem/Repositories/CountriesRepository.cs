using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Repositories
{
    public class CountriesRepository: BaseRepository<Country>
    {
         public CountriesRepository() : base() { }

         public CountriesRepository(UnitOfWork UnitOfWork) : base(UnitOfWork) { }
    }
}