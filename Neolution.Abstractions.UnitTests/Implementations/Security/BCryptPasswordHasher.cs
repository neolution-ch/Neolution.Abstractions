namespace Neolution.Abstractions.Tests.Implementations.Security
{
    using Neolution.Abstractions.Security;

    /// <summary>
    /// Uses BCrypt as a password hashing provider
    /// </summary>
    /// <seealso cref="IPasswordHasher" />
    public class BCryptPasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// The default work factor
        /// </summary>
        /// <remarks>sciervo: My DELL XPS13 needs about 900ms to hash the password with work factor 13</remarks>
        private const int DefaultWorkFactor = 13;

        /// <inheritdoc />
        public string CreateHash(string plainTextPassword)
        {
            return this.CreateHash(plainTextPassword, DefaultWorkFactor);
        }

        /// <inheritdoc />
        public string CreateHash(string plainTextPassword, int workFactor)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword, workFactor);
        }

        /// <inheritdoc />
        public bool VerifyHash(string hashedPassword, string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
        }
    }
}
