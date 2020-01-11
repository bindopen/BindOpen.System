﻿using BindOpen.Framework.Data.Elements;
using BindOpen.Framework.Data.Items;
using BindOpen.Framework.Data.Connections;
using BindOpen.Framework.Data.Queries;
using BindOpen.Framework.Extensions.Attributes;
using BindOpen.Framework.Extensions.Runtime;
using BindOpen.Framework.System.Diagnostics;
using BindOpen.Framework.System.Scripting;
using System;
using System.Data;
using System.Xml.Serialization;

namespace BindOpen.Framework.Databases.Extensions.Connectors
{
    /// <summary>
    /// This class defines a database connector.
    /// </summary>
    public abstract class BdoDbConnector : BdoConnector
    {
        // -----------------------------------------------
        // PROPERTIES
        // -----------------------------------------------

        #region Properties

        /// <summary>
        /// The provider of this instance.
        /// </summary>
        [XmlIgnore()]
        public DbQueryBuilder QueryBuilder { get; set; } = null;

        /// <summary>
        /// The provider of this instance.
        /// </summary>
        [DetailProperty(Name = "provider")]
        public string Provider
        {
            get;
            set;
        }

        /// <summary>
        /// The server address of this instance.
        /// </summary>
        [DetailProperty(Name = "serverAddress")]
        public string ServerAddress
        {
            get;
            set;
        }

        /// <summary>
        /// The initial catalog of this instance.
        /// </summary>
        [DetailProperty(Name = "initialCatalog")]
        public string InitialCatalog
        {
            get;
            set;
        }

        /// <summary>
        /// The integrated security of this instance.
        /// </summary>
        [DetailProperty(Name = "integratedSecurity")]
        public string IntegratedSecurity
        {
            get;
            set;
        }

        /// <summary>
        /// The user name of this instance.
        /// </summary>
        [DetailProperty(Name = "userName")]
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// The password of this instance.
        /// </summary>
        [DetailProperty(Name = "password")]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// The database kind of this instance.
        /// </summary>
        [DetailProperty(Name = "databaseKind")]
        public BdoDbConnectorKind DatabaseConnectorKind
        {
            get;
            set;
        }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the DatabaseConnector class.
        /// </summary>
        protected BdoDbConnector() : base()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the DatabaseConnector class.
        /// </summary>
        /// <param name="name">The name of this instance.</param>
        /// <param name="connectionString">The connection string to consider.</param>
        protected BdoDbConnector(
            string name, string connectionString = null) : base(name, connectionString)
        {
        }

        #endregion

        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors

        /// <summary>
        /// Creates a new connection.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        public new abstract IBdoDbConnection CreateConnection(IBdoLog log = null);

        /// <summary>
        /// Updates the connection string.
        /// </summary>
        /// <param name="connectionString">The connection string to consider.</param>
        /// <returns>Returns a clone of this instance.</returns>
        public override void UpdateConnectionString(string connectionString = null)
        {
            base.UpdateConnectionString(connectionString);
            DictionaryDataItem item = DictionaryDataItem.Create(connectionString);

            Provider = item.GetContent("Provider").Trim().ToLower();
            DatabaseConnectorKind = GuesKind();
            ServerAddress = item.GetContent("Data Source");
            InitialCatalog = item.GetContent("Initial Catalog");
            UserName = item.GetContent("User Id");
            Password = item.GetContent("Password");
        }

        // SQL commands

        /// <summary>
        /// Gets the SQL text of the specified query.
        /// </summary>
        /// <param name="query">The query to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <returns>Returns the SQL text of the specified query.</returns>
        public string CreateCommandText(
            IDbQuery query,
            IBdoScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null) => CreateCommandText(query, false, scriptVariableSet, log);

        /// <summary>
        /// Gets the SQL text of the specified query.
        /// </summary>
        /// <param name="query">The query to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="isParametersInjected">Indicates whether parameters are replaced.</param>
        /// <returns>Returns the SQL text of the specified query.</returns>
        public string CreateCommandText(
            IDbQuery query,
            bool isParametersInjected = false,
            IBdoScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null) => CreateCommandText(query, null, isParametersInjected, scriptVariableSet, log);

        /// <summary>
        /// Gets the SQL text of the specified query.
        /// </summary>
        /// <param name="query">The query to consider.</param>
        /// <param name="parameterSet">The parameter elements to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="isParametersInjected">Indicates whether parameters are replaced.</param>
        /// <returns>Returns the SQL text of the specified query.</returns>
        public string CreateCommandText(
            IDbQuery query,
            IDataElementSet parameterSet,
            IBdoScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null) => CreateCommandText(query, null, false, scriptVariableSet, log);

        /// <summary>
        /// Gets the SQL text of the specified query.
        /// </summary>
        /// <param name="query">The query to consider.</param>
        /// <param name="parameterSet">The parameter set to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="isParametersInjected">Indicates whether parameters are replaced.</param>
        /// <returns>Returns the SQL text of the specified query.</returns>
        public string CreateCommandText(
            IDbQuery query,
            IDataElementSet parameterSet,
            bool isParametersInjected = false,
            IBdoScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null)
        {
            string sqlText = "";

            if (QueryBuilder == null)
                log.AddError("Data builder missing");
            else
                sqlText = QueryBuilder.Build(query, log, parameterSet, isParametersInjected, scriptVariableSet);

            return sqlText;
        }

        /// <summary>
        /// Creates a command from the specified query.
        /// </summary>
        /// <param name="query">The query to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <returns>Returns the database command.</returns>
        public IDbCommand CreateCommand(
            IDbQuery query,
            IBdoScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null) => CreateCommand(query, null, scriptVariableSet, log);

        /// <summary>
        /// Creates a command from the specified query.
        /// </summary>
        /// <param name="query">The query to consider.</param>
        /// <param name="parameterSet">The parameter elements to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <returns>Returns the database command.</returns>
        public abstract IDbCommand CreateCommand(
            IDbQuery query,
            IDataElementSet parameterSet,
            IBdoScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null);

        #endregion

        // ------------------------------------------
        // DATABASE MANAGEMENT
        // ------------------------------------------

        #region Database Management

        // ------------------------------------------------

        /// <summary>
        /// Gets the database connector kind from the specified connection string.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The database provider  of the specified connection string.</returns>
        public static BdoDbConnectorKind GuessKind(string connectionString)
        {
            connectionString = connectionString.Trim();

            if (connectionString.IndexOf("SQLOLEDB", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return BdoDbConnectorKind.MSSqlServer;
            }
            else if (connectionString.IndexOf("MSDASQL", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return BdoDbConnectorKind.MySQL;
            }
            else if (connectionString.IndexOf("MSDAORA", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return BdoDbConnectorKind.Oracle;
            }
            //else if ((connectionString.ToUpper().Contains("MICROSOFT.JET.OLEDB.4.0")) &
            //    (connectionString.Contains("EXTENDED PROPERTIES=\"EXCEL")))
            //    databaseKind = ConnectorKind_database.Excel;
            //else if ((connectionString.ToUpper().Contains("MICROSOFT.JET.OLEDB.4.0")) &
            //    (connectionString.Contains("EXTENDED PROPERTIES=\"TEXT")))
            //    databaseKind = ConnectorKind_database.TextFiles;
            else if (connectionString.IndexOf("POSTGRESQL", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return BdoDbConnectorKind.PostgreSql;
            }

            return BdoDbConnectorKind.Any;
        }

        /// <summary>
        /// Guesses the database connector kind of this instance.
        /// </summary>
        /// <returns>The database connector kind of this instance.</returns>
        public BdoDbConnectorKind GuesKind()
        {
            return BdoDbConnector.GuessKind(ConnectionString);
        }

        #endregion
    }
}
