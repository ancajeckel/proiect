using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Interfaces;
using LibraryWebApp.Models;
using LibraryWebApp.DataAccess;
using System.Data.Entity;

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

        public void Save(Author author)
        {
            if (author.AuthorId <= 0)
            {
                db.Authors.Add(author);
            }
            else
            {
                db.Entry(author).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        public void Delete(Author author)
        {
            /*var auth = db.Entry(author);
            if (auth.State == EntityState.Detached)
                db.Authors.Attach(author);*/

            //db.Entry(author).State = EntityState.Deleted;

            //db.Authors.Attach(author);

            db.Authors.Remove(author);
            db.SaveChanges();
        }
    }
}
