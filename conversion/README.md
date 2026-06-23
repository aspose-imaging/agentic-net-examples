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

## All Examples (162 total)

| Example |
|---------|
| [convert-a-bigtiff-raster-image-into-a-pdf-document-while-preserving-the-original-image-fidelity.cs](./convert-a-bigtiff-raster-image-into-a-pdf-document-while-preserving-the-original-image-fidelity.cs) |
| [convert-a-bmp-image-file-into-a-pdf-document-maintaining-image-fidelity-and-appropriate-page-dimensions.cs](./convert-a-bmp-image-file-into-a-pdf-document-maintaining-image-fidelity-and-appropriate-page-dimensions.cs) |
| [convert-a-cdr-file-to-the-specified-image-format-programmatically-using-a-net-application.cs](./convert-a-cdr-file-to-the-specified-image-format-programmatically-using-a-net-application.cs) |
| [convert-a-cmx-image-to-a-specified-output-format-using-the-net-imaging-library.cs](./convert-a-cmx-image-to-a-specified-output-format-using-the-net-imaging-library.cs) |
| [convert-a-dicom-image-to-a-desired-raster-format-using-the-net-imaging-library.cs](./convert-a-dicom-image-to-a-desired-raster-format-using-the-net-imaging-library.cs) |
| [convert-a-lossless-webp-image-to-a-gif-format-ensuring-the-resulting-file-retains-the-original-visual-quality.cs](./convert-a-lossless-webp-image-to-a-gif-format-ensuring-the-resulting-file-retains-the-original-visual-quality.cs) |
| [convert-a-png-image-to-a-pdf-document-while-maintaining-original-image-fidelity-and-vector-compatibility.cs](./convert-a-png-image-to-a-pdf-document-while-maintaining-original-image-fidelity-and-vector-compatibility.cs) |
| [convert-a-png-image-to-a-pdf-file-using-custom-specified-pdf-generation-options.cs](./convert-a-png-image-to-a-pdf-file-using-custom-specified-pdf-generation-options.cs) |
| [convert-a-png-image-with-transparency-into-a-pdf-while-preserving-its-alpha-channel.cs](./convert-a-png-image-with-transparency-into-a-pdf-while-preserving-its-alpha-channel.cs) |
| [convert-a-webp-image-file-into-a-pdf-document-preserving-image-fidelity-and-embedding-it-correctly.cs](./convert-a-webp-image-file-into-a-pdf-document-preserving-image-fidelity-and-embedding-it-correctly.cs) |
| [convert-a-webp-image-file-to-a-pdf-document-while-maintaining-the-image-fidelity.cs](./convert-a-webp-image-file-to-a-pdf-document-while-maintaining-the-image-fidelity.cs) |
| [convert-a-webp-image-file-to-gif-format-preserving-animation-frames-and-color-fidelity.cs](./convert-a-webp-image-file-to-gif-format-preserving-animation-frames-and-color-fidelity.cs) |
| [convert-a-webp-image-into-a-pdf-document-generating-pdf-output-from-the-webp-source.cs](./convert-a-webp-image-into-a-pdf-document-generating-pdf-output-from-the-webp-source.cs) |
| [convert-a-webp-image-to-a-gif-image-programmatically-using-the-net-imaging-library.cs](./convert-a-webp-image-to-a-gif-image-programmatically-using-the-net-imaging-library.cs) |
| [convert-a-webp-image-to-a-pdf-document-preserving-image-fidelity-and-embedding-metadata-as-needed.cs](./convert-a-webp-image-to-a-pdf-document-preserving-image-fidelity-and-embedding-metadata-as-needed.cs) |
| [convert-a-webp-image-to-pdf-while-applying-custom-pdf-configuration-settings-including-page-size-compression-and-metadata-handling.cs](./convert-a-webp-image-to-pdf-while-applying-custom-pdf-configuration-settings-including-page-size-compression-and-metadata-handling.cs) |
| [convert-an-apng-file-to-a-png-image-using-the-net-imaging-library-while-preserving-image-quality.cs](./convert-an-apng-file-to-a-png-image-using-the-net-imaging-library-while-preserving-image-quality.cs) |
| [convert-an-apng-raster-image-into-a-pdf-document-while-maintaining-original-image-fidelity.cs](./convert-an-apng-raster-image-into-a-pdf-document-while-maintaining-original-image-fidelity.cs) |
| [convert-an-avif-raster-image-to-a-pdf-document-preserving-image-quality-and-metadata.cs](./convert-an-avif-raster-image-to-a-pdf-document-preserving-image-quality-and-metadata.cs) |
| [convert-an-avif-raster-image-to-svg-format-preserving-visual-fidelity-and-supporting-transparency.cs](./convert-an-avif-raster-image-to-svg-format-preserving-visual-fidelity-and-supporting-transparency.cs) |
| [convert-an-eps-file-to-a-pdf-document-using-the-net-imaging-library-with-high-fidelity.cs](./convert-an-eps-file-to-a-pdf-document-using-the-net-imaging-library-with-high-fidelity.cs) |
| [convert-an-eps-vector-image-to-the-target-raster-format-using-the-net-imaging-api.cs](./convert-an-eps-vector-image-to-the-target-raster-format-using-the-net-imaging-api.cs) |
| [convert-an-image-from-one-supported-format-to-another-using-the-net-imaging-library.cs](./convert-an-image-from-one-supported-format-to-another-using-the-net-imaging-library.cs) |
| [convert-an-image-to-a-specified-output-format-programmatically-using-the-net-imaging-library.cs](./convert-an-image-to-a-specified-output-format-programmatically-using-the-net-imaging-library.cs) |
| [convert-an-odg-file-to-any-supported-image-format-using-the-net-imaging-library.cs](./convert-an-odg-file-to-any-supported-image-format-using-the-net-imaging-library.cs) |
| [convert-an-svg-document-to-a-raster-image-extracting-frames-from-an-apng-source-as-needed.cs](./convert-an-svg-document-to-a-raster-image-extracting-frames-from-an-apng-source-as-needed.cs) |
| [convert-an-svg-image-file-to-a-png-raster-image-while-maintaining-visual-fidelity.cs](./convert-an-svg-image-file-to-a-png-raster-image-while-maintaining-visual-fidelity.cs) |
| [convert-an-svg-image-to-a-gif-format-while-maintaining-visual-fidelity-and-transparency.cs](./convert-an-svg-image-to-a-gif-format-while-maintaining-visual-fidelity-and-transparency.cs) |
| [convert-an-svg-image-to-a-tiff-file-preserving-visual-fidelity-and-supporting-optional-compression-settings.cs](./convert-an-svg-image-to-a-tiff-file-preserving-visual-fidelity-and-supporting-optional-compression-settings.cs) |
| [convert-an-svg-image-to-bmp-format-preserving-visual-fidelity-and-supporting-custom-dimensions.cs](./convert-an-svg-image-to-bmp-format-preserving-visual-fidelity-and-supporting-custom-dimensions.cs) |
| *...and 132 more files — [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/main/conversion)* |

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`  
- **.NET 9.0** or later  

[← Back to the root README](../README.md)