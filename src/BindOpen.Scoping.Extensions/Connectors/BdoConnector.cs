﻿using BindOpen.Scoping.Data.Meta;
using BindOpen.Logging;

namespace BindOpen.Scoping.Extensions.Connectors
{
    /// <summary>
    /// This class represents a connector.
    /// </summary>
    public abstract class BdoConnector : BdoExtension,
        IBdoConnector
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoConnector class.
        /// </summary>
        protected BdoConnector() : base()
        {
        }

        #endregion

        // ------------------------------------------
        // IBdoConnector Implementation
        // ------------------------------------------

        #region IBdoConnector

        /// <summary>
        /// The connection string of this instance.
        /// </summary>
        [BdoProperty("connectionString")]
        public string ConnectionString { get; set; }


        /// <summary>
        /// The connection string of this instance.
        /// </summary>
        [BdoProperty("connectionTimeOut")]
        public int ConnectionTimeOut { get; set; }

        /// <summary>
        /// Creates a new connection.
        /// </summary>
        /// <param key="log">The log to consider.</param>
        public abstract IBdoConnection NewConnection(IBdoLog log = null);

        #endregion
    }
}