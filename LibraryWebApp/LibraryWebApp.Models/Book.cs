using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApp.Models
{
    public class Book
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.BookAuthors = new HashSet<BookAuthor>();
            this.BookCategories = new HashSet<BookCategory>();
            this.BookLibraries = new HashSet<BookLibrary>();
            this.Requests = new HashSet<Request>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Book title is required")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Publisher of a book is required")]
        public int PublisherId { get; set; }

        [Required]
        [Range(1000,2100,ErrorMessage = "Here should be given a valid year")]
        public int Year { get; set; }

        public Nullable<decimal> Price { get; set; }

        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookLibrary> BookLibraries { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
