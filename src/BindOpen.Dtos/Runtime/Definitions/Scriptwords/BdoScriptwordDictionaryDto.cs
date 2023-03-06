﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BindOpen.Runtime.Definitions
{
    /// <summary>
    /// This class represents a DTO script word dico.
    /// </summary>
    [XmlType("ScriptwordDictionaryDto", Namespace = "https://storage.bindopen.org/xsd/bindopen")]
    [XmlRoot(ElementName = "scriptwords.dico", Namespace = "https://storage.bindopen.org/xsd/bindopen", IsNullable = false)]
    public class BdoScriptwordDictionaryDto
        : TBdoExtensionDictionaryDto<BdoScriptwordDefinitionDto>
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// The definition class of this instance.
        /// </summary>
        [JsonPropertyName("definitionClass")]
        [XmlElement("definitionClass")]
        public string DefinitionClass { get; set; }

        /// <summary>
        /// Definitions of this instance.
        /// </summary>
        [JsonPropertyName("definitions")]
        [XmlArray("definitions")]
        [XmlArrayItem("add.definition")]
        public List<BdoScriptwordDefinitionDto> Definitions { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoScriptwordDictionaryDto class.
        /// </summary>
        public BdoScriptwordDictionaryDto()
        {
        }

        #endregion
    }
}
