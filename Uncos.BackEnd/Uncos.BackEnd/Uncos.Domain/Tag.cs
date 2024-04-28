﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    [Table("Tag")]
    public class Tag
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<NewsTag> NewsTags { get; set; }
    }
}
