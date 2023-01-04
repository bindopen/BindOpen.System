﻿using BindOpen.Data.Specification;
using System.Linq;

namespace BindOpen.Data.Elements
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class ScalarElementSpecConverter
    {
        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static ScalarElementSpecDto ToDto(this IScalarElementSpec poco)
        {
            if (poco == null) return null;

            ScalarElementSpecDto dto = new()
            {
                AccessibilityLevel = poco.AccessibilityLevel,
                Aliases = poco.Aliases?.ToList(),
                AvailableItemizationModes = poco.AvailableItemizationModes?.ToList(),
                ConstraintStatement = poco.ConstraintStatement?.ToDto(),
                InheritanceLevel = poco.InheritanceLevel,
                IsAllocatable = poco.IsAllocatable,
                ItemScript = poco.ItemScript,
                ItemSpecificationLevels = poco.ItemSpecificationLevels?.ToList(),
                MaximumItemNumber = poco.MaximumItemNumber,
                MinimumItemNumber = poco.MinimumItemNumber,
                RequirementLevel = poco.RequirementLevel,
                RequirementScript = poco.RequirementScript,
                SpecificationLevels = poco.SpecificationLevels?.ToList(),
                ValueType = poco.ValueType
            };

            return dto;
        }

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="dto">The DTO to consider.</param>
        /// <returns>The DTO object.</returns>
        public static IScalarElementSpec ToPoco(this ScalarElementSpecDto dto)
        {
            if (dto == null) return null;

            ScalarElementSpec poco = new()
            {
                //AccessibilityLevel = dto.AccessibilityLevel,
                //Aliases = dto.Aliases?.ToList(),
                //AreaSpecifications = dto.AreaSpecifications.Select(q => q.ToPoco()).ToList(),
                //AvailableItemizationModes = dto.AvailableItemizationModes?.ToList(),
                //ConstraintStatement = dto.ConstraintStatement?.ToPoco(),
                //GroupId = dto.GroupId,
                //InheritanceLevel = dto.InheritanceLevel,
                //IsAllocatable = dto.IsAllocatable,
                //ItemScript = dto.ItemScript,
                //ItemSpecificationLevels = dto.ItemSpecificationLevels?.ToList(),
                //MaximumItemNumber = dto.MaximumItemNumber,
                //MinimumItemNumber = dto.MinimumItemNumber,
                //RequirementLevel = dto.RequirementLevel,
                //RequirementScript = dto.RequirementScript,
                //SpecificationLevels = dto.SpecificationLevels?.ToList(),
                //ValueType = dto.ValueType
            };

            return poco;
        }
    }
}