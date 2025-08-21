using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace nea_backend
{
    internal class HashingHelper
    {
        private const int SALT_LENGTH = 5;

        public HashingHelper() { }

        /// <summary>
        /// Generates a random salt for inclusion in the database.
        /// </summary>
        /// <returns>A random 5 character ASCII salt string.</returns>
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

        /// <summary>
        /// A method to hash an ASCII string using the SHA256 hashing algorithm.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>A hexadecimal string of the hashed password.</returns>
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

        /// <summary>
        /// Given a plaintext password, produces a salt and hashes this password.
        /// </summary>
        /// <param name="plaintextPassword"></param>
        /// <returns>A tuple containing: the 5 character salt, the hashed version of the plaintext password.</returns>
        public (string salt, string encryptedPassword) ComputeSaltAndHash(string plaintextPassword)
        {
            string salt = GenerateSalt();
            string hashedPassword = SHA256HashString($"{plaintextPassword}{salt}");
            return (salt, hashedPassword);
        }

        /// <summary>
        /// Hashes the plaintext password and salt together.
        /// </summary>
        /// <param name="plaintextPassword"></param>
        /// <param name="salt"></param>
        /// <returns>A hexadecimal string containing the hashed version of the plaintext password and string put together.</returns>
        /// <exception cref="Exception"></exception>
        public string GetHashFromSaltAndPassword(string plaintextPassword, string salt)
        {
            if (salt.Length != SALT_LENGTH) throw new Exception("Attempted to hash password with a salt of incorrect length.");
            return SHA256HashString($"{plaintextPassword}{salt}");
        }
    }
}
