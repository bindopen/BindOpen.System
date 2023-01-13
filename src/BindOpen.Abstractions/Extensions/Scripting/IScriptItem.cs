﻿using BindOpen.MetaData;
using BindOpen.MetaData.Items;

namespace BindOpen.Extensions.Scripting
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptItem : IBdoItem, ITNamedPoco<IScriptItem>
    {
        /// <summary>
        /// The kind.
        /// </summary>
        ScriptItemKinds Kind { get; set; }

        /// <summary>
        /// The index.
        /// </summary>
        int Index { get; set; }
    }
}