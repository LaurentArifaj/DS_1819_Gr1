using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace finalTest
{
    class RSA
    {

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;

        static public String encryptRSA(String plainText, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[]  bytePlainText = Encoding.UTF8.GetBytes(plainText);

                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(bytePlainText, DoOAEPPadding);
                }
                return Convert.ToBase64String(encryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public String DecryptRSA(String encText, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] byteEncText = Encoding.UTF8.GetBytes(encText);
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(byteEncText, DoOAEPPadding);
                }
                return Convert.ToBase64String( decryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
