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

- `using Aspose.Imaging;` (68/68 files) ← category-specific
- `using System;` (68/68 files)
- `using System.IO;` (68/68 files)
- `using Aspose.Imaging.ImageOptions;` (65/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cmx;` (40/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (23/68 files) ← category-specific
- `using Aspose.Imaging.Sources;` (11/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (10/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (8/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (7/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (6/68 files) ← category-specific
- `using System.Collections.Generic;` (4/68 files)
- `using System.Threading.Tasks;` (2/68 files)
- `using Aspose.Imaging.FileFormats.Bmp;` (1/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (1/68 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (1/68 files) ← category-specific
- `using System.Linq;` (1/68 files)
- `using Aspose.Imaging.ImageLoadOptions;` (1/68 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs](./load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs) |  | load a cmx file from a local path using the image load method |
| [detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs](./detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs) | `CmxImage` | detect whether the loaded cmx image contains multiple pages using the image ismu... |
| [convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs](./convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs) | `TiffOptions` | convert a single page cmx image to a single page tiff file with default compress... |
| [28194-convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs](./28194-convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs) | `CmxImage`, `Graphics`, `TiffFrame` | convert a single page cmx image to a multi page tiff file by adding blank pages |
| [convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs](./convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs) | `CmxImage`, `MultiPageOptions`, `PngOptions` | Convert a multi‑page CMX image to a single‑page TIFF file by merging pages. |
| [convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs](./convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs) | `CmxImage`, `TiffOptions`, `VectorRasterizationOptions` | convert a multi page cmx image to a multi page tiff file preserving original pag... |
| [convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs](./convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs) | `JpegOptions` | convert a cmx image to jpeg format with quality set to 90 using jpegoptions |
| [convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs](./convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs) | `JpegOptions` | convert a cmx image to jpeg format with progressive encoding enabled for smoothe... |
| [convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs](./convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs) | `CmxRasterizationOptions`, `PdfOptions` | convert a cmx image to pdf format with a4 page size using pdfoptions |
| [convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs](./convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs) | `CmxRasterizationOptions`, `LoadOptions`, `PdfOptions` | convert a cmx image to pdf format embedding fonts as subsets for smaller files |
| [save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs](./save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs) | `TiffOptions` | save converted tiff images with lzw compression and verify file size reduction |
| [save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs](./save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs) | `TiffOptions` | save converted tiff images with ccitt group 4 compression for monochrome output |
| [set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs](./set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs) | `JpegOptions` | set dpi of output jpeg image to 300 using jpegoptions resolutionx and resolution... |
| [preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs](./preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs) | `CmxImage`, `PdfOptions`, `VectorRasterizationOptions` | preserve cmx metadata when converting to pdf by copying imageproperties to the p... |
| [convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs](./convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs) | `CmxImage`, `TiffOptions` | convert cmx to tiff with custom color depth of 8 bits per pixel |
| [convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs](./convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs) | `CmxImage`, `JpegOptions` | convert cmx to jpeg with custom background color for transparent regions to avoi... |
| [use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs](./use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs) | `TiffOptions` | use aspose imaging to convert cmx stream from memory to tiff without temporary f... |
| [convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs](./convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs) | `CmxRasterizationOptions`, `PdfOptions` | convert cmx image loaded from a network stream to pdf and write to response stre... |
| [implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs](./implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs) | `CmxImage`, `JpegOptions` | implement asynchronous conversion of cmx to jpeg using async await pattern for n... |
| [create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs](./create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs) | `PngOptions` | create a console application that accepts input cmx path and output format as ar... |
| [validate-that-output-file-size-does-not-exceed-a-specified-limit-after-conversion.cs](./validate-that-output-file-size-does-not-exceed-a-specified-limit-after-conversion.cs) | `PngOptions` | validate that output file size does not exceed a specified limit after conversio... |
| [generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs](./generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs) | `PngOptions` | generate a thumbnail of a cmx image before conversion using image resize for pre... |
| [apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs](./apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs) |  | apply rotation to cmx image before converting to tiff using image rotateflip to ... |
| [convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs](./convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs) | `CmxImage`, `PdfOptions`, `VectorRasterizationOptions` | convert cmx to multi page pdf where each cmx page becomes a separate pdf page |
| [convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs](./convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs) | `JpegOptions`, `PdfOptions`, `PngOptions` | convert cmx to single page pdf by flattening all pages onto one page |
| [use-imageoptions-to-set-color-profile-for-tiff-output-during-cmx-conversion.cs](./use-imageoptions-to-set-color-profile-for-tiff-output-during-cmx-conversion.cs) | `CmxImage`, `TiffOptions`, `VectorRasterizationOptions` | use imageoptions to set color profile for tiff output during cmx conversion |
| [convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs](./convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs) | `CmxImage`, `JpegOptions` | convert cmx to jpeg with exif orientation tag preserved from source image |
| [implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs](./implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs) | `CmxImage`, `PngOptions`, `VectorRasterizationOptions` | implement logging of conversion parameters using nlog for each cmx conversion op... |
| [write-unit-tests-for-cmx-to-tiff-conversion-covering-single-page-and-multi-page-scenarios.cs](./write-unit-tests-for-cmx-to-tiff-conversion-covering-single-page-and-multi-page-scenarios.cs) | `MultiPageOptions`, `TiffOptions`, `VectorRasterizationOptions` | write unit tests for cmx to tiff conversion covering single page and multi page ... |
| [write-integration-tests-for-batch-conversion-of-cmx-files-to-pdf-in-parallel-threads.cs](./write-integration-tests-for-batch-conversion-of-cmx-files-to-pdf-in-parallel-threads.cs) | `CmxImage`, `PdfOptions` | write integration tests for batch conversion of cmx files to pdf in parallel thr... |
| *...and 5 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.3.0/convert-cmx-images) |

## Category Statistics
- Total examples: 68
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpOptions`
- `CmxImage`
- `CmxLoadOptions`
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
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅

## Version History

| Version | Examples Added | Total | Date |
|---------|---------------|-------|------|
| V1 | 34 | 68 | 2026-04-21 |

<!-- AUTOGENERATED:START -->
Updated: 2026-04-21 | Run: `20260421_055845` | Examples: 68
<!-- AUTOGENERATED:END -->