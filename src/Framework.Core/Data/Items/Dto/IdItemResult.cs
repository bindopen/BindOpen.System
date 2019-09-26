﻿using System;
using System.Xml.Serialization;
using BindOpen.Framework.Core.Data.Common;

namespace BindOpen.Framework.Core.Data.Items.Dto
{
    /// <summary>
    /// This class represents the ID item result.
    /// </summary>
    [Serializable()]
    [XmlType("IdItemResult", Namespace = "https://bindopen.org/xsd")]
    [XmlRoot("idItemResult", Namespace = "https://bindopen.org/xsd", IsNullable = false)]
    public class IdItemResult
    {
        /// <summary>
        /// The ID of this instance.
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status of this instance.
        /// </summary>
        [XmlElement("status")]
        public ResourceStatus Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the IdItemResult class.
        /// </summary>
        /// <param name="id">The ID to consider.</param>
        /// <param name="status">The status to consider.</param>
        public IdItemResult(string id, ResourceStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}