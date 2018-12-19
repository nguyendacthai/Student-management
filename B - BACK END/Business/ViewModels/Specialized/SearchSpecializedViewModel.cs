﻿using System.Collections.Generic;
using Database.Enumerations;
using Shared.Enumerations.Specialized;
using Shared.Models;

namespace Business.ViewModels.Specialized
{
    public class SearchSpecializedViewModel
    {
        /// <summary>
        /// Indexes of specialized
        /// </summary>
        public List<int> Ids { get; set; }

        /// <summary>
        /// Names of specialized
        /// </summary>
        public List<string> Names { get; set; }

        /// <summary>
        /// Statuses of specialized.
        /// </summary>
        public List<MasterItemStatus> Statuses { get; set; }

        /// <summary>
        /// Pagination information.
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Sort direction and property.
        /// </summary>
        public Sorting<SpecializedPropertySort> Sort { get; set; }
    }
}