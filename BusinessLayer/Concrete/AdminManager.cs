using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            admin.AdminUserName = lm.Encrypt(admin.AdminUserName);
            admin.AdminPassword = lm.PasswordHash(admin.AdminPassword);
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            admin.AdminUserName = lm.Encrypt(admin.AdminUserName);
            //admin.AdminPassword = lm.PasswordHash(admin.AdminPassword);
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            admin.AdminUserName = lm.Encrypt(admin.AdminUserName);
            //admin.AdminPassword = lm.PasswordHash(admin.AdminPassword);
            _adminDal.Update(admin);
        }

        //public Admin GetAdmin(int id)
        //{
           
        //    var adm = _adminDal.GetAdmin(id);
        //    adm.AdminUserName = lm.Decrypt(adm.AdminUserName);                       
        //    return adm;
        //}

        public Admin GetByAdmin(string k, string p)
        {
            return _adminDal.GetByAdmin(k,p);
        }

        public Admin GetByID(int id)
        {
            var adm = _adminDal.Get(x => x.AdminID == id);
            adm.AdminUserName = lm.Decrypt(adm.AdminUserName);
            return adm;
            //return _adminDal.Get(x => x.AdminID == id);

        }
        LoginManager lm = new LoginManager();

        public List<Admin> GetListAdmin()
        {
            //var adm=_adminDal.List();

            List<Admin> lst = (from p in _adminDal.List(x=>x.AdminStatus==true)

                               select new Admin
                               {

                                   AdminID = p.AdminID,
                                   AdminUserName =lm.Decrypt(p.AdminUserName),
                                   AdminPassword = p.AdminPassword,
                                   RoleID = p.RoleID,

                               }).ToList();


            return lst;


        }

        public string[] GetRolesForAdmin(string username)
        {
            return _adminDal.GetRolesForAdmin(username);
        }
    }
}
