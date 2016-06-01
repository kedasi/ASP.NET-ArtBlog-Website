using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;

namespace Web.ViewModels
{
    public class BlogEntryIndexViewModel
    {
        public List<BlogEntry> BlogEntries { get; set; }
    }

    public class BlogEntryCreateEditViewModel
    {
        public BlogEntry BlogEntry { get; set; }
        public SelectList Users { get; set; }
        
    }
}