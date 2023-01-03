﻿using BindOpen.Data;
using BindOpen.Data.Elements;
using BindOpen.Runtime.Definition;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.Extensions.Processing
{
    /// <summary>
    /// This class represents a task configuration.
    /// </summary>
    public class BdoTaskConfiguration
        : TBdoExtensionTitledItemConfiguration<IBdoTaskDefinition>, IBdoTaskConfiguration
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Input detail of this instance.
        /// </summary>
        public IBdoElementSet InputDetail { get; set; }


        /// <summary>
        /// Output detail of this instance.
        /// </summary>
        public IBdoElementSet OutputDetail { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoTaskConfiguration class.
        /// </summary>
        public BdoTaskConfiguration() : this(null)
        {
        }

        /// <summary>
        /// Instantiates a new instance of the BdoTaskConfiguration class.
        /// </summary>
        public BdoTaskConfiguration(string definitionUniqueId)
            : base(BdoExtensionItemKind.Task, definitionUniqueId)
        {
        }

        #endregion

        // ------------------------------------------
        // MUTATORS
        // ------------------------------------------

        #region Mutators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public new IBdoTaskConfiguration Add(params IBdoElement[] items)
        {
            base.Add(items);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public new IBdoTaskConfiguration WithItems(params IBdoElement[] items)
        {
            base.WithItems(items);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"></param>
        public IBdoTaskConfiguration AddInputs(params IBdoElement[] inputs)
        {
            if (InputDetail == null) InputDetail = new BdoElementSet();
            InputDetail.Add(inputs);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"></param>
        public IBdoTaskConfiguration WithInputs(params IBdoElement[] inputs)
        {
            if (InputDetail == null) InputDetail = new BdoElementSet();
            InputDetail.WithItems(inputs);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputs"></param>
        public IBdoTaskConfiguration AddOutputs(params IBdoElement[] outputs)
        {
            if (OutputDetail == null) OutputDetail = new BdoElementSet();
            OutputDetail.Add(outputs);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputs"></param>
        public IBdoTaskConfiguration WithOutputs(params IBdoElement[] outputs)
        {
            if (OutputDetail == null) OutputDetail = new BdoElementSet();
            OutputDetail.WithItems(outputs);
            return this;
        }

        #endregion

        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors

        // Entries --------------------------------

        /// <summary>
        /// Gets the specified entries.
        /// </summary>
        /// <param name="taskEntryKinds">The kind end entries to consider.</param>
        /// <returns>True if this instance is configurable.</returns>
        public List<IBdoElement> GetEntries(params TaskEntryKind[] taskEntryKinds)
        {
            if (taskEntryKinds.Length == 0)
                taskEntryKinds = new TaskEntryKind[1] { TaskEntryKind.Any };

            var elements = new List<IBdoElement>();

            if ((taskEntryKinds.Contains(TaskEntryKind.Any)) || (taskEntryKinds.Contains(TaskEntryKind.Input)))
            {
                elements.AddRange(InputDetail.ToList());
            }

            if ((taskEntryKinds.Contains(TaskEntryKind.Any)) || (taskEntryKinds.Contains(TaskEntryKind.Output)))
                elements.AddRange(OutputDetail.Items);
            if ((taskEntryKinds.Contains(TaskEntryKind.Any)) || (taskEntryKinds.Contains(TaskEntryKind.ScalarOutput)))
                elements.AddRange(OutputDetail.Items.Where(p => p.ValueType.IsScalar()));
            if ((taskEntryKinds.Contains(TaskEntryKind.Any)) || (taskEntryKinds.Contains(TaskEntryKind.NonScalarOutput)))
                elements.AddRange(OutputDetail.Items.Where(p => !p.ValueType.IsScalar()));

            return elements.Distinct().ToList();
        }

        /// <summary>
        /// Returns the entry of the specified kind with the specified unique name.
        /// </summary>
        /// <param name="key">The key to consider.</param>
        /// <param name="taskEntryKinds">The kind end entries to consider.</param>
        /// <returns>Returns the input with the specified name.</returns>
        public IBdoElement GetEntryWithName(string key, params TaskEntryKind[] taskEntryKinds)
        {
            return GetEntries(taskEntryKinds).Find(p => p.BdoKeyEquals(key));
        }

        #endregion

        //------------------------------------------
        // CLONING
        //-----------------------------------------

        #region Cloning

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns the cloned metrics definition.</returns>
        public override object Clone(params string[] areas)
        {
            BdoTaskConfiguration task = base.Clone(areas) as BdoTaskConfiguration;

            if (InputDetail != null)
            {
                task.InputDetail = InputDetail.Clone() as BdoElementSet;
            }

            if (OutputDetail != null)
            {
                task.OutputDetail = OutputDetail.Clone() as BdoElementSet;
            }

            return task;
        }

        #endregion

        // ------------------------------------------
        // IDISPOSABLE METHODS
        // ------------------------------------------

        #region IDisposable_Methods

        private bool _isDisposed = false;

        /// <summary>
        /// Disposes this instance. 
        /// </summary>
        /// <param name="isDisposing">Indicates whether this instance is disposing</param>
        protected override void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            InputDetail?.Dispose();
            OutputDetail?.Dispose();

            _isDisposed = true;

            base.Dispose(isDisposing);
        }

        #endregion
    }
}