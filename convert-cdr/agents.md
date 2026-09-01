---
name: convert-cdr
description: C# examples for Convert CDR using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Convert CDR

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Convert CDR** category.
This folder contains standalone C# examples for Convert CDR operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (30/30 files)
- `using System.IO;` (30/30 files)
- `using Aspose.Imaging.ImageOptions;` (30/30 files) ← category-specific
- `using Aspose.Imaging;` (27/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cdr;` (22/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (4/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (2/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (2/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (1/30 files) ← category-specific
- `using System.Threading.Tasks;` (1/30 files)
- `using Aspose.Imaging.ProgressManagement;` (1/30 files) ← category-specific
- `using Aspose.Imaging.Exif;` (1/30 files) ← category-specific
- `using Aspose.Imaging.Sources;` (1/30 files) ← category-specific
- `using System.Collections.Generic;` (1/30 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs](./load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs) | `CdrImage`, `JpegOptions` | Load a single‑page CDR file and save it as a high‑quality JPG using C#. |
| [convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs](./convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs) | `CdrImage`, `PngOptions` | Convert a single‑page CDR file to PNG while preserving transparency with a C# sn... |
| [transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs](./transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | Transform a single‑page CDR document into a PDF, embedding vector data via C# co... |
| [export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs](./export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PsdOptions` | Export a single‑page CDR file to PSD format, maintaining layers using C#. |
| [load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs](./load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | Load a multi‑page CDR file and generate separate PDF pages for each vector page ... |
| [convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs](./convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs) | `CdrImage`, `PsdOptions`, `VectorRasterizationOptions` | Convert each page of a multi‑page CDR document into individual PSD files preserv... |
| [batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs](./batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs) | `CdrImage`, `JpegOptions` | Batch convert a folder of CDR files to JPG images with default settings using C#... |
| [batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs](./batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs) | `CdrImage`, `PngOptions` | Batch export CDR files to PNG format by iterating through a directory with C# lo... |
| [combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs](./combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Combine multiple CDR documents into a single PDF, preserving page order via C#. |
| [batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs](./batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `MultiPageOptions` | Batch transform a collection of CDR files into separate PSD files, retaining ori... |
| [wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs](./wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs) | `JpegOptions` | Wrap CDR‑to‑JPG conversion in try‑catch blocks to log runtime exceptions in C#. |
| [verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs](./verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs) | `JpegOptions`, `VectorRasterizationOptions` | Verify that a JPG file created from CDR conversion exists and has non‑zero size ... |
| [set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs](./set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs) | `CdrImage`, `JpegOptions`, `VectorRasterizationOptions` | Set JPEG quality to 90 before saving a CDR conversion to JPG using C# options. |
| [adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs](./adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Adjust PNG compression to maximum while converting a CDR file to PNG in C#. |
| [define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs](./define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs) | `CdrRasterizationOptions`, `MultiPageOptions`, `PdfOptions` | Define custom PDF page size A4 when converting a multi‑page CDR document to PDF ... |
| [specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs](./specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs) | `PsdOptions`, `VectorRasterizationOptions` | Specify 16‑bit color depth for PSD output when converting a CDR file to PSD in C... |
| [convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs](./convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs) | `CdrImage`, `JpegOptions`, `VectorRasterizationOptions` | Convert a CDR file from a memory stream directly to JPG without intermediate fil... |
| [convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs](./convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs) | `CdrImage`, `LoadOptions`, `PngOptions` | Convert a CDR file from a byte array to PNG and output to a memory stream in C#. |
| [use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs](./use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | Use asynchronous methods to convert a CDR file to PDF, improving UI responsivene... |
| [implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs](./implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs) | `JpegOptions`, `LoadOptions` | Implement progress reporting while batch converting CDR files to JPG, updating a... |
| [apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs](./apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs) | `JpegOptions` | Apply a custom JPEG encoder setting to embed EXIF metadata during CDR‑to‑JPG con... |
| [preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs](./preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs) | `CdrRasterizationOptions`, `PngOptions` | Preserve alpha channel when converting a CDR file to PNG by configuring PNG opti... |
| [generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs](./generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Generate a PDF with embedded fonts when converting a CDR file to PDF using C#. |
| [retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs](./retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs) | `CdrImage`, `MultiPageOptions`, `PsdOptions` | Retain layer groups when exporting a CDR file to PSD by enabling layer preservat... |
| [resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs](./resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs) | `CdrRasterizationOptions`, `JpegOptions` | Resize a CDR‑to‑JPG conversion output to 1024×768 pixels during saving in C#. |
| [apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs](./apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Apply lossless compression to a CDR‑to‑PNG conversion while maintaining original... |
| [set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs](./set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs) | `PdfCoreOptions`, `PdfOptions` | Set PDF version to 1.7 for compatibility when converting a CDR file to PDF in C#... |
| [set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs](./set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs) | `CdrImage`, `PsdOptions` | Set PSD resolution to 300 DPI for print quality when converting a CDR file in C#... |
| [ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs](./ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs) | `CdrRasterizationOptions`, `LoadOptions`, `PdfOptions` | Ensure fonts are embedded in the PDF output when converting a CDR file with embe... |
| [batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs](./batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs) | `CdrImage`, `JpegOptions` | Batch convert CDR files to JPG, naming each output with the original filename pl... |

## Category Statistics
- Total examples: 30
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `CdrImage`
- `CdrLoadOptions`
- `CdrRasterizationOptions`
- `JpegOptions`
- `LoadOptions`
- `MultiPageOptions`
- `PdfCoreOptions`
- `PdfOptions`
- `PngOptions`
- `PsdOptions`
- `PsdVectorizationOptions`
- `RasterImage`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- **High‑compression PNG export for web assets** – The `adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs` example shows how to load a CorelDRAW CDR file and save it as a PNG with `PngOptions` configured for maximum compression, ideal for reducing bandwidth when serving graphics online.  
- **Lossless PNG conversion preserving original dimensions** – In `apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs` the code demonstrates a CDR file‑to‑PNG conversion that keeps the exact size and uses lossless compression, perfect for archival or print‑ready workflows.  
- **Batch conversion of multiple CDR files to timestamped JPGs** – The `batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs` script iterates over a folder of CDR documents, converts each to JPEG, and appends a timestamp to the filename, streamlining automated image pipelines that need unique output names.  
- **Preserving layer structure when moving from CDR to PSD** – `batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs` loads each CDR, creates a `PsdImage` with the original layers intact, and saves it, enabling designers to continue editing in Photoshop without losing editability.  
- **In‑memory conversion from a CDR byte array to a PNG stream** – The `convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs` snippet reads a CDR file into a byte array, converts it to PNG using a memory stream, and returns the stream, which is useful for web services that must avoid temporary files while performing CDR to image dotnet transformations.

## Related Categories
If you need to transform the resulting images further, explore the **Image Compression** and **Image Format Conversion** categories, which cover JPEG quality tuning, WebP generation, and TIFF handling. For scenarios that involve extracting vector data or converting multi‑page documents, the **Vector Graphics** and **Multi‑Page Document** sections provide examples of working with SVG, PDF, and multi‑page CDR files. Together, these categories complement the Convert CDR examples by offering end‑to‑end pipelines for CorelDRAW C# projects.

## Operations Covered
- Convert CDR to PNG with maximum compression  
- Convert CDR to PNG with lossless compression while keeping original dimensions  
- Batch convert multiple CDR files to JPEG with timestamped filenames  
- Batch convert multiple CDR files to PSD while preserving layer structure  
- Convert CDR byte array to PNG and write to a memory stream  
- Convert single‑page CDR to transparent PNG (preserve alpha channel)  
- Convert multi‑page CDR to PDF with custom A4 page size  
- Create output directories automatically if missing  

## Supported Formats
- **CDR** – CorelDRAW source format being loaded.  
- **PNG** – Target format for most conversions; used with compression and transparency options.  
- **JPEG** – Target format in the batch‑convert‑to‑JPG example.  
- **PSD** – Target format when retaining original layer structure.  
- **PDF** – Target format for multi‑page document conversion with custom page size.  

## API Classes Used
- `Aspose.Imaging.Image.Load` — Static method that loads an image file (e.g., a CDR file) and returns an appropriate image object.  
- `CdrImage` — Represents a CorelDRAW document; provides access to pages, layers, and allows saving to other formats.  
- `PngOptions` — Holds PNG‑specific saving options such as compression level and transparency handling.  
- `JpegOptions` — Holds JPEG‑specific saving options (e.g., quality) used when converting to JPEG.  
- `PsdOptions` — Holds PSD‑specific saving options to preserve layers when saving as Photoshop files.  
- `PdfOptions` — Holds PDF‑specific saving options, including page size configuration.  
- `Image.Save(string path, ImageOptions options)` — Saves the loaded image to the specified path using the provided format options.  
- `Image.Save(Stream stream, ImageOptions options)` — Saves the image directly into a memory stream (used for byte‑array conversion).  
- `Directory.CreateDirectory(string path)` — Ensures the output folder exists before saving files.  
- `File.Exists(string path)` — Checks that the source CDR file is present before processing.


## Get Started

Ready to try Convert Cdr conversions on your own files with Aspose.Imaging for .NET?

```bash
dotnet add package Aspose.Imaging
```

| Resource | Link |
|----------|------|
| 📖 Documentation | [docs.aspose.com/imaging/net](https://docs.aspose.com/imaging/net/) |
| 📦 NuGet Package | [nuget.org/packages/Aspose.Imaging](https://www.nuget.org/packages/aspose.imaging) |
| 🚀 Release Notes | [releases.aspose.com/imaging/net](https://releases.aspose.com/imaging/net/) |
| 🌐 Online Apps | [products.aspose.app/imaging](https://products.aspose.app/imaging/family/) |
| 🔑 Free Temporary License | [purchase.aspose.com/temporary-license](https://purchase.aspose.com/temporary-license) |
| 🤝 Consulting (paid implementation help) | [consulting.aspose.com](https://consulting.aspose.com/) |

<!-- AUTOGENERATED:START -->
Updated: 2026-08-20 | Run: `20260722_051918` | Examples: 30
<!-- AUTOGENERATED:END -->

## Developer Q&A

### Q: How can I set maximum PNG compression when converting a CorelDRAW CDR file to PNG using Aspose.Imaging in C#?  
Use `PngOptions.CompressionLevel = PngCompressionLevel.Maximum` and call `image.Save(outputPath, pngOptions)`. → See: `adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs`

### Q: How do I preserve transparency while converting a single‑page CDR to PNG with Aspose.Imaging for .NET?  
Load the CDR with `Image.Load`, create `PngOptions` with `ColorType = PngColorType.TruecolorWithAlpha`, then save via `image.Save(outputPath, pngOptions)`. → See: `convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs`

### Q: How can I batch convert multiple CDR files to JPG and include a timestamp in each output filename using Aspose.Imaging C#?  
Iterate the CDR files, build the output name like `$"{Path.GetFileNameWithoutExtension(file)}_{DateTime.Now:yyyyMMddHHmmss}.jpg"`, and save each with `JpegOptions` via `image.Save`. → See: `batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs`

### Q: What is the way to convert a CDR file from a byte array to a PNG memory stream with Aspose.Imaging in C#?  
Call `Image.Load(byteArray)` to get the CDR image, then `image.Save(memoryStream, new PngOptions())`. → See: `convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs`

### Q: How can I report progress while batch converting CDR files to JPG in a console application using Aspose.Imaging?  
Assign a `ProgressCallback` to `ImageOptions` or handle `Image.Progress` and update the console bar inside the loop. → See: `implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs`