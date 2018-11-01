// <copyright file="IDeserialize.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    using System.IO;

    /// <summary>
    /// Interface for Deserialization from an object.
    /// </summary>
    public interface IDeserialize
    {
        /// <summary>Deserializes an object from a file.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="path">Source file path.</param>
        /// <returns>Deserialized object.</returns>
        T DeserializeFromFile<T>(string path);

        /// <summary>Deserializes an object from a stream. Will not close the stream.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input stream.</param>
        /// <returns>Deserialized object.</returns>
        T DeserializeFromStream<T>(Stream input);
    }
}
