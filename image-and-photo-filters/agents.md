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

## Scope
- This folder contains examples for **Image and Photo Filters**.
- Files are standalone `.cs` examples stored directly in this folder.

## Required Namespaces

- `using Aspose.Imaging;` (59/64 files) ← category-specific
- `using System;` (56/64 files)
- `using Aspose.Imaging.ImageOptions;` (48/64 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (28/64 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (21/64 files) ← category-specific
- `using System.IO;` (19/64 files)
- `using Aspose.Imaging.Sources;` (19/64 files) ← category-specific
- `using Aspose.Imaging.MagicWand;` (17/64 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (17/64 files) ← category-specific
- `using Aspose.Imaging.MagicWand.ImageMasks;` (13/64 files) ← category-specific
- `using Aspose.Imaging.Watermark;` (12/64 files) ← category-specific
- `using Aspose.Imaging.Watermark.Options;` (12/64 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (12/64 files) ← category-specific
- `using System.Drawing;` (4/64 files)
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (1/64 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (1/64 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (1/64 files) ← category-specific
- `using System.Collections.Generic;` (1/64 files)

## Common Code Pattern

Most files follow this pattern:

```csharp
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load("input.png"))
{
    // ... operations ...
    image.Save("output.png");
}
```

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [apply-an-alpha-blending-filter-to-an-image-supplied-in-any-supported-format-producing-a-blended-output.cs](./apply-an-alpha-blending-filter-to-an-image-supplied-in-any-supported-format-producing-a-blended-output.cs) | `RasterImage` | Apply an Alpha Blending filter to an image supplied in any supported format, pro... |
| [apply-the-magic-wand-filter-to-select-a-region-in-an-image-of-any-supported-format-and-modify-it.cs](./apply-the-magic-wand-filter-to-select-a-region-in-an-image-of-any-supported-format-and-modify-it.cs) | `PngOptions`, `RasterImage` | Apply the Magic Wand filter to select a region in an image of any supported form... |
| [apply-the-remove-watermark-filter-to-eliminate-watermarks-from-images-regardless-of-supported-input-format.cs](./apply-the-remove-watermark-filter-to-eliminate-watermarks-from-images-regardless-of-supported-input-format.cs) | `RasterImage`, `TeleaWatermarkOptions` | Apply the Remove Watermark filter to eliminate watermarks from images regardless... |
| [utilize-image-and-photo-filter-functions-to-process-images-of-any-supported-format-programmatically.cs](./utilize-image-and-photo-filter-functions-to-process-images-of-any-supported-format-programmatically.cs) | `PngOptions`, `RasterImage` | Utilize image and photo filter functions to process images of any supported form... |
| [examine-the-image-and-photo-filters-overview-to-become-familiar-with-available-image-filtering-options.cs](./examine-the-image-and-photo-filters-overview-to-become-familiar-with-available-image-filtering-options.cs) | `BilateralSmoothingFilterOptions`, `GaussianBlurFilterOptions`, `MedianFilterOptions` | Examine the Image and Photo Filters overview to become familiar with available i... |
| [determine-the-available-image-filters-and-devise-a-strategy-for-applying-them-within-the-processing-pipeline.cs](./determine-the-available-image-filters-and-devise-a-strategy-for-applying-them-within-the-processing-pipeline.cs) | `BilateralSmoothingFilterOptions`, `GaussWienerFilterOptions`, `GaussianBlurFilterOptions` | Determine the available image filters and devise a strategy for applying them wi... |
| [apply-the-defined-image-filters-to-the-target-images-following-the-specifications-outlined-in-the-applying-filters-guidelines.cs](./apply-the-defined-image-filters-to-the-target-images-following-the-specifications-outlined-in-the-applying-filters-guidelines.cs) |  | Apply the defined image filters to the target images following the specification... |
| [apply-an-alpha-blending-filter-to-an-image-using-the-provided-example-as-a-reference.cs](./apply-an-alpha-blending-filter-to-an-image-using-the-provided-example-as-a-reference.cs) | `PngOptions`, `RasterImage` | Apply an Alpha Blending filter to an image using the provided example as a refer... |
| [implement-the-magic-wand-filter-on-an-image-reproducing-the-behavior-demonstrated-in-the-provided-example.cs](./implement-the-magic-wand-filter-on-an-image-reproducing-the-behavior-demonstrated-in-the-provided-example.cs) | `PngOptions`, `RasterImage` | Implement the Magic Wand filter on an image, reproducing the behavior demonstrat... |
| [eliminate-the-watermark-from-an-image-by-implementing-the-procedure-demonstrated-in-the-provided-example.cs](./eliminate-the-watermark-from-an-image-by-implementing-the-procedure-demonstrated-in-the-provided-example.cs) | `PngImage`, `TeleaWatermarkOptions` | Eliminate the watermark from an image by implementing the procedure demonstrated... |
| [provide-a-concise-summary-describing-how-each-applied-filter-alters-image-appearance-and-characteristics.cs](./provide-a-concise-summary-describing-how-each-applied-filter-alters-image-appearance-and-characteristics.cs) |  | Provide a concise summary describing how each applied filter alters image appear... |
| [apply-the-alpha-blending-filter-to-combine-an-image-with-a-specified-color-and-opacity-across-supported-formats.cs](./apply-the-alpha-blending-filter-to-combine-an-image-with-a-specified-color-and-opacity-across-supported-formats.cs) | `BmpOptions`, `GifOptions`, `JpegOptions` | Apply the Alpha Blending filter to combine an image with a specified color and o... |
| [apply-the-alpha-blending-filter-to-an-image-to-combine-pixel-values-based-on-specified-opacity-levels.cs](./apply-the-alpha-blending-filter-to-an-image-to-combine-pixel-values-based-on-specified-opacity-levels.cs) | `PngOptions`, `RasterImage` | Apply the alpha blending filter to an image to combine pixel values based on spe... |
| [examine-the-alpha-blending-image-filter-overview-to-understand-its-blending-algorithm-and-usage-parameters.cs](./examine-the-alpha-blending-image-filter-overview-to-understand-its-blending-algorithm-and-usage-parameters.cs) | `JpegOptions`, `RasterImage` | Examine the Alpha Blending image filter overview to understand its blending algo... |
| [set-up-the-alpha-blending-filter-by-specifying-blend-color-opacity-and-blending-mode-parameters.cs](./set-up-the-alpha-blending-filter-by-specifying-blend-color-opacity-and-blending-mode-parameters.cs) | `ImageBlendingFilterOptions`, `PngOptions`, `RasterImage` | Set up the Alpha Blending filter by specifying blend color, opacity, and blendin... |
| [run-the-provided-code-sample-to-blend-an-image-using-a-specified-color-and-opacity.cs](./run-the-provided-code-sample-to-blend-an-image-using-a-specified-color-and-opacity.cs) | `Graphics`, `JpegOptions`, `RasterImage` | Run the provided code sample to blend an image using a specified color and opaci... |
| [inspect-the-output-image-after-applying-the-alpha-blending-filter-to-verify-blending-effects.cs](./inspect-the-output-image-after-applying-the-alpha-blending-filter-to-verify-blending-effects.cs) | `ImageBlendingFilterOptions`, `PngOptions`, `RasterImage` | Inspect the output image after applying the Alpha Blending filter to verify blen... |
| [use-the-magic-wand-filter-to-select-a-color-similar-region-and-fill-it-with-a-color-for-any-supported-format.cs](./use-the-magic-wand-filter-to-select-a-color-similar-region-and-fill-it-with-a-color-for-any-supported-format.cs) | `PngOptions`, `RasterImage` | Use the Magic Wand filter to select a color‑similar region and fill it with a co... |
| [apply-a-magic-wand-selection-filter-to-the-image-to-isolate-contiguous-regions-based-on-color-similarity.cs](./apply-a-magic-wand-selection-filter-to-the-image-to-isolate-contiguous-regions-based-on-color-similarity.cs) | `PngOptions`, `RasterImage` | Apply a Magic Wand selection filter to the image to isolate contiguous regions b... |
| [examine-the-magic-wand-filter-overview-to-understand-its-functionality-and-applicable-use-cases.cs](./examine-the-magic-wand-filter-overview-to-understand-its-functionality-and-applicable-use-cases.cs) | `PngOptions`, `RasterImage` | Examine the Magic Wand filter overview to understand its functionality and appli... |
| [configure-the-magic-wand-filter-by-specifying-tolerance-fill-color-and-border-color-parameters.cs](./configure-the-magic-wand-filter-by-specifying-tolerance-fill-color-and-border-color-parameters.cs) | `PngOptions` | Configure the Magic Wand filter by specifying tolerance, fill color, and border ... |
| [execute-the-sample-to-apply-the-magic-wand-filter-for-region-selection-and-filling.cs](./execute-the-sample-to-apply-the-magic-wand-filter-for-region-selection-and-filling.cs) | `PngOptions`, `RasterImage` | Execute the sample to apply the Magic Wand filter for region selection and filli... |
| [render-the-outcome-of-applying-the-magic-wand-filter-to-the-image-for-visual-verification.cs](./render-the-outcome-of-applying-the-magic-wand-filter-to-the-image-for-visual-verification.cs) | `PngOptions`, `RasterImage` | Render the outcome of applying the Magic Wand filter to the image for visual ver... |
| [detect-and-eliminate-watermarks-from-images-using-the-remove-watermark-filter-for-any-supported-format.cs](./detect-and-eliminate-watermarks-from-images-using-the-remove-watermark-filter-for-any-supported-format.cs) | `RasterImage`, `TeleaWatermarkOptions` | Detect and eliminate watermarks from images using the Remove Watermark filter fo... |
| [apply-the-remove-watermark-filter-on-an-image-to-eliminate-embedded-watermarks-while-preserving-image-quality.cs](./apply-the-remove-watermark-filter-on-an-image-to-eliminate-embedded-watermarks-while-preserving-image-quality.cs) | `PngImage`, `TeleaWatermarkOptions` | Apply the Remove Watermark filter on an image to eliminate embedded watermarks w... |
| [examine-the-remove-watermark-filter-overview-to-understand-its-functionality-and-usage-parameters-within-the-library.cs](./examine-the-remove-watermark-filter-overview-to-understand-its-functionality-and-usage-parameters-within-the-library.cs) | `PngOptions`, `RasterImage` | Examine the Remove Watermark filter overview to understand its functionality and... |
| [configure-the-remove-watermark-filter-by-defining-watermark-color-and-appropriate-threshold-parameters-clearly.cs](./configure-the-remove-watermark-filter-by-defining-watermark-color-and-appropriate-threshold-parameters-clearly.cs) | `PngImage`, `TeleaWatermarkOptions` | Configure the Remove Watermark filter by defining watermark color and appropriat... |
| [run-the-provided-code-to-programmatically-strip-the-existing-watermark-from-the-target-image-file.cs](./run-the-provided-code-to-programmatically-strip-the-existing-watermark-from-the-target-image-file.cs) | `RasterImage`, `TeleaWatermarkOptions` | Run the provided code to programmatically strip the existing watermark from the ... |
| [validate-the-image-output-after-watermark-removal-to-ensure-visual-integrity-and-expected-dimensions.cs](./validate-the-image-output-after-watermark-removal-to-ensure-visual-integrity-and-expected-dimensions.cs) | `PngImage`, `TeleaWatermarkOptions` | Validate the image output after watermark removal to ensure visual integrity and... |
| [utilize-image-and-photo-filters-to-eliminate-a-watermark-from-a-given-image-while-maintaining-visual-fidelity.cs](./utilize-image-and-photo-filters-to-eliminate-a-watermark-from-a-given-image-while-maintaining-visual-fidelity.cs) | `PngImage`, `TeleaWatermarkOptions` | Utilize image and photo filters to eliminate a watermark from a given image whil... |
| [utilize-image-processing-filters-to-detect-and-eliminate-watermarks-from-a-given-image-file.cs](./utilize-image-processing-filters-to-detect-and-eliminate-watermarks-from-a-given-image-file.cs) | `PngImage`, `TeleaWatermarkOptions` | Utilize image processing filters to detect and eliminate watermarks from a given... |
| [utilize-image-processing-filters-to-detect-and-eliminate-watermarks-from-photos-within-a-given-image.cs](./utilize-image-processing-filters-to-detect-and-eliminate-watermarks-from-photos-within-a-given-image.cs) | `RasterImage` | Utilize image processing filters to detect and eliminate watermarks from photos ... |
| [apply-image-and-photo-filters-to-isolate-a-specific-color-region-using-the-magic-wand-selection-tool.cs](./apply-image-and-photo-filters-to-isolate-a-specific-color-region-using-the-magic-wand-selection-tool.cs) | `PngOptions`, `RasterImage` | Apply image and photo filters to isolate a specific color region using the Magic... |
| [remove-the-background-from-an-image-by-applying-the-magic-wand-filter-within-the-image-processing-library.cs](./remove-the-background-from-an-image-by-applying-the-magic-wand-filter-within-the-image-processing-library.cs) | `PngOptions`, `RasterImage` | Remove the background from an image by applying the Magic Wand filter within the... |
| [apply-image-and-photo-filters-to-isolate-and-process-a-specific-color-region-within-an-image.cs](./apply-image-and-photo-filters-to-isolate-and-process-a-specific-color-region-within-an-image.cs) | `PngOptions`, `RasterImage` | Apply image and photo filters to isolate and process a specific color region wit... |
| [apply-built-in-image-and-photo-filter-effects-to-a-target-image-using-the-provided-filter-api.cs](./apply-built-in-image-and-photo-filter-effects-to-a-target-image-using-the-provided-filter-api.cs) | `PngOptions`, `RasterImage` | Apply built‑in image and photo filter effects to a target image using the provid... |
| [apply-the-alpha-blending-filter-to-an-image-to-combine-visual-layers-with-adjustable-opacity.cs](./apply-the-alpha-blending-filter-to-an-image-to-combine-visual-layers-with-adjustable-opacity.cs) | `JpegOptions` | Apply the Alpha Blending filter to an image to combine visual layers with adjust... |
| [apply-image-and-photo-filters-with-the-magic-wand-tool-to-an-image-file.cs](./apply-image-and-photo-filters-with-the-magic-wand-tool-to-an-image-file.cs) | `GaussianBlurFilterOptions`, `PngOptions`, `RasterImage` | Apply image and photo filters with the Magic Wand tool to an IMAGE file. |
| [apply-image-and-photo-filters-using-the-magic-wand-filter-to-a-specified-image.cs](./apply-image-and-photo-filters-using-the-magic-wand-filter-to-a-specified-image.cs) | `PngOptions`, `RasterImage` | Apply image and photo filters using the Magic Wand filter to a specified image. |
| [apply-image-and-photo-filters-to-define-the-watermark-position-on-a-target-image-file.cs](./apply-image-and-photo-filters-to-define-the-watermark-position-on-a-target-image-file.cs) | `GaussianBlurFilterOptions`, `PngImage`, `PngOptions` | Apply image and photo filters to define the watermark position on a target image... |
| [apply-image-and-photo-filters-to-remove-watermarks-from-a-given-image-while-preserving-visual-quality.cs](./apply-image-and-photo-filters-to-remove-watermarks-from-a-given-image-while-preserving-visual-quality.cs) | `PngImage`, `TeleaWatermarkOptions` | Apply image and photo filters to remove watermarks from a given image while pres... |
| [chain-and-apply-multiple-image-filters-sequentially-to-an-apng-file-to-achieve-cumulative-effects.cs](./chain-and-apply-multiple-image-filters-sequentially-to-an-apng-file-to-achieve-cumulative-effects.cs) | `ApngImage` | Chain and apply multiple image filters sequentially to an APNG file to achieve c... |
| [implement-an-image-filter-that-enables-chaining-multiple-filters-sequentially-on-an-apng-image.cs](./implement-an-image-filter-that-enables-chaining-multiple-filters-sequentially-on-an-apng-image.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Implement an image filter that enables chaining multiple filters sequentially on... |
| [apply-a-specified-image-filter-to-each-raster-frame-within-an-apng-image-while-maintaining-animation-integrity.cs](./apply-a-specified-image-filter-to-each-raster-frame-within-an-apng-image-while-maintaining-animation-integrity.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Apply a specified image filter to each raster frame within an APNG image while m... |
| [apply-an-image-or-photo-filter-to-an-apng-file-modifying-pixel-data-while-preserving-animation-frames.cs](./apply-an-image-or-photo-filter-to-an-apng-file-modifying-pixel-data-while-preserving-animation-frames.cs) | `ApngFrame`, `ApngImage` | Apply an Image or Photo filter to an APNG file, modifying pixel data while prese... |
| [apply-a-supported-filter-to-an-apng-image-adjusting-pixel-data-according-to-the-selected-filter-type.cs](./apply-a-supported-filter-to-an-apng-image-adjusting-pixel-data-according-to-the-selected-filter-type.cs) | `ApngImage`, `MedianFilterOptions` | Apply a supported filter to an APNG image, adjusting pixel data according to the... |
| [apply-a-specified-image-filter-to-an-apng-file-ensuring-correct-handling-of-its-animation-frames.cs](./apply-a-specified-image-filter-to-an-apng-file-ensuring-correct-handling-of-its-animation-frames.cs) | `ApngImage`, `ApngOptions`, `GaussianBlurFilterOptions` | Apply a specified image filter to an APNG file, ensuring correct handling of its... |
| [apply-a-specified-filter-to-an-apng-image-modifying-each-frame-while-preserving-animation-properties.cs](./apply-a-specified-filter-to-an-apng-image-modifying-each-frame-while-preserving-animation-properties.cs) | `ApngImage`, `GaussianBlurFilterOptions` | Apply a specified filter to an APNG image, modifying each frame while preserving... |
| [apply-the-alphablendingimagefilter-to-an-apng-image-to-blend-pixel-transparency-effectively-as-specified.cs](./apply-the-alphablendingimagefilter-to-an-apng-image-to-blend-pixel-transparency-effectively-as-specified.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Apply the AlphaBlendingImageFilter to an APNG image to blend pixel transparency ... |
| [apply-the-alphablendingimagefilter-to-an-apng-image-directly-using-the-provided-image-filter-api.cs](./apply-the-alphablendingimagefilter-to-an-apng-image-directly-using-the-provided-image-filter-api.cs) | `AlphaBlendingImageFilter` | Apply the AlphaBlendingImageFilter to an APNG image directly using the provided ... |
| [blend-an-apng-image-with-a-chosen-color-and-opacity-using-an-image-filter.cs](./blend-an-apng-image-with-a-chosen-color-and-opacity-using-an-image-filter.cs) | `ApngImage`, `ApngOptions`, `Graphics` | Blend an APNG image with a chosen color and opacity using an image filter. |
| [apply-a-filter-to-an-apng-image-allowing-custom-blending-color-selection-and-configurable-opacity-level.cs](./apply-a-filter-to-an-apng-image-allowing-custom-blending-color-selection-and-configurable-opacity-level.cs) | `ApngImage`, `ApngOptions`, `Graphics` | Apply a filter to an APNG image allowing custom blending color selection and con... |
| [apply-the-alpha-blending-filter-to-an-apng-image-to-blend-pixel-colors-based-on-their-alpha-values.cs](./apply-the-alpha-blending-filter-to-an-apng-image-to-blend-pixel-colors-based-on-their-alpha-values.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Apply the Alpha Blending filter to an APNG image to blend pixel colors based on ... |
| [apply-a-specified-image-filter-during-construction-of-an-apng-image-object-to-transform-pixel-data.cs](./apply-a-specified-image-filter-during-construction-of-an-apng-image-object-to-transform-pixel-data.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Apply a specified image filter during construction of an APNG image object to tr... |
| [apply-a-filter-to-an-apng-image-and-set-its-configuration-properties-as-desired.cs](./apply-a-filter-to-an-apng-image-and-set-its-configuration-properties-as-desired.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Apply a filter to an APNG image and set its configuration properties as desired. |
| [apply-the-specified-image-filter-to-an-apng-file-replicating-the-behavior-demonstrated-in-the-example.cs](./apply-the-specified-image-filter-to-an-apng-file-replicating-the-behavior-demonstrated-in-the-example.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Apply the specified image filter to an APNG file, replicating the behavior demon... |
| [apply-the-magicwandfilter-to-target-and-process-a-selected-region-within-an-apng-image.cs](./apply-the-magicwandfilter-to-target-and-process-a-selected-region-within-an-apng-image.cs) | `ApngOptions`, `RasterImage` | Apply the MagicWandFilter to target and process a selected region within an APNG... |
| [use-magicwandfilter-to-select-and-process-a-specific-region-within-an-apng-image-efficiently.cs](./use-magicwandfilter-to-select-and-process-a-specific-region-within-an-apng-image-efficiently.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Use MagicWandFilter to select and process a specific region within an APNG image... |
| [apply-a-color-similarity-filter-to-isolate-a-region-within-an-apng-image-based-on-pixel-hue.cs](./apply-a-color-similarity-filter-to-isolate-a-region-within-an-apng-image-based-on-pixel-hue.cs) | `ApngOptions`, `RasterImage` | Apply a color‑similarity filter to isolate a region within an APNG image based o... |
| [apply-the-magic-wand-filter-to-an-apng-image-to-modify-its-pixel-data-according-to-specified-criteria.cs](./apply-the-magic-wand-filter-to-an-apng-image-to-modify-its-pixel-data-according-to-specified-criteria.cs) | `ApngImage` | Apply the Magic Wand filter to an APNG image to modify its pixel data according ... |
| [use-removewatermarkfilter-to-eliminate-watermarks-from-apng-images-while-preserving-visual-fidelity-and-metadata.cs](./use-removewatermarkfilter-to-eliminate-watermarks-from-apng-images-while-preserving-visual-fidelity-and-metadata.cs) | `ApngOptions`, `RasterImage` | Use RemoveWatermarkFilter to eliminate watermarks from APNG images while preserv... |
| [use-removewatermarkfilter-to-programmatically-eliminate-watermarks-from-an-apng-image-while-preserving-visual-integrity.cs](./use-removewatermarkfilter-to-programmatically-eliminate-watermarks-from-an-apng-image-while-preserving-visual-integrity.cs) | `ApngImage`, `ApngOptions` | Use RemoveWatermarkFilter to programmatically eliminate watermarks from an APNG ... |
| [remove-watermarks-from-an-apng-image-by-applying-an-appropriate-filter-that-detects-and-eliminates-embedded-marks.cs](./remove-watermarks-from-an-apng-image-by-applying-an-appropriate-filter-that-detects-and-eliminates-embedded-marks.cs) | `ApngImage`, `RasterImage`, `TeleaWatermarkOptions` | Remove watermarks from an APNG image by applying an appropriate filter that dete... |
| [apply-the-remove-watermark-filter-to-an-apng-image-to-successfully-eliminate-embedded-watermarks.cs](./apply-the-remove-watermark-filter-to-an-apng-image-to-successfully-eliminate-embedded-watermarks.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Apply the Remove Watermark filter to an APNG image to successfully eliminate emb... |

## Category Statistics
- Total examples: 64
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `AlphaBlendingImageFilter`
- `ApngFrame`
- `ApngImage`
- `ApngOptions`
- `BilateralSmoothingFilterOptions`
- `BmpOptions`
- `GaussWienerFilterOptions`
- `GaussianBlurFilterOptions`
- `GifOptions`
- `Graphics`
- `ImageBlendingFilterOptions`
- `JpegOptions`
- `MedianFilterOptions`
- `MotionWienerFilterOptions`
- `PdfOptions`
- `PngImage`
- `PngOptions`
- `RasterImage`
- `TeleaWatermarkOptions`

## All Tasks

| Task ID | Description | Status |
|---------|-------------|--------|
| 13366 | Apply an Alpha Blending filter to an image supplied in any supported format, producing a b | ✅ |
| 13367 | Apply the Magic Wand filter to select a region in an image of any supported format and mod | ✅ |
| 13368 | Apply the Remove Watermark filter to eliminate watermarks from images regardless of suppor | ✅ |
| 13369 | Utilize image and photo filter functions to process images of any supported format program | ✅ |
| 13370 | Examine the Image and Photo Filters overview to become familiar with available image filte | ✅ |
| 13371 | Determine the available image filters and devise a strategy for applying them within the p | ✅ |
| 13372 | Apply the defined image filters to the target images following the specifications outlined | ✅ |
| 13373 | Apply an Alpha Blending filter to an image using the provided example as a reference. | ✅ |
| 13374 | Implement the Magic Wand filter on an image, reproducing the behavior demonstrated in the  | ✅ |
| 13375 | Eliminate the watermark from an image by implementing the procedure demonstrated in the pr | ✅ |
| 13376 | Provide a concise summary describing how each applied filter alters image appearance and c | ✅ |
| 13377 | Apply the Alpha Blending filter to combine an image with a specified color and opacity acr | ✅ |
| 13378 | Apply the alpha blending filter to an image to combine pixel values based on specified opa | ✅ |
| 13379 | Examine the Alpha Blending image filter overview to understand its blending algorithm and  | ✅ |
| 13380 | Set up the Alpha Blending filter by specifying blend color, opacity, and blending mode par | ✅ |
| 13381 | Run the provided code sample to blend an image using a specified color and opacity. | ✅ |
| 13382 | Inspect the output image after applying the Alpha Blending filter to verify blending effec | ✅ |
| 13383 | Use the Magic Wand filter to select a color‑similar region and fill it with a color for an | ✅ |
| 13384 | Apply a Magic Wand selection filter to the image to isolate contiguous regions based on co | ✅ |
| 13385 | Examine the Magic Wand filter overview to understand its functionality and applicable use  | ✅ |
| 13386 | Configure the Magic Wand filter by specifying tolerance, fill color, and border color para | ✅ |
| 13387 | Execute the sample to apply the Magic Wand filter for region selection and filling. | ✅ |
| 13388 | Render the outcome of applying the Magic Wand filter to the image for visual verification. | ✅ |
| 13389 | Detect and eliminate watermarks from images using the Remove Watermark filter for any supp | ✅ |
| 13390 | Apply the Remove Watermark filter on an image to eliminate embedded watermarks while prese | ✅ |
| 13391 | Examine the Remove Watermark filter overview to understand its functionality and usage par | ✅ |
| 13392 | Configure the Remove Watermark filter by defining watermark color and appropriate threshol | ✅ |
| 13393 | Run the provided code to programmatically strip the existing watermark from the target ima | ✅ |
| 13394 | Validate the image output after watermark removal to ensure visual integrity and expected  | ✅ |
| 14108 | Utilize image and photo filters to eliminate a watermark from a given image while maintain | ✅ |
| 14109 | Utilize image processing filters to detect and eliminate watermarks from a given image fil | ✅ |
| 14110 | Utilize image processing filters to detect and eliminate watermarks from photos within a g | ✅ |
| 14111 | Apply image and photo filters to isolate a specific color region using the Magic Wand sele | ✅ |
| 14112 | Remove the background from an image by applying the Magic Wand filter within the image pro | ✅ |
| 14113 | Apply image and photo filters to isolate and process a specific color region within an ima | ✅ |
| 14114 | Apply built‑in image and photo filter effects to a target image using the provided filter  | ✅ |
| 14115 | Apply the Alpha Blending filter to an image to combine visual layers with adjustable opaci | ✅ |
| 14116 | Apply image and photo filters with the Magic Wand tool to an IMAGE file. | ✅ |
| 14118 | Apply image and photo filters using the Magic Wand filter to a specified image. | ✅ |
| 14121 | Apply image and photo filters to define the watermark position on a target image file. | ✅ |
| 14122 | Apply image and photo filters to remove watermarks from a given image while preserving vis | ✅ |
| 14302 | Chain and apply multiple image filters sequentially to an APNG file to achieve cumulative  | ✅ |
| 14303 | Implement an image filter that enables chaining multiple filters sequentially on an APNG i | ✅ |
| 14304 | Apply a specified image filter to each raster frame within an APNG image while maintaining | ✅ |
| 14305 | Apply an Image or Photo filter to an APNG file, modifying pixel data while preserving anim | ✅ |
| 14306 | Apply a supported filter to an APNG image, adjusting pixel data according to the selected  | ✅ |
| 14307 | Apply a specified image filter to an APNG file, ensuring correct handling of its animation | ✅ |
| 14308 | Apply a specified filter to an APNG image, modifying each frame while preserving animation | ✅ |
| 14309 | Apply the AlphaBlendingImageFilter to an APNG image to blend pixel transparency effectivel | ✅ |
| 14310 | Apply the AlphaBlendingImageFilter to an APNG image directly using the provided image filt | ✅ |
| 14311 | Blend an APNG image with a chosen color and opacity using an image filter. | ✅ |
| 14312 | Apply a filter to an APNG image allowing custom blending color selection and configurable  | ✅ |
| 14313 | Apply the Alpha Blending filter to an APNG image to blend pixel colors based on their alph | ✅ |
| 14314 | Apply a specified image filter during construction of an APNG image object to transform pi | ✅ |
| 14315 | Apply a filter to an APNG image and set its configuration properties as desired. | ✅ |
| 14316 | Apply the specified image filter to an APNG file, replicating the behavior demonstrated in | ✅ |
| 14317 | Apply the MagicWandFilter to target and process a selected region within an APNG image. | ✅ |
| 14318 | Use MagicWandFilter to select and process a specific region within an APNG image efficient | ✅ |
| 14319 | Apply a color‑similarity filter to isolate a region within an APNG image based on pixel hu | ✅ |
| 14320 | Apply the Magic Wand filter to an APNG image to modify its pixel data according to specifi | ✅ |
| 14324 | Use RemoveWatermarkFilter to eliminate watermarks from APNG images while preserving visual | ✅ |
| 14325 | Use RemoveWatermarkFilter to programmatically eliminate watermarks from an APNG image whil | ✅ |
| 14326 | Remove watermarks from an APNG image by applying an appropriate filter that detects and el | ✅ |
| 14327 | Apply the Remove Watermark filter to an APNG image to successfully eliminate embedded wate | ✅ |

## General Tips
- See parent [agents.md](../agents.md) for:
  - **Boundaries** - Always / Ask First / Never rules for all examples
  - **Common Mistakes** - verified anti-patterns that cause build failures
  - **Command Reference** - build and run commands
  - **Testing Guide** - build and run verification steps
- Review code examples in this folder for Image and Photo Filters patterns

<!-- AUTOGENERATED:START -->
Updated: 2026-03-15 | Run: `20260315_134541` | Examples: 64
<!-- AUTOGENERATED:END -->