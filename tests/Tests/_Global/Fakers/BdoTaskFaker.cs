﻿using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Meta;
using BindOpen.Kernel.Scoping;
using Bogus;
using NUnit.Framework;

namespace BindOpen.Kernel.Tests
{
    public static class BdoTaskFaker
    {
        public static readonly string XmlFilePath = SystemData.WorkingFolder + "Task.xml";
        public static readonly string JsonFilePath = SystemData.WorkingFolder + "Task.json";

        public static dynamic NewData()
        {
            var f = new Faker();
            return new
            {
                boolValue = f.Random.Bool(),
                intValue = f.Random.Int(800),
                enumValue = AccessibilityLevels.Private,
                stringValue = f.Lorem.Word()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param key="data"></param>
        /// <returns></returns>
        public static IBdoMetaObject NewMetaObject(dynamic data = null)
        {
            data ??= NewData();

            var meta = BdoData.NewObject()
                .WithDataType(BdoExtensionKinds.Task, "bindopen.kernel.tests$taskFake")
                .WithProperties(
                    ("boolValue", data.boolValue as bool?),
                    ("intValue", data.intValue as int?))
                .WithInputs(
                    ("enumValue", data.enumValue as AccessibilityLevels?))
                .WithOutputs(
                    ("stringValue", data.stringValue as string));

            return meta;
        }

        public static void AssertFake(TaskFake task, dynamic reference)
        {
            Assert.That(task != null, "Task missing");

            Assert.That(task.BoolValue == reference.boolValue, "Bad task - Boolean value");
            Assert.That(task.EnumValue.ToString() == reference.enumValue.ToString(), "Bad task - Enumeration value");
            Assert.That(task.IntValue == reference.intValue, "Bad task - Integer value");
            Assert.That(task.StringValue == reference.stringValue, "Bad task - String value");
        }
    }
}
