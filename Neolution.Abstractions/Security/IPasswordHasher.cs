﻿namespace Neolution.Abstractions.Security
{
    /// <summary>
    /// Provides methods to create and validate password hashes.
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Gets or sets the work factor. Higher means more time is needed for hashing.
        /// </summary>
        int WorkFactor { get; set; }

        /// <summary>
        /// Creates the hash from the specified plain text password.
        /// </summary>
        /// <param name="plainTextPassword">The plain text password.</param>
        /// <returns>The hashed password.</returns>
        string CreateHash(string plainTextPassword);

        /// <summary>
        /// Verifies the specified plain text password with the specified hash.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="plainTextPassword">The plain text password.</param>
        /// <returns><c>true</c> if the hashed password is a correct computed hash of the specified plain text password; <c>false</c> if this is not the case.</returns>
        bool VerifyHash(string hashedPassword, string plainTextPassword);
    }
}
