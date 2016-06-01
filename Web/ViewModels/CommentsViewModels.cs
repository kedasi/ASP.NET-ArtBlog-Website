using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;

namespace Web.ViewModels
{
    public class CommentIndexViewModel
    {
        public List<Comment> Comments { get; set; }
    }
    public class CommentCreateEditViewModel
    {
        public Comment Comment { get; set; }
        public SelectList Users { get; set; }
        public SelectList Pictures { get; set; }

    }
}