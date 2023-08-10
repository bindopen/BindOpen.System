﻿using BindOpen.System.Data.Conditions;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.System.Data.Meta
{
    /// <summary>
    /// This class represents a data element specification.
    /// </summary>
    public partial class BdoSpec : BdoObject, IBdoSpec
    {
        // --------------------------------------------------
        // CONSTANTS
        // --------------------------------------------------

        #region Constants

        /// <summary>
        /// Names of the attribute areas of the TBdoSpec class.
        /// </summary>
        public static readonly string[] __AreaNames = new[]
        {
            nameof(DataAreaKind.Design),
            nameof(DataAreaKind.Constraints),
            nameof(DataAreaKind.Properties),
            nameof(BdoMetaDataAreaKind.Element),
            nameof(DataAreaKind.Items)
        };

        #endregion

        // --------------------------------------------------
        // CONSTRUCTORS
        // --------------------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BdoSpec class.
        /// </summary>
        public BdoSpec() : base()
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
        public override object Clone()
        {
            var dataElementSpec = base.Clone<BdoSpec>();

            dataElementSpec.WithAliases(Aliases?.ToArray());
            dataElementSpec.WithValueModes(AvailableDataModes?.ToArray());
            dataElementSpec.WithSpecLevels(SpecLevels?.ToArray());

            return dataElementSpec;
        }

        #endregion

        // --------------------------------------------------
        // IBdoSpec Implementation
        // --------------------------------------------------

        #region IBdoSpec

        /// <summary>
        /// The identifier of the group of this instance.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// The identifier of the group of this instance.
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// The label of this instance.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The requirement level of this instance.
        /// </summary>
        public RequirementLevels RequirementLevel { get; set; } = RequirementLevels.None;

        /// <summary>
        /// The requirement script of this instance.
        /// </summary>
        public string RequirementExp { get; set; }

        /// <summary>
        /// The level of inheritance of this instance.
        /// </summary>
        public InheritanceLevels InheritanceLevel { get; set; } = InheritanceLevels.None;

        /// <summary>
        /// Levels of specification of this instance.
        /// </summary>
        public IList<SpecificationLevels> SpecLevels { get; set; }

        /// <summary>
        /// Level of accessibility of this instance.
        /// </summary>
        public AccessibilityLevels AccessibilityLevel { get; set; } = AccessibilityLevels.Public;

        #endregion

        // ------------------------------------------
        // ITParent Implementation
        // ------------------------------------------

        #region ITParent

        public IBdoCompositeSpec Parent { get; set; }

        #endregion

        // ------------------------------------------
        // IIndexed Implementation
        // ------------------------------------------

        #region IIndexed

        /// <summary>
        /// The index of this instance.
        /// </summary>
        public int? Index { get; set; }

        #endregion

        // ------------------------------------------
        // IReferenced Implementation
        // ------------------------------------------

        #region IReferenced

        /// <summary>
        /// 
        /// </summary>
        public string Key() => Name;

        #endregion

        // ------------------------------------------
        // IIdentified Implementation
        // ------------------------------------------

        #region IIdentified

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        #endregion

        // ------------------------------------------
        // INamed Implementation
        // ------------------------------------------

        #region INamed

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        #endregion

        // ------------------------------------------
        // IGloballyTitled Implementation
        // ------------------------------------------

        #region IGloballyTitled

        /// <summary>
        /// 
        /// </summary>
        public ITBdoDictionary<string> Title { get; set; }

        #endregion

        // ------------------------------------------
        // IGloballyDescribed Implementation
        // ------------------------------------------

        #region IGloballyDescribed

        /// <summary>
        /// 
        /// </summary>
        public ITBdoDictionary<string> Description { get; set; }

        #endregion

        // ------------------------------------------
        // IGloballyDescribed Implementation
        // ------------------------------------------

        #region IGloballyDescribed

        /// <summary>
        /// 
        /// </summary>
        public IBdoMetaSet Detail { get; set; }

        #endregion

        // --------------------------------------------------
        // IBdoSpec Implementation
        // --------------------------------------------------

        #region IBdoSpec

        /// <summary>
        /// Indicates whether this instance is compatible with the specified data item.
        /// </summary>
        /// <param key="item">The data item to consider.</param>
        /// <returns>True if this instance is compatible with the specified data item.</returns>
        public virtual bool IsCompatibleWithData(
            object item)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public IBdoCondition Condition { get; set; }

        /// <summary>
        /// The aliases of the entry.
        /// </summary>
        public IList<string> Aliases { get; set; }

        /// <summary>
        /// Indicates whether the instance can be allocated.
        /// </summary>
        public bool IsAllocatable { get; set; } = false;

        /// <summary>
        /// The script of this instance.
        /// </summary>
        public BdoDataType DataType { get; set; }

        /// <summary>
        /// The available itemization modes of this instance.
        /// </summary>
        public IList<DataMode> AvailableDataModes { get; set; }

        /// <summary>
        /// The default item of this instance.
        /// </summary>
        public object DefaultData { get; set; }

        /// <summary>
        /// Minimum item number of this instance.
        /// </summary>
        public uint MinDataItemNumber { get; set; } = 0;

        /// <summary>
        /// Maximum item number of this instance.
        /// </summary>
        public uint? MaxDataItemNumber { get; set; }

        /// <summary>
        /// Indicates whether the value of this instance is a list.
        /// </summary>
        public bool IsValueList => MaxDataItemNumber == null || MaxDataItemNumber > 1;

        /// <summary>
        /// The item requirement level of this instance.
        /// </summary>
        public RequirementLevels DataRequirementLevel { get; set; }

        /// <summary>
        /// The requirement script of this instance.
        /// </summary>
        public string DataRequirementExp { get; set; }

        /// <summary>
        /// Levels of specification of this instance.
        /// </summary>
        public IList<SpecificationLevels> DataSpecLevels { get; set; }

        #endregion

        // ------------------------------------------
        // IDISPOSABLE METHODS
        // ------------------------------------------

        #region IDisposable_Methods

        private bool _isDisposed = false;

        /// <summary>
        /// Disposes this instance. 
        /// </summary>
        /// <param key="isDisposing">Indicates whether this instance is disposing</param>
        protected override void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            Condition?.Dispose();
            this.

            _isDisposed = true;

            base.Dispose(isDisposing);
        }

        #endregion
    }
}
