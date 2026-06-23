# Image Filter C# Examples with Aspose.Imaging

A collection of concise C# snippets that demonstrate how to **apply image filters** and photo effects using **Aspose.Imaging for .NET**. These examples cover common scenarios such as alpha blending, overlay composition, and batch processing, helping you quickly integrate photo filter functionality into your .NET applications.

## What's in This Category
- **Alpha blending with custom opacity** – blend a JPEG with a semi‑transparent overlay and save as PNG.  
- **Center‑based overlay composition** – calculate the center of a BMP background, blend a PNG overlay, and export to TIFF.  
- **Batch processing of image folders** – apply a 64‑level alpha overlay to every PNG in a directory and output JPEG results.  
- **Saving with specific format options** – use `PngOptions`, `JpegOptions`, and `TiffOptions` to control output quality and metadata.  

## Quick Start

The most common operation—applying an alpha‑blended overlay and saving the result—can be done in just a few lines:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

string sourcePath = @"input.jpg";
string overlayPath = @"overlay.png";
string outputPath = @"output.png";

using (RasterImage source = (RasterImage)Image.Load(sourcePath))
using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
{
    // Apply 50% opacity (alpha = 127) to the overlay
    overlay.Alpha = 127;
    source.Blend(overlay, new Point(0, 0));

    var pngOptions = new PngOptions { ColorType = PngColorType.Truecolor };
    source.Save(outputPath, pngOptions);
}
```

Run the code after adding the **Aspose.Imaging** NuGet package (see Requirements) and you’ll have a filtered image ready for use.

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [remove-watermark-from-a-png-using-telea-algorithm-and-set-removal-attempts-to-five.cs](./remove-watermark-from-a-png-using-telea-algorithm-and-set-removal-attempts-to-five.cs) |
| [create-a-custom-selection-by-combining-magic-wand-union-and-subtraction-then-fill-with-solid-color.cs](./create-a-custom-selection-by-combining-magic-wand-union-and-subtraction-then-fill-with-solid-color.cs) |
| [add-unit-tests-that-verify-mask-inversion-works-correctly-for-both-fully-white-and-fully-black-initial-masks.cs](./add-unit-tests-that-verify-mask-inversion-works-correctly-for-both-fully-white-and-fully-black-initial-masks.cs) |
| [adjust-contentawarefillwatermarkoptions-maxpaintingattempts-to-3-to-improve-removal-quality-on-complex-watermark-patterns.cs](./adjust-contentawarefillwatermarkoptions-maxpaintingattempts-to-3-to-improve-removal-quality-on-complex-watermark-patterns.cs) |
| [adjust-magicwandtool-threshold-to-a-high-value-to-expand-mask-coverage-over-color-gradients-in-a-png-image.cs](./adjust-magicwandtool-threshold-to-a-high-value-to-expand-mask-coverage-over-color-gradients-in-a-png-image.cs) |
| [allow-users-to-adjust-the-feather-radius-interactively-and-preview-the-refined-mask-in-real-time.cs](./allow-users-to-adjust-the-feather-radius-interactively-and-preview-the-refined-mask-in-real-time.cs) |
| [apply-a-color-similarity-filter-to-isolate-a-region-within-an-apng-image-based-on-pixel-hue.cs](./apply-a-color-similarity-filter-to-isolate-a-region-within-an-apng-image-based-on-pixel-hue.cs) |
| [apply-a-filter-to-an-apng-image-allowing-custom-blending-color-selection-and-configurable-opacity-level.cs](./apply-a-filter-to-an-apng-image-allowing-custom-blending-color-selection-and-configurable-opacity-level.cs) |
| [apply-a-filter-to-an-apng-image-and-set-its-configuration-properties-as-desired.cs](./apply-a-filter-to-an-apng-image-and-set-its-configuration-properties-as-desired.cs) |
| [apply-a-magic-wand-selection-filter-to-the-image-to-isolate-contiguous-regions-based-on-color-similarity.cs](./apply-a-magic-wand-selection-filter-to-the-image-to-isolate-contiguous-regions-based-on-color-similarity.cs) |
| [apply-a-specified-filter-to-an-apng-image-modifying-each-frame-while-preserving-animation-properties.cs](./apply-a-specified-filter-to-an-apng-image-modifying-each-frame-while-preserving-animation-properties.cs) |
| [apply-a-specified-image-filter-during-construction-of-an-apng-image-object-to-transform-pixel-data.cs](./apply-a-specified-image-filter-during-construction-of-an-apng-image-object-to-transform-pixel-data.cs) |
| [apply-a-specified-image-filter-to-an-apng-file-ensuring-correct-handling-of-its-animation-frames.cs](./apply-a-specified-image-filter-to-an-apng-file-ensuring-correct-handling-of-its-animation-frames.cs) |
| [apply-a-specified-image-filter-to-each-raster-frame-within-an-apng-image-while-maintaining-animation-integrity.cs](./apply-a-specified-image-filter-to-each-raster-frame-within-an-apng-image-while-maintaining-animation-integrity.cs) |
| [apply-a-supported-filter-to-an-apng-image-adjusting-pixel-data-according-to-the-selected-filter-type.cs](./apply-a-supported-filter-to-an-apng-image-adjusting-pixel-data-according-to-the-selected-filter-type.cs) |
| [apply-alpha-blending-with-0-opacity-to-verify-that-background-image-remains-unchanged-after-operation.cs](./apply-alpha-blending-with-0-opacity-to-verify-that-background-image-remains-unchanged-after-operation.cs) |
| [apply-alpha-blending-with-full-opacity-255-to-a-png-overlay-and-verify-no-transparency-loss.cs](./apply-alpha-blending-with-full-opacity-255-to-a-png-overlay-and-verify-no-transparency-loss.cs) |
| [apply-an-alpha-blending-filter-to-an-image-supplied-in-any-supported-format-producing-a-blended-output.cs](./apply-an-alpha-blending-filter-to-an-image-supplied-in-any-supported-format-producing-a-blended-output.cs) |
| [apply-an-alpha-blending-filter-to-an-image-using-the-provided-example-as-a-reference.cs](./apply-an-alpha-blending-filter-to-an-image-using-the-provided-example-as-a-reference.cs) |
| [apply-an-image-or-photo-filter-to-an-apng-file-modifying-pixel-data-while-preserving-animation-frames.cs](./apply-an-image-or-photo-filter-to-an-apng-file-modifying-pixel-data-while-preserving-animation-frames.cs) |
| [apply-built-in-image-and-photo-filter-effects-to-a-target-image-using-the-provided-filter-api.cs](./apply-built-in-image-and-photo-filter-effects-to-a-target-image-using-the-provided-filter-api.cs) |
| [apply-content-aware-fill-removal-on-a-jpeg-with-two-attempts-then-compare-result-with-telea-algorithm.cs](./apply-content-aware-fill-removal-on-a-jpeg-with-two-attempts-then-compare-result-with-telea-algorithm.cs) |
| [apply-feathering-of-radius-5-pixels-to-a-magic-wand-selection-before-saving-as-png.cs](./apply-feathering-of-radius-5-pixels-to-a-magic-wand-selection-before-saving-as-png.cs) |
| [apply-getfeathered-with-a-radius-of-5-pixels-to-smooth-mask-edges-on-a-high-resolution-tiff-image.cs](./apply-getfeathered-with-a-radius-of-5-pixels-to-smooth-mask-edges-on-a-high-resolution-tiff-image.cs) |
| [apply-image-and-photo-filters-to-define-the-watermark-position-on-a-target-image-file.cs](./apply-image-and-photo-filters-to-define-the-watermark-position-on-a-target-image-file.cs) |
| [apply-image-and-photo-filters-to-isolate-a-specific-color-region-using-the-magic-wand-selection-tool.cs](./apply-image-and-photo-filters-to-isolate-a-specific-color-region-using-the-magic-wand-selection-tool.cs) |
| [apply-image-and-photo-filters-to-isolate-and-process-a-specific-color-region-within-an-image.cs](./apply-image-and-photo-filters-to-isolate-and-process-a-specific-color-region-within-an-image.cs) |
| [apply-image-and-photo-filters-to-remove-watermarks-from-a-given-image-while-preserving-visual-quality.cs](./apply-image-and-photo-filters-to-remove-watermarks-from-a-given-image-while-preserving-visual-quality.cs) |
| [apply-image-and-photo-filters-using-the-magic-wand-filter-to-a-specified-image.cs](./apply-image-and-photo-filters-using-the-magic-wand-filter-to-a-specified-image.cs) |
| [apply-image-and-photo-filters-with-the-magic-wand-tool-to-an-image-file.cs](./apply-image-and-photo-filters-with-the-magic-wand-tool-to-an-image-file.cs) |
| *...and 108 more files — [View all ↗](https://github.com/aspose-imaging/agentic-net-examples/tree/main/image-and-photo-filters)* |

## Requirements

- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** (or later) runtime
- Visual Studio 2022 (or any compatible IDE)

## Back to Main README

[← Back to the repository root README](../README.md)