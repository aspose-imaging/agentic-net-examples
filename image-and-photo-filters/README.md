# ImageGrayscaleMask Inversion and APNG Frame Filtering with Aspose.Imaging for .NET

This collection demonstrates how to work with **ImageGrayscaleMask** inversion for both white and black masks, apply custom filters to every raster frame of an APNG while keeping its animation properties intact, and use the **MagicWand** tool to isolate or modify specific pixel regions. The examples are built with Aspose.Imaging for .NET – a UI‑agnostic backend API that runs everywhere (ASP.NET Core, console apps, Azure Functions, Docker, etc.) without any UI dependencies.

## What You Can Do
- **Test mask inversion** – verify that `ImageGrayscaleMask` correctly inverts fully white and fully black masks (unit‑test example).  
- **Filter each APNG frame** – apply a user‑defined image filter to every raster frame of an APNG while preserving frame delays, disposal methods, and overall animation integrity.  
- **Isolate a color region with MagicWand** – select a specific color range in a PNG, create a mask, and process the isolated area.  
- **Modify APNG pixel data using MagicWand** – run a MagicWand‑based filter across all frames of an APNG to change pixels that meet custom criteria.  
- **Blend PNG overlay onto BMP background and export** – compute the center coordinates of a BMP, blend a PNG overlay, and save the result as a TIFF file.

## Quick Start
Below is a minimal snippet that applies a custom filter to every frame of an APNG while preserving its animation metadata:

```csharp
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath  = @"C:\Images\input_animation.apng";
        string outputPath = @"C:\Images\output_animation_filtered.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the APNG
        using (Image image = Image.Load(inputPath))
        {
            var apng = (ApngImage)image;

            // Iterate over each raster frame
            foreach (var frame in apng.Frames)
            {
                // Example filter: increase gamma (you can replace with any filter)
                frame.AdjustGamma(1.2f);
            }

            // Save while keeping original animation properties
            apng.Save(outputPath, new ApngOptions { ColorType = apng.ColorType });
        }

        Console.WriteLine($"Filtered APNG saved to {outputPath}");
    }
}
```

## Requirements
- .NET 9.0 (or later)
- Aspose.Imaging NuGet package  

```bash
dotnet add package Aspose.Imaging
```

## Resources

| Link | Description |
|------|-------------|
| [Documentation](https://docs.aspose.com/imaging/net/) | Official Aspose.Imaging for .NET docs |
| [NuGet](https://www.nuget.org/packages/aspose.imaging) | Package source |
| [Release Notes](https://releases.aspose.com/imaging/net/) | Latest changes and bug fixes |
| [Online Apps](https://products.aspose.app/imaging/family/) | Try Aspose.Imaging features in the browser |
| [Free Temporary License](https://purchase.aspose.com/temporary-license) | Get a temporary license for evaluation |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-unit-tests-that-verify-mask-inversion-works-correctly-for-both-fully-white-and-fully-black-initial-masks.cs](./add-unit-tests-that-verify-mask-inversion-works-correctly-for-both-fully-white-and-fully-black-initial-masks.cs) |
| [adjust-contentawarefillwatermarkoptions-maxpaintingattempts-to-3-to-improve-removal-quality-on-complex-watermark-patterns.cs](./adjust-contentawarefillwatermarkoptions-maxpaintingattempts-to-3-to-improve-removal-quality-on-complex-watermark-patterns.cs) |
| [adjust-contentawarefillwatermarkoptions-maxpaintingattempts-to-3-to-improve-removal-quality-on-complex-watermark.cs](./adjust-contentawarefillwatermarkoptions-maxpaintingattempts-to-3-to-improve-removal-quality-on-complex-watermark.cs) |
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
| [apply-the-alpha-blending-filter-to-an-apng-image-to-blend-pixel-colors-based-on-their-alpha-values.cs](./apply-the-alpha-blending-filter-to-an-apng-image-to-blend-pixel-colors-based-on-their-alpha-values.cs) |
[**View all 148 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/image-and-photo-filters)
