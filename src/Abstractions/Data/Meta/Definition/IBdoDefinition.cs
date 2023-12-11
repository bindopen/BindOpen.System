﻿using BindOpen.Kernel.Data;

namespace BindOpen.Kernel.Data.Meta
{
    /// <summary>
    /// This interface represents a configuration.
    /// </summary>
    public interface IBdoDefinition :
        IBdoSpecSet, ITTreeNode<IBdoDefinition>,
        IBdoTitled, IBdoDescribed,
        IIndexed, IDated, IBdoUsing
    {
    }
}