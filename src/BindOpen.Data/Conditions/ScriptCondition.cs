﻿using BindOpen.Data.Items;

namespace BindOpen.Data.Conditions
{
    /// <summary>
    /// This class represents a script condition.
    /// </summary>
    public class ScriptCondition : Condition, IScriptCondition
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the ScriptCondition class.
        /// </summary>
        public ScriptCondition()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the ScriptCondition class.
        /// </summary>
        /// <param name="trueValue">The true value to consider.</param>
        /// <param name="expression">The expression to consider.</param>
        public ScriptCondition(bool trueValue, IBdoExpression expression) : base(trueValue)
        {
            Expression = expression;
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
            var condition = new ScriptCondition
            {
                Expression = Expression.Clone<BdoExpression>()
            };

            return condition;
        }

        #endregion

        // ------------------------------------------
        // IScriptCondition Implementation
        // ------------------------------------------

        #region IScriptCondition

        /// <summary>
        /// Expression script representing the condition.
        /// </summary>
        public IBdoExpression Expression { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IScriptCondition WithExpression(IBdoExpression expression)
        {
            Expression = expression;
            return this;
        }

        #endregion
    }
}