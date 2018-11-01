// <copyright file="XmlSerialization.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Provides methods for easily serializing and deserializing objects to xml.
    /// </summary>
    public class XmlSerialization : IDeserialize, IStringDeserialize, ISerialize, IStringSerialize
    {
        /// <summary>Deserializes an object from a XML file.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="path">Source file path.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeFromFile<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (XmlReader xmlReader = XmlReader.Create(path))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }

        /// <summary>Deserializes an object from a XML stream. Will not close the stream.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input stream.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeFromStream<T>(Stream input)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (XmlReader xmlReader = XmlReader.Create(input))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }

        /// <summary>Deserializes an object from a XML string.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input string.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeFromString<T>(string input)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (XmlReader xmlReader = XmlReader.Create(input))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }

        /// <summary>Serializes an object as XML to a file.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="path">Destination file path.</param>
        /// <param name="append">If true and the file exists it will be appended to,
        /// otherwise it will be overwritten.</param>
        public void SerializeToFile(object input, string path, bool append = false)
        {
            Type type = input.GetType();
            if (type.IsSerializable)
            {
                var serializer = new XmlSerializer(type);
                using (TextWriter xmlWriter = new StreamWriter(path, append))
                {
                    serializer.Serialize(xmlWriter, input);
                }
            }
        }

        /// <summary>Serializes an object as XML to a stream. Will not close the stream.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="outStream">Output stream.</param>
        public void SerializeToStream(object input, Stream outStream)
        {
            Type type = input.GetType();
            if (type.IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(type);
                StreamWriter streamWriter = new StreamWriter(
                    outStream,
                    Encoding.UTF8,
                    bufferSize: 4096,
                    leaveOpen: true);

                using (XmlTextWriter xmlWriter = new XmlTextWriter(streamWriter))
                {
                    serializer.Serialize(xmlWriter, input);
                }
            }
        }

        /// <summary>Serializes an object to a XML string.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <returns>String the object was serialized to.</returns>
        public string SerializeToString(object input)
        {
            Type type = input.GetType();

            if (type.IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(type);

                using (StringWriter xmlWriter = new StringWriter())
                {
                    serializer.Serialize(xmlWriter, input);
                    return xmlWriter.ToString();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
