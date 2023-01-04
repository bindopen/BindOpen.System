﻿using BindOpen.Data.Stores;
using NUnit.Framework;

namespace BindOpen.Runtime.Hosting.Tests
{
    [TestFixture]
    public class AppHostTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAppHost()
        {
            Assert.That(GlobalVariables.AppHost.IsLoaded, "Application host not load failed");
        }

        [Test]
        public void TestAppHostWithNoOptions()
        {
            var appHost = BdoHosting.NewHost();

            Assert.That(appHost.IsLoaded, "Application host not load failed");
        }

        [Test]
        public void TestAppHostWithDatasources()
        {
            var appHost = BdoHosting.NewHost(
                options => options
                    .AddDataStore(store => store
                        .RegisterDatasources(m => m
                            .AddFromConnectionStrings(GlobalVariables.NetCoreConfiguration))));

            Assert.That(appHost.IsLoaded, "Application host not load failed");

            var datasourceDepot = appHost.GetDatasourceDepot();

            var datasourceA = datasourceDepot?["db.testA"];
            Assert.That(datasourceA?.Name == "db.testA", "Bad data source loading");

            Assert.That(datasourceDepot?.GetConnectionString("db.testA") != null,
                "Bad data source loading");

            Assert.That(datasourceDepot?.GetConnectionString("db.testA", "database.mssqlserver$client") != null,
                "Bad data source loading");

            var datasourceB = datasourceDepot?["db.testB"];
            Assert.That(datasourceB?.Name == "db.testB", "Bad data source loading from .NET Core configuration");

            Assert.That(datasourceDepot?.GetConnectionString("db.testB") != null,
                "Bad data source loading from .NET Core configuration");

            Assert.That(datasourceDepot.Get()?.Name == "db.testA", "Bad data source loading");

            Assert.That(datasourceDepot.GetConnectionString() != null, "Bad data source loading");
        }
    }
}