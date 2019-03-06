using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using LibraryWebApp.Interfaces;
using LibraryWebApp.Models;
using LibraryWebApp.DataAccess;
using System.Data.Entity;

namespace LibraryWebApp.BusinessLogic
{
    public class SqlBookManager : IBookManager
    {
        private LibraryDatabaseEntities db;

        public SqlBookManager()
        {
            db = new LibraryDatabaseEntities();
        }

        public void Delete(Book book)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public LibraryDatabaseEntities getContext()
        {
            return db;
        }

        Book IBookManager.Get(int? id)
        {
            if (id != null)
            {
                return db.Books.First(b => b.BookId == id);
            }
            return null;
        }

        IList<Book> IBookManager.GetAll()
        {
            return db.Books.Select(b => b).ToList();
        }

        void IBookManager.Save(Book book)
        {
            if (book != null)
            {
                if (book.PublisherId != null)
                {
                    //needed this way instead of getting via Publisher.Get() to be in same context
                    var bookPublisher = db.Publishers.First(p => p.PublisherId == book.PublisherId);
                    if (bookPublisher != null)
                    {
                        book.Publisher = bookPublisher;
                    }
                }
            }
            if (book.BookId <= 0)
            {
                db.Books.Add(book);
            }
            else
            {
                db.Entry(book).State = EntityState.Modified;
            }
            db.Entry<Publisher>(book.Publisher).State = EntityState.Detached;
            db.SaveChanges();
        }
    }
}
