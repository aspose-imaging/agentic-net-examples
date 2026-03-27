using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Define the output path for the README file (relative to the current directory)
        string outputPath = Path.Combine("Output", "README.md");

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // README content describing common conversion steps with Aspose.Imaging
        string readmeContent = @"# Aspose.Imaging Conversion Guide

## Introduction
This guide provides developers with step‑by‑step instructions for common image conversion tasks using the Aspose.Imaging library for .NET.

## Prerequisites
- Add a reference to the Aspose.Imaging NuGet package.
- Include the required namespaces in your code (e.g., `using Aspose.Imaging;`, `using Aspose.Imaging.ImageOptions;`, `using Aspose.Imaging.Sources;`).

## Basic Format Conversion
```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the source image
using (Image image = Image.Load(""Input/sample.jpg""))
{
    // Save to PNG format
    image.Save(""Output/sample.png"", new PngOptions());
}
```

## Converting to PDF
```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

// Load the source image
using (Image image = Image.Load(""Input/sample.png""))
{
    var pdfOptions = new PdfOptions
    {
        PdfDocumentInfo = new PdfDocumentInfo()
    };
    image.Save(""Output/sample.pdf"", pdfOptions);
}
```

## Multi‑Page Vector to TIFF
```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

// Load a multi‑page vector image (e.g., CDR)
using (Image image = Image.Load(""Input/multipage.cdr""))
{
    var exportOptions = new TiffOptions(TiffExpectedFormat.Default)
    {
        MultiPageOptions = new MultiPageOptions(new IntRange(0, 2)) // Export first two pages
    };

    if (image is VectorImage)
    {
        exportOptions.VectorRasterizationOptions = new VectorRasterizationOptions
        {
            BackgroundColor = Color.White,
            PageWidth = image.Width,
            PageHeight = image.Height,
            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
            SmoothingMode = SmoothingMode.None
        };
    }

    image.Save(""Output/multipage.tif"", exportOptions);
}
```

## Creating an Image from Scratch
```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

// Define image size
int width = 800;
int height = 600;

// Create a blank PNG image
var pngOptions = new PngOptions
{
    Source = new FileCreateSource(Path.Combine(""Output"", ""blank.png""), false)
};

using (Image canvas = Image.Create(pngOptions, width, height))
{
    // Perform drawing operations here (e.g., using Graphics)
    canvas.Save(); // Saves to the path defined in FileCreateSource
}
```

## Notes
- Always wrap `Image` objects in `using` blocks to ensure proper disposal.
- When saving to a file, use the appropriate `*Options` class from `Aspose.Imaging.ImageOptions`.
- For vector rasterization, construct `VectorRasterizationOptions` directly; do **not** cast the result of `GetDefaultOptions`.
- Use `Directory.CreateDirectory` before writing any output file to avoid `DirectoryNotFoundException`.

---";

        // Write the README content to the output file
        File.WriteAllText(outputPath, readmeContent);
    }
}