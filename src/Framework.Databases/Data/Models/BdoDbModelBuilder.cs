﻿using BindOpen.Framework.Data.Helpers.Strings;
using BindOpen.Framework.Data.Queries;
using BindOpen.Framework.Extensions.Carriers;

namespace BindOpen.Framework.Data.Models
{
    /// <summary>
    /// This class represents a database model.
    /// </summary>
    public class BdoDbModelBuilder : IBdoDbModelBuilder
    {
        IBdoDbModel _model = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public BdoDbModelBuilder(IBdoDbModel model)
        {
            _model = model;
        }

        // Tables ---------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoDbModelBuilder AddTable(DbTable table)
            => AddTable(null, table);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoDbModelBuilder AddTable(string name, DbTable table)
        {
            if (table != null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = table.Schema.ConcatenateIfNotEmpty(".") + table.Name;
                }

                (_model as BdoDbModel).TableDictionary.Add(name, table);
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IBdoDbModelBuilder AddTable<T>() where T : class
        {
            return this;
        }

        // Join conditions ---------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoDbModelBuilder AddJoinCondition(DbQueryJoinCondition condition)
            => AddJoinCondition(null, condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoDbModelBuilder AddJoinCondition(string name, DbQueryJoinCondition condition)
        {
            if (condition != null)
            {
                name = !string.IsNullOrEmpty(name) ? name :
                    (condition.Field1?.Schema) + "_" + (condition.Field1?.DataTableAlias ?? condition.Field1?.DataTable)
                    + "_"
                    + (condition.Field2?.Schema) + "_" + (condition.Field2?.DataTableAlias ?? condition.Field2?.DataTable);

                (_model as BdoDbModel).JoinConditionDictionary.Add(name, condition);
            }

            return this;
        }

        // Tuples ---------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public IBdoDbModelBuilder AddTuple(string name, DbField[] fields)
        {
            if (fields != null)
            {
                (_model as BdoDbModel).TupleDictionary.Add(name, fields);
            }

            return this;
        }

        // Queries ---------------------------------------

        /// <summary>
        /// Adds the specified query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoDbModelBuilder AddQuery(IDbQuery query)
            => AddQuery(null, query);

        /// <summary>
        /// Adds the specified query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoDbModelBuilder AddQuery(string name, IDbQuery query)
        {
            if (query != null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = query.GetName();
                }
                (_model as BdoDbModel).QueryDictionary.Add(name, new DbStoredQuery(query, name));
            }
            return this;
        }
    }
}
