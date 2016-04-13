using ManagementSystem.Models;
using ManagementSystem.Repositories;
using ManagementSystem.Services.ModelServices;
using ManagementSystem.ViewModels.CitiesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    public class CitiesController : BaseController
    {
        public ActionResult List()
        {
            CitiesListVM model = new CitiesListVM();
            TryUpdateModel(model);

            model.Cities = new CitiesService().GetAll();

            if (!string.IsNullOrEmpty(model.Search))
            {
                model.Cities = model.Cities.Where(c => c.Name.ToLower().Contains(model.Search) || c.PostCode.ToString().Contains(model.Search)).ToList();
            }

            switch (model.SortOrder)
            {
                case "name_asc": model.Cities = model.Cities.OrderBy(c => c.Name).ToList(); break;
                case "name_desc": model.Cities = model.Cities.OrderByDescending(c => c.Name).ToList(); break;
                case "postcode_asc": model.Cities = model.Cities.OrderBy(c => c.PostCode).ToList(); break;
                case "postcode_desc": model.Cities = model.Cities.OrderByDescending(c => c.PostCode).ToList(); break;
            }

            

            return View(model);
        }
        
        public ActionResult Edit(int? id)
        {
            CitiesEditVM model = new CitiesEditVM();
            CitiesService citiesService = new CitiesService();
            City city;

            if (id.HasValue)
            {
                city = citiesService.GetById(id.Value);
                if (city == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
                city = new City();

            model.ID = city.ID;
            model.CountryID = city.CountryID;
            model.Name = city.Name;
            model.PostCode = city.PostCode;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            CitiesEditVM model = new CitiesEditVM();
            CitiesService citiesService = new CitiesService();
            City city;

            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ID==0)
            {
                city = new City();
            }
            else
            {
                city = citiesService.GetById(model.ID);
                if (city == null)
                {
                    return RedirectToAction("List");
                }
            }

            city.ID = model.ID;
            city.CountryID = model.CountryID;
            city.Name = model.Name;
            city.PostCode = model.PostCode;

            citiesService.Save(city);

            return RedirectToAction("List");

        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                new CitiesService().Delete(id.Value);
            }
            return RedirectToAction("List");
        }
    }
}