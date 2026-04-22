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

- `using System;` (90/90 files)
- `using System.IO;` (90/90 files)
- `using Aspose.Imaging.ImageOptions;` (89/90 files) ← category-specific
- `using Aspose.Imaging;` (81/90 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cdr;` (72/90 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (14/90 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (12/90 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (9/90 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (8/90 files) ← category-specific
- `using System.Collections.Generic;` (5/90 files)
- `using Aspose.Imaging.Sources;` (3/90 files) ← category-specific
- `using Aspose.Imaging.ImageLoadOptions;` (3/90 files) ← category-specific
- `using Aspose.Imaging.ProgressManagement;` (2/90 files) ← category-specific
- `using System.Threading.Tasks;` (2/90 files)
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (1/90 files) ← category-specific
- `using System.Drawing;` (1/90 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs](./load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs) | `CdrImage`, `JpegOptions` | Load a single‑page CDR file and save it as a high‑quality JPG using C#. |
| [convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs](./convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Convert a single‑page CDR file to PNG while preserving transparency with a C# sn... |
| [transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs](./transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | Transform a single‑page CDR document into a PDF, embedding vector data via C# co... |
| [export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs](./export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs) | `PsdOptions`, `VectorRasterizationOptions` | Export a single‑page CDR file to PSD format, maintaining layers using C#. |
| [load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs](./load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PdfOptions` | Load a multi‑page CDR file and generate separate PDF pages for each vector page ... |
| [convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs](./convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs) | `CdrImage`, `PsdOptions`, `VectorRasterizationOptions` | Convert each page of a multi‑page CDR document into individual PSD files preserv... |
| [batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs](./batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs) | `CdrImage`, `JpegOptions` | Batch convert a folder of CDR files to JPG images with default settings using C#... |
| [batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs](./batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs) | `CdrImage`, `PngOptions` | Batch export CDR files to PNG format by iterating through a directory with C# lo... |
| [combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs](./combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Combine multiple CDR documents into a single PDF, preserving page order via C#. |
| [batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs](./batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs) | `CdrImage`, `PsdOptions`, `PsdVectorizationOptions` | Batch transform a collection of CDR files into separate PSD files, retaining ori... |
| [wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs](./wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs) | `JpegOptions` | Wrap CDR‑to‑JPG conversion in try‑catch blocks to log runtime exceptions in C#. |
| [verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs](./verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs) | `CdrImage`, `JpegOptions`, `LoadOptions` | Verify that a JPG file created from CDR conversion exists and has non‑zero size ... |
| [set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs](./set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs) | `CdrImage`, `CdrRasterizationOptions`, `JpegOptions` | Set JPEG quality to 90 before saving a CDR conversion to JPG using C# options. |
| [adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs](./adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Adjust PNG compression to maximum while converting a CDR file to PNG in C#. |
| [define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs](./define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Define custom PDF page size A4 when converting a multi‑page CDR document to PDF ... |
| [specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs](./specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs) | `PsdOptions` | Specify 16‑bit color depth for PSD output when converting a CDR file to PSD in C... |
| [convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs](./convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs) | `CdrImage`, `CdrLoadOptions`, `JpegOptions` | Convert a CDR file from a memory stream directly to JPG without intermediate fil... |
| [convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs](./convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs) | `CdrImage`, `LoadOptions`, `PngOptions` | Convert a CDR file from a byte array to PNG and output to a memory stream in C#. |
| [use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs](./use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `LoadOptions` | Use asynchronous methods to convert a CDR file to PDF, improving UI responsivene... |
| [implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs](./implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs) | `JpegOptions`, `LoadOptions` | Implement progress reporting while batch converting CDR files to JPG, updating a... |
| [apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs](./apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `JpegOptions` | Apply a custom JPEG encoder setting to embed EXIF metadata during CDR‑to‑JPG con... |
| [preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs](./preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Preserve alpha channel when converting a CDR file to PNG by configuring PNG opti... |
| [generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs](./generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Generate a PDF with embedded fonts when converting a CDR file to PDF using C#. |
| [retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs](./retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs) | `CdrImage`, `PsdOptions`, `VectorRasterizationOptions` | Retain layer groups when exporting a CDR file to PSD by enabling layer preservat... |
| [resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs](./resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs) | `CdrImage`, `JpegOptions` | Resize a CDR‑to‑JPG conversion output to 1024×768 pixels during saving in C#. |
| [apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs](./apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Apply lossless compression to a CDR‑to‑PNG conversion while maintaining original... |
| [set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs](./set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs) | `CdrImage`, `PdfCoreOptions`, `PdfOptions` | Set PDF version to 1.7 for compatibility when converting a CDR file to PDF in C#... |
| [set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs](./set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Set PSD resolution to 300 DPI for print quality when converting a CDR file in C#... |
| [ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs](./ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs) | `CdrRasterizationOptions`, `PdfOptions` | Ensure fonts are embedded in the PDF output when converting a CDR file with embe... |
| [batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs](./batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs) | `CdrImage`, `JpegOptions` | Batch convert CDR files to JPG, naming each output with the original filename pl... |

## Category Statistics
- Total examples: 90
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

## Version History

| Version | Examples Added | Total | Date |
|---------|---------------|-------|------|
| V1 | 30 | 60 | 2026-04-17 |
| V2 | 30 | 90 | 2026-04-22 |

<!-- AUTOGENERATED:START -->
Updated: 2026-04-22 | Run: `20260422_062821` | Examples: 90
<!-- AUTOGENERATED:END -->