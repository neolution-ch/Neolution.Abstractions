namespace Neolution.Abstractions.Serialization
{
    /// <summary>
    /// Interface for converting objects to string and vice versa.
    /// </summary>
    public interface IStringSerializer
    {
        /// <summary>
        /// Deserializes the specified string to an object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="value">The value to deserialize.</param>
        /// <returns>The object, deserialized from the specified string.</returns>
        T Deserialize<T>(string value);

        /// <summary>
        /// Serializes the specified object to a string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize</typeparam>
        /// <param name="instance">The object to serialize.</param>
        /// <returns>
        /// The specified object, serialized as a string.
        /// </returns>
        string Serialize<T>(T instance);
    }
}
