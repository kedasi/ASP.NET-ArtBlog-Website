using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Identity;

namespace Web.ViewModels
{
    public class UserIndexViewModel
    {
        public List<UserInt> Users { get; set; }
    }

    public class UserCreateEditViewModel
    {
        //public UserInt User { get; set; }
        public int? UserId { get; set; }


        [MaxLength(25, ErrorMessageResourceName = nameof(Resources.Domain.TextTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string AboutMeHead { get; set; }
        [MinLength(35, ErrorMessageResourceName = nameof(Resources.Domain.BlogTextTooShort), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string AboutMeBody { get; set; }
    }
}