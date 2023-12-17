﻿using BindOpen.Kernel.Data.Helpers;

namespace BindOpen.Kernel.Data
{
    /// <summary>
    /// This interface represents an described data item.
    /// </summary>
    public static class ITChildExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T Root<T>(
            this ITChild<T> child,
            int levelMax = 50)
            where T : IReferenced
        {
            if (child != null && levelMax > 0)
            {
                if (child.Parent == null)
                {
                    return child.As<T>();
                }
                else if (child.Parent is ITChild<T> tree)
                {
                    return tree.Root(levelMax--);
                }
            }

            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Q WithParent<Q, T>(this Q item, T parent)
            where Q : ITChild<T>
            where T : IReferenced
        {
            item.Parent = parent;

            if (parent is ITSingleChildParent<Q> singleChildParent)
            {
                singleChildParent.WithChild(item);
            }

            return item;
        }

        /// <summary>
        /// The level of this instance.
        /// </summary>
        public static int Level<T>(this ITChild<T> child)
            where T : IReferenced
        {
            if (child != null)
            {
                var parent = child.Parent;
                if (parent is ITChild<T> parentChild)
                {
                    return parentChild.Level() + 1;
                }
            }

            return 0;
        }
    }
}