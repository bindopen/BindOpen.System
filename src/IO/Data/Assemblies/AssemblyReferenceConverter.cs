﻿using AutoMapper;

namespace BindOpen.System.Data.Assemblies
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class AssemblyReferenceConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static AssemblyReferenceDto ToDto(this IBdoAssemblyReference poco)
        {
            if (poco == null) return null;

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<BdoAssemblyReference, AssemblyReferenceDto>()
                    .ForMember(q => q.Definition, opt => opt.MapFrom(q => new DefinitionReferenceDto()
                    {
                        DefinitionExtensionKind = q.DefinitionExtensionKind,
                        DefinitionUniqueName = q.DefinitionUniqueName,
                    }))
            );

            var mapper = new Mapper(config);
            var dto = mapper.Map<AssemblyReferenceDto>(poco);

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param key="dto">The DTO to consider.</param>
        /// <returns>The DTO object.</returns>
        public static IBdoAssemblyReference ToPoco(
            this AssemblyReferenceDto dto)
        {
            if (dto == null) return null;

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<AssemblyReferenceDto, BdoAssemblyReference>()
                    .ForMember(q => q.DefinitionExtensionKind, opt => opt.MapFrom(q => q.Definition.DefinitionExtensionKind))
                    .ForMember(q => q.DefinitionUniqueName, opt => opt.MapFrom(q => q.Definition.DefinitionUniqueName))
            );

            var mapper = new Mapper(config);
            var poco = mapper.Map<BdoAssemblyReference>(dto);

            return poco;
        }
    }
}
