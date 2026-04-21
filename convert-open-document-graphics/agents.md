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

- `using System;` (240/240 files)
- `using System.IO;` (240/240 files)
- `using Aspose.Imaging.ImageOptions;` (238/240 files) ← category-specific
- `using Aspose.Imaging;` (237/240 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (61/240 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (26/240 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (17/240 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (15/240 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (13/240 files) ← category-specific
- `using Aspose.Imaging.Sources;` (10/240 files) ← category-specific
- `using System.Threading.Tasks;` (8/240 files)
- `using Aspose.Imaging.FileFormats.Svg;` (7/240 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (6/240 files) ← category-specific
- `using System.Xml;` (4/240 files)
- `using System.Xml.Schema;` (4/240 files)
- `using System.Net.Sockets;` (4/240 files)
- `using System.Diagnostics;` (4/240 files)
- `using System.Reflection;` (4/240 files)
- `using Aspose.Imaging.Brushes;` (4/240 files) ← category-specific
- `using System.Collections.Generic;` (4/240 files)
- `using System.Linq;` (3/240 files)
- `using System.Xml.Linq;` (3/240 files)
- `using System.Text.RegularExpressions;` (2/240 files)
- `using Aspose.Imaging.FileFormats;` (2/240 files) ← category-specific
- `using System.Text;` (1/240 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs](./load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs) | `PngOptions` | Load an ODG file and save it as a PNG image using Image.Save. |
| [load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs](./load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs) | `JpegOptions` | Load an ODG file and convert it to JPEG format with default compression settings... |
| [load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs](./load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs) | `BmpOptions`, `OdgRasterizationOptions` | Load an ODG file and export it as a BMP image preserving original dimensions. |
| [load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `OdgRasterizationOptions`, `PdfOptions` | Load an ODG file and save it as a PDF document using default PDF options. |
| [load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs](./load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load an ODG file and convert it to SVG while preserving vector information. |
| [load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs](./load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs) | `OtgRasterizationOptions`, `PngOptions` | Load an OTG file and save it as a PNG image with default rasterization settings. |
| [load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs](./load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs) | `JpegOptions`, `OtgRasterizationOptions` | Load an OTG file and convert it to JPEG format applying standard quality level. |
| [load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs](./load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs) | `BmpOptions`, `OtgRasterizationOptions` | Load an OTG file and export it as a BMP image maintaining original size. |
| [load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `OtgRasterizationOptions`, `PdfOptions` | Load an OTG file and save it as a PDF document using default PDF options. |
| [load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs](./load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs) | `OtgRasterizationOptions`, `SvgOptions` | Load an OTG file and convert it to SVG while keeping vector data intact. |
| [create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs](./create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs) | `OdgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for ODG, set resolution, and save the image as PNG. |
| [create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs) | `JpegOptions`, `OdgRasterizationOptions` | Create RasterizationOptions for ODG, configure JPEG quality, and save as JPEG fi... |
| [create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs](./create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs) | `OtgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for OTG, set background color, and save as PNG image... |
| [create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs) | `JpegOptions`, `OtgRasterizationOptions` | Create RasterizationOptions for OTG, define JPEG compression level, and save as ... |
| [load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load ODG and save as SVG while preserving all vector layers and attributes. |
| [load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load OTG and save as SVG while preserving all vector layers and attributes. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OdgRasterizationOptions`, `PngOptions` | Apply a median filter to an ODG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OtgRasterizationOptions`, `PngOptions` | Apply a median filter to an OTG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions` | Apply a median filter to an ODG image before converting and saving it as BMP. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `MedianFilterOptions`, `OtgRasterizationOptions` | Apply a median filter to an OTG image before converting and saving it as BMP. |
| [iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs](./iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs) | `PngOptions`, `VectorRasterizationOptions` | Iterate over a folder of ODG files and batch convert each to PNG format. |
| [iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs](./iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs) | `OtgRasterizationOptions`, `PdfOptions` | Iterate over a folder of OTG files and batch convert each to PDF format. |
| [convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF while specifying a custom page size for the document. |
| [convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF while specifying a custom page size for the document. |
| [convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions`, `OdgRasterizationOptions` | Convert an ODG file to JPEG and set the output quality to 85 percent. |
| [convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions`, `OtgRasterizationOptions` | Convert an OTG file to JPEG and set the output quality to 85 percent. |
| [convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `OdgRasterizationOptions` | Convert an ODG file to BMP while preserving transparency information in the outp... |
| [convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `OtgRasterizationOptions` | Convert an OTG file to BMP while preserving transparency information in the outp... |
| [convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and ensure original layer names are retained in the o... |
| [convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `OtgRasterizationOptions`, `SvgOptions` | Convert an OTG file to SVG and ensure original layer names are retained in the o... |
| *...and 90 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.3.0/convert-open-document-graphics) |

## Category Statistics
- Total examples: 240
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpImage`
- `BmpOptions`
- `GaussianBlurFilterOptions`
- `Graphics`
- `JpegOptions`
- `LoadOptions`
- `MedianFilterOptions`
- `OdgImage`
- `OdgRasterizationOptions`
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

## Version History

| Version | Examples Added | Total | Date |
|---------|---------------|-------|------|
| V1 | 120 | 240 | 2026-04-21 |

<!-- AUTOGENERATED:START -->
Updated: 2026-04-21 | Run: `20260421_063600` | Examples: 240
<!-- AUTOGENERATED:END -->