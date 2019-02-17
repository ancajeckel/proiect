using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;

namespace LibraryWebApp.Interfaces
{
    public interface IAuthorManager
    {
        void Save(Author author);

        Author Get(int id);

        IList<Author> GetAll();
    }
}
