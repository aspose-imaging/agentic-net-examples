# Image Format Conversion with Aspose.Imaging for .NET  

Convert image C# code samples that demonstrate how to perform image format conversion using the Aspose.Imaging library. These examples cover common scenarios such as converting between PNG, JPEG, and other supported formats, as well as querying the library for supported source and destination types. Use the format converter dotnet API to integrate seamless image transformations into your .NET applications.

## What's in This Category
- **Convert between supported formats** – e.g., PNG to JPEG using `PngOptions` or `JpegOptions`.  
- **Programmatic output format selection** – specify the desired format at runtime.  
- **Determine supported source and destination formats** – query the library for conversion capabilities.  
- **Batch conversion patterns** – apply the same conversion logic to multiple images (illustrated in the examples).  
- **Handle format‑specific options** – preserve quality, DPI, and other metadata during conversion.

## Quick Start  

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load the source image (any supported format)
        using (Image image = Image.Load("source.png"))
        {
            // Define the output format (JPEG in this case)
            var jpegOptions = new JpegOptions { Quality = 90 };
            image.Save("output.jpg", jpegOptions);
        }
    }
}
```

The snippet loads an image, sets JPEG‑specific options, and saves it as a new format – the most common image format conversion task.

## All Examples  

| Example | Description |
|---|---|
| [convert-an-image-from-one-supported-format-to-another-using-the-net-imaging-library.cs](./convert-an-image-from-one-supported-format-to-another-using-the-net-imaging-library.cs) | Demonstrates converting an image from one supported format to another using `PngOptions`. |
| [convert-an-image-to-a-specified-output-format-programmatically-using-the-net-imaging-library.cs](./convert-an-image-to-a-specified-output-format-programmatically-using-the-net-imaging-library.cs) | Shows how to programmatically select the output format with `JpegOptions`. |
| [determine-which-image-formats-can-serve-as-source-and-destination-types-for-conversion-within-the-net-imaging-library.cs](./determine-which-image-formats-can-serve-as-source-and-destination-types-for-conversion-within-the-net-imaging-library.cs) | Explains how to query Aspose.Imaging for supported source and destination conversion types. |

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`  
- **.NET 9.0** or later  

[← Back to the root README](../README.md)