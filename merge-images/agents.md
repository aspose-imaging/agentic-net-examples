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

- `using Aspose.Imaging.ImageOptions;` (40/40 files) ← category-specific
- `using System;` (39/40 files)
- `using System.IO;` (39/40 files)
- `using Aspose.Imaging.Sources;` (37/40 files) ← category-specific
- `using System.Collections.Generic;` (36/40 files)
- `using Aspose.Imaging;` (34/40 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (34/40 files) ← category-specific
- `using System.Linq;` (23/40 files)
- `using Aspose.Imaging.FileFormats.Pdf;` (6/40 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (6/40 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (1/40 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs](./load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Load multiple JPEG files from a directory and merge them horizontally into a sin... |
| [load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs](./load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs) | `JpegImage`, `JpegOptions` | 28678 load several jpeg pictures arrange them vertically and save the combined r... |
| [combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs](./combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | 28679 combine a set of jpeg images horizontally and output the merged picture as... |
| [merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs](./merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs) | `PngOptions` | 28680 merge multiple jpeg files side by side and store the final composition in ... |
| [resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs](./resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs) | `JpegImage`, `JpegOptions` | 28681 resize each input jpeg to a uniform width before performing a horizontal m... |
| [rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs](./rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 28682 rotate every jpeg image ninety degrees clockwise then merge them verticall... |
| [flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs](./flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs) | `PngOptions`, `RasterImage` | 28683 flip each jpeg image horizontally compose them in a horizontal layout and ... |
| [crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs](./crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs) | `JpegOptions`, `PdfOptions` | 28684 crop all jpeg pictures to a central square region merge them vertically an... |
| [apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs](./apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs) | `Graphics`, `JpegImage`, `JpegOptions` | 28685 apply a uniform background color to the canvas before merging jpeg images ... |
| [set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs](./set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | 28686 set the output dpi to 300 when merging jpeg files horizontally and saving ... |
| [specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs](./specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 28687 specify jpeg quality level of 85 while merging images vertically and stori... |
| [use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs](./use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 28688 use imageloadoptions to limit memory usage while loading jpeg files for a ... |
| [create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs](./create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 28689 create a memory stream merge jpeg images horizontally and write the combin... |
| [read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs](./read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 28690 read jpeg images from a network stream merge them vertically and send the ... |
| [process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs](./process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Process a batch of JPEG folders, merging each folder's images horizontally into ... |
| [implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs](./implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs) | `PngOptions`, `RasterImage` | 28692 implement parallel loading of jpeg files then merge them vertically and sa... |
| [use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs](./use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 28693 use a cancellation token to abort a long running horizontal jpeg merge ope... |
| [log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs](./log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs) | `JpegOptions` | 28694 log progress percentage after each jpeg image is added to the canvas durin... |
| [wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs](./wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs) | `PngOptions`, `RasterImage` | 28695 wrap image loading and merging code in try catch blocks to handle file acc... |
| [employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs](./employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs) | `PngOptions`, `RasterImage` | 28696 employ using statements to ensure all image objects are disposed after com... |
| [generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs](./generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 28697 generate output filenames by appending a timestamp to the original jpeg na... |
| [save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs](./save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs) | `JpegOptions` | 28698 save merged jpeg images to a temporary folder then move them to the final ... |
| [configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs](./configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Configure PdfOptions to use A4 page size when saving a horizontally merged JPEG ... |
| [enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs](./enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs) | `PngOptions`, `RasterImage` | Enable PNG interlacing in PngOptions while merging JPEG images horizontally and ... |
| [set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs](./set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Set JPEG subsampling to 4:2:0 in JpegOptions during a vertical merge to reduce f... |
| [apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs](./apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Apply a grayscale color conversion to each JPEG before merging them horizontally... |
| [convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs](./convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Convert each JPEG to CMYK color space prior to a vertical merge and save the res... |
| [add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) | `Graphics`, `JpegImage`, `JpegOptions` | Add a semi‑transparent watermark text to the merged image after completing a hor... |
| [overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs](./overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs) | `PngOptions`, `RasterImage` | Overlay a logo PNG on the bottom‑right corner of the merged JPEG image before sa... |
| [insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs](./insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs) | `BmpOptions`, `Graphics`, `JpegOptions` | Insert a 10‑pixel padding between each JPEG image during a vertical merge to imp... |
| [align-all-merged-jpeg-images-to-the-top-left-corner-of-the-canvas-for-a-consistent-layout.cs](./align-all-merged-jpeg-images-to-the-top-left-corner-of-the-canvas-for-a-consistent-layout.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Align all merged JPEG images to the top‑left corner of the canvas for a consiste... |
| [center-each-jpeg-image-on-the-canvas-while-merging-them-horizontally-to-create-a-balanced-composition.cs](./center-each-jpeg-image-on-the-canvas-while-merging-them-horizontally-to-create-a-balanced-composition.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Center each JPEG image on the canvas while merging them horizontally to create a... |
| [place-jpeg-images-at-the-bottom-right-of-the-canvas-during-a-vertical-merge-to-achieve-right-aligned-output.cs](./place-jpeg-images-at-the-bottom-right-of-the-canvas-during-a-vertical-merge-to-achieve-right-aligned-output.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Place JPEG images at the bottom‑right of the canvas during a vertical merge to a... |
| [use-imageoptions-to-set-output-resolution-to-150-dpi-when-saving-a-merged-jpeg-as-png.cs](./use-imageoptions-to-set-output-resolution-to-150-dpi-when-saving-a-merged-jpeg-as-png.cs) | `Graphics`, `PngOptions`, `RasterImage` | Use ImageOptions to set output resolution to 150 DPI when saving a merged JPEG a... |
| [apply-a-uniform-border-of-five-pixels-around-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./apply-a-uniform-border-of-five-pixels-around-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Apply a uniform border of five pixels around the merged image after completing a... |
| [create-a-custom-canvas-larger-than-the-combined-image-size-and-position-jpegs-centrally-before-merging-vertically.cs](./create-a-custom-canvas-larger-than-the-combined-image-size-and-position-jpegs-centrally-before-merging-vertically.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Create a custom canvas larger than the combined image size and position JPEGs ce... |
| [preserve-original-exif-metadata-by-copying-it-from-the-first-jpeg-to-the-merged-output-file.cs](./preserve-original-exif-metadata-by-copying-it-from-the-first-jpeg-to-the-merged-output-file.cs) | `JpegImage`, `JpegOptions` | Preserve original EXIF metadata by copying it from the first JPEG to the merged ... |
| [remove-all-metadata-from-the-merged-jpeg-image-to-reduce-file-size-after-a-vertical-merge.cs](./remove-all-metadata-from-the-merged-jpeg-image-to-reduce-file-size-after-a-vertical-merge.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Remove all metadata from the merged JPEG image to reduce file size after a verti... |
| [add-custom-author-metadata-to-the-merged-pdf-generated-from-a-horizontal-jpeg-merge-operation.cs](./add-custom-author-metadata-to-the-merged-pdf-generated-from-a-horizontal-jpeg-merge-operation.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Add custom author metadata to the merged PDF generated from a horizontal JPEG me... |
| [load-jpeg-images-using-a-filestream-merge-them-horizontally-and-close-the-streams-automatically-with-using-blocks.cs](./load-jpeg-images-using-a-filestream-merge-them-horizontally-and-close-the-streams-automatically-with-using-blocks.cs) | `JpegImage`, `JpegOptions` | Load JPEG images using a FileStream, merge them horizontally, and close the stre... |
| - | | existing-0 |
| - | | existing-1 |
| - | | existing-10 |
| - | | existing-11 |
| - | | existing-12 |
| - | | existing-13 |
| - | | existing-14 |
| - | | existing-15 |
| - | | existing-16 |
| - | | existing-17 |
| - | | existing-18 |
| - | | existing-19 |
| - | | existing-2 |
| - | | existing-20 |
| - | | existing-21 |
| - | | existing-22 |
| - | | existing-23 |
| - | | existing-24 |
| - | | existing-25 |
| - | | existing-26 |
| - | | existing-27 |
| - | | existing-28 |
| - | | existing-29 |
| - | | existing-3 |
| - | | existing-30 |
| - | | existing-31 |
| - | | existing-32 |
| - | | existing-33 |
| - | | existing-34 |
| - | | existing-35 |
| - | | existing-36 |
| - | | existing-37 |
| - | | existing-38 |
| - | | existing-39 |
| - | | existing-4 |
| - | | existing-40 |
| - | | existing-41 |
| - | | existing-42 |
| - | | existing-43 |
| - | | existing-44 |
| - | | existing-45 |
| - | | existing-46 |
| - | | existing-47 |
| - | | existing-48 |
| - | | existing-49 |
| - | | existing-5 |
| - | | existing-50 |
| - | | existing-51 |
| - | | existing-52 |
| - | | existing-53 |
| - | | existing-54 |
| - | | existing-55 |
| - | | existing-56 |
| - | | existing-57 |
| - | | existing-58 |
| - | | existing-59 |
| - | | existing-6 |
| - | | existing-60 |
| - | | existing-61 |
| - | | existing-62 |
| - | | existing-63 |
| - | | existing-64 |
| - | | existing-65 |
| - | | existing-66 |
| - | | existing-67 |
| - | | existing-68 |
| - | | existing-69 |
| - | | existing-7 |
| - | | existing-70 |
| - | | existing-71 |
| - | | existing-72 |
| - | | existing-73 |
| - | | existing-74 |
| - | | existing-75 |
| - | | existing-76 |
| - | | existing-77 |
| - | | existing-78 |
| - | | existing-79 |
| - | | existing-8 |
| - | | existing-80 |
| - | | existing-81 |
| - | | existing-82 |
| - | | existing-83 |
| - | | existing-84 |
| - | | existing-85 |
| - | | existing-86 |
| - | | existing-87 |
| - | | existing-88 |
| - | | existing-89 |
| - | | existing-9 |
| - | | existing-90 |
| - | | existing-91 |
| - | | existing-92 |
| - | | existing-93 |
| - | | existing-94 |

## Category Statistics
- Total examples: 135
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpOptions`
- `Graphics`
- `JpegImage`
- `JpegOptions`
- `PdfOptions`
- `PngOptions`
- `RasterImage`
- `SolidBrush`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-04-02 | Run: `20260402_084856` | Examples: 135
<!-- AUTOGENERATED:END -->