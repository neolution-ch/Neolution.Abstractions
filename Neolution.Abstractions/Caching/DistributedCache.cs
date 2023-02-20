namespace Neolution.Abstractions.Caching
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// Abstract base class for distributed cache implementations
    /// </summary>
    public abstract class DistributedCache<TCacheId> : IDistributedCache<TCacheId>
        where TCacheId : struct, Enum
    {
        /// <summary>
        /// Gets the name of the cache.
        /// </summary>
        /// <value>
        /// The name of the cache.
        /// </value>
        private static string CacheIdName => typeof(TCacheId).Name;

        /// <inheritdoc />
        public T Get<T>(TCacheId id)
        {
            return this.Get<T>(id, null);
        }

        /// <inheritdoc />
        public T Get<T>(TCacheId id, string key)
        {
            var cacheKey = CreateCacheKey(id, key);
            return this.GetCacheObject<T>(cacheKey);
        }

        /// <inheritdoc />
        public Task<T> GetAsync<T>(TCacheId id, CancellationToken token = default)
        {
            return this.GetAsync<T>(id, null, token);
        }

        /// <inheritdoc />
        public Task<T> GetAsync<T>(TCacheId id, string key, CancellationToken token = default)
        {
            var cacheKey = CreateCacheKey(id, key);
            return this.GetCacheObjectAsync<T>(cacheKey, token);
        }

        /// <inheritdoc />
        public void Set<T>(TCacheId id, T value)
        {
            this.Set(id, null, value);
        }

        /// <inheritdoc />
        public void Set<T>(TCacheId id, string key, T value)
        {
            var cacheKey = CreateCacheKey(id, key);
            this.SetCacheObject(cacheKey, value);
        }

        /// <inheritdoc />
        public Task SetAsync<T>(TCacheId id, T value, CancellationToken token = default)
        {
            return this.SetAsync(id, null, value, token);
        }

        /// <inheritdoc />
        public Task SetAsync<T>(TCacheId id, string key, T value, CancellationToken token = default)
        {
            var cacheKey = CreateCacheKey(id, key);
            return this.SetCacheObjectAsync(cacheKey, value, token);
        }

        /// <inheritdoc />
        public void SetWithOptions<T>(TCacheId id, T value, CacheEntryOptions options)
        {
            this.SetWithOptions(id, null, value, options);
        }

        /// <inheritdoc />
        public void SetWithOptions<T>(TCacheId id, string key, T value, CacheEntryOptions options)
        {
            var cacheKey = CreateCacheKey(id, key);
            this.SetCacheObject(cacheKey, value, options);
        }

        /// <inheritdoc />
        public Task SetWithOptionsAsync<T>(TCacheId id, T value, CacheEntryOptions options, CancellationToken token = default)
        {
            return this.SetWithOptionsAsync(id, null, value, options, token);
        }

        /// <inheritdoc />
        public Task SetWithOptionsAsync<T>(TCacheId id, string key, T value, CacheEntryOptions options, CancellationToken token = default)
        {
            var cacheKey = CreateCacheKey(id, key);
            return this.SetCacheObjectAsync(cacheKey, value, options, token);
        }

        /// <inheritdoc />
        public void Refresh(TCacheId id)
        {
            this.Refresh(id, null);
        }

        /// <inheritdoc />
        public void Refresh(TCacheId id, string key)
        {
            var cacheKey = CreateCacheKey(id, key);
            this.RefreshCacheObject(cacheKey);
        }

        /// <inheritdoc />
        public Task RefreshAsync(TCacheId id, CancellationToken token = default)
        {
            return this.RefreshAsync(id, null, token);
        }

        /// <inheritdoc />
        public Task RefreshAsync(TCacheId id, string key, CancellationToken token = default)
        {
            var cacheKey = CreateCacheKey(id, key);
            return this.RefreshCacheObjectAsync(cacheKey, token);
        }

        /// <inheritdoc />
        public void Remove(TCacheId id)
        {
            this.Remove(id, null);
        }

        /// <inheritdoc />
        public void Remove(TCacheId id, string key)
        {
            var cacheKey = CreateCacheKey(id, key);
            this.RemoveCacheObject(cacheKey);
        }

        /// <inheritdoc />
        public Task RemoveAsync(TCacheId id, CancellationToken token = default)
        {
            return this.RemoveAsync(id, null, token);
        }

        /// <inheritdoc />
        public Task RemoveAsync(TCacheId id, string key, CancellationToken token = default)
        {
            var cacheKey = CreateCacheKey(id, key);
            return this.RemoveCacheObjectAsync(cacheKey, token);
        }

        /// <summary>
        /// Gets the object from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The object from the cache</returns>
        protected abstract T GetCacheObject<T>(string key);

        /// <summary>
        /// Gets the object from the cache asynchronously.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The object from the cache</returns>
        protected abstract Task<T> GetCacheObjectAsync<T>(string key, CancellationToken token);

        /// <summary>
        /// Sets the object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        protected abstract void SetCacheObject<T>(string key, T value);

        /// <summary>
        /// Sets the object in the cache asynchronously.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        protected abstract Task SetCacheObjectAsync<T>(string key, T value, CancellationToken token);

        /// <summary>
        /// Sets the object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        protected abstract void SetCacheObject<T>(string key, T value, CacheEntryOptions options);

        /// <summary>
        /// Sets the object in the cache asynchronously.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        protected abstract Task SetCacheObjectAsync<T>(string key, T value, CacheEntryOptions options, CancellationToken token);

        /// <summary>
        /// Refreshes the object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        protected abstract void RefreshCacheObject(string key);

        /// <summary>
        /// Refreshes the object in the cache asynchronously.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        protected abstract Task RefreshCacheObjectAsync(string key, CancellationToken token);

        /// <summary>
        /// Removes the object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        protected abstract void RemoveCacheObject(string key);

        /// <summary>
        /// Removes the object in the cache asynchronously.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        protected abstract Task RemoveCacheObjectAsync(string key, CancellationToken token);

        /// <summary>
        /// Creates the full key to use for the underlying cache implementation.
        /// </summary>
        /// <param name="id">The cache id.</param>
        /// <param name="key">The key of the cache entry.</param>
        /// <returns>The caching key.</returns>
        private static string CreateCacheKey(TCacheId id, string key = null)
        {
            var cacheKey = id.ToString();
            if (!string.IsNullOrWhiteSpace(key))
            {
                cacheKey = $"{cacheKey}_{key}";
            }

            return $"{CacheIdName}:{cacheKey}";
        }
    }
}
