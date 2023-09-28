﻿using BindOpen.Kernel.Data.Meta;

namespace BindOpen.Kernel.Data.Stores
{
    /// <summary>
    /// This class represents a data source.
    /// </summary>
    public class BdoDatasource : TBdoMetaWrapper<BdoMetaNode>, IBdoDatasource
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        public string Id { get => Detail?.Id; set { (Detail ??= BdoData.NewNode()).WithId(value); } }

        public string Name { get => Detail?.Name; set { (Detail ??= BdoData.NewNode()).WithName(value); } }

        [BdoProperty("datasourceKind")]
        public DatasourceKind DatasourceKind { get; set; }

        [BdoProperty("connectionString")]
        public string ConnectionString { get; set; }

        public new IBdoMetaNode Detail { get => base.Detail; set { base.Detail = value as BdoMetaNode; } }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoDatasource class.
        /// </summary>
        public BdoDatasource() : base()
        {
        }

        #endregion
    }
}
