﻿using System;

namespace BindOpen.Extensions.Processing
{
    /// <summary>
    /// This class represents an attribute of routines.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class BdoRoutineAttribute : MetaExtensionAttribute
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
