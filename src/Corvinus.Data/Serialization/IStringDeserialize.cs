// <copyright file="IStringDeserialize.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    /// <summary>
    /// Interface for Deserialization from a string.
    /// </summary>
    public interface IStringDeserialize
    {
        /// <summary>Deserializes an object from a string.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input string.</param>
        /// <returns>Deserialized object.</returns>
        T DeserializeFromString<T>(string input);
    }
}
