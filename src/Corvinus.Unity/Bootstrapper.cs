// <copyright file="Bootstrapper.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Unity
{
    using global::Unity;

    /// <summary>
    /// Unity Bootstrapper Class.
    /// </summary>
    public abstract class Bootstrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
        /// </summary>
        public Bootstrapper()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
        /// </summary>
        /// <param name="assemblyPath">Folder path to assembly directory.</param>
        public Bootstrapper(string assemblyPath)
        {
            this.RegisterAssembliesByPath(assemblyPath);
        }

        /// <summary>
        /// Gets or sets Application Level Unity Container.
        /// </summary>
        public IUnityContainer AppContainer { get; set; } = new UnityContainer();

        /// <summary>
        /// Register types from assemblies in the assemblyPath.
        /// </summary>
        /// <param name="assemblyPath">Folder path to assembly directory.</param>
        public void RegisterAssembliesByPath(string assemblyPath)
        {
            this.AppContainer.RegisterAssemblyTypes(assemblyPath);
        }
    }
}
