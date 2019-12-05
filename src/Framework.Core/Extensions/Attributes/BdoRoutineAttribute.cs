﻿using System;

namespace BindOpen.Framework.Core.Extensions.Attributes
{
    /// <summary>
    /// This class represents an attribute of routines.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class BdoRoutineAttribute : BdoExtensionItemAttribute
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the RoutineAttribute class.
        /// </summary>
        public BdoRoutineAttribute() : base()
        {
        }

        #endregion
    }
}
