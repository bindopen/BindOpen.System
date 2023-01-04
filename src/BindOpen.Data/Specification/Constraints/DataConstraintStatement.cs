﻿using BindOpen.Extensions.Processing;
using BindOpen.Data.Elements;
using BindOpen.Data.Items;

namespace BindOpen.Data.Specification
{
    /// <summary>
    /// This class represents the data constraint statement.
    /// </summary>
    public class DataConstraintStatement : TBdoItemSet<IBdoRoutineConfiguration>,
        IDataConstraintStatement
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the DataConstraintStatement class.
        /// </summary>
        public DataConstraintStatement()
        {
        }

        #endregion

        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors

        /// <summary>
        /// Returns the constraint with the specified name.
        /// </summary>
        /// <param name="name">The name of the item to return.</param>
        /// <returns>Returns the item with the specified name.</returns>
        public IBdoRoutineConfiguration GetConstraint(string name)
        {
            return Get(name);
        }

        /// <summary>
        /// Returns the constraint parameter.
        /// </summary>
        /// <param name="constraintName">The name of the constraint to return.</param>
        /// <param name="parameterName">The name of the parameter to return.</param>
        /// <returns>Returns the specified constrainst parameter.</returns>
        public IBdoElement GetConstraintParameter(
            string constraintName,
            string parameterName = null)
        {
            IBdoRoutineConfiguration routine = GetConstraint(constraintName);
            return routine?[parameterName];
        }

        /// <summary>
        /// Returns the constraint parameter value.
        /// </summary>
        /// <param name="constraintName">The name of the constraint to return.</param>
        /// <param name="parameterName">The name of the parameter to return.</param>
        /// <returns>Returns the specified constrainst parameter.</returns>
        public object GetConstraintParameterValue(
            string constraintName,
            string parameterName = null)
        {
            IBdoRoutineConfiguration routine = GetConstraint(constraintName);
            return routine?.GetItem(parameterName);
        }

        #endregion

        // --------------------------------------------------
        // CLONING
        // --------------------------------------------------

        #region Cloning

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns a cloned instance.</returns>
        public override object Clone(params string[] areas)
        {
            DataConstraintStatement dataConstraintStatement = base.Clone(areas) as DataConstraintStatement;
            return dataConstraintStatement;
        }

        #endregion
    }
}