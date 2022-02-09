// -------------------------------------------------------------------------------
// <copyright file="Category.cs" company="Tethys">
//   Copyright (C) 2016-2021 Thomas Graf
//   All Rights Reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// SPDX-License-Identifier: Apache-2.0
// -------------------------------------------------------------------------------

namespace Tethys.Dgml
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Implements the category information.
    /// </summary>
    public class Category
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the category label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the category background color.
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        public Dictionary<string, string> Attributes { get; private set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            this.Id = string.Empty;
            this.Label = string.Empty;
            this.Background = string.Empty;
            this.Attributes = new Dictionary<string, string>();
        } // Category()

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="label">The label.</param>
        /// <param name="background">The background.</param>
        public Category(string id, string label, string background)
        {
            this.Id = id;
            this.Label = label;
            this.Background = background;
            this.Attributes = new Dictionary<string, string>();
        } // Category()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder(100);
            sb.Append($"Id={this.Id}, Label={this.Label}, Background={this.Background}, Attributes=[");
            foreach (var pair in this.Attributes)
            {
                sb.Append($"(Key={pair.Key}, Value={pair.Value})");
            } // foreach

            sb.Append("]");
            return sb.ToString();
        } // ToString()
        #endregion // PUBLIC METHODS
    } // Category
}