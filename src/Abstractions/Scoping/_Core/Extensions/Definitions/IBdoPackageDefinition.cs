﻿using BindOpen.System.Data;
using BindOpen.System.Data.Assemblies;
using System.Collections.Generic;

namespace BindOpen.System.Scoping
{
    /// <summary>
    /// This interface defines the extension definition.
    /// </summary>
    public interface IBdoPackageDefinition : IReferenced,
        IIdentified, INamed,
        IBdoTitled, IBdoDescribed
    {
        /// <summary>
        /// 
        /// </summary>
        string AssemblyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetRootNamespace();

        /// <summary>
        /// 
        /// </summary>
        string GroupName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void Initialize();

        /// <summary>
        /// 
        /// </summary>
        IBdoDictionary ItemIndexFullNameDictionary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string RootNamespace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IList<IBdoAssemblyReference> UsingAssemblyReferences { get; set; }
    }
}