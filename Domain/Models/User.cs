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

        [MinLength(3),MaxLength(35), Required]
        public string Username { get; set; }
        [MinLength(6), MaxLength(35), Required]
        public string Password { get; set; }
        [MaxLength(35)]
        public string Firstname { get; set; }
        [MaxLength(35)]
        public string Lastname { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime Birthdate { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        [MaxLength(5000)]
        public string AboutMe { get; set; }

        //fk
        public virtual List<BlogEntry> BlogEntries { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Picture> Pictures { get; set; }

    }
}
