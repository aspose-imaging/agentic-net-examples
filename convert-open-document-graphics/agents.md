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
- `using Aspose.Imaging;` (116/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (24/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (10/120 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (8/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (7/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (7/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (5/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (5/120 files) ← category-specific
- `using Aspose.Imaging.Sources;` (5/120 files) ← category-specific
- `using System.Threading.Tasks;` (4/120 files)
- `using System.Collections.Generic;` (2/120 files)
- `using System.Xml;` (2/120 files)
- `using System.Xml.Schema;` (2/120 files)
- `using System.Net.Sockets;` (2/120 files)
- `using System.Diagnostics;` (2/120 files)
- `using System.Reflection;` (2/120 files)
- `using Aspose.Imaging.Brushes;` (2/120 files) ← category-specific
- `using System.Text;` (1/120 files)
- `using System.Text.RegularExpressions;` (1/120 files)
- `using System.Linq;` (1/120 files)

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
| [create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs](./create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs) | `OdgImage`, `OdgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for ODG, set resolution, and save the image as PNG. |
| [create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs) | `JpegOptions`, `OdgRasterizationOptions` | Create RasterizationOptions for ODG, configure JPEG quality, and save as JPEG fi... |
| [create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs](./create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs) | `OtgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for OTG, set background color, and save as PNG image... |
| [create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs) | `JpegOptions`, `OtgRasterizationOptions` | Create RasterizationOptions for OTG, define JPEG compression level, and save as ... |
| [load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load ODG and save as SVG while preserving all vector layers and attributes. |
| [load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `OtgRasterizationOptions`, `SvgOptions` | Load OTG and save as SVG while preserving all vector layers and attributes. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OdgRasterizationOptions`, `PngOptions` | Apply a median filter to an ODG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OtgRasterizationOptions`, `PngOptions` | Apply a median filter to an OTG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `MedianFilterOptions`, `OdgRasterizationOptions` | Apply a median filter to an ODG image before converting and saving it as BMP. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `MedianFilterOptions`, `OtgRasterizationOptions` | Apply a median filter to an OTG image before converting and saving it as BMP. |
| [iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs](./iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs) | `OdgRasterizationOptions`, `PngOptions` | Iterate over a folder of ODG files and batch convert each to PNG format. |
| [iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs](./iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs) | `OtgRasterizationOptions`, `PdfOptions` | Iterate over a folder of OTG files and batch convert each to PDF format. |
| [convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF while specifying a custom page size for the document. |
| [convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF while specifying a custom page size for the document. |
| [convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions` | Convert an ODG file to JPEG and set the output quality to 85 percent. |
| [convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions`, `OtgRasterizationOptions` | Convert an OTG file to JPEG and set the output quality to 85 percent. |
| [convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions` | Convert an ODG file to BMP while preserving transparency information in the outp... |
| [convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `OtgRasterizationOptions` | Convert an OTG file to BMP while preserving transparency information in the outp... |
| [convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and ensure original layer names are retained in the o... |
| [convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `OtgRasterizationOptions`, `SvgOptions` | Convert an OTG file to SVG and ensure original layer names are retained in the o... |
| *...and 90 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.5.0/convert-open-document-graphics) |

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


## Developer Q&A

### Q: How to load an ODG file and save it as a PNG image using Image.Save in .NET C#?  
Use `Image.Load("sample.odg")` to open the ODG and then call `image.Save("output.png", new PngOptions())`. → See: `load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs`

### Q: How do I convert an ODG file to JPEG with default compression settings in C#?  
Load the ODG with `Image.Load` and save it using `new JpegOptions()` without modifying any properties. → See: `load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs`

### Q: How to export an OTG file as a PDF document using default PDF options in .NET?  
Open the OTG via `Image.Load` and call `image.Save("result.pdf", new PdfOptions())`. → See: `load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs`

### Q: How do I convert an ODG file to SVG while preserving all vector layers and attributes in C#?  
Load the ODG with `Image.Load` and save it using `new SvgOptions()` (or `SvgRasterizationOptions`) to retain vector information. → See: `load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs`

### Q: How to apply a median filter to an OTG image before converting and saving it as a BMP in .NET?  
Create a `MedianFilterOptions` object, assign it to `OtgRasterizationOptions`, and then save the image with `new BmpOptions()`. → See: `apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs`



### Q: How can I apply a Gaussian blur filter to an ODG image before saving it as a JPEG using Aspose.Imaging in C#?  
Use `Image.Load` to open the ODG, add a `GaussianBlurFilterOption` to the image’s `FilterOptions`, and then call `image.Save` with `JpegOptions`. → See: `apply-a-gaussian-blur-filter-to-an-odg-image-before-converting-and-saving-as-jpeg.cs`

### Q: How do I set the JPEG output quality to 85 % when converting an ODG file to JPEG with Aspose.Imaging in .NET?  
Create a `JpegOptions` instance, set its `Quality` property to 85, and pass it to `image.Save`. → See: `convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs`

### Q: How can I embed XMP metadata into a PDF generated from an ODG file using Aspose.Imaging for .NET?  
Load the ODG with `Image.Load`, create a `PdfOptions` object, assign the XMP XML string to its `XmpMetadata` property, and save the image as PDF. → See: `convert-an-odg-file-to-pdf-and-embed-xmp-metadata-for-enhanced-document-information.cs`

### Q: How do I define custom DPI and page margins when converting an ODG document to PDF with Aspose.Imaging in C#?  
Set `PdfOptions.DpiX`/`DpiY` and `PdfOptions.PageMargins` before calling `image.Save` with the `PdfOptions` instance. → See: `convert-an-odg-file-to-pdf-set-custom-dpi-and-define-page-margins-for-layout.cs`

### Q: How can I preserve transparency while converting an OTG file to BMP using Aspose.Imaging in .NET?  
Load the OTG image, use `BmpOptions` with `ColorType = PngColorType.TruecolorWithAlpha` (or the default preserving alpha), and save the image as BMP. → See: `convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs`
## Operations Covered
- Apply Gaussian blur filter to ODG image  
- Convert ODG image to JPEG format  
- Apply specific ICC color profile to ODG image  
- Convert ODG image to PNG format  
- Preserve transparency when converting ODG to BMP  
- Convert ODG image to BMP format  
- Embed XMP metadata while saving ODG as PDF  
- Convert ODG image to PDF format  
- Add text watermark overlay to ODG image before PNG export  
- Convert ODG image to SVG format  
- Set correct viewbox attribute in exported SVG  
- Convert OTG image to BMP while preserving transparency  

## Supported Formats
- **ODG** – source OpenDocument graphics file loaded for processing  
- **OTG** – alternative OpenDocument graphics file loaded for processing  
- **JPEG** – target format when saving blurred image  
- **PNG** – target format for color‑profile and watermark examples  
- **BMP** – target format for transparency‑preserving conversions  
- **PDF** – target format for rasterization with XMP metadata embedding  
- **SVG** – target format for vector export with viewbox handling  

## API Classes Used
- `Image` — base class that loads any supported image and provides common functionality.  
- `RasterImage` — derived class that enables raster‑specific operations such as applying filters.  
- `GaussianBlurFilterOption` — defines parameters for a Gaussian blur filter applied to a raster image.  
- `PngOptions` — configures settings (e.g., compression, color type) used when saving an image as PNG.  
- `JpegOptions` — configures settings (e.g., quality) used when saving an image as JPEG.  
- `BmpOptions` — configures settings for saving an image as BMP, including transparency handling.  
- `PdfOptions` — configures settings for saving an image as PDF, including metadata embedding.  
- `VectorRasterizationOptions` — specifies rasterization parameters (background color, page size, etc.) for vector‑to‑raster conversions like PDF.  
- `Color` — represents a color value; used for background color or other color specifications.  
- `ColorProfile` — applies an ICC color profile to an image to ensure accurate color reproduction.  
- `ImageOptions` — abstract base for all format‑specific save‑option classes.  
- `Aspose.Imaging.FileFormats.OpenDocument` (namespace) — provides support for loading ODG/OTG files.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_075808` | Examples: 120
<!-- AUTOGENERATED:END -->