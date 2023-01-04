﻿using BindOpen.Data.Elements;
using BindOpen.Runtime.Scopes;
using System.Collections.Generic;
using BindOpen.Logging;

namespace BindOpen.Runtime.Definition
{
    /// <summary>
    /// This delegate represents a handler POST function.
    /// </summary>
    /// <param name="targetObject">The target object to consider.</param>
    /// <param name="sourceBdoElement">The source data element to consider.</param>
    /// <param name="scope">The scope to consider.</param>
    /// <param name="varElementSet">The variable element set to consider.</param>
    /// <param name="alog">The log to consider.</param>
    /// <returns>Returns the source object.</returns>
    public delegate List<object> BdoHandlerPostFunction(
            object targetObject,
            ref IBdoElement sourceBdoElement,
            IBdoScope scope = null,
            IBdoElementSet varElementSet = null,
            IBdoLog alog = null);
}