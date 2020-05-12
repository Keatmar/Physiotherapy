using System;
using System.Security.Cryptography;
using System.Text;

namespace Physiotherapy.BLL
{
    public enum Supported_Ha
    {
        SHA256,
        SHA384,
        SHA512
    }
    public class Password
    {
        public static string ComputeHash(string password, byte[] salt)
        {
            int minSaltLength = 4;
            int maxSaltLength = 16;

            byte[] saltBytes;
            if (salt != null)
            {
                saltBytes = salt;
            }
            else // Create Random byte array
            {
                Random r = new Random();
                int saltLength = r.Next(minSaltLength, maxSaltLength);
                saltBytes = new byte[saltLength];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(saltBytes);
                rng.Dispose();
            }
            byte[] passwordDATA = ASCIIEncoding.UTF8.GetBytes(password);
            byte[] passDataAndSalt = new byte[password.Length + saltBytes.Length];

            for (int i = 0; i < passwordDATA.Length; i++)
                passDataAndSalt[i] = passwordDATA[i];
            for (int n = 0; n < saltBytes.Length; n++)
                passDataAndSalt[passwordDATA.Length + n] = passwordDATA[n];

            // Convert password byte to hash value byte
            byte[] hasValue;
            SHA512Managed sha = new SHA512Managed();
            hasValue = sha.ComputeHash(passDataAndSalt);


            byte[] result = new byte[hasValue.Length + saltBytes.Length];
            for (int i = 0; i < hasValue.Length; i++)
                result[i] = hasValue[i];
            for (int n = 0; n < saltBytes.Length; n++)
                result[hasValue.Length + n] = saltBytes[n];

            return Convert.ToBase64String(result);

        }

        public static bool ConfirmPassword(string password, string hasValue)
        {
            byte[] hashBytes = Convert.FromBase64String(hasValue);

            // For 512 hash
            int hasSize = 64;

            byte[] saltBytes = new byte[hashBytes.Length - hasSize];

            for (int x = 0; x < saltBytes.Length; x++)
                saltBytes[x] = hashBytes[hasSize + x];

            string newHash = ComputeHash(password, saltBytes);
            return (hasValue == newHash);
        }
    }
}
