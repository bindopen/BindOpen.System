﻿using BindOpen.Data;
using BindOpen.Runtime.Scopes;
using BindOpen.Tests.Runtime;
using NUnit.Framework;

namespace BindOpen.Tests.Extensions
{
    [TestFixture, Order(300)]
    public class BdoFunctionTests
    {
        private readonly string _filePath = Tests.WorkingFolder + "Function.xml";

        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testData = BdoFunctionFaker.Fake();
        }

        [Test, Order(1)]
        public void CreateFunctionFromScopeTest()
        {
            var config =
                BdoConfig.New("tests.core$testFunction")
                .With(
                    BdoMeta.NewScalar("boolValue", _testData.boolValue as bool?),
                    BdoMeta.NewScalar("enumValue", _testData.enumValue as string),
                    BdoMeta.NewScalar("intValue", _testData.intValue as int?),
                    BdoMeta.NewScalar("stringValue", _testData.stringValue as string));

            var result = RuntimeTests.Scope?.CallFunction<bool?>(config);

            Assert.That(result == true, "Bad function result");
        }
    }

}
