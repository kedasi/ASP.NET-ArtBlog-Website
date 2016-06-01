using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PictureRating
    {
        public int PictureRatingId { get; set; }

        //fk
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        public int RatingId { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
