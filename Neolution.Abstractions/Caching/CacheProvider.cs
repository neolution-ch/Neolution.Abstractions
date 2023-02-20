namespace Neolution.Abstractions.Caching
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// LEGACY Abstract base class for cache providers
    /// </summary>

    [Obsolete("Please use either MemoryCache or DistributedCache")]
    public abstract class CacheProvider<TEnum> : ICacheProvider<TEnum>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Gets the name of the cache.
        /// </summary>
        /// <value>
        /// The name of the cache.
        /// </value>
        private static string CacheName => typeof(TEnum).Name;

        /// <inheritdoc />
        public T GetObject<T>(TEnum container)
        {
            return this.GetObject<T>(container, null);
        }

        /// <inheritdoc />
        public T GetObject<T>(TEnum container, string key)
        {
            key = CreateCacheKey(container, key);
            return (T)this.GetCacheObject(key);
        }

        /// <inheritdoc />
        public void SetObject(TEnum container, object cacheObject)
        {
            this.SetObject(container, null, cacheObject);
        }

        /// <inheritdoc />
        public void SetObject(TEnum container, string key, object cacheObject)
        {
            key = CreateCacheKey(container, key);
            this.SetCacheObject(key, cacheObject);
        }

        /// <inheritdoc />
        public void SetObject(TEnum container, object cacheObject, DateTime expiration)
        {
            this.SetObject(container, null, cacheObject, expiration);
        }

        /// <inheritdoc />
        public void SetObject(TEnum container, string key, object cacheObject, DateTime expiration)
        {
            key = CreateCacheKey(container, key);
            this.SetCacheObject(key, cacheObject, expiration);
        }

        /// <inheritdoc />
        public void Reset(TEnum container)
        {
            this.Reset(container, null);
        }

        /// <inheritdoc />
        public void Reset(TEnum container, string key)
        {
            key = CreateCacheKey(container, key);
            this.ResetCacheObject(key);
        }

        /// <summary>
        /// Gets the object from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The object from the cache</returns>
        protected abstract object GetCacheObject(string key);

        /// <summary>
        /// Sets the object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        protected abstract void SetCacheObject(string key, object value);

        /// <summary>
        /// Sets the object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiration">The expiration.</param>
        protected abstract void SetCacheObject(string key, object value, DateTime expiration);

        /// <summary>
        /// Resets the object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        protected abstract void ResetCacheObject(string key);

        /// <summary>
        /// Creates the cache key.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <returns>The cache key</returns>
        private static string CreateCacheKey(TEnum container, string key = null)
        {
            var containerName = container.ToString();
            if (!string.IsNullOrWhiteSpace(key))
            {
                containerName = $"{containerName}_{key}";
            }

            return $"{CacheName}:{containerName}";
        }
    }
}
