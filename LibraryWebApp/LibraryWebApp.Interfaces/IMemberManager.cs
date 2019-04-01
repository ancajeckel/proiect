using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;

namespace LibraryWebApp.Interfaces
{
    public interface IMemberManager
    {
        void Save(Member member);

        Member Get(int id);

        Member Get(String email, String password);

        IList<Member> GetAll();

        void Delete(Member member);
    }
}
