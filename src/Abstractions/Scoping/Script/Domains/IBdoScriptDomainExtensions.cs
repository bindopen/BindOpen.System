﻿using BindOpen.System.Data;
using BindOpen.System.Data.Meta;
using BindOpen.System.Logging;

namespace BindOpen.System.Scoping.Script
{
    /// <summary>
    /// This interface represents an named data item.
    /// </summary>
    public static class IBdoScriptDomainExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T WithScope<T>(
            this T function,
            IBdoScope scope)
            where T : IBdoScriptDomain
        {
            if (function != null)
            {
                function.Scope = scope;
            }

            return function;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T WithVariableSet<T>(
            this T function,
            IBdoMetaSet variableSet)
            where T : IBdoScriptDomain
        {
            if (function != null)
            {
                function.VariableSet = variableSet;
            }

            return function;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T WithLog<T>(
            this T function,
            IBdoLog log)
            where T : IBdoScriptDomain
        {
            if (function != null)
            {
                function.Log = log;
            }

            return function;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T WithScriptword<T>(
            this T function,
            IBdoScriptword word)
            where T : IBdoScriptDomain
        {
            if (function != null)
            {
                function.Scriptword = word;
            }

            return function;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param key="assemblyFileName"></param>
        public static bool IsScriptDomain(this BdoDataType dataType)
        {
            return dataType >= typeof(IBdoScriptDomain);
        }
    }
}