using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Utility
{
    public static class Crypto
    {

        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value))
            );
        }


        //public static string Hash(string value, HashAlgorithm algorithm, Byte[] salt)
        //{
        //    Byte[] inputBytes = Encoding.UTF8.GetBytes(value);

        //    // Combine salt and input bytes
        //    Byte[] saltedInput = new Byte[salt.Length + inputBytes.Length];
        //    salt.CopyTo(saltedInput, 0);
        //    inputBytes.CopyTo(saltedInput, salt.Length);

        //    Byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

        //    return BitConverter.ToString(hashedBytes);
        //}


        //public static string ComputeSha256Hash(string rawData)
        //{
        //    // Create a SHA256   
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        // ComputeHash - returns byte array  
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

        //        // Convert byte array to a string   
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}
    }
}
