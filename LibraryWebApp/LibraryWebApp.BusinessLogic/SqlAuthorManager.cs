using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Interfaces;
using LibraryWebApp.Models;
using LibraryWebApp.DataAccess;

namespace LibraryWebApp.BusinessLogic
{
    public class SqlAuthorManager : IAuthorManager
    {
        private LibraryDatabaseEntities db;

        public SqlAuthorManager()
        {
            db = new LibraryDatabaseEntities();
        }

        Author IAuthorManager.Get(int id)
        {
            return db.Authors.First(x => x.AuthorId == id);
        }

        IList<Author> IAuthorManager.GetAll()
        {

            return db.Authors.Where(a => true).ToList();
        }

        void IAuthorManager.Save(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
