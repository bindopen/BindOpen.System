﻿using BindOpen.System.Data.Meta;
using BindOpen.System.Scoping.Functions;

namespace BindOpen.System.Tests
{
    /// <summary>
    /// This class represents a database data field.
    /// </summary>
    public static class FunctionFake
    {
        /// <summary>
        /// The boolean value of this instance.
        /// </summary>
        [BdoFunction(Name = "testEqual")]
        public static bool GetTest(
            [BdoParameter(Title = "String value")]
            string stringValue,
            [BdoParameter(Title = "Integer value")]
            int intValue = 10)
            => stringValue == intValue.ToString();
    }
}