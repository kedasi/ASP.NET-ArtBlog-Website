using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain.Models
{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }


        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(1000, ErrorMessageResourceName = nameof(Resources.Domain.CommentTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(5, ErrorMessageResourceName = nameof(Resources.Domain.CommentTooShort), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string CommentText { get; set; }

        //fk
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        public int UserId { get; set; }
        public virtual UserInt User { get; set; }
    }
}
