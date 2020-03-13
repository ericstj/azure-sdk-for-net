﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search
{
    /// <summary>
    /// Options for <see cref="SearchIndexClient.SuggestAsync"/> that
    /// allow specifying filtering, sorting, and other suggestions query
    /// behaviors.
    /// </summary>
    [CodeGenSchema("SuggestRequest")]
    public partial class SuggestOptions : SearchRequestOptions
    {
        /// <summary>
        /// The search text to use to suggest documents. Must be at least 1
        /// character, and no more than 100 characters.
        /// </summary>
        [CodeGenSchemaMember("search")]
        internal string SearchText { get; set; }

        /// <summary>
        /// The name of the suggester as specified in the suggesters collection
        /// that's part of the index definition.
        /// </summary>
        [CodeGenSchemaMember("suggesterName")]
        internal string SuggesterName { get; set; }

        /// <summary>
        /// An OData expression that filters the documents considered for
        /// suggestions.  You can use
        /// <see cref="SearchFilter.Create(FormattableString)"/> to help
        /// construct the filter expression.
        /// </summary>
        [CodeGenSchemaMember("filter")]
        public string Filter { get; set; }

        /// <summary>
        /// The list of field names to search for the specified search text.
        /// Target fields must be included in the specified suggester.
        /// </summary>
        public IList<string> SearchFields { get; internal set; } = new List<string>();

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join SearchFields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenSchemaMember("searchFields")]
        internal string SearchFieldsRaw
        {
            get => SearchFields.CommaJoin();
            set => throw new InvalidOperationException($"Cannot deserialize {nameof(SuggestOptions)}.");
        }
        #pragma warning restore CA1822

        /// <summary>
        /// The list of fields to retrieve. If unspecified, only the key field
        /// will be included in the results.
        /// </summary>
        public IList<string> Select { get; internal set; } = new List<string>();

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join Select so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenSchemaMember("select")]
        internal string SelectRaw
        {
            get => Select.CommaJoin();
            set => throw new InvalidOperationException($"Cannot deserialize {nameof(SuggestOptions)}.");
        }
        #pragma warning restore CA1822

        /// <summary>
        /// The number of suggestions to retrieve. This must be a value between
        /// 1 and 100. The default is 5.
        /// </summary>
        [CodeGenSchemaMember("top")]
        public int? Size { get; set; }

        /// <summary>
        /// The list of OData $orderby expressions by which to sort the
        /// results. Each expression can be either a field name or a call to
        /// either the geo.distance() or the search.score() functions.  Each
        /// expression can be followed by asc to indicate ascending, or desc
        /// to indicate descending. The default is ascending order. Ties will
        /// be broken by the match scores of documents. If no $orderby is
        /// specified, the default sort order is descending by document match
        /// score. There can be at most 32 $orderby clauses.
        /// </summary>
        public IList<string> OrderBy { get; internal set; } = new List<string>();

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join OrderBy so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenSchemaMember("orderby")]
        internal string OrderByRaw
        {
            get => OrderBy.CommaJoin();
            set => throw new InvalidOperationException($"Cannot deserialize {nameof(SuggestOptions)}.");
        }
        #pragma warning restore CA1822
    }
}
