﻿using System.Collections.Generic;

namespace Fidal.Framework.Data
{
    /// <summary>
    /// This class represents the search form request DTO.
    /// </summary>
    public interface ISearchRequestDto
    {
        /// <summary>
        /// The columns of this instance.
        /// </summary>
        List<string> ColumnNames { get; set; }

        /// <summary>
        /// The query of this instance.
        /// </summary>
        string Query { get; set; }

        /// <summary>
        /// The order-by of this instance.
        /// </summary>
        string OrderBy { get; set; }
    }
}