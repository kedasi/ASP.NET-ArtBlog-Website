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

        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(144, ErrorMessageResourceName = nameof(Resources.Domain.BlogTitleTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = nameof(Resources.Domain.BlogTitleTooShort), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string BlogTitle { get; set; }

        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(10000, ErrorMessageResourceName = nameof(Resources.Domain.BlogTextTooLong), ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(50, ErrorMessageResourceName = nameof(Resources.Domain.BlogTextTooShort), ErrorMessageResourceType = typeof(Resources.Domain))]
       public string BlogText { get; set; }


        //fk

       public int UserId { get; set; }
       public virtual User User { get; set; }
    }
}
