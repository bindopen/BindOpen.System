﻿using BindOpen.Framework.Data.Elements;
using System;

namespace BindOpen.Framework.Extensions.Attributes
{
    /// <summary>
    /// This class represents a input property attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TaskInputAttribute : DataElementAttribute
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the TaskInputAttribute class.
        /// </summary>
        public TaskInputAttribute() : base()
        {
        }

        #endregion
    }
}
