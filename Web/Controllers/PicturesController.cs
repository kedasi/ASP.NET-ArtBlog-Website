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
    public class PicturesController : BaseController
    {
        private readonly IUOW _uow;

        public PicturesController(IUOW uow)
        {
            _uow = uow;
        }


        // GET: Pictures
        public ActionResult Index()
        {
            var vm = new PictureIndexViewModel()
            {
                Pictures = _uow.Pictures.All
            };
            return View(vm);
        }

        // GET: Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = _uow.Pictures.GetById(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Pictures/Create
        public ActionResult Create()
        {
            var vm = new PictureCreateEditViewModel()
            {
                Users = new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id), nameof(Domain.Identity.UserInt.UserName))
            };
            return View(vm);
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PictureCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Pictures.Add(vm.Picture);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.Users= new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id),
                nameof(Domain.Identity.UserInt.UserName), vm.Picture.UserId);
            return View(vm);
        }

        // GET: Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = _uow.Pictures.GetById(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            var vm = new PictureCreateEditViewModel()
            {
                Picture = picture,
                Users = new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id),
                nameof(Domain.Identity.UserInt.UserName), picture.UserId)
        };
            return View(vm);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PictureCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Pictures.Update(vm.Picture);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.Users = new SelectList(this._uow.UsersInt.All, nameof(Domain.Identity.UserInt.Id),
                nameof(Domain.Identity.UserInt.UserName), vm.Picture.UserId);
            return View(vm);
        }

        // GET: Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = _uow.Pictures.GetById(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = _uow.Pictures.GetById(id);
            _uow.Pictures.Delete(picture);
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
