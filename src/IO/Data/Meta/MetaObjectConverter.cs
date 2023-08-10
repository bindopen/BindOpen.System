﻿using AutoMapper;
using BindOpen.System.Data.Assemblies;
using System.Linq;

namespace BindOpen.System.Data.Meta
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class MetaObjectConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static MetaObjectDto ToDto(this IBdoMetaObject poco)
        {
            if (poco == null) return null;

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<BdoMetaObject, MetaObjectDto>()
                    .ForMember(q => q.ClassReference, opt => opt.Ignore())
                    .ForMember(q => q.MetaItems, opt => opt.Ignore())
                    .ForMember(q => q.Item, opt => opt.Ignore())
                    .ForMember(q => q.DataReference, opt => opt.MapFrom(q => q.DataReference.ToDto()))
                    .ForMember(q => q.Specs, opt => opt.Ignore())
            );

            var mapper = new Mapper(config);
            var dto = mapper.Map<MetaObjectDto>(poco);

            dto.ClassReference = poco?.DataType.ClassReference?.ToDto();
            dto.DataReference = poco.DataReference?.ToDto();
            dto.MetaItems = poco.Items?.Select(q => q.ToDto()).ToList();
            dto.Specs = poco.Specs?.Select(q =>
            {
                var dto = q.ToDto();
                if (q.DataType.ValueType == poco.DataType.ValueType)
                {
                    dto.ValueType = DataValueTypes.Any;
                }
                return dto;
            }).ToList();
            dto.ValueType = poco?.DataType.ValueType ?? DataValueTypes.Any;

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="dto">The DTO to consider.</param>
        /// <returns>The DTO object.</returns>
        public static IBdoMetaObject ToPoco(
            this MetaObjectDto dto)
        {
            if (dto == null) return null;

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<MetaObjectDto, BdoMetaObject>()
                    .ForMember(q => q.DataType, opt => opt.Ignore())
                    .ForMember(q => q.Items, opt => opt.Ignore())
                    .ForMember(q => q.Parent, opt => opt.Ignore())
                    .ForMember(q => q.DataReference, opt => opt.Ignore())
                    .ForMember(q => q.Specs, opt => opt.Ignore())
                );

            var mapper = new Mapper(config);
            var poco = mapper.Map<BdoMetaObject>(dto);

            poco.DataReference = dto.DataReference.ToPoco();
            poco.DataType = new BdoDataType()
            {
                ClassReference = dto.ClassReference.ToPoco(),
                ValueType = dto.ValueType
            };
            var specs = dto.Specs?.Select(q => q.ToPoco())?.ToArray();
            poco.Specs = specs?.Length > 0 ? BdoData.NewSet<IBdoSpec>(specs) : null;

            poco.With(dto.MetaItems?.Select(q => q.ToPoco()).ToArray());

            return poco;
        }
    }
}
