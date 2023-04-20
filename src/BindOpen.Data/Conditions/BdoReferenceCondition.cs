﻿namespace BindOpen.Data.Conditions
{
    /// <summary>
    /// This class represents a script condition.
    /// </summary>
    public class BdoReferenceCondition : BdoCondition, IBdoReferenceCondition
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the ReferenceCondition class.
        /// </summary>
        public BdoReferenceCondition()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the ReferenceCondition class.
        /// </summary>
        /// <param key="trueValue">The true value to consider.</param>
        /// <param key="exp">The exp to consider.</param>
        public BdoReferenceCondition(
            IBdoReference exp) : base()
        {
            Reference = exp;
        }

        #endregion

        // ------------------------------------------
        // IDataItem Implementation
        // ------------------------------------------

        #region IDataItem

        /// <summary>
        /// Clones this instance.
        /// </summary>
        public override object Clone(params string[] areas)
        {
            var condition = new BdoReferenceCondition
            {
                Reference = Reference.Clone<BdoReference>()
            };

            return condition;
        }

        #endregion

        // ------------------------------------------
        // IReferenceCondition Implementation
        // ------------------------------------------

        #region IReferenceCondition

        /// <summary>
        /// Expression script representing the condition.
        /// </summary>
        public IBdoReference Reference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param key="exp"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IBdoReferenceCondition WithReference(IBdoReference reference)
        {
            Reference = reference;
            return this;
        }

        #endregion
    }
}