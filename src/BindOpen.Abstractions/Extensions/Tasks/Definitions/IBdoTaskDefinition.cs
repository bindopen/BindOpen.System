﻿using BindOpen.Data;
using BindOpen.Data.Assemblies;
using BindOpen.Data.Meta;
using System;

namespace BindOpen.Extensions.Tasks
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoTaskDefinition : IBdoExtensionDefinition
    {
        /// <summary>
        /// 
        /// </summary>
        IBdoClassReference ClassReference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ITBdoSet<IBdoSpec> InputSpecDetail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ITBdoSet<IBdoSpec> OutputSpecDetail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Type RuntimeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        float MaximumIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool IsExecutable { get; set; }
    }
}