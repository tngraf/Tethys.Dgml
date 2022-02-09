// -------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Tethys">
//   Copyright (C) 2022 Thomas Graf
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

using System;

namespace Tethys.Dgml.Demo
{
    /// <summary>
    /// Main class of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Creating DGML example files...");
            VerySimpleExample();
            CategoriesExample();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Create a very simple DGML file.
        /// </summary>
        private static void VerySimpleExample()
        {
            var settings = new OutputSettings();
            settings.GraphDirection = GraphDirection.LeftToRight;
            var builder = new DgmlBuilder(settings);

            builder.Nodes.Add(new Node("A", "A", null));
            builder.Nodes.Add(new Node("B", "B", null));

            builder.Links.Add(new Link("A", "B"));

            builder.WriteToFile("VerySimpleExample.dgml");
        }

        /// <summary>
        /// Create a simple DGML file using categories.
        /// </summary>
        private static void CategoriesExample()
        {
            var settings = new OutputSettings();
            settings.GraphDirection = GraphDirection.LeftToRight;
            var builder = new DgmlBuilder(settings);

            builder.Categories.Add(new Category("Blue", "Blue", "#0000FF"));
            builder.Categories.Add(new Category("Green", "Green", "#00FF00"));
            builder.Categories.Add(new Category("Red", "Red", "#FF0000"));

            builder.Nodes.Add(new Node("A", "Node A", "Blue"));
            builder.Nodes.Add(new Node("B", "Node B", "Green"));
            builder.Nodes.Add(new Node("C", "Node C", "Red"));
            builder.Nodes.Add(new Node("D", "Node D", null));

            builder.Links.Add(new Link("A", "B"));
            builder.Links.Add(new Link("A", "C"));
            builder.Links.Add(new Link("C", "D"));

            builder.WriteToFile("CategoriesExample.dgml");
        }
    }
}
