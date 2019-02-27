using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;

namespace LibraryWebApp.Interfaces
{
    public interface IPublisherManager
    {
        void Save(Publisher publisher);

        Publisher Get(int? id);

        IList<Publisher> GetAll();
    }
}
