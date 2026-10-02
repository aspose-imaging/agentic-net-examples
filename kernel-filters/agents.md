---
name: kernel-filters
description: C# examples for Kernel Filters using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Kernel Filters

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Kernel Filters** category.
This folder contains standalone C# examples for Kernel Filters operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (231/465 files)
- `using System.IO;` (231/465 files)
- `using Aspose.Imaging.ImageOptions;` (191/465 files) ← category-specific
- `using Aspose.Imaging;` (176/465 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (80/465 files) ← category-specific
- `using Aspose.Imaging.Sources;` (76/465 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (69/465 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.Convolution;` (46/465 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (34/465 files) ← category-specific
- `using System.Collections.Generic;` (11/465 files)
- `using System.Linq;` (8/465 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (7/465 files) ← category-specific
- `using System.Xml.Linq;` (7/465 files)
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (5/465 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (4/465 files) ← category-specific
- `using System.Threading.Tasks;` (3/465 files)
- `using System.Diagnostics;` (2/465 files)
- `using System.Threading;` (2/465 files)
- `using System.Net.Http;` (2/465 files)
- `using System.Xml;` (2/465 files)
- `using Aspose.Imaging.FileFormats.Bmp;` (1/465 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (1/465 files) ← category-specific
- `using System.Text.Json;` (1/465 files)
- `using System.Text.RegularExpressions;` (1/465 files)
- `using System.Text;` (1/465 files)
- `using System.Xml.Schema;` (1/465 files)
- `using Aspose.Imaging.Brushes;` (1/465 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (1/465 files) ← category-specific
- `using Aspose.Imaging.MagicWand;` (1/465 files) ← category-specific
- `using Aspose.Imaging.MagicWand.ImageMasks;` (1/465 files) ← category-specific
- `using System.Globalization;` (1/465 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs](./load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs) | `ConvolutionFilterOptions`, `PngOptions`, `RasterImage` | Load a PNG image from the templates folder and apply a predefined 5x5 blur box f... |
| [create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs](./create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs) | `JpegOptions`, `RasterImage` | Create a custom 3x3 convolution matrix and apply it to a JPEG image loaded from ... |
| [validate-that-a-custom-7x7-kernel-has-odd-dimensions-before-applying-it-to-a-png-file.cs](./validate-that-a-custom-7x7-kernel-has-odd-dimensions-before-applying-it-to-a-png-file.cs) | `PngOptions`, `RasterImage` | Validate that a custom 7x7 kernel has odd dimensions before applying it to a PNG... |
| [normalize-a-custom-kernel-so-its-coefficients-sum-to-one-and-apply-to-a-jpeg-image.cs](./normalize-a-custom-kernel-so-its-coefficients-sum-to-one-and-apply-to-a-jpeg-image.cs) | `JpegOptions`, `RasterImage` | Normalize a custom kernel so its coefficients sum to one and apply to a JPEG ima... |
| [adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs](./adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs) | `BmpOptions`, `ConvolutionFilterOptions`, `RasterImage` | Adjust kernel coefficients to increase brightness while applying a 5x5 blur to a... |
| [apply-a-zero-sum-edge-detection-kernel-to-a-png-image-and-verify-black-background-with-highlighted-edges.cs](./apply-a-zero-sum-edge-detection-kernel-to-a-png-image-and-verify-black-background-with-highlighted-edges.cs) | `ConvolutionFilterOptions`, `PngOptions`, `RasterImage` | Apply a zero‑sum edge detection kernel to a PNG image and verify black backgroun... |
| [generate-an-emboss-effect-using-a-3x3-kernel-on-a-jpeg-image-and-export-to-tiff-format.cs](./generate-an-emboss-effect-using-a-3x3-kernel-on-a-jpeg-image-and-export-to-tiff-format.cs) | `TiffOptions` | Generate an emboss effect using a 3x3 kernel on a JPEG image and export to TIFF ... |
| [use-a-custom-5x5-kernel-to-compute-average-pixel-values-and-apply-as-a-smoothing-filter-on-png.cs](./use-a-custom-5x5-kernel-to-compute-average-pixel-values-and-apply-as-a-smoothing-filter-on-png.cs) | `PngOptions`, `RasterImage` | Use a custom 5x5 kernel to compute average pixel values and apply as a smoothing... |
| [apply-a-gaussian-blur-filter-with-sigma-1-5-to-a-bmp-image-and-save-as-png.cs](./apply-a-gaussian-blur-filter-with-sigma-1-5-to-a-bmp-image-and-save-as-png.cs) | `PngOptions` | Apply a Gaussian blur filter with sigma 1.5 to a BMP image and save as PNG. |
| [apply-a-motion-blur-filter-with-a-45-degree-angle-on-a-tiff-image-and-export-to-jpeg.cs](./apply-a-motion-blur-filter-with-a-45-degree-angle-on-a-tiff-image-and-export-to-jpeg.cs) | `ConvolutionFilterOptions`, `JpegOptions`, `RasterImage` | Apply a motion blur filter with a 45 degree angle on a TIFF image and export to ... |
| [apply-a-motion-blur-filter-with-length-10-pixels-to-a-bmp-image-and-save-as-jpeg.cs](./apply-a-motion-blur-filter-with-length-10-pixels-to-a-bmp-image-and-save-as-jpeg.cs) | `JpegOptions`, `RasterImage` | Apply a motion blur filter with length 10 pixels to a BMP image and save as JPEG... |
| [apply-a-motion-blur-filter-with-horizontal-direction-to-a-tiff-image-and-export-to-png.cs](./apply-a-motion-blur-filter-with-horizontal-direction-to-a-tiff-image-and-export-to-png.cs) | `ConvolutionFilterOptions`, `PngOptions`, `RasterImage` | Apply a motion blur filter with horizontal direction to a TIFF image and export ... |
| [apply-a-predefined-blur-box-filter-of-size-3x3-to-an-svg-image-and-save-as-png.cs](./apply-a-predefined-blur-box-filter-of-size-3x3-to-an-svg-image-and-save-as-png.cs) | `PngOptions`, `RasterImage` | Apply a predefined blur box filter of size 3x3 to an SVG image and save as PNG. |
| [apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs](./apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs) | `JpegOptions`, `RasterImage` | Apply a predefined blur box filter to all PNG files in a folder and output JPEGs... |
| [adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs](./adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs) | `RasterImage` | Adjust the size of a blur box kernel from 3x3 to 7x7 to increase smoothing on BM... |
| [normalize-a-blur-kernel-so-its-total-sum-equals-one-and-apply-to-a-bmp-image-for-uniform-blur.cs](./normalize-a-blur-kernel-so-its-total-sum-equals-one-and-apply-to-a-bmp-image-for-uniform-blur.cs) | `BmpOptions`, `RasterImage` | Normalize a blur kernel so its total sum equals one and apply to a BMP image for... |
| [normalize-a-custom-7x7-kernel-for-neutral-brightness-and-apply-to-a-jpeg-image-for-soft-focus.cs](./normalize-a-custom-7x7-kernel-for-neutral-brightness-and-apply-to-a-jpeg-image-for-soft-focus.cs) | `ConvolutionFilterOptions`, `JpegOptions`, `RasterImage` | Normalize a custom 7x7 kernel for neutral brightness and apply to a JPEG image f... |
| [normalize-a-3x3-sharpening-kernel-to-preserve-overall-image-brightness-before-applying-to-jpeg.cs](./normalize-a-3x3-sharpening-kernel-to-preserve-overall-image-brightness-before-applying-to-jpeg.cs) | `ConvolutionFilterOptions`, `JpegOptions`, `RasterImage` | Normalize a 3x3 sharpening kernel to preserve overall image brightness before ap... |
| [create-a-deconvolution-filter-to-restore-a-previously-blurred-jpeg-image-and-save-as-png.cs](./create-a-deconvolution-filter-to-restore-a-previously-blurred-jpeg-image-and-save-as-png.cs) | `PngOptions`, `RasterImage` | Create a deconvolution filter to restore a previously blurred JPEG image and sav... |
| [use-the-deconvolution-filter-to-reverse-a-motion-blur-effect-on-a-png-image-and-save-as-tiff.cs](./use-the-deconvolution-filter-to-reverse-a-motion-blur-effect-on-a-png-image-and-save-as-tiff.cs) | `DeconvolutionFilterOptions`, `RasterImage`, `TiffOptions` | Use the deconvolution filter to reverse a motion blur effect on a PNG image and ... |
| [validate-that-the-sum-of-coefficients-in-a-custom-kernel-equals-one-to-avoid-brightness-shift.cs](./validate-that-the-sum-of-coefficients-in-a-custom-kernel-equals-one-to-avoid-brightness-shift.cs) |  | Validate that the sum of coefficients in a custom kernel equals one to avoid bri... |
| [validate-that-a-custom-kernel-s-dimensions-are-odd-before-applying-a-deconvolution-filter-to-png.cs](./validate-that-a-custom-kernel-s-dimensions-are-odd-before-applying-a-deconvolution-filter-to-png.cs) | `PngOptions`, `RasterImage` | Validate that a custom kernel's dimensions are odd before applying a deconvoluti... |
| [validate-that-a-custom-sharpening-kernel-s-sum-exceeds-one-to-achieve-brightness-increase-on-png-image.cs](./validate-that-a-custom-sharpening-kernel-s-sum-exceeds-one-to-achieve-brightness-increase-on-png-image.cs) | `PngOptions`, `RasterImage` | Validate that a custom sharpening kernel's sum exceeds one to achieve brightness... |
| [chain-a-sharpen-filter-followed-by-an-emboss-filter-on-a-svg-image-and-save-as-bmp.cs](./chain-a-sharpen-filter-followed-by-an-emboss-filter-on-a-svg-image-and-save-as-bmp.cs) | `BmpOptions`, `ConvolutionFilterOptions`, `Graphics` | Chain a sharpen filter followed by an emboss filter on a SVG image and save as B... |
| [chain-a-gaussian-blur-filter-followed-by-a-sharpen-filter-on-a-tiff-image-and-export-to-png.cs](./chain-a-gaussian-blur-filter-followed-by-a-sharpen-filter-on-a-tiff-image-and-export-to-png.cs) | `PngOptions` | Chain a Gaussian blur filter followed by a sharpen filter on a TIFF image and ex... |
| [chain-three-filters-blur-edge-detection-and-sharpen-on-a-png-image-and-save-as-jpeg.cs](./chain-three-filters-blur-edge-detection-and-sharpen-on-a-png-image-and-save-as-jpeg.cs) | `ConvolutionFilterOptions`, `GaussianBlurFilterOptions`, `JpegOptions` | Chain three filters: blur, edge detection, and sharpen on a PNG image and save a... |
| [chain-a-blur-box-filter-then-an-emboss-filter-then-a-sharpen-filter-on-a-jpeg-image-for-complex-styling.cs](./chain-a-blur-box-filter-then-an-emboss-filter-then-a-sharpen-filter-on-a-jpeg-image-for-complex-styling.cs) | `ConvolutionFilterOptions`, `JpegOptions`, `RasterImage` | Chain a blur box filter, then an emboss filter, then a sharpen filter on a JPEG ... |
| [batch-process-a-collection-of-bmp-images-with-a-custom-edge-detection-kernel-and-output-jpegs.cs](./batch-process-a-collection-of-bmp-images-with-a-custom-edge-detection-kernel-and-output-jpegs.cs) | `JpegOptions` | Batch process a collection of BMP images with a custom edge detection kernel and... |
| [batch-apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs](./batch-apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs) | `ConvolutionFilterOptions`, `JpegOptions`, `RasterImage` | Batch apply a predefined blur box filter to all PNG files in a folder and output... |
| [batch-apply-a-sharpen-filter-to-all-png-files-in-a-directory-and-overwrite-originals-safely.cs](./batch-apply-a-sharpen-filter-to-all-png-files-in-a-directory-and-overwrite-originals-safely.cs) | `PngOptions`, `RasterImage` | Batch apply a sharpen filter to all PNG files in a directory and overwrite origi... |
| *...and 435 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.9.0/kernel-filters) |

## Category Statistics
- Total examples: 465
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `AddFilter`
- `ApngFrame`
- `ApngImage`
- `ApngOptions`
- `BilateralSmoothingFilterOptions`
- `BmpOptions`
- `ConvolutionFilter`
- `ConvolutionFilterOptions`
- `DeconvolutionFilterOptions`
- `EdgeDetectionFilterOptions`
- `GaussWienerFilterOptions`
- `GaussianBlurFilterOptions`
- `Graphics`
- `Image`
- `JpegImage`
- `JpegOptions`
- `JsonSerializerOptions`
- `LazyImage`
- `LoadOptions`
- `MedianFilterOptions`
- `MotionWienerFilter`
- `MotionWienerFilterOptions`
- `MultiPageOptions`
- `MultiplyFilter`
- `ParallelOptions`
- `PdfOptions`
- `PngImage`
- `PngOptions`
- `RasterCachedImage`
- `RasterImage`
- `SampleFilter`
- `SharpenFilterOptions`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`
- `VignetteFilter`
- `WebPImage`
- `WebPOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- When you need to **rasterize an SVG to PNG and then apply a Gaussian blur** in a .NET service, the “Rasterize SVG To PNG And Apply Gaussian Blur In C#” example shows the exact sequence of loading the SVG, converting it to a raster image, applying `GaussianBlurFilterOptions`, and saving the result.  
- If your application must **blur an ICO image and output it as a PNG**, the “Apply a Blur Filter to an ICO Image and Write the Processed Output to a New File” snippet demonstrates loading the ICO, casting to `RasterImage`, applying a Gaussian blur kernel, and writing the PNG with `PngOptions`.  
- For restoring detail in a blurred Photoshop file, the **deconvolution filter on a PSD image using Aspose.Imaging** example illustrates how to load a PSD, cast to `RasterImage`, apply `DeconvolutionFilterOptions`, and save the corrected file.  
- When preprocessing a multi‑page TIFF for OCR, the “Apply a Gaussian Blur Filter to a TIFF Image and Save the Resulting File” code provides a ready‑to‑use pattern for loading a TIFF, applying `GaussianBlurFilterOptions` via the kernel filter API, and persisting the blurred image.  
- To add a motion‑blur effect to an OTG graphic before converting it to PNG, the “Apply a Motion Blur Effect to an OTG Image and Persist the Processed Output to a File” sample shows how to use `MotionBlurFilterOptions` as a kernel filter and then save the transformed image with `PngOptions`.

## Related Categories
Kernel Filters often complement format‑conversion tasks, so you’ll find the **[Convert SVG To Raster Images](../convert-svg-to-raster-images/)** category useful when you need to handle SVG inputs before applying any kernel‑based processing.  
If you’re looking to combine blur or sharpening with color adjustments, the **[Image And Photo Filters](../image-and-photo-filters/)** examples demonstrate how to chain multiple filter types together.  
For broader image manipulation workflows—such as resizing, cropping, or format changes after a kernel filter—check out the **[Manipulating Images](../manipulating-images/)** category, which provides a comprehensive set of operations that work seamlessly with the kernel filter examples shown here.

<!-- AUTOGENERATED:START -->
Updated: 2026-10-02 | Run: `20261002_065542` | Examples: 465
<!-- AUTOGENERATED:END -->