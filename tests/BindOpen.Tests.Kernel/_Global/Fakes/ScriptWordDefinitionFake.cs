﻿using BindOpen.Data;
using BindOpen.Extensions.Functions;
using BindOpen.Script;
using System;

namespace BindOpen.Tests
{
    /// <summary>
    /// This class represents a script word definition fake.
    /// </summary>
    public static class ScriptWordDefinitionFake
    {
        // ------------------------------------------
        // VARIABLES
        // ------------------------------------------

        #region Variables

        /// <summary>
        /// Evaluates the script word $Constant.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        [BdoFunction(
            Name = "CONSTANT",
            Kind = ScriptItemKinds.Variable,
            Description = "Returns the test constant.",
            CreationDate = "2016-09-14")]
        public static object Var_Constant()
        {
            return "const";
        }

        /// <summary>
        /// Evaluates the script word $TEXT.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        [BdoFunction(
            Name = "Func1",
            Kind = ScriptItemKinds.Function,
            Description = "Test function 1.",
            CreationDate = "2022-06-24")]
        public static object Fun_Func1(IBdoFunctionDomain domain)
        {
            return domain?.Scriptword.GetData<string>(0);
        }

        /// <summary>
        /// Evaluates the script word $ISEQUAL.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        [BdoFunction(
            Name = "Func2",
            Kind = ScriptItemKinds.Function,
            Description = "Test function 2.",
            CreationDate = "2022-06-24",
            Parameter1Name = "value1", Parameter1ValueType = DataValueTypes.Text,
            Parameter2Name = "value2", Parameter2ValueType = DataValueTypes.Text)]
        public static object Fun_Func2(IBdoFunctionDomain domain)
        {
            string value1 = domain?.Scriptword.GetData<string>(0);
            string value2 = domain?.Scriptword.GetData<string>(1);

            return value1.Equals(value2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Evaluates the script word $Func1.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        [BdoFunction(
            Name = "Func3",
            Kind = ScriptItemKinds.Function,
            Description = "Test function 3.",
            CreationDate = "2022-06-24",
            Parameter1Name = "value1", Parameter1ValueType = DataValueTypes.Object,
            Parameter2Name = "value2", Parameter2ValueType = DataValueTypes.Object)]
        public static object Fun_Func3(object value1, object value2)
        {
            return value1?.ToString() == value2?.ToString();
        }

        /// <summary>
        /// Evaluates the script word $Func2.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        [BdoFunction]
        public static object Fun_Func4(IBdoFunctionDomain domain)
        {
            string value = domain?.Scriptword.GetData<string>(0);
            string parentValue = domain?.Scriptword?.Parent.GetData<string>();

            return parentValue + ":" + value;
        }

        /// <summary>
        /// Evaluates the script word $Func5.
        /// </summary>
        /// <returns>The interpreted string value.</returns>
        public static object Fun_Func5(
            IBdoFunctionDomain domain,
            object value1,
            params string[] values)
        {
            string parentValueText = domain?.Scriptword?.Parent?.GetData<string>();
            string valueText = value1?.ToString();
            string valuesText = string.Join('-', values);

            return parentValueText + ":" + valueText + ":" + valuesText;
        }

        #endregion
    }
}