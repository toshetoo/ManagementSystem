using ManagementSystem.Models;
using ManagementSystem.Repositories;
using ManagementSystem.Services.ModelServices;
using ManagementSystem.ViewModels.CountriesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    public class CountriesController : BaseController
    {
        public ActionResult List()
        {
            CountriesListVM model = new CountriesListVM();
            TryUpdateModel(model);

            model.Countries = new CountriesService().GetAll();

            if (!string.IsNullOrEmpty(model.Search))
            {
                model.Countries = model.Countries.Where(c => c.Name.ToLower().Contains(model.Search)).ToList();
            }

            switch (model.SortOrder)
            {
                case "name_asc": model.Countries = model.Countries.OrderBy(c => c.Name).ToList(); break;
                case "name_desc": model.Countries = model.Countries.OrderByDescending(c => c.Name).ToList(); break;                
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            CountriesEditVM model = new CountriesEditVM();
            CountriesService countriesService = new CountriesService();

            Country country;
            if (id.HasValue)
            {
                country = countriesService.GetById(id.Value);
                if (country==null)
                {
                    return RedirectToAction("List");
                }
            }
            else
             country = new Country();

            model.ID = country.ID;
            model.Name = country.Name;
            model.Cities = country.Cities;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit()
        {
            CountriesEditVM model = new CountriesEditVM();
            CountriesService countriesService = new CountriesService();

            TryUpdateModel(model);

            Country country;
            if (model.ID!=0)
            {
                country = countriesService.GetById(model.ID);
                if (country==null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                country = new Country();
            }

            country.ID = model.ID;
            country.Name = model.Name;
            country.Cities = model.Cities;

            countriesService.Save(country);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {

            CountriesService countriesService = new CountriesService();
            if (id.HasValue)
            {
                countriesService.Delete(id.Value);                
            }

            return RedirectToAction("List");

        }
    }
}