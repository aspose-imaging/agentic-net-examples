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
- `using Aspose.Imaging.ImageOptions;` (209/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (65/425 files) ← category-specific
- `using Aspose.Imaging.Sources;` (59/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (31/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (30/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (28/425 files) ← category-specific
- `using Aspose.Imaging.Masking;` (22/425 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (22/425 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (22/425 files) ← category-specific
- `using System.Collections.Generic;` (19/425 files)
- `using Aspose.Imaging.FileFormats.Cdr;` (19/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (18/425 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (17/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (13/425 files) ← category-specific
- `using System.Drawing.Text;` (8/425 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (6/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats;` (6/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (6/425 files) ← category-specific
- `using System.Linq;` (6/425 files)
- `using Aspose.Imaging.FileFormats.Psd;` (4/425 files) ← category-specific
- `using System.Drawing.Drawing2D;` (4/425 files)
- `using System.Diagnostics;` (2/425 files)
- `using Aspose.Imaging.FileFormats.Svg;` (2/425 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (2/425 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (2/425 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (1/425 files) ← category-specific
- `using Aspose.Imaging.MagicWand;` (1/425 files) ← category-specific
- `using Aspose.Imaging.MagicWand.ImageMasks;` (1/425 files) ← category-specific
- `using System.Net.Sockets;` (1/425 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs](./load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Load a PNG image, apply auto‑masking Graph Cut with default strokes, and save as... |
| [create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs](./create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Create AutoMaskingGraphCutOptions with custom feathering radius, apply to a PNG,... |
| [define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs](./define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs) | `MaskingOptions`, `PngOptions`, `RasterImage` | Define a Point array for manual masking, use it on a PNG, and save the processed... |
| [reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs](./reuse-previously-configured-automaskinggraphcutoptions-to-refine-background-removal-on-a-second-png-file.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Reuse previously configured AutoMaskingGraphCutOptions to refine background remo... |
| [supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs](./supply-a-detectedobjectlist-converted-to-assumedobjectdata-for-improved-graph-cut-segmentation-on-a-raster-image.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Supply a DetectedObjectList converted to AssumedObjectData for improved Graph Cu... |
| [load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs](./load-an-svg-vector-image-remove-its-background-using-default-analysis-and-save-as-png.cs) | `PngOptions`, `VectorRasterizationOptions` | Load an SVG vector image, remove its background using default analysis, and save... |
| [remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs](./remove-background-from-an-emf-file-by-specifying-a-background-color-that-matches-unwanted-regions.cs) | `EmfOptions` | Remove background from an EMF file by specifying a background color that matches... |
| [define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs](./define-a-rectangular-area-for-selective-background-removal-in-a-cdr-vector-image-before-rasterization.cs) | `PngOptions`, `VectorRasterizationOptions` | Define a rectangular area for selective background removal in a CDR vector image... |
| [after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs](./after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs) | `PngOptions`, `VectorRasterizationOptions` | After removing background from a vector image, rasterize it to PNG using PngOpti... |
| [batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs](./batch-process-a-folder-of-png-files-applying-auto-masking-graph-cut-with-user-defined-strokes-to-each.cs) | `GraphCutMaskingOptions`, `PngOptions`, `RasterImage` | Batch process a folder of PNG files, applying auto‑masking Graph Cut with user‑d... |
| [iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs](./iterate-over-a-collection-of-svg-files-remove-backgrounds-rasterize-to-png-and-store-results-in-output-directory.cs) | `PngOptions` | Iterate over a collection of SVG files, remove backgrounds, rasterize to PNG, an... |
| [apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs](./apply-median-filter-to-a-png-image-after-background-removal-to-reduce-residual-noise-before-saving.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Apply median filter to a PNG image after background removal to reduce residual n... |
| [combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs](./combine-gauss-wiener-deblurring-with-bilateral-smoothing-on-a-raster-image-to-enhance-clarity-after-masking.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Combine Gauss‑Wiener deblurring with bilateral smoothing on a raster image to en... |
| [use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs](./use-motion-wiener-filter-on-a-png-that-suffered-motion-blur-then-apply-sharpening-for-edge-definition.cs) | `MotionWienerFilterOptions`, `PngOptions`, `RasterImage` | Use Motion‑Wiener filter on a PNG that suffered motion blur, then apply sharpeni... |
| [align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs](./align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs) | `JpegOptions`, `RasterImage` | Align horizontal and vertical DPI of a raster image before applying any correcti... |
| [create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs](./create-bilateralsmoothingfilteroptions-with-size-parameter-set-to-5-apply-to-png-and-save-output.cs) | `PngOptions`, `RasterImage` | Create BilateralSmoothingFilterOptions with size parameter set to 5, apply to PN... |
| [apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs](./apply-sharpenfilteroptions-after-median-filtering-to-accentuate-edges-in-a-cleaned-raster-image.cs) | `JpegOptions`, `RasterImage` | Apply SharpenFilterOptions after median filtering to accentuate edges in a clean... |
| [load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs](./load-multiple-emf-files-remove-backgrounds-using-specified-color-rasterize-each-to-png-and-log-processing-time.cs) | `PngOptions`, `VectorRasterizationOptions` | Load multiple EMF files, remove backgrounds using specified color, rasterize eac... |
| [implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to.cs](./implement-a-console-application-that-accepts-image-path-arguments-applies-auto-masking-and-writes-png-output-to.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Implement a console application that accepts image path arguments, applies auto‑... |
| [configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of.cs](./configure-automaskinggraphcutoptions-to-reuse-strokes-across-iterations-improving-mask-accuracy-for-a-series-of.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Configure AutoMaskingGraphCutOptions to reuse strokes across iterations, improvi... |
| [use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs](./use-detectedobjectlist-from-a-prior-analysis-to-seed-graph-cut-algorithm-for-more-precise-background-segmentation.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Use DetectedObjectList from a prior analysis to seed Graph Cut algorithm for mor... |
| [apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs](./apply-median-filter-with-kernel-size-3-to-a-png-after-background-removal-to-smooth-minor-artifacts.cs) | `AutoMaskingGraphCutOptions`, `MedianFilterOptions`, `PngOptions` | Apply median filter with kernel size 3 to a PNG after background removal to smoo... |
| [run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during.cs](./run-gauss-wiener-filter-with-default-parameters-on-a-rasterized-vector-image-to-reduce-blur-introduced-during.cs) | `GaussWienerFilterOptions`, `PngOptions`, `RasterImage` | Run Gauss‑Wiener filter with default parameters on a rasterized vector image to ... |
| [process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs](./process-a-batch-of-cdr-files-remove-backgrounds-using-area-selection-rasterize-to-png-and-compress-results.cs) | `CdrImage`, `PngOptions`, `VectorRasterizationOptions` | Process a batch of CDR files, remove backgrounds using area selection, rasterize... |
| [apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs](./apply-motion-wiener-filter-with-motion-vector-set-to-horizontal-direction-on-a-png-captured-from-video.cs) | `PngOptions`, `RasterImage` | Apply Motion‑Wiener filter with motion vector set to horizontal direction on a P... |
| [combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and.cs](./combine-bilateral-smoothing-and-sharpening-filters-sequentially-on-a-raster-image-to-achieve-noise-reduction-and.cs) | `PngOptions`, `RasterImage` | Combine bilateral smoothing and sharpening filters sequentially on a raster imag... |
| [align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs](./align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs) | `PngOptions`, `SvgRasterizationOptions` | Align resolutions of a loaded SVG before rasterization to ensure consistent DPI ... |
| [create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs](./create-a-reusable-method-that-loads-a-raster-image-applies-auto-masking-median-filter-and-returns-processed-bitmap.cs) | `AutoMaskingGraphCutOptions`, `MedianFilterOptions`, `PngOptions` | Create a reusable method that loads a raster image, applies auto‑masking, median... |
| [develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background.cs](./develop-a-unit-test-that-verifies-background-removal-on-a-png-yields-transparent-pixels-where-original-background.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Develop a unit test that verifies background removal on a PNG yields transparent... |
| [measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes.cs](./measure-performance-difference-between-graph-cut-auto-masking-with-default-strokes-and-with-custom-user-strokes.cs) | `AutoMaskingGraphCutOptions`, `PngOptions`, `RasterImage` | Measure performance difference between Graph Cut auto‑masking with default strok... |
| *...and 395 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.10.0/manipulating-images) |

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
- When you need to **export a PSD file as PNG while preserving custom font appearance**, you can point Aspose.Imaging to a folder of user‑defined fonts with `FontSettings.SetFontsFolder`, load the PSD, and save it using `PngOptions` – this keeps the text rendering identical to the original design.  
- If your workflow requires **applying Gaussian blur to multiple CDR files and merging the blurred results into a multipage TIFF**, load each `.cdr` file, apply `GaussianBlurFilter`, and add the processed images to a `TiffImage` collection before saving the combined document.  
- To generate an animated PNG from a series of PNG frames with smoother edges, enable the **smoothing mode in the APNG options** (`ApngOptions.SmoothingMode = SmoothingMode.AntiAlias`) before calling `image.Save(outputPath, new ApngOptions())`.  
- When you want to **use the Bradley threshold algorithm to binarize an image and output the result as an APNG**, cast the loaded image to `RasterImage`, call `BinarizeBradley`, and then save the processed raster using `ApngOptions`.  
- For high‑quality batch conversion of TIFF images to PDF where visual fidelity matters, set the **smoothing/anti‑aliasing mode in the PDF options** (`PdfOptions.SmoothingMode = SmoothingMode.AntiAlias`) to ensure crisp text and graphics in the final PDF.

## Related Categories
Manipulating images often goes hand‑in‑hand with format conversion, so the examples here complement the **[Convert Cdr](../convert-cdr/)** and **[Convert Raster Image](../convert-raster-image/)** categories, where you can learn how to read and write CorelDRAW or generic raster files before applying filters.  
If you need to apply additional visual effects such as sharpening or color adjustments, the **[Image And Photo Filters](../image-and-photo-filters/)** category provides a wide range of filter options that can be combined with the Gaussian blur or Bradley threshold workflows shown above.  
Finally, when you want to combine several processed pages into a single document, the **[Merge Images](../merge-images/)** category demonstrates techniques for stitching images together, which aligns naturally with the multipage TIFF merging scenario.


## Operations Covered
- Export PSD to PNG with custom fonts  
- Add user‑defined fonts to FontSettings  
- Apply smoothing mode when generating APNG files  
- Apply Gaussian blur to multiple CDR files  
- Merge blurred CDR images into a multi‑page TIFF  
- Perform Bradley threshold (BinarizeBradley) on PNG images  
- Batch convert TIFF images to high‑quality PDF with smoothing enabled  
- Rotate a PNG image 45° while preserving transparent background and dimensions

## Supported Formats
- **PSD** – source Photoshop document that is exported to PNG with accurate text rendering.  
- **PNG** – input raster image for smoothing, Bradley threshold, rotation, and as the base format for APNG creation.  
- **APNG** – animated PNG output generated after applying smoothing or Bradley threshold.  
- **CDR** – CorelDRAW files that receive Gaussian blur before being merged.  
- **TIFF** – multi‑page TIFF created from blurred CDR images and also the source format for batch PDF conversion.  
- **PDF** – high‑quality PDF files produced from TIFF images and from TIFF‑to‑PDF conversion with multiple font folders.

## API Classes Used
- `Image` — static class used to load any supported image (`Image.Load`) and to save processed results (`Image.Save`).  
- `RasterImage` — derived class for raster‑specific operations such as applying the Bradley threshold (`BinarizeBradley`).  
- `FontSettings` — (referenced in the file name) manages custom font collections and font folders for accurate text rendering during export.  
- `ImageOptions` (namespace) — provides option classes (e.g., PNG, PDF, TIFF) that control saving parameters like smoothing mode or font settings.  
- `ApngOptions` — option class (from `Aspose.Imaging.FileFormats.Apng`) that configures APNG generation, including smoothing mode.  
- `PdfOptions` — option class (from `Aspose.Imaging.FileFormats.Pdf`) that configures PDF output, such as embedding fonts and high‑quality rendering.  
- `TiffOptions` — option class (from `Aspose.Imaging.FileFormats.Tiff`) that configures multi‑page TIFF creation and saving.  
- `GaussianBlurFilterOptions` — filter option class used to apply Gaussian blur to raster images before merging.  
- `BinarizeBradleyFilterOptions` — filter option class used to perform Bradley threshold binarization on raster images.


## Get Started

Ready to try Manipulating Images conversions on your own files with Aspose.Imaging for .NET?

```bash
dotnet add package Aspose.Imaging
```

| Resource | Link |
|----------|------|
| 📖 Documentation | [docs.aspose.com/imaging/net](https://docs.aspose.com/imaging/net/) |
| 📦 NuGet Package | [www.nuget.org/packages/aspose.imaging](https://www.nuget.org/packages/aspose.imaging) |
| 🚀 Release Notes | [releases.aspose.com/imaging/net](https://releases.aspose.com/imaging/net/) |
| 🌐 Online Apps | [products.aspose.app/imaging/family](https://products.aspose.app/imaging/family/) |
| 🔑 Free Temporary License | [purchase.aspose.com/temporary-license](https://purchase.aspose.com/temporary-license) |
| 🤝 Consulting (paid implementation help) | [consulting.aspose.com](https://consulting.aspose.com/) |


## Developer Q&A

### Q: How can I safely handle a missing input PNG file when adjusting contrast with Aspose.Imaging in C# (net9.0)?
Check `File.Exists` before calling `Image.Load`; if the file is absent the generic `catch (Exception ex)` block will capture the resulting `FileNotFoundException`. The contrast is then applied with `image.AdjustContrast(...)`. → See: [apply-contrast-adjustments-to-images-allowing-fine-grained-control-over-tonal-range-and-visual-clarity.cs](./apply-contrast-adjustments-to-images-allowing-fine-grained-control-over-tonal-range-and-visual-clarity.cs)

### Q: How do I apply a median filter to an APNG image using Aspose.Imaging in C#?
Load the APNG with `Image.Load`, create a `MedianFilterOptions` object, and call `image.Filter(medianFilterOptions)`. Save the filtered image with `PngOptions` to retain the APNG format. → See: [apply-median-and-wiener-filters-to-images-saved-in-the-apng-format-for-enhanced-noise-reduction.cs](./apply-median-and-wiener-filters-to-images-saved-in-the-apng-format-for-enhanced-noise-reduction.cs)

### Q: How can I batch convert multiple CDR files to individual PDF documents while preserving vector shapes with Aspose.Imaging in C#?
Iterate over the CDR files, load each with `Image.Load`, set `PdfOptions` (including `VectorRasterizationOptions` if needed), and call `image.Save(pdfPath, pdfOptions)`. This keeps vector shapes intact in the resulting PDFs. → See: [batch-export-emf-text-from-multiple-cdr-files-to-individual-pdf-documents-with-vector-shape-conversion.cs](./batch-export-emf-text-from-multiple-cdr-files-to-individual-pdf-documents-with-vector-shape-conversion.cs)

### Q: How do I configure FontSettings with multiple font directories for TIFF‑to‑PDF conversion using Aspose.Imaging in C#?
Create a `FontSettings` instance, add each folder via `fontSettings.FontFolders.Add("path")`, assign it to `PdfOptions.FontSettings`, then load the TIFF and save as PDF. This enables scripts that require fonts from different locations. → See: [configure-fontsettings-with-multiple-font-directories-for-tiff-to-pdf-conversion-to-support-diverse-scripts.cs](./configure-fontsettings-with-multiple-font-directories-for-tiff-to-pdf-conversion-to-support-diverse-scripts.cs)

### Q: How can I flip a GIF image horizontally, rotate it 15 degrees, and store the result in a byte array with Aspose.Imaging in C#?
Load the GIF with `Image.Load`, call `image.RotateFlip(RotateFlipType.RotateNoneFlipX)`, then `image.Rotate(15)`. Save the transformed image to a `MemoryStream` using `GifOptions` and retrieve the byte array via `memoryStream.ToArray()`. → See: [flip-a-gif-image-horizontally-rotate-it-15-degrees-and-store-the-result-in-a-byte-array.cs](./flip-a-gif-image-horizontally-rotate-it-15-degrees-and-store-the-result-in-a-byte-array.cs)

<!-- AUTOGENERATED:START -->
Updated: 2026-10-15 | Run: `20261015_045938` | Examples: 425
<!-- AUTOGENERATED:END -->