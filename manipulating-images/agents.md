---
name: manipulating-images
description: C# examples for Manipulating Images using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Manipulating Images

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Manipulating Images** category.
This folder contains standalone C# examples for Manipulating Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System.IO;` (644/644 files)
- `using System;` (643/644 files)
- `using Aspose.Imaging;` (619/644 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (534/644 files) ← category-specific
- `using Aspose.Imaging.Sources;` (161/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (158/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (104/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (65/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (60/644 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (59/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (54/644 files) ← category-specific
- `using Aspose.Imaging.Masking;` (52/644 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (52/644 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (50/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cdr;` (46/644 files) ← category-specific
- `using System.Collections.Generic;` (30/644 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (22/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (19/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (19/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (19/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (16/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (16/644 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (13/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats;` (9/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (7/644 files) ← category-specific
- `using System.Linq;` (5/644 files)
- `using Aspose.Imaging.Shapes;` (5/644 files) ← category-specific
- `using System.Drawing;` (5/644 files)
- `using Aspose.Imaging.FileFormats.Wmf;` (4/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (3/644 files) ← category-specific
- `using Aspose.Imaging.CustomFontHandler;` (3/644 files) ← category-specific
- `using System.Diagnostics;` (3/644 files)
- `using Aspose.Imaging.FileFormats.Emf.Graphics;` (2/644 files) ← category-specific
- `using Aspose.Imaging.ProgressManagement;` (2/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Emf.Records;` (2/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Emf.Objects;` (2/644 files) ← category-specific
- `using System.Net.Sockets;` (2/644 files)
- `using Aspose.Imaging.CoreExceptions;` (2/644 files) ← category-specific
- `using Aspose.Imaging.MagicWand;` (1/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cmx;` (1/644 files) ← category-specific
- `using System.Globalization;` (1/644 files)
- `using Aspose.Imaging.FileFormats.Dng;` (1/644 files) ← category-specific
- `using Aspose.Imaging.Dithering;` (1/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Djvu;` (1/644 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Dicom;` (1/644 files) ← category-specific
- `using System.Text;` (1/644 files)
- `using Aspose.Imaging.ImageLoadOptions;` (1/644 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs](./load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Load a PNG image, apply auto‑masking Graph Cut with default strokes, and save as... |
| [create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs](./create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Create AutoMaskingGraphCutOptions with custom feathering radius, apply to a PNG,... |
| [define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs](./define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs) | `MaskingOptions`, `PngOptions`, `RasterImage` | Define a Point array for manual masking, use it on a PNG, and save the processed... |
| [reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs](./reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Reuse previously configured AutoMaskingGraphCutOptions to refine background remo... |
| [supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs](./supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs) | `PngOptions`, `RasterImage` | Supply a DetectedObjectList converted to AssumedObjectData for improved Graph Cu... |
| [load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs](./load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | Load an SVG vector image, remove its background using default analysis, and save... |
| [remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs](./remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs) | `EmfImage`, `MetaImage` | Remove background from an EMF file by specifying a background color that matches... |
| [define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs](./define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Define a rectangular area for selective background removal in a CDR vector image... |
| [after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs](./after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs) | `PngOptions`, `VectorRasterizationOptions` | After removing background from a vector image, rasterize it to PNG using PngOpti... |
| [batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs](./batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Batch process a folder of PNG files, applying auto‑masking Graph Cut with user‑d... |
| [iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs](./iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | Iterate over a collection of SVG files, remove backgrounds, rasterize to PNG, an... |
| [apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs](./apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs) | `MedianFilterOptions`, `RasterImage` | Apply median filter to a PNG image after background removal to reduce residual n... |
| [combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs](./combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs) | `AutoMaskingGraphCutOptions`, `BilateralSmoothingFilterOptions`, `GaussWienerFilterOptions` | Combine Gauss‑Wiener deblurring with bilateral smoothing on a raster image to en... |
| [use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs](./use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs) | `MotionWienerFilterOptions`, `PngOptions`, `RasterImage` | Use Motion‑Wiener filter on a PNG that suffered motion blur, then apply sharpeni... |
| [align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs](./align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs) |  | Align horizontal and vertical DPI of a raster image before applying any correcti... |
| [create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs](./create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs) | `BilateralSmoothingFilterOptions`, `RasterImage` | Create BilateralSmoothingFilterOptions with size parameter set to 5, apply to PN... |
| [apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs](./apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs) | `MedianFilterOptions`, `RasterImage`, `SharpenFilterOptions` | Apply SharpenFilterOptions after median filtering to accentuate edges in a clean... |
| [load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs](./load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs) | `EmfImage`, `EmfRasterizationOptions`, `PngOptions` | Load multiple EMF files, remove backgrounds using specified color, rasterize eac... |
| [implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to-given-folder.cs](./implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to-given-folder.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Implement a console application that accepts image path arguments, applies auto‑... |
| [configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of-pngs.cs](./configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of-pngs.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Configure AutoMaskingGraphCutOptions to reuse strokes across iterations, improvi... |
| [use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs](./use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Use DetectedObjectList from a prior analysis to seed Graph Cut algorithm for mor... |
| [apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs](./apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs) | `MedianFilterOptions`, `RasterImage` | Apply median filter with kernel size 3 to a PNG after background removal to smoo... |
| [run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during-conversion.cs](./run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during-conversion.cs) | `GaussWienerFilterOptions`, `RasterImage` | Run Gauss‑Wiener filter with default parameters on a rasterized vector image to ... |
| [process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs](./process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Process a batch of CDR files, remove backgrounds using area selection, rasterize... |
| [apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs](./apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs) | `MotionWienerFilterOptions`, `RasterImage` | Apply Motion‑Wiener filter with motion vector set to horizontal direction on a P... |
| [combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and-edge-clarity.cs](./combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and-edge-clarity.cs) | `PngOptions` | Combine bilateral smoothing and sharpening filters sequentially on a raster imag... |
| [align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs](./align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | Align resolutions of a loaded SVG before rasterization to ensure consistent DPI ... |
| [create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs](./create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs) | `PngOptions` | Create a reusable method that loads a raster image, applies auto‑masking, median... |
| [develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background-existed.cs](./develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background-existed.cs) | `MaskingOptions`, `PngImage`, `PngOptions` | Develop a unit test that verifies background removal on a PNG yields transparent... |
| [measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes-on-identical-images.cs](./measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes-on-identical-images.cs) | `AutoMaskingGraphCutOptions`, `GraphCutMaskingOptions`, `PngOptions` | Measure performance difference between Graph Cut auto‑masking with default strok... |
| *...and 377 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.3.0/manipulating-images) |

## Category Statistics
- Total examples: 644
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngFrame`
- `ApngImage`
- `ApngOptions`
- `AutoMaskingGraphCutOptions`
- `BackgroundRemovalFilterOptions`
- `BilateralSmoothingFilterOptions`
- `BmpImage`
- `BmpOptions`
- `CdrImage`
- `CdrLoadOptions`
- `CdrRasterizationOptions`
- `EmfImage`
- `EmfOptions`
- `EmfRasterizationOptions`
- `GaussWienerFilterOptions`
- `GaussianBlurFilterOptions`
- `GifImage`
- `GifOptions`
- `GraphCutMaskingOptions`
- `Graphics`
- `JpegImage`
- `JpegOptions`
- `LinearGradientBrush`
- `LoadOptions`
- `MaskingOptions`
- `MedianFilterOptions`
- `MetaImage`
- `MotionWienerFilterOptions`
- `MultiPageOptions`
- `PdfCoreOptions`
- `PdfOptions`
- `PngImage`
- `PngOptions`
- `PsdOptions`
- `RasterCachedImage`
- `RasterImage`
- `SharpenFilterOptions`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `VectorImage`
- `VectorRasterizationOptions`
- `WebPImage`
- `WmfImage`
- `WmfRasterizationOptions`

## Failed Tasks

All tasks passed ✅

## Version History

| Version | Examples Added | Total | Date |
|---------|---------------|-------|------|
| V1 | 237 | 644 | 2026-04-21 |

<!-- AUTOGENERATED:START -->
Updated: 2026-04-21 | Run: `20260421_065549` | Examples: 644
<!-- AUTOGENERATED:END -->