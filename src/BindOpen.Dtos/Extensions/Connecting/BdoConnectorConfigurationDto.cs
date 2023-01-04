﻿using BindOpen.Runtime.Dtos.Extensions;
using BindOpen.Runtime.Definition;
using System.Xml.Serialization;

namespace BindOpen.Extensions.Connecting
{
    /// <summary>
    /// This class represents a connector configuration DTO.
    /// </summary>
    [XmlType("ConnectorConfiguration", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "connector", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class BdoConnectorConfigurationDto
        : TBdoExtensionTitledItemConfigurationDto<BdoConnectorDefinitionDto>
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoConnectorConfigurationDto class.
        /// </summary>
        public BdoConnectorConfigurationDto()
        {
        }

        #endregion
    }
}