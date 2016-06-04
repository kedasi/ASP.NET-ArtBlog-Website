using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(35, ErrorMessageResourceName = nameof(Resources.Domain.UsernameTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(3, ErrorMessageResourceName = nameof(Resources.Domain.UsernameTooShort), ErrorMessageResourceType = typeof(Resources.Domain))]
       public string Username { get; set; }

        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(35, ErrorMessageResourceName = nameof(Resources.Domain.PasswordTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(6, ErrorMessageResourceName = nameof(Resources.Domain.PasswordTooShort), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string Password { get; set; }

        [MaxLength(35, ErrorMessageResourceName = nameof(Resources.Domain.TextTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
       public string Firstname { get; set; }

        [MaxLength(35, ErrorMessageResourceName = nameof(Resources.Domain.TextTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string Lastname { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime Birthdate { get; set; }
        [MaxLength(35, ErrorMessageResourceName = nameof(Resources.Domain.TextTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string Location { get; set; }
        [MaxLength(35, ErrorMessageResourceName = nameof(Resources.Domain.TextTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string AboutMe { get; set; }

        //fk
        public virtual List<BlogEntry> BlogEntries { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Picture> Pictures { get; set; }

    }
}
