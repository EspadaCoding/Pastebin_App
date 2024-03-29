using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    public class News
    {
        public Guid userId { get; set; }
        public Guid Id { get; set; } 
        [Display(Name = "News title")]
        [Required(ErrorMessage = "Error, invalid title!!!")]
        [RegularExpression("^[A-Z][a-z]{1,99}$", ErrorMessage = "RegularExpression error!")]
        [MinLength(8, ErrorMessage = "Error, min lenght 8 letters!")]
        [MaxLength(100, ErrorMessage = "Error, max length 100 letters!")]
        [DataType(DataType.Text)]
        public string Title { get; set; } 
        [Display(Name = "News content text")]
        [Required(ErrorMessage = "Error, invalid content!!!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
         
        public FILE Poster { get; set; }

        [Display(Name = "Likes")]
        public int Likes { get; set; } = 0; 
   
        public DateTime CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Error, invalid category!!!")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 

        [Display(Name = "CountofComments")]
        public int CountofComments { get; set; } 
        public virtual IEnumerable<NewsTag> NewsTags { get; set; }   
    }
}
