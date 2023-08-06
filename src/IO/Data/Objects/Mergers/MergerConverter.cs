﻿using System.Collections.Generic;

namespace BindOpen.System.Data
{
    /// <summary>
    /// This static class represents a data reference converter.
    /// </summary>
    public static class MergerConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static MergerDto ToDto(this IBdoFilter poco)
        {
            if (poco == null) return null;

            MergerDto dto = new()
            {
                AddedValues = new List<string>(poco?.AddedValues),
                RemovedValues = new List<string>(poco?.RemovedValues)
            };

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="dto">The DTO to consider.</param>
        /// <returns>The DTO object.</returns>
        public static IBdoFilter ToPoco(this MergerDto dto)
        {
            BdoMerger poco = new()
            {
                AddedValues = new List<string>(dto?.AddedValues),
                RemovedValues = new List<string>(dto?.RemovedValues)
            };

            return poco;
        }
    }
}