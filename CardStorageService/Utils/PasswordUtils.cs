using System.Security.Cryptography;
using System.Text;

namespace CardStorageService.Utils
{
    public static class PasswordUtils
    {
        private const string SecretKey = "TopSecretTopSecret";

        public static (string passwordSalt, string passwordHash) CreatePasswordHash(string password)
        {
            // генерируется соль
            byte[] buffer = new byte[16];
            RNGCryptoServiceProvider secureRandom = new RNGCryptoServiceProvider();
            secureRandom.GetBytes(buffer);  

            // создание хэша
            string passwordSalt = Convert.ToBase64String(buffer);
            string passwordHash = GetPasswordHash(password, passwordSalt);

            return (passwordSalt, passwordHash);
        }

        public static bool VerifyPassword(string password, string passwordSalt, string passwordHash)
        {
            return GetPasswordHash(password, passwordSalt) == passwordHash;
        }

        public static string GetPasswordHash(string password, string passwordSalt) 
        {
            password = $"{password}~{passwordSalt}~{SecretKey}";
            byte[] buffer = Encoding.UTF8.GetBytes(password);

            SHA512 sha512 = new SHA512Managed();
            byte[] passwordHash= sha512.ComputeHash(buffer);

            return Convert.ToBase64String(passwordHash);
        
        }
    }
}
