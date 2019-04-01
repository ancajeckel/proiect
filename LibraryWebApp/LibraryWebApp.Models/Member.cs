using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApp.Models
{
    public class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Requests = new HashSet<Request>();
        }

        public int MemberId { get; set; }
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }
        public string PermitNumber { get; set; }
        public Nullable<int> AddressId { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        [Display(Name = "Your email")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage ="This field is required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Your password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        [NotMapped]
        public string LoginErrorMessage { get; set; }
    }
}
