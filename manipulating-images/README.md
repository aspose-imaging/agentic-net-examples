# Image Manipulation C# with Aspose.Imaging

A collection of concise, ready‑to‑run C# snippets that demonstrate **image manipulation** using Aspose.Imaging for .NET.  
These examples cover common **image editing** tasks such as loading PNG files, applying auto‑masking, customizing mask feathering, and saving the processed result—perfect for developers looking to integrate resize, crop, rotate, and advanced masking into their .NET applications.

## What's in This Category
- Load a PNG image and apply auto‑masking with default graph‑cut strokes.  
- Create `AutoMaskingGraphCutOptions` with a custom feathering radius.  
- Define a point array for manual masking and apply it to a PNG.  
- Export the processed image using `PngOptions`.  

## Quick Start

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;

// Load a PNG image
using (RasterImage image = (RasterImage)Image.Load("input.png"))
{
    // Apply auto‑masking with default graph‑cut options
    var autoMask = new AutoMaskingGraphCutOptions();
    image.ApplyAutoMasking(autoMask);

    // Save the result
    var pngOptions = new PngOptions();
    image.Save("output.png", pngOptions);
}
```

The snippet above shows the most common workflow: load → auto‑mask → save. Add resizing, cropping, or rotation by using the corresponding `Resize`, `Crop`, or `Rotate` methods on the `RasterImage` instance.

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-user-defined-fonts-to-fontsettings-and-export-a-psd-as-png-with-accurate-text-appearance.cs](./add-user-defined-fonts-to-fontsettings-and-export-a-psd-as-png-with-accurate-text-appearance.cs) |
| [adjust-brightness-of-a-cdr-document-upward-fifteen-percent-and-save-the-result-as-a-tiff-file.cs](./adjust-brightness-of-a-cdr-document-upward-fifteen-percent-and-save-the-result-as-a-tiff-file.cs) |
| [adjust-brightness-of-a-tiff-image-then-apply-gaussian-blur-saving-the-final-picture-as-pdf.cs](./adjust-brightness-of-a-tiff-image-then-apply-gaussian-blur-saving-the-final-picture-as-pdf.cs) |
| [adjust-contrast-of-a-gif-picture-to-high-level-and-write-the-result-to-a-new-gif-file.cs](./adjust-contrast-of-a-gif-picture-to-high-level-and-write-the-result-to-a-new-gif-file.cs) |
| [adjust-contrast-of-a-tiff-image-then-apply-floyd-steinberg-dithering-saving-as-png.cs](./adjust-contrast-of-a-tiff-image-then-apply-floyd-steinberg-dithering-saving-as-png.cs) |
| [adjust-gamma-of-a-gif-picture-to-1-5-and-write-the-modified-frame-to-a-new-gif.cs](./adjust-gamma-of-a-gif-picture-to-1-5-and-write-the-modified-frame-to-a-new-gif.cs) |
| [adjust-gamma-of-a-gif-sequence-before-creating-an-animated-gif-with-balanced-luminance.cs](./adjust-gamma-of-a-gif-sequence-before-creating-an-animated-gif-with-balanced-luminance.cs) |
| [adjust-image-contrast-within-apng-files-applying-fine-tuned-contrast-modifications-while-preserving-animation-frames.cs](./adjust-image-contrast-within-apng-files-applying-fine-tuned-contrast-modifications-while-preserving-animation-frames.cs) |
| [adjust-the-brightness-of-images-encoded-in-apng-format-programmatically-using-the-provided-api.cs](./adjust-the-brightness-of-images-encoded-in-apng-format-programmatically-using-the-provided-api.cs) |
| [adjust-the-gamma-of-images-and-save-the-results-in-apng-format-preserving-transparency-and-animation.cs](./adjust-the-gamma-of-images-and-save-the-results-in-apng-format-preserving-transparency-and-animation.cs) |
| [after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs](./after-removing-background-from-a-vector-image-rasterize-it-to-png-using-pngoptions-with-default-compression.cs) |
| [align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs](./align-horizontal-and-vertical-dpi-of-a-raster-image-before-applying-any-correction-filters-for-consistent-scaling.cs) |
| [align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs](./align-resolutions-of-a-loaded-svg-before-rasterization-to-ensure-consistent-dpi-in-the-resulting-png-file.cs) |
| [analyze-the-confidence-percentage-of-an-embedded-digital-signature-in-a-jpeg-image-using-the-provided-password.cs](./analyze-the-confidence-percentage-of-an-embedded-digital-signature-in-a-jpeg-image-using-the-provided-password.cs) |
| [apply-a-45-degree-rotation-to-a-bmp-image-with-white-background-fill-and-store-the-output-in-a-file.cs](./apply-a-45-degree-rotation-to-a-bmp-image-with-white-background-fill-and-store-the-output-in-a-file.cs) |
| [apply-a-blur-effect-to-an-image-and-output-the-processed-result-in-apng-format-preserving-animation-characteristics.cs](./apply-a-blur-effect-to-an-image-and-output-the-processed-result-in-apng-format-preserving-animation-characteristics.cs) |
| [apply-a-correction-filter-to-an-image-and-save-the-result-in-apng-format-while-maintaining-transparency.cs](./apply-a-correction-filter-to-an-image-and-save-the-result-in-apng-format-while-maintaining-transparency.cs) |
| [apply-a-correction-filter-to-an-image-to-adjust-visual-properties-enhancing-contrast-brightness-and-color-balance.cs](./apply-a-correction-filter-to-an-image-to-adjust-visual-properties-enhancing-contrast-brightness-and-color-balance.cs) |
| [apply-a-custom-background-color-when-rotating-a-bmp-image-by-120-degrees-to-fill-empty-corners.cs](./apply-a-custom-background-color-when-rotating-a-bmp-image-by-120-degrees-to-fill-empty-corners.cs) |
| [apply-a-deskew-operation-to-correct-image-orientation-and-improve-visual-alignment-for-accurate-processing.cs](./apply-a-deskew-operation-to-correct-image-orientation-and-improve-visual-alignment-for-accurate-processing.cs) |
| [apply-a-gaussian-blur-filter-to-an-image-to-soften-details-while-maintaining-its-overall-dimensions.cs](./apply-a-gaussian-blur-filter-to-an-image-to-soften-details-while-maintaining-its-overall-dimensions.cs) |
| [apply-a-gaussian-wiener-filter-to-images-and-output-the-processed-results-in-apng-format.cs](./apply-a-gaussian-wiener-filter-to-images-and-output-the-processed-results-in-apng-format.cs) |
| [apply-a-gaussian-wiener-filter-to-images-to-effectively-reduce-noise-while-preserving-edge-details.cs](./apply-a-gaussian-wiener-filter-to-images-to-effectively-reduce-noise-while-preserving-edge-details.cs) |
| [apply-a-median-filter-to-images-and-output-the-results-in-apng-format-ensuring-pixel-level-noise-reduction.cs](./apply-a-median-filter-to-images-and-output-the-results-in-apng-format-ensuring-pixel-level-noise-reduction.cs) |
| [apply-a-median-filter-to-images-to-reduce-noise-while-preserving-edges-and-fine-details.cs](./apply-a-median-filter-to-images-to-reduce-noise-while-preserving-edges-and-fine-details.cs) |
| [apply-a-motion-wiener-filter-to-apng-images-to-reduce-motion-blur-while-preserving-animation-integrity.cs](./apply-a-motion-wiener-filter-to-apng-images-to-reduce-motion-blur-while-preserving-animation-integrity.cs) |
| [apply-a-motion-wiener-filter-to-images-to-reduce-noise-while-preserving-motion-details.cs](./apply-a-motion-wiener-filter-to-images-to-reduce-noise-while-preserving-motion-details.cs) |
| [apply-a-smoothing-mode-to-image-processing-operations-to-control-rendering-quality-and-reduce-visual-artifacts.cs](./apply-a-smoothing-mode-to-image-processing-operations-to-control-rendering-quality-and-reduce-visual-artifacts.cs) |
| [apply-a-smoothing-mode-to-image-processing-operations-when-generating-apng-files-to-improve-visual-quality.cs](./apply-a-smoothing-mode-to-image-processing-operations-when-generating-apng-files-to-improve-visual-quality.cs) |
| [apply-automatic-masking-to-images-and-output-the-result-in-apng-format-preserving-transparency-and-animation.cs](./apply-automatic-masking-to-images-and-output-the-result-in-apng-format-preserving-transparency-and-animation.cs) |
[**View all 425 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/manipulating-images)

## Requirements
- **Aspose.Imaging** NuGet package (latest version)  
- **.NET 9** or later  

```bash
dotnet add package Aspose.Imaging
```

## ↩️ Back to Main README
[← Return to the repository root README](../README.md)