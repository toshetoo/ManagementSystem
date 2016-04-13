using ManagementSystem.Models;
using ManagementSystem.Repositories;
using ManagementSystem.Services.ModelServices;
using ManagementSystem.ViewModels;
using ManagementSystem.ViewModels.UsersVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    public class UsersController : BaseController
    {
        public ActionResult List()
        {
            UsersListVM model = new UsersListVM();
            TryUpdateModel(model);

            model.Users = new UsersService().GetAll();

            if (!string.IsNullOrEmpty(model.Search))
            {
                model.Users = model.Users.Where(u => u.FirstName.ToLower().Contains(model.Search) || u.LastName.ToLower().Contains(model.Search) || u.Username.ToLower().Contains(model.Search)).ToList();
            }

            switch (model.SortOrder)
            {
                case "username_asc": model.Users = model.Users.OrderBy(u => u.Username).ToList(); break;
                case "username_desc": model.Users = model.Users.OrderByDescending(u => u.Username).ToList(); break;
                case "firstname_asc": model.Users = model.Users.OrderBy(u => u.FirstName).ToList(); break;
                case "firstname_desc": model.Users = model.Users.OrderByDescending(u => u.FirstName).ToList(); break;
                case "lastname_asc": model.Users = model.Users.OrderBy(u => u.LastName).ToList(); break;
                case "lastname_desc": model.Users = model.Users.OrderByDescending(u => u.LastName).ToList(); break;                
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            User user = new User();
            UsersService userService = new UsersService();
            UsersEditVM model = new UsersEditVM();

            if (id.HasValue)
            {
                user = userService.GetById(id.Value);
                if (user==null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                user = new User();
            }

            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Username = user.Username;
            model.Password = user.Password;
            model.CityID = user.CityID;
            model.Email = user.Email;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            UsersEditVM model = new UsersEditVM();
            UsersService usersService = new UsersService();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user;
            if (model.ID==0)
            {
                user = new User();
            }
            else
            {
                user = usersService.GetById(model.ID);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }

            user.ID = model.ID;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Password = model.Password;
            user.Username = model.Username;
            user.CityID = model.CityID;
            user.Email = model.Email;

            usersService.Save(user);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            UsersService usersService = new UsersService();

            if (id.HasValue)
            {
                usersService.Delete(id.Value);
            }            
            return RedirectToAction("List");
        }
    }
}