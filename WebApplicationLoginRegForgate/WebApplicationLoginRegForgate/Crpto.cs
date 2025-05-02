using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationLoginRegForgate
{
    public static class Crpto
    {
        public static string Hash(string Value)
        {
            // Hashing logic here
            // For example, using SHA256
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(Value);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}