﻿using BindOpen.Logging;

namespace BindOpen.Data.Meta
{
    /// <summary>
    /// This class represents a catalog el that is an el whose els are entities.
    /// </summary>
    public partial class BdoMetaSet :
        TBdoSet<IBdoMetaData>,
        IBdoMetaSet
    {
        public virtual void Update(
            IBdoMetaData refItem,
            string[] areas = null,
            UpdateModes[] updateModes = null,
            IBdoBaseLog log = null)
        {
        }
    }
}
