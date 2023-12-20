﻿using BindOpen.Logging;
using BindOpen.Scoping;
using System;

namespace BindOpen.Data.Assemblies
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoClassReference : IBdoAssemblyReference
    {
        /// <summary>
        /// The library name of this instance.
        /// </summary>
        string ClassName { get; set; }

        Type GetRuntimeType(IBdoScope scope = null, IBdoLog log = null);
    }
}