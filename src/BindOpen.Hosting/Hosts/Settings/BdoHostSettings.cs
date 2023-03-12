﻿using BindOpen.Data.Helpers;
using BindOpen.Data.Meta;
using BindOpen.Hosting.Settings;
using BindOpen.Scopes.Scopes;
using System.Text.Json.Serialization;

namespace BindOpen.Hosting.Hosts
{
    /// <summary>
    /// This class represents a BindOpen host settings.
    /// </summary>
    public class BdoHostSettings : BdoSettings, IBdoHostSettings
    {
        // -------------------------------------------------------
        // PROPERTIES
        // -------------------------------------------------------

        #region Properties

        // Folders ---------------

        /// <summary>
        /// The library folder path of this instance.
        /// </summary>
        [BdoProperty(Name = "library.folderPath")]
        [JsonPropertyName("library.folderPath")]
        public string LibraryFolderPath { get; internal set; } = (@".\" + BdoDefaultHostPaths.__DefaultLibraryFolderPath).ToPath();

        #endregion

        // -------------------------------------------------------------
        // CONSTRUCTORS
        // -------------------------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoHostSettings class.
        /// </summary>
        public BdoHostSettings()
            : base()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the BdoHostSettings class.
        /// </summary>
        /// <param key="scope">The scope to consider.</param>
        /// <param key="config">The config to consider.</param>
        public BdoHostSettings(
            IBdoScope scope,
            IBdoConfiguration config)
            : base(scope, config)
        {
        }

        #endregion

        // ------------------------------------------
        // MUTATORS
        // ------------------------------------------

        #region Mutators

        /// <summary>
        /// Sets the library folder path.
        /// </summary>
        /// <param key="libraryFolderPath"></param>
        /// <returns>Returns this instance.</returns>
        public IBdoHostSettings WithLibraryFolder(string libraryFolderPath = null)
        {
            LibraryFolderPath = libraryFolderPath?.EndingWith(@"\").ToPath();

            return this;
        }

        #endregion
    }
}