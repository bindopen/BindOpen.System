﻿namespace BindOpen.Data
{
    /// <summary>
    /// This class represents an extension of the DataValueType enumeration.
    /// </summary>
    public static class NameFormatsExtensions
    {
        /// <summary>
        /// Indicates whether the specified kind has name.
        /// </summary>
        /// <param name="kind">The kind of the option name.</param>
        /// <returns>Returns true or false.</returns>
        public static bool HasName(this NameFormats format)
        {
            return format == NameFormats.NameThenValue || format == NameFormats.NameWithValue || format == NameFormats.OnlyName;
        }

        /// <summary>
        /// Indicates whether the specified kind has value.
        /// </summary>
        /// <param name="kind">The kind of the option name.</param>
        /// <returns>Returns true or false.</returns>
        public static bool HasValue(this NameFormats format)
        {
            return format == NameFormats.NameThenValue || format == NameFormats.NameWithValue || format == NameFormats.OnlyValue;
        }

    }
}
