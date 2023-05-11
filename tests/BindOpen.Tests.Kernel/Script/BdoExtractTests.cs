﻿using BindOpen.Data;
using BindOpen.Data.Helpers;
using BindOpen.Data.Meta;
using BindOpen.Script;
using Bogus;
using NUnit.Framework;

namespace BindOpen.Tests.Script
{
    [TestFixture, Order(210)]
    public class BdoExtractTests
    {
        dynamic _valueSet;
        public BdoDictionary _dico = null;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var f = new Faker();
            _valueSet = new
            {
                preffix = f.Random.Word(),
                value1 = f.Random.Word(),
                middle = f.Random.Word(),
                value2 = f.Random.Word(),
                suffix = f.Random.Word(),
                name_value1 = "value1",
                name_value2 = "value2"
            };
        }

        public void Test(IBdoMetaSet set)
        {
            Assert.That(
                set.GetData<string>(_valueSet.name_value1) == _valueSet.value1 as string
                && set.GetData<string>(_valueSet.name_value2) == _valueSet.value2 as string, "Bad string parsing");
        }

        [Test, Order(1)]
        public void Create1Test()
        {
            string st = _valueSet.preffix + _valueSet.value1 + _valueSet.middle + _valueSet.value2 + _valueSet.suffix;
            string pattern = _valueSet.preffix + "{{" + _valueSet.name_value1 + "}}" + _valueSet.middle + "{{" + _valueSet.name_value2 + "}}" + _valueSet.suffix;

            var set = st.ExtractTokens(pattern);

            Test(set);
        }

        [Test, Order(2)]
        public void Create2Test()
        {
            string st = _valueSet.value1 + _valueSet.middle + _valueSet.value2 + _valueSet.suffix;
            string pattern = "{{" + _valueSet.name_value1 + "}}" + _valueSet.middle + "{{" + _valueSet.name_value2 + "}}" + _valueSet.suffix;

            var set = st.ExtractTokens(pattern);

            Test(set);
        }

        [Test, Order(3)]
        public void Create3Test()
        {
            string st = _valueSet.preffix + _valueSet.value1 + _valueSet.middle + _valueSet.value2;
            string pattern = _valueSet.preffix + "{{" + _valueSet.name_value1 + "}}" + _valueSet.middle + "{{" + _valueSet.name_value2 + "}}";

            var set = st.ExtractTokens(pattern);

            Test(set);
        }

        [Test, Order(4)]
        public void Create4Test()
        {
            string st = _valueSet.value1 + _valueSet.middle + _valueSet.value2;
            string pattern = "{{" + _valueSet.name_value1 + "}}" + _valueSet.middle + "{{" + _valueSet.name_value2 + "}}";

            var set = st.ExtractTokens(pattern, '"');

            Test(set);
        }

        [Test, Order(5)]
        public void Create5Test()
        {
            string st = (_valueSet.value1 as string).ToQuoted('"') + ":" + _valueSet.value2;
            string pattern = "{{" + _valueSet.name_value1 + "}}" + ":" + "{{" + _valueSet.name_value2 + "}}";

            var set = st.ExtractTokens(pattern, '"');

            Test(set);
        }

        [Test, Order(6)]
        public void CreateTest_NameSpaceValue()
        {
            var name = @"toto ""max";
            string st = name.ToQuoted('"') + " " + _valueSet.value2;
            string pattern = LabelFormats.NameSpaceValue.GetScript();

            var set = st.ExtractTokens(pattern, '"');

            Assert.That(
                set.GetData<string>(LabelFormatsExtensions.__Script_This_Name) == name
                && set.GetData<string>(LabelFormatsExtensions.__Script_This_Value) == _valueSet.value2 as string, "Bad string parsing");
        }

        [Test, Order(7)]
        public void CreateTest_Map()
        {
            var name = @"toto ""max";
            string st = name.ToQuoted('"') + " " + _valueSet.value2;
            string pattern = LabelFormats.NameSpaceValue.GetScript();

            string st_name = null;
            string st_value = null;

            var set = st.ExtractTokens(pattern, '"');
            set.Map(
                (LabelFormatsExtensions.__Script_This_Name, q => { st_name = q.GetData<string>(); }
            ),
                (LabelFormatsExtensions.__Script_This_Value, q => { st_value = q.GetData<string>(); }
            ));

            Assert.That(st_name == name as string && st_value == _valueSet.value2, "Bad string parsing");
        }
    }
}
