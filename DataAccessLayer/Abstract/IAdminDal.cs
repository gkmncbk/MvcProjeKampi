using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAdminDal : IRepository<Admin>
    {
        Admin GetByAdmin(string k, string p);
        string[] GetRolesForAdmin(string username);

        List<Admin> GetListAdmin();
        //Admin GetAdmin(int id);
    }
}
