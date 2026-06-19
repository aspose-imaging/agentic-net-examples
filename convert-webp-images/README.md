# WebP Conversion C# with Aspose.Imaging for .NET

Convert WebP images to other formats quickly and safely using Aspose.Imaging for .NET. These examples demonstrate common **WebP conversion C#** scenarios such as turning WebP into GIF, PDF, PNG, or JPEG in a .NET 9+ project.

## What's in This Category
- Load a WebP file and save it as a GIF (`Image.Save`)  
- Convert a WebP image to PDF by specifying `PdfOptions`  
- Verify that a WebP file exists before attempting conversion to avoid `FileNotFoundException`  
- Use a `using` statement to automatically dispose of the `WebPImage` object  
- Convert a WebP image to JPEG (or PNG) with explicit format options  

## Quick Start
The most frequent task is converting a WebP image to JPEG:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load the WebP image
        using (WebPImage webp = (WebPImage)Image.Load("input.webp"))
        {
            // Set JPEG options (quality = 90)
            var jpegOptions = new JpegOptions { Quality = 90 };

            // Save as JPEG
            webp.Save("output.jpg", jpegOptions);
        }
    }
}
```

Add the Aspose.Imaging NuGet package to your project and run the snippet – the WebP file is converted to a high‑quality JPEG in one line of code.

## All Examples

| Example | Description |
|---|---|
| [load-a-webp-file-and-save-it-as-a-gif-using-image-save.cs](./load-a-webp-file-and-save-it-as-a-gif-using-image-save.cs) | Load a WebP file and save it as a GIF using `Image.Save`. |
| [load-a-webp-file-and-convert-it-to-pdf-by-specifying-the-pdf-format.cs](./load-a-webp-file-and-convert-it-to-pdf-by-specifying-the-pdf-format.cs) | Load a WebP file and convert it to PDF by specifying `PdfOptions`. |
| [verify-that-the-webp-image-exists-before-conversion-to-avoid-filenotfound-exceptions.cs](./verify-that-the-webp-image-exists-before-conversion-to-avoid-filenotfound-exceptions.cs) | Verify that the WebP image exists before conversion to avoid `FileNotFoundException`. |
| [use-a-using-statement-to-automatically-dispose-of-the-image.cs](./use-a-using-statement-to-automatically-dispose-of-the-image.cs) | Demonstrates proper resource handling with a `using` block. |
| [convert-webp-to-jpeg-with-quality-settings.cs](./convert-webp-to-jpeg-with-quality-settings.cs) | Convert WebP to JPEG while controlling compression quality. |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** or later

[← Back to main README](../README.md)