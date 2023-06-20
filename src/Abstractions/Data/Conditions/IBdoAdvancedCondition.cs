﻿using System.Collections.Generic;

namespace BindOpen.System.Data.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoAdvancedCondition : IBdoCondition
    {
        /// <summary>
        /// 
        /// </summary>
        AdvancedConditionKind Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IList<IBdoCondition> Conditions { get; set; }
    }
}