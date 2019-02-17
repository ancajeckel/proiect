using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public Nullable<int> RequestedBy { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<System.DateTime> DateRequested { get; set; }
        public Nullable<System.DateTime> DateReturned { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
