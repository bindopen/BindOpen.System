﻿using BindOpen.Data.Meta;
using BindOpen.Data;
using BindOpen.Data.Configuration;
using BindOpen.Data.Helpers;
using BindOpen.Data.Items;
using BindOpen.Runtime.Scopes;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using BindOpen.Data.Items;

namespace BindOpen.Hosting.Settings
{
    /// <summary>
    /// This class represents a config.
    /// </summary>
    public class BdoSettings : BdoItem, IBdoSettings
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the TBdoSettings class.
        /// </summary>
        public BdoSettings()
        {
            Configuration = BdoConfig.New();
        }

        /// <summary>
        /// Instantiates a new instance of the TBdoSettings class.
        /// </summary>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="config">The config to consider.</param>
        public BdoSettings(
            IBdoScope scope,
            IBdoConfiguration config)
        {
            Scope = scope;
            Configuration = config;
        }

        #endregion

        // -------------------------------------------------------
        // IBdoSettings Implementation
        // -------------------------------------------------------

        #region IBdoSettings

        /// <summary>
        /// The application scope of this instance.
        /// </summary>
        public IBdoScope Scope { get; set; }

        /// <summary>
        /// The item of this instance.
        /// </summary>
        public IBdoConfiguration Configuration { get; set; }

        /// <summary>
        /// Returns the key of this instance.
        /// </summary>
        /// <returns></returns>
        public string Key()
        {
            return Configuration?.Name;
        }

        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name to consider.</param>
        public T Get<T>(string name)
            where T : class
        {
            return Configuration.GetData<T>(name, Scope);
        }

        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        public object Get(string name)
        {
            return Configuration.GetData(name, Scope);
        }

        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">The calling property name to consider.</param>
        public T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (Configuration == null) return default;

            if (propertyName != null)
            {
                IBdoMetaData element = Configuration.Get(propertyName);
                if (element != null)
                {
                    return (T)Configuration.GetData(propertyName, Scope);
                }
                else
                {
                    _ = GetType().GetPropertyInfo(
                        propertyName,
                        new Type[] { typeof(BdoDataAttribute) },
                        out BdoDataAttribute attribute);

                    if (attribute is BdoDataAttribute)
                    {
                        object value = Configuration.GetData(attribute.Name, Scope);
                        if (value is T t)
                            return t;
                    }
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defaultValue">The default value to consider.</param>
        /// <param name="propertyName">The calling property name to consider.</param>
        public T GetProperty<T>(T defaultValue, [CallerMemberName] string propertyName = null) where T : struct, IConvertible
        {
            if (Configuration == null) return default;

            if (propertyName != null)
            {
                IBdoMetaData element = Configuration.Get(propertyName);
                if (element != null)
                {
                    return (T)Configuration.GetData(propertyName, Scope);
                }
                else
                {
                    _ = GetType().GetPropertyInfo(
                        propertyName,
                        new Type[] { typeof(BdoDataAttribute) },
                        out BdoDataAttribute attribute);

                    if (attribute is BdoDataAttribute)
                        return (Configuration.GetData(attribute.Name, Scope) as string)?.ToEnum<T>(defaultValue) ?? default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <param name="propertyName">The calling property name to consider.</param>
        public void SetProperty(object value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName != null)
            {
                PropertyInfo propertyInfo = GetType().GetPropertyInfo(
                    propertyName,
                    new Type[] { typeof(BdoDataAttribute) },
                    out BdoDataAttribute attribute);

                if (attribute is BdoDataAttribute)
                {
                    Configuration.Add(
                        BdoMeta.NewScalar(
                            attribute.Name,
                            propertyInfo.PropertyType.GetValueType(),
                            value));
                }
            }
        }

        #endregion

        // ------------------------------------------
        // IDISPOSABLE METHODS
        // ------------------------------------------

        #region IDisposable_Methods

        private bool _isDisposed = false;

        /// <summary>
        /// Disposes this instance. 
        /// </summary>
        /// <param name="isDisposing">Indicates whether this instance is disposing</param>
        protected override void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            Scope?.Dispose();

            _isDisposed = true;

            base.Dispose(isDisposing);
        }

        public IBdoScoped WithScope(IBdoScope scope)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
