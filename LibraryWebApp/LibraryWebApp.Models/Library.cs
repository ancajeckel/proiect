using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Library
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Library()
        {
            this.BookLibraries = new HashSet<BookLibrary>();
        }

        public int LibraryId { get; set; }
        public string Name { get; set; }
        public Nullable<int> AddressId { get; set; }

        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookLibrary> BookLibraries { get; set; }
    }
}
