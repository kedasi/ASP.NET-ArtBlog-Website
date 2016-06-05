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
    public class BlogEntriesController : BaseController
    {
        private readonly IUOW _uow;

        public BlogEntriesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: BlogEntries
        public ActionResult Index()
        {
            var vm = new BlogEntryIndexViewModel()
            {
                BlogEntries = _uow.BlogEntries.All
            };
            return View(vm);
        }

        // GET: BlogEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = _uow.BlogEntries.GetById(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Create
        public ActionResult Create()
        {
            var vm = new BlogEntryCreateEditViewModel()
            {
                Users = new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id), nameof(Domain.Identity.UserInt.UserName))
            };
            return View(vm);
        }

        // POST: BlogEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogEntryCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.BlogEntries.Add(vm.BlogEntry);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.Users = new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id),
               nameof(Domain.Identity.UserInt.UserName), vm.BlogEntry.User.Id);
            return View(vm);
        }

        // GET: BlogEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = _uow.BlogEntries.GetById(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }

            var vm = new BlogEntryCreateEditViewModel()
            {
                BlogEntry = blogEntry,
                Users = new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id),
               nameof(Domain.Identity.UserInt.UserName), blogEntry.User.Id)
        };
            return View(vm);
        }

        // POST: BlogEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogEntryCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.BlogEntries.Update(vm.BlogEntry);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.Users = new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id),
              nameof(Domain.Identity.UserInt.UserName), vm.BlogEntry.User.Id);
            return View(vm);
        }

        // GET: BlogEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = _uow.BlogEntries.GetById(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            BlogEntry blogEntry = _uow.BlogEntries.GetById(id);
            _uow.BlogEntries.Delete(blogEntry);
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
