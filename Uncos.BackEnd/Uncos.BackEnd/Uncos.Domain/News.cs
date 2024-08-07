using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    [Table("News")]
    public class News
    {
        public Guid userId { get; set; }
        public Guid Id { get; set; }
        [Display(Name = "News title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Display(Name = "News content text")]
        [Required(ErrorMessage = "Error, invalid content!!!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Poster")]
        public string Poster { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Likes")]
        public int Likes { get; set; } = 0;
        [Display(Name = "ItSaved")]
        public bool ItSaved { get; set; } = false;
        [Display(Name = "ItLiked")]
        public bool ItLiked { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Error, invalid category!!!")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "CountofComments")]
        public int CountofComments { get; set; }
        public virtual IEnumerable<NewsTag> NewsTags { get; set; }
    }
}