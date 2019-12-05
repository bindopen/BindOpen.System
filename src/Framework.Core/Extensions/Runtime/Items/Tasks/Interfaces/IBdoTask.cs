﻿using BindOpen.Framework.Core.Application.Scopes;
using BindOpen.Framework.Core.Data.Common;
using BindOpen.Framework.Core.Data.Elements.Sets;
using BindOpen.Framework.Core.Extensions.Definition.Items;
using BindOpen.Framework.Core.System.Diagnostics;
using BindOpen.Framework.Core.System.Scripting;

namespace BindOpen.Framework.Core.Extensions.Runtime.Items
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoTask : ITBdoExtensionItem<IBdoTaskDefinition>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scope"></param>
        /// <param name="scriptVariableSet"></param>
        /// <param name="log"></param>
        /// <param name="taskEntryKinds"></param>
        /// <returns></returns>
        object GetEntryObjectWithName(
            string name,
            IBdoScope scope = null,
            IBdoScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null,
            params TaskEntryKind[] taskEntryKinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataElementSpecSet"></param>
        /// <param name="taskEntryKind"></param>
        /// <returns></returns>
        bool IsCompatibleWith(IDataElementSpecSet dataElementSpecSet, TaskEntryKind taskEntryKind = TaskEntryKind.Any);

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
        void UpdateAbsolutePaths(string relativePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="scope"></param>
        /// <param name="scriptVariableSet"></param>
        /// <param name="runtimeMode"></param>
        void Execute(
            IBdoLog log,
            IBdoScope scope = null,
            IBdoScriptVariableSet scriptVariableSet = null,
            RuntimeMode runtimeMode = RuntimeMode.Normal);
    }
}