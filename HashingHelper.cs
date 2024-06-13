using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype_full
{
    internal class HashingHelper
    {
        private const int SALT_LENGTH = 5;

        public HashingHelper() { }

        private string GenerateSalt()
        {
            byte[] salt = new byte[SALT_LENGTH];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // switch bits randomly
                rng.GetNonZeroBytes(salt);
            }
            // return 5 characters of an otherwise 8 character ASCII salt
            return Convert.ToBase64String(salt).Substring(0, 5);
        }

        private string SHA256HashString(string inputString)
        {
            byte[] result;
            using (SHA256 sha256 = SHA256.Create())
            {
                // get bytes of input string
                byte[] input = Encoding.UTF8.GetBytes(inputString);
                // compute hash using SHA256
                result = sha256.ComputeHash(input);
            }
            return Convert.ToBase64String(result);
        }

        public (string salt, string encryptedPassword) ComputeSaltAndHash(string plaintextPassword)
        {
            string salt = GenerateSalt();
            string hashedPassword = SHA256HashString($"{plaintextPassword}{salt}");
            return (salt, hashedPassword);
        }

        public string GetHashFromSaltAndPassword(string plaintextPassword, string salt)
        {
            if (salt.Length != SALT_LENGTH) throw new Exception("Attempted to hash password with a salt of incorrect length.");
            return SHA256HashString($"{plaintextPassword}{salt}");
        }
    }
}
