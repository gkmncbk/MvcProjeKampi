using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
   public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        Context c = new Context();
        //public Writer GetByWriter(string mail, string password)
        //{
        //    return c.Writers.FirstOrDefault(x => x.WriterMail == mail && x.WriterPassword == password);
        //}

        public int GetByWriterId(string mail)
        {
            //return c.Writers.FirstOrDefault(x => x.WriterMail == mail).WriterID;
            return c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault(); ;
        }
    }
}
