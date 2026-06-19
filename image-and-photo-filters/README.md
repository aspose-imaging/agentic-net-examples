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

## All Examples

| Example | Description |
|---|---|
| [load-a-jpeg-image-apply-alpha-blending-with-127-opacity-and-save-as-png.cs](./load-a-jpeg-image-apply-alpha-blending-with-127-opacity-and-save-as-png.cs) | Load a JPEG, apply 127‑opacity alpha blending, and save as PNG using `PngOptions`. |
| [calculate-center-coordinates-of-a-bmp-background-blend-a-png-overlay-and-export-to-tiff.cs](./calculate-center-coordinates-of-a-bmp-background-blend-a-png-overlay-and-export-to-tiff.cs) | Compute the center of a BMP, blend a PNG overlay, and export the result to TIFF. |
| [batch-process-a-folder-of-png-images-applying-64-alpha-overlay-and-saving-results-as-jpeg-files.cs](./batch-process-a-folder-of-png-images-applying-64-alpha-overlay-and-saving-results-as-jpeg-files.cs) | Iterate over a folder, apply a 64‑level alpha overlay to each PNG, and save the outputs as JPEG files. |

## Requirements

- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** (or later) runtime
- Visual Studio 2022 (or any compatible IDE)

## Back to Main README

[← Back to the repository root README](../README.md)