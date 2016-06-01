using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUOW _uow;

        public UsersController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Users
        public ActionResult Index()
        {
            var vm = new UserIndexViewModel()
            {
                Users = _uow.Users.All
            };
            return View(vm);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _uow.Users.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            var vm = new UserCreateEditViewModel();
            return View(vm);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Users.Add(vm.User);
                _uow.Commit();
                
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _uow.Users.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var vm = new UserCreateEditViewModel()
            {
                User = user
            };
            return View(vm);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Users.Update(vm.User);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _uow.Users.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _uow.Users.GetById(id);
            _uow.Users.Delete(user);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
