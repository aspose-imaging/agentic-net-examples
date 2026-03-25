---
name: convert-cmx-images
description: C# examples for Convert CMX Images using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Convert CMX Images

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Convert CMX Images** category.
This folder contains standalone C# examples for Convert CMX Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using Aspose.Imaging;` (35/34 files) ← category-specific
- `using System;` (34/34 files)
- `using System.IO;` (34/34 files)
- `using Aspose.Imaging.ImageOptions;` (33/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cmx;` (20/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (13/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (4/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (4/34 files) ← category-specific
- `using Aspose.Imaging.Sources;` (4/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (4/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (4/34 files) ← category-specific
- `using System.Collections.Generic;` (1/34 files)
- `using System.Threading.Tasks;` (1/34 files)
- `using Aspose.Imaging.FileFormats.Bmp;` (1/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (1/34 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (1/34 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs](./load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs) | `CmxImage`, `PngOptions` | Load a CMX file from a local path using the Image.Load method. |
| [detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs](./detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs) | `CmxImage` | Detect whether the loaded CMX image contains multiple pages using the Image.IsMu... |
| [convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs](./convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs) | `TiffOptions` | Convert a single‑page CMX image to a single‑page TIFF file with default compress... |
| [convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs](./convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs) | `CmxImage`, `Graphics`, `PngImage` | Convert a single‑page CMX image to a multi‑page TIFF file by adding blank pages. |
| [convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs](./convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs) | `CmxImage`, `PngOptions`, `RasterImage` | Convert a multi‑page CMX image to a single‑page TIFF file by merging pages. |
| [convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs](./convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs) | `TiffOptions`, `VectorRasterizationOptions` | Convert a multi‑page CMX image to a multi‑page TIFF file preserving original pag... |
| [convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs](./convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs) | `JpegOptions` | Convert a CMX image to JPEG format with quality set to 90 using JpegOptions. |
| [convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs](./convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs) | `CmxImage`, `JpegOptions`, `VectorRasterizationOptions` | Convert a CMX image to JPEG format with progressive encoding enabled for smoothe... |
| [convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs](./convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs) | `CmxRasterizationOptions`, `PdfOptions` | Convert a CMX image to PDF format with A4 page size using PdfOptions. |
| [convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs](./convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs) | `CmxRasterizationOptions`, `LoadOptions`, `PdfOptions` | Convert a CMX image to PDF format embedding fonts as subsets for smaller files. |
| [save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs](./save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs) | `TiffOptions` | Save converted TIFF images with LZW compression and verify file size reduction. |
| [save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs](./save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs) | `TiffOptions` | Save converted TIFF images with CCITT Group 4 compression for monochrome output. |
| [set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs](./set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs) | `JpegOptions` | Set DPI of output JPEG image to 300 using JpegOptions.ResolutionX and Resolution... |
| [preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs](./preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs) | `CmxImage`, `PdfOptions`, `VectorRasterizationOptions` | Preserve CMX metadata when converting to PDF by copying ImageProperties to the P... |
| [convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs](./convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs) | `TiffOptions` | Convert CMX to TIFF with custom color depth of 8 bits per pixel. |
| [convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs](./convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs) | `CmxImage`, `CmxRasterizationOptions`, `JpegImage` | Convert CMX to JPEG with custom background color for transparent regions to avoi... |
| [use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs](./use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs) | `CmxImage`, `TiffOptions`, `VectorRasterizationOptions` | Use Aspose.Imaging to convert CMX stream from memory to TIFF without temporary f... |
| [convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs](./convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs) | `CmxImage`, `CmxRasterizationOptions`, `PdfOptions` | Convert CMX image loaded from a network stream to PDF and write to response stre... |
| [implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs](./implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs) | `CmxImage`, `JpegOptions` | Implement asynchronous conversion of CMX to JPEG using async/await pattern for n... |
| [create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs](./create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs) | `BmpOptions`, `GifOptions`, `JpegOptions` | Create a console application that accepts input CMX path and output format as ar... |
| [validate-that-output-file-size-does-not-exceed-a-specified-limit-after-conversion.cs](./validate-that-output-file-size-does-not-exceed-a-specified-limit-after-conversion.cs) | `PngOptions` | Validate that output file size does not exceed a specified limit after conversio... |
| [generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs](./generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs) | `CmxImage`, `PngOptions` | Generate a thumbnail of a CMX image before conversion using Image.Resize for pre... |
| [apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs](./apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs) | `TiffOptions` | Apply rotation to CMX image before converting to TIFF using Image.RotateFlip to ... |
| [convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs](./convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs) | `CmxImage`, `PdfOptions` | Convert CMX to multi‑page PDF where each CMX page becomes a separate PDF page. |
| [convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs](./convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs) | `CmxImage`, `PdfOptions`, `VectorRasterizationOptions` | Convert CMX to single‑page PDF by flattening all pages onto one page. |
| [use-imageoptions-to-set-color-profile-for-tiff-output-during-cmx-conversion.cs](./use-imageoptions-to-set-color-profile-for-tiff-output-during-cmx-conversion.cs) | `TiffOptions` | Use ImageOptions to set color profile for TIFF output during CMX conversion. |
| [convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs](./convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs) | `CmxImage`, `JpegOptions` | Convert CMX to JPEG with EXIF orientation tag preserved from source image. |
| [implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs](./implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs) | `CmxImage`, `CmxRasterizationOptions`, `PngOptions` | Implement logging of conversion parameters using NLog for each CMX conversion op... |
| [write-unit-tests-for-cmx-to-tiff-conversion-covering-single-page-and-multi-page-scenarios.cs](./write-unit-tests-for-cmx-to-tiff-conversion-covering-single-page-and-multi-page-scenarios.cs) | `MultiPageOptions`, `TiffOptions`, `VectorRasterizationOptions` | Write unit tests for CMX to TIFF conversion covering single‑page and multi‑page ... |
| [write-integration-tests-for-batch-conversion-of-cmx-files-to-pdf-in-parallel-threads.cs](./write-integration-tests-for-batch-conversion-of-cmx-files-to-pdf-in-parallel-threads.cs) | `PdfOptions`, `VectorRasterizationOptions` | Write integration tests for batch conversion of CMX files to PDF in parallel thr... |
| [optimize-memory-usage-when-converting-large-multi-page-cmx-files-by-streaming-pages.cs](./optimize-memory-usage-when-converting-large-multi-page-cmx-files-by-streaming-pages.cs) | `CmxImage`, `PngOptions` | Optimize memory usage when converting large multi‑page CMX files by streaming pa... |
| [convert-cmx-to-tiff-using-a-custom-image-encoder-to-embed-custom-tags.cs](./convert-cmx-to-tiff-using-a-custom-image-encoder-to-embed-custom-tags.cs) | `TiffOptions` | Convert CMX to TIFF using a custom image encoder to embed custom tags. |
| [convert-cmx-to-jpeg-using-a-custom-quality-setting-read-from-configuration-file.cs](./convert-cmx-to-jpeg-using-a-custom-quality-setting-read-from-configuration-file.cs) | `JpegOptions`, `VectorRasterizationOptions` | Convert CMX to JPEG using a custom quality setting read from configuration file. |
| [convert-cmx-to-pdf-with-custom-document-title-set-via-pdfoptions-title-for-identification.cs](./convert-cmx-to-pdf-with-custom-document-title-set-via-pdfoptions-title-for-identification.cs) | `PdfOptions`, `VectorRasterizationOptions` | Convert CMX to PDF with custom document title set via PdfOptions.Title for ident... |

## Category Statistics
- Total examples: 34
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpOptions`
- `CmxImage`
- `CmxRasterizationOptions`
- `GifOptions`
- `Graphics`
- `JpegImage`
- `JpegOptions`
- `LoadOptions`
- `MultiPageOptions`
- `PdfOptions`
- `PngImage`
- `PngOptions`
- `RasterImage`
- `TiffOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-03-25 | Run: `20260325_164920` | Examples: 34
<!-- AUTOGENERATED:END -->