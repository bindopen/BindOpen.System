﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BindOpen.Scoping.Data
{
    /// <summary>
    /// This class represents a dico data item.
    /// </summary>
    /// <example>Titles, Descriptions.</example>
    /// <seealso cref="KeyValuePairDto"/>
    [XmlType("Dictionary", Namespace = "https://storage.bindopen.org/xsd/bindopen")]
    [XmlRoot(ElementName = "dictionary", Namespace = "https://storage.bindopen.org/xsd/bindopen", IsNullable = false)]
    public class DictionaryDto : BdoItemDto
    {
        // --------------------------------------------------
        // PROPERTIES
        // --------------------------------------------------

        #region Properties

        /// <summary>
        /// The ID of this instance.
        /// </summary>
        [JsonPropertyName("id")]
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Values of this instance.
        /// </summary>
        [JsonPropertyName("values")]
        [XmlElement("add.value")]
        public List<KeyValuePairDto> Values { get; set; }

        #endregion

        // --------------------------------------------------
        // CONSTRUCTORS
        // --------------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the DictionaryDataItemDto class. 
        /// </summary>
        public DictionaryDto()
        {
        }

        #endregion
    }

}