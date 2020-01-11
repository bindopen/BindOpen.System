﻿using BindOpen.Framework.Data.Depots;
using BindOpen.Framework.Data.Common;
using BindOpen.Framework.Data.Context;
using BindOpen.Framework.Data.Items;
using BindOpen.Framework.Extensions.References;
using BindOpen.Framework.Extensions.Runtime;
using BindOpen.Framework.System.Assemblies.References;
using BindOpen.Framework.System.Diagnostics;
using BindOpen.Framework.System.Scripting;
using System;
using BindOpen.Framework.Data.Stores;

namespace BindOpen.Framework.Application.Scopes
{
    /// <summary>
    /// This interface defines an application scope.
    /// </summary>
    public interface IBdoScope : IDisposable
    {
        /// <summary>
        /// The application domain.
        /// </summary>
        AppDomain AppDomain { get; }

        /// <summary>
        /// The extension item definition store.
        /// </summary>
        IBdoExtensionStore ExtensionStore { get; set; }

        /// <summary>
        /// The data store of this instance.
        /// </summary>
        IBdoDataStore DataStore { get; set; }

        /// <summary>
        /// The data context.
        /// </summary>
        IBdoDataContext Context { get; set; }

        /// <summary>
        /// The script interpreter.
        /// </summary>
        IBdoScriptInterpreter Interpreter { get; set; }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="specificationAreas"></param>
        /// <param name="updateModes"></param>
        /// <returns></returns>
        IBdoLog Update<T>(T item = default, string[] specificationAreas = null, UpdateModes[] updateModes = null) where T : IDataItem;

        /// <summary>
        /// Cheks this instance.
        /// </summary>
        /// <param name="isExtensionStoreChecked"></param>
        /// <param name="isScriptInterpreterChecked"></param>
        /// <param name="isDataContextChecked"></param>
        /// <param name="isDataStoreChecked"></param>
        /// <returns></returns>
        IBdoLog Check(
            bool isExtensionStoreChecked = false,
            bool isScriptInterpreterChecked = false,
            bool isDataContextChecked = false,
            bool isDataStoreChecked = false);

        /// <summary>
        /// Loads the specified extensions.
        /// </summary>
        /// <param name="references">The extension references to consider.</param>
        IBdoLog LoadExtensions(
            params IBdoExtensionReference[] references);

        /// <summary>
        /// Loads the specified extensions.
        /// </summary>
        /// <param name="loadOptionsAction">The load options action to consider.</param>
        /// <param name="references">The extension references to consider.</param>
        IBdoLog LoadExtensions(
            Action<IExtensionLoadOptions> loadOptionsAction,
            params IBdoExtensionReference[] references);

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();
    }
}