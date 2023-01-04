﻿using BindOpen.Extensions.Modeling;
using BindOpen.Data;
using BindOpen.Data.Elements;
using BindOpen.Runtime.Tests;
using Bogus;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace BindOpen.Runtime.IO.Tests.MasterData.Elements
{
    [TestFixture, Order(201)]
    public class CollectionElementSetTests
    {
        private readonly string _filePath = GlobalVariables.WorkingFolder + "CollectionElementSet.xml";

        private dynamic _testData;

        private IBdoElementSet _collectionElementSet = null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var f = new Faker();
            _testData = new
            {
                collectionStringValues1 = Enumerable.Range(0, 10).Select(p => (Key: f.Random.Word(), Value: f.Random.Word())).ToArray(),
                collectionStringValues2 = Enumerable.Range(0, 10).Select(p => (Key: f.Random.Word(), Value: f.Random.Word())).ToArray(),
                collectionDoubleValues1 = Enumerable.Range(0, 10).Select(p => (Key: f.Random.Word(), Value: f.Random.Double())).ToArray(),
                collectionDoubleValues2 = Enumerable.Range(0, 10).Select(p => (Key: f.Random.Word(), Value: f.Random.Double())).ToArray(),
            };
        }

        private static void Test(IBdoElementSet elementSet)
        {
            _ = elementSet.GetItem<ICarrierElement>("collection1");
            _ = elementSet.Get<ICarrierElement>(1);

            Assert.That(elementSet?.Count == 2, "Bad collection element set - Count");
        }

        [Test, Order(1)]
        public void CreateCollectionElementSetTest()
        {
            var collectionElement1 = BdoElements.NewCollection(
                "collection1",
                (((string Key, string Value)[])_testData.collectionStringValues1).Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray()
            );
            collectionElement1.Add(
                (((string Key, double Value)[])_testData.collectionDoubleValues1).Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray());

            var collectionElement2 = BdoElements.NewCollection(
                "collection2",
                (((string Key, string Value)[])_testData.collectionStringValues2).Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray()
            );
            collectionElement2.Add(
                (((string Key, double Value)[])_testData.collectionDoubleValues2).Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray());
            collectionElement2.Add(
                BdoElements.NewCarrier("collection2", "tests.core$testCarrier")
                    .WithItem(
                        (new { path = "file2.txt" }).AsElementSet<BdoCarrierConfiguration>()));

            _collectionElementSet = BdoElements.NewSet(collectionElement1, collectionElement2);

            Test(_collectionElementSet);
        }

        [Test, Order(3)]
        public void SaveBdoElementSetTest()
        {
            if (_collectionElementSet == null)
            {
                CreateCollectionElementSetTest();
            }

            var isSaved = _collectionElementSet.ToDto().SaveXml(_filePath);

            Assert.That(isSaved, "Element set saving failed");
        }

        [Test, Order(4)]
        public void LoadBdoElementSetTest()
        {
            if (_collectionElementSet == null || !File.Exists(_filePath))
            {
                SaveBdoElementSetTest();
            }

            var elementSet = XmlHelper.LoadXml<BdoElementSetDto>(_filePath).ToPoco();

            Test(elementSet);
        }
    }
}