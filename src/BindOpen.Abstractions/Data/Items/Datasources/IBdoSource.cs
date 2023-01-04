﻿using BindOpen.Extensions.Connecting;
using System.Collections.Generic;

namespace BindOpen.Data.Items
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoSource : ITIdentifiedPoco<IBdoSource>, ITNamedPoco<IBdoSource>, IReferenced
    {
        /// <summary>
        /// 
        /// </summary>
        string InstanceName { get; set; }

        /// <summary>
        /// Sets the specified module name of this instance. 
        /// </summary>
        /// <param name="instanceName">The instance name to consider.</param>
        IBdoSource WithInstanceName(string instanceName);

        /// <summary>
        /// 
        /// </summary>
        bool IsDefault { get; set; }

        /// <summary>
        /// Specifies that this instance is the default. 
        /// </summary>
        IBdoSource AsDefault(bool isDefault = true);

        /// <summary>
        /// 
        /// </summary>
        DatasourceKind Kind { get; set; }

        /// <summary>
        /// Sets the specified kind of this instance. 
        /// </summary>
        /// <param name="kind">The kind to consider.</param>
        IBdoSource WithKind(DatasourceKind kind);

        /// <summary>
        /// 
        /// </summary>
        string ModuleName { get; set; }

        /// <summary>
        /// Sets the specified module name of this instance. 
        /// </summary>
        /// <param name="moduleName">The module name to consider.</param>
        IBdoSource WithModuleName(string moduleName);

        /// <summary>
        /// 
        /// </summary>
        IBdoConnectorConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoConnectorConfiguration> Configurations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IBdoConnectorConfiguration GetConfiguration(string name = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool HasConfiguration(string name = null);

        /// <summary>
        /// Removes the specified connector configuration.
        /// </summary>
        /// <param name="name">The name of the connector configuration to consider.</param>
        IBdoSource RemoveConfiguration(string name);

        /// <summary>
        /// Sets the specified configurations.
        /// </summary>
        /// <param name="configs">The configurations to consider.</param>
        IBdoSource WithConfiguration(params IBdoConnectorConfiguration[] configs);

        /// <summary>
        /// Adds the specified connector configuration.
        /// </summary>
        /// <param name="config">The connector to add.</param>
        IBdoSource AddConfiguration(IBdoConnectorConfiguration config);
    }
}