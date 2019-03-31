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
    public class SqlMemberManager : IMemberManager
    {
        private LibraryDatabaseEntities db;

        public SqlMemberManager()
        {
            db = new LibraryDatabaseEntities();
        }

        Member IMemberManager.Get(int id)
        {
            return db.Members.First(x => x.MemberId == id);
        }


        Member IMemberManager.Get(String email, String password)
        {
            return db.Members
                .Where(x => x.EmailAddress == email && x.Password == password)
                .FirstOrDefault()                ;
        }

        IList<Member> IMemberManager.GetAll()
        {

            return db.Members.Where(a => true).ToList();
        }

        public void Save(Member member)
        {
            if (member.MemberId <= 0)
            {
                db.Members.Add(member);
            }
            else
            {
                db.Entry(member).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        public void Delete(Member member)
        {
            db.Members.Remove(member);
            db.SaveChanges();
        }
    }
}
