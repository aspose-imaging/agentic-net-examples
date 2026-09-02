# Export PSD to PNG with Custom Fonts Using Aspose.Imaging C#

A quick collection of real‑world C# snippets that show how to **export a Photoshop PSD file to PNG while preserving custom font rendering** with Aspose.Imaging for .NET. The examples also cover contrast adjustment, noise‑reduction filters for APNG, batch conversion of CorelDRAW CDR files to PDF (vector shapes retained), and configuring multiple font folders for TIFF‑to‑PDF conversion. Aspose.Imaging is a UI‑agnostic backend API that runs everywhere – ASP.NET Core, console apps, Azure Functions, Docker containers, etc., without any UI dependencies.

## What You Can Do
- **Export a PSD as PNG with accurate text appearance** by loading user‑defined fonts into `FontSettings` before rendering.  
- **Adjust image contrast** on a PNG file with fine‑grained tonal control.  
- **Apply median and Wiener filters** to an APNG file for advanced noise reduction.  
- **Batch export multiple CDR files to individual PDF documents**, preserving vector shapes and text.  
- **Configure multiple font directories** when converting TIFF images to PDF to support diverse scripts.

## Quick Start
```csharp
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ExportPsdWithFonts
{
    static void Main()
    {
        string psdPath   = "input.psd";
        string pngPath   = "output.png";
        string fontsPath = "Fonts";

        // Load the PSD image
        using var image = Image.Load(psdPath);

        // Register custom fonts
        var fontSettings = new FontSettings();
        fontSettings.AddFontFolder(fontsPath, recursive: true);
        image.FontSettings = fontSettings;

        // Export to PNG preserving the custom font rendering
        var pngOptions = new PngOptions { ColorType = PngColorType.Truecolor };
        image.Save(pngPath, pngOptions);

        Console.WriteLine("Export completed.");
    }
}
```

## Requirements
- .NET 9.0 (or later)  
- Aspose.Imaging for .NET  

Install the library via NuGet:

```bash
dotnet add package Aspose.Imaging
```

## Resources
| Link | Description |
|------|-------------|
| [Documentation](https://docs.aspose.com/imaging/net/) | Official Aspose.Imaging API docs |
| [NuGet](https://www.nuget.org/packages/aspose.imaging) | Package repository |
| [Release Notes](https://releases.aspose.com/imaging/net/) | Latest version changes |
| [Online Apps](https://products.aspose.app/imaging/family/) | Try Aspose.Imaging features in the browser |
| [Free Temporary License](https://purchase.aspose.com/temporary-license) | Get a temporary license for evaluation |

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