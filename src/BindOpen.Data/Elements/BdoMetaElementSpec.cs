﻿using BindOpen.Meta.Conditions;
using BindOpen.Meta.Items;
using BindOpen.Meta.Specification;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.Meta.Elements
{
    /// <summary>
    /// This class represents a data element specification.
    /// </summary>
    public abstract class BdoMetaElementSpec : DataSpecification, IBdoMetaElementSpec
    {
        // --------------------------------------------------
        // CONSTANTS
        // --------------------------------------------------

        #region Constants

        /// <summary>
        /// Names of the attribute areas of the TBdoElementSpec class.
        /// </summary>
        public static readonly string[] __AreaNames = new[]
        {
            nameof(DataAreaKind.Design),
            nameof(DataAreaKind.Constraints),
            nameof(DataAreaKind.Properties),
            nameof(BdoMetaElementAreaKind.Element),
            nameof(DataAreaKind.Items)
        };

        #endregion

        // --------------------------------------------------
        // VARIABLES
        // --------------------------------------------------

        #region Variables

        private List<DataItemizationMode> _availableItemizationModes = null;

        #endregion

        // --------------------------------------------------
        // CONSTRUCTORS
        // --------------------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BdoElementSpec class.
        /// </summary>
        protected BdoMetaElementSpec() : base()
        {
        }

        #endregion

        // --------------------------------------------------
        // CLONING
        // --------------------------------------------------

        #region Cloning

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns a cloned instance.</returns>
        public override object Clone(params string[] areas)
        {
            var dataElementSpec = base.Clone<BdoMetaElementSpec>(areas);

            dataElementSpec.WithAliases(Aliases?.ToArray());
            dataElementSpec.WithAvailableItemizationModes(AvailableItemizationModes?.ToArray());
            dataElementSpec.WithConstraintStatement(ConstraintStatement.Clone<DataConstraintStatement>());
            dataElementSpec.WithSpecificationLevels(SpecificationLevels?.ToArray());
            dataElementSpec.WithSubSpecs(SubSpecs?.ToArray());

            return dataElementSpec;
        }

        #endregion

        // --------------------------------------------------
        // IBdoElementSpec Implementation
        // --------------------------------------------------

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ICondition Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithCondition(ICondition condition)
        {
            Condition = condition;
            return this;
        }

        /// <summary>
        /// The aliases of the entry.
        /// </summary>
        public List<string> Aliases { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aliases"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithAliases(params string[] aliases)
        {
            Aliases = aliases.ToList();
            return this;
        }

        /// <summary>
        /// Indicates whether the instance can be allocated.
        /// </summary>
        public bool IsAllocatable { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isAllocatable"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec AsAllocatable(bool isAllocatable = true)
        {
            IsAllocatable = isAllocatable;

            return this;
        }

        /// <summary>
        /// The script of this instance.
        /// </summary>
        public string ItemScript { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithItemScript(string script)
        {
            ItemScript = script;

            return this;
        }

        /// <summary>
        /// The available itemization modes of this instance.
        /// </summary>
        public List<DataItemizationMode> AvailableItemizationModes
        {
            get => _availableItemizationModes;
            set
            {
                if ((value == null) || (value.Count == 0) || (value.Contains(DataItemizationMode.Any)))
                    _availableItemizationModes = new List<DataItemizationMode>() { DataItemizationMode.Any };
                else
                    _availableItemizationModes = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modes"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithAvailableItemizationModes(params DataItemizationMode[] modes)
        {
            _availableItemizationModes = modes.ToList();

            return this;
        }

        /// <summary>
        /// The default item of this instance.
        /// </summary>
        public object DefaultItem { get; set; }

        /// <summary>
        /// Minimum item number of this instance.
        /// </summary>
        public int MinimumItemNumber { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithMaximumItemNumber(int number)
        {
            MaximumItemNumber = number;

            return this;
        }

        /// <summary>
        /// Maximum item number of this instance.
        /// </summary>
        public int MaximumItemNumber { get; set; } = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithMinimumItemNumber(int number)
        {
            MinimumItemNumber = number;

            return this;
        }

        /// <summary>
        /// Indicates whether the value of this instance is a list.
        /// </summary>
        public bool IsValueList => (MaximumItemNumber == -1) || (MaximumItemNumber > 1);

        /// <summary>
        /// The item requirement level of this instance.
        /// </summary>
        public RequirementLevels ItemRequirementLevel
        {
            get
            {
                if (MaximumItemNumber == 0)
                {
                    return RequirementLevels.Forbidden;
                }
                else if (MinimumItemNumber > 0)
                {
                    return RequirementLevels.Required;
                }
                else if (MinimumItemNumber <= 0)
                {
                    return RequirementLevels.Optional;
                }
                else
                {
                    return RequirementLevels.None;
                }
            }
        }

        /// <summary>
        /// Levels of specification of this instance.
        /// </summary>
        public List<SpecificationLevels> ItemSpecificationLevels { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="levels"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithItemSpecificationLevels(params SpecificationLevels[] levels)
        {
            ItemSpecificationLevels = levels.ToList();
            return this;
        }

        /// <summary>
        /// Data constraint statement of this instance.
        /// </summary>
        public IDataConstraintStatement ConstraintStatement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithConstraintStatement(IDataConstraintStatement statement)
        {
            ConstraintStatement = statement;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<IBdoMetaElementSpec> SubSpecs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specs"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithSubSpecs(params IBdoMetaElementSpec[] specs)
        {
            SubSpecs = new List<IBdoMetaElementSpec>();
            AddSubSpecs(specs);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specs"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec AddSubSpecs(params IBdoMetaElementSpec[] specs)
        {
            SubSpecs ??= new List<IBdoMetaElementSpec>();
            SubSpecs.AddRange(specs);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec GetSubSpec(string name)
        {
            return SubSpecs.FirstOrDefault(q => q.BdoKeyEquals(name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBdoMetaElementSpec WithDefaultItem(object item)
        {
            DefaultItem = item;
            return this;
        }

        #endregion

        // ------------------------------------------
        // IDISPOSABLE METHODS
        // ------------------------------------------

        #region IDisposable_Methods

        private bool _isDisposed = false;

        /// <summary>
        /// Disposes this instance. 
        /// </summary>
        /// <param name="isDisposing">Indicates whether this instance is disposing</param>
        protected override void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            ConstraintStatement?.Dispose();

            _isDisposed = true;

            base.Dispose(isDisposing);
        }

        #endregion
    }
}
