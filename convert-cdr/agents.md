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
- `using Aspose.Imaging;` (30/30 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (30/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cdr;` (19/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (3/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (2/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (2/30 files) ← category-specific
- `using Aspose.Imaging.Sources;` (1/30 files) ← category-specific
- `using Aspose.Imaging.ImageLoadOptions;` (1/30 files) ← category-specific
- `using System.Threading.Tasks;` (1/30 files)
- `using Aspose.Imaging.ProgressManagement;` (1/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (1/30 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs](./load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs) | `CdrImage`, `JpegOptions` | load a single page cdr file and save it as a high quality jpg using c |
| [convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs](./convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs) | `CdrRasterizationOptions`, `PngOptions` | convert a single page cdr file to png while preserving transparency with a c sni... |
| [transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs](./transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | transform a single page cdr document into a pdf embedding vector data via c code |
| [export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs](./export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PsdOptions` | export a single page cdr file to psd format maintaining layers using c |
| [load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs](./load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | load a multi page cdr file and generate separate pdf pages for each vector page ... |
| [convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs](./convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs) | `CdrImage`, `PsdOptions`, `VectorRasterizationOptions` | convert each page of a multi page cdr document into individual psd files preserv... |
| [batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs](./batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs) | `CdrImage`, `JpegOptions` | batch convert a folder of cdr files to jpg images with default settings using c |
| [batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs](./batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs) | `CdrImage`, `PngOptions` | batch export cdr files to png format by iterating through a directory with c loo... |
| [combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs](./combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | combine multiple cdr documents into a single pdf preserving page order via c |
| [batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs](./batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PsdOptions` | Batch transform a collection of CDR files into separate PSD files, retaining ori... |
| [wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs](./wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs) | `JpegOptions` | Wrap CDR‑to‑JPG conversion in try‑catch blocks to log runtime exceptions in C#. |
| [verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs](./verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs) | `JpegOptions`, `VectorRasterizationOptions` | Verify that a JPG file created from CDR conversion exists and has non‑zero size ... |
| [set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs](./set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs) | `JpegOptions` | Set JPEG quality to 90 before saving a CDR conversion to JPG using C# options. |
| [adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs](./adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Adjust PNG compression to maximum while converting a CDR file to PNG in C#. |
| [define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs](./define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Define custom PDF page size A4 when converting a multi‑page CDR document to PDF ... |
| [specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs](./specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs) | `PsdOptions` | Specify 16‑bit color depth for PSD output when converting a CDR file to PSD in C... |
| [convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs](./convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `JpegOptions` | Convert a CDR file from a memory stream directly to JPG without intermediate fil... |
| [convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs](./convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs) | `CdrImage`, `CdrLoadOptions`, `PngOptions` | Convert a CDR file from a byte array to PNG and output to a memory stream in C#. |
| [use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs](./use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | Use asynchronous methods to convert a CDR file to PDF, improving UI responsivene... |
| [implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs](./implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs) | `JpegOptions`, `LoadOptions` | Implement progress reporting while batch converting CDR files to JPG, updating a... |
| [apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs](./apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs) | `CdrImage`, `JpegOptions`, `VectorRasterizationOptions` | Apply a custom JPEG encoder setting to embed EXIF metadata during CDR‑to‑JPG con... |
| [preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs](./preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Preserve alpha channel when converting a CDR file to PNG by configuring PNG opti... |
| [generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs](./generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Generate a PDF with embedded fonts when converting a CDR file to PDF using C#. |
| [retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs](./retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs) | `CdrImage`, `MultiPageOptions`, `PsdOptions` | Retain layer groups when exporting a CDR file to PSD by enabling layer preservat... |
| [resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs](./resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs) | `JpegOptions` | Resize a CDR‑to‑JPG conversion output to 1024×768 pixels during saving in C#. |
| [apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs](./apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Apply lossless compression to a CDR‑to‑PNG conversion while maintaining original... |
| [set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs](./set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs) | `PdfCoreOptions`, `PdfOptions` | Set PDF version to 1.7 for compatibility when converting a CDR file to PDF in C#... |
| [set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs](./set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs) | `PsdOptions`, `VectorRasterizationOptions` | Set PSD resolution to 300 DPI for print quality when converting a CDR file in C#... |
| [ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs](./ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Ensure fonts are embedded in the PDF output when converting a CDR file with embe... |
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
- A design studio needs to batch‑convert legacy CorelDRAW CDR files into high‑resolution PNGs for web publishing, so they can automate the CDR to image dotnet workflow with Aspose.Imaging.  
- An e‑learning platform wants to generate thumbnail previews of CDR diagrams on the fly in a C# web service, leveraging CDR file conversion to reduce storage size.  
- A print‑on‑demand service must transform client‑submitted CorelDRAW CDR artwork into PDF or TIFF formats before sending jobs to the printer, using CorelDRAW C# integration.  
- A document management system requires extracting vector shapes from CDR files and saving them as SVG for further editing, employing CDR to image dotnet capabilities.  
- A mobile app backend processes user‑uploaded CDR files and converts them to JPEG for quick display on devices, utilizing Aspose.Imaging’s C# conversion utilities.

## Related Categories  
The Convert CDR examples complement the PDF and SVG conversion sections, where similar techniques are used to render vector graphics into raster formats. If you’re working with multi‑page documents, the Convert PDF category shows how to handle pagination and layering, while the Convert SVG group demonstrates preserving scalability during conversion. Exploring the Image Optimization and Metadata Management categories can also help you fine‑tune the output quality and embed useful information after converting CDR files.


## Developer Q&A

### Q: How do I load a single‑page CDR file and save it as a high‑quality JPG in C#?
Use `CdrImage.Load` to open the CDR file and call `Save` with a `JpegOptions` object where `Quality` is set to a high value (e.g., 90). This works with .NET 6/7 and C# 10. → See: `load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs`

### Q: How to convert a single‑page CDR file to PNG while preserving transparency in C#?
Load the file with `CdrImage.Load`, configure `CdrRasterizationOptions` for vector rasterization, and save using `PngOptions` with `Transparency = true`. The code runs on .NET 6+ with C#. → See: `convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs`

### Q: How do I batch convert a folder of CDR files to JPG images using default settings in C#?
Iterate through the directory, load each file with `CdrImage.Load`, and call `Save` with a new `JpegOptions()` instance (default settings). This simple loop works in any .NET Core/Framework project. → See: `batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs`

### Q: How to convert a CDR file from a memory stream directly to JPG without intermediate files in C#?
Create a `MemoryStream` containing the CDR bytes, load it via `CdrImage.Load(memoryStream)`, then save to another `MemoryStream` using `JpegOptions`. No temporary files are written, suitable for ASP.NET Core. → See: `convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs`

### Q: How do I use asynchronous methods to convert a CDR file to PDF, improving UI responsiveness in C#?
Call `CdrImage.LoadAsync` to read the CDR file, then `SaveAsync` with a `PdfOptions` instance to write the PDF. Both methods are awaitable and compatible with .NET 6/7 async patterns. → See: `use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs`



### Q: How can I set the PNG compression level to maximum when converting a CDR file to PNG with Aspose.Imaging in C#?  
Use `PngOptions.CompressionLevel = PngCompressionLevel.Maximum` before calling `cdrImage.Save(outputPath, pngOptions)`. → See: `adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs`

### Q: How do I embed EXIF metadata into a JPEG while converting from a CDR file using Aspose.Imaging in C#?  
Create a `JpegOptions` instance, assign the desired EXIF data to its `ExifData` property, and pass this options object to `cdrImage.Save(outputPath, jpegOptions)`. → See: `apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs`

### Q: How can I preserve the original dimensions and apply lossless compression when converting a CDR file to PNG with Aspose.Imaging in C#?  
Instantiate `PngOptions` with `CompressionLevel = PngCompressionLevel.BestCompression` and save the `CdrImage` without modifying its `Width` or `Height`. → See: `apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs`

### Q: How do I batch convert a collection of CDR files to separate PSD files while keeping the original layer structure using Aspose.Imaging in C#?  
Iterate through the CDR files, load each with `CdrImage`, and call `Save` with a new `PsdOptions()` which retains the layer hierarchy. → See: `batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs`

### Q: How can I combine multiple CDR documents into a single PDF while preserving page order using Aspose.Imaging in C#?  
Load each CDR as a `CdrImage`, add its pages to a `PdfDocument`, and finally save the combined document with `PdfOptions`. → See: `combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs`
## Operations Covered
- Convert CDR to PNG with maximum compression  
- Convert CDR to PNG using lossless compression while preserving dimensions  
- Batch convert multiple CDR files to JPEG with timestamped filenames  
- Batch convert CDR files to PSD while retaining original layer structure  
- Convert CDR data from a byte array to PNG via a memory stream  
- Convert a single‑page CDR to PNG preserving transparency  
- Convert multi‑page CDR to PDF with a custom A4 page size  
- Load a CDR image from a file or from a byte array  

## Supported Formats
- **CDR** – CorelDRAW source format being loaded  
- **PNG** – Output format for high‑compression and transparent conversions  
- **JPEG** – Output format used in the batch‑conversion example  
- **PSD** – Output format that keeps the original layer hierarchy  
- **PDF** – Output format for multi‑page document conversion with custom page size  

## API Classes Used
- `Image` — static class that provides the `Load` method to read images from files, streams, or byte arrays.  
- `CdrImage` — represents a CorelDRAW document; enables access to pages and saving to other formats.  
- `PngOptions` — defines PNG‑specific save settings such as compression level.  
- `JpegOptions` — defines JPEG‑specific save settings (e.g., quality).  
- `PsdOptions` — defines PSD‑specific save settings to retain layers when converting.  
- `PdfOptions` — defines PDF‑specific save settings, including custom page size configuration.  
- `ImageLoadOptions` — allows configuration of how an image is loaded (used when loading from a stream or byte array).  
- `MemoryStream` — .NET stream used to hold image data in memory during conversion (used together with Aspose.Imaging).  
- `File` / `Directory` — .NET I/O classes employed to verify file existence and create output folders, supporting the conversion workflow.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_030426` | Examples: 30
<!-- AUTOGENERATED:END -->