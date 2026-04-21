---
name: merge-images
description: C# examples for Merge Images using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Merge Images

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Merge Images** category.
This folder contains standalone C# examples for Merge Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (215/215 files)
- `using System.IO;` (215/215 files)
- `using Aspose.Imaging.ImageOptions;` (213/215 files) ← category-specific
- `using Aspose.Imaging;` (204/215 files) ← category-specific
- `using System.Collections.Generic;` (168/215 files)
- `using Aspose.Imaging.Sources;` (156/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (119/215 files) ← category-specific
- `using System.Linq;` (111/215 files)
- `using Aspose.Imaging.FileFormats.Pdf;` (25/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (22/215 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (7/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (6/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (4/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (4/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (3/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg2000;` (3/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tga;` (3/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (3/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf;` (3/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.BigTiff;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Djvu;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Ico;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Dicom;` (2/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Graphics;` (1/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cmx;` (1/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (1/215 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (1/215 files) ← category-specific
- `using System.Threading;` (1/215 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs](./load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Load multiple JPEG files from a directory and merge them horizontally into a sin... |
| [load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs](./load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Load several JPEG pictures, arrange them vertically, and save the combined resul... |
| [combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs](./combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Combine a set of JPEG images horizontally and output the merged picture as a PDF... |
| [merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs](./merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs) | `PngOptions`, `RasterImage` | Merge multiple JPEG files side by side and store the final composition in PNG fo... |
| [resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs](./resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Resize each input JPEG to a uniform width before performing a horizontal merge a... |
| [rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs](./rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Rotate every JPEG image ninety degrees clockwise, then merge them vertically and... |
| [flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs](./flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs) | `PngOptions`, `RasterImage` | Flip each JPEG image horizontally, compose them in a horizontal layout, and expo... |
| [crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs](./crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs) | `JpegImage`, `PdfOptions`, `PngOptions` | Crop all JPEG pictures to a central square region, merge them vertically, and wr... |
| [apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs](./apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs) | `Graphics`, `JpegImage`, `JpegOptions` | Apply a uniform background color to the canvas before merging JPEG images horizo... |
| [set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs](./set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Set the output DPI to 300 when merging JPEG files horizontally and saving the re... |
| [specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs](./specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs) | `JpegImage`, `JpegOptions` | Specify JPEG quality level of 85 while merging images vertically and storing the... |
| [use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs](./use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs) | `JpegImage`, `JpegOptions`, `LoadOptions` | Use ImageLoadOptions to limit memory usage while loading JPEG files for a horizo... |
| [create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs](./create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Create a memory stream, merge JPEG images horizontally, and write the combined o... |
| [read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs](./read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Read JPEG images from a network stream, merge them vertically, and send the resu... |
| [process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs](./process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | Process a batch of JPEG folders, merging each folder's images horizontally into ... |
| [implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs](./implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs) | `PngOptions`, `RasterImage` | Implement parallel loading of JPEG files, then merge them vertically and save th... |
| [use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs](./use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Use a cancellation token to abort a long-running horizontal JPEG merge operation... |
| [log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs](./log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs) | `JpegImage`, `JpegOptions` | Log progress percentage after each JPEG image is added to the canvas during a ve... |
| [wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs](./wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs) | `PngOptions`, `RasterImage` | Wrap image loading and merging code in try‑catch blocks to handle file‑access ex... |
| [employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs](./employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs) | `PngOptions`, `RasterImage` | Employ using statements to ensure all Image objects are disposed after completin... |
| [generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs](./generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Generate output filenames by appending a timestamp to the original JPEG name for... |
| [save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs](./save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Save merged JPEG images to a temporary folder, then move them to the final desti... |
| [configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs](./configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Configure PdfOptions to use A4 page size when saving a horizontally merged JPEG ... |
| [enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs](./enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs) | `PngOptions`, `RasterImage` | Enable PNG interlacing in PngOptions while merging JPEG images horizontally and ... |
| [set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs](./set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Set JPEG subsampling to 4:2:0 in JpegOptions during a vertical merge to reduce f... |
| [apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs](./apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Apply a grayscale color conversion to each JPEG before merging them horizontally... |
| [convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs](./convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Convert each JPEG to CMYK color space prior to a vertical merge and save the res... |
| [add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) | `Graphics`, `JpegImage`, `JpegOptions` | Add a semi‑transparent watermark text to the merged image after completing a hor... |
| [overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs](./overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs) | `PngOptions`, `RasterImage` | Overlay a logo PNG on the bottom‑right corner of the merged JPEG image before sa... |
| [insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs](./insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs) | `JpegImage`, `JpegOptions` | Insert a 10‑pixel padding between each JPEG image during a vertical merge to imp... |
| *...and 105 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.3.0/merge-images) |

## Category Statistics
- Total examples: 215
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngImage`
- `ApngOptions`
- `BigTiffImage`
- `BigTiffOptions`
- `BmpOptions`
- `CmxImage`
- `DicomImage`
- `DicomOptions`
- `DjvuImage`
- `EmfOptions`
- `EmfRasterizationOptions`
- `GifImage`
- `GifOptions`
- `Graphics`
- `IcoImage`
- `IcoOptions`
- `Jpeg2000Image`
- `Jpeg2000Options`
- `JpegImage`
- `JpegOptions`
- `LoadOptions`
- `OdgRasterizationOptions`
- `OtgRasterizationOptions`
- `PdfCoreOptions`
- `PdfOptions`
- `PngOptions`
- `PsdOptions`
- `RasterImage`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `TgaOptions`
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`
- `WebPImage`
- `WebPOptions`
- `WmfOptions`
- `WmfRasterizationOptions`

## Failed Tasks

All tasks passed ✅

## Version History

| Version | Examples Added | Total | Date |
|---------|---------------|-------|------|
| V1 | 95 | 95 | 2026-04-06 |
| V2 | 40 | 135 | 2026-04-07 |
| V3 | 40 | 175 | 2026-04-08 |
| V4 | 40 | 215 | 2026-04-21 |

<!-- AUTOGENERATED:START -->
Updated: 2026-04-21 | Run: `20260421_142136` | Examples: 215
<!-- AUTOGENERATED:END -->