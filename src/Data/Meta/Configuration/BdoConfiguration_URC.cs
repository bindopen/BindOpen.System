﻿using BindOpen.System.Logging;
using System.Linq;

namespace BindOpen.System.Data.Meta
{
    /// <summary>
    /// This class represents a data item set.
    /// </summary>
    public partial class BdoConfiguration : BdoMetaSet, IBdoConfiguration
    {
        public override void Update(
            ITBdoSet<IBdoMetaData> refItem,
            string[] areas = null,
            UpdateModes[] updateModes = null,
            IBdoLog log = null)
        {
            base.Update(refItem, areas, updateModes, log);

            // we update the children

            if (refItem is IBdoConfiguration refConfig && refConfig._Children?.Any() == true)
            {
                _children ??= BdoData.NewSet<IBdoConfiguration>();

                _children?.Update(refConfig._Children, areas, updateModes, log);
            }
        }
    }
}