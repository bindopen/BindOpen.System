﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using BindOpen.Framework.Core.Application.Scopes;
using BindOpen.Framework.Core.Data.Common;
using BindOpen.Framework.Core.Data.Elements;
using BindOpen.Framework.Core.Data.Items.Source;
using BindOpen.Framework.Core.System.Diagnostics;
using BindOpen.Framework.Core.System.Scripting;
using BindOpen.Framework.Runtime.Application.Security;

namespace BindOpen.Framework.Runtime.Application.Configuration
{
    /// <summary>
    /// This class represents a DTO application configuration.
    /// </summary>
    [XmlType("AppConfiguration", Namespace = "https://bindopen.org/xsd")]
    [XmlRoot("app.config", Namespace = "https://bindopen.org/xsd", IsNullable = false)]
    public class AppConfiguration : Core.Application.Configuration.BaseConfiguration, IAppConfiguration
    {
        // -------------------------------------------------------
        // PROPERTIES
        // -------------------------------------------------------

        #region Properties

        /// <summary>
        /// The credentials of this instance.
        /// </summary>
        [XmlArray("credentials")]
        [XmlArrayItem("credential")]
        public List<ApplicationCredential> Credentials { get; set; } = new List<ApplicationCredential>();

        /// <summary>
        /// The data sources of this instance.
        /// </summary>
        [XmlArray("dataSources")]
        [XmlArrayItem("add")]
        public List<DataSource> DataSources { get; set; } = new List<DataSource>();

        #endregion

        // -------------------------------------------------------------
        // CONSTRUCTORS
        // -------------------------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the AppConfiguration class.
        /// </summary>
        public AppConfiguration()
            : base()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the AppConfiguration class.
        /// </summary>
        /// <param name="items">The items to consider.</param>
        public AppConfiguration(params IDataElement[] items)
            : base(items)
        {
        }

        #endregion

        // --------------------------------------------------
        // SERIALIZATION
        // --------------------------------------------------

        #region Serialization

        /// <summary>
        /// Updates information for storage.
        /// </summary>
        /// <param name="log">The log to update.</param>
        public override void UpdateStorageInfo(ILog log = null)
        {
            base.UpdateStorageInfo(log);

            foreach (ApplicationCredential applicationCredential in Credentials)
                applicationCredential.UpdateStorageInfo(log);

            foreach (DataSource dataSource in DataSources)
                dataSource.UpdateStorageInfo(log);
        }

        /// <summary>
        /// Updates information for runtime.
        /// </summary>
        /// <param name="appScope">The application scope to consider.</param>
        /// <param name="scriptVariableSet">The set of script variables to consider.</param>
        /// <param name="log">The log to update.</param>
        public override void UpdateRuntimeInfo(IAppScope appScope = null, IScriptVariableSet scriptVariableSet = null, ILog log = null)
        {
            base.UpdateRuntimeInfo(appScope, scriptVariableSet, log);

            foreach (ApplicationCredential applicationCredential in Credentials)
                applicationCredential.UpdateRuntimeInfo(appScope, scriptVariableSet, log);

            foreach (DataSource dataSource in DataSources)
                dataSource.UpdateRuntimeInfo(appScope, scriptVariableSet, log);
        }

        #endregion

        // --------------------------------------------------
        // UPDATE, CHECK, REPAIR
        // --------------------------------------------------

        #region Update_Check_Repair

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <typeparam name="T">The application configuration class to consider.</typeparam>
        /// <param name="item">The item to consider.</param>
        /// <param name="specificationAreas">The specification areas to consider.</param>
        /// <param name="updateModes">The update modes to consider.</param>
        /// <returns>Log of the operation.</returns>
        /// <remarks>Put reference collections as null if you do not want to repair this instance.</remarks>
        public override ILog Update<T>(
            T item = default,
            string[] specificationAreas = null,
            UpdateModes[] updateModes = null)
        {
            ILog log = new Log();

            if (item is AppConfiguration configuration)
            {
                log.Append(base.Update(
                    configuration,
                    specificationAreas,
                    updateModes));

                // we update the credentials

                if (configuration.Credentials != null)
                {
                    Credentials = new List<ApplicationCredential>();
                    foreach (ApplicationCredential applicationCredential in configuration.Credentials)
                        Credentials.Add(applicationCredential.Clone() as ApplicationCredential);
                }

                if (configuration.DataSources != null)
                {
                    DataSources = new List<DataSource>();
                    foreach (DataSource dataSource in configuration.DataSources)
                        DataSources.Add(dataSource.Clone() as DataSource);
                }
            }

            return log;
        }

        #endregion

        // ------------------------------------------
        // MISCELLANEOUS
        // ------------------------------------------

        #region Miscellaneous

        /// <summary>
        /// Gets the name of the application instance.
        /// </summary>
        /// <returns>Returns the name of the application instance.</returns>
        public static string __ApplicationInstanceName => (Environment.MachineName ?? "").ToUpper();

        #endregion
    }
}