﻿using BindOpen.Framework.Data.Queries;

namespace BindOpen.Framework.Data.Queries
{
    /// <summary>
    /// This class represents a builder of database query.
    /// </summary>
    internal partial class DbQueryBuilder_PostgreSql : DbQueryBuilder
    {
        // System

        /// <summary>
        /// Evaluates the script word $SQLNEWGUID.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        public override string GetSqlText_NewGuid()
        {
            return "gen_random_uuid()";
        }

        /// <summary>
        /// Evaluates the script word $SQLRANDOM.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        public override string GetSqlText_Random()
        {
            return "MD5(random()::text)";
        }
    }
}