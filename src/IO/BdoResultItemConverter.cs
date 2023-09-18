﻿namespace BindOpen.Kernel
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class BdoResultItemConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static ResultItemDto ToDto(
            this IResultItem poco)
        {
            if (poco == null) return null;

            var dto = new ResultItemDto()
            {
                Key = poco.Key,
                Status = poco.Status
            };

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="dto">The DTO to consider.</param>
        /// <returns>The DTO object.</returns>
        public static IResultItem ToPoco(
            this ResultItemDto dto)
        {
            if (dto == null) return null;

            var poco = new ResultItem()
            {
                Key = dto.Key,
                Status = dto.Status
            };

            return poco;
        }
    }
}