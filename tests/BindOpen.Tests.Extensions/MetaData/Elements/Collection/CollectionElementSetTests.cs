﻿using BindOpen.Extensions.Modeling;
using BindOpen.Data.Elements;
using Bogus;
using NUnit.Framework;
using System.Linq;

namespace BindOpen.Runtime.Tests.MetaData.Elements.Collection
{
    [TestFixture, Order(201)]
    public class CollectionElementSetTests
    {
        private dynamic _testData;

        private ICollectionElement _collectionElement = null;

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

        private static void Test(ICollectionElement collection)
        {
            var el1 = collection.Get("collection1");
            var el2 = collection.Get<ICollectionElement>(1);

            var item2 = el2.Get<ICarrierElement>("collection2");

            Assert.That(collection?.Count == 2, "Bad collection element set - Count");
        }

        [Test, Order(1)]
        public void CreateCollectionElementSetTest()
        {
            (string Key, string Value)[] collectionStringValues = _testData.collectionStringValues1;
            (string Key, double Value)[] collectionDoubleValues = _testData.collectionDoubleValues1;

            var collectionElement1 = BdoElements.NewCollection(
                "collection1",
                collectionStringValues.Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray(),
                collectionDoubleValues.Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray()
            );

            var collectionElement2 = BdoElements.NewCollection(
                "collection2",
                collectionStringValues.Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray(),
                (((string Key, double Value)[])_testData.collectionDoubleValues2).Select(p => BdoElements.NewScalar(p.Key, p.Value)).ToArray());
            collectionElement2
                .Add(
                    BdoElements.NewCarrier("collection2", "tests.core$testCarrier")
                        .WithItem(
                            (new { path = "file2.txt" }).AsElementSet<BdoCarrierConfiguration>()));

            _collectionElement = BdoElements.NewCollection(collectionElement1, collectionElement2);

            Test(_collectionElement);
        }
    }
}