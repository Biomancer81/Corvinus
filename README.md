# Corvinus Framework
The Corvinus Framework is working toward creating a variety of libraries to ease the use of development and reduce code dupilication.

## Corvinus.Data
### 1. Corvinus.Data.Serialization
  * Seriaization Methods for conversion of objects to/from JSON, XML and Binary.
  * Includes the following:
    1. Corvinus.Data.Serialization.JsonSerialization
      ```
      void SerializeToFile(object input, string path, bool append = false)
      void SerializeToStream(object input, Stream stream)
      stirng SerializeToString(object input)
      T DeserializeFromFile<T>(string path)
      T DeserializeFromStream<T>(stream input)
      T DeserializeFromString<T>(string input)
      ```
    1. Corvinus.Data.Serialization.XmlSerialization
      ```
      void SerializeToFile(object input, string path, bool append = false)
      void SerializeToStream(object input, Stream stream)
      string SerializeToString(object input)
      T DeserializeFromFile<T>(string path)
      T DeserializeFromStream<T>(stream input)
      T DeserializeFromString<T>(string input)
      ```
    1. Corvinus.Data.Serialization.BinarySerialization
      ```
      void SerializeToFile(object input, string path, bool append = false)
      void SerializeToStream(object input, Stream stream)
      T DeserializeFromFile<T>(string path)
      T DeserializeFromStream<T>(stream input)
      ```
