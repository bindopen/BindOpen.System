﻿namespace BindOpen.System.Data.Meta
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoDefinitionExtensions
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param key="items">The items of the item to add.</param>
        /// <returns>Returns the new item that has been added.
        /// Returns null if the new item is null or else its name is null.</returns>
        /// <remarks>The new item must have a name.</remarks>
        public static T Add<T>(
           this T set,
           params IBdoSpec[] items)
           where T : IBdoDefinition
        {
            if (set != null && items != null)
            {
                foreach (var item in items)
                {
                    set.Insert(item);
                }
            }

            return set;
        }

        /// <summary>
        /// Sets the specified single item of this instance.
        /// </summary>
        /// <param key="items">The items to apply to this instance.</param>
        /// <remarks>Items of this instance must be allowed and must not be forbidden. Otherwise, the values will be the default ones..</remarks>
        public static T With<T>(
           this T set,
           params IBdoSpec[] items)
           where T : IBdoDefinition
        {
            if (set != null)
            {
                set.Clear();
                set.Add(items);
            }

            return set;
        }
    }
}