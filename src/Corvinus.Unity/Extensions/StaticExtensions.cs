// <copyright file="StaticExtensions.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Unity
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using global::Unity;

    /// <summary>
    /// Static Extension Methods for Unity Framework.
    /// </summary>
    public static class StaticExtensions
    {
        /// <summary>
        /// A static method for registering all types in an assembly for Unity.
        /// </summary>
        /// <param name="unityContainer"><see cref="IUnityContainer"/>.</param>
        /// <param name="assemblyPath"><see cref="string"/> containing the path to your assembly folder.</param>
        public static void RegisterAssemblyTypes(this IUnityContainer unityContainer, string assemblyPath)
        {
            string[] dependencies = Directory.GetFiles(assemblyPath);

            Dictionary<Type, Type> typeMappings = new Dictionary<Type, Type>();

            foreach (string fileName in dependencies)
            {
                string assemblyName = Path.GetFileNameWithoutExtension(fileName);
                if (assemblyName != null)
                {
                    Assembly pluginAssembly = Assembly.LoadFile(fileName);

                    foreach (Type type in pluginAssembly.GetTypes())
                    {
                        if (type.IsPublic)
                        {
                            if (!type.IsAbstract)
                            {
                                Type[] typeInterfaces = type.GetInterfaces();
                                foreach (Type typeInterface in typeInterfaces)
                                {
                                    if (typeMappings.ContainsKey(typeInterface))
                                    {
                                        // throw new DuplicateTypeMappingException(typeInterface.Name, typeInterface, pluginMappings[typeInterface], pluginType);
                                    }
                                    else
                                    {
                                        typeMappings.Add(typeInterface, type);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (var mapping in typeMappings)
            {
                unityContainer.RegisterType(mapping.Key, mapping.Value);
            }
        }
    }
}
