﻿using BindOpen.Data.Assemblies;
using BindOpen.Data.Meta;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BindOpen.Runtime.Definitions
{
    /// <summary>
    /// This class represents the entity definition.
    /// </summary>
    [XmlType("EntityDefinition", Namespace = "https://storage.bindopen.org/xsd/bindopen")]
    [XmlRoot(ElementName = "entity.definition", Namespace = "https://storage.bindopen.org/xsd/bindopen", IsNullable = false)]
    public class BdoEntityDefinitionDto : ExtensionDefinitionDto
    {
        // --------------------------------------------------
        // PROPERTIES
        // --------------------------------------------------

        #region Properties

        /// <summary>
        /// Item class of this instance.
        /// </summary>
        [JsonPropertyName("itemClass")]
        [XmlElement("itemClass")]
        public ClassReferenceDto ItemClass { get; set; }

        /// <summary>
        /// Viewer class of this instance.
        /// </summary>
        [JsonPropertyName("viewerClass")]
        [XmlElement("viewerClass")]
        public string ViewerClass { get; set; }

        // DTO

        /// <summary>
        /// The set of detail specifications of this instance.
        /// </summary>
        [JsonPropertyName("detail.spec")]
        [XmlElement("detail.spec")]
        public SpecSetDto DetailSpec { get; set; }

        /// <summary>
        /// Formats of this instance.
        /// </summary>
        [JsonPropertyName("formats")]
        [XmlArray("formats")]
        [XmlArrayItem("format")]
        public List<BdoFormatDefinitionDto> FormatDefinitions { get; set; }

        #endregion

        // --------------------------------------------------
        // CONSTRUCTORS
        // --------------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the EntityDefinition class.
        /// </summary>
        public BdoEntityDefinitionDto()
        {
        }

        #endregion
    }
}
