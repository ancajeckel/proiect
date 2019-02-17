using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.Libraries = new HashSet<Library>();
            this.Members = new HashSet<Member>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public Nullable<int> BuildingNumber { get; set; }
        public string BuildingName { get; set; }
        public string EntranceNumber { get; set; }
        public string Floor { get; set; }
        public Nullable<int> ApartmentNumber { get; set; }
        public string City { get; set; }
        public Nullable<int> PostalCode { get; set; }
        public string Country { get; set; }
        public string OtherDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Library> Libraries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
