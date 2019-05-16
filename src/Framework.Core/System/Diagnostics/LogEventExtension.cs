﻿using System.Collections.Generic;
using System.Linq;
using BindOpen.Framework.Core.System.Diagnostics.Events;
using BindOpen.Framework.Core.System.Diagnostics;

namespace BindOpen.Framework.Core.System.Diagnostics
{
    /// <summary>
    /// This class represents a log event extension.
    /// </summary>
    public static class LogEventExtension
    {
        // Gets -------------------------

        /// <summary>
        /// Gets the specified events of this instance.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <param name="kinds">The event kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static List<ILogEvent> GetEvents(
            this List<ILogEvent> logEvents,
            params EventKinds[] kinds)
        {
            return logEvents ==null ? new List<ILogEvent>() : logEvents.Where(p => kinds.Length==0 || kinds.Contains(p.Kind)).ToList();
        }

        /// <summary>
        /// Gets the warnings of this instance.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static List<ILogEvent> GetWarnings(
            this List<ILogEvent> logEvents)
        {
            return logEvents.GetEvents(EventKinds.Warning);
        }

        /// <summary>
        /// Gets the errors of this instance.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static List<ILogEvent> GetErrors(
            this List<ILogEvent> logEvents)
        {
            return logEvents.GetEvents(EventKinds.Error);
        }

        /// <summary>
        /// Gets the exceptions of this instance.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static List<ILogEvent> GetExceptions(
            this List<ILogEvent> logEvents)
        {
            return logEvents.GetEvents(EventKinds.Exception);
        }

        /// <summary>
        /// Gets the messages of this instance.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static List<ILogEvent> GetMessages(
            this List<ILogEvent> logEvents)
        {
            return logEvents.GetEvents(EventKinds.Message);
        }

        /// <summary>
        /// Gets the errors or exceptions of this instance.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static List<ILogEvent> GetErrorOrExceptions(
            this List<ILogEvent> logEvents)
        {
            return logEvents.GetEvents(EventKinds.Error, EventKinds.Exception);
        }

        /// <summary>
        /// Gets the warnings, errors or exceptions of this instance.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static List<ILogEvent> GetErrorOrExceptionOrWarnings(
            this List<ILogEvent> logEvents)
        {
            return logEvents.GetEvents(EventKinds.Warning, EventKinds.Error, EventKinds.Exception);
        }

        // Has --------------------------

        /// <summary>
        /// Indicates whether this instance has the specified events.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <param name="kinds">The event kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool Has(
            this List<ILogEvent> logEvents,
            params EventKinds[] kinds)
        {
            return logEvents?.Any(p => kinds.Contains(p.Kind)) ?? false;
        }

        /// <summary>
        /// Indicates whether this instance has any warnings.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasWarnings(
            this List<ILogEvent> logEvents)
        {
            return logEvents.Has(EventKinds.Warning);
        }

        /// <summary>
        /// Indicates whether this instance has any errors.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasErrors(
            this List<ILogEvent> logEvents)
        {
            return logEvents.Has(EventKinds.Error);
        }

        /// <summary>
        /// Indicates whether this instance has any exceptions.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasExceptions(
            this List<ILogEvent> logEvents)
        {
            return logEvents.Has(EventKinds.Exception);
        }

        /// <summary>
        /// Indicates whether this instance has any messages.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasMessages(
            this List<ILogEvent> logEvents)
        {
            return logEvents.Has(EventKinds.Message);
        }

        /// <summary>
        /// Indicates whether this instance has any errors or exceptions.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasErrorsOrExceptions(
            this List<ILogEvent> logEvents)
        {
            return logEvents.Has(EventKinds.Error, EventKinds.Exception);
        }

        /// <summary>
        /// Indicates whether this instance has any warnings, errors or exceptions.
        /// </summary>
        /// <param name="logEvents">The log events to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasErrorOrExceptionOrWarnings(
            this List<ILogEvent> logEvents)
        {
            return logEvents.Has(EventKinds.Warning, EventKinds.Error, EventKinds.Exception);
        }
    }
}
