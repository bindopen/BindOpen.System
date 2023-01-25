﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BindOpen.Data.Meta
{
    /// <summary>
    /// This class represents a data element set.
    /// </summary>
    [XmlType("MetaSet", Namespace = "https://xsd.bindopen.org")]
    [XmlRoot(ElementName = "metaSet", Namespace = "https://xsd.bindopen.org", IsNullable = false)]
    public class MetaSetDto : IDto, IIdentified
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// The identifier of this instance.
        /// </summary>
        [JsonPropertyName("id")]
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// The elements of this instance.
        /// </summary>
        [JsonPropertyName("elements")]
        [XmlArray("elements")]
        [XmlArrayItem("object", Type = typeof(MetaObjectDto))]
        [XmlArrayItem("scalar", Type = typeof(MetaScalarDto))]
        public List<MetaDataDto> Elements { get; set; }

        /// <summary>
        /// Indicates whether the entities property must be ignored.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public bool ElementsSpecified => Elements?.Count > 0;

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoElementSetDto class.
        /// </summary>
        public MetaSetDto()
        {
        }

        #endregion
    }
}

