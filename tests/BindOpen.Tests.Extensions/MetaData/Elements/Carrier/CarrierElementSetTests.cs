﻿using BindOpen.Extensions;
using BindOpen.Extensions.Modeling;
using BindOpen.Data.Elements;
using BindOpen.Runtime.Tests.Extensions.Data;
using Bogus;
using NUnit.Framework;

namespace BindOpen.Runtime.Tests.MetaData.Elements.Carrier
{
    [TestFixture, Order(200)]
    public class CarrierElementSetTests
    {
        private dynamic _testData;

        private IBdoElementSet _carrierElementSet = null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var f = new Faker();
            _testData = new
            {
                path1 = f.Random.Word() + "_1.txt",
                path2 = f.Random.Word() + "_2.txt",
                path3 = f.Random.Word() + "_3.txt",
                folderPath3 = f.Random.Word() + "_3.txt",
                path4 = f.Random.Word() + "_4.txt"
            };
        }

        public void Test(IBdoElementSet elementSet)
        {
            var carrierElement1 = elementSet.GetItem<ICarrierElement>("carrier1");
            var carrierElement2 = elementSet.GetItem<ICarrierElement>("carrier2");
            var carrierElement3 = elementSet.Get<ICarrierElement>(2);
            var carrierElement4 = elementSet.GetItem<ICarrierElement>("carrier4");

            Assert.That(elementSet?.Count == 4, "Bad carrier element set - Count");

            Assert.That(
                carrierElement1?.GetFirstItem().GetItem<string>("path") == _testData.path1
                , "Bad carrier element - Set1");

            Assert.That(
                carrierElement2?.GetFirstItem()?.GetItem<string>("path") == _testData.path2
                , "Bad carrier element - Set2");

            Assert.That(
                carrierElement3?.GetFirstItem()?.GetItem<string>("path") == _testData.path3
                , "Bad carrier element - Set3");

            Assert.That(
                carrierElement4?.GetFirstItem()?.GetItem<string>("path") == _testData.path4
                , "Bad carrier element - Set4");
        }

        [Test, Order(1)]
        public void CreateCarrierElementSetTest()
        {
            var carrierElement1 = BdoElements.NewCarrier(
                "carrier1",
                BdoExtensions.NewCarrierConfiguration(
                    "tests.core$testCarrier",
                    BdoElements.NewScalar("path", _testData.path1)));

            var carrierElement2 = BdoElements.NewCarrier("carrier2", "tests.core$testCarrier")
                .WithItem((new { path = _testData.path2 }).AsElementSet<BdoCarrierConfiguration>());

            var carrierElement3 = new CarrierFake(_testData.path3, _testData.folderPath3)?.AsElement();

            var carrierElement4 = BdoExtensions.NewCarrier<CarrierFake>(
                BdoExtensions.NewCarrierConfiguration("tests.core$testCarrier")
                    .WithItems((new { path = _testData.path4 }).AsElementSet()?.ToArray()))?.AsElement();

            _carrierElementSet = BdoElements.NewSet(
                carrierElement1, carrierElement2, carrierElement3, carrierElement4);

            Test(_carrierElementSet);
        }
    }
}