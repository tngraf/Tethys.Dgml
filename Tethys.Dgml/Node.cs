// -------------------------------------------------------------------------------
// <copyright file="Node.cs" company="Tethys">
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
    /// Implements the node information.
    /// </summary>
    public class Node
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the node id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the node name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the node category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        public Dictionary<string, string> Attributes { get; private set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        public Node()
        {
            this.Id = string.Empty;
            this.Name = string.Empty;
            this.Attributes = new Dictionary<string, string>();
        } // Node()

        /// <summary>
        /// Initializes a new instance of the <see cref="Node" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        public Node(string id, string name, string category)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Attributes = new Dictionary<string, string>();
        } // Node()
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
            sb.Append($"Id={this.Id}, Name={this.Name}, Attributes=[");
            foreach (var pair in this.Attributes)
            {
                sb.Append($"(Key={pair.Key}, Value={pair.Value})");
            } // foreach

            sb.Append("]");
            return sb.ToString();
        } // ToString()
        #endregion // PUBLIC METHODS
    } // Node
}