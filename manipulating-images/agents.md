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

- `using Aspose.Imaging;` (240/425 files) ← category-specific
- `using System;` (237/425 files)
- `using System.IO;` (237/425 files)
- `using Aspose.Imaging.ImageOptions;` (187/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (47/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (46/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (35/425 files) ← category-specific
- `using Aspose.Imaging.Sources;` (34/425 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (28/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (23/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cdr;` (20/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (15/425 files) ← category-specific
- `using System.Collections.Generic;` (14/425 files)
- `using Aspose.Imaging.Masking;` (13/425 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (13/425 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (13/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (9/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (7/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (7/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (5/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (5/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (4/425 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (4/425 files) ← category-specific
- `using System.Drawing;` (3/425 files)
- `using System.Diagnostics;` (2/425 files)
- `using Aspose.Imaging.CoreExceptions;` (2/425 files) ← category-specific
- `using System.Linq;` (2/425 files)
- `using Aspose.Imaging.Shapes;` (1/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Emf.Records;` (1/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Emf.Objects;` (1/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats;` (1/425 files) ← category-specific
- `using Aspose.Imaging.Watermark;` (1/425 files) ← category-specific
- `using System.Net.Sockets;` (1/425 files)
- `using Aspose.Imaging.FileFormats.Dicom;` (1/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (1/425 files) ← category-specific
- `using Aspose.Imaging.ImageLoadOptions;` (1/425 files) ← category-specific
- `using Aspose.Imaging.CustomFontHandler;` (1/425 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs](./load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Load a PNG image, apply auto‑masking Graph Cut with default strokes, and save as... |
| [create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs](./create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs) | `PngOptions` | Create AutoMaskingGraphCutOptions with custom feathering radius, apply to a PNG,... |
| [define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs](./define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs) | `MaskingOptions`, `PngOptions`, `RasterImage` | Define a Point array for manual masking, use it on a PNG, and save the processed... |
| [reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs](./reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Reuse previously configured AutoMaskingGraphCutOptions to refine background remo... |
| [supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs](./supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Supply a DetectedObjectList converted to AssumedObjectData for improved Graph Cu... |
| [load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs](./load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | Load an SVG vector image, remove its background using default analysis, and save... |
| [remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs](./remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs) | `EmfImage`, `MetaImage` | Remove background from an EMF file by specifying a background color that matches... |
| [define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs](./define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Define a rectangular area for selective background removal in a CDR vector image... |
| [after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs](./after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs) | `PngOptions`, `VectorRasterizationOptions` | After removing background from a vector image, rasterize it to PNG using PngOpti... |
| [batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs](./batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs) | `PngOptions`, `RasterImage` | Batch process a folder of PNG files, applying auto‑masking Graph Cut with user‑d... |
| [iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs](./iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | Iterate over a collection of SVG files, remove backgrounds, rasterize to PNG, an... |
| [apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs](./apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs) | `AutoMaskingGraphCutOptions`, `MedianFilterOptions`, `PngOptions` | Apply median filter to a PNG image after background removal to reduce residual n... |
| [combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs](./combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs) | `BilateralSmoothingFilterOptions`, `GaussWienerFilterOptions`, `RasterImage` | Combine Gauss‑Wiener deblurring with bilateral smoothing on a raster image to en... |
| [use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs](./use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs) | `MotionWienerFilterOptions`, `RasterImage`, `SharpenFilterOptions` | Use Motion‑Wiener filter on a PNG that suffered motion blur, then apply sharpeni... |
| [align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs](./align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs) |  | Align horizontal and vertical DPI of a raster image before applying any correcti... |
| [create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs](./create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs) | `BilateralSmoothingFilterOptions`, `RasterImage` | Create BilateralSmoothingFilterOptions with size parameter set to 5, apply to PN... |
| [apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs](./apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs) | `MedianFilterOptions`, `RasterImage`, `SharpenFilterOptions` | Apply SharpenFilterOptions after median filtering to accentuate edges in a clean... |
| [load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs](./load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs) | `EmfImage`, `EmfRasterizationOptions`, `PngOptions` | Load multiple EMF files, remove backgrounds using specified color, rasterize eac... |
| [implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to.cs](./implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Implement a console application that accepts image path arguments, applies auto‑... |
| [configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of.cs](./configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Configure AutoMaskingGraphCutOptions to reuse strokes across iterations, improvi... |
| [use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs](./use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Use DetectedObjectList from a prior analysis to seed Graph Cut algorithm for mor... |
| [apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs](./apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs) | `MedianFilterOptions`, `RasterImage` | Apply median filter with kernel size 3 to a PNG after background removal to smoo... |
| [run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during.cs](./run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during.cs) | `GaussWienerFilterOptions`, `RasterImage` | Run Gauss‑Wiener filter with default parameters on a rasterized vector image to ... |
| [process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs](./process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs) | `CdrImage`, `CdrRasterizationOptions`, `PngOptions` | Process a batch of CDR files, remove backgrounds using area selection, rasterize... |
| [apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs](./apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs) | `MotionWienerFilterOptions`, `RasterImage` | Apply Motion‑Wiener filter with motion vector set to horizontal direction on a P... |
| [combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and.cs](./combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and.cs) | `BilateralSmoothingFilterOptions`, `RasterImage`, `SharpenFilterOptions` | Combine bilateral smoothing and sharpening filters sequentially on a raster imag... |
| [align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs](./align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs) | `PngOptions`, `SvgImage`, `SvgRasterizationOptions` | Align resolutions of a loaded SVG before rasterization to ensure consistent DPI ... |
| [create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs](./create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Create a reusable method that loads a raster image, applies auto‑masking, median... |
| [develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background.cs](./develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background.cs) | `PngImage`, `PngOptions`, `RasterImage` | Develop a unit test that verifies background removal on a PNG yields transparent... |
| [measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes.cs](./measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes.cs) | `PngOptions` | Measure performance difference between Graph Cut auto‑masking with default strok... |
| *...and 395 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.6.0/manipulating-images) |

## Category Statistics
- Total examples: 425
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



### Q: How can I rotate a BMP image by 45 degrees, fill the empty background with white, and save the result using Aspose.Imaging for .NET?  
Load the BMP with `Image.Load`, call `image.Rotate(45)` and set the background color via `image.BackgroundColor = Color.White` before saving with `BmpImage.Save`. → See: `apply-a-45-degree-rotation-to-a-bmp-image-with-white-background-fill-and-store-the-output-in-a-file.cs`

### Q: How do I programmatically adjust brightness, contrast, and gamma of an APNG file and export the edited image as PNG in C#?  
Use `ApngImage` to load the file, apply `ImageAdjustments.BrightnessContrastGamma(brightness, contrast, gamma)` and then save with `PngOptions`. → See: `apply-configurable-brightness-contrast-and-gamma-adjustments-to-apng-images-programmatically-within-the-net-environment.cs`

### Q: How can I apply a Gaussian blur to a TIFF image, increase its brightness, and save the final picture as a PDF using Aspose.Imaging?  
Load the TIFF with `Image.Load`, add a `GaussianBlurFilter` via `image.ApplyFilter(new GaussianBlurFilter(radius))`, adjust brightness with `ImageAdjustments.Brightness(image, value)`, and export using `PdfOptions`. → See: `apply-gaussian-blur-to-a-tiff-image-then-adjust-brightness-saving-the-final-picture-as-pdf.cs`

### Q: How do I crop an image by shifting the crop region with offset values in Aspose.Imaging for .NET?  
Create a `Rectangle` that represents the desired crop area, modify its `X` and `Y` with the offset, and call `image.Crop(rectangle)` before saving. → See: `apply-offset-based-cropping-to-images-shifting-the-crop-region-to-extract-desired-portions-efficiently.cs`

### Q: How can I batch‑process all TIFF files in a folder, apply a Gaussian blur to each, and output each softened image as a PDF with Aspose.Imaging?  
Iterate through the directory, load each TIFF via `Image.Load`, apply `new GaussianBlurFilter(radius)` with `image.ApplyFilter`, then save each result using `PdfOptions` to the output folder. → See: `batch-apply-gaussian-blur-to-all-tiff-files-in-a-folder-outputting-each-softened-image-as-pdf.cs`

### Q: How can I batch‑verify digital signatures of images stored in a cloud folder and write any mismatches to an audit log using Aspose.Imaging for .NET?  
Use `Image.Load` to open each file, call `image.VerifySignature(password)` for verification, and log the result with `File.AppendAllText`. → See: batch-verify-digital-signatures-of-images-in-cloud-storage-logging-any-mismatches-to-an-audit-file.cs  

### Q: How do I compress all GIF files in a directory with lossy compression while keeping the original animation frame order in C#?  
Create a `GifCompressionOptions` with `Lossy = true` and pass it to `GifImage.Save` for each file; the library preserves the frame sequence automatically. → See: compress-multiple-gif-files-in-a-directory-with-lossy-settings-preserving-each-animation-s-frame-order.cs  

### Q: How can I embed a digital signature into a BMP image and then attempt verification with an incorrect password using Aspose.Imaging for .NET?  
Set `BmpOptions.DigitalSignature` when saving the BMP, then call `image.VerifySignature(wrongPassword)` which will return false for a bad password. → See: create-a-bmp-image-embed-a-digital-signature-then-attempt-to-verify-the-signature-with-an-incorrect-password.cs  

### Q: How do I set

### Q: How can I extract the mask generated by AutoMaskingGraphCut and save it as a separate PNG using Aspose.Imaging for .NET?  
Use the `AutoMaskingGraphCutResult.MaskImage` property to get the mask bitmap and call its `Save` method with a `PngOptions` instance. → See: 27872-load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs  

### Q: How do I set a custom feathering radius for the AutoMaskingGraphCut operation on a PNG in C#?  
Create an `AutoMaskingGraphCutOptions` object, assign the desired value to its `FeatheringRadius` property, and pass it to `AutoMaskingGraphCut`. → See: create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs  

### Q: How can I rotate a BMP image by a non‑standard angle (e.g., 30°) and fill the empty area with white using Aspose.Imaging in .NET?  
Call `image.Rotate` with a `RotateOptions` specifying `Angle = 30` and `BackgroundColor = Color.White`. → See: apply-a-45-degree-rotation-to-a-bmp-image-with-white-background-fill-and-store-the-output-in-a-file.cs  

### Q: How do I apply brightness, contrast, and gamma adjustments to each frame of an APNG before saving as a PNG in C#?  
Load the `ApngImage`, iterate its `Frames` collection, call `AdjustBrightnessContrast
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
Updated: 2026-06-27 | Run: `20260627_051727` | Examples: 425
<!-- AUTOGENERATED:END -->