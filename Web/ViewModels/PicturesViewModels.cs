using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Domain.Models;

namespace Web.ViewModels
{
    public class PictureIndexViewModel
    {
        public List<Picture> Pictures { get; set; }
    }

    public class PictureCreateEditViewModel
    {
        public Picture Picture { get; set; }
        public SelectList Users { get; set; }
    }
   
}