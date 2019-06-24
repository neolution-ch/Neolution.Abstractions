namespace Neolution.Abstractions.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using Neolution.Abstractions.Security;
    using Neolution.Abstractions.Tests.Implementations.Security;
    using Neolution.DependencyResolution.Abstractions;

    /// <inheritdoc />
    public class CompositionRoot : BootstrappedCompositionRoot
    {
        /// <inheritdoc />
        public override void Configure(IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        }
    }
}
