// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Minor changes to allow strongly typed cache keys.
namespace Neolution.Abstractions.Caching
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a distributed cache of serialized values with strongly typed access.
    /// </summary>
    /// <typeparam name="TCacheId">The type of the cache identifier.</typeparam>
    [SuppressMessage("Critical Code Smell", "S2360:Optional parameters should not be used", Justification = "Do not rename to stay compatible with the IDistributedCache interface from Microsoft.")]
    [SuppressMessage("Microsoft.Naming", "CA1716: Identifiers should not match keywords", Justification = "Do not rename to stay compatible with the IDistributedCache interface from Microsoft.")]
    public interface IDistributedCache<in TCacheId>
        where TCacheId : struct, Enum
    {
        /// <summary>
        /// Gets a value with the given cache identifier.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <returns>The located value or null.</returns>
        T Get<T>(TCacheId id);

        /// <summary>
        /// Gets a value with the given cache identifier and key.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <returns>The located value or null.</returns>
        T Get<T>(TCacheId id, string key);

        /// <summary>
        /// Gets a value with the given cache identifier.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task" /> that represents the asynchronous operation, containing the located value or null.
        /// </returns>
        Task<T> GetAsync<T>(TCacheId id, CancellationToken token = default);

        /// <summary>
        /// Gets a value with the given cache identifier and key.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task" /> that represents the asynchronous operation, containing the located value or null.
        /// </returns>
        Task<T> GetAsync<T>(TCacheId id, string key, CancellationToken token = default);

        /// <summary>
        /// Sets the value with the given cache identifier.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="value">The value to set in the cache.</param>
        void Set<T>(TCacheId id, T value);

        /// <summary>
        /// Sets the value with the given cache identifier and key.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to set in the cache.</param>
        void Set<T>(TCacheId id, string key, T value);

        /// <summary>
        /// Sets the value with the given cache identifier.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task SetAsync<T>(TCacheId id, T value, CancellationToken token = default);

        /// <summary>
        /// Sets the value with the given cache identifier and key.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task SetAsync<T>(TCacheId id, string key, T value, CancellationToken token = default);

        /// <summary>
        /// Sets the value with the given cache identifier.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        void SetWithOptions<T>(TCacheId id, T value, CacheEntryOptions options);

        /// <summary>
        /// Sets the value with the given cache identifier and key.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        void SetWithOptions<T>(TCacheId id, string key, T value, CacheEntryOptions options);

        /// <summary>
        /// Sets the value with the given cache identifier.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task SetWithOptionsAsync<T>(TCacheId id, T value, CacheEntryOptions options, CancellationToken token = default);

        /// <summary>
        /// Sets the value with the given cache identifier.
        /// </summary>
        /// <typeparam name="T">The type of the cache identifier.</typeparam>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task SetWithOptionsAsync<T>(TCacheId id, string key, T value, CacheEntryOptions options, CancellationToken token = default);

        /// <summary>
        /// Refreshes a value in the cache based on its id, resetting its sliding expiration timeout (if any).
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        void Refresh(TCacheId id);

        /// <summary>
        /// Refreshes a value in the cache based on its id and key, resetting its sliding expiration timeout (if any).
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        void Refresh(TCacheId id, string key);

        /// <summary>
        /// Refreshes a value in the cache based on its id, resetting its sliding expiration timeout (if any).
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        Task RefreshAsync(TCacheId id, CancellationToken token = default);

        /// <summary>
        /// Refreshes a value in the cache based on its id, resetting its sliding expiration timeout (if any).
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task RefreshAsync(TCacheId id, string key, CancellationToken token = default);

        /// <summary>
        /// Removes the value with the given cache identifier.
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        void Remove(TCacheId id);

        /// <summary>
        /// Removes the value with the given cache identifier and key.
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        void Remove(TCacheId id, string key);

        /// <summary>
        /// Removes the value with the given cache identifier.
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        Task RemoveAsync(TCacheId id, CancellationToken token = default);

        /// <summary>
        /// Removes the value with the given cache identifier.
        /// </summary>
        /// <param name="id">An enum value identifying the requested value.</param>
        /// <param name="key">The key.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task RemoveAsync(TCacheId id, string key, CancellationToken token = default);
    }
}
