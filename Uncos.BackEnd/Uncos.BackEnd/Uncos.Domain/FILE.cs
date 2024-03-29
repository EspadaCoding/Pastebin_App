using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Domain
{
    public class FILE
    {
        public Guid NewsId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; }
    }
}
