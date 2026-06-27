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

- `using System;` (231/477 files)
- `using System.IO;` (231/477 files)
- `using Aspose.Imaging;` (223/477 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (165/477 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (135/477 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (53/477 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.Convolution;` (42/477 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (30/477 files) ← category-specific
- `using Aspose.Imaging.Sources;` (18/477 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (7/477 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (7/477 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (4/477 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (3/477 files) ← category-specific
- `using System.Diagnostics;` (3/477 files)
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (2/477 files) ← category-specific
- `using Aspose.Imaging.ImageFilters;` (2/477 files) ← category-specific
- `using System.Drawing;` (2/477 files)
- `using System.Threading.Tasks;` (2/477 files)
- `using Aspose.Imaging.CoreExceptions.ImageFormats;` (2/477 files) ← category-specific
- `using System.Net.Http;` (2/477 files)
- `using System.Linq;` (1/477 files)
- `using Aspose.Imaging.CoreExceptions;` (1/477 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (1/477 files) ← category-specific
- `using System.Threading;` (1/477 files)
- `using Aspose.Imaging.Multithreading;` (1/477 files) ← category-specific
- `using Aspose.Imaging.ProgressManagement;` (1/477 files) ← category-specific
- `using System.Xml;` (1/477 files)
- `using Aspose.Imaging.FileFormats.Pdf;` (1/477 files) ← category-specific
- `using System.Collections.Generic;` (1/477 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs](./load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs) | `RasterImage` | load a png image from the templates folder and apply a predefined 5x5 blur box f... |
| [create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs](./create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs) | `JpegImage`, `RasterImage` | create a custom 3x3 convolution matrix and apply it to a jpeg image loaded from ... |
| [validate-that-a-custom-7x7-kernel-has-odd-dimensions-before-applying-it-to-a-png-file.cs](./validate-that-a-custom-7x7-kernel-has-odd-dimensions-before-applying-it-to-a-png-file.cs) | `ConvolutionFilterOptions`, `RasterImage` | validate that a custom 7x7 kernel has odd dimensions before applying it to a png... |
| [normalize-a-custom-kernel-so-its-coefficients-sum-to-one-and-apply-to-a-jpeg-image.cs](./normalize-a-custom-kernel-so-its-coefficients-sum-to-one-and-apply-to-a-jpeg-image.cs) | `JpegOptions`, `RasterImage` | normalize a custom kernel so its coefficients sum to one and apply to a jpeg ima... |
| [adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs](./adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs) | `GaussianBlurFilterOptions`, `RasterImage` | adjust kernel coefficients to increase brightness while applying a 5x5 blur to a... |
| [28794-apply-a-zero-sum-edge-detection-kernel-to-a-png-image-and-verify-black-background-with-highlighted-edges.cs](./28794-apply-a-zero-sum-edge-detection-kernel-to-a-png-image-and-verify-black-background-with-highlighted-edges.cs) | `PngOptions`, `RasterImage` | apply a zero sum edge detection kernel to a png image and verify black backgroun... |
| [generate-an-emboss-effect-using-a-3x3-kernel-on-a-jpeg-image-and-export-to-tiff-format.cs](./generate-an-emboss-effect-using-a-3x3-kernel-on-a-jpeg-image-and-export-to-tiff-format.cs) | `ConvolutionFilterOptions`, `RasterImage`, `TiffOptions` | generate an emboss effect using a 3x3 kernel on a jpeg image and export to tiff ... |
| [use-a-custom-5x5-kernel-to-compute-average-pixel-values-and-apply-as-a-smoothing-filter-on-png.cs](./use-a-custom-5x5-kernel-to-compute-average-pixel-values-and-apply-as-a-smoothing-filter-on-png.cs) | `PngOptions`, `RasterImage` | use a custom 5x5 kernel to compute average pixel values and apply as a smoothing... |
| [apply-a-gaussian-blur-filter-with-sigma-1-5-to-a-bmp-image-and-save-as-png.cs](./apply-a-gaussian-blur-filter-with-sigma-1-5-to-a-bmp-image-and-save-as-png.cs) | `GaussianBlurFilterOptions`, `RasterImage` | apply a gaussian blur filter with sigma 1 5 to a bmp image and save as png |
| [apply-a-motion-blur-filter-with-a-45-degree-angle-on-a-tiff-image-and-export-to-jpeg.cs](./apply-a-motion-blur-filter-with-a-45-degree-angle-on-a-tiff-image-and-export-to-jpeg.cs) | `JpegOptions`, `MotionWienerFilterOptions`, `TiffImage` | apply a motion blur filter with a 45 degree angle on a tiff image and export to ... |
| [apply-a-motion-blur-filter-with-length-10-pixels-to-a-bmp-image-and-save-as-jpeg.cs](./apply-a-motion-blur-filter-with-length-10-pixels-to-a-bmp-image-and-save-as-jpeg.cs) | `MotionWienerFilterOptions`, `RasterImage` | apply a motion blur filter with length 10 pixels to a bmp image and save as jpeg |
| [apply-a-motion-blur-filter-with-horizontal-direction-to-a-tiff-image-and-export-to-png.cs](./apply-a-motion-blur-filter-with-horizontal-direction-to-a-tiff-image-and-export-to-png.cs) | `MotionWienerFilterOptions`, `PngOptions`, `TiffImage` | apply a motion blur filter with horizontal direction to a tiff image and export ... |
| [apply-a-predefined-blur-box-filter-of-size-3x3-to-an-svg-image-and-save-as-png.cs](./apply-a-predefined-blur-box-filter-of-size-3x3-to-an-svg-image-and-save-as-png.cs) | `ConvolutionFilterOptions`, `PngOptions`, `RasterImage` | apply a predefined blur box filter of size 3x3 to an svg image and save as png |
| [apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs](./apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs) | `GaussianBlurFilterOptions`, `JpegOptions`, `RasterImage` | apply a predefined blur box filter to all png files in a folder and output jpegs |
| [adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs](./adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs) | `BmpOptions`, `RasterImage` | adjust the size of a blur box kernel from 3x3 to 7x7 to increase smoothing on bm... |
| [normalize-a-blur-kernel-so-its-total-sum-equals-one-and-apply-to-a-bmp-image-for-uniform-blur.cs](./normalize-a-blur-kernel-so-its-total-sum-equals-one-and-apply-to-a-bmp-image-for-uniform-blur.cs) | `BmpOptions`, `ConvolutionFilterOptions`, `RasterImage` | normalize a blur kernel so its total sum equals one and apply to a bmp image for... |
| [normalize-a-custom-7x7-kernel-for-neutral-brightness-and-apply-to-a-jpeg-image-for-soft-focus.cs](./normalize-a-custom-7x7-kernel-for-neutral-brightness-and-apply-to-a-jpeg-image-for-soft-focus.cs) | `ConvolutionFilterOptions`, `JpegOptions`, `RasterImage` | normalize a custom 7x7 kernel for neutral brightness and apply to a jpeg image f... |
| [normalize-a-3x3-sharpening-kernel-to-preserve-overall-image-brightness-before-applying-to-jpeg.cs](./normalize-a-3x3-sharpening-kernel-to-preserve-overall-image-brightness-before-applying-to-jpeg.cs) | `JpegOptions`, `RasterImage` | normalize a 3x3 sharpening kernel to preserve overall image brightness before ap... |
| [create-a-deconvolution-filter-to-restore-a-previously-blurred-jpeg-image-and-save-as-png.cs](./create-a-deconvolution-filter-to-restore-a-previously-blurred-jpeg-image-and-save-as-png.cs) | `GaussWienerFilterOptions`, `PngOptions`, `RasterImage` | create a deconvolution filter to restore a previously blurred jpeg image and sav... |
| [use-the-deconvolution-filter-to-reverse-a-motion-blur-effect-on-a-png-image-and-save-as-tiff.cs](./use-the-deconvolution-filter-to-reverse-a-motion-blur-effect-on-a-png-image-and-save-as-tiff.cs) | `MotionWienerFilterOptions`, `RasterImage`, `TiffOptions` | use the deconvolution filter to reverse a motion blur effect on a png image and ... |
| [validate-that-the-sum-of-coefficients-in-a-custom-kernel-equals-one-to-avoid-brightness-shift.cs](./validate-that-the-sum-of-coefficients-in-a-custom-kernel-equals-one-to-avoid-brightness-shift.cs) | `RasterImage` | validate that the sum of coefficients in a custom kernel equals one to avoid bri... |
| [28810-validate-that-a-custom-kernel-s-dimensions-are-odd-before-applying-a-deconvolution-filter-to-png.cs](./28810-validate-that-a-custom-kernel-s-dimensions-are-odd-before-applying-a-deconvolution-filter-to-png.cs) | `PngOptions`, `RasterImage` | validate that a custom kernel s dimensions are odd before applying a deconvoluti... |
| [validate-that-a-custom-sharpening-kernel-s-sum-exceeds-one-to-achieve-brightness-increase-on-png-image.cs](./validate-that-a-custom-sharpening-kernel-s-sum-exceeds-one-to-achieve-brightness-increase-on-png-image.cs) | `PngOptions`, `RasterImage` | validate that a custom sharpening kernel s sum exceeds one to achieve brightness... |
| [chain-a-sharpen-filter-followed-by-an-emboss-filter-on-a-svg-image-and-save-as-bmp.cs](./chain-a-sharpen-filter-followed-by-an-emboss-filter-on-a-svg-image-and-save-as-bmp.cs) | `BmpOptions`, `ConvolutionFilterOptions`, `PngOptions` | chain a sharpen filter followed by an emboss filter on a svg image and save as b... |
| [chain-a-gaussian-blur-filter-followed-by-a-sharpen-filter-on-a-tiff-image-and-export-to-png.cs](./chain-a-gaussian-blur-filter-followed-by-a-sharpen-filter-on-a-tiff-image-and-export-to-png.cs) | `GaussianBlurFilterOptions`, `PngOptions`, `SharpenFilterOptions` | chain a gaussian blur filter followed by a sharpen filter on a tiff image and ex... |
| [chain-three-filters-blur-edge-detection-and-sharpen-on-a-png-image-and-save-as-jpeg.cs](./chain-three-filters-blur-edge-detection-and-sharpen-on-a-png-image-and-save-as-jpeg.cs) | `ConvolutionFilterOptions`, `GaussianBlurFilterOptions`, `JpegOptions` | chain three filters blur edge detection and sharpen on a png image and save as j... |
| [chain-a-blur-box-filter-then-an-emboss-filter-then-a-sharpen-filter-on-a-jpeg-image-for-complex-styling.cs](./chain-a-blur-box-filter-then-an-emboss-filter-then-a-sharpen-filter-on-a-jpeg-image-for-complex-styling.cs) | `ConvolutionFilterOptions`, `RasterImage`, `SharpenFilterOptions` | chain a blur box filter then an emboss filter then a sharpen filter on a jpeg im... |
| [batch-process-a-collection-of-bmp-images-with-a-custom-edge-detection-kernel-and-output-jpegs.cs](./batch-process-a-collection-of-bmp-images-with-a-custom-edge-detection-kernel-and-output-jpegs.cs) | `JpegOptions`, `RasterImage` | batch process a collection of bmp images with a custom edge detection kernel and... |
| [batch-apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs](./batch-apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs) | `GaussianBlurFilterOptions`, `JpegOptions`, `RasterImage` | batch apply a predefined blur box filter to all png files in a folder and output... |
| [batch-apply-a-sharpen-filter-to-all-png-files-in-a-directory-and-overwrite-originals-safely.cs](./batch-apply-a-sharpen-filter-to-all-png-files-in-a-directory-and-overwrite-originals-safely.cs) | `RasterImage`, `SharpenFilterOptions` | batch apply a sharpen filter to all png files in a directory and overwrite origi... |
| *...and 447 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.6.0/kernel-filters) |

## Category Statistics
- Total examples: 477
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

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
- `ParallelOptions`
- `PdfOptions`
- `PngImage`
- `PngOptions`
- `RasterImage`
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
- Applying a **kernel filter C#** to sharpen medical imaging scans, allowing radiologists to highlight subtle tissue details without altering the original DICOM data.  
- Implementing a custom **convolution filter dotnet** to remove periodic noise from satellite photographs, improving the accuracy of downstream geographic information system (GIS) analyses.  
- Using **image kernel processing** to create artistic edge‑detection effects in real‑time photo editing apps, giving users a stylized preview before committing changes.  
- Enhancing OCR preprocessing pipelines by applying a blur kernel filter in C# to reduce high‑frequency artifacts, which boosts text recognition rates on scanned documents.  
- Developing a batch‑processing tool that applies a Gaussian kernel filter to product images, ensuring consistent background smoothing for e‑commerce catalogs.

## Related Categories  
The Kernel Filters examples complement the **Color Adjustments** category, where you can combine tone‑mapping with convolution kernels for richer visual effects. They also intersect with the **Image Transformations** group, enabling you to apply kernel‑based sharpening after geometric operations such as rotation or scaling. Additionally, the **File Format Conversions** section often benefits from kernel filtering to preserve quality when converting between raster formats, making it easy to integrate these techniques into broader image‑processing workflows.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-27 | Run: `20260627_032626` | Examples: 477
<!-- AUTOGENERATED:END -->