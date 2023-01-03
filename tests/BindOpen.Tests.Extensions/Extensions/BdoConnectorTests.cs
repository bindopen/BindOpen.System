﻿using BindOpen.Extensions;
using BindOpen.Extensions.Connecting;
using BindOpen.Data.Elements;
using BindOpen.Runtime.Tests.Extensions.Connecting;
using NUnit.Framework;

namespace BindOpen.Runtime.Tests.Extensions
{
    [TestFixture, Order(301)]
    public class BdoConnectorTests
    {
        private ConnectorFake _connector = null;

        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testData = BdoConnectorFaker.Fake();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IBdoConnector CreateConnector(dynamic data)
        {
            IBdoConnectorConfiguration config =
                BdoExtensions.NewConnectorConfiguration("tests.core$testConnector")
                .WithItems(
                    BdoElements.NewScalar("host", data.host),
                    BdoElements.NewScalar("port", data.port),
                    BdoElements.NewScalar("isSslEnabled", data.isSslEnabled));

            return BdoExtensions.NewConnector<ConnectorFake>(config);
        }

        [Test, Order(1)]
        public void CreateConnectorTest()
        {
            _connector = CreateConnector(_testData);

            BdoConnectorFaker.AssertFake(_connector, _testData);
        }
    }
}
