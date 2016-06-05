using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
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
                UserInt = this._uow.UsersInt.GetById(User.Identity.GetUserId<int>())
            };
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}