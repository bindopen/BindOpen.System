﻿namespace BindOpen.Data
{
    /// <summary>
    /// This interface defines a data expression.
    /// </summary>
    public interface IBdoExpression : IBdoObjectNotMetable, IIdentified, IReferenced
    {
        /// <summary>
        /// The kind.
        /// </summary>
        BdoExpressionKind ExpressionKind { get; set; }

        /// <summary>
        /// The text.
        /// </summary>
        string Text { get; set; }
    }
}