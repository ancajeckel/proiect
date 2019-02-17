using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class BookLibrary
    {
        public int BookLibraryId { get; set; }
        public Nullable<int> LibraryId { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual Library Library { get; set; }
    }
}
