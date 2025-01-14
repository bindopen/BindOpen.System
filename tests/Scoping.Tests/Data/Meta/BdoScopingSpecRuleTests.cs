﻿using BindOpen.Tests;
using NUnit.Framework;

namespace BindOpen.Data.Meta;

[TestFixture, Order(100)]
public class BdoScopingSpecRuleTests
{
    private IBdoSpec _spec;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _spec = BdoScopingSpecFaker.CreateSpec();
    }

    [Test, Order(2)]
    public void RequirementTest()
    {
        var meta0 = BdoData.NewNode("meta-test")
            .WithSpec(BdoData.NewSpec())
            .With(
                BdoData.NewScalar("title", "A"));

        var requirementLevel0 = meta0.GetRequirementLevel(ScopingTestData.Scope);
        Assert.That(requirementLevel0 == RequirementLevels.None, "Statement - Error");

        var meta1 = BdoData.NewNode("meta-test")
            .WithSpec(_spec)
            .With(
                BdoData.NewScalar("auto", true),
                BdoData.NewScalar("title", "This is my title"));

        var requirementLevel1 = meta1.GetRequirementLevel(ScopingTestData.Scope);
        Assert.That(requirementLevel1 == RequirementLevels.Required, "Statement - Error");

        var meta2 = BdoData.NewNode("meta-test")
            .WithSpec(_spec)
            .With(("auto", true));

        var requirementLevel2 = meta2.GetRequirementLevel(ScopingTestData.Scope);
        Assert.That(requirementLevel2 == RequirementLevels.Optional, "Statement - Error");
    }

    [Test, Order(3)]
    public void RequirementCheckTest()
    {
        var meta0 = BdoData.NewNode("meta-test")
            .WithSpec(spec => spec.AddItemRequirement(RequirementLevels.Optional).WithName("toto"))
            .With(
                BdoData.NewScalar("title", "A")
                    .WithSpec(spec => spec.AddRequirement(RequirementLevels.Optional)));

        var validator = ScopingTestData.Scope.CreateValidator();
        var valid = validator.Check(meta0);
        Assert.That(valid, "Statement - Error");
    }

    [Test, Order(4)]
    public void ItemRequirementTest()
    {
        var meta0 = BdoData.NewNode("meta-test")
            .WithSpec(BdoData.NewSpec())
            .With(
                BdoData.NewScalar("title", "A"));

        var requirementLevel0 = meta0.GetItemRequirementLevel(ScopingTestData.Scope);
        Assert.That(requirementLevel0 == RequirementLevels.Optional, "Statement - Error");

        var meta1 = BdoData.NewNode("meta-test")
            .WithSpec(_spec)
            .With(
                BdoData.NewScalar("auto", true),
                BdoData.NewScalar("title", "This is my title"));

        var requirementLevel1 = meta1.GetItemRequirementLevel(ScopingTestData.Scope);
        Assert.That(requirementLevel1 == RequirementLevels.Required, "Statement - Error");

        var meta2 = BdoData.NewNode("meta-test")
            .WithSpec(_spec)
            .With(
                BdoData.NewScalar("auto", false));

        var requirementLevel2 = meta2.GetItemRequirementLevel(ScopingTestData.Scope);
        Assert.That(requirementLevel2 == RequirementLevels.Optional, "Statement - Error");
    }

    [Test, Order(6)]
    public void InEnumTest()
    {
        var spec = BdoData.NewSpec();

        var meta0 = BdoData.NewNode("meta-test")
            .With(
                BdoData.NewScalar("level", "RequirementLevels.Optional")
                    .WithSpec(q => q.MustBeInList<RequirementLevels>())
            );

        var validator = ScopingTestData.Scope.CreateValidator();
        var isChecked = validator.Check(meta0);
        Assert.That(!isChecked, "Constraint validation failed");
    }
}
