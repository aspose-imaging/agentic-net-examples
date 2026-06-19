# Raster Image Conversion C# with Aspose.Imaging

Convert raster images, apply transformations, and export them to different formats using Aspose.Imaging for .NET. These examples demonstrate common bitmap conversion dotnet scenarios such as filtering, resizing, cropping, and saving to PDF or SVG.

## What's in This Category
- Apply a median filter to a BMP and save the result as a PDF.  
- Resize a PNG to a specific resolution and export directly to PDF.  
- Crop a raster image to a central square region before converting it to SVG.  
- Load, manipulate, and re‑encode bitmap images to other raster or vector formats.  
- Combine multiple image‑processing steps in a single workflow.

## Quick Start
```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load a raster image (any supported format)
using (RasterImage image = (RasterImage)Image.Load("input.png"))
{
    // Example: resize to 800x600
    image.Resize(800, 600);

    // Save as JPEG
    var jpegOptions = new JpegOptions { Quality = 90 };
    image.Save("output.jpg", jpegOptions);
}
```
The snippet shows the most common raster image conversion: load → resize → save in a different format.

## All Examples
| Example | Description |
|---|---|
| [load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs](./load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs) | Apply a median filter to a BMP and export the result as a PDF. |
| [resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs](./resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs) | Resize a PNG to 1024 × 768 and save directly to PDF. |
| [crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs](./crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs) | Crop a raster image to a central square and convert it to SVG. |

## Requirements
- **Aspose.Imaging** NuGet package (`Install-Package Aspose.Imaging`)
- .NET 9.0 or later

[← Back to Root README](../README.md)