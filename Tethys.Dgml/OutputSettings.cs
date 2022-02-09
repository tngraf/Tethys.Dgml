// -------------------------------------------------------------------------------
// <copyright file="OutputSettings.cs" company="Tethys">
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
    /// <summary>
    /// Graph directions.
    /// </summary>
    public enum GraphDirection
    {
        /// <summary>
        /// Draw nodes top to bottom.
        /// </summary>
        TopToBottom = 0,

        /// <summary>
        /// Draw nodes left to right.
        /// </summary>
        LeftToRight = 1,
    } // GraphDirection

    /// <summary>
    /// Output settings for the NuGet Dependency Analyzer.
    /// </summary>
    public class OutputSettings
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets a value indicating whether to use color coding.
        /// </summary>
        public bool UseColorCoding { get; set; }

        /// <summary>
        /// Gets or sets the graph direction.
        /// </summary>
        public GraphDirection GraphDirection { get; set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputSettings"/> class.
        /// </summary>
        public OutputSettings()
        {
            this.UseColorCoding = true;
            this.GraphDirection = GraphDirection.LeftToRight;
        } // OutputSettings()
        #endregion // CONSTRUCTION
    } // OutputSettings
}
