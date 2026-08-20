---
name: convert-open-document-graphics
description: C# examples for Convert Open Document Graphics using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Convert Open Document Graphics

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Convert Open Document Graphics** category.
This folder contains standalone C# examples for Convert Open Document Graphics operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (120/120 files)
- `using System.IO;` (120/120 files)
- `using Aspose.Imaging.ImageOptions;` (120/120 files) ← category-specific
- `using Aspose.Imaging;` (117/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (35/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (10/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (9/120 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (8/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (7/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (6/120 files) ← category-specific
- `using Aspose.Imaging.Sources;` (4/120 files) ← category-specific
- `using System.Threading.Tasks;` (4/120 files)
- `using System.Collections.Generic;` (2/120 files)
- `using System.Net.Sockets;` (2/120 files)
- `using Aspose.Imaging.FileFormats.Svg;` (2/120 files) ← category-specific
- `using System.Reflection;` (2/120 files)
- `using Aspose.Imaging.Brushes;` (2/120 files) ← category-specific
- `using System.Net;` (1/120 files)
- `using System.Xml;` (1/120 files)
- `using System.Xml.Schema;` (1/120 files)
- `using System.Diagnostics;` (1/120 files)
- `using Aspose.Imaging.FileFormats.OpenDocument.Objects;` (1/120 files) ← category-specific
- `using System.Text.RegularExpressions;` (1/120 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs](./load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs) | `PngOptions` | Load an ODG file and save it as a PNG image using Image.Save. |
| [load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs](./load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs) | `JpegOptions` | Load an ODG file and convert it to JPEG format with default compression settings... |
| [load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs](./load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs) | `BmpOptions`, `OdgRasterizationOptions` | Load an ODG file and export it as a BMP image preserving original dimensions. |
| [load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `OdgRasterizationOptions`, `PdfOptions` | Load an ODG file and save it as a PDF document using default PDF options. |
| [load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs](./load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs) | `OdgRasterizationOptions`, `SvgOptions` | Load an ODG file and convert it to SVG while preserving vector information. |
| [load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs](./load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs) | `OtgRasterizationOptions`, `PngOptions` | Load an OTG file and save it as a PNG image with default rasterization settings. |
| [load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs](./load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs) | `JpegOptions`, `OtgRasterizationOptions` | Load an OTG file and convert it to JPEG format applying standard quality level. |
| [load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs](./load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs) | `BmpOptions`, `OtgRasterizationOptions` | Load an OTG file and export it as a BMP image maintaining original size. |
| [load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `OtgRasterizationOptions`, `PdfOptions` | Load an OTG file and save it as a PDF document using default PDF options. |
| [load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs](./load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load an OTG file and convert it to SVG while keeping vector data intact. |
| [create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs](./create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs) | `PngOptions`, `VectorRasterizationOptions` | Create RasterizationOptions for ODG, set resolution, and save the image as PNG. |
| [create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs) | `JpegOptions`, `OdgRasterizationOptions` | Create RasterizationOptions for ODG, configure JPEG quality, and save as JPEG fi... |
| [create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs](./create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs) | `OtgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for OTG, set background color, and save as PNG image... |
| [create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs) | `JpegOptions`, `OtgRasterizationOptions` | Create RasterizationOptions for OTG, define JPEG compression level, and save as ... |
| [load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions` | Load ODG and save as SVG while preserving all vector layers and attributes. |
| [load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load OTG and save as SVG while preserving all vector layers and attributes. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OdgRasterizationOptions`, `PngOptions` | Apply a median filter to an ODG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OtgRasterizationOptions`, `PngOptions` | Apply a median filter to an OTG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `MedianFilterOptions`, `RasterImage` | Apply a median filter to an ODG image before converting and saving it as BMP. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `MedianFilterOptions`, `OtgRasterizationOptions` | Apply a median filter to an OTG image before converting and saving it as BMP. |
| [iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs](./iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs) | `OdgRasterizationOptions`, `PngOptions` | Iterate over a folder of ODG files and batch convert each to PNG format. |
| [iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs](./iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs) | `OtgRasterizationOptions`, `PdfOptions` | Iterate over a folder of OTG files and batch convert each to PDF format. |
| [convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF while specifying a custom page size for the document. |
| [convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF while specifying a custom page size for the document. |
| [convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions`, `OdgRasterizationOptions` | Convert an ODG file to JPEG and set the output quality to 85 percent. |
| [convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions`, `OtgRasterizationOptions` | Convert an OTG file to JPEG and set the output quality to 85 percent. |
| [convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `OdgRasterizationOptions` | Convert an ODG file to BMP while preserving transparency information in the outp... |
| [convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `OtgRasterizationOptions` | Convert an OTG file to BMP while preserving transparency information in the outp... |
| [convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and ensure original layer names are retained in the o... |
| [convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `OtgRasterizationOptions`, `SvgOptions` | Convert an OTG file to SVG and ensure original layer names are retained in the o... |
| *...and 90 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.8.0/convert-open-document-graphics) |

## Category Statistics
- Total examples: 120
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpImage`
- `BmpOptions`
- `GaussianBlurFilterOptions`
- `Graphics`
- `JpegImage`
- `JpegOptions`
- `LoadOptions`
- `MedianFilterOptions`
- `OdgImage`
- `OdgRasterizationOptions`
- `OpenThermalGraphics`
- `OtgImage`
- `OtgRasterizationOptions`
- `PdfCoreOptions`
- `PdfOptions`
- `PngOptions`
- `RasterImage`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- A document management system needs to batch‑convert ODG files to PNG for web preview; the **ODG conversion C#** samples show how to load OpenDocument graphics and export them using Aspose.Imaging for .NET.  
- An engineering firm wants to embed vector diagrams from OpenDocument graphics into a PDF report; the **OpenDocument graphics dotnet** examples demonstrate rasterizing ODG pages while preserving quality.  
- A SaaS platform automates thumbnail generation for user‑uploaded ODG files; the provided code illustrates fast **ODG conversion C#** with memory‑efficient streams.  
- A desktop publishing tool requires converting ODG illustrations to SVG for further editing; the **OpenDocument graphics dotnet** snippets guide you through preserving vector data during the export.  
- An e‑learning application needs to transform ODG slide assets into JPEGs for mobile devices; the **ODG conversion C#** examples detail scaling and compression options available in Aspose.Imaging.

## Related Categories  
The Convert Open Document Graphics category complements the **Vector Graphics Conversion** and **Raster Image Processing** sections, where you can find additional examples for handling SVG, EPS, and PDF formats. If you’re working with multi‑page documents, the **Document to Image** category provides guidance on converting PDF or DOCX pages to bitmap images. Together, these categories give a comprehensive toolkit for any .NET developer dealing with diverse image and document workflows.


## Operations Covered
- Apply Gaussian blur filter to ODG images  
- Apply specific ICC color profile to ODG images  
- Convert ODG to BMP while preserving transparency  
- Convert ODG to PDF and embed XMP metadata  
- Add watermark text overlay to ODG before PNG conversion  
- Convert ODG to PNG with white background  
- Ensure correct ViewBox attribute when converting ODG to SVG  
- Convert OTG to BMP while preserving transparency  

## Supported Formats
- **ODG** – source OpenDocument Graphics file used for all conversions  
- **OTG** – source OpenDocument Graphics file (alternative extension)  
- **JPEG** – target format when saving blurred ODG image  
- **PNG** – target format for color‑profile conversion, watermarking, and white‑background output  
- **BMP** – target format for transparency‑preserving conversions  
- **PDF** – target format for ODG to PDF conversion with XMP metadata  
- **SVG** – target format for ODG to SVG conversion with proper ViewBox  

## API Classes Used
- `Image` — core class for loading, processing, and saving images.  
- `JpegOptions` — provides settings for saving an image as a JPEG file.  
- `PngOptions` — provides settings for saving an image as a PNG file.  
- `BmpOptions` — provides settings for saving an image as a BMP file, including transparency handling.  
- `PdfOptions` — provides settings for saving an image as a PDF document and embedding metadata.  
- `SvgOptions` — provides settings for saving an image as an SVG file, allowing view‑box configuration.  
- `GaussianBlurFilter` — filter that applies a Gaussian blur effect to an image.  
- `IccProfile` (or related ICC color‑profile class) — used to assign a specific ICC color profile to an image before saving.

<!-- AUTOGENERATED:START -->
Updated: 2026-08-19 | Run: `20260819_045032` | Examples: 120
<!-- AUTOGENERATED:END -->

## Developer Q&A

### Q: How can I apply a Gaussian blur filter to an ODG image before converting it to JPEG using Aspose.Imaging in C#?  
Load the ODG with `Image.Load`, apply `new GaussianBlurFilterOption(radius)` via `image.ApplyFilter`, and save using `JpegOptions`. → See: `apply-a-gaussian-blur-filter-to-an-odg-image-before-converting-and-saving-as-jpeg.cs`

### Q: How do I enable anti‑aliasing when converting an ODG file to PNG with Aspose.Imaging for smoother results?  
Set `pngOptions.RasterizationOptions.AntiAliasing = true` before calling `image.Save`. → See: `configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-odg-to-png-for-smoother-visual-results.cs`

### Q: How can I generate a progressive JPEG from an ODG file for faster web loading using Aspose.Imaging in C#?  
Use `JpegOptions` with `Progressive = true` (and optionally set `Quality`) and save the loaded ODG image. → See: `convert-an-odg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs`

### Q: What is the best way to asynchronously batch‑convert multiple ODG files to BMP in C# with Aspose.Imaging?  
In an `async Main`, iterate the file list, load each ODG with `Image.Load`, and call `image.Save` with `BmpOptions` inside `await Task.Run`. → See: `implement-asynchronous-batch-conversion-of-odg-files-to-bmp-using-async-await-for-non-blocking-i-o.cs`

<!-- AUTOGENERATED:START -->
Updated: 2026-08-18 | Run: `20260626_062855` | Examples: 120
<!-- AUTOGENERATED:END -->
