using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        [Required, MaxLength(50)]
        public string PictureTitle { get; set; }
        [Required, MaxLength(1000)]
        public string PictureUrl { get; set; }

     //fk
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<PictureRating> PictureRatings { get; set; }
    }
}
