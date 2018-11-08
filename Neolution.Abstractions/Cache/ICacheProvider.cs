namespace Neolution.Abstractions.Cache
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Methods to help caching data of any type. Data is put in containers and may be identified by a string key. Data can be saved, retrieved and reset.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    public interface ICacheProvider<in TEnum>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Gets cached data from the specified container.
        /// </summary>
        /// <typeparam name="T">The type of the returned object.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>
        /// The data from cache.
        /// </returns>
        [SuppressMessage("Minor Code Smell", "S4018:Generic methods should provide type parameters", Justification = "Type parameter cannot be inferred at method call.")]
        T GetObject<T>(TEnum container);

        /// <summary>
        /// Gets cached data identified by a key from the specified container.
        /// </summary>
        /// <typeparam name="T">The type of the returned object.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The data from cache.
        /// </returns>
        [SuppressMessage("Minor Code Smell", "S4018:Generic methods should provide type parameters", Justification = "Type parameter cannot be inferred at method call.")]
        T GetObject<T>(TEnum container, string key);

        /// <summary>
        /// Sets cached data in the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="cacheObject">The cache object.</param>
        void SetObject(TEnum container, object cacheObject);

        /// <summary>
        /// Sets cached data identified by a key in the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <param name="cacheObject">The cache object.</param>
        void SetObject(TEnum container, string key, object cacheObject);

        /// <summary>
        /// Sets cached data with an expiration date, in the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="cacheObject">The cache object.</param>
        /// <param name="expiration">The expiration.</param>
        void SetObject(TEnum container, object cacheObject, DateTime expiration);

        /// <summary>
        /// Sets cached data with an expiration date, identified by a key in the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <param name="cacheObject">The cache object.</param>
        /// <param name="expiration">The expiration.</param>
        void SetObject(TEnum container, string key, object cacheObject, DateTime expiration);

        /// <summary>
        /// Resets cached data of the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        void Reset(TEnum container);

        /// <summary>
        /// Resets cached data identified by a key of the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        void Reset(TEnum container, string key);
    }
}
