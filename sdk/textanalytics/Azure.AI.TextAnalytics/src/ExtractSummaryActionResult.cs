﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the execution of an <see cref="ExtractSummaryAction"/> on the input documents.
    /// </summary>
    public class ExtractSummaryActionResult : TextAnalyticsActionResult
    {
        private readonly ExtractSummaryResultCollection _documentsResults;

        /// <summary>
        /// Successful action.
        /// </summary>
        internal ExtractSummaryActionResult(ExtractSummaryResultCollection result, string actionName, DateTimeOffset completedOn)
            : base(actionName, completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Action with an error.
        /// </summary>
        internal ExtractSummaryActionResult(string actionName, DateTimeOffset completedOn,TextAnalyticsErrorInternal error)
            : base(actionName, completedOn, error) { }

        /// <summary>
        /// Gets the result of the execution of an <see cref="ExtractSummaryAction"/> per each input document.
        /// </summary>
        public ExtractSummaryResultCollection DocumentsResults
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException($"Cannot access the results of this action, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _documentsResults;
            }
        }
    }
}
