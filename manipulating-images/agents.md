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

- `using Aspose.Imaging;` (244/413 files) ← category-specific
- `using System;` (237/413 files)
- `using System.IO;` (237/413 files)
- `using Aspose.Imaging.ImageOptions;` (197/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (48/413 files) ← category-specific
- `using Aspose.Imaging.Sources;` (46/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (42/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (33/413 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (28/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (26/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cdr;` (18/413 files) ← category-specific
- `using System.Collections.Generic;` (15/413 files)
- `using Aspose.Imaging.Masking;` (14/413 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (14/413 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (14/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (10/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (9/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (7/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (6/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (6/413 files) ← category-specific
- `using System.Linq;` (5/413 files)
- `using Aspose.Imaging.Brushes;` (5/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (4/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (3/413 files) ← category-specific
- `using System.Drawing;` (3/413 files)
- `using System.Diagnostics;` (3/413 files)
- `using Aspose.Imaging.FileFormats;` (3/413 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (1/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Emf.Records;` (1/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Emf.Objects;` (1/413 files) ← category-specific
- `using System.Net.Sockets;` (1/413 files)
- `using Aspose.Imaging.FileFormats.Core;` (1/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Core.Photo.Hdr;` (1/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Dicom;` (1/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Ico;` (1/413 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Djvu;` (1/413 files) ← category-specific
- `using Aspose.Imaging.ImageLoadOptions;` (1/413 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [27872-load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs](./27872-load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | load a png image apply auto masking graph cut with default strokes and save as p... |
| [27873-create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs](./27873-create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | create automaskinggraphcutoptions with custom feathering radius apply to a png t... |
| [define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs](./define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs) | `MaskingOptions`, `PngOptions`, `RasterImage` | define a point array for manual masking use it on a png and save the processed i... |
| [reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs](./reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs) | `PngOptions`, `RasterImage` | reuse previously configured automaskinggraphcutoptions to refine background remo... |
| [supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs](./supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs) | `PngOptions`, `RasterImage` | supply a detectedobjectlist converted to assumedobjectdata for improved graph cu... |
| [load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs](./load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | load an svg vector image remove its background using default analysis and save a... |
| [remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs](./remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs) | `EmfImage`, `MetaImage` | remove background from an emf file by specifying a background color that matches... |
| [define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs](./define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | define a rectangular area for selective background removal in a cdr vector image... |
| [after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs](./after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs) | `PngOptions`, `VectorRasterizationOptions` | after removing background from a vector image rasterize it to png using pngoptio... |
| [batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs](./batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | batch process a folder of png files applying auto masking graph cut with user de... |
| [iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs](./iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | iterate over a collection of svg files remove backgrounds rasterize to png and s... |
| [apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs](./apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs) | `MedianFilterOptions`, `RasterImage` | apply median filter to a png image after background removal to reduce residual n... |
| [combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs](./combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs) | `BilateralSmoothingFilterOptions`, `GaussWienerFilterOptions`, `RasterImage` | combine gauss wiener deblurring with bilateral smoothing on a raster image to en... |
| [use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs](./use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs) | `MotionWienerFilterOptions`, `RasterImage`, `SharpenFilterOptions` | use motion wiener filter on a png that suffered motion blur then apply sharpenin... |
| [align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs](./align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs) |  | align horizontal and vertical dpi of a raster image before applying any correcti... |
| [create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs](./create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs) | `BilateralSmoothingFilterOptions`, `RasterImage` | create bilateralsmoothingfilteroptions with size parameter set to 5 apply to png... |
| [apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs](./apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs) | `MedianFilterOptions`, `RasterImage`, `SharpenFilterOptions` | apply sharpenfilteroptions after median filtering to accentuate edges in a clean... |
| [load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs](./load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs) | `EmfRasterizationOptions`, `PngOptions` | load multiple emf files remove backgrounds using specified color rasterize each ... |
| [implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to-given-folder.cs](./implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to-given-folder.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | implement a console application that accepts image path arguments applies auto m... |
| [configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of-pngs.cs](./configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of-pngs.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | configure automaskinggraphcutoptions to reuse strokes across iterations improvin... |
| [use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs](./use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | use detectedobjectlist from a prior analysis to seed graph cut algorithm for mor... |
| [apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs](./apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs) | `MedianFilterOptions`, `RasterImage` | apply median filter with kernel size 3 to a png after background removal to smoo... |
| [run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during-conversion.cs](./run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during-conversion.cs) | `GaussWienerFilterOptions`, `RasterImage` | run gauss wiener filter with default parameters on a rasterized vector image to ... |
| [process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs](./process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | process a batch of cdr files remove backgrounds using area selection rasterize t... |
| [apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs](./apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs) | `MotionWienerFilterOptions`, `RasterImage` | apply motion wiener filter with motion vector set to horizontal direction on a p... |
| [combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and-edge-clarity.cs](./combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and-edge-clarity.cs) | `BilateralSmoothingFilterOptions`, `RasterImage`, `SharpenFilterOptions` | combine bilateral smoothing and sharpening filters sequentially on a raster imag... |
| [align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs](./align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | align resolutions of a loaded svg before rasterization to ensure consistent dpi ... |
| [27899-create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs](./27899-create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs) | `RasterImage` | create a reusable method that loads a raster image applies auto masking median f... |
| [develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background-existed.cs](./develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background-existed.cs) | `MaskingOptions`, `PngOptions`, `RasterImage` | develop a unit test that verifies background removal on a png yields transparent... |
| [measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes-on-identical-images.cs](./measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes-on-identical-images.cs) | `AutoMaskingGraphCutOptions`, `GraphCutMaskingOptions`, `PngOptions` | measure performance difference between graph cut auto masking with default strok... |
| *...and 383 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.5.0/manipulating-images) |

## Category Statistics
- Total examples: 413
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


## Use Cases  
- A web service that receives user‑uploaded photos and needs to **resize, crop, and rotate C#** images on the fly before storing them in Azure Blob Storage, ensuring consistent thumbnails across the platform.  
- An e‑commerce application that automatically adjusts product images for different device screens, using **image manipulation C#** to generate high‑resolution and thumbnail versions in a single pipeline.  
- A desktop utility for batch **image editing dotnet** that processes large TIFF archives, applying rotation and cropping to meet printing specifications without manual intervention.  
- A medical imaging tool that extracts regions of interest from DICOM‑converted images, employing **resize, crop, rotate C#** operations to focus on diagnostic details.  
- An automated marketing workflow that creates social‑media graphics by programmatically resizing and rotating source assets, streamlining **image editing dotnet** tasks for rapid campaign launches.  

## Related Categories  
The Manipulating Images examples often complement the **Converting Formats** category, where files are first transformed into a suitable format before being resized or cropped. Developers working on **Applying Filters** can chain filter operations after performing basic transformations like rotate and resize, achieving richer visual effects. Additionally, the **Drawing Shapes** and **Metadata Management** sections provide ways to annotate or tag the manipulated images, creating a comprehensive image processing toolkit within the repository.


## Developer Q&A

### Q: How do I load a PNG image, apply auto‑masking graph cut with the default strokes, and save the result as a PNG in C#?
Use `RasterImage.Load` to open the PNG, create an `AutoMaskingGraphCutOptions` instance with default strokes, call `image.ApplyAutoMaskingGraphCut(options)`, and then save with `image.Save("output.png", new PngOptions())`. → See: `27872-load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs`

### Q: How to define a point array for manual masking on a PNG and export the processed image using Aspose.Imaging for .NET?
Create a `MaskingOptions` object, assign your `Point[]` array to its `Points` property, invoke `image.ApplyMasking(maskingOptions)`, and save the image with `new PngOptions()`. → See: `define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs`

### Q: How do I remove the background from an SVG vector image with default analysis and rasterize it to PNG in C#?
Load the SVG with `SvgImage.Load`, use `AutoMaskingGraphCutOptions` (default settings) together with `image.ApplyAutoMaskingGraphCut`, then rasterize and save via `image.Save("output.png", new PngOptions())`. → See: `load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs`

### Q: How to apply a median filter to a PNG after background removal to reduce residual noise before saving?
After masking, instantiate `MedianFilterOptions`, call `image.ApplyFilter(medianOptions)`, and finally save the cleaned image with `new PngOptions()`. → See: `apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs`

### Q: How to batch‑process a folder of PNG files, applying auto‑masking graph cut with custom user‑defined strokes to each file in .NET?
Loop through the directory, load each file with `RasterImage.Load`, configure `AutoMaskingGraphCutOptions` with your custom strokes, apply `image.ApplyAutoMaskingGraphCut(options)`, and save the result using `new PngOptions()`. → See: `batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs`


## Operations Covered
- Load PNG image from file  
- Apply auto‑masking (graph‑cut) to PNG  
- Save processed image as PNG  
- Apply Gaussian‑Wiener filter to image  
- Save filtered image as APNG  
- Adjust gamma of raster image  
- Apply per‑channel gamma correction to PSD  
- Export PSD image to PDF  
- Embed digital signature into JPEG (pixel‑count check)  
- Verify digital signature on BMP  
- Perform Gauss‑Wiener deblurring on raster image  
- Apply bilateral smoothing after masking  

## Supported Formats
- **PNG** – loaded and saved after masking  
- **APNG** – output format for Gaussian‑Wiener filtered image  
- **JPEG** – source image for digital‑signature embedding  
- **PSD** – source image for per‑channel gamma correction  
- **PDF** – target format when exporting PSD  
- **BMP** – created, signed, and verified  

## API Classes Used
- **Image** – base class for loading, processing, and disposing images.  
- **RasterImage** – provides pixel‑level operations such as `AdjustGamma` and filter application.  
- **PngOptions** – specifies options when saving PNG files.  
- **GraphCutMaskingOptions** – configures parameters for automatic graph‑cut masking.  
- **GraphCutMaskingResult** – holds the result of a graph‑cut masking operation.  
- **FileCreateSource** – represents a file‑based data source used when creating new images.  
- **GaussianWienerFilterOption** – defines settings for the Gaussian‑Wiener filter.  
- **BilateralSmoothingFilterOption** – defines settings for bilateral smoothing filter.  
- **JpegImage** – represents a JPEG image, used here for embedding a digital signature.  
- **BmpOptions** – defines options for creating and saving BMP images.  
- **BmpImage** – represents a BMP image, used for signing and verification.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_070134` | Examples: 413
<!-- AUTOGENERATED:END -->