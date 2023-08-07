﻿using AutoMapper;
using BindOpen.System.Data.Helpers;
using System.Linq;

namespace BindOpen.System.Data.Meta
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class ConfigurationConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static ConfigurationDto ToDto(this IBdoConfiguration poco) => poco.ToDto<ConfigurationDto>();

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static T ToDto<T>(this IBdoConfiguration poco)
            where T : ConfigurationDto
        {
            if (poco == null) return null;

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<IBdoConfiguration, T>()
                    .ForMember(q => q.CreationDate, opt => opt.MapFrom(q => StringHelper.ToString(q.CreationDate)))
                    .ForMember(q => q.Description, opt => opt.MapFrom(q => q.Description.ToDto()))
                    .ForMember(q => q.Items, opt => opt.MapFrom(q => q.Items == null ? null : q.Items.Select(q => q.ToDto()).ToList()))
                    .ForMember(q => q.LastModificationDate, opt => opt.MapFrom(q => StringHelper.ToString(q.CreationDate)))
                    .ForMember(q => q.Title, opt => opt.MapFrom(q => q.Title.ToDto()))
                    .ForMember(q => q.UsedItemIds, opt => opt.MapFrom(q => q.UsedItemIds == null ? null : q.UsedItemIds.Select(q => q).ToList()))
            );

            var mapper = new Mapper(config);
            var dto = mapper.Map<T>(poco);

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static IBdoConfiguration ToPoco(this ConfigurationDto dto) => dto.ToPoco<BdoConfiguration>();

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param key="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static T ToPoco<T>(this ConfigurationDto dto)
            where T : IBdoConfiguration
        {
            if (dto == null) return default;

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<ConfigurationDto, T>()
                    .ForMember(q => q.CreationDate, opt => opt.MapFrom(q => q.CreationDate.ToDateTime(null)))
                    .ForMember(q => q.Description, opt => opt.Ignore())
                    .ForMember(q => q.Items, opt => opt.Ignore())
                    .ForMember(q => q.LastModificationDate, opt => opt.MapFrom(q => q.CreationDate.ToDateTime(null)))
                    .ForMember(q => q.Title, opt => opt.Ignore())
                    .ForMember(q => q.UsedItemIds, opt => opt.MapFrom(q => q.UsedItemIds == null ? null : q.UsedItemIds.Select(q => q).ToList()))
            );

            var mapper = new Mapper(config);
            var poco = mapper.Map<T>(dto);
            poco
                .WithTitle(dto.Title.ToPoco<string>())
                .WithDescription(dto.Description.ToPoco<string>())
                .With(dto.Items.Select(q => q.ToPoco()).ToArray());

            return poco;
        }
    }
}
