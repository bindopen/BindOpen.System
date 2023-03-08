﻿using BindOpen.Data.Configuration;
using System.Linq;

namespace BindOpen.Data
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class DatasourceConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static DatasourceDto ToDto(this IBdoDatasource poco)
        {
            if (poco == null) return null;

            DatasourceDto dto = new()
            {
                Configurations = poco?.Select(q => q?.ToDto()).ToList(),
                InstanceName = poco.InstanceName,
                Kind = poco.Kind,
                ModuleName = poco.ModuleName,
                Name = poco.Name
            };

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="dto">The DTO to consider.</param>
        /// <returns>The DTO object.</returns>
        public static IBdoDatasource ToPoco(
            this DatasourceDto dto)
        {
            var poco = BdoData.NewDatasource(
                dto.Name,
                dto.Kind,
                dto.Configurations?.Count == 0 ? null : dto.Configurations?.Select(q => q.ToPoco()).ToArray())
                .WithInstanceName(dto.InstanceName)
                .WithModuleName(dto.ModuleName)
                .WithName(dto.Name);

            return poco;
        }
    }
}
