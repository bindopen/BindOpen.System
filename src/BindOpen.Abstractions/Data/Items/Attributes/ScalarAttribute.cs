﻿using BindOpen.Data.Elements;
using System;

namespace BindOpen.Data.Items
{
    /// <summary>
    /// This class represents an scalar attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ScalarAttribute : BdoElementAttribute
    {
        // --------------------------------------------------
        // VARIABLES
        // --------------------------------------------------

        #region Variables

        #endregion

        // --------------------------------------------------
        // PROPERTIES
        // --------------------------------------------------

        #region Properties

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the ScalarAttribute class.
        /// </summary>
        public ScalarAttribute() : base()
        {
        }

        #endregion
    }
}