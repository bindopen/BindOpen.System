﻿using BindOpen.Data;

namespace BindOpen.Scoping.Script
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptItem : IBdoObject, INamed, IIndexed
    {
        /// <summary>
        /// The kind.
        /// </summary>
        ScriptItemKinds Kind { get; set; }

    }
}