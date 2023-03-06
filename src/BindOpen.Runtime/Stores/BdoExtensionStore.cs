﻿using BindOpen.Data.Items;
using BindOpen.Extensions;
using BindOpen.Runtime.Definitions;
using System.Collections.Generic;

namespace BindOpen.Runtime.Stores
{
    /// <summary>
    /// This class represents a BindOpen extension item store.
    /// </summary>
    public class BdoExtensionStore : BdoItem,
        IBdoExtensionStore
    {
        // ------------------------------------------
        // VARIABLES
        // ------------------------------------------

        #region Variables

        private readonly Dictionary<string, IBdoConnectorDefinition> _connectorDictionary = new();
        private readonly Dictionary<string, IBdoEntityDefinition> _entityDictionary = new();
        private readonly Dictionary<string, IBdoFunctionDefinition> _functionDictionary = new();
        private readonly Dictionary<string, IBdoScriptwordDefinition> _scriptWordDictionary = new();
        private readonly Dictionary<string, IBdoTaskDefinition> _taskDictionary = new();

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoExtensionStore class.
        /// </summary>
        public BdoExtensionStore()
        {
        }

        #endregion

        // ------------------------------------------
        // IBdoExtensionStore Implementation
        // ------------------------------------------

        #region IBdoExtensionStore

        // Item definitions ----------------------------------

        /// <summary>
        /// Returns the item definitions of this instance.
        /// </summary>
        /// <returns>The item words of specified library names.</returns>
        public ITBdoSet<T> GetDefinitions<T>() where T : IBdoExtensionDefinition
        {
            return (typeof(T).GetExtensionKind()) switch
            {
                BdoExtensionKind.Connector => _connectorDictionary as ITBdoSet<T>,
                BdoExtensionKind.Entity => _entityDictionary as ITBdoSet<T>,
                BdoExtensionKind.Function => _functionDictionary as ITBdoSet<T>,
                BdoExtensionKind.Scriptword => _scriptWordDictionary as ITBdoSet<T>,
                BdoExtensionKind.Task => _taskDictionary as ITBdoSet<T>,
                _ => new TBdoSet<T>(),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param key="uniqueName"></param>
        /// <returns></returns>
        public T GetDefinition<T>(
            string uniqueName)
            where T : IBdoExtensionDefinition
        {
            var definition = GetDefinition(
                typeof(T).GetExtensionKind(),
                uniqueName);
            return (T)definition;
        }

        /// <summary>
        /// Returns the item definition with the specified unique name.
        /// </summary>
        /// <param key="uniqueName">The unique ID of item to return.</param>
        /// <returns>The item with the specified unique name.</returns>
        public IBdoExtensionDefinition GetDefinition(
            BdoExtensionKind kind,
            string uniqueName)
        {
            string upperUniqueName = uniqueName?.ToUpper();

            if (uniqueName != null)
            {
                switch (kind)
                {
                    case BdoExtensionKind.Connector:
                        {
                            _connectorDictionary.TryGetValue(upperUniqueName, out IBdoConnectorDefinition connectorDefinition);
                            return connectorDefinition;
                        }
                    case BdoExtensionKind.Entity:
                        {
                            _entityDictionary.TryGetValue(upperUniqueName, out IBdoEntityDefinition entityDefinition);
                            return entityDefinition;
                        }
                    case BdoExtensionKind.Function:
                        {
                            _functionDictionary.TryGetValue(upperUniqueName, out IBdoFunctionDefinition functionDefinition);
                            return functionDefinition;
                        }
                    case BdoExtensionKind.Scriptword:
                        {
                            _scriptWordDictionary.TryGetValue(upperUniqueName, out IBdoScriptwordDefinition scritpwordDefinition);
                            return scritpwordDefinition;
                        }
                    case BdoExtensionKind.Task:
                        {
                            _taskDictionary.TryGetValue(upperUniqueName, out IBdoTaskDefinition taskDefinition);
                            return taskDefinition;
                        }
                    default:
                        break;
                }
            }

            return default;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public IBdoExtensionStore Clear()
        {
            _entityDictionary.Clear();
            _connectorDictionary.Clear();
            _entityDictionary.Clear();
            _functionDictionary.Clear();
            _scriptWordDictionary.Clear();
            _taskDictionary.Clear();

            return this;
        }

        /// <summary>
        /// Adds the specified definition.
        /// </summary>
        /// <typeparam name="T">The BindOpen extension item definition class to consider.</typeparam>
        /// <param key="definition">The definition to add.</param>
        public IBdoExtensionStore Add(IBdoExtensionDefinition definition)
        {
            var uniqueName = definition?.UniqueName?.ToUpper();

            if (definition is IBdoEntityDefinition carier)
            {
                if (!_entityDictionary.ContainsKey(uniqueName))
                {
                    _entityDictionary.Add(uniqueName, carier);
                }
            }
            else if (definition is IBdoConnectorDefinition connector)
            {
                if (!_connectorDictionary.ContainsKey(uniqueName))
                {
                    _connectorDictionary.Add(uniqueName, connector);
                }
            }
            else if (definition is IBdoEntityDefinition entity)
            {
                if (!_entityDictionary.ContainsKey(uniqueName))
                {
                    _entityDictionary.Add(uniqueName, entity);
                }
            }
            else if (definition is IBdoFunctionDefinition function)
            {
                if (!_functionDictionary.ContainsKey(uniqueName))
                {
                    _functionDictionary.Add(uniqueName, function);
                }
            }
            else if (definition is IBdoScriptwordDefinition scriptWord)
            {
                if (!_scriptWordDictionary.ContainsKey(uniqueName))
                {
                    _scriptWordDictionary.Add(uniqueName, scriptWord);
                }
            }
            else if (definition is IBdoTaskDefinition task)
            {
                if (!_taskDictionary.ContainsKey(uniqueName))
                {
                    _taskDictionary.Add(uniqueName, task);
                }
            }

            return this;
        }

        #endregion


        // ------------------------------------------
        // IIdentified Implementation
        // ------------------------------------------

        #region IIdentified

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        #endregion
    }
}
