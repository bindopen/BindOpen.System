﻿using BindOpen.Data.Meta;

namespace BindOpen.Data
{
    /// <summary>
    /// This static class provides methods to create element specifications.
    /// </summary>
    public static partial class BdoMeta
    {
        // Static creators -------------------------

        /// <summary>
        /// Instantiates a new instance of the BdoElementSet class.
        /// </summary>
        /// <param key="specs">The elems to consider.</param>
        public static BdoSpecList NewSpecList(params IBdoSpec[] specs)
            => NewSpecList<BdoSpecList>(specs);

        // Static T creators -------------------------

        /// <summary>
        /// Instantiates a new instance of the BdoElementSet class.
        /// </summary>
        /// <param key="elems">The elems to consider.</param>
        public static BdoSpecList NewSpecList<T>(params IBdoSpec[] specs)
            where T : class, IBdoSpecSet, new()
        {
            var elemSpecSet = new BdoSpecList()
                .With(specs) as BdoSpecList;

            return elemSpecSet;
        }
    }
}
