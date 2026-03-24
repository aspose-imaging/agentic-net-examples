---
name: aspose-imaging-examples
description: AI-friendly C# code examples for Aspose.Imaging for .NET
language: csharp
framework: net9.0
package: Aspose.Imaging
---

# Aspose.Imaging for .NET Examples

AI-friendly repository containing validated C# examples for Aspose.Imaging for .NET API.

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET.
When working in this repository:
- Each `.cs` file is a **standalone Console Application** - do not create multi-file projects
- All examples must **compile and run** without errors using `dotnet build` and `dotnet run`
- Follow the conventions, boundaries, and anti-patterns documented below exactly
- Use the **Command Reference** section for build/run commands

## Repository Overview

This repository contains **1047** working code examples demonstrating Aspose.Imaging for .NET capabilities.

**Statistics** (as of 2026-03-24):
- Total Examples: 1047
- Categories: 7
- Overall Pass Rate: 100.0%

## Category Details

### conversion
- Examples: 162
- Guide: [agents.md](./conversion/agents.md)

### image-and-photo-filters
- Examples: 64
- Guide: [agents.md](./image-and-photo-filters/agents.md)

### kernel-filters
- Examples: 233
- Guide: [agents.md](./kernel-filters/agents.md)

### manipulate-different-image-file-formats
- Examples: 168
- Guide: [agents.md](./manipulate-different-image-file-formats/agents.md)

### manipulating-images
- Examples: 170
- Guide: [agents.md](./manipulating-images/agents.md)

### merge-images
- Examples: 95
- Guide: [agents.md](./merge-images/agents.md)

### working-with-drawing-images
- Examples: 155
- Guide: [agents.md](./working-with-drawing-images/agents.md)

## Boundaries

### Always

These rules are mandatory for every example.

#### Use explicit types - never use `var`
```csharp
// CORRECT
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png"))
{
    RasterImage raster = (RasterImage)image;
    PngOptions options = new PngOptions();
}

// WRONG
// var image = Aspose.Imaging.Image.Load("input.png");
```

#### Use `using` blocks for IDisposable objects
```csharp
// CORRECT
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png"))
{
    image.Save("output.png");
}

// WRONG - memory leak, file lock not released
// Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png");
// image.Save("output.png");
```

#### Fully qualify the Image class to avoid ambiguity
```csharp
// CORRECT
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png"))
{ }

// WRONG - ambiguous with System.Drawing.Image
// using (Image image = Image.Load("input.png")) { }
```

#### Save the image after all modifications
```csharp
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png"))
{
    // ... make modifications ...
    image.Save("output.png");
}
```

### Ask First

Check with a human before doing any of these:
- **Creating multi-file projects** - each example must be a single `.cs` file
- **Using deprecated APIs** - check the Aspose.Imaging changelog for the current API surface
- **Adding NuGet packages** beyond `Aspose.Imaging` - the `.csproj` template only includes Aspose.Imaging
- **Modifying shared infrastructure** - `.csproj` templates, `agents.md` files, CI configs

### Never

- Never use `var` for variable declarations
- Never use unqualified `Image` - always use `Aspose.Imaging.Image`
- Never forget to dispose images - always use `using` blocks
- Never modify `agents.md` files - they are auto-generated
- Never modify the `.csproj` template - it is generated

## Common Mistakes (Anti-Patterns)

### Unqualified Image Type
```csharp
// WRONG - CS0104 ambiguous between System.Drawing.Image and Aspose.Imaging.Image
Image image = Image.Load("input.png");
```
```csharp
// CORRECT
Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png");
```

### Missing using block
```csharp
// WRONG - memory leak, file lock not released
Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png");
image.Save("output.png");
```
```csharp
// CORRECT
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png"))
{
    image.Save("output.png");
}
```

### Using var
```csharp
// WRONG
var image = Aspose.Imaging.Image.Load("input.png");
var options = new PngOptions();
```
```csharp
// CORRECT
Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png");
PngOptions options = new PngOptions();
```

## Repository Structure

```
agents.md
README.md
+-- conversion/
+-- image-and-photo-filters/
+-- kernel-filters/
+-- manipulate-different-image-file-formats/
+-- manipulating-images/
+-- merge-images/
+-- working-with-drawing-images/
```

## Category Index

| Category | Examples | Pass Rate | Details |
|----------|----------|-----------|---------|
| [Conversion](./conversion/) | 162 | 100.0% | [agents.md](./conversion/agents.md) |
| [Image and Photo Filters](./image-and-photo-filters/) | 64 | 100.0% | [agents.md](./image-and-photo-filters/agents.md) |
| [Kernel Filters](./kernel-filters/) | 233 | 100.0% | [agents.md](./kernel-filters/agents.md) |
| [Manipulate Different Image File Formats](./manipulate-different-image-file-formats/) | 168 | 100.0% | [agents.md](./manipulate-different-image-file-formats/agents.md) |
| [Manipulating Images](./manipulating-images/) | 170 | 100.0% | [agents.md](./manipulating-images/agents.md) |
| [Merge Images](./merge-images/) | 95 | 100.0% | [agents.md](./merge-images/agents.md) |
| [Working With Drawing Images](./working-with-drawing-images/) | 155 | 100.0% | [agents.md](./working-with-drawing-images/agents.md) |

## Command Reference

### Build and Run
```bash
# Create a new project (if needed)
dotnet new console -n ExampleProject --framework net9.0

# Add Aspose.Imaging NuGet package
dotnet add package Aspose.Imaging

# Build
dotnet build --configuration Release --verbosity minimal

# Run
dotnet run
```

### Project File (.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Aspose.Imaging" Version="*" />
  </ItemGroup>
</Project>
```

## Testing Guide

Every example must pass these verification steps.

### Build Verification
```bash
dotnet build --configuration Release --verbosity minimal
```
- **Success**: Exit code 0, no `CS` error codes in output
- **Failure**: Any `error CS####` line indicates a build failure

### Common Error Codes
| Code | Meaning | Fix |
|------|---------|-----|
| `CS0104` | Ambiguous type reference | Use `Aspose.Imaging.Image` fully qualified |
| `CS1061` | Member does not exist on type | Check Aspose.Imaging API docs |
| `CS0246` | Type or namespace not found | Add missing `using` directive |
| `CS0029` | Cannot convert type | Cast explicitly or use correct type |

## How to Use These Examples

### Prerequisites
- .NET SDK (8.0 or higher)
- Aspose.Imaging for .NET (via NuGet)

### Running an Example
1. Navigate to any category folder
2. Each .cs file is a standalone Console Application
3. Compile and run:
   ```bash
   dotnet run <example-file.cs>
   ```

<!-- AUTOGENERATED:START -->
Updated: 2026-03-24 | Run: `20260324_042406` | Examples: 1047 | Categories: 7
<!-- AUTOGENERATED:END -->

---
*This repository is maintained by automated code generation. Last updated: 2026-03-24 | Total examples: 1047*