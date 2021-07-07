using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ILoginService
    {

        string PasswordHash(string p);

        string Encrypt(string p);
        string Decrypt(string p);
        //List<Admin> GetAdminList();
        //Admin GetAdmin();

        Boolean ReCaptcha(string captcha);
    }
}
