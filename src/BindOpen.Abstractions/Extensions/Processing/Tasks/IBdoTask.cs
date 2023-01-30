﻿using BindOpen.Data;
using BindOpen.Data.Meta;
using BindOpen.Logging;
using BindOpen.Runtime.Definition;
using BindOpen.Runtime.Scopes;

namespace BindOpen.Extensions.Processing
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoTask :
        ITBdoExtensionItem<IBdoTask, IBdoTaskDefinition>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scope"></param>
        /// <param name="varSet">The variable element set to consider.</param>
        /// <param name="log"></param>
        /// <param name="taskEntryKinds"></param>
        /// <returns></returns>
        object GetEntryObjectWithName(
            string name,
            IBdoScope scope = null,
            IBdoMetaSet varSet = null,
            IBdoLog log = null,
            params TaskEntryKind[] taskEntryKinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataElementSpecSet"></param>
        /// <param name="taskEntryKind"></param>
        /// <returns></returns>
        bool IsCompatibleWith(IBdoMetaSpecSet dataElementSpecSet, TaskEntryKind taskEntryKind = TaskEntryKind.Any);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationLevel"></param>
        /// <returns></returns>
        bool IsConfigurable(SpecificationLevels specificationLevel = SpecificationLevels.Runtime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativePath"></param>
        IBdoTask UpdateAbsolutePaths(string relativePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="varSet">The variable element set to consider.</param>
        /// <param name="runtimeMode"></param>
        /// <param name="log"></param>
        IBdoTask Execute(
            IBdoScope scope = null,
            IBdoMetaSet varSet = null,
            RuntimeModes runtimeMode = RuntimeModes.Normal,
            IBdoLog log = null);
    }
}