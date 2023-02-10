﻿using BindOpen.Data.Meta;
using BindOpen.Logging;
using BindOpen.Runtime.Scopes;

namespace BindOpen.Data
{
    /// <summary>
    /// This class represents a data element set.
    /// </summary>
    public static partial class BdoMetaObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static T UpdateTree<T>(
            this T meta,
            IBdoScope scope = null,
            IBdoLog log = null)
            where T : IBdoMetaObject
        {
            var obj = meta.GetData();
            if (obj != null)
            {
                meta?.With(
                    obj.ToMetaArray(
                        meta.GetClassType(scope, log)));
            }

            return meta;
        }
    }
}
