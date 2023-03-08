﻿using BindOpen.Data.Helpers;
using BindOpen.Data.Meta;
using BindOpen.Data.Meta.Reflection;
using BindOpen.Logging;
using BindOpen.Scoping.Scopes;

namespace BindOpen.Extensions.Tasks
{
    /// <summary>
    /// This class represents an application 
    /// </summary>
    public static class BdoScopeExtensions
    {
        /// <summary>
        /// Creates the instance of the specified definition.
        /// </summary>
        /// <param key="scope">The scope to consider.</param>
        /// <param key="config">The config to consider.</param>
        /// <param key="log">The log to consider.</param>
        /// <param key="varSet">The variable element set to use.</param>
        /// <returns>Returns the created task.</returns>
        public static IBdoTask CreateTask(
            this IBdoScope scope,
            IBdoConfiguration config = null,
            IBdoMetaSet varSet = null,
            IBdoLog log = null)
        {
            IBdoTask task = null;

            if (config != null && scope?.Check(true, log: log) == true)
            {
                // we get the task class reference

                IBdoTaskDefinition definition = scope.ExtensionStore.GetDefinition<IBdoTaskDefinition>(config?.DefinitionUniqueName);
                if (definition == null)
                {
                    log?.AddError("Could not retrieve the extension task '" + config.DefinitionUniqueName + "' definition in scope");
                }
                else
                {
                    // we intantiate the task

                    AssemblyHelper.CreateInstance(definition.RuntimeType, out object item, log);

                    if (log?.HasEvent(EventKinds.Error, EventKinds.Exception) != false)
                    {
                        if ((task = item as IBdoTask) != null)
                        {
                            task.UpdateFromMeta(config, true, scope, varSet);
                        }
                        //task.UpdateFromMetaSet<BdoInputAttribute>(config, scope, varSet);
                        //task.UpdateFromMetaSet<BdoOutputAttribute>(config, scope, varSet);
                    }
                }
            }

            return task;
        }

        /// <summary>
        /// Creates the instance of the specified definition.
        /// </summary>
        /// <param key="scope">The scope to consider.</param>
        /// <param key="config">The config to consider.</param>
        /// <param key="log">The log to consider.</param>
        /// <param key="varSet">The variable element set to use.</param>
        /// <typeparam name="T">The entity class to return.</typeparam>
        /// <returns>Returns the created entity.</returns>
        public static T CreateTask<T>(
            this IBdoScope scope,
            IBdoConfiguration config = null,
            IBdoMetaSet varSet = null,
            IBdoLog log = null) where T : BdoTask
        {
            return scope.CreateTask(config, varSet, log) as T;
        }
    }
}
