﻿using BindOpen.Data;
using BindOpen.Data.Configuration;
using BindOpen.Extensions.Connecting;
using BindOpen.Extensions.Modeling;
using BindOpen.Extensions.Processing;

namespace BindOpen.Extensions
{
    /// <summary>
    /// This static class provides methods to create extension items.
    /// </summary>
    public static partial class Bdo
    {
        /// <summary>
        /// Creates the instance of the specified definition.
        /// </summary>
        /// <typeparam name="T">The connector class to return.</typeparam>
        /// <param name="config"></param>
        /// <returns>Returns the created connector.</returns>
        public static T NewConnector<T>(
            IBdoConfiguration config)
            where T : class, IBdoConnector, new()
        {
            T connector = new();
            connector.WithConfig(config);
            connector.UpdateFromMeta(config);

            return connector;
        }

        /// <summary>
        /// Creates the instance of the specified definition.
        /// </summary>
        /// <typeparam name="T">The connector class to return.</typeparam>
        /// <param name="config"></param>
        /// <returns>Returns the created connector.</returns>
        public static T NewEntity<T>(
            IBdoConfiguration config)
            where T : class, IBdoEntity, new()
        {
            T entity = new();
            entity.WithConfig(config);
            entity.UpdateFromMeta(config);

            return entity;
        }


        /// <summary>
        /// Creates the instance of the specified definition.
        /// </summary>
        /// <typeparam name="T">The task class to return.</typeparam>
        /// <param name="config"></param>
        /// <returns>Returns the created connector.</returns>
        public static T NewTask<T>(
            IBdoConfiguration config)
            where T : class, IBdoTask, new()
        {
            T task = new();
            task.WithConfig(config);

            return task;
        }
    }
}