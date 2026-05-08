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

- `using System;` (72/138 files)
- `using System.IO;` (72/138 files)
- `using Aspose.Imaging;` (67/138 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (53/138 files) ← category-specific
- `using Aspose.Imaging.MagicWand;` (34/138 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (33/138 files) ← category-specific
- `using Aspose.Imaging.MagicWand.ImageMasks;` (27/138 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (20/138 files) ← category-specific
- `using Aspose.Imaging.Sources;` (14/138 files) ← category-specific
- `using Aspose.Imaging.Watermark;` (6/138 files) ← category-specific
- `using Aspose.Imaging.Watermark.Options;` (6/138 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (5/138 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (4/138 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (4/138 files) ← category-specific
- `using Aspose.Imaging.Masking;` (4/138 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (4/138 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (4/138 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (3/138 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (2/138 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (2/138 files) ← category-specific
- `using System.Diagnostics;` (2/138 files)
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (1/138 files) ← category-specific
- `using System.Drawing;` (1/138 files)
- `using System.Collections.Generic;` (1/138 files)
- `using Aspose.Imaging.FileFormats.BigTiff;` (1/138 files) ← category-specific
- `using System.Linq;` (1/138 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-jpeg-image-apply-alpha-blending-with-127-opacity-and-save-as-png.cs](./load-a-jpeg-image-apply-alpha-blending-with-127-opacity-and-save-as-png.cs) | `JpegImage`, `PngOptions`, `RasterImage` | load a jpeg image apply alpha blending with 127 opacity and save as png |
| [calculate-center-coordinates-of-a-bmp-background-blend-a-png-overlay-and-export-to-tiff.cs](./calculate-center-coordinates-of-a-bmp-background-blend-a-png-overlay-and-export-to-tiff.cs) | `RasterImage`, `TiffOptions` | calculate center coordinates of a bmp background blend a png overlay and export ... |
| [batch-process-a-folder-of-png-images-applying-64-alpha-overlay-and-saving-results-as-jpeg-files.cs](./batch-process-a-folder-of-png-images-applying-64-alpha-overlay-and-saving-results-as-jpeg-files.cs) | `JpegOptions`, `PngOptions` | batch process a folder of png images applying 64 alpha overlay and saving result... |
| [create-a-point-object-at-100-200-to-position-overlay-on-a-tiff-image.cs](./create-a-point-object-at-100-200-to-position-overlay-on-a-tiff-image.cs) | `Graphics`, `SolidBrush`, `TiffImage` | create a point object at 100 200 to position overlay on a tiff image |
| [define-a-custom-overlay-rectangle-of-200x150-pixels-and-blend-it-onto-a-gif-background.cs](./define-a-custom-overlay-rectangle-of-200x150-pixels-and-blend-it-onto-a-gif-background.cs) | `GifImage`, `GifOptions`, `Graphics` | define a custom overlay rectangle of 200x150 pixels and blend it onto a gif back... |
| [apply-alpha-blending-with-full-opacity-255-to-a-png-overlay-and-verify-no-transparency-loss.cs](./apply-alpha-blending-with-full-opacity-255-to-a-png-overlay-and-verify-no-transparency-loss.cs) | `PngOptions`, `RasterImage` | apply alpha blending with full opacity 255 to a png overlay and verify no transp... |
| [use-magic-wand-tool-with-threshold-30-to-select-red-region-in-a-jpeg-image.cs](./use-magic-wand-tool-with-threshold-30-to-select-red-region-in-a-jpeg-image.cs) | `RasterImage` | use magic wand tool with threshold 30 to select red region in a jpeg image |
| [combine-two-magic-wand-selections-using-union-operation-and-save-the-combined-mask-as-png.cs](./combine-two-magic-wand-selections-using-union-operation-and-save-the-combined-mask-as-png.cs) | `PngOptions`, `RasterImage` | combine two magic wand selections using union operation and save the combined ma... |
| [subtract-a-green-magic-wand-selection-from-a-blue-selection-and-export-the-result-to-bmp.cs](./subtract-a-green-magic-wand-selection-from-a-blue-selection-and-export-the-result-to-bmp.cs) | `BmpOptions`, `RasterImage` | subtract a green magic wand selection from a blue selection and export the resul... |
| [invert-a-magic-wand-selection-on-a-tiff-image-and-fill-the-inverted-area-with-white.cs](./invert-a-magic-wand-selection-on-a-tiff-image-and-fill-the-inverted-area-with-white.cs) | `RasterImage`, `TiffOptions` | invert a magic wand selection on a tiff image and fill the inverted area with wh... |
| [apply-feathering-of-radius-5-pixels-to-a-magic-wand-selection-before-saving-as-png.cs](./apply-feathering-of-radius-5-pixels-to-a-magic-wand-selection-before-saving-as-png.cs) | `PngOptions`, `RasterImage` | apply feathering of radius 5 pixels to a magic wand selection before saving as p... |
| [remove-watermark-from-a-jpeg-using-content-aware-fill-algorithm-with-three-removal-attempts.cs](./remove-watermark-from-a-jpeg-using-content-aware-fill-algorithm-with-three-removal-attempts.cs) | `ContentAwareFillWatermarkOptions`, `RasterImage` | remove watermark from a jpeg using content aware fill algorithm with three remov... |
| [remove-watermark-from-a-png-using-telea-algorithm-and-set-removal-attempts-to-five.cs](./remove-watermark-from-a-png-using-telea-algorithm-and-set-removal-attempts-to-five.cs) | `PngImage` | remove watermark from a png using telea algorithm and set removal attempts to fi... |
| [define-watermark-region-coordinates-50-50-200-100-and-apply-removal-filter-on-a-bmp-image.cs](./define-watermark-region-coordinates-50-50-200-100-and-apply-removal-filter-on-a-bmp-image.cs) | `BmpImage`, `TeleaWatermarkOptions` | define watermark region coordinates 50 50 200 100 and apply removal filter on a ... |
| [batch-remove-watermarks-from-a-folder-of-tiff-files-using-content-aware-fill-and-save-results.cs](./batch-remove-watermarks-from-a-folder-of-tiff-files-using-content-aware-fill-and-save-results.cs) | `RasterImage` | batch remove watermarks from a folder of tiff files using content aware fill and... |
| [load-an-image-from-a-memory-stream-apply-alpha-blending-and-write-output-to-another-stream.cs](./load-an-image-from-a-memory-stream-apply-alpha-blending-and-write-output-to-another-stream.cs) | `PngOptions`, `RasterImage` | load an image from a memory stream apply alpha blending and write output to anot... |
| [resize-a-jpeg-to-800x600-before-applying-magic-wand-selection-with-threshold-40.cs](./resize-a-jpeg-to-800x600-before-applying-magic-wand-selection-with-threshold-40.cs) | `JpegImage` | resize a jpeg to 800x600 before applying magic wand selection with threshold 40 |
| [rotate-a-png-by-90-degrees-then-blend-a-semi-transparent-overlay-and-save-as-gif.cs](./rotate-a-png-by-90-degrees-then-blend-a-semi-transparent-overlay-and-save-as-gif.cs) | `GifOptions`, `PngOptions`, `RasterImage` | rotate a png by 90 degrees then blend a semi transparent overlay and save as gif |
| [crop-a-bmp-to-central-400x400-area-apply-feathered-magic-wand-selection-and-export-to-png.cs](./crop-a-bmp-to-central-400x400-area-apply-feathered-magic-wand-selection-and-export-to-png.cs) | `PngOptions`, `RasterImage` | crop a bmp to central 400x400 area apply feathered magic wand selection and expo... |
| [process-each-page-of-a-multi-page-tiff-applying-alpha-blending-with-200-opacity-and-save.cs](./process-each-page-of-a-multi-page-tiff-applying-alpha-blending-with-200-opacity-and-save.cs) | `TiffImage` | process each page of a multi page tiff applying alpha blending with 200 opacity ... |
| [convert-a-pdf-page-to-image-apply-watermark-removal-and-save-the-cleaned-image-as-jpeg.cs](./convert-a-pdf-page-to-image-apply-watermark-removal-and-save-the-cleaned-image-as-jpeg.cs) | `JpegOptions`, `RasterImage` | convert a pdf page to image apply watermark removal and save the cleaned image a... |
| [load-a-gif-animation-apply-magic-wand-selection-on-first-frame-and-reassemble-animation.cs](./load-a-gif-animation-apply-magic-wand-selection-on-first-frame-and-reassemble-animation.cs) | `GifImage`, `GifOptions` | load a gif animation apply magic wand selection on first frame and reassemble an... |
| [apply-alpha-blending-with-0-opacity-to-verify-that-background-image-remains-unchanged-after-operation.cs](./apply-alpha-blending-with-0-opacity-to-verify-that-background-image-remains-unchanged-after-operation.cs) | `PngOptions`, `RasterImage` | apply alpha blending with 0 opacity to verify that background image remains unch... |
| [set-overlay-alpha-to-192-and-blend-a-png-logo-onto-a-jpeg-banner-at-bottom-right-corner.cs](./set-overlay-alpha-to-192-and-blend-a-png-logo-onto-a-jpeg-banner-at-bottom-right-corner.cs) | `JpegOptions`, `RasterImage` | set overlay alpha to 192 and blend a png logo onto a jpeg banner at bottom right... |
| [use-magic-wand-threshold-70-to-select-sky-region-in-a-landscape-png-and-invert-selection.cs](./use-magic-wand-threshold-70-to-select-sky-region-in-a-landscape-png-and-invert-selection.cs) | `PngOptions`, `RasterImage` | use magic wand threshold 70 to select sky region in a landscape png and invert s... |
| [combine-three-magic-wand-selections-using-union-then-apply-feathering-of-radius-8-before-saving.cs](./combine-three-magic-wand-selections-using-union-then-apply-feathering-of-radius-8-before-saving.cs) | `RasterImage` | combine three magic wand selections using union then apply feathering of radius ... |
| [subtract-a-text-watermark-selection-from-a-scanned-document-image-and-export-as-high-resolution-tiff.cs](./subtract-a-text-watermark-selection-from-a-scanned-document-image-and-export-as-high-resolution-tiff.cs) | `RasterImage`, `TiffOptions` | subtract a text watermark selection from a scanned document image and export as ... |
| [apply-content-aware-fill-removal-on-a-jpeg-with-two-attempts-then-compare-result-with-telea-algorithm.cs](./apply-content-aware-fill-removal-on-a-jpeg-with-two-attempts-then-compare-result-with-telea-algorithm.cs) | `ContentAwareFillWatermarkOptions`, `JpegImage`, `TeleaWatermarkOptions` | apply content aware fill removal on a jpeg with two attempts then compare result... |
| [load-images-from-a-zip-archive-apply-alpha-blending-to-each-and-write-outputs-to-another-zip.cs](./load-images-from-a-zip-archive-apply-alpha-blending-to-each-and-write-outputs-to-another-zip.cs) | `PngOptions` | load images from a zip archive apply alpha blending to each and write outputs to... |
| [create-a-custom-selection-by-combining-magic-wand-union-and-subtraction-then-fill-with-solid-color.cs](./create-a-custom-selection-by-combining-magic-wand-union-and-subtraction-then-fill-with-solid-color.cs) | `Graphics`, `PngOptions`, `RasterImage` | Create a custom selection by combining Magic Wand union and subtraction, then fi... |
| *...and 108 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.4.0/image-and-photo-filters) |

## Category Statistics
- Total examples: 138
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngFrame`
- `ApngImage`
- `ApngOptions`
- `AutoMaskingGraphCutOptions`
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
- `RasterImage`
- `SharpenFilterOptions`
- `SolidBrush`
- `TeleaWatermarkOptions`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-05-05 | Run: `20260505_041608` | Examples: 138
<!-- AUTOGENERATED:END -->