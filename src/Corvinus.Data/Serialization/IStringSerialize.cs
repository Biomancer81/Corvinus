﻿// <copyright file="IStringSerialize.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    /// <summary>
    /// Interface for Serialization to a string.
    /// </summary>
    public interface IStringSerialize
    {
        /// <summary>Serializes an object to a string.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <returns>String the object was serialized to.</returns>
        string SerializeToString(object input);
    }
}
