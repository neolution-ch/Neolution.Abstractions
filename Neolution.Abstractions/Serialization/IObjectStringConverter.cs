namespace Neolution.Abstractions.Serialization
{
    /// <summary>
    /// Interface for converting objects to string and back.
    /// </summary>
    public interface IObjectStringConverter
    {
        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The specified object, serialized as a string.</returns>
        string SerializeObject(object value);

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="value">The value to deserialize.</param>
        /// <returns>The object, deserialized from the specified string.</returns>
        T DeserializeObject<T>(string value);
    }
}
