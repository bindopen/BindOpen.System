﻿using BindOpen.Data.Helpers;

namespace BindOpen.Data
{
    /// <summary>
    /// This class represents an accessibility level extension.
    /// </summary>
    public static class AccessibilityLevelExtensions
    {
        /// <summary>
        /// Gets the accessibility level corresponding to the specified string.
        /// </summary>
        /// <param key="levelString">The visibility to consider.</param>
        /// <param key="defaultLevelString">The default visibility to consider.</param>
        /// <returns>Returns the visibility corresponding to the specified strings.</returns>
        public static AccessibilityLevels ToAccessibilityLevel(
            string level,
            string defaultLevel)
        {
            AccessibilityLevels visibility = level.ToEnum(AccessibilityLevels.None);

            if (visibility == AccessibilityLevels.Inherited)
            {
                visibility = defaultLevel.ToEnum(AccessibilityLevels.None);
            }

            return visibility;
        }

    }
}