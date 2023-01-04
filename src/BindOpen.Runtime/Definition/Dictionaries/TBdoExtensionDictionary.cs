﻿using BindOpen.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.Runtime.Definition
{
    /// <summary>
    /// This class represents a BindOpen extension dictionary.
    /// </summary>
    /// <typeparam name="T">The class of extension item definition to consider.</typeparam>
    public class TBdoExtensionDictionary<T> : BdoItem,
        ITBdoExtensionDictionary<T>
        where T : IBdoExtensionItemDefinition
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the TBdoExtensionDictionary class.
        /// </summary>
        public TBdoExtensionDictionary()
        {
        }

        #endregion

        // ------------------------------------------
        // ITBdoExtensionDictionary Implementation
        // ------------------------------------------

        #region ITBdoExtensionDictionary

        /// <summary>
        /// ID of the library of this instance.
        /// </summary>
        public string LibraryId { get; set; }

        public ITBdoExtensionDictionary<T> WithLibraryId(string libraryId)
        {
            LibraryId = libraryId;
            return this;
        }

        /// <summary>
        /// Name of the library of this instance.
        /// </summary>
        public string LibraryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryName"></param>
        /// <returns></returns>
        public ITBdoExtensionDictionary<T> WithLibraryName(string libraryName)
        {
            LibraryName = libraryName;
            return this;
        }

        /// <summary>
        /// Definitions of this instance.
        /// </summary>
        public List<T> Definitions { get; set; } = new List<T>();

        public ITBdoExtensionDictionary<T> WithDefinitions(params T[] definitions)
        {
            Definitions = definitions.ToList();
            return this;
        }

        public ITBdoExtensionDictionary<T> AddDefinitions(params T[] definitions)
        {
            Definitions ??= new List<T>();
            Definitions.AddRange(definitions.ToList());
            return this;
        }

        /// <summary>
        /// Groups of this instance.
        /// </summary>
        public List<IBdoExtensionItemGroup> Groups { get; set; }

        public ITBdoExtensionDictionary<T> WithGroups(params IBdoExtensionItemGroup[] groups)
        {
            Groups = groups.ToList();
            return this;
        }

        public ITBdoExtensionDictionary<T> AddGroups(params IBdoExtensionItemGroup[] groups)
        {
            Groups ??= new List<IBdoExtensionItemGroup>();
            Groups.AddRange(groups.ToList());
            return this;
        }

        #endregion

        // ------------------------------------------
        // ITStorablePoco Implementation
        // ------------------------------------------

        #region ITStorablePoco

        /// <summary>
        /// Creation date of this instance.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Creation date of this instance.
        /// </summary>
        public IBdoExtensionDictionary WithCreationDate(DateTime? date)
        {
            CreationDate = date;
            return this;
        }

        /// <summary>
        /// Last modification date of this instance.
        /// </summary>
        public DateTime? LastModificationDate { get; set; }

        /// <summary>
        /// Creation date of this instance.
        /// </summary>
        public IBdoExtensionDictionary WithLastModificationDate(DateTime? date)
        {
            LastModificationDate = date;
            return this;
        }

        #endregion

        // ------------------------------------------
        // IReferenced Implementation
        // ------------------------------------------

        #region IReferenced

        /// <summary>
        /// 
        /// </summary>
        public string Key() => Name;

        #endregion

        // ------------------------------------------
        // IIdentifiedPoco Implementation
        // ------------------------------------------

        #region IIdentifiedPoco

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IBdoExtensionDictionary WithId(string id)
        {
            Id = id;
            return this;
        }

        #endregion

        // ------------------------------------------
        // INamedPoco Implementation
        // ------------------------------------------

        #region INamedPoco

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoExtensionDictionary WithName(string name)
        {
            Name = BdoItems.NewName(name, "spec_");
            return this;
        }

        #endregion

        // ------------------------------------------
        // IGloballyTitled Implementation
        // ------------------------------------------

        #region IGloballyTitled

        /// <summary>
        /// 
        /// </summary>
        public IBdoDictionary Title { get; set; }

        public IBdoExtensionDictionary AddTitle(KeyValuePair<string, string> item)
        {
            Title ??= BdoItems.NewDictionary();
            Title.Add(item);
            return this;
        }

        public IBdoExtensionDictionary WithTitle(IBdoDictionary dictionary)
        {
            Title = dictionary;
            return this;
        }

        public string GetTitleText(string key = "*", string defaultKey = "*")
        {
            return Title?[key, defaultKey];
        }

        #endregion

        // ------------------------------------------
        // IGloballyDescribed Implementation
        // ------------------------------------------

        #region IGloballyDescribed

        /// <summary>
        /// 
        /// </summary>
        public IBdoDictionary Description { get; set; }

        public IBdoExtensionDictionary AddDescription(KeyValuePair<string, string> item)
        {
            Description ??= BdoItems.NewDictionary();
            Description.Add(item);
            return this;
        }

        public IBdoExtensionDictionary WithDescription(IBdoDictionary dictionary)
        {
            Description = dictionary;
            return this;
        }

        public string GetDescriptionText(string key = "*", string defaultKey = "*")
        {
            return Description?[key, defaultKey];
        }

        #endregion

    }
}