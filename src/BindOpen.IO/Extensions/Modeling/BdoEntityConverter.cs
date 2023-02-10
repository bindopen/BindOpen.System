﻿using BindOpen.Data;
using BindOpen.Data.Configuration;

namespace BindOpen.Extensions.Modeling
{
    /// <summary>
    /// This class represents a entity converter.
    /// </summary>
    public static class BdoEntityConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static ConfigurationDto ToDto(this IBdoEntity poco)
        {
            if (poco == null) return null;

            var dto = poco.Config.ToDto();

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="dto">The DTO to consider.</param>
        /// <returns>The DTO object.</returns>
        public static T ToPoco<T>(this ConfigurationDto dto) where T : class, IBdoEntity, new()
        {
            if (dto == null) return null;

            T poco = new();
            poco
                .WithConfig(dto.ToPoco());

            return poco;
        }
    }
}
