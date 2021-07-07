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
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        Context c = new Context();

        //public Admin GetAdmin(int id)
        //{
        //    return c.Admins.FirstOrDefault(x => x.AdminID==id);
        //}

        public Admin GetByAdmin(string k, string p)
        {
            return c.Admins.FirstOrDefault(x => x.AdminUserName == k && x.AdminPassword == p);
        }

        
        public List<Admin> GetListAdmin()
        {
            List<Admin> lst = c.Admins.ToList();
            return lst;

        }

        public string[] GetRolesForAdmin(string username)
        {
            var x = c.Admins.FirstOrDefault(y => y.AdminUserName == username);
            if (x==null)
            {
                return null;
            }
            else
            {
                return new string[] { x.Role.RoleName };
            }

        }
    }
}
