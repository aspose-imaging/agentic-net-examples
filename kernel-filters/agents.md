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

- `using System;` (231/464 files)
- `using System.IO;` (231/464 files)
- `using Aspose.Imaging;` (210/464 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (139/464 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (138/464 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (47/464 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.Convolution;` (44/464 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (27/464 files) ← category-specific
- `using Aspose.Imaging.Sources;` (18/464 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (6/464 files) ← category-specific
- `using System.Linq;` (5/464 files)
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (4/464 files) ← category-specific
- `using System.Diagnostics;` (4/464 files)
- `using System.Collections.Generic;` (4/464 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (3/464 files) ← category-specific
- `using System.Threading.Tasks;` (3/464 files)
- `using System.Drawing;` (3/464 files)
- `using Aspose.Imaging.CoreExceptions;` (2/464 files) ← category-specific
- `using System.Threading;` (2/464 files)
- `using Aspose.Imaging.FileFormats.Apng;` (2/464 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (1/464 files) ← category-specific
- `using Aspose.Imaging.ImageFilters;` (1/464 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (1/464 files) ← category-specific
- `using Aspose.Imaging.Multithreading;` (1/464 files) ← category-specific
- `using System.Text.Json;` (1/464 files)
- `using System.Text.RegularExpressions;` (1/464 files)
- `using System.Net.Http;` (1/464 files)
- `using System.Xml;` (1/464 files)
- `using System.Xml.Schema;` (1/464 files)
- `using Aspose.Imaging.Brushes;` (1/464 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs](./load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs) | `GaussianBlurFilterOptions`, `RasterImage` | Load a PNG image from the templates folder and apply a predefined 5x5 blur box f... |
| [create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs](./create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs) | `ConvolutionFilterOptions`, `JpegOptions`, `RasterImage` | Create a custom 3x3 convolution matrix and apply it to a JPEG image loaded from ... |
| [validate-that-a-custom-7x7-kernel-has-odd-dimensions-before-applying-it-to-a-png-file.cs](./validate-that-a-custom-7x7-kernel-has-odd-dimensions-before-applying-it-to-a-png-file.cs) | `PngOptions` | Validate that a custom 7x7 kernel has odd dimensions before applying it to a PNG... |
| [normalize-a-custom-kernel-so-its-coefficients-sum-to-one-and-apply-to-a-jpeg-image.cs](./normalize-a-custom-kernel-so-its-coefficients-sum-to-one-and-apply-to-a-jpeg-image.cs) | `JpegOptions`, `RasterImage` | Normalize a custom kernel so its coefficients sum to one and apply to a JPEG ima... |
| [adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs](./adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs) | `BmpOptions`, `GaussWienerFilterOptions`, `RasterImage` | Adjust kernel coefficients to increase brightness while applying a 5x5 blur to a... |
| [apply-a-zero-sum-edge-detection-kernel-to-a-png-image-and-verify-black-background-with-highlighted-edges.cs](./apply-a-zero-sum-edge-detection-kernel-to-a-png-image-and-verify-black-background-with-highlighted-edges.cs) | `PngOptions` | Apply a zero‑sum edge detection kernel to a PNG image and verify black backgroun... |
| [generate-an-emboss-effect-using-a-3x3-kernel-on-a-jpeg-image-and-export-to-tiff-format.cs](./generate-an-emboss-effect-using-a-3x3-kernel-on-a-jpeg-image-and-export-to-tiff-format.cs) | `ConvolutionFilterOptions`, `RasterImage`, `TiffOptions` | Generate an emboss effect using a 3x3 kernel on a JPEG image and export to TIFF ... |
| [use-a-custom-5x5-kernel-to-compute-average-pixel-values-and-apply-as-a-smoothing-filter-on-png.cs](./use-a-custom-5x5-kernel-to-compute-average-pixel-values-and-apply-as-a-smoothing-filter-on-png.cs) | `ConvolutionFilterOptions`, `RasterImage` | Use a custom 5x5 kernel to compute average pixel values and apply as a smoothing... |
| [apply-a-gaussian-blur-filter-with-sigma-1-5-to-a-bmp-image-and-save-as-png.cs](./apply-a-gaussian-blur-filter-with-sigma-1-5-to-a-bmp-image-and-save-as-png.cs) | `GaussianBlurFilterOptions`, `RasterImage` | Apply a Gaussian blur filter with sigma 1.5 to a BMP image and save as PNG. |
| [apply-a-motion-blur-filter-with-a-45-degree-angle-on-a-tiff-image-and-export-to-jpeg.cs](./apply-a-motion-blur-filter-with-a-45-degree-angle-on-a-tiff-image-and-export-to-jpeg.cs) | `JpegOptions`, `MotionWienerFilterOptions`, `TiffImage` | Apply a motion blur filter with a 45 degree angle on a TIFF image and export to ... |
| [apply-a-motion-blur-filter-with-length-10-pixels-to-a-bmp-image-and-save-as-jpeg.cs](./apply-a-motion-blur-filter-with-length-10-pixels-to-a-bmp-image-and-save-as-jpeg.cs) | `JpegOptions`, `MotionWienerFilterOptions`, `RasterImage` | Apply a motion blur filter with length 10 pixels to a BMP image and save as JPEG... |
| [apply-a-motion-blur-filter-with-horizontal-direction-to-a-tiff-image-and-export-to-png.cs](./apply-a-motion-blur-filter-with-horizontal-direction-to-a-tiff-image-and-export-to-png.cs) | `MotionWienerFilterOptions`, `PngOptions`, `TiffImage` | Apply a motion blur filter with horizontal direction to a TIFF image and export ... |
| [apply-a-predefined-blur-box-filter-of-size-3x3-to-an-svg-image-and-save-as-png.cs](./apply-a-predefined-blur-box-filter-of-size-3x3-to-an-svg-image-and-save-as-png.cs) | `PngOptions`, `RasterImage`, `SvgRasterizationOptions` | Apply a predefined blur box filter of size 3x3 to an SVG image and save as PNG. |
| [apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs](./apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs) | `GaussianBlurFilterOptions`, `JpegOptions`, `RasterImage` | Apply a predefined blur box filter to all PNG files in a folder and output JPEGs... |
| [adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs](./adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs) | `BmpOptions`, `ConvolutionFilterOptions`, `RasterImage` | Adjust the size of a blur box kernel from 3x3 to 7x7 to increase smoothing on BM... |
| [normalize-a-blur-kernel-so-its-total-sum-equals-one-and-apply-to-a-bmp-image-for-uniform-blur.cs](./normalize-a-blur-kernel-so-its-total-sum-equals-one-and-apply-to-a-bmp-image-for-uniform-blur.cs) | `BmpOptions`, `RasterImage` | Normalize a blur kernel so its total sum equals one and apply to a BMP image for... |
| [normalize-a-custom-7x7-kernel-for-neutral-brightness-and-apply-to-a-jpeg-image-for-soft-focus.cs](./normalize-a-custom-7x7-kernel-for-neutral-brightness-and-apply-to-a-jpeg-image-for-soft-focus.cs) | `GaussianBlurFilterOptions`, `JpegImage`, `RasterImage` | Normalize a custom 7x7 kernel for neutral brightness and apply to a JPEG image f... |
| [normalize-a-3x3-sharpening-kernel-to-preserve-overall-image-brightness-before-applying-to-jpeg.cs](./normalize-a-3x3-sharpening-kernel-to-preserve-overall-image-brightness-before-applying-to-jpeg.cs) | `JpegOptions`, `RasterImage` | Normalize a 3x3 sharpening kernel to preserve overall image brightness before ap... |
| [create-a-deconvolution-filter-to-restore-a-previously-blurred-jpeg-image-and-save-as-png.cs](./create-a-deconvolution-filter-to-restore-a-previously-blurred-jpeg-image-and-save-as-png.cs) | `GaussWienerFilterOptions`, `PngOptions`, `RasterImage` | Create a deconvolution filter to restore a previously blurred JPEG image and sav... |
| [use-the-deconvolution-filter-to-reverse-a-motion-blur-effect-on-a-png-image-and-save-as-tiff.cs](./use-the-deconvolution-filter-to-reverse-a-motion-blur-effect-on-a-png-image-and-save-as-tiff.cs) | `MotionWienerFilterOptions`, `RasterImage`, `TiffOptions` | Use the deconvolution filter to reverse a motion blur effect on a PNG image and ... |
| [validate-that-the-sum-of-coefficients-in-a-custom-kernel-equals-one-to-avoid-brightness-shift.cs](./validate-that-the-sum-of-coefficients-in-a-custom-kernel-equals-one-to-avoid-brightness-shift.cs) | `ConvolutionFilterOptions`, `PngOptions`, `RasterImage` | Validate that the sum of coefficients in a custom kernel equals one to avoid bri... |
| [validate-that-a-custom-kernel-s-dimensions-are-odd-before-applying-a-deconvolution-filter-to-png.cs](./validate-that-a-custom-kernel-s-dimensions-are-odd-before-applying-a-deconvolution-filter-to-png.cs) | `PngOptions`, `RasterImage` | Validate that a custom kernel's dimensions are odd before applying a deconvoluti... |
| [validate-that-a-custom-sharpening-kernel-s-sum-exceeds-one-to-achieve-brightness-increase-on-png-image.cs](./validate-that-a-custom-sharpening-kernel-s-sum-exceeds-one-to-achieve-brightness-increase-on-png-image.cs) | `RasterImage`, `SharpenFilterOptions` | Validate that a custom sharpening kernel's sum exceeds one to achieve brightness... |
| [chain-a-sharpen-filter-followed-by-an-emboss-filter-on-a-svg-image-and-save-as-bmp.cs](./chain-a-sharpen-filter-followed-by-an-emboss-filter-on-a-svg-image-and-save-as-bmp.cs) | `BmpOptions`, `ConvolutionFilterOptions`, `PngOptions` | Chain a sharpen filter followed by an emboss filter on a SVG image and save as B... |
| [chain-a-gaussian-blur-filter-followed-by-a-sharpen-filter-on-a-tiff-image-and-export-to-png.cs](./chain-a-gaussian-blur-filter-followed-by-a-sharpen-filter-on-a-tiff-image-and-export-to-png.cs) | `GaussianBlurFilterOptions`, `PngOptions`, `SharpenFilterOptions` | Chain a Gaussian blur filter followed by a sharpen filter on a TIFF image and ex... |
| [chain-three-filters-blur-edge-detection-and-sharpen-on-a-png-image-and-save-as-jpeg.cs](./chain-three-filters-blur-edge-detection-and-sharpen-on-a-png-image-and-save-as-jpeg.cs) | `JpegOptions`, `RasterImage` | Chain three filters: blur, edge detection, and sharpen on a PNG image and save a... |
| [chain-a-blur-box-filter-then-an-emboss-filter-then-a-sharpen-filter-on-a-jpeg-image-for-complex-styling.cs](./chain-a-blur-box-filter-then-an-emboss-filter-then-a-sharpen-filter-on-a-jpeg-image-for-complex-styling.cs) | `ConvolutionFilterOptions`, `RasterImage`, `SharpenFilterOptions` | Chain a blur box filter, then an emboss filter, then a sharpen filter on a JPEG ... |
| [batch-process-a-collection-of-bmp-images-with-a-custom-edge-detection-kernel-and-output-jpegs.cs](./batch-process-a-collection-of-bmp-images-with-a-custom-edge-detection-kernel-and-output-jpegs.cs) | `JpegOptions` | Batch process a collection of BMP images with a custom edge detection kernel and... |
| [batch-apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs](./batch-apply-a-predefined-blur-box-filter-to-all-png-files-in-a-folder-and-output-jpegs.cs) | `GaussianBlurFilterOptions`, `JpegOptions`, `RasterImage` | Batch apply a predefined blur box filter to all PNG files in a folder and output... |
| [batch-apply-a-sharpen-filter-to-all-png-files-in-a-directory-and-overwrite-originals-safely.cs](./batch-apply-a-sharpen-filter-to-all-png-files-in-a-directory-and-overwrite-originals-safely.cs) | `RasterImage`, `SharpenFilterOptions` | Batch apply a sharpen filter to all PNG files in a directory and overwrite origi... |
| *...and 434 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.5.0/kernel-filters) |

## Category Statistics
- Total examples: 464
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
- `JpegImage`
- `JpegOptions`
- `JsonSerializerOptions`
- `LazyImage`
- `LoadOptions`
- `MedianFilterOptions`
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


## Developer Q&A

### Q: How to create a custom 3x3 convolution matrix and apply it to a JPEG image in .NET C#?
Use **ConvolutionFilterOptions** to define a 3x3 kernel and call **RasterImage.ApplyFilter** on the loaded JPEG.  
→ See: `create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs`

### Q: How do I normalize a custom kernel so its coefficients sum to one before applying it to a JPEG in C#?
Create a **ConvolutionFilterOptions** instance, set the kernel values, then divide each coefficient by the total sum (or set `Normalize = true`). Apply the filter with **RasterImage.ApplyFilter**.  
→ See: `normalize-a-custom-kernel-so-its-coefficients-sum-to-one-and-apply-to-a-jpeg-image.cs`

### Q: How to apply a zero‑sum edge detection kernel to a PNG image using Aspose.Imaging in .NET?
Define a zero‑sum kernel in **ConvolutionFilterOptions**, then invoke **RasterImage.ApplyFilter** on the PNG image. The resulting image shows black background with highlighted edges.  
→ See: `apply-a-zero-sum-edge-detection-kernel-to-a-png-image-and-verify-black-background-with-highlighted-edges.cs`

### Q: How do I change the blur box kernel size from 3x3 to 7x7 for more smoothing on a BMP in C#?
Set **GaussianBlurFilterOptions.KernelSize** (or **ConvolutionFilterOptions**) to a 7x7 size and apply it with **RasterImage.ApplyFilter** on the BMP.  
→ See: `adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs`

### Q: How to apply a Gaussian blur filter with sigma 1.5 to a BMP image and save as PNG in .NET?
Instantiate **GaussianBlurFilterOptions**, set `Sigma = 1.5`, apply the filter via **RasterImage.ApplyFilter**, then save the result using **Image.Save** with **PngOptions**.  
→ See: `apply-a-gaussian-blur-filter-with-sigma-1-5-to-a-bmp-image-and-save-as-png.cs`



### Q: How can I load an SVG, rasterize it, apply a Gaussian blur, and save the result as PNG using Aspose.Imaging in C#?  
Load the SVG with `Image.Load`, rasterize it, apply `new GaussianBlurFilterOption(radius, sigma)` via `image.Filter`, then save with `PngOptions`. → See: `add-a-readme-example-that-walks-through-loading-an-svg-applying-gaussian-blur-and-saving.cs`

### Q: How do I apply a blur filter to a WebP image and write the processed image as a PNG file with Aspose.Imaging for .NET?  
Load the WebP using `Image.Load`, call `image.Filter(new BlurFilterOption(radius))`, and save the output with `new PngOptions()`. → See: `apply-a-blur-filter-to-a-webp-image-and-write-the-processed-image-to-a-new-file.cs`

### Q: How can I use a custom convolution kernel with negative coefficients to sharpen a PNG image in C# using Aspose.Imaging?  
Create a `ConvolutionFilterOption` supplying the kernel array (including negative values) and invoke `image.Filter` on the loaded PNG before saving. → See: `apply-a-custom-kernel-with-negative-coefficients-to-create-a-sharpening-effect-on-a-png.cs`

### Q: How do I perform deconvolution on an EMF file and save the processed raster image using Aspose.Imaging in C#?  
Load the EMF with `Image.Load`, rasterize it to a bitmap, apply `new DeconvolutionFilterOption()` via `image.Filter`, then save the result with appropriate image options. → See: `apply-a-deconvolution-filter-to-an-emf-image-and-write-the-processed-output-to-disk.cs`

### Q: How can I apply a Gaussian blur to a DNG raw image and export it as PNG using Aspose.Imaging for .NET?  
Load the DNG using `Image.Load` (optionally with `ImageLoadOptions`), apply `new GaussianBlurFilterOption(radius, sigma)` through `image.Filter`, and save the output with `PngOptions`. → See: `apply-a-gaussian-blur-filter-to-a-dng-image-and-write-the-processed-output-to-a-file.cs`

### Q: How can I apply a motion blur filter to a WMF image and save the result as PNG using Aspose.Imaging for .NET?  
Use `Image.Load` to open the WMF, then add a `MotionBlurFilterOption` to the image’s `FilterOptions` collection, and finally save with `PngOptions`. → See: `apply-a-motion-blur-filter-to-a-wmf-image-and-write-the-processed-image-to-a-new-file.cs`

### Q: How do I sharpen a DICOM image with Aspose.Imaging in C# and persist the processed file as DICOM?  
Load the DICOM via `Image.Load`, apply a `SharpenFilterOption` through the image’s `FilterOptions`, and save using `DicomOptions`. → See: `apply-a-sharpen-filter-to-a-dicom-image-and-persist-the-processed-image-to-storage.cs`

### Q: How can I use a built‑in kernel filter (e.g., Emboss) from Aspose.Imaging’s filter set on a PNG image?  
After loading the PNG with `Image.Load`, add the desired `ConvolutionFilterOption` (such as `EmbossFilterOption`) to the image’s `FilterOptions`, then save the output. → See: `apply-a-kernel-filter-from-the-image-processing-filter-set-to-the-target-image.cs`

### Q: How do I rasterize an EPS file to PNG, apply an edge‑detection filter, and save the processed image using Aspose.Imaging?  
Load the EPS with `Image.Load`, rasterize it to a temporary PNG, apply an `EdgeDetectionFilterOption` via `FilterOptions`, and save the final PNG. → See: `apply-an-edge-detection-filter-to-an-eps-image-and-save-the-processed-output-to-a-file.cs`

### Q: How can I load a DNG raw image with ImageLoadOptions before applying a Gaussian blur in Aspose.Imaging for C#?  
Create an `ImageLoadOptions` instance for the DNG, pass it to `Image.Load`, then add a `GaussianBlurFilterOption` to the image’s `FilterOptions` and save as PNG. → See: `apply-a-gaussian-blur-filter-to-a-dng-image-and-write-the-processed-output-to-a-file.cs`

### Q: How can I rasterize an EMF file to PNG before applying a deconvolution filter using Aspose.Imaging in C#?  
Load the EMF with `Image.Load`, save it to a temporary PNG via `image.Save(tempPath,
## Operations Covered
- Load an SVG file  
- Rasterize SVG to a raster image  
- Apply Gaussian blur filter  
- Apply predefined 3×3 box blur filter  
- Apply motion‑blur effect  
- Apply deconvolution filter to JPEG2000 image  
- Apply generic blur filter to EPS image  
- Apply sharpening filter to APNG image  
- Save processed image as PNG  

## Supported Formats
- **SVG** – loaded and rasterized before filtering  
- **PNG** – used as output format for most examples (and as temporary raster file)  
- **EPS** – loaded, rasterized, then blurred  
- **JPEG2000** – loaded and processed with deconvolution filter  
- **CMX** – loaded and blurred (output saved as PNG)  
- **WebP** – loaded and processed with motion blur, saved as PNG  
- **APNG** – loaded and sharpened, saved as APNG  

## API Classes Used
- `Image` — base class for loading any supported image format.  
- `Image.Load(string path)` — static method that reads an image file into an `Image` object.  
- `PngOptions` — specifies PNG‑specific saving options, including rasterization settings.  
- `SvgRasterizationOptions` — defines how an SVG is rasterized (size, background, etc.).  
- `GaussianBlurFilterOption` (from `ImageFilters.FilterOptions`) — configures a Gaussian blur to be applied to a raster image.  
- `BoxBlurFilterOption` — configures a predefined 3×3 box blur filter.  
- `MotionBlurFilterOption` — configures a motion‑blur effect with direction and distance parameters.  
- `DeconvolutionFilterOption` — configures a deconvolution filter for sharpening or restoring JPEG2000 images.  
- `SharpenFilterOption` — configures a sharpening filter for raster images.  
- `RasterImage` (implied cast) — raster image type that supports filter operations.  
- `PngImage` / `WebPImage` / `EpsImage` / `Jpeg2000Image` / `CmxImage` / `SvgImage` (from respective `FileFormats` namespaces) — concrete image classes representing specific file formats.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_061900` | Examples: 464
<!-- AUTOGENERATED:END -->