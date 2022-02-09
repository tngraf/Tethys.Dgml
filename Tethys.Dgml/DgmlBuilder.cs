// -------------------------------------------------------------------------------
// <copyright file="DgmlBuilder.cs" company="Tethys">
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

//// See also https://github.com/merijndejonge/DgmlBuilder/tree/master/src/DgmlBuilder/Model

namespace Tethys.Dgml
{
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Build a DGML graph.
    /// </summary>
    public class DgmlBuilder
    {
        //// ---------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the name format.
        /// </summary>
        public string NameFormat { get; set; }

        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        public IList<Node> Nodes { get; set; }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        public IList<Link> Links { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public IList<Category> Categories { get; set; }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        public OutputSettings Settings { get; private set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="DgmlBuilder" /> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public DgmlBuilder(OutputSettings settings)
        {
            this.Settings = settings;
            this.Nodes = new List<Node>();
            this.Links = new List<Link>();
            this.Categories = new List<Category>();
        } // DgmlBuilder()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Creates a DGML file from the given data.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void WriteToFile(string filename)
        {
            var xmlsettings = new XmlWriterSettings();
            xmlsettings.Encoding = Encoding.UTF8;
            xmlsettings.Indent = true;

            using (var writer = XmlWriter.Create(filename, xmlsettings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("DirectedGraph", "http://schemas.microsoft.com/vs/2009/dgml");
                if (this.Settings.GraphDirection == GraphDirection.LeftToRight)
                {
                    writer.WriteAttributeString("Layout", "Sugiyama");
                    writer.WriteAttributeString("GraphDirection", "LeftToRight");
                } // if

                writer.WriteStartElement("Nodes");
                this.WriteNodes(writer);
                writer.WriteEndElement();

                writer.WriteStartElement("Categories");
                this.WriteCategories(writer);
                writer.WriteEndElement();

                writer.WriteStartElement("Links");
                this.WriteLinks(writer);
                writer.WriteEndElement();

                writer.WriteEndElement(); // end of DirectedGraph
                writer.WriteEndDocument();
            } // using
        } // CreateFile()
        #endregion // PUBLIC METHODS

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Writes the nodes.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void WriteNodes(XmlWriter writer)
        {
            foreach (var node in this.Nodes)
            {
                writer.WriteStartElement("Node");
                writer.WriteAttributeString("Id", node.Id);

                if (!string.IsNullOrEmpty(node.Name))
                {
                    writer.WriteAttributeString("Label", node.Name);
                } // if

                if (!string.IsNullOrEmpty(node.Category))
                {
                    writer.WriteAttributeString("Category", node.Category);
                } // if

                if (node.Attributes.ContainsKey("COLOR"))
                {
                    writer.WriteAttributeString(
                        "Background",
                        node.Attributes["COLOR"]);
                } // if

                writer.WriteEndElement();
            } // foreach
        } // WriteNodes()

        /// <summary>
        /// Writes the links.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void WriteLinks(XmlWriter writer)
        {
            foreach (var link in this.Links)
            {
                writer.WriteStartElement("Link");
                writer.WriteAttributeString("Source", link.Source);
                writer.WriteAttributeString("Target", link.Target);
                if (link.Attributes.ContainsKey(Link.IsOptionalAttributeName))
                {
                    if (link.Attributes[Link.IsOptionalAttributeName].ToUpperInvariant() == "TRUE")
                    {
                        writer.WriteAttributeString("StrokeDashArray", "2,2");
                    } // if
                } // if

                writer.WriteEndElement();
            } // foreach
        } // WriteLinks()

        /// <summary>
        /// Writes the categories.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void WriteCategories(XmlWriter writer)
        {
            foreach (var category in this.Categories)
            {
                writer.WriteStartElement("Category");
                writer.WriteAttributeString("Id", category.Id);
                writer.WriteAttributeString("Background", category.Background);

                writer.WriteEndElement();
            } // foreach
        } // WriteCategories()
        #endregion // PRIVATE METHODS
    } // DgmlBuilder
}
