﻿using BindOpen.MetaData.Elements;
using BindOpen.MetaData.Items;
using System;

namespace BindOpen.Runtime.Definition
{
    /// <summary>
    /// This interface defines the carrier definition.
    /// </summary>
    public interface IBdoCarrierDefinition : IBdoExtensionItemDefinition
    {
        /// <summary>
        /// 
        /// </summary>
        Type RuntimeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DatasourceKind DatasourceKind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ItemClass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IBdoMetaElementSpecSet DetailSpec { get; set; }
    }
}