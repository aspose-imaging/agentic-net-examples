# Convert BigTIFF Image to PDF in C# using Aspose.Imaging

This repository contains a set of **C# console examples** that demonstrate how to use **Aspose.Imaging for .NET** – a UI‑agnostic backend API that works in ASP.NET Core, console apps, Azure Functions, and Docker containers.  
The samples show how to:

* Convert a **BigTIFF raster image** into a **PDF** while preserving the original image fidelity.  
* Transform a **WebP** image into a **GIF** programmatically.  
* Render an **SVG** vector graphic to a **PNG** raster image without losing visual quality.  
* Set up the required prerequisites and configuration for raster‑format conversions.  
* Enumerate PNG input parameters that affect successful conversion.

## What You Can Do
- **Convert a BigTIFF raster image into a PDF document while preserving fidelity** (`bigimage.tif → bigimage.pdf`).  
- **Convert a WebP image to a GIF image** (`input.webp → output.gif`).  
- **Convert an SVG image file to a PNG raster image while maintaining visual fidelity** (`input.svg → output.png`).  
- **Prepare the environment for image‑to‑raster conversions** (install NuGet package, apply license, target supported .NET runtime).  
- **Enumerate PNG input parameters** that influence conversion outcomes (e.g., color type, bit depth, compression level).

## Quick Start

The most common scenario – converting a **BigTIFF** image to a **PDF** while keeping the original quality:

```csharp
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath  = @"C:\Images\bigimage.tif";
        string outputPath = @"C:\Images\bigimage.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Set PDF options – keep original resolution and compression
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth  = image.Width,
                    PageHeight = image.Height,
                    // Preserve original raster fidelity
                    Source = image
                }
            };

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine($"Converted '{inputPath}' to PDF at '{outputPath}'.");
    }
}
```

Run the snippet in a .NET 9.0 console project after installing the Aspose.Imaging package.

## Requirements

* **Aspose.Imaging for .NET** (compatible with .NET 9.0)  
  ```bash
  dotnet add package Aspose.Imaging
  ```

* (Optional) A valid Aspose.Imaging **temporary or permanent license** for full‑functionality.

## Resources

| Resource | Link |
|----------|------|
| Documentation | https://docs.aspose.com/imaging/net/ |
| NuGet Package | https://www.nuget.org/packages/aspose.imaging |
| Release Notes | https://releases.aspose.com/imaging/net/ |
| Online Apps | https://products.aspose.app/imaging/family/ |
| Free Temporary License | https://purchase.aspose.com/temporary-license |

## Files

Examples and tasks in this folder:

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
[**View all 162 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/conversion)