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

- `using System;` (135/135 files)
- `using System.IO;` (135/135 files)
- `using Aspose.Imaging.ImageOptions;` (133/135 files) ← category-specific
- `using Aspose.Imaging;` (131/135 files) ← category-specific
- `using System.Collections.Generic;` (91/135 files)
- `using Aspose.Imaging.Sources;` (83/135 files) ← category-specific
- `using System.Linq;` (56/135 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (55/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (18/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (14/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (5/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (4/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (4/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (3/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg2000;` (3/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tga;` (3/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (3/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf;` (3/135 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (3/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.BigTiff;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Djvu;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Ico;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Dicom;` (2/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Graphics;` (1/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cmx;` (1/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (1/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (1/135 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs](./load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | load multiple jpeg files from a directory and merge them horizontally into a sin... |
| [load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs](./load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs) | `JpegImage`, `JpegOptions` | load several jpeg pictures arrange them vertically and save the combined result ... |
| [combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs](./combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | combine a set of jpeg images horizontally and output the merged picture as a pdf... |
| [merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs](./merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs) | `PngOptions`, `RasterImage` | merge multiple jpeg files side by side and store the final composition in png fo... |
| [resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs](./resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | resize each input jpeg to a uniform width before performing a horizontal merge a... |
| [rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs](./rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | rotate every jpeg image ninety degrees clockwise then merge them vertically and ... |
| [flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs](./flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs) | `PngOptions` | flip each jpeg image horizontally compose them in a horizontal layout and export... |
| [crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs](./crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | crop all jpeg pictures to a central square region merge them vertically and writ... |
| [apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs](./apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs) | `Graphics`, `JpegImage`, `JpegOptions` | apply a uniform background color to the canvas before merging jpeg images horizo... |
| [set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs](./set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | set the output dpi to 300 when merging jpeg files horizontally and saving the re... |
| [specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs](./specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | specify jpeg quality level of 85 while merging images vertically and storing the... |
| [use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs](./use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs) | `JpegImage`, `JpegOptions`, `LoadOptions` | use imageloadoptions to limit memory usage while loading jpeg files for a horizo... |
| [create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs](./create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | create a memory stream merge jpeg images horizontally and write the combined out... |
| [read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs](./read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | read jpeg images from a network stream merge them vertically and send the result... |
| [process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs](./process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | process a batch of jpeg folders merging each folder s images horizontally into s... |
| [implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs](./implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs) | `PngOptions`, `RasterImage` | implement parallel loading of jpeg files then merge them vertically and save the... |
| [use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs](./use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | use a cancellation token to abort a long running horizontal jpeg merge operation... |
| [log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs](./log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs) | `JpegImage`, `JpegOptions` | log progress percentage after each jpeg image is added to the canvas during a ve... |
| [wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs](./wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | wrap image loading and merging code in try catch blocks to handle file access ex... |
| [employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs](./employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs) | `PngOptions`, `RasterImage` | employ using statements to ensure all image objects are disposed after completin... |
| [generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs](./generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | generate output filenames by appending a timestamp to the original jpeg name for... |
| [save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs](./save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | save merged jpeg images to a temporary folder then move them to the final destin... |
| [configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs](./configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | configure pdfoptions to use a4 page size when saving a horizontally merged jpeg ... |
| [enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs](./enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs) | `PngOptions`, `RasterImage` | enable png interlacing in pngoptions while merging jpeg images horizontally and ... |
| [set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs](./set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs) | `JpegImage`, `JpegOptions` | set jpeg subsampling to 4 2 0 in jpegoptions during a vertical merge to reduce f... |
| [apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs](./apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Apply a grayscale color conversion to each JPEG before merging them horizontally... |
| [convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs](./convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | convert each jpeg to cmyk color space prior to a vertical merge and save the res... |
| [add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) | `Graphics`, `JpegImage`, `JpegOptions` | Add a semi‑transparent watermark text to the merged image after completing a hor... |
| [overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs](./overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs) | `PngOptions`, `RasterImage` | overlay a logo png on the bottom right corner of the merged jpeg image before sa... |
| [insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs](./insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | insert a 10 pixel padding between each jpeg image during a vertical merge to imp... |
| *...and 105 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/main/merge-images) |

## Category Statistics
- Total examples: 135
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

<!-- AUTOGENERATED:START -->
Updated: 2026-04-07 | Run: `20260407_065759` | Examples: 135
<!-- AUTOGENERATED:END -->