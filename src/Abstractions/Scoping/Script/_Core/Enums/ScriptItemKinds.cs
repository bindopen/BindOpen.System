﻿using System;

namespace BindOpen.System.Scoping.Script
{
    /// <summary>
    /// This enumeration lists the possible kinds of script items.
    /// </summary>
    [Flags]
    public enum ScriptItemKinds
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Function.
        /// </summary>
        Function = 1 << 0,

        /// <summary>
        /// Variable.
        /// </summary>
        Variable = 1 << 1,

        /// <summary>
        /// Text.
        /// </summary>
        Text = 1 << 2,

        /// <summary>
        /// Syntax.
        /// </summary>
        Syntax = 1 << 3,

        /// <summary>
        /// Literal.
        /// </summary>
        Literal = 1 << 4,

        /// <summary>
        /// Any.
        /// </summary>
        Any = Function | Literal | Syntax | Text | Variable
    }
}