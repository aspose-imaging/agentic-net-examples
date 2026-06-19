# WMF & EMF Conversion with Aspose.Imaging for .NET  

Convert Windows Metafile (WMF) and Enhanced Metafile (EMF) images to modern raster formats using C#. The examples show how to load WMF/EMF from disk, streams, or URLs and export them to PNG, BMP, TIFF, and other formats with full .NET control.

## What's in This Category
- Load a WMF file from disk and save it as a high‑resolution PNG.  
- Load an EMF image from a memory stream and export it to TIFF with LZW compression.  
- Load a WMF image from a URL stream and write it directly to a byte array in BMP format.  
- (Additional) Convert WMF/EMF to JPEG, GIF, or other raster types while preserving vector quality.  

## Quick Start  

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load a WMF file and save it as PNG
using (Image image = Image.Load(@"C:\Images\sample.wmf"))
{
    var pngOptions = new PngOptions { ColorType = PngColorType.Truecolor };
    image.Save(@"C:\Images\sample.png", pngOptions);
}
```

The snippet demonstrates the most common operation: reading a WMF metafile and exporting it to a high‑quality PNG image.

## All Examples  

| Example | Description |
|---|---|
| [load-a-wmf-file-from-disk-and-save-it-as-a-high-resolution-png-image.cs](./load-a-wmf-file-from-disk-and-save-it-as-a-high-resolution-png-image.cs) | Load a WMF file from disk and save it as a high‑resolution PNG image. |
| [load-an-emf-image-from-a-memory-stream-and-export-it-to-tiff-with-lzw-compression.cs](./load-an-emf-image-from-a-memory-stream-and-export-it-to-tiff-with-lzw-compression.cs) | Load an EMF image from a memory stream and export it to TIFF with LZW compression. |
| [load-wmf-from-a-url-stream-and-save-it-directly-to-a-byte-array-in-bmp-format.cs](./load-wmf-from-a-url-stream-and-save-it-directly-to-a-byte-array-in-bmp-format.cs) | Load WMF from a URL stream and save it directly to a byte array in BMP format. |
| *(additional examples)* | Other conversions such as WMF/EMF → JPEG, GIF, or custom raster options. |

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`  
- **.NET 9.0** or later  

[← Back to main README](../README.md)