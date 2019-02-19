using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LibraryWebApp.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibraryWebApp.DataAccess
{
    public partial class LibraryDatabaseEntities : DbContext
    {
        public LibraryDatabaseEntities()
            : base("name=LibraryDatabaseEntities")
        {
        }

        //test branch
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookLibrary> BookLibraries { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
    }
}
