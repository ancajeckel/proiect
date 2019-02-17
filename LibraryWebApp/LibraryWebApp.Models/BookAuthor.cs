using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
