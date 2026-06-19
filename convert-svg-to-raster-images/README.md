# SVG to PNG C# – Convert SVG to Raster Images with Aspose.Imaging

Convert Scalable Vector Graphics (SVG) to raster formats such as PNG, BMP, or JPEG directly in .NET. These examples demonstrate **SVG rasterization dotnet** techniques, showing how to load an SVG, configure rasterization options, and output a **vector to raster C#** image with Aspose.Imaging.

## What's in This Category
- Load an SVG file and set custom rasterization dimensions before conversion.  
- Save a loaded SVG as a BMP file with explicit width and height.  
- Convert an SVG to PNG using the default rasterization settings.  
- Adjust DPI and background color during rasterization.  
- Export SVG to other raster formats (JPEG, TIFF) by swapping the output options.

## Quick Start
The most common scenario is converting an SVG to PNG with default rasterization options:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the SVG file
using (SvgImage svgImage = (SvgImage)Image.Load("sample.svg"))
{
    // Set PNG output options
    var pngOptions = new PngOptions();

    // Save as PNG (default rasterization)
    svgImage.Save("output.png", pngOptions);
}
```

Add the Aspose.Imaging package to your project:

```bash
dotnet add package Aspose.Imaging
```

## All Examples

| Example | Description |
|---|---|
| [load-an-svg-file-using-svgimage-class-and-configure-rasterization-dimensions-before-conversion.cs](./load-an-svg-file-using-svgimage-class-and-configure-rasterization-dimensions-before-conversion.cs) | Load an SVG file using `SvgImage` and configure custom rasterization width/height before saving as PNG. |
| [save-the-loaded-svg-as-a-bmp-file-with-custom-width-and-height-settings.cs](./save-the-loaded-svg-as-a-bmp-file-with-custom-width-and-height-settings.cs) | Save the loaded SVG as a BMP file while specifying custom width and height via `SvgRasterizationOptions`. |
| [save-the-loaded-svg-as-a-png-file-using-default-rasterization-options.cs](./save-the-loaded-svg-as-a-png-file-using-default-rasterization-options.cs) | Convert an SVG to PNG using the default rasterization settings (no extra configuration). |
| *(additional examples may be added here)* |  |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet (`Aspose.Imaging`).  
- **.NET 9.0** or later.  

[← Back to Root README](../README.md)