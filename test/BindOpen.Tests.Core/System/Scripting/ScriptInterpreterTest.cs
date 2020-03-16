﻿using BindOpen.Data.Expression;
using BindOpen.Data.Helpers.Serialization;
using BindOpen.System.Diagnostics;
using BindOpen.System.Scripting;
using NUnit.Framework;
using System;

namespace BindOpen.Tests.Core.System.Diagnostics
{
    [TestFixture, Order(12)]
    public class ScriptInterpreterTest
    {
        private readonly string _script = "$ISEQUAL(\"MYTABLE\", $Text(MYTABLE))";
        private readonly string _interpretedScript = "true";

        [SetUp]
        public void Setup()
        {
        }

        [Test, Order(1)]
        public void TestInterprete()
        {
            var log = new BdoLog();

            string resultScript = "";

            var scriptVariableSet = new ScriptVariableSet();
            resultScript = GlobalVariables.Scope.Interpreter.Interprete(_script, DataExpressionKind.Script, scriptVariableSet, log);

            string xml = "";
            if (log.HasErrorsOrExceptions())
            {
                xml = log.ToXml();
            }
            Assert.That(_interpretedScript.Equals(resultScript, StringComparison.OrdinalIgnoreCase), "Bad script interpretation. Result was '" + xml);
        }
    }
}