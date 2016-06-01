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
    public class PictureRatingsController : BaseController
    {
        private readonly IUOW _uow;

        public PictureRatingsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: PictureRatings
        public ActionResult Index()
        {
            var vm = new PictureRatingIndexViewModel()
            {
                PictureRatings = _uow.PictureRatings.All
            };
            return View(vm);
        }

        // GET: PictureRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PictureRating pictureRating = _uow.PictureRatings.GetById(id);
            if (pictureRating == null)
            {
                return HttpNotFound();
            }
            return View(pictureRating);
        }

        // GET: PictureRatings/Create
        public ActionResult Create()
        {
            var vm = new PictureRatingCreateEditViewModel()
            {
               Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId), nameof(Picture.PictureTitle)),
                Ratings = new SelectList(this._uow.Ratings.All, nameof(Rating.RatingId), nameof(Rating.Rate))
            };
            return View(vm);
        }

        // POST: PictureRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PictureRatingCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.PictureRatings.Add(vm.PictureRating);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            vm.Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId),
                 nameof(Picture.PictureTitle), vm.PictureRating.PictureId);
            vm.Ratings = new SelectList(this._uow.Ratings.All, nameof(Rating.RatingId),
                nameof(Rating.Rate), vm.PictureRating.RatingId);
            return View(vm);
        }

        // GET: PictureRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PictureRating pictureRating = _uow.PictureRatings.GetById(id);
            if (pictureRating == null)
            {
                return HttpNotFound();
            }
            var vm = new PictureRatingCreateEditViewModel()
            {
                PictureRating = pictureRating,
                Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId),
                 nameof(Picture.PictureTitle), pictureRating.PictureId),
            Ratings = new SelectList(this._uow.Ratings.All, nameof(Rating.RatingId),
                nameof(Rating.Rate), pictureRating.RatingId)
        };
            return View(vm);
        }

        // POST: PictureRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PictureRatingCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.PictureRatings.Update(vm.PictureRating);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.Pictures = new SelectList(this._uow.Pictures.All, nameof(Picture.PictureId),
                nameof(Picture.PictureTitle), vm.PictureRating.PictureId);
            vm.Ratings = new SelectList(this._uow.Ratings.All, nameof(Rating.RatingId),
                nameof(Rating.Rate), vm.PictureRating.RatingId);
            return View(vm);
        }

        // GET: PictureRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PictureRating pictureRating = _uow.PictureRatings.GetById(id);
            if (pictureRating == null)
            {
                return HttpNotFound();
            }
            return View(pictureRating);
        }

        // POST: PictureRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PictureRating pictureRating = _uow.PictureRatings.GetById(id);
            _uow.PictureRatings.Delete(pictureRating);
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
