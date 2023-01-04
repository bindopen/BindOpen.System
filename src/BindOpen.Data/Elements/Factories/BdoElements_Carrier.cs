﻿using BindOpen.Extensions.Modeling;

namespace BindOpen.Data.Elements
{
    /// <summary>
    /// This static class provides methods to create data els.
    /// </summary>
    public static partial class BdoElements
    {
        /// <summary>
        /// Initializes a new carrier el.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="definitionUniqueId ">The definition unique ID to consider.</param>
        public static CarrierElement NewCarrier(
            string name,
            string definitionUniqueId = null)
            => NewCarrier<CarrierElement>(name, definitionUniqueId);

        /// <summary>
        /// Initializes a new carrier el.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="item">The items to consider.</param>
        public static CarrierElement NewCarrier(
            string name,
            IBdoCarrierConfiguration item)
            => NewCarrier<CarrierElement>(name, item);

        // Static T creators -------------------------

        /// <summary>
        /// Initializes a new carrier el.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="definitionUniqueId ">The definition unique ID to consider.</param>
        public static T NewCarrier<T>(
            string name,
            string definitionUniqueId = null)
            where T : class, ICarrierElement, new()
        {
            var el = new T();
            el.WithDefinitionUniqueId(definitionUniqueId);
            el.WithName(name);

            return el;
        }

        /// <summary>
        /// Initializes a new carrier el.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="item">The items to consider.</param>
        public static T NewCarrier<T>(
            string name,
            IBdoCarrierConfiguration item)
            where T : class, ICarrierElement, new()
        {
            var el = new T();
            el.WithItem(item);
            el.WithName(name);

            return el;
        }
    }
}