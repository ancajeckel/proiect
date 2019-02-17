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
            throw new NotImplementedException();
        }

        IList<Author> IAuthorManager.GetAll()
        {
            return db.Authors.Select(a => a).ToList();
        }

        void IAuthorManager.Save(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
