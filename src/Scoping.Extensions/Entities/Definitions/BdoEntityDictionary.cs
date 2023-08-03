﻿using BindOpen.System.Scoping;

namespace BindOpen.System.Scoping
{
    /// <summary>
    /// This class represents a DTO entity dico.
    /// </summary>
    public class BdoEntityDictionary : TBdoExtensionDictionary<IBdoEntityDefinition>, IBdoEntityDictionary
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoEntityDictionary class.
        /// </summary>
        public BdoEntityDictionary()
        {
        }

        #endregion
    }
}
