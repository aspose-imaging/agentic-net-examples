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

- `using Aspose.Imaging;` (104/102 files) ← category-specific
- `using System;` (102/102 files)
- `using System.IO;` (102/102 files)
- `using Aspose.Imaging.ImageOptions;` (98/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cmx;` (59/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (36/102 files) ← category-specific
- `using Aspose.Imaging.Sources;` (18/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (16/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (14/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (13/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (9/102 files) ← category-specific
- `using System.Collections.Generic;` (5/102 files)
- `using System.Threading.Tasks;` (4/102 files)
- `using Aspose.Imaging.ImageLoadOptions;` (4/102 files) ← category-specific
- `using System.Linq;` (3/102 files)
- `using Aspose.Imaging.FileFormats.Bmp;` (2/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (2/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (1/102 files) ← category-specific
- `using System.Net.Http;` (1/102 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs](./load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs) | `CmxImage`, `PngOptions` |  |
| [detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs](./detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs) | `CmxImage` |  |
| [convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs](./convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs) | `TiffOptions` |  |
| [convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs](./convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs) | `CmxImage`, `Graphics`, `PngOptions` |  |
| [convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs](./convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs) | `PngOptions`, `RasterImage`, `TiffOptions` |  |
| [convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs](./convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs) | `CmxImage`, `TiffOptions`, `VectorRasterizationOptions` |  |
| [convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs](./convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs) | `JpegOptions` |  |
| [convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs](./convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs) | `CmxLoadOptions`, `JpegOptions` |  |
| [convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs](./convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs) | `CmxRasterizationOptions`, `PdfOptions` |  |
| [convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs](./convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs) | `CmxImage`, `PdfOptions`, `VectorRasterizationOptions` |  |
| [save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs](./save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs) | `TiffOptions` |  |
| [save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs](./save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs) | `TiffOptions` |  |
| [set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs](./set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs) | `JpegOptions` |  |
| [preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs](./preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs) | `CmxImage`, `PdfOptions` |  |
| [convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs](./convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs) | `CmxImage`, `TiffOptions` |  |
| [convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs](./convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs) | `CmxImage`, `CmxRasterizationOptions`, `JpegOptions` |  |
| [use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs](./use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs) | `CmxImage`, `CmxLoadOptions`, `TiffOptions` |  |
| [convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs](./convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs) | `CmxImage`, `PdfOptions` |  |
| [implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs](./implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs) | `CmxImage`, `JpegOptions` |  |
| [create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs](./create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs) | `BmpOptions`, `CmxImage`, `CmxRasterizationOptions` |  |
| [validate-that-output-file-size-does-not-exceed-a-specified-limit-after-conversion.cs](./validate-that-output-file-size-does-not-exceed-a-specified-limit-after-conversion.cs) | `LoadOptions`, `PngOptions` |  |
| [generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs](./generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs) | `CmxImage`, `PngOptions` |  |
| [apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs](./apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs) | `CmxImage`, `TiffOptions` |  |
| [convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs](./convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs) | `PdfOptions`, `VectorRasterizationOptions` |  |
| [convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs](./convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs) | `CmxImage`, `JpegImage`, `JpegOptions` |  |
| [use-imageoptions-to-set-color-profile-for-tiff-output-during-cmx-conversion.cs](./use-imageoptions-to-set-color-profile-for-tiff-output-during-cmx-conversion.cs) | `CmxImage`, `RasterImage`, `TiffImage` |  |
| [convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs](./convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs) | `CmxImage`, `JpegOptions` |  |
| [implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs](./implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs) | `PngOptions`, `VectorRasterizationOptions` |  |
| [write-unit-tests-for-cmx-to-tiff-conversion-covering-single-page-and-multi-page-scenarios.cs](./write-unit-tests-for-cmx-to-tiff-conversion-covering-single-page-and-multi-page-scenarios.cs) | `MultiPageOptions`, `TiffOptions` |  |
| [write-integration-tests-for-batch-conversion-of-cmx-files-to-pdf-in-parallel-threads.cs](./write-integration-tests-for-batch-conversion-of-cmx-files-to-pdf-in-parallel-threads.cs) | `CmxRasterizationOptions`, `PdfOptions` |  |
| *...and 5 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.4.0/convert-cmx-images) |

## Category Statistics
- Total examples: 102
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpOptions`
- `CmxImage`
- `CmxLoadOptions`
- `CmxRasterizationOptions`
- `EmfOptions`
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
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-04-28 | Run: `20260428_064005` | Examples: 102
<!-- AUTOGENERATED:END -->