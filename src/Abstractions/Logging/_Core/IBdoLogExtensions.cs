﻿using BindOpen.System.Data.Meta;
using BindOpen.System.Processing;
using System;

namespace BindOpen.System.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoLogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T WithChildren<T>(
            this T log,
            params IBdoLog[] children)
            where T : IBdoLog
        {
            if (log != null)
            {
                log._Children = children;
            }

            return log;
        }

        public static T WithParent<T>(
            this T log,
            IBdoLog parent)
            where T : IBdoLog
        {
            if (log != null)
            {
                log.Parent = parent;
            }

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        public static T WithExecution<T>(
            this T log,
            IBdoProcessExecution execution)
            where T : IBdoLog
        {
            if (log != null)
            {
                log.Execution = execution;
            }

            return log;
        }

        public static T WithTask<T>(
            this T log,
            IBdoConfiguration config)
            where T : IBdoLog
        {
            if (log != null)
            {
                log.TaskConfig = config;
            }

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HasEvent<T>(
            this T log,
            params EventKinds[] kinds)
            where T : IBdoLog
        {
            return log?.HasEvent(true, kinds) ?? false;
        }

        public static T AddException<T>(
            this T log,
            Exception exception,
            DateTime? date = null,
            string resultCode = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Exception, exception?.Message, exception?.ToString(), date, resultCode);

            return log;
        }
    }
}