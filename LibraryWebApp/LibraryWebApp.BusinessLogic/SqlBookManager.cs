﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Interfaces;
using LibraryWebApp.Models;
using LibraryWebApp.DataAccess;

namespace LibraryWebApp.BusinessLogic
{
    public class SqlBookManager : IBookManager
    {
        private LibraryDatabaseEntities db;

        public SqlBookManager()
        {
            db = new LibraryDatabaseEntities();
        }

        Book IBookManager.Get(int id)
        {
            throw new NotImplementedException();
        }

        IList<Book> IBookManager.GetAll()
        {
            return db.Books.Select(b => b).ToList();
        }

        void IBookManager.Save(Book book)
        {
            throw new NotImplementedException();
        }

    }
}