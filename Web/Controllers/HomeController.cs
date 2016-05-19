using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNet.Identity;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IUOW _uow;


        public HomeController(IUOW uow)
        {
            _uow = uow;
        }

        public ActionResult Index()
        {
            var vm = new HomeIndexViewModel()
            {
                
            Article = _uow.Articles.FindArticleByName("HomeIndex")
            };

            int userInt = User.Identity.GetUserId<int>();
            List<Person> persons;
            persons = _uow.Persons.GetAllForUser(userInt);
            if (persons.Count < 1 && userInt != 0)
            {
                return RedirectToAction("Create", "Persons");
            }

            return View(vm);

        }

        public ActionResult IndexAuth(bool auth)
        {
            var vm = new HomeIndexViewModel();
            vm.Article = _uow.Articles.FindArticleByName("HomeIndex");
            if (auth == true)
            {
                {
                    vm.PersonsList = _uow.Persons.GetAllForUser(User.Identity.GetUserId<int>());
                    if (vm.PersonsList.Count < 1)
                    {
                        return RedirectToAction("Create", "Persons");
                    }

                }

                

            }
            return View("index");

            //public ActionResult About()
            //{
            //    ViewBag.Message = "Your application description page.";

            //    return View();
            //}

            //public ActionResult Contact()
            //{
            //    ViewBag.Message = "Your contact page.";

            //    return View();
            //}
        }
    }
}