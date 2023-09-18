﻿namespace BindOpen.Kernel
{
    /// <summary>
    /// This interface represents an activable object.
    /// </summary>
    public interface IActivable
    {
        /// <summary>
        /// Indicates whether this object is active.
        /// </summary>
        bool IsActive { get; set; }
    }
}