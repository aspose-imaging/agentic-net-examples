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
- `using Aspose.Imaging;` (100/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (15/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (9/120 files) ← category-specific
- `using Aspose.Imaging.Sources;` (9/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (8/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (6/120 files) ← category-specific
- `using System.Threading.Tasks;` (4/120 files)
- `using System.Linq;` (4/120 files)
- `using Aspose.Imaging.FileFormats.Svg;` (3/120 files) ← category-specific
- `using System.Collections.Generic;` (2/120 files)
- `using System.Xml;` (2/120 files)
- `using System.Xml.Schema;` (2/120 files)
- `using System.Net.Sockets;` (2/120 files)
- `using System.Diagnostics;` (2/120 files)
- `using System.Reflection;` (2/120 files)
- `using Aspose.Imaging.Brushes;` (2/120 files) ← category-specific
- `using Aspose.Imaging.ImageFilters;` (1/120 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (1/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (1/120 files) ← category-specific
- `using System.Text.RegularExpressions;` (1/120 files)
- `using System.Xml.Linq;` (1/120 files)
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (1/120 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs](./load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs) | `PngOptions` | Load an ODG file and save it as a PNG image using Image.Save. |
| [load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs](./load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs) | `JpegOptions` | Load an ODG file and convert it to JPEG format with default compression settings... |
| [load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs](./load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs) | `BmpOptions` | Load an ODG file and export it as a BMP image preserving original dimensions. |
| [load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `PdfOptions` | Load an ODG file and save it as a PDF document using default PDF options. |
| [load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs](./load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs) | `SvgOptions` | Load an ODG file and convert it to SVG while preserving vector information. |
| [load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs](./load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs) | `PngOptions` | Load an OTG file and save it as a PNG image with default rasterization settings. |
| [load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs](./load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs) | `JpegOptions` | Load an OTG file and convert it to JPEG format applying standard quality level. |
| [load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs](./load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs) | `BmpOptions` | Load an OTG file and export it as a BMP image maintaining original size. |
| [load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `PdfOptions` | Load an OTG file and save it as a PDF document using default PDF options. |
| [load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs](./load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs) | `SvgOptions` | Load an OTG file and convert it to SVG while keeping vector data intact. |
| [create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs](./create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs) | `OdgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for ODG, set resolution, and save the image as PNG. |
| [create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs) | `JpegOptions` | Create RasterizationOptions for ODG, configure JPEG quality, and save as JPEG fi... |
| [create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs](./create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs) | `OtgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for OTG, set background color, and save as PNG image... |
| [create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs) | `JpegOptions`, `VectorRasterizationOptions` | Create RasterizationOptions for OTG, define JPEG compression level, and save as ... |
| [load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions` | Load ODG and save as SVG while preserving all vector layers and attributes. |
| [load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions` | Load OTG and save as SVG while preserving all vector layers and attributes. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs) | `PngOptions`, `RasterImage` | Apply a median filter to an ODG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs) | `Graphics`, `PngOptions`, `RasterImage` | Apply a median filter to an OTG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `PngOptions`, `VectorRasterizationOptions` | Apply a median filter to an ODG image before converting and saving it as BMP. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `VectorRasterizationOptions` | Apply a median filter to an OTG image before converting and saving it as BMP. |
| [iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs](./iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs) | `PngOptions` | Iterate over a folder of ODG files and batch convert each to PNG format. |
| [iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs](./iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs) | `PdfOptions` | Iterate over a folder of OTG files and batch convert each to PDF format. |
| [convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `PdfOptions`, `VectorRasterizationOptions` | Convert an ODG file to PDF while specifying a custom page size for the document. |
| [convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `PdfOptions`, `VectorRasterizationOptions` | Convert an OTG file to PDF while specifying a custom page size for the document. |
| [convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions` | Convert an ODG file to JPEG and set the output quality to 85 percent. |
| [convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions` | Convert an OTG file to JPEG and set the output quality to 85 percent. |
| [convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `RasterImage` | Convert an ODG file to BMP while preserving transparency information in the outp... |
| [convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `RasterImage` | Convert an OTG file to BMP while preserving transparency information in the outp... |
| [convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `SvgOptions` | Convert an ODG file to SVG and ensure original layer names are retained in the o... |
| [convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `SvgOptions` | Convert an OTG file to SVG and ensure original layer names are retained in the o... |
| *...and 90 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.10.0/convert-open-document-graphics) |

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
- `RasterCachedImage`
- `RasterImage`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- Need to blur a vector diagram before publishing it as a JPEG? Apply a Gaussian blur to an ODG image and save it as JPEG in C# using Aspose.Imaging’s `GaussianBlurFilterOption` as demonstrated in the sample.  
- Want to render ODG files on a solid white canvas for consistent UI display? The example shows how to convert an ODG file to PNG with a white background in C#.  
- Require a BMP output that retains the original ODG’s transparent layers? Use the BMP rasterization options illustrated to convert ODG to BMP while preserving transparency.  
- Generating PDF documentation that must include searchable metadata? The code converts an ODG file to PDF and embeds XMP metadata for enhanced document information.  
- Looking to fine‑tune ODG‑to‑JPEG conversion with additional processing steps? The “Aspose Imaging ODG to JPEG conversion with filter options” example applies filter options (e.g., blur, quality settings) before saving the JPEG.

## Related Categories
If you’re working with raster formats beyond ODG, the **Convert Raster Image** category ([../convert-raster-image/](../convert-raster-image/)) offers similar loading and saving patterns for PNG, BMP, and JPEG files.  
For more advanced image manipulation—such as applying color corrections, sharpening, or custom kernels—check out the **Image And Photo Filters** section ([../image-and-photo-filters/](../image-and-photo-filters/)), which builds on the same filter‑option infrastructure used in the ODG examples.  
When your workflow involves vector sources like SVG that need rasterization, the **Convert SVG To Raster Images** category ([../convert-svg-to-raster-images/](../convert-svg-to-raster-images/)) provides complementary techniques for handling vector‑to‑bitmap conversions.


## Operations Covered
- Apply Gaussian blur filter to ODG images  
- Apply a specific ICC color profile to ODG images  
- Convert ODG files to BMP while preserving alpha channel  
- Convert ODG files to PDF and embed XMP metadata  
- Add a text watermark when converting ODG to PNG  
- Convert ODG files to SVG with a correctly set viewbox attribute  
- Convert OTG images to 32‑bit BMP with transparency  
- Load ODG/OTG images from the file system

## Supported Formats
- **ODG** – source OpenDocument graphics file used as input  
- **OTG** – source OpenDocument graphics file (alternative extension) used as input  
- **JPEG** – target format when saving blurred ODG images  
- **PNG** – target format when applying ICC profile or adding watermark  
- **BMP** – target format for preserving transparency (32‑bit)  
- **PDF** – target format for embedding XMP metadata  
- **SVG** – target format for preserving viewbox information

## API Classes Used
- `Image` — core class for loading, processing, and saving images.  
- `JpegOptions` — defines JPEG‑specific saving parameters (quality, compression, etc.).  
- `PngOptions` — defines PNG‑specific saving parameters (color depth, compression, etc.).  
- `BmpOptions` — defines BMP‑specific saving parameters, including support for alpha channel.  
- `PdfOptions` — defines PDF‑specific saving parameters and allows embedding of XMP metadata.  
- `SvgOptions` — defines SVG‑specific saving parameters such as viewbox handling.  
- `FileSource` — represents a file‑based image source used when loading ODG/OTG files.  
- `TextBrush` (from `Aspose.Imaging.Brushes`) — provides a brush that draws text, used for watermarking.  
- `SvgGraphics` (from `Aspose.Imaging.FileFormats.Svg.Graphics`) — enables drawing operations on SVG output, ensuring correct viewbox settings.


## Get Started

Ready to try Convert Open Document Graphics conversions on your own files with Aspose.Imaging for .NET?

```bash
dotnet add package Aspose.Imaging
```

| Resource | Link |
|----------|------|
| 📖 Documentation | [docs.aspose.com/imaging/net](https://docs.aspose.com/imaging/net/) |
| 📦 NuGet Package | [www.nuget.org/packages/aspose.imaging](https://www.nuget.org/packages/aspose.imaging) |
| 🚀 Release Notes | [releases.aspose.com/imaging/net](https://releases.aspose.com/imaging/net/) |
| 🌐 Online Apps | [products.aspose.app/imaging/family](https://products.aspose.app/imaging/family/) |
| 🔑 Free Temporary License | [purchase.aspose.com/temporary-license](https://purchase.aspose.com/temporary-license) |
| 🤝 Consulting (paid implementation help) | [consulting.aspose.com](https://consulting.aspose.com/) |


## Developer Q&A

### Q: What exception should I catch when converting an ODG file to PNG using `Image.Save` in C# with Aspose.Imaging?
Catch a generic `Exception` around `Image.Load` and `image.Save` because Aspose.Imaging throws it for file‑format, I/O, or conversion errors. → See: [load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs](./load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs)

### Q: How does enabling `RasterizationOptions.AntiAliasing` affect ODG‑to‑PNG conversion in Aspose.Imaging for .NET?
Setting `PngOptions.RasterizationOptions.AntiAliasing = true` smooths edges and reduces jagged artifacts in the rendered PNG. → See: [configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-odg-to-png-for-smoother-visual-results.cs](./configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-odg-to-png-for-smoother-visual-results.cs)

### Q: How can I enable progressive JPEG encoding when converting an ODG file to JPEG for faster web loading in C#?
Assign `JpegOptions.Progressive = true` before calling `image.Save` to produce a progressive JPEG that loads incrementally in browsers. → See: [convert-an-odg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs](./convert-an-odg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs)

### Q: How do I set a custom DPI and define page margins when converting an ODG file to PDF with Aspose.Imaging?
Configure `PdfOptions.DpiX`, `PdfOptions.DpiY`, and `PdfOptions.PageMargins` on the `PdfOptions` object before saving the image as PDF. → See: [convert-an-odg-file-to-pdf-set-custom-dpi-and-define-page-margins-for-layout.cs](./convert-an-odg-file-to-pdf-set-custom-dpi-and-define-page-margins-for-layout.cs)

### Q: How can I retain all original metadata properties when saving an ODG image as PNG using Aspose.Imaging?
Use `PngOptions` with `KeepMetadata = true` (or copy the metadata collection) before calling `image.Save` to preserve EXIF, XMP, and other metadata. → See: [save-an-odg-image-as-png-while-retaining-all-original-metadata-properties.cs](./save-an-odg-image-as-png-while-retaining-all-original-metadata-properties.cs)

<!-- AUTOGENERATED:START -->
Updated: 2026-10-14 | Run: `20261014_165921` | Examples: 120
<!-- AUTOGENERATED:END -->