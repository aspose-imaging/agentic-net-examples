# What's New in Aspose.Imaging for .NET 26.10 — C# Examples

This folder contains a set of **machine‑verified** C# snippets that demonstrate the new or enhanced APIs introduced in the **Aspose.Imaging for .NET 26.10** release.  
The examples cover:

* Convolution filter options with fine‑grained alpha handling.  
* Image blending with the full set of `BlendingMode` values and custom opacity/positioning.  
* Exporting raster images with clipping rectangles.  
* Reading and writing EXIF metadata.  
* Faster, lower‑memory AVIF processing.  
* Metadata removal and bulk conversion of XIF/TIFF files.

All code compiles with .NET 9.0 and the **Aspose.Imaging 26.10.0** NuGet package.

---

## What's New

- **`ConvolutionFilterOptions`** – New flags (`IgnoreAlpha`, `BordersProcessing`) let you control how alpha channels and image borders are treated when applying convolution kernels.  
  - Blur filter (ignore alpha) – [`apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs`](./apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs)  
  - Sharpen filter (borders processing, no alpha ignore) – [`apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs`](./apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs)

- **`ImageBlendingFilterOptions` / `BlendingMode`** – Full support for `Multiply`, `Overlay`, `Screen` and custom opacity/position blending.  
  - Multiply mode – [`blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs`](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs)  
  - Overlay mode – [`blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs`](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs)  
  - Screen mode – [`blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs`](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs)  
  - Custom opacity & position – [`blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs`](./blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs)

- **`RasterImageExporter`** – Added clipping‑rectangle support when exporting a batch of images to different formats.  
  - Export with clipping rectangle (10, 15, 100, 100) – [`export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs`](./export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs) – [IMAGINGNET‑3868](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/)

- **`ExifData`** – New helper methods for retrieving EXIF tags directly.  
  - Read `DateTimeOriginal` tag – [`load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs`](./load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs)  
  - Read `XResolution` / `YResolution` – [`load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs`](./load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs)

- **AVIF support** – Performance and memory‑usage improvements, plus a dedicated `AvifImage` class.  
  - Convert AVIF → JPEG – [`load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs`](./load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs) – [IMAGINGNET‑7739](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/)  
  - Convert AVIF → PNG via `AvifImage` – [`load-an-avif-image-using-avifimage-and-save-it-as-png.cs`](./load-an-avif-image-using-avifimage-and-save-it-as-png.cs) – [IMAGINGNET‑8135](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/)

- **`RemoveMetadata`** – One‑line API to strip all metadata from an image before saving.  
  - Remove metadata – [`load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs`](./load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs) – [IMAGINGNET‑8123](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/)

- **`Image.Load`** – Now supports bulk loading of XIF and TIFF files for conversion to PNG.  
  - XIF/TIFF → PNG batch conversion – [`load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs`](./load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs) – [IMAGINGNET‑8171](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/)

---

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

        // Apply a 3×3 blur kernel, ignoring the alpha channel
        var blurOptions = new ConvolutionFilterOptions
        {
            Kernel = new float[,] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 } },
            Normalize = true,
            IgnoreAlpha = true
        };
        image.ApplyFilter(new ConvolutionFilter(blurOptions));

        // Save the filtered image
        image.Save("output_blur.png", new PngOptions());
    }
}
```

The snippet demonstrates the new **`ConvolutionFilterOptions.IgnoreAlpha`** flag introduced in 26.10. All examples in this folder follow the same pattern: load → process → save, with proper `try/catch` handling.

---

## Requirements

* **Aspose.Imaging for .NET 26.10** (or later)  
  ```bash
  dotnet add package Aspose.Imaging --version 26.10.0
  ```
* .NET 9.0 SDK (or any supported version)

---

## Resources

* Official 26.10 release notes: <https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/>
* All examples in this release, with ticket mapping: [`./agents.md`](./agents.md)
* Examples for other releases: [`../README.md`](../README.md)
* Documentation: <https://docs.aspose.com/imaging/net/>
* NuGet package: <https://www.nuget.org/packages/aspose.imaging>
