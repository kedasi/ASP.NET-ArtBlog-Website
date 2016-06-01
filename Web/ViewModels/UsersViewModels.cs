using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace Web.ViewModels
{
    public class UserIndexViewModel
    {
        public List<User> Users { get; set; }
    }

    public class UserCreateEditViewModel
    {
        public User User { get; set; }

        
    }
}