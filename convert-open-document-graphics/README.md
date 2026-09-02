# Apply Gaussian Blur to ODG Image and Save as JPEG in C#

This repository contains ready‑to‑run C# examples that demonstrate how to work with **Open Document Graphics (ODG)** files using **Aspose.Imaging for .NET** – a UI‑agnostic backend API that runs everywhere (ASP.NET Core, console apps, Azure Functions, Docker, etc.).  
The samples show how to:

* Apply a Gaussian blur filter to an ODG and export it as a JPEG.  
* Convert ODG to PNG while enabling anti‑aliasing for smoother visuals.  
* Generate a progressive JPEG from ODG for faster web loading.  
* Create a PDF from ODG with custom DPI and page margins.  
* Export ODG to SVG and ensure the `viewBox` attribute is set correctly.

## What You Can Do

- **Apply Gaussian blur to an ODG and save it as JPEG** – using `GaussianBlurFilterOption`.  
- **Convert ODG to PNG with anti‑aliasing** – by configuring `RasterizationOptions` for smoother results.  
- **Convert ODG to progressive JPEG** – with maximum quality and progressive encoding.  
- **Convert ODG to PDF** – specifying custom DPI and page margins for precise layout.  
- **Convert ODG to SVG** – and automatically correct the `viewBox` attribute.

## Quick Start

The most common scenario is applying a Gaussian blur to an ODG and exporting it as a JPEG:

```csharp
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        string inputPath  = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_blur.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load ODG, apply Gaussian blur, and save as JPEG
        using (Image image = Image.Load(inputPath))
        {
            var blur = new GaussianBlurFilterOption(5); // radius = 5
            image.Filter(blur);

            var jpegOptions = new JpegOptions { Quality = 90 };
            image.Save(outputPath, jpegOptions);
        }

        Console.WriteLine($"Blurred JPEG saved to {outputPath}");
    }
}
```

## Requirements

- .NET 9.0 (or later)  
- Aspose.Imaging for .NET  

Install the NuGet package:

```bash
dotnet add package Aspose.Imaging
```

## Resources

| Resource | Link |
|----------|------|
| Documentation | https://docs.aspose.com/imaging/net/ |
| NuGet | https://www.nuget.org/packages/aspose.imaging |
| Release Notes | https://releases.aspose.com/imaging/net/ |
| Online Apps | https://products.aspose.app/imaging/family/ |
| Free Temporary License | https://purchase.aspose.com/temporary-license |

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
[**View all 120 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-open-document-graphics)