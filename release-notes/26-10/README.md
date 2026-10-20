# What's New in Aspose.Imaging for .NET 26.10 — C# Examples  

This folder contains a set of **machine‑verified** C# snippets that demonstrate the new and updated APIs shipped with Aspose.Imaging for .NET 26.10.  
The release adds several image‑processing capabilities (convolution filters, blending modes, AVIF handling, metadata removal, etc.) and fixes/improvements tracked by the tickets listed below.

## What's New  

- **ConvolutionFilterOptions** – Apply blur and sharpen convolution filters with fine‑grained control over `IgnoreAlpha` and `BordersProcessing`.  
  - [apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs](./apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs)  
  - [apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs](./apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs)  

- **BlendingMode** – New blending modes for `ImageBlendingFilterOptions`: Multiply, Overlay, Screen.  
  - [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs)  
  - [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs)  
  - [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs)  

- **ImageBlendingFilterOptions** – Position‑aware overlay blending with custom opacity.  
  - [blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs](./blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs)  

- **RasterImageExporter** – Export a collection of images to different formats using a clipping rectangle.  
  - Ticket **IMAGINGNET‑3868** – [export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs](./export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs)  

- **ExifData** – Read EXIF tags such as `DateTimeOriginal`, `XResolution`, and `YResolution`.  
  - [load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs](./load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs)  
  - [load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs](./load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs)  

- **JpegOptions** – Convert AVIF images to JPEG.  
  - Ticket **IMAGINGNET‑7739** – [load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs](./load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs)  

- **AvifImage** – Load AVIF images directly and save them as PNG, with performance and memory improvements.  
  - Ticket **IMAGINGNET‑8135** – [load-an-avif-image-using-avifimage-and-save-it-as-png.cs](./load-an-avif-image-using-avifimage-and-save-it-as-png.cs)  

- **RemoveMetadata** – Strip all metadata from an image before saving.  
  - Ticket **IMAGINGNET‑8123** – [load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs](./load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs)  

- **Image.Load** – Load XIF and TIFF files and convert each to PNG in a single pass.  
  - Ticket **IMAGINGNET‑8171** – [load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs](./load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs)  

## Quick Start  

```csharp
using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Filters;

class QuickStart
{
    static void Main()
    {
        // Load a PNG image
        using var image = Image.Load("input.png");

        // Apply a blur convolution filter (ignore alpha = true)
        var blurOptions = new ConvolutionFilterOptions
        {
            Filter = ConvolutionFilterOptions.Blur,
            IgnoreAlpha = true
        };
        image.Filter(blurOptions);

        // Save the filtered image
        image.Save("blurred.png", new PngOptions());
        Console.WriteLine("Blurred image saved.");
    }
}
```

The snippet above compiles and runs with .NET 9.0 (or any supported version) and demonstrates the typical pattern used throughout the examples: **load → process → save** with proper `using` disposal.

## Requirements  

- **Aspose.Imaging for .NET 26.10** (or later).  
- .NET SDK (any version supported by the package, e.g., .NET 9.0).  

Install the library via NuGet:

```bash
dotnet add package Aspose.Imaging
```

## Resources  

- Official 26.10 release notes: <https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/>  
- All examples in this release with ticket mapping: [agents.md](./agents.md)  
- Examples for other releases: [../README.md](../README.md)  
- Documentation: <https://docs.aspose.com/imaging/net/>  
- NuGet package: <https://www.nuget.org/packages/aspose.imaging>
