---
name: aspose-imaging-examples
description: AI-friendly C# code examples for Aspose.Imaging for .NET
language: csharp
framework: net9.0
package: Aspose.Imaging
---

# Aspose.Imaging for .NET Examples

AI-friendly index of compiler-validated C# examples for Aspose.Imaging for .NET.

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET.
When working in this repository:
- Each `.cs` file is a **standalone Console Application** - do not create multi-file projects
- All examples must **compile and run** without errors using `dotnet build` and `dotnet run`
- Follow the conventions, boundaries, and anti-patterns documented below exactly
- Use the **Command Reference** section for build/run commands

## Repository Overview

This repository contains **4856** working code examples demonstrating Aspose.Imaging for .NET capabilities.

**Statistics** (as of 2026-06-29):
- Total Examples: 2901
- Categories: 17
- Overall Pass Rate: 100.0%

## Category Details

### conversion
- Examples: 162
- Guide: [agents.md](./conversion/agents.md)

### convert-apng
- Examples: 102
- Guide: [agents.md](./convert-apng/agents.md)

### convert-cdr
- Examples: 120
- Guide: [agents.md](./convert-cdr/agents.md)

### convert-cmx-images
- Examples: 102
- Guide: [agents.md](./convert-cmx-images/agents.md)

### convert-dicom-images
- Examples: 60
- Guide: [agents.md](./convert-dicom-images/agents.md)

### convert-eps-images
- Examples: 120
- Guide: [agents.md](./convert-eps-images/agents.md)

### convert-open-document-graphics
- Examples: 240
- Guide: [agents.md](./convert-open-document-graphics/agents.md)

### convert-raster-image
- Examples: 279
- Guide: [agents.md](./convert-raster-image/agents.md)

### convert-svg-to-raster-images
- Examples: 80
- Guide: [agents.md](./convert-svg-to-raster-images/agents.md)

### convert-webp-images
- Examples: 60
- Guide: [agents.md](./convert-webp-images/agents.md)

### converting-wmf-and-emf
- Examples: 58
- Guide: [agents.md](./converting-wmf-and-emf/agents.md)

### image-and-photo-filters
- Examples: 282
- Guide: [agents.md](./image-and-photo-filters/agents.md)

### kernel-filters
- Examples: 695
- Guide: [agents.md](./kernel-filters/agents.md)

### manipulate-different-image-file-formats
- Examples: 1032
- Guide: [agents.md](./manipulate-different-image-file-formats/agents.md)

### manipulating-images
- Examples: 650
- Guide: [agents.md](./manipulating-images/agents.md)

### merge-images
- Examples: 175
- Guide: [agents.md](./merge-images/agents.md)

### working-with-drawing-images
- Examples: 639
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
+-- convert-apng/
+-- convert-cdr/
+-- convert-cmx-images/
+-- convert-dicom-images/
+-- convert-eps-images/
+-- convert-open-document-graphics/
+-- convert-raster-image/
+-- convert-svg-to-raster-images/
+-- convert-webp-images/
+-- converting-wmf-and-emf/
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
| [Convert APNG](./convert-apng/) | 51 | 100.0% | [agents.md](./convert-apng/agents.md) |
| [Convert CDR](./convert-cdr/) | 30 | 100.0% | [agents.md](./convert-cdr/agents.md) |
| [Convert CMX Images](./convert-cmx-images/) | 34 | 100.0% | [agents.md](./convert-cmx-images/agents.md) |
| [Convert DICOM Images](./convert-dicom-images/) | 30 | 100.0% | [agents.md](./convert-dicom-images/agents.md) |
| [Convert EPS Images](./convert-eps-images/) | 60 | 100.0% | [agents.md](./convert-eps-images/agents.md) |
| [Convert Open Document Graphics](./convert-open-document-graphics/) | 120 | 100.0% | [agents.md](./convert-open-document-graphics/agents.md) |
| [Convert Raster Image](./convert-raster-image/) | 139 | 100.0% | [agents.md](./convert-raster-image/agents.md) |
| [Convert SVG to Raster Images](./convert-svg-to-raster-images/) | 40 | 100.0% | [agents.md](./convert-svg-to-raster-images/agents.md) |
| [Convert webp Images](./convert-webp-images/) | 30 | 100.0% | [agents.md](./convert-webp-images/agents.md) |
| [Converting WMF and EMF](./converting-wmf-and-emf/) | 29 | 100.0% | [agents.md](./converting-wmf-and-emf/agents.md) |
| [Image and Photo Filters](./image-and-photo-filters/) | 148 | 100.0% | [agents.md](./image-and-photo-filters/agents.md) |
| [Kernel Filters](./kernel-filters/) | 465 | 100.0% | [agents.md](./kernel-filters/agents.md) |
| [Manipulate Different Image File Formats](./manipulate-different-image-file-formats/) | 602 | 100.0% | [agents.md](./manipulate-different-image-file-formats/agents.md) |
| [Manipulating Images](./manipulating-images/) | 425 | 100.0% | [agents.md](./manipulating-images/agents.md) |
| [Merge Images](./merge-images/) | 135 | 100.0% | [agents.md](./merge-images/agents.md) |
| [Working With Drawing Images](./working-with-drawing-images/) | 401 | 100.0% | [agents.md](./working-with-drawing-images/agents.md) |

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





## Related Resources

Aspose.Imaging for .NET is a UI-agnostic backend API that integrates into any .NET application — ASP.NET Core, console apps, Azure Functions, Docker containers — without requiring a display or UI framework.

| Resource | Link |
|----------|------|
| 📖 Documentation | [docs.aspose.com/imaging/net](https://docs.aspose.com/imaging/net/) |
| 📦 NuGet Package | [www.nuget.org/packages/aspose.imaging](https://www.nuget.org/packages/aspose.imaging) |
| 🚀 Release Notes | [releases.aspose.com/imaging/net](https://releases.aspose.com/imaging/net/) |
| 🌐 Online Apps | [products.aspose.app/imaging/family](https://products.aspose.app/imaging/family/) |
| 🔑 Free Temporary License | [purchase.aspose.com/temporary-license](https://purchase.aspose.com/temporary-license) |
| 🤝 Consulting (paid implementation help) | [consulting.aspose.com](https://consulting.aspose.com/) |

## Agent Capabilities
- **MCP‑compatible image processing agent** – can be invoked through an MCP server to perform on‑demand image‑processing tasks using Aspose.Imaging for .NET.  
- **REST API for C# code generation** – exposes a `POST /generate-code` endpoint that accepts a JSON payload describing the desired operation and returns ready‑to‑run C# snippets.  
- **Agentic example generator for Aspose.Imaging** – automatically creates complete, compilable examples for any of the supported categories (e.g., conversion, filters, merging, drawing, WMF/EMF handling).  
- **AI agent for .NET image processing examples** – interprets natural‑language requests such as “convert an APNG to PNG with lossless compression” and produces the corresponding C# code.  
- **OpenAPI‑compatible imaging code generator** – provides an OpenAPI specification that defines request/response schemas, enabling seamless integration with other LLM‑driven workflows.  

### Input / Output Specification
- **Inputs (JSON payload)**  
  - `category` – one of the repository categories (e.g., `convert-apng`, `image-and-photo-filters`).  
  - `source` – local file path, URL, or base‑64 string of the input image.  
  - `targetFormat` – desired output format (e.g., `png`, `jpeg`, `webp`).  
  - `options` – optional dictionary of Aspose.Imaging settings (compression level, DPI, color depth, filter type, etc.).  
  - `outputMode` – `"code"` (plain C# text), `"file"` (downloadable `.cs` file), or `"both"`.  

- **Outputs**  
  - `code` – a complete C# example (including `using` statements, method definition, and error handling) that performs the requested operation.  
  - `metadata` – JSON object summarizing the operation (input type, output type, required NuGet packages, Aspose.Imaging version).  
  - `fileUrl` (optional) – link to a generated `.cs` file when `outputMode` includes `"file"`.

### Core Functionalities
- **Image format conversion** across all supported types (APNG, CDR, CMX, DICOM, EPS, Open Document Graphics, raster, SVG → raster, WebP, WMF/EMF, etc.).  
- **Application of image and photo filters** (kernel filters, color adjustments, sharpening, etc.).  
- **Manipulation of different image file formats** (cropping, resizing, rotating, metadata editing).  
- **Merging and compositing images** (layering, drawing primitives, combining multiple sources).  
- **Working with drawing images** (vector graphics, text overlay, shape creation).  

These capabilities enable downstream AI agents and LLM systems to request, receive, and execute precise .NET imaging code tailored to any scenario covered by the Aspose.Imaging library.

## Quick Reference
| Task | Category | Key Classes |
|------|----------|-------------|
| Load an image from file, stream, or byte array | manipulating-images | Image, ImageLoadOptions |
| Save or convert an image to PNG, JPEG, BMP, GIF, etc. | conversion | Image, ImageSaveOptions, PngOptions, JpegOptions, BmpOptions, GifOptions |
| Convert APNG to another format (e.g., PNG, JPEG) | convert-apng | ApngImage, ImageSaveOptions, PngOptions |
| Convert CorelDRAW (CDR) files to raster formats | convert-cdr | CdrImage, ImageSaveOptions, PngOptions |
| Convert CMX vector images to raster formats | convert-cmx-images | CmxImage, ImageSaveOptions, JpegOptions |
| Convert DICOM medical images to common formats | convert-dicom-images | DicomImage, ImageSaveOptions, PngOptions |
| Convert EPS files to raster images | convert-eps-images | EpsImage, ImageSaveOptions, BmpOptions |
| Convert OpenDocument graphics (ODG) to PNG/JPEG | convert-open-document-graphics | OdgImage, ImageSaveOptions, PngOptions |
| Render SVG files to raster images (PNG, JPEG) | convert-svg-to-raster-images | SvgImage, RasterImage, ImageSaveOptions, PngOptions |
| Convert WebP images to other formats or vice‑versa | convert-webp-images | WebPImage, ImageSaveOptions, WebpOptions |
| Convert WMF or EMF vector drawings to raster images | converting-wmf-and-emf | WmfImage, EmfImage, ImageSaveOptions, PngOptions |
| Apply photo filters (e.g., Sepia, Grayscale) | image-and-photo-filters | Image, Filter, FilterOptions, SepiaFilter, GrayscaleFilter |
| Apply kernel‑based filters (e.g., Gaussian blur, Sharpen) | kernel-filters | Image, Filter, GaussianBlurFilter, SharpenFilter |
| Resize, rotate, or crop an image | manipulating-images | Image, ImageProcessor, ResizeOptions, RotateFlipType, Rectangle |
| Merge multiple images into a single canvas | merge-images | Image, ImageCollection, ImageCombiner, ImageSaveOptions |
| Draw shapes or text on vector/raster images | working-with-drawing-images | VectorImage, Graphics, Pen, Brush, Font |
<!-- AUTOGENERATED:START -->
Updated: 2026-06-29 | Run: `20260629_035455` | Examples: 4856 | Categories: 17
<!-- AUTOGENERATED:END -->

---
## Related Agentic .NET Example Repositories

| Repository | Product |
|------------|---------|
| [aspose-pdf/agentic-net-examples](https://github.com/aspose-pdf/agentic-net-examples) | Aspose.PDF for .NET |
| [aspose-words/agentic-net-examples](https://github.com/aspose-words/agentic-net-examples) | Aspose.Words for .NET |
| [aspose-cells/agentic-net-examples](https://github.com/aspose-cells/agentic-net-examples) | Aspose.Cells for .NET |
| [aspose-slides/agentic-net-examples](https://github.com/aspose-slides/agentic-net-examples) | Aspose.Slides for .NET |
| [aspose-email/agentic-net-examples](https://github.com/aspose-email/agentic-net-examples) | Aspose.Email for .NET |
| [aspose-barcode/agentic-net-examples](https://github.com/aspose-barcode/agentic-net-examples) | Aspose.BarCode for .NET |

*Maintained by an [agentic example generation workflow](https://metrics.aspose.com/agents/product-families/imaging/) | For AI-friendly guidance, see [AGENTS.md](https://github.com/aspose-imaging/agentic-net-examples/blob/main/agents.md) | Last updated: 2026-06-29*