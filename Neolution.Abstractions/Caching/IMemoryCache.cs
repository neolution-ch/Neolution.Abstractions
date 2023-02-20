// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Minor changes to allow strongly typed cache keys.
namespace Neolution.Abstractions.Caching
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Interface that provides strongly typed access for memory caching implementations.
    /// </summary>
    /// <typeparam name="TCacheId">The cache identifier enum.</typeparam>
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Do not rename to stay compatible with the IDistributedCache interface from Microsoft.")]
    public interface IMemoryCache<in TCacheId>
        where TCacheId : struct, Enum
    {
        /// <summary>
        /// Gets the item associated with this id if present.
        /// </summary>
        /// <typeparam name="T">The type of the cached object.</typeparam>
        /// <param name="id">The cache identifier.</param>
        /// <returns>The object from cache.</returns>
        T Get<T>(TCacheId id);

        /// <summary>
        /// Gets the item associated with this id and key if present.
        /// </summary>
        /// <typeparam name="T">The type of the cached object.</typeparam>
        /// <param name="id">The cache identifier.</param>
        /// <param name="key">An object identifying the requested entry.</param>
        /// <returns>The object from cache.</returns>
        T Get<T>(TCacheId id, string key);

        /// <summary>
        /// Create or overwrite an entry in the cache.
        /// </summary>
        /// <typeparam name="T">The type of the cached object.</typeparam>
        /// <param name="id">The cache identifier.</param>
        /// <param name="value">The value to cache.</param>
        void Set<T>(TCacheId id, T value);

        /// <summary>
        /// Create or overwrite an entry in the cache.
        /// </summary>
        /// <typeparam name="T">The type of the cached object.</typeparam>
        /// <param name="id">The cache identifier.</param>
        /// <param name="key">An object identifying the entry.</param>
        /// <param name="value">The value to cache.</param>
        void Set<T>(TCacheId id, string key, T value);

        /// <summary>
        /// Removes the object associated with the given id.
        /// </summary>
        /// <param name="id">The cache identifier.</param>
        void Remove(TCacheId id);

        /// <summary>
        /// Removes the object associated with the given id and key.
        /// </summary>
        /// <param name="id">The cache identifier.</param>
        /// <param name="key">An object identifying the entry.</param>
        void Remove(TCacheId id, string key);
    }
}
