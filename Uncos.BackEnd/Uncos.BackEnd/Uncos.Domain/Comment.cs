﻿ 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    [Table("Comment")]
    public class Comment
    { 
        public Guid Id { get; set; }
        [Display(Name = "News content text")] 
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int NewsID { get; set; }
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
    }
}
