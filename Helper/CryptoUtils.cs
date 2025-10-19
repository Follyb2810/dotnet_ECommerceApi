using System;
using System.Security.Cryptography;

namespace ECommerceApi.Helper
{
    public static class CryptoUtils
    {
        /// <summary>
        /// Generates a secure random hexadecimal token.
        /// Equivalent to crypto.randomBytes(length).toString("hex") in Node.js
        /// </summary>
        /// <param name="length">The number of bytes to generate (default = 32)</param>
        /// <returns>A secure random hex string</returns>
        public static string GenerateSecureToken(int length = 32)
        {
            var bytes = RandomNumberGenerator.GetBytes(length);
            return Convert.ToHexString(bytes).ToLower(); // lowercase for consistency
        }

        /// <summary>
        /// Generates a cryptographically secure random integer within a range.
        /// Equivalent to crypto.randomInt(min, max) in Node.js
        /// </summary>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (exclusive)</param>
        /// <returns>A secure random integer</returns>
        public static int GenerateSecureInt(int min, int max)
        {
            return RandomNumberGenerator.GetInt32(min, max);
        }

        /// <summary>
        /// Generates a new UUID (GUID in .NET).
        /// Equivalent to crypto.randomUUID() in Node.js
        /// </summary>
        /// <returns>A random UUID string</returns>
        public static string GenerateUUID()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates a numeric one-time code (e.g. 6-digit OTP)
        /// </summary>
        /// <param name="digits">Number of digits (default = 6)</param>
        /// <returns>A random numeric code</returns>
        public static string GenerateNumericCode(int digits = 6)
        {
            int min = (int)Math.Pow(10, digits - 1);
            int max = (int)Math.Pow(10, digits);
            return GenerateSecureInt(min, max).ToString();
        }
    }
}
