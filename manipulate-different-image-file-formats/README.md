# Image Format Manipulation C# with Aspose.Imaging

Explore practical code samples that demonstrate **image format manipulation C#** using Aspose.Imaging for .NET. These examples cover common multi‑format imaging dotnet scenarios such as loading, converting, and preserving image attributes across BMP, PNG, and JPEG files.

## What's in This Category
- Load a BMP image from the file system and read its pixel dimensions.  
- Save a loaded BMP image as PNG while keeping the original color depth and transparency.  
- Convert BMP files to JPEG with configurable compression quality.  
- (Additional samples) Adjust image metadata during format conversion.  
- (Additional samples) Batch‑process multiple image formats in a single workflow.

## Quick Start
The most frequent task is converting a BMP to PNG while preserving its visual fidelity:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

string sourcePath = @"Images/input.bmp";
string destPath   = @"Images/output.png";

using (Image bmp = Image.Load(sourcePath))
{
    var pngOptions = new PngOptions
    {
        ColorType = PngColorType.TruecolorWithAlpha,
        BitDepth  = 8
    };
    bmp.Save(destPath, pngOptions);
}
```

Add the Aspose.Imaging package to your project:

```bash
dotnet add package Aspose.Imaging
```

## All Examples

| Example | Description |
|---|---|
| [load-a-bmp-image-from-the-file-system-and-retrieve-its-pixel-dimensions-for-processing.cs](./load-a-bmp-image-from-the-file-system-and-retrieve-its-pixel-dimensions-for-processing.cs) | Load a BMP image and obtain its width, height, and pixel format for further processing. |
| [save-a-loaded-bmp-image-as-png-while-preserving-the-original-color-depth-and-transparency.cs](./save-a-loaded-bmp-image-as-png-while-preserving-the-original-color-depth-and-transparency.cs) | Convert BMP to PNG, preserving original color depth and alpha channel. |
| [convert-bmp-files-to-jpeg-using-configurable-compression-quality-via-the-net-imaging-api.cs](./convert-bmp-files-to-jpeg-using-configurable-compression-quality-via-the-net-imaging-api.cs) | Convert BMP files to JPEG with adjustable compression quality settings. |

## Requirements
- **Aspose.Imaging** NuGet package (`dotnet add package Aspose.Imaging`)
- **.NET 9** or later

[← Back to main README](../README.md)