using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain.Models
{
    public class Picture : BaseEntity
    {
        public int PictureId { get; set; }


        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(1000, ErrorMessageResourceName = nameof(Resources.Domain.PicTitleTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(5, ErrorMessageResourceName = nameof(Resources.Domain.PicTitleTooShort), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string PictureTitle { get; set; }
        [Required, MaxLength(1000)]
        public string PictureUrl { get; set; }

     //fk
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<PictureRating> PictureRatings { get; set; }
    }
}
