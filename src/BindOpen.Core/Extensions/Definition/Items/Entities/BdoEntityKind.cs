﻿using System;
using System.Xml.Serialization;

namespace BindOpen.Extensions.Definition
{

    // --------------------------------------------------
    // ENUMERATIONS
    // --------------------------------------------------

    #region Enumerations

    /// <summary>
    /// This enumeration lists all the possible kinds of entities.
    /// </summary>
    [Serializable()]
    [XmlType("EntityKind", Namespace = "https://bindopen.org/xsd")]
    public enum BdoEntityKind
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Any.
        /// </summary>
        Any,

        /// <summary>
        /// Data carrier.
        /// </summary>
        Carrier,

        /// <summary>
        /// Data zone.
        /// </summary>
        Zone,

        /// <summary>
        /// Simple item.
        /// </summary>
        SimpleItem
    }

    #endregion

}