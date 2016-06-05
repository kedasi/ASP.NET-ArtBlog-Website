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
using Domain.Identity;
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

        //    // GET: Users
        //    public ActionResult Index()
        //    {
        //        var vm = new UserIndexViewModel()
        //        {
        //            Users = _uow.UsersInt.All
        //        };
        //        return View(vm);
        //    }

        //    // GET: Users/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        UserInt user = _uow.UsersInt.GetById(id);
        //        if (user == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(user);
        //    }

        //    // GET: Users/Create
        //    public ActionResult Create()
        //    {
        //        var vm = new UserCreateEditViewModel();
        //        return View(vm);
        //    }

        //    // POST: Users/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create(UserCreateEditViewModel vm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _uow.UsersInt.Add(vm.User);
        //            _uow.Commit();

        //            return RedirectToAction("Index");
        //        }

        //        return View(vm);
        //    }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInt user = _uow.UsersInt.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var vm = new UserCreateEditViewModel()
            {
                UserId = id,
                AboutMeHead = user.AboutMeHeader,
                AboutMeBody = user.AboutMe
                
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
                UserInt user = _uow.UsersInt.GetById(vm.UserId);
                user.AboutMe = vm.AboutMeBody;
                user.AboutMeHeader = vm.AboutMeHead;

                _uow.UsersInt.Update(user);
                _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            return View(vm);
        }

        //// GET: Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserInt user = _uow.UsersInt.GetById(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //    // POST: Users/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        UserInt user = _uow.UsersInt.GetById(id);
        //        _uow.UsersInt.Delete(user);
        //        _uow.Commit();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
