﻿using BindOpen.Data.Meta;
using System.Linq;

namespace BindOpen.Data
{
    /// <summary>
    /// This static class provides methods to create data element set.
    /// </summary>
    public static partial class BdoMeta
    {
        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet()
            => NewSet<BdoMetaSet>();

        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="elems">The parameters to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet(params IBdoMetaData[] elems)
            => NewSet<BdoMetaSet>(elems);

        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="pairs">The pairs to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet(params (string Name, object Value)[] pairs)
            => NewSet<BdoMetaSet>(pairs);

        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="pairs">The pairs to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet(params (string Name, DataValueTypes ValueType, object Value)[] triplets)
            => NewSet<BdoMetaSet>(triplets);


        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="objects">The parameters to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet(params object[] objects)
            => NewSet<BdoMetaSet>(objects);

        /// <summary>
        /// Creates a new instance of the IBdoElementSet class.
        /// </summary>
        /// <param name="stringObject">The string to consider.</param>
        /// <returns>The collection.</returns>
        public static BdoMetaSet NewSet(string stringObject)
            => NewSet<BdoMetaSet>(stringObject);

        // Static T creators -------------------------

        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet<T>()
            where T : class, IBdoMetaSet, new()
        {
            return BdoData.NewItemSet<BdoMetaSet, IBdoMetaData>();
        }

        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="elems">The parameters to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet<T>(params IBdoMetaData[] elems)
            where T : class, IBdoMetaSet, new()
        {
            var metaSet = NewSet<T>();
            metaSet.WithItems(elems);

            return metaSet;
        }

        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="pairs">The pairs to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet<T>(params (string Name, object Value)[] pairs)
            where T : class, IBdoMetaSet, new()
        {
            var metaSet = NewSet<T>();
            metaSet.WithItems(pairs.Select(q => BdoMeta.New(q.Name, q.Value)).ToArray());

            return metaSet;
        }

        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="pairs">The pairs to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet<T>(params (string Name, DataValueTypes ValueType, object Value)[] triplets)
            where T : class, IBdoMetaSet, new()
        {
            var metaSet = NewSet<T>();
            metaSet.WithItems(triplets.Select(q => BdoMeta.New(q.Name, q.ValueType, q.Value)).ToArray());

            return metaSet;
        }


        /// <summary>
        /// Defines the parameters of this instance.
        /// </summary>
        /// <param name="objects">The parameters to consider.</param>
        /// <returns>Return this instance.</returns>
        public static BdoMetaSet NewSet<T>(params object[] objects)
            where T : class, IBdoMetaSet, new()
        {
            var index = 0;
            return NewSet<T>(objects?.Select(p =>
            {
                var scalar = BdoMeta.NewScalar(DataValueTypes.Any, p);
                scalar.WithIndex(++index);
                return scalar;
            }).ToArray());
        }

        /// <summary>
        /// Creates a new instance of the IBdoElementSet class.
        /// </summary>
        /// <param name="stringObject">The string to consider.</param>
        /// <returns>The collection.</returns>
        public static BdoMetaSet NewSet<T>(
            string stringObject)
            where T : class, IBdoMetaSet, new()
        {
            var metaSet = new BdoMetaSet();
            if (stringObject != null)
            {
                foreach (var subString in stringObject.Split(';'))
                {
                    if (subString.IndexOf("=") > 0)
                    {
                        int i = subString.IndexOf("=");
                        metaSet.Add(
                            BdoMeta.NewScalar(
                                subString[..i],
                                DataValueTypes.Text,
                                subString[(i + 1)..]));
                    }
                }
            }
            return metaSet;
        }
    }
}
