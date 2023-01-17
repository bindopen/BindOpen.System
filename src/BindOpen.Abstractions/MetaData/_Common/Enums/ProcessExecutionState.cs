﻿using System.Xml.Serialization;

namespace BindOpen.MetaData
{
    /// <summary>
    /// This enumeration represents the possible process execution states.
    /// </summary>
    [XmlType("ProcessExecutionState", Namespace = "https://xsd.bindopen.org")]
    public enum ProcessExecutionState
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Pending.
        /// </summary>
        Pending,

        /// <summary>
        /// Ended.
        /// </summary>
        Ended
    }

}
