// <copyright file="ISerialize.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    using System.IO;

    /// <summary>
    /// Interface for Serialization to an object.
    /// </summary>
    public interface ISerialize
    {
        /// <summary>Serializes an object to a file.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="path">Destination file path.</param>
        /// <param name="append">If true and the file exists it will be appended to,
        /// otherwise it will be overwritten.</param>
        void SerializeToFile(object input, string path, bool append = false);

        /// <summary>Serializes an object to a stream. Will not close the stream.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="outStream">Output stream.</param>
        void SerializeToStream(object input, Stream outStream);
    }
}
