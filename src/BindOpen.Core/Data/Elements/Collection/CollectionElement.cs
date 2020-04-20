﻿using BindOpen.Application.Scopes;
using BindOpen.Data.Common;
using BindOpen.Data.Helpers.Objects;
using BindOpen.Data.Items;
using BindOpen.System.Diagnostics;
using BindOpen.System.Scripting;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Data.Elements
{
    /// <summary>
    /// This class represents a catalog element that is an element whose elements are entities.
    /// </summary>
    [XmlType("CatalogElement", Namespace = "https://bindopen.org/xsd")]
    [XmlRoot(ElementName = "catalog", Namespace = "https://bindopen.org/xsd", IsNullable = false)]
    public class CollectionElement : DataElement, ICollectionElement
    {
        // --------------------------------------------------
        // PROPERTIES
        // --------------------------------------------------

        #region Properties

        /// <summary>
        /// The elements of this instance.
        /// </summary>
        [XmlElement("carrier", typeof(CarrierElement))]
        [XmlElement("document", typeof(DocumentElement))]
        [XmlElement("object", typeof(ObjectElement))]
        [XmlElement("meta", typeof(MetaDataElement))]
        [XmlElement("scalar", typeof(ScalarElement))]
        [XmlElement("source", typeof(SourceElement))]
        [XmlElement("collection", typeof(CollectionElement))]
        [XmlArrayElement("elements")]
        public List<DataElement> Elements
        {
            get;
            set;
        }

        // Specifcation -----------------------

        /// <summary>
        /// The specification of this instance.
        /// </summary>
        [XmlElement("specification")]
        public new CollectionElementSpec Specification
        {
            get { return base.Specification as CollectionElementSpec; }
            set { base.Specification = value; }
        }

        #endregion

        // --------------------------------------------------
        // CONSTRUCTORS
        // --------------------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new catalog element.
        /// </summary>
        public CollectionElement()
            : base(null, "CatalogElement_")
        {
        }

        /// <summary>
        /// Initializes a new data catalog element.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="id">The ID to consider.</param>
        /// <param name="specification">The specification to consider.</param>
        /// <param name="elements">The elements to consider.</param>
        public CollectionElement(
            string name,
            string id,
            ICollectionElementSpec specification,
            params IDataElement[] elements)
            : base(name, "CatalogElement_", id)
        {
            ValueType = DataValueType.Object;
            Specification = specification as CollectionElementSpec;

            SetItem(elements);
        }

        /// <summary>
        /// Initializes a new data catalog element.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="elements">The elements to consider.</param>
        public CollectionElement(
            string name,
            params IDataElement[] elements)
            : this(name, null, null, elements)
        {
        }

        /// <summary>
        /// Initializes a new data catalog element.
        /// </summary>
        /// <param name="elements">The elements to consider.</param>
        public CollectionElement(
            params IDataElement[] elements)
            : this(null, null, null, elements)
        {
        }

        #endregion

        // --------------------------------------------------
        // ITEMS
        // --------------------------------------------------

        #region Items

        // Specification ---------------------

        /// <summary>
        /// Creates a new specification.
        /// </summary>
        /// <returns>Returns the new specifcation.</returns>
        public override IDataElementSpec NewSpecification()
        {
            return Specification = new CollectionElementSpec();
        }

        // Items ----------------------------

        /// <summary>
        /// Adds a new single item of this instance.
        /// </summary>
        /// <param name="item">The string item of this instance.</param>
        /// <param name="log">The log to populate.</param>
        /// <remarks>Items of this instance must be allowed and must not be forbidden. Otherwise, the elements will be the default ones..</remarks>
        /// <returns>Returns True if the specified has been well added.</returns>
        public override IDataElement AddItem(object item, IBdoLog log = null)
        {
            base.AddItem(item, log);

            return this;
        }

        /// <summary>
        /// Sets the specified single item of this instance.
        /// </summary>
        /// <param name="item">The item to apply to this instance.</param>
        /// <remarks>Items of this instance must be allowed and must not be forbidden. Otherwise, the values will be the default ones..</remarks>
        public override IDataElement SetItem(object item)
        {
            base.SetItem(item);

            return this;
        }

        /// <summary>
        /// Indicates whether this instance contains the specified scalar item or the specified catalog name.
        /// </summary>
        /// <param name="indexItem">The index item to consider.</param>
        /// <param name="isCaseSensitive">Indicates whether the verification is case sensitive.</param>
        /// <returns>Returns true if this instance contains the specified scalar item or the specified catalog name.</returns>
        public override bool HasItem(object indexItem, bool isCaseSensitive = false)
        {
            if (indexItem is string)
                return Items.Any(p => p.KeyEquals(indexItem));

            return false;
        }

        /// <summary>
        /// Returns a text node representing this instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("|", Items.Select(p => (p as NamedDataItem)?.Key() ?? "").ToArray());
        }

        /// <summary>
        /// Returns the item with the specified name and group ID.
        /// </summary>
        /// <param name="name">The name of the item to return.</param>
        /// <param name="groupId">The ID of the group of the item to return.</param>
        /// <returns>Returns the item with the specified name and group ID.</returns>
        public IDataElement GetElement(string name, string groupId = null)
        {
            return Items?.FirstOrDefault(p =>
                p.KeyEquals(name)
                && ((p as DataElement)?.Specification?.GroupId.KeyEquals(groupId) != false)) as IDataElement;
        }

        /// <summary>
        /// Returns the item object of this instance.
        /// </summary>
        /// <param name="elementName">The element name to consider.</param>
        /// <param name="log">The log to populate.</param>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to use.</param>
        /// <returns>Returns the items of this instance.</returns>
        public object GetElementObject(
            string elementName = null,
            IBdoScope scope = null,
            IScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null)
        {
            IDataElement element = (elementName != null ? GetElement(elementName) : Elements[0]);
            return element?.GetValue(scope, scriptVariableSet, log);
        }

        /// <summary>
        /// Returns the item object of this instance.
        /// </summary>
        /// <param name="elementName">The element name to consider.</param>
        /// <param name="log">The log to populate.</param>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to use.</param>
        /// <returns>Returns the items of this instance.</returns>
        public T GetElementObject<T>(
            string elementName = null,
            IBdoScope scope = null,
            IScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null)
        {
            return (T)GetElementObject(elementName, scope, scriptVariableSet, log);
        }

        /// <summary>
        /// Returns the item object of this instance.
        /// </summary>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to use.</param>
        /// <param name="log">The log to populate.</param>
        /// <returns>Returns the items of this instance.</returns>
        public override object GetValue(
            IBdoScope scope = null,
            IScriptVariableSet scriptVariableSet = null,
            IBdoLog log = null)
        {
            switch (ItemizationMode)
            {
                case DataItemizationMode.Valued:
                    if (Items.Count == 0) return null;
                    var aObject = new Dictionary<string, object>();
                    foreach (var item in Items)
                    {
                        if (item is DataElement element && !aObject.ContainsKey(element.Name))
                        {
                            aObject.Add(element.Name, element.GetValue(scope, scriptVariableSet, log));
                        }
                    }
                    return aObject;
                case DataItemizationMode.Referenced:
                case DataItemizationMode.Script:
                    return base.GetValue(scope, scriptVariableSet, log);
            }

            return null;
        }

        #endregion

        // --------------------------------------------------
        // SERIALIZATION
        // --------------------------------------------------

        #region Serialization

        /// <summary>
        /// Updates information for storage.
        /// </summary>
        /// <param name="log">The log to update.</param>
        public override void UpdateStorageInfo(IBdoLog log = null)
        {
            base.UpdateStorageInfo(log);

            Elements = Items?.Select(p =>
            {
                DataElement element = p as DataElement;
                element?.UpdateStorageInfo(log);
                return element;
            }).ToList();
        }

        /// <summary>
        /// Updates information for runtime.
        /// </summary>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="scriptVariableSet">The set of script variables to consider.</param>
        /// <param name="log">The log to update.</param>
        public override void UpdateRuntimeInfo(IBdoScope scope = null, IScriptVariableSet scriptVariableSet = null, IBdoLog log = null)
        {
            foreach (DataElement element in Elements)
            {
                element.UpdateRuntimeInfo(scope, scriptVariableSet, log);
                AddItem(element);
            }

            base.UpdateRuntimeInfo(scope, scriptVariableSet, log);
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
            CollectionElement aCatalogElement = base.Clone() as CollectionElement;
            //if (DataSchemreference != null)
            //    aCatalogElement.DataSchemreference = DataSchemreference.Clone() as DataHandler;

            return aCatalogElement;
        }

        #endregion
    }
}
