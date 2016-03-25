using ManagementSystem.Models;
using ManagementSystem.Repositories;
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
            model.Cities = new CitiesRepository().GetAll();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            CitiesEditVM model = new CitiesEditVM();
            CitiesRepository repo = new CitiesRepository();
            City city;

            if (id.HasValue)
            {
                city = repo.GetById(id.Value);
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
        public ActionResult Edit()
        {
            CitiesEditVM model = new CitiesEditVM();
            CitiesRepository repo = new CitiesRepository();
            City city;

            TryUpdateModel(model);

            if (model.ID==0)
            {
                city = new City();
            }
            else
            {
                city = repo.GetById(model.ID);
                if (city == null)
                {
                    return RedirectToAction("List");
                }
            }

            city.ID = model.ID;
            city.CountryID = model.CountryID;
            city.Name = model.Name;
            city.PostCode = model.PostCode;

            repo.Save(city);

            return RedirectToAction("List");

        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                new CitiesRepository().Delete(id.Value);
            }
            return RedirectToAction("List");
        }
    }
}