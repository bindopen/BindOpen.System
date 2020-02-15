﻿using BindOpen.Data.Common;
using BindOpen.Extensions.Carriers;

namespace BindOpen.Data.Queries
{
    /// <summary>
    /// This class represents the condition of a database query join.
    /// </summary>
    public class DbQueryJoinCondition : IDbQueryJoinCondition
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// The field 1 of this instance.
        /// </summary>
        public DbField Field1 { get; set; }

        /// <summary>
        /// The field 2 of this instance.
        /// </summary>
        public DbField Field2 { get; set; }

        /// <summary>
        /// The operator of this instance.
        /// </summary>
        public DataOperator Operator { get; set; } = DataOperator.Equal;

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the DbQueryJoinCondition class.
        /// </summary>
        public DbQueryJoinCondition()
        {
        }

        #endregion

        // ------------------------------------------
        // OPERATORS
        // ------------------------------------------

        #region Operators

        /// <summary>
        /// Returns the data expression string corresponding to this instance.
        /// </summary>
        public static implicit operator string(DbQueryJoinCondition condition)
        {
            string query = "";

            if (condition != null)
            {
                if (condition.Field1 != null && condition.Field2 != null)
                {
                    switch (condition.Operator)
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
                    query += DbQueryBuilder.GetBdoScript(condition.Field1) + ", " +
                        DbQueryBuilder.GetBdoScript(condition.Field2) + ")";
                }
            }

            return query;
        }

        #endregion
    }
}