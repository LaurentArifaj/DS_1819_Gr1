using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace finalTest
{
    class Password
    {
        public static String generateSalt()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            String salt = rnd.Next(100000, 1000000).ToString();
            return salt;
        }
        public static String encryptPw(String password)
        {
            string passwordSalt = password + generateSalt();
            SHA1CryptoServiceProvider objHash = new SHA1CryptoServiceProvider();
            byte[] bytePasswordSalt = Encoding.UTF8.GetBytes(passwordSalt);
            byte[] byteSaltedPasswordHash = objHash.ComputeHash(bytePasswordSalt);
            return Convert.ToBase64String(byteSaltedPasswordHash);
        }
        public static Boolean verifyPw(String password, String salt, String encPassword)
        {
            string saltPassword = password + salt;

            byte[] byteSaltPassword =
                Encoding.UTF8.GetBytes(saltPassword);

            SHA1CryptoServiceProvider objHash =
                new SHA1CryptoServiceProvider();
            byte[] byteSaltedHashPassword =
                objHash.ComputeHash(byteSaltPassword);

            string base64SaltedHashPassword =
                Convert.ToBase64String(byteSaltedHashPassword);

            if (base64SaltedHashPassword.Equals(encPassword))
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
