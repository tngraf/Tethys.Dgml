// -------------------------------------------------------------------------------
// <copyright file="Link.cs" company="Tethys">
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
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains the data for graph edges.
    /// </summary>
    public class Link
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// The name of the color attribute.
        /// </summary>
        public const string IsOptionalAttributeName = "IsOptional";

        /// <summary>
        /// Gets the source node.
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Gets the target node.
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// Gets or sets the stroke thickness.
        /// </summary>
        public string StrokeThickness { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        public string Visibility { get; set; }

        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Gets or sets the stroke.
        /// </summary>
        public string Stroke { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        public Dictionary<string, string> Attributes { get; private set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        /// <param name="source">Source node.</param>
        /// <param name="target">Target node.</param>
        public Link(string source, string target)
        {
            this.Source = source;
            this.Target = target;
            this.Attributes = new Dictionary<string, string>();
        } // Link()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal
        /// to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with
        /// this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal
        /// to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var edge = obj as Link;
            if (edge == null)
            {
                return false;
            } // if

            if (this.Source != edge.Source)
            {
                return false;
            } // if

            if (this.Target != edge.Target)
            {
                return false;
            } // if

            if (this.Attributes.Count != edge.Attributes.Count)
            {
                return false;
            } // if

            return this.Attributes.All(
                edgeAttribute => edge.Attributes.Contains(edgeAttribute));
        } // Equals()

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms
        /// and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            var hash = 0;

            hash = hash + this.Source.GetHashCode();
            hash = hash + this.Target.GetHashCode();

            return this.Attributes.Aggregate(
                hash,
                (current, edgeAttribute) => current + edgeAttribute.ToString().GetHashCode());
        } // GetHashCode()

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder(50);

            sb.AppendFormat($"{this.Source} => {this.Target}");

            if (this.Attributes.Count > 0)
            {
                sb.Append(" [");

                foreach (var attribute in this.Attributes)
                {
                    sb.Append(attribute.Key);
                    sb.Append("=");
                    sb.Append(attribute.Key);
                    sb.Append(",");
                } // foreach

                sb.Append("]");
            } // if

            return sb.ToString();
        } // ToString()
        #endregion // PUBLIC METHODS
    } // Link
}
