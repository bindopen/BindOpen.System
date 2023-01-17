﻿using BindOpen.MetaData.Elements;
using BindOpen.Runtime.Scopes;
using System.Collections.Generic;
using BindOpen.Logging;

namespace BindOpen.Runtime.Definition
{
    /// <summary>
    /// This delegate represents a handler GET function.
    /// </summary>
    /// <param name="sourceElement">The source element to consider.</param>
    /// <param name="pathDetail">The path detail to consider.</param>
    /// <param name="scope">The scope to consider.</param>
    /// <param name="varElementSet">The variable element set to consider.</param>
    /// <param name="alog">The log to consider.</param>
    /// <returns>Returns the target objects.</returns>
    public delegate List<object> BdoHandlerGetFunction(
            IBdoMetaElement sourceElement = null,
            IBdoMetaElementSet pathDetail = null,
            IBdoScope scope = null,
            IBdoMetaElementSet varElementSet = null,
            IBdoLog alog = null);
}
