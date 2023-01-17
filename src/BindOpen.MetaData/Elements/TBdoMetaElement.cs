﻿using BindOpen.Logging;
using BindOpen.MetaData.Items;
using BindOpen.Runtime.Scopes;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.MetaData.Elements
{
    /// <summary>
    /// This class represents a data element.
    /// </summary>
    public abstract class TBdoMetaElement<TElement, TSpec, TItem> : BdoMetaElement,
        ITBdoMetaElement<TElement, TSpec, TItem>
        where TElement : IBdoMetaElement
        where TSpec : IBdoMetaElementSpec
        where TItem : class
    {
        // --------------------------------------------------
        // CONSTRUCTORS
        // --------------------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the TBdoElement class.
        /// </summary>
        public TBdoMetaElement() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new data element.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="namePreffix">The name preffix to consider.</param>
        /// <param name="id">The ID to consider.</param>
        protected TBdoMetaElement(
            string name = null,
            string namePreffix = null,
            string id = null)
            : base(name, namePreffix, id)
        {
        }

        #endregion


        // --------------------------------------------------
        // ITBdoElement implementation
        // --------------------------------------------------

        #region ITBdoElement

        // --------------------------------------------------
        // PROPERTIES
        // --------------------------------------------------

        // Specifications ---------------------

        /// <summary>
        /// Data constraint statement of this instance.
        /// </summary>
        public new List<TSpec> Specs
        {
            get => base.Specs?.Cast<TSpec>().ToList();
            set { base.WithSpecifications(value?.Cast<IBdoMetaElementSpec>().ToArray()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public new TSpec GetSpecification(string name = null)
        {
            return (TSpec)base.GetSpecification(name);
        }

        /// <summary>
        /// Gets a new specification.
        /// </summary>
        /// <returns>Returns the new specifcation.</returns>
        public new TSpec NewSpecification()
        {
            return (TSpec)base.NewSpecification();
        }

        // Items ----------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new TElement ClearItems()
        {
            return (TElement)base.ClearItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new TElement WithIndex(int? index)
        {
            return (TElement)base.WithIndex(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public new TElement WithItemizationMode(DataItemizationMode mode)
        {
            return (TElement)base.WithItemizationMode(mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public new TElement WithItemReference(IBdoReference reference)
        {
            return (TElement)base.WithItemReference(reference);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public new TElement WithItemScript(string script)
        {
            return (TElement)base.WithItemScript(script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public new TElement WithValueType(DataValueTypes valueType)
        {
            return (TElement)base.WithValueType(valueType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public new TElement WithSpecifications(params IBdoMetaElementSpec[] specs)
        {
            return (TElement)base.WithSpecifications(specs);
        }

        /// <summary>
        /// Sets the item of this instance.
        /// </summary>
        /// <param name="item">The string item of this instance.</param>
        /// <remarks>Items of this instance must be allowed and must not be forbidden. Otherwise, the items will be the default ones..</remarks>
        /// <returns>Returns True if the specified has been well added.</returns>
        public virtual TElement WithItems(params TItem[] objs)
        {
            return (TElement)base.WithItems(objs);
        }

        /// <summary>
        /// Returns the item object of this instance.
        /// </summary>
        /// <param name="log">The log to populate.</param>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="varElementSet">The variable element set to use.</param>
        /// <returns>Returns the items of this instance.</returns>
        public new List<TItem> Items(
            IBdoScope scope = null,
            IBdoMetaElementSet varElementSet = null,
            IBdoLog log = null)
        => base.Items<TItem>(scope, varElementSet, log);

        /// <summary>
        /// Returns the item object of this instance.
        /// </summary>
        /// <param name="log">The log to populate.</param>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="varElementSet">The variable element set to use.</param>
        /// <returns>Returns the items of this instance.</returns>
        List<Q> ITBdoMetaElement<TElement, TSpec, TItem>.Items<Q>(
            IBdoScope scope = null,
            IBdoMetaElementSet varElementSet = null,
            IBdoLog log = null)
        => base.Items<Q>(scope, varElementSet, log);

        /// <summary>
        /// Returns the item object of this instance.
        /// </summary>
        /// <param name="log">The log to populate.</param>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="varElementSet">The variable element set to use.</param>
        /// <returns>Returns the items of this instance.</returns>
        public new TItem Item(
            IBdoScope scope = null,
            IBdoMetaElementSet varElementSet = null,
            IBdoLog log = null)
        => base.Item<TItem>(scope, varElementSet, log);

        /// <summary>
        /// Returns the item object of this instance.
        /// </summary>
        /// <param name="log">The log to populate.</param>
        /// <param name="scope">The scope to consider.</param>
        /// <param name="varElementSet">The variable element set to use.</param>
        /// <returns>Returns the items of this instance.</returns>
        Q ITBdoMetaElement<TElement, TSpec, TItem>.Item<Q>(
            IBdoScope scope = null,
            IBdoMetaElementSet varElementSet = null,
            IBdoLog log = null)
        => base.Item<Q>(scope, varElementSet, log);

        #endregion
    }
}
