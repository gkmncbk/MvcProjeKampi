using BusinessLayer.Abstract;
using EntityLayer.Concrete.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        public string hash = "MvcProjeKampi";
        public string Decrypt(string p)
        {
            byte[] data = Convert.FromBase64String(p);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        public string Encrypt(string p)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(p);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public string PasswordHash(string p)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(p))); ;
        }
        public Boolean ReCaptcha(string captcha)
        {

            const string secret = "6LcbnlsbAAAAAGVC-me0TRpGpyYcb393Zw08DCsP";

            var restUrl = string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, captcha);

            WebRequest req = WebRequest.Create(restUrl);
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

            JsonSerializer serializer = new JsonSerializer();

            CaptchaResult result = null;

            using (var reader = new StreamReader(resp.GetResponseStream()))
            {
                string resultObject = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<CaptchaResult>(resultObject);     
            }
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
