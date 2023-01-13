﻿using BindOpen.MetaData;
using BindOpen.MetaData.Elements;
using Bogus;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace BindOpen.Tests.IO.MetaData
{
    [TestFixture, Order(202)]
    public class ScalarElementSetTests
    {
        private readonly string _filePath_xml = GlobalVariables.WorkingFolder + "ScalarElementSet.xml";
        private readonly string _filePath_json = GlobalVariables.WorkingFolder + "ScalarElementSet.json";

        private dynamic _testData;

        private IBdoElementSet _elemSet = null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var f = new Faker();
            _testData = new
            {
                arrayNumber1 = Enumerable.Range(0, 10).Select(p => f.Random.Double()).ToArray(),
                arrayString2 = Enumerable.Range(0, 10).Select(p => f.Random.Word()).ToArray(),
                arrayInteger3 = Enumerable.Range(0, 10).Select(p => f.Random.Int()).ToArray(),
                arrayArrayByte4 = Enumerable.Range(1, 2).Select(p => f.Random.Bytes(5000)).ToArray()
            };
        }

        private void Test(IBdoElementSet elemSet)
        {
            var scalarElement1 = elemSet.Get<IBdoMetaScalar>("float1");
            var scalarElement2 = elemSet.Get<IBdoMetaScalar>("text2");
            var scalarElement3 = elemSet.Get<IBdoMetaScalar>(2);
            var scalarElement4 = elemSet.Get<IBdoMetaScalar>("byteArray4");

            Assert.That(
                _elemSet.Count == 4, "Bad scalar element set - Count");

            var scalar1 = scalarElement1.GetItemList<double>();
            var scalar2 = scalarElement2.GetItemList<string>();
            var scalar3 = scalarElement3.GetItemList<int>();
            var scalar4 = scalarElement4.GetItemList<byte[]>();

            Assert.That(
                scalar1?.Intersect(_testData.arrayNumber1 as double[]).Any() ?? false
                , "Bad scalar element - Set1");

            Assert.That(
                scalar2?.Intersect(_testData.arrayString2 as string[]).Any() ?? false
                , "Bad scalar element - Set2");

            Assert.That(
                scalar3?.Intersect(_testData.arrayInteger3 as int[]).Any() ?? false
                , "Bad scalar element - Set3");

            Assert.That(
                scalar4[0]?.SequenceEqual(_testData.arrayArrayByte4[0] as byte[]) == true
                && scalar4[1]?.SequenceEqual(_testData.arrayArrayByte4[1] as byte[]) == true
                , "Bad scalar element - Set4");
        }

        [Test, Order(1)]
        public void TestCreateElementWithNullValue()
        {
            var element1 = BdoMeta.NewScalar("null1", null);

            Assert.That(
                element1 != null, "Bad scalar element creation");
        }

        [Test, Order(2)]
        public void CreateElementSetTest()
        {
            var element1 = BdoMeta.NewScalar("float1", DataValueTypes.Number, _testData.arrayNumber1);
            var element2 = BdoMeta.NewScalar("text2", DataValueTypes.Text, _testData.arrayString2);
            var element3 = BdoMeta.NewScalar("integer3", DataValueTypes.Integer, _testData.arrayInteger3);
            var element4 = BdoMeta.NewScalar("byteArray4", DataValueTypes.ByteArray, _testData.arrayArrayByte4);

            _elemSet = BdoMeta.NewSet(element1, element2, element3, element4);

            Test(_elemSet);
        }

        [Test, Order(3)]
        public void UpdateCheckRepairTest()
        {
            var elementAA = BdoMeta.NewScalar("name1", null);
            var elementAB = BdoMeta.NewScalar("name1", "Test1");
            elementAA.Repair(elementAB);

            var elemSetA = BdoMeta.NewSet(elementAA, elementAB);


            var elementBA = BdoMeta.NewScalar("name1", "Test1");
            var elementBB = BdoMeta.NewScalar("name1", null);
            elementBA.Repair(elementBB);

            var elemSetB = BdoMeta.NewSet(elementBA, elementBB);

            elemSetB.Add(elementBB);
            elemSetA.Add(elementAB);
            elemSetB.Update(elemSetA);

            elemSetA.Add(null);
            elemSetB.Add(null);
            elemSetB.Add(BdoMeta.NewElement("name1", null));
            elemSetB.Add(BdoMeta.NewElement("name3", null));
            elemSetB.Add(BdoMeta.NewElement("name4", null));
            elemSetB.Add(BdoMeta.NewElement("name5", DataValueTypes.Text));
            elemSetA.Add(BdoMeta.NewElement("name1", null));
            elemSetA.Add(BdoMeta.NewElement("name2", null));
            elemSetA.Add(BdoMeta.NewScalar("name4", DataValueTypes.Text, null));
            elemSetA.Add(BdoMeta.NewElement("name5", null));
            elemSetB.Repair(elemSetA);
            elemSetB.Update(elemSetA);
        }

        [Test, Order(4)]
        public void ElementToStringTest()
        {
            var el = BdoMeta.NewScalar(DataValueTypes.Text, _testData.arrayString2[0]);
            var st = el.ToString();
            Assert.That(st == _testData.arrayString2[0], "Bad scalar element - ToString");

            el = BdoMeta.NewScalar(DataValueTypes.Text, _testData.arrayInteger3[0]);
            st = el.ToString();
            Assert.That(st == _testData.arrayInteger3[0].ToString(), "Bad scalar element - ToString");
        }

        // Xml

        [Test, Order(5)]
        public void SaveXmlBdoElementSetTest()
        {
            if (_elemSet == null)
            {
                CreateElementSetTest();
            }

            var isSaved = _elemSet.ToDto().SaveXml(_filePath_xml);

            Assert.That(isSaved, "Element set saving failed. ");
        }

        [Test, Order(6)]
        public void LoadXmlBdoElementSetTest()
        {
            if (_elemSet == null || !File.Exists(_filePath_xml))
            {
                SaveXmlBdoElementSetTest();
            }

            var elemSet = XmlHelper.LoadXml<BdoElementSetDto>(_filePath_xml).ToPoco();

            Test(elemSet);
        }

        // Json

        [Test, Order(7)]
        public void SaveJsonBdoElementSetTest()
        {
            if (_elemSet == null)
            {
                CreateElementSetTest();
            }

            var isSaved = _elemSet.ToDto().SaveJson(_filePath_json);

            Assert.That(isSaved, "Element set saving failed. ");
        }

        [Test, Order(8)]
        public void LoadJsonBdoElementSetTest()
        {
            if (_elemSet == null || !File.Exists(_filePath_json))
            {
                SaveJsonBdoElementSetTest();
            }

            var elemSet = JsonHelper.LoadJson<BdoElementSetDto>(_filePath_json).ToPoco();

            Test(elemSet);
        }
    }
}
