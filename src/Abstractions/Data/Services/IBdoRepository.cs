﻿using BindOpen.Logging;
using BindOpen.Scoping.Connectors;
using System;

namespace BindOpen.Data.Services;

/// <summary>
/// 
/// </summary>
public interface IBdoRepository : IBdoConnected
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="action"></param>
    /// <param name="log"></param>
    /// <param name="autoConnect"></param>
    void UsingConnection(Action<IBdoConnection, IBdoLog> action, bool autoConnect = true, IBdoLog log = null);
}