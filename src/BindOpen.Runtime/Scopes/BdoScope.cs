﻿using BindOpen.Extensions.Scripting;
using BindOpen.Data.Context;
using BindOpen.Data.Items;
using BindOpen.Data.Stores;
using BindOpen.Runtime.References;
using BindOpen.Runtime.Stores;
using System;
using BindOpen.Logging;

namespace BindOpen.Runtime.Scopes
{
    /// <summary>
    /// This class represents an application scope.
    /// </summary>
    public class BdoScope : BdoItem, IBdoScope
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// The application domain.
        /// </summary>
        public AppDomain AppDomain { get; } = null;

        /// <summary>
        /// The BindOpen extension store of this instance.
        /// </summary>
        public IBdoExtensionStore ExtensionStore { get; set; }

        /// <summary>
        /// The data context of this instance.
        /// </summary>
        public IBdoDataContext Context { get; set; }

        /// <summary>
        /// The data store of this instance.
        /// </summary>
        public IBdoDataStore DataStore { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoScope class.
        /// </summary>
        /// <param name="appDomain">The application domain to instance.</param>
        public BdoScope(AppDomain appDomain = null) : base()
        {
            AppDomain = appDomain ?? AppDomain.CurrentDomain;

            ExtensionStore = new BdoExtensionStore();

            Context = new BdoDataContext();
        }

        #endregion

        // ------------------------------------------
        // MUTATORS
        // ------------------------------------------

        #region Mutators

        /// <summary>
        /// Creates a new script interpreter.
        /// </summary>
        /// <returns>Returns the new script interpreter.</returns>
        public IBdoScriptInterpreter NewScriptInterpreter()
            => BdoScript.CreateInterpreter(this);

        /// <summary>
        /// Loads the specified extensions.
        /// </summary>
        /// <param name="loadOptionsAction">The load options action to consider.</param>
        /// <param name="references">The extension references to consider.</param>
        public bool LoadExtensions(
            Func<IExtensionLoadOptions, bool> loadOptionsAction,
            IBdoExtensionReference[] references,
            IBdoLog log = null)
        {
            var loaded = true;

            IExtensionLoadOptions loadOptions = null;
            if (loadOptionsAction != null)
            {
                loadOptions = new ExtensionLoadOptions();
                loaded &= loadOptionsAction?.Invoke(loadOptions) ?? true;
            }
            var loader = new BdoExtensionStoreLoader(AppDomain, ExtensionStore, loadOptions);
            loaded &= loader.LoadExtensionsInStore(references, log);

            return loaded;
        }

        /// <summary>
        /// Loads the specified extensions.
        /// </summary>
        /// <param name="references">The extension references to consider.</param>
        public bool LoadExtensions(
            IBdoExtensionReference[] references,
            IBdoLog log = null) => LoadExtensions(null, references, log);

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            Context?.Clear();
            DataStore?.Clear();
            ExtensionStore?.Clear();
        }

        #endregion
    }
}