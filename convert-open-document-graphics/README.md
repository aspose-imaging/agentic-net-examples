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

## All Examples

| Example | Description |
|---|---|
| [load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs](./load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs) | Load an ODG file and save it as a PNG image using `Image.Save`. |
| [load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs](./load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs) | Load an ODG file and convert it to JPEG format with default compression settings. |
| [load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs](./load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs) | Load an ODG file and export it as a BMP image while preserving the original dimensions. |
| *(additional examples can be added here as the collection grows)* |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** or later

[← Back to main README](../README.md)