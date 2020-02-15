﻿using BindOpen.Data.Elements;
using BindOpen.Data.Items;
using BindOpen.Extensions.Runtime;
using BindOpen.System.Diagnostics.Events;
using BindOpen.System.Diagnostics.Loggers;
using BindOpen.System.Processing;
using System;
using System.Collections.Generic;

namespace BindOpen.System.Diagnostics
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoLog : IDescribedDataItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        BdoLogEvent this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BdoLogEvent this[string id] { get; }

        /// <summary>
        /// 
        /// </summary>
        DataElementSet Detail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        List<BdoLogEvent> Events { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ProcessExecution Execution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Level { get; }

        /// <summary>
        /// 
        /// </summary>
        BdoTaskConfiguration Task { get; set; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Checkpoints { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Errors { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Exceptions { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Messages { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Warnings { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLog> SubLogs { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogger> Loggers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IBdoLog Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IBdoLog Root { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddCheckpoint(string title, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddError(string title, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddEvent(EventKinds kind, string title, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddEvent(IBdoLogEvent logEvent, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="criticality"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddException(Exception exception, BdoEventCriticality criticality = BdoEventCriticality.None, string resultCode = null, string source = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddException(string title, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggers"></param>
        void AddLoggers(params IBdoLogger[] loggers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddMessage(string title, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterFinder"></param>
        /// <param name="eventKind"></param>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        IBdoLog AddSubLog(Predicate<IBdoLog> filterFinder = null, EventKinds eventKind = EventKinds.Any, string title = null, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <param name="eventKind"></param>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        IBdoLog AddSubLog(IBdoLog childLog, Predicate<IBdoLog> logFinder = null, EventKinds eventKind = EventKinds.Any, string title = null, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent AddWarning(string title, BdoEventCriticality criticality = BdoEventCriticality.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// Adds the specified events to this instance.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="logFinder"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> AddEvents(IBdoLog log, Predicate<IBdoLog> logFinder = null, params EventKinds[] kinds);

        /// <summary>
        /// Adds the specified events to this instance.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> AddEvents(IBdoLog log, params EventKinds[] kinds);

        /// <summary>
        /// Adds the specified events.
        /// </summary>
        /// <param name="eventFuncs">The functions that return events.</param>
        /// <returns>Returns the added events.</returns>
        IBdoLog WithEvents(params Func<IBdoLog, IBdoLogEvent>[] eventFuncs);

        /// <summary>
        /// Adds the events of this instance to the specified log.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="logFinder"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> AddEventsTo(IBdoLog log, Predicate<IBdoLog> logFinder = null, params EventKinds[] kinds);

        /// <summary>
        /// Adds the events of this instance to the specified log.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> AddEventsTo(IBdoLog log, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        void ClearEvents(bool isRecursive = true, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        void End(ProcessExecutionStatus status = ProcessExecutionStatus.Completed);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        int GetEventCount(bool isRecursive = false, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> GetEvents(bool isRecursive = false, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        IBdoLogEvent GetEventWithId(string id, bool isRecursive = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IBdoLogger GetLogger(string name = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        IBdoLogger GetLogger(BdoDefaultLoggerFormat format);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        List<IBdoLogger> GetLoggers(params BdoDefaultLoggerFormat[] formats);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        EventKinds GetMaxEventKind(bool isRecursive = true, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        IBdoLog GetSubLogWithId(string id, bool isRecursive = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variantName"></param>
        /// <param name="defaultVariantName"></param>
        /// <returns></returns>
        new string GetTitle(string variantName = "*", string defaultVariantName = "*");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasErrors(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasErrorsOrExceptions(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasErrorsOrExceptionsOrWarnings(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        bool HasEvent(bool isRecursive = true, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kinds"></param>
        /// <returns></returns>
        bool HasEvent(params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasExceptions(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasMessages(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool HasSubLog();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        bool HasWarnings(bool isRecursive = true, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childLog"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool RemoveSubLog(IBdoLog childLog, bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool RemoveSubLog(string id, bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        void Sanitize();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logFilePath"></param>
        /// <returns></returns>
        bool Save<T>(string logFilePath) where T : IBdoLogger, new();

        /// <summary>
        /// Executes the specified action on loggers of this instance.
        /// </summary>
        /// <param name="action">The action to consider.</param>
        void ForLoggers(Action<IBdoLogger> action);

        /// <summary>
        /// 
        /// </summary>
        void Start();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string ToString<T>() where T : IBdoLogger, new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childLog"></param>
        /// <param name="mode"></param>
        void WriteLog(IBdoLog childLog, BdoLoggerMode mode = BdoLoggerMode.Auto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="mode"></param>
        void WriteLog(IBdoLogEvent logEvent, BdoLoggerMode mode = BdoLoggerMode.Auto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="elementValue"></param>
        /// <param name="mode"></param>
        void WriteLog(string elementName, object elementValue, BdoLoggerMode mode = BdoLoggerMode.Auto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="mode"></param>
        void WriteLog(IBdoTaskConfiguration task, BdoLoggerMode mode = BdoLoggerMode.Auto);

        /// <summary>
        /// 
        /// </summary>
        void BuildTree();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IBdoLog GetRoot();

        /// <summary>
        /// Clones this instance considering the parent log.
        /// </summary>
        /// <param name="parent"></param>
        IBdoLog Clone(IBdoLog parent = null);

        /// <summary>
        /// Clones this instance considering the parent log.
        /// </summary>
        /// <param name="parent"></param>
        T Clone<T>(IBdoLog parent = null) where T : class;
    }
}