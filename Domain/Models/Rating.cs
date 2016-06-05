using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Rating : BaseEntity
    {
        public int RatingId { get; set; }
        public int Rate { get; set; }

        //fk

        public virtual List<PictureRating> PictureRatings { get; set; }
    }
}
