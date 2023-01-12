﻿using BindOpen.Meta.Elements;
using System;

namespace BindOpen.Meta.Items
{
    /// <summary>
    /// This class represents a parameter attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterAttribute : BdoMetaAttribute
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the ParameterAttribute class.
        /// </summary>
        public ParameterAttribute() : base()
        {
        }

        #endregion
    }
}