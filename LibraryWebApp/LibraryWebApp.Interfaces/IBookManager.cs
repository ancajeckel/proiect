using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;

namespace LibraryWebApp.Interfaces
{
    public interface IBookManager
    {
        void Save(Book book);

        Book Get(int id);

        IList<Book> GetAll();
    }
}
