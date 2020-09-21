namespace Neolution.Abstractions.Tests
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Neolution.Abstractions.Security;
    using Neolution.Extensions.DependencyInjection;
    using Shouldly;
    using Xunit;

    /// <summary>
    /// Tests for password hashers. Implementations of <see cref="IPasswordHasher"/>
    /// </summary>
    public class PasswordHasherTests
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordHasherTests"/> class.
        /// </summary>
        public PasswordHasherTests()
        {
            this.serviceProvider = Bootstrapper.Startup<CompositionRoot>(new ConfigurationBuilder().Build());
        }

        /// <summary>
        /// Password can be verified.
        /// </summary>
        [Fact]
        public void Password_Can_Be_Verified()
        {
            // Arrange
            var hasher = this.serviceProvider.GetService<IPasswordHasher>();
            const string plainPassword = "helloWorld!";

            // Act
            var sw = new Stopwatch();
            sw.Start();
            var hashedPassword = hasher.CreateHash(plainPassword);
            sw.Stop();

            // Assert
            hasher.VerifyHash(hashedPassword, plainPassword).ShouldBeTrue();
            Trace.WriteLine($"Hashing the password needed {sw.ElapsedMilliseconds}ms to complete!");
        }

        /// <summary>
        /// Password hashes are salted.
        /// </summary>
        [Fact]
        public void Hashes_Are_Salted()
        {
            // Arrange
            var hasher = this.serviceProvider.GetService<IPasswordHasher>();
            const string plainPassword = "helloWorld!";

            // Act
            var hashedPassword1 = hasher.CreateHash(plainPassword, 4);
            var hashedPassword2 = hasher.CreateHash(plainPassword, 4);

            // Assert
            hashedPassword1.ShouldNotBe(hashedPassword2);
        }
    }
}
