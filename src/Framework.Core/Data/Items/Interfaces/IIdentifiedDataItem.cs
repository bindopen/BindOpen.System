﻿using BindOpen.Framework.Core.Data.Items;

namespace BindOpen.Framework.Core.Data.Items
{
    /// <summary>
    /// This interface represents an identified data item.
    /// </summary>
    public interface IIdentifiedDataItem : IDataItem, IIdentified, IReferenced
    {
    }
}
