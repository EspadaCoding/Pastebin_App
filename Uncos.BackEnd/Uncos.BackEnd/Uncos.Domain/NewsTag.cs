using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    [Table("NewsTag")]
    public class NewsTag
    { 
        public Guid Id { get; set; }
        public Guid NewsId { get; set; }
        public virtual News News { get; set; }
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
