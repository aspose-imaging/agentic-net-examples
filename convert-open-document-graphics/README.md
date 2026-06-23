# ODG conversion C# – Convert OpenDocument Graphics with Aspose.Imaging for .NET

This folder contains practical C# snippets that demonstrate how to work with **OpenDocument graphics (ODG)** using Aspose.Imaging for .NET.  
The examples cover loading an ODG file, rasterizing it, and exporting it to popular raster formats such as PNG, JPEG, BMP, and more – all within a .NET 9+ environment.

## What's in This Category
- Load an ODG file and save it as a PNG image (`Image.Save` with `PngOptions`).
- Convert an ODG file to JPEG using default compression settings (`JpegOptions`).
- Export an ODG file to BMP while preserving the original dimensions (`BmpOptions` + `OdgRasterizationOptions`).
- (Additional examples) Convert ODG to other raster formats or adjust rasterization parameters.

## Quick Start
The most common scenario is converting an ODG document to a PNG image:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load the ODG file
        using (Image odgImage = Image.Load("sample.odg"))
        {
            // Define PNG export options (optional)
            var pngOptions = new PngOptions();

            // Save as PNG
            odgImage.Save("output.png", pngOptions);
        }
    }
}
```

Add the Aspose.Imaging NuGet package to your project and run the snippet – the ODG will be rasterized and saved as `output.png`.

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [apply-a-gaussian-blur-filter-to-an-odg-image-before-converting-and-saving-as-jpeg.cs](./apply-a-gaussian-blur-filter-to-an-odg-image-before-converting-and-saving-as-jpeg.cs) |
| [apply-a-gaussian-blur-filter-to-an-otg-image-before-converting-and-saving-as-jpeg.cs](./apply-a-gaussian-blur-filter-to-an-otg-image-before-converting-and-saving-as-jpeg.cs) |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs) |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-jpeg.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-jpeg.cs) |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs) |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs) |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-jpeg.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-jpeg.cs) |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs) |
| [apply-a-specific-icc-color-profile-to-an-odg-image-before-saving-it-as-png.cs](./apply-a-specific-icc-color-profile-to-an-odg-image-before-saving-it-as-png.cs) |
| [apply-a-specific-icc-color-profile-to-an-otg-image-before-saving-it-as-png.cs](./apply-a-specific-icc-color-profile-to-an-otg-image-before-saving-it-as-png.cs) |
| [configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-odg-to-png-for-smoother-visual-results.cs](./configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-odg-to-png-for-smoother-visual-results.cs) |
| [configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-otg-to-png-for-smoother-results.cs](./configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-otg-to-png-for-smoother-results.cs) |
| [convert-an-odg-file-to-bmp-and-apply-a-threshold-filter-to-create-a-binary-image.cs](./convert-an-odg-file-to-bmp-and-apply-a-threshold-filter-to-create-a-binary-image.cs) |
| [convert-an-odg-file-to-bmp-and-set-the-background-color-to-white-during-rasterization.cs](./convert-an-odg-file-to-bmp-and-set-the-background-color-to-white-during-rasterization.cs) |
| [convert-an-odg-file-to-bmp-and-specify-a-custom-resolution-of-150-dpi.cs](./convert-an-odg-file-to-bmp-and-specify-a-custom-resolution-of-150-dpi.cs) |
| [convert-an-odg-file-to-bmp-using-an-8-bit-palette-to-reduce-file-size.cs](./convert-an-odg-file-to-bmp-using-an-8-bit-palette-to-reduce-file-size.cs) |
| [convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) |
| [convert-an-odg-file-to-jpeg-and-embed-an-icc-profile-for-color-management.cs](./convert-an-odg-file-to-jpeg-and-embed-an-icc-profile-for-color-management.cs) |
| [convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) |
| [convert-an-odg-file-to-jpeg-and-specify-custom-chroma-subsampling-for-color-fidelity.cs](./convert-an-odg-file-to-jpeg-and-specify-custom-chroma-subsampling-for-color-fidelity.cs) |
| [convert-an-odg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs](./convert-an-odg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs) |
| [convert-an-odg-file-to-jpeg-while-preserving-exif-orientation-metadata-in-the-output.cs](./convert-an-odg-file-to-jpeg-while-preserving-exif-orientation-metadata-in-the-output.cs) |
| [convert-an-odg-file-to-pdf-and-add-password-protection-to-restrict-access.cs](./convert-an-odg-file-to-pdf-and-add-password-protection-to-restrict-access.cs) |
| [convert-an-odg-file-to-pdf-and-embed-the-necessary-fonts-for-accurate-rendering.cs](./convert-an-odg-file-to-pdf-and-embed-the-necessary-fonts-for-accurate-rendering.cs) |
| [convert-an-odg-file-to-pdf-and-embed-xmp-metadata-for-enhanced-document-information.cs](./convert-an-odg-file-to-pdf-and-embed-xmp-metadata-for-enhanced-document-information.cs) |
| [convert-an-odg-file-to-pdf-and-flatten-annotations-to-produce-a-static-document.cs](./convert-an-odg-file-to-pdf-and-flatten-annotations-to-produce-a-static-document.cs) |
| [convert-an-odg-file-to-pdf-and-include-custom-metadata-such-as-author-and-title.cs](./convert-an-odg-file-to-pdf-and-include-custom-metadata-such-as-author-and-title.cs) |
| [convert-an-odg-file-to-pdf-and-set-a-custom-author-property-in-the-document-metadata.cs](./convert-an-odg-file-to-pdf-and-set-a-custom-author-property-in-the-document-metadata.cs) |
| [convert-an-odg-file-to-pdf-and-set-a-specific-compression-level-for-the-output.cs](./convert-an-odg-file-to-pdf-and-set-a-specific-compression-level-for-the-output.cs) |
| [convert-an-odg-file-to-pdf-and-set-the-document-title-property-in-the-metadata.cs](./convert-an-odg-file-to-pdf-and-set-the-document-title-property-in-the-metadata.cs) |
| *...and 90 more files — [View all ↗](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-open-document-graphics)* |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** or later

[← Back to main README](../README.md)