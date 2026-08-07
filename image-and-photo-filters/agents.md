---
name: image-and-photo-filters
description: C# examples for Image and Photo Filters using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Image and Photo Filters

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Image and Photo Filters** category.
This folder contains standalone C# examples for Image and Photo Filters operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (72/148 files)
- `using System.IO;` (72/148 files)
- `using Aspose.Imaging;` (70/148 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (56/148 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (35/148 files) ← category-specific
- `using Aspose.Imaging.MagicWand;` (32/148 files) ← category-specific
- `using Aspose.Imaging.MagicWand.ImageMasks;` (29/148 files) ← category-specific
- `using Aspose.Imaging.Sources;` (20/148 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (19/148 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (7/148 files) ← category-specific
- `using Aspose.Imaging.Watermark;` (6/148 files) ← category-specific
- `using Aspose.Imaging.Watermark.Options;` (6/148 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (5/148 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (5/148 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (4/148 files) ← category-specific
- `using Aspose.Imaging.Masking;` (4/148 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (4/148 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (4/148 files) ← category-specific
- `using System.Linq;` (3/148 files)
- `using System.Collections.Generic;` (3/148 files)
- `using Aspose.Imaging.Brushes;` (3/148 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (3/148 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (1/148 files) ← category-specific
- `using System.Drawing;` (1/148 files)
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (1/148 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-jpeg-image-apply-alpha-blending-with-127-opacity-and-save-as-png.cs](./load-a-jpeg-image-apply-alpha-blending-with-127-opacity-and-save-as-png.cs) | `PngOptions`, `RasterImage` | Load a JPEG image, apply alpha blending with 127 opacity, and save as PNG. |
| [calculate-center-coordinates-of-a-bmp-background-blend-a-png-overlay-and-export-to-tiff.cs](./calculate-center-coordinates-of-a-bmp-background-blend-a-png-overlay-and-export-to-tiff.cs) | `RasterImage`, `TiffOptions` | Calculate center coordinates of a BMP background, blend a PNG overlay, and expor... |
| [batch-process-a-folder-of-png-images-applying-64-alpha-overlay-and-saving-results-as-jpeg-files.cs](./batch-process-a-folder-of-png-images-applying-64-alpha-overlay-and-saving-results-as-jpeg-files.cs) | `PngOptions` | Batch process a folder of PNG images, applying 64‑alpha overlay and saving resul... |
| [create-a-point-object-at-100-200-to-position-overlay-on-a-tiff-image.cs](./create-a-point-object-at-100-200-to-position-overlay-on-a-tiff-image.cs) | `Graphics`, `TiffImage`, `TiffOptions` | Create a Point object at (100,200) to position overlay on a TIFF image. |
| [define-a-custom-overlay-rectangle-of-200x150-pixels-and-blend-it-onto-a-gif-background.cs](./define-a-custom-overlay-rectangle-of-200x150-pixels-and-blend-it-onto-a-gif-background.cs) | `GifOptions`, `Graphics`, `PngOptions` | Define a custom overlay rectangle of 200x150 pixels and blend it onto a GIF back... |
| [apply-alpha-blending-with-full-opacity-255-to-a-png-overlay-and-verify-no-transparency-loss.cs](./apply-alpha-blending-with-full-opacity-255-to-a-png-overlay-and-verify-no-transparency-loss.cs) | `PngOptions`, `RasterImage` | Apply alpha blending with full opacity (255) to a PNG overlay and verify no tran... |
| [use-magic-wand-tool-with-threshold-30-to-select-red-region-in-a-jpeg-image.cs](./use-magic-wand-tool-with-threshold-30-to-select-red-region-in-a-jpeg-image.cs) | `JpegOptions`, `RasterImage` | Use Magic Wand tool with threshold 30 to select red region in a JPEG image. |
| [combine-two-magic-wand-selections-using-union-operation-and-save-the-combined-mask-as-png.cs](./combine-two-magic-wand-selections-using-union-operation-and-save-the-combined-mask-as-png.cs) | `PngOptions`, `RasterImage` | Combine two Magic Wand selections using union operation and save the combined ma... |
| [subtract-a-green-magic-wand-selection-from-a-blue-selection-and-export-the-result-to-bmp.cs](./subtract-a-green-magic-wand-selection-from-a-blue-selection-and-export-the-result-to-bmp.cs) | `BmpOptions`, `RasterImage` | Subtract a green Magic Wand selection from a blue selection and export the resul... |
| [invert-a-magic-wand-selection-on-a-tiff-image-and-fill-the-inverted-area-with-white.cs](./invert-a-magic-wand-selection-on-a-tiff-image-and-fill-the-inverted-area-with-white.cs) | `RasterImage`, `TiffOptions` | Invert a Magic Wand selection on a TIFF image and fill the inverted area with wh... |
| [apply-feathering-of-radius-5-pixels-to-a-magic-wand-selection-before-saving-as-png.cs](./apply-feathering-of-radius-5-pixels-to-a-magic-wand-selection-before-saving-as-png.cs) | `RasterImage` | Apply feathering of radius 5 pixels to a Magic Wand selection before saving as P... |
| [remove-watermark-from-a-jpeg-using-content-aware-fill-algorithm-with-three-removal-attempts.cs](./remove-watermark-from-a-jpeg-using-content-aware-fill-algorithm-with-three-removal-attempts.cs) | `ContentAwareFillWatermarkOptions`, `JpegImage` | Remove watermark from a JPEG using content‑aware fill algorithm with three remov... |
| [remove-watermark-from-a-png-using-telea-algorithm-and-set-removal-attempts-to-five.cs](./remove-watermark-from-a-png-using-telea-algorithm-and-set-removal-attempts-to-five.cs) | `PngImage` | Remove watermark from a PNG using Telea algorithm and set removal attempts to fi... |
| [define-watermark-region-coordinates-50-50-200-100-and-apply-removal-filter-on-a-bmp-image.cs](./define-watermark-region-coordinates-50-50-200-100-and-apply-removal-filter-on-a-bmp-image.cs) | `BmpImage`, `BmpOptions` | Define watermark region coordinates (50,50,200,100) and apply removal filter on ... |
| [batch-remove-watermarks-from-a-folder-of-tiff-files-using-content-aware-fill-and-save-results.cs](./batch-remove-watermarks-from-a-folder-of-tiff-files-using-content-aware-fill-and-save-results.cs) | `ContentAwareFillWatermarkOptions`, `RasterImage` | Batch remove watermarks from a folder of TIFF files using content‑aware fill and... |
| [load-an-image-from-a-memory-stream-apply-alpha-blending-and-write-output-to-another-stream.cs](./load-an-image-from-a-memory-stream-apply-alpha-blending-and-write-output-to-another-stream.cs) | `PngOptions`, `RasterImage` | Load an image from a memory stream, apply alpha blending, and write output to an... |
| [resize-a-jpeg-to-800x600-before-applying-magic-wand-selection-with-threshold-40.cs](./resize-a-jpeg-to-800x600-before-applying-magic-wand-selection-with-threshold-40.cs) | `JpegImage` | Resize a JPEG to 800x600 before applying Magic Wand selection with threshold 40. |
| [rotate-a-png-by-90-degrees-then-blend-a-semi-transparent-overlay-and-save-as-gif.cs](./rotate-a-png-by-90-degrees-then-blend-a-semi-transparent-overlay-and-save-as-gif.cs) | `GifOptions`, `RasterImage` | Rotate a PNG by 90 degrees, then blend a semi‑transparent overlay and save as GI... |
| [crop-a-bmp-to-central-400x400-area-apply-feathered-magic-wand-selection-and-export-to-png.cs](./crop-a-bmp-to-central-400x400-area-apply-feathered-magic-wand-selection-and-export-to-png.cs) | `PngOptions`, `RasterImage` | Crop a BMP to central 400x400 area, apply feathered Magic Wand selection, and ex... |
| [process-each-page-of-a-multi-page-tiff-applying-alpha-blending-with-200-opacity-and-save.cs](./process-each-page-of-a-multi-page-tiff-applying-alpha-blending-with-200-opacity-and-save.cs) | `BmpOptions`, `RasterImage`, `TiffImage` | Process each page of a multi‑page TIFF, applying alpha blending with 200 opacity... |
| [convert-a-pdf-page-to-image-apply-watermark-removal-and-save-the-cleaned-image-as-jpeg.cs](./convert-a-pdf-page-to-image-apply-watermark-removal-and-save-the-cleaned-image-as-jpeg.cs) | `JpegOptions` | Convert a PDF page to image, apply watermark removal, and save the cleaned image... |
| [load-a-gif-animation-apply-magic-wand-selection-on-first-frame-and-reassemble-animation.cs](./load-a-gif-animation-apply-magic-wand-selection-on-first-frame-and-reassemble-animation.cs) | `GifImage`, `RasterImage` | Load a GIF animation, apply Magic Wand selection on first frame, and reassemble ... |
| [apply-alpha-blending-with-0-opacity-to-verify-that-background-image-remains-unchanged-after-operation.cs](./apply-alpha-blending-with-0-opacity-to-verify-that-background-image-remains-unchanged-after-operation.cs) | `PngOptions`, `RasterImage` | Apply alpha blending with 0 opacity to verify that background image remains unch... |
| [set-overlay-alpha-to-192-and-blend-a-png-logo-onto-a-jpeg-banner-at-bottom-right-corner.cs](./set-overlay-alpha-to-192-and-blend-a-png-logo-onto-a-jpeg-banner-at-bottom-right-corner.cs) | `JpegOptions`, `RasterImage` | Set overlay alpha to 192 and blend a PNG logo onto a JPEG banner at bottom‑right... |
| [use-magic-wand-threshold-70-to-select-sky-region-in-a-landscape-png-and-invert-selection.cs](./use-magic-wand-threshold-70-to-select-sky-region-in-a-landscape-png-and-invert-selection.cs) | `PngOptions`, `RasterImage` | Use Magic Wand threshold 70 to select sky region in a landscape PNG and invert s... |
| [combine-three-magic-wand-selections-using-union-then-apply-feathering-of-radius-8-before-saving.cs](./combine-three-magic-wand-selections-using-union-then-apply-feathering-of-radius-8-before-saving.cs) | `RasterImage` | Combine three Magic Wand selections using union, then apply feathering of radius... |
| [subtract-a-text-watermark-selection-from-a-scanned-document-image-and-export-as-high-resolution-tiff.cs](./subtract-a-text-watermark-selection-from-a-scanned-document-image-and-export-as-high-resolution-tiff.cs) | `TeleaWatermarkOptions`, `TiffOptions` | Subtract a text watermark selection from a scanned document image and export as ... |
| [apply-content-aware-fill-removal-on-a-jpeg-with-two-attempts-then-compare-result-with-telea-algorithm.cs](./apply-content-aware-fill-removal-on-a-jpeg-with-two-attempts-then-compare-result-with-telea-algorithm.cs) | `ContentAwareFillWatermarkOptions`, `JpegImage`, `TeleaWatermarkOptions` | Apply content‑aware fill removal on a JPEG with two attempts, then compare resul... |
| [load-images-from-a-zip-archive-apply-alpha-blending-to-each-and-write-outputs-to-another-zip.cs](./load-images-from-a-zip-archive-apply-alpha-blending-to-each-and-write-outputs-to-another-zip.cs) |  | Load images from a ZIP archive, apply alpha blending to each, and write outputs ... |
| [create-a-custom-selection-by-combining-magic-wand-union-and-subtraction-then-fill-with-solid-color.cs](./create-a-custom-selection-by-combining-magic-wand-union-and-subtraction-then-fill-with-solid-color.cs) | `Graphics`, `PngOptions`, `RasterImage` | Create a custom selection by combining Magic Wand union and subtraction, then fi... |
| *...and 118 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.7.0/image-and-photo-filters) |

## Category Statistics
- Total examples: 148
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngFrame`
- `ApngImage`
- `ApngOptions`
- `AutoMaskingGraphCutOptions`
- `BigTiffImage`
- `BilateralSmoothingFilterOptions`
- `BmpImage`
- `BmpOptions`
- `ContentAwareFillWatermarkOptions`
- `GaussWienerFilterOptions`
- `GaussianBlurFilterOptions`
- `GifImage`
- `GifOptions`
- `GraphCutMaskingOptions`
- `Graphics`
- `ImageBlendingFilterOptions`
- `JpegImage`
- `JpegOptions`
- `MaskingOptions`
- `MedianFilterOptions`
- `MotionWienerFilterOptions`
- `PngImage`
- `PngOptions`
- `RasterCachedImage`
- `RasterImage`
- `SharpenFilterOptions`
- `SolidBrush`
- `TeleaWatermarkOptions`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases  
- An online gallery lets users upload pictures and instantly **apply filter Aspose.Imaging** to create vintage or black‑and‑white looks before sharing.  
- An e‑commerce site generates product thumbnails by running an **image filter C#** routine that sharpens edges and balances colors for faster loading.  
- A desktop photo‑editing tool offers batch processing where developers can plug in a **photo filter dotnet** component to apply artistic effects to hundreds of images in one click.  
- A medical imaging application enhances X‑ray scans by using **apply filter Aspose.Imaging** to improve contrast and highlight critical details for diagnostic review.  
- An automated social‑media scheduler adds a brand‑specific **image filter C#** to every visual asset, ensuring consistent visual identity across all posts.

## Related Categories  
The Image and Photo Filters examples often complement the **Image Conversion** and **Image Resizing and Cropping** sections, where transformed images are later saved in different formats or dimensions. Developers working on **Watermarking and Text Overlay** can combine filter operations with branding overlays to produce polished marketing assets. Additionally, the **Metadata and EXIF** category provides tools to preserve or modify image information after applying filters, ensuring that the processed files remain compliant with downstream workflows.

<!-- AUTOGENERATED:START -->
Updated: 2026-07-22 | Run: `20260722_054922` | Examples: 148
<!-- AUTOGENERATED:END -->