using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Tsmp.User.Domain.Services;

namespace Tsmp.User.Infrastructure.Services
{
    public class SHA256PasswordHelper : IPasswordHelper
    {
        public bool CompareHash(string hash, string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var passwordHashBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hashBytes = Encoding.UTF8.GetBytes(hash);

                if (hashBytes.Length != passwordHashBytes.Length) return false;

                for (var i = 0; i < hashBytes.Length; i++)
                {
                    if (hashBytes[i] != passwordHashBytes[i]) return false;
                }

                return true;
            }
        }

        public string ComputeHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString());
                }

                return builder.ToString();
            }
        }
    }
}
