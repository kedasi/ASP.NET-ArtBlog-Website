using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [MinLength(5), MaxLength(1000), Required]
        public string CommentText { get; set; }

        //fk
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
