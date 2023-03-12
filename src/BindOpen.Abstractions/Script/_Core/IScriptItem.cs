﻿using BindOpen.Data;

namespace BindOpen.Script
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptItem : IBdoItem, INamed
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