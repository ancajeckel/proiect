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
    public class SqlPublisherManager : IPublisherManager
    {
        private LibraryDatabaseEntities db;

        public SqlPublisherManager()
        {
            db = new LibraryDatabaseEntities();
        }

        public SqlPublisherManager(LibraryDatabaseEntities dbexist)
        {
            db = dbexist;
        }

        public Publisher Get(int? id)
        {
            if (id != null)
            {
                return db.Publishers.First(p => p.PublisherId == id);
            }
            return null;
        }

        public IList<Publisher> GetAll()
        {
            return db.Publishers.Where(b => true).ToList();
        }

        public void Save(Publisher publisher)
        {
            db.Publishers.Add(publisher);
            db.SaveChanges();
        }
    }
}
