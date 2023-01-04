﻿using BindOpen.Extensions;
using BindOpen.Data;
using BindOpen.Data.Elements;
using BindOpen.Data.Items;
using BindOpen.Data.Stores;
using BindOpen.Runtime.Tests;
using Bogus;
using NUnit.Framework;
using System.IO;

namespace BindOpen.Runtime.IO.Tests.MasterData.Stores
{
    [TestFixture, Order(101)]
    public class DatasourceDepotTests
    {
        private readonly string _filePath_xml = GlobalVariables.WorkingFolder + "DatasourceDepot.xml";
        private readonly string _filePath_json = GlobalVariables.WorkingFolder + "DatasourceDepot.json";

        private IBdoSourceDepot _datasourceDepot = null;

        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var f = new Faker();
            _testData = new
            {
                host = f.Internet.IpAddress().ToString(),
                port = f.Random.Int(1000),
                isDefaultCredentialsUsed = f.Random.Bool(),
                isSslEnabled = f.Random.Bool(),
                timeout = f.Random.Int(8000),
                login = f.Person.Email,
                password = f.Lorem.Word()
            };
        }

        private void TestBdoDatasourceDepot(IBdoSourceDepot depot)
        {
            Assert.That(depot.HasItem("smtp_default"), "Error with item existence check");
            Assert.That(depot.Get("smtp_default")?.Configurations?.Count == 1, "Bad configuration count");
            Assert.That(depot.Get("smtp_default")?.Configuration?.GetItem<string>("host") == _testData.host, "Bad string");
            Assert.That(depot.Get("smtp_default")?.Configuration?.GetItem<int>("port") == _testData.port, "Bad integer");
            Assert.That(depot.Get("smtp_default")?.Configuration?.GetItem<bool>("isDefaultCredentialsUsed") == _testData.isDefaultCredentialsUsed, "Bad boolean");
            Assert.That(depot.Get("smtp_default")?.Configuration?.GetItem<bool>("isSslEnabled") == _testData.isSslEnabled, "Bad boolean");
            Assert.That(depot.Get("smtp_default")?.Configuration?.GetItem<int>("timeout") == _testData.timeout, "Bad integer");
            Assert.That(depot.Get("smtp_default")?.Configuration?.GetItem<string>("login") == _testData.login, "Bad string");
            Assert.That(depot.Get("smtp_default")?.Configuration?.GetItem<string>("password") == _testData.password, "Bad string");
        }

        [Test, Order(1)]
        public void CreateBdoDatasourceDepotTest()
        {
            _datasourceDepot = BdoItems.NewDatasourceDepot(
                BdoItems.NewDatasource(
                    "smtp_default",
                    DatasourceKind.EmailServer,
                    BdoExtensions.NewConnectorConfiguration(
                        "messages$smtp",
                        BdoElements.NewScalar("host", _testData.host),
                        BdoElements.NewScalar("port", DataValueTypes.Integer, _testData.port),
                        BdoElements.NewScalar("isDefaultCredentialsUsed", DataValueTypes.Boolean, _testData.isDefaultCredentialsUsed),
                        BdoElements.NewScalar("isSslEnabled", DataValueTypes.Boolean, _testData.isSslEnabled),
                        BdoElements.NewScalar("timeout", DataValueTypes.Integer, _testData.timeout),
                        BdoElements.NewScalar("login", _testData.login),
                        BdoElements.NewScalar("password", _testData.password))));

            TestBdoDatasourceDepot(_datasourceDepot);
        }

        // Xml

        [Test, Order(2)]
        public void SaveXmlBdoDatasourceDepotTest()
        {
            if (_datasourceDepot == null)
            {
                CreateBdoDatasourceDepotTest();
            }

            var isSaved = _datasourceDepot.ToDto().SaveXml(_filePath_xml);
            Assert.That(isSaved, "Element set saving failed");

            TestBdoDatasourceDepot(_datasourceDepot);
        }

        [Test, Order(3)]
        public void LoadXmlBdoDatasourceDepotTest()
        {
            if (_datasourceDepot == null || !File.Exists(_filePath_xml))
            {
                SaveXmlBdoDatasourceDepotTest();
            }

            var depot = XmlHelper.LoadXml<BdoDatasourceDepotDto>(_filePath_xml).ToPoco();

            TestBdoDatasourceDepot(depot);
        }

        // Json

        [Test, Order(4)]
        public void SaveJsonBdoDatasourceDepotTest()
        {
            if (_datasourceDepot == null)
            {
                CreateBdoDatasourceDepotTest();
            }

            var isSaved = _datasourceDepot.ToDto().SaveJson(_filePath_json);
            Assert.That(isSaved, "Element set saving failed");

            TestBdoDatasourceDepot(_datasourceDepot);
        }

        [Test, Order(5)]
        public void LoadJsonBdoDatasourceDepotTest()
        {
            if (_datasourceDepot == null || !File.Exists(_filePath_json))
            {
                SaveJsonBdoDatasourceDepotTest();
            }

            var depot = JsonHelper.LoadJson<BdoDatasourceDepotDto>(_filePath_json).ToPoco();

            TestBdoDatasourceDepot(depot);
        }
    }
}