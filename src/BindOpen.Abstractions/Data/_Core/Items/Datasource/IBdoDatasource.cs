﻿using BindOpen.Data.Meta;

namespace BindOpen.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoDatasource :
        IBdoConfigurationSet,
        IBdoNotMetableItem, IIdentified, INamed, IReferenced
    {
        /// <summary>
        /// 
        /// </summary>
        string InstanceName { get; set; }

        /// <summary>
        /// Sets the specified module name of this instance. 
        /// </summary>
        /// <param key="instanceName">The instance name to consider.</param>
        IBdoDatasource WithInstanceName(string instanceName);

        /// <summary>
        /// 
        /// </summary>
        DatasourceKind Kind { get; set; }

        /// <summary>
        /// Sets the specified kind of this instance. 
        /// </summary>
        /// <param key="kind">The kind to consider.</param>
        IBdoDatasource WithKind(DatasourceKind kind);

        /// <summary>
        /// 
        /// </summary>
        string ModuleName { get; set; }

        /// <summary>
        /// Sets the specified module name of this instance. 
        /// </summary>
        /// <param key="moduleName">The module name to consider.</param>
        IBdoDatasource WithModuleName(string moduleName);

        /// <summary>
        /// Sets the specified single item of this instance.
        /// </summary>
        /// <param key="items">The items to apply to this instance.</param>
        /// <remarks>Items of this instance must be allowed and must not be forbidden. Otherwise, the values will be the default ones..</remarks>
        new IBdoDatasource With(params IBdoConfiguration[] items);
    }
}