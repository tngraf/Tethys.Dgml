# Agent for Tethys.Dgml

## Project Overview

**Tethys.Dgml** is a lightweight .NET library (netstandard2.0) that provides programmatic support for creating Directed Graph Markup Language (DGML) files. DGML is an XML-based format used by Visual Studio to visualize dependency graphs and relationships.

### Key Files & Structure

- **Tethys.Dgml/** - Main library project (NuGet package)
  - `DgmlBuilder.cs` - Primary API for building DGML graphs
  - `Node.cs` - Represents nodes in the graph
  - `Link.cs` - Represents edges/links between nodes
  - `Category.cs` - Represents visual categories (colors, styles)
  - `OutputSettings.cs` - Configuration for graph layout and direction
- **Tethys.Dgml.Demo/** - Example project showing library usage
- **DemoFiles/** - Sample DGML files and visualizations

## Agent Responsibilities

When working on this project, focus on:

1. **Library Maintenance**
   - Fix bugs and improve the core DGML generation logic
   - Maintain backward compatibility (currently on v1.0.0)
   - Ensure XML output conforms to Microsoft's DGML schema

2. **Code Quality**
   - Maintain consistent code style (C# conventions)
   - Apply Apache 2.0 licensing headers to new files
   - Keep documentation in code up to date
   - Use XML documentation comments for public APIs

3. **Building & Testing**
   - Verify builds succeed: `dotnet build`
   - Validate generated DGML files are well-formed XML
   - Test with different target frameworks (netstandard2.0, net5.0, net8.0)

4. **Documentation**
   - Update README.md with usage examples
   - Maintain ChangeLog.md for version history
   - Document API changes in code comments

## Common Tasks

### Building the Project

```powershell
dotnet build
# or with specific configuration
dotnet build -c Release
```

### Running the Demo

```powershell
dotnet run --project Tethys.Dgml.Demo
# generates VerySimpleExample.dgml and CategoriesExample.dgml
```

### Creating NuGet Package

```powershell
dotnet pack Tethys.Dgml/Tethys.Dgml.csproj -c Release
```

### Checking Build Output

- Debug: `Tethys.Dgml/bin/Debug/netstandard2.0/`
- Release: `Tethys.Dgml/bin/Release/netstandard2.0/`

## Code Conventions

- **Namespacing**: All public classes in `Tethys.Dgml` namespace
- **Licensing**: Include Apache 2.0 SPDX header in new files
- **XML Output**: Uses `System.Xml.XmlDocument` for DGML generation
- **Collections**: Use `IList<T>` for Nodes, Links, and Categories

## Code Quality

- Use meaningful variable and function names that clearly describe their purpose
- Include helpful comments for complex logic
- Add error handling for user inputs and API calls

## API Surface

### Core Classes

- `DgmlBuilder` - Main entry point; contains collections and output methods
- `Node(id, label, category)` - Graph vertices
- `Link(source, target)` - Graph edges
- `Category(id, label, color)` - Visual styling
- `OutputSettings` - Controls layout direction and formatting

## Testing Notes

When making changes, verify:

- Generated DGML files are valid XML
- Sample DGML files display correctly in Visual Studio (with DGML Editor)
- Both demo examples produce expected visual results
- All target frameworks compile successfully

## Contributing Guidelines

- Make changes incrementally and test frequently
- Update both code comments and user-facing documentation
- Use descriptive commit messages
- Reference GitHub issues when applicable
- Ensure NuGet package metadata is accurate before releases

## References

- [DGML Reference - Microsoft Docs](https://github.com/MicrosoftDocs/visualstudio-docs/blob/main/docs/modeling/directed-graph-markup-language-dgml-reference.md)
- [GitHub Repository](https://github.com/tngraf/Tethys.Dgml)
- [NuGet Package](https://www.nuget.org/packages/Tethys.Dgml/)
