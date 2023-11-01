﻿using BindOpen.Kernel.Data.Meta;
using BindOpen.Kernel.Logging;
using BindOpen.Kernel.Scoping.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace BindOpen.Kernel.Scoping.Connectors
{
    /// <summary>
    /// This interfaces represents a connection.
    /// </summary>
    public interface IBdoConnection : IDisposable
    {
        /// <summary>
        /// Connector.
        /// </summary>
        IBdoConnector Connector { get; }

        /// <summary>
        /// The connection string.
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// The connection timeout.
        /// </summary>
        int ConnectionTimeout { get; }

        /// <summary>
        /// The state.
        /// </summary>
        ConnectionState State { get; }

        // Open / Close -----------------------------

        /// <summary>
        /// Opens a connection.
        /// </summary>
        void Connect(IBdoLog log = null);

        /// <summary>
        /// Closes the existing connection.
        /// </summary>
        void Disconnect(IBdoLog log = null);

        // Push / Pull -----------------------------

        /// <summary>
        /// Pulls entity objects using the specified parameter set.
        /// </summary>
        /// <param name="paramSet">The set of meta parameters.</param>
        /// <returns>Returns the entity objects.</returns>
        IEnumerable<IBdoEntity> Pull(IBdoMetaSet paramSet = null);

        /// <summary>
        /// Pulls entity objects using the specified parameter set.
        /// </summary>
        /// <typeparam name="T">The BindOpen entity class to consider.</typeparam>
        /// <param name="paramSet">The set of meta parameters.</param>
        /// <returns>Returns the entity objects.</returns>
        IEnumerable<T> Pull<T>(IBdoMetaSet paramSet = null)
            where T : IBdoEntity;

        /// <summary>
        /// Pushes the specified entity objects.
        /// </summary>
        /// <param name="entities">The entity object to push.</param>
        /// <returns>Returns True whether the entities have been pushed.</returns>
        bool Push(params IBdoEntity[] entities);
    }
}
