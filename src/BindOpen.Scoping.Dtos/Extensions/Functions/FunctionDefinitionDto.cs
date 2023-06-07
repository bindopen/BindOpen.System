﻿using BindOpen.Scoping.Data;
using BindOpen.Scoping.Data.Meta;
using BindOpen.Scoping.Script;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BindOpen.Scoping.Extensions.Functions
{
    /// <summary>
    /// This class represents a script word definition.
    /// </summary>
    [XmlType("FunctionDefinition", Namespace = "https://storage.bindopen.org/xsd/bindopen")]
    [XmlRoot(ElementName = "scriptWord.definition", Namespace = "https://storage.bindopen.org/xsd/bindopen", IsNullable = false)]
    public class FunctionDefinitionDto : ExtensionDefinitionDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// The calling class of this instance.
        /// </summary>
        [JsonPropertyName("callingClass")]
        [XmlElement("callingClass")]
        public string CallingClass { get; set; }

        /// <summary>
        /// Kind of this instance.
        /// </summary>
        [JsonPropertyName("kind")]
        [XmlElement("kind")]
        public ScriptItemKinds Kind { get; set; } = ScriptItemKinds.None;

        /// <summary>
        /// Maximum number of parameters of this instance.
        /// </summary>
        [JsonPropertyName("maxParameterNumber")]
        [XmlElement("maxParameterNumber")]
        public int MaxParameterNumber { get; set; } = -1;

        /// <summary>
        /// Minimum number of parameters of this instance.
        /// </summary>
        [JsonPropertyName("minParameterNumber")]
        [XmlElement("minParameterNumber")]
        public int MinParameterNumber { get; set; } = -1;

        /// <summary>
        /// Name of parameters of this instance when parameters are repeated.
        /// </summary>
        /// <seealso cref="IsRepeatedParameters"/>
        /// <seealso cref="RepeatedParameterValueType"/>
        [JsonPropertyName("repeatedParameterName")]
        [XmlElement("repeatedParameterName")]
        public string RepeatedParameterName { get; set; }

        /// <summary>
        /// Value type of parameters of this instance when parameters are repeated.
        /// </summary>
        /// <seealso cref="IsRepeatedParameters"/>
        /// <seealso cref="RepeatedParameterName"/>
        [JsonPropertyName("repeatedParameterValueType")]
        [XmlElement("repeatedParameterValueType")]
        public DataValueTypes RepeatedParameterValueType { get; set; }

        /// <summary>
        /// Reference unique ID of this instance.
        /// </summary>
        [JsonPropertyName("referenceUniqueName")]
        [XmlAttribute("referenceUniqueName")]
        public string ReferenceUniqueName { get; set; }

        /// <summary>
        /// The return value type of this instance.
        /// </summary>
        [JsonPropertyName("returnValueType")]
        [XmlElement("returnValueType")]
        public DataValueTypes ReturnValueType { get; set; } = DataValueTypes.Text;

        /// <summary>
        /// Name of the runtime function.
        /// </summary>
        [JsonPropertyName("functionName")]
        [XmlElement("functionName")]
        public string RuntimeFunctionName { get; set; }

        // DTO

        /// <summary>
        /// The definitions of the sub words of this instance.
        /// </summary>
        [JsonPropertyName("children")]
        [XmlArray("children")]
        [XmlArrayItem("add.definition")]
        public List<FunctionDefinitionDto> Children { get; set; }

        /// <summary>
        /// The elements of this instance.
        /// </summary>
        [JsonPropertyName("parameters")]
        [XmlElement("parameter")]
        public List<MetaDataDto> ParameterSpecification { get; set; }

        /// <summary>
        /// Indicates whether the entities property must be ignored.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public bool ParameterSpecificationSpecified => ParameterSpecification?.Count > 0;

        /// <summary>
        /// Description of parameters of this instance when parameters are repeated.
        /// </summary>
        /// <seealso cref="IsRepeatedParameters"/>
        /// <seealso cref="RepeatedParameterName"/>
        [JsonPropertyName("repeatedParameterDescription")]
        [XmlElement("repeatedParameterDescription")]
        public DictionaryDto RepeatedParameterDescription { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoFunctionDefinitionDto class.
        /// </summary>
        public FunctionDefinitionDto()
        {
        }

        #endregion
    }
}