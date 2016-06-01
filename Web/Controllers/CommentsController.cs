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
    public class CommentsController : BaseController
    {
        private readonly IUOW _uow;

        public CommentsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Comments
        public ActionResult Index()
        {
            var vm = new CommentIndexViewModel()
            {
                Comments = _uow.Comments.All
            };
            return View(vm);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _uow.Comments.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            var vm = new CommentCreateEditViewModel()
            {
                Users = new SelectList(this._uow.Users.All, nameof(Domain.Models.User.UserId), nameof(Domain.Models.User.Username)),
                Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId), nameof(Picture.PictureTitle))
            };

            return View(vm);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Comments.Add(vm.Comment);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.Users = new SelectList(this._uow.Users.All, nameof(Domain.Models.User.UserId),
            nameof(Domain.Models.User.Username), vm.Comment.UserId);
            vm.Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId),
                nameof(Picture.PictureTitle), vm.Comment.PictureId);

            return View(vm);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _uow.Comments.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            var vm = new CommentCreateEditViewModel()
            {
                Comment = comment,
                Users = new SelectList(this._uow.Users.All, nameof(Domain.Models.User.UserId),
            nameof(Domain.Models.User.Username), comment.UserId),
            Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId),
                nameof(Picture.PictureTitle), comment.PictureId)
        };

            return View(vm);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Comments.Update(vm.Comment);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.Users = new SelectList(this._uow.Users.All, nameof(Domain.Models.User.UserId),
            nameof(Domain.Models.User.Username), vm.Comment.UserId);
            vm.Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId),
                nameof(Picture.PictureTitle), vm.Comment.PictureId);

            return View(vm);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _uow.Comments.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = _uow.Comments.GetById(id);
            _uow.Comments.Delete(comment);
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
