﻿using BindOpen.Framework.Data.Common;
using BindOpen.Framework.Data.Expression;
using BindOpen.Framework.Extensions.Carriers;

namespace BindOpen.Framework.Data.Queries
{
    /// <summary>
    /// This class represents a factory of basic database query statement.
    /// </summary>
    public static partial class DbFactory
    {
        // From --------------------------------

        /// <summary>
        /// Creates a new From statement.
        /// </summary>
        /// <param name="table">The table to consider.</param>
        /// <returns>Returns a new From statement.</returns>
        public static IDbQueryFromStatement CreateFromStatement(DbTable table)
            => new DbQueryFromStatement()
                .WithJointure(CreateJoinStatement(table));

        // Jointure --------------------------------

        /// <summary>
        /// Creates a new Jointure statement.
        /// </summary>
        /// <param name="table">The table to consider.</param>
        /// <returns>Returns a new From statement.</returns>
        public static IDbQueryJointureStatement CreateJoinStatement(DbTable table)
            => new DbQueryJointureStatement() { Kind = DbQueryJointureKind.None, Table = table };

        /// <summary>
        /// Creates a new Jointure statement.
        /// </summary>
        /// <param name="kind">The kind to consider.</param>
        /// <param name="table">The table to consider.</param>
        /// <param name="condition">The condition to consider.</param>
        /// <returns>Returns a new From statement.</returns>
        public static IDbQueryJointureStatement CreateJoinStatement(DbQueryJointureKind kind, DbTable table, DataExpression condition = null)
            => new DbQueryJointureStatement() { Kind = kind, Table = table, Condition = condition };

        /// <summary>
        /// Creates a new Jointure statement.
        /// </summary>
        /// <param name="kind">The kind to consider.</param>
        /// <param name="table">The table to consider.</param>
        /// <param name="conditionScript">The condition script to consider.</param>
        /// <returns>Returns a new From statement.</returns>
        public static IDbQueryJointureStatement CreateJoinStatement(DbQueryJointureKind kind, DbTable table, string conditionScript)
            => new DbQueryJointureStatement() { Kind = kind, Table = table, Condition = conditionScript.CreateScript() };

        /// <summary>
        /// Creates a new Jointure statement.
        /// </summary>
        /// <param name="kind">The kind to consider.</param>
        /// <param name="table">The table to consider.</param>
        /// <param name="field1">The field1 to consider.</param>
        /// <param name="field2">The field2 to consider.</param>
        /// <param name="operator">The operator to consider.</param>
        public static IDbQueryJointureStatement CreateJoinStatement(DbQueryJointureKind kind, DbTable table, DbField field1, DbField field2, DataOperator _operator = DataOperator.Equal)
        {
            var jointure = CreateJoinStatement(kind, table);

            if (field1 != null && field2 != null)
            {
                string query = "";

                switch (_operator)
                {
                    case DataOperator.Equal:
                        query += "$sqlEq(";
                        break;
                    case DataOperator.Different:
                        query += "$sqlDiff(";
                        break;
                    case DataOperator.Greater:
                        query += "$sqlGt(";
                        break;
                    case DataOperator.GreaterOrEqual:
                        query += "$sqlGte(";
                        break;
                    case DataOperator.Lesser:
                        query += "$sqlLt(";
                        break;
                    case DataOperator.LesserOrEqual:
                        query += "$sqlLte(";
                        break;
                }
                query += "$" +
                   (string.IsNullOrEmpty(field1.DataModule) ? "" : ("sqlDatabase('" + field1.DataModule + "').")) +
                   (string.IsNullOrEmpty(field1.Schema) ? "" : ("sqlSchema('" + field1.Schema + "').")) +
                   (string.IsNullOrEmpty(field1.DataTable) ? "" : ("sqlTable('" + field1.DataTable + "').")) +
                   (string.IsNullOrEmpty(field1.Name) ? "" : ("sqlField('" + field1.Name + "')"));

                query += ", $" +
                   (string.IsNullOrEmpty(field2.DataModule) ? "" : ("sqlDatabase('" + field2.DataModule + "').")) +
                   (string.IsNullOrEmpty(field2.Schema) ? "" : ("sqlSchema('" + field2.Schema + "').")) +
                   (string.IsNullOrEmpty(field2.DataTable) ? "" : ("sqlTable('" + field2.DataTable + "').")) +
                   (string.IsNullOrEmpty(field2.Name) ? "" : ("sqlField('" + field2.Name + "')"));

                query += ")";

                jointure.Condition = query.CreateScript();
            }

            return jointure;
        }
    }
}