using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Airplanes.Security
{
    /// <summary>
    /// Class chứa các hàm liên quan tới bảo mật dữ liệu người dùng
    /// Salt : Tạo một hàm random theo toàn bộ ký tự trong hdh
    /// EncryptPassword : Tiến hành mã hóa mật khẩu theo phương thức mã hóa MD5
    /// </summary>
    public class Security
    {
        private static Security _instance;

        public static Security GetInstance()
        {
            return _instance ?? (_instance = new Security());
        }


        
        public string Salt()
        {
            string salt = "";
            StringBuilder builder = new StringBuilder();
            using (RNGCryptoServiceProvider random = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    random.GetBytes(data);
                    char character = (char)data[i];
                    builder.Append(character);
                }

                salt = builder.ToString();
            }
            return salt;
        }

        public string EncryptPassword(string password, string salt)
        {
            string newPassword = "";
            StringBuilder builder = new StringBuilder();
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = md5.ComputeHash(new UTF8Encoding().GetBytes(password + salt));
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                newPassword = builder.ToString();
            }

            return newPassword;
        }
    }
}
