using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;

namespace Web.ViewModels
{
    public class PictureRatingIndexViewModel
    {
        public List<PictureRating> PictureRatings { get; set; }
    }

    public class PictureRatingCreateEditViewModel
    {
        public PictureRating PictureRating { get; set; }
        public SelectList Pictures { get; set; }
        public SelectList Ratings { get; set; }

    }
}