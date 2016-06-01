using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class BlogEntry
    {
       public int BlogEntryId { get; set; }
        [MaxLength(144), Required]

       public string BlogTitle { get; set; }
        [MaxLength(10000), MinLength(50), Required]
       public string BlogText { get; set; }


        //fk

       public int UserId { get; set; }
       public virtual User User { get; set; }
    }
}
