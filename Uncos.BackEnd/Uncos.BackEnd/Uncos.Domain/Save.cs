using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    [Table("Save")]
    public class Save
    { 
        public Guid Id { get; set; }
        public Guid NewsId { get; set; }
        public Guid UserID { get; set; }
        public DateTime SavedDate { get; set; }
        public bool Saved { get; set; }
    }
}
