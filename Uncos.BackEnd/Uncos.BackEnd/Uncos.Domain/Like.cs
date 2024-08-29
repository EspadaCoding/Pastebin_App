using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    [Table("Like")]
    public class Like
    { 
        public Guid Id { get; set; }
        public Guid NewsId { get; set; }
        public Guid UserID { get; set; }
        public DateTime LikedDate { get; set; }
        public bool Liked { get; set; }
    }
} 