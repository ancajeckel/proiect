using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> CategoryId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}
