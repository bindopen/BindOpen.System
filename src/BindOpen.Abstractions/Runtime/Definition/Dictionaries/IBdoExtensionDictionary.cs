﻿using BindOpen.Data.Items;

namespace BindOpen.Runtime.Definition
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoExtensionDictionary :
        ITIdentifiedPoco<IBdoExtensionDictionary>,
        ITNamedPoco<IBdoExtensionDictionary>,
        ITGloballyTitledPoco<IBdoExtensionDictionary>,
        ITGloballyDescribedPoco<IBdoExtensionDictionary>,
        ITStorablePoco<IBdoExtensionDictionary>
    {
    }
}