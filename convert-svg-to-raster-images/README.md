# SVG to PNG C# – Convert SVG to Raster Images with Aspose.Imaging

Convert Scalable Vector Graphics (SVG) to raster formats such as PNG, BMP, or JPEG directly in .NET. These examples demonstrate **SVG rasterization dotnet** techniques, showing how to load an SVG, configure rasterization options, and output a **vector to raster C#** image with Aspose.Imaging.

## What's in This Category
- Load an SVG file and set custom rasterization dimensions before conversion.  
- Save a loaded SVG as a BMP file with explicit width and height.  
- Convert an SVG to PNG using the default rasterization settings.  
- Adjust DPI and background color during rasterization.  
- Export SVG to other raster formats (JPEG, TIFF) by swapping the output options.

## Quick Start
The most common scenario is converting an SVG to PNG with default rasterization options:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the SVG file
using (SvgImage svgImage = (SvgImage)Image.Load("sample.svg"))
{
    // Set PNG output options
    var pngOptions = new PngOptions();

    // Save as PNG (default rasterization)
    svgImage.Save("output.png", pngOptions);
}
```

Add the Aspose.Imaging package to your project:

```bash
dotnet add package Aspose.Imaging
```

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-a-watermark-text-to-bmp-image-after-svg-rasterization-using-drawing-api.cs](./add-a-watermark-text-to-bmp-image-after-svg-rasterization-using-drawing-api.cs) |
| [apply-grayscale-filter-to-png-raster-image-before-saving-the-output-file.cs](./apply-grayscale-filter-to-png-raster-image-before-saving-the-output-file.cs) |
| [batch-convert-multiple-svg-files-to-bmp-using-a-single-svgrasterizationoptions-instance.cs](./batch-convert-multiple-svg-files-to-bmp-using-a-single-svgrasterizationoptions-instance.cs) |
| [batch-convert-multiple-svg-files-to-png-while-reusing-the-same-rasterization-options.cs](./batch-convert-multiple-svg-files-to-png-while-reusing-the-same-rasterization-options.cs) |
| [catch-exceptions-during-svg-loading-and-log-error-details-for-troubleshooting.cs](./catch-exceptions-during-svg-loading-and-log-error-details-for-troubleshooting.cs) |
| [catch-exceptions-during-svg-saving-and-record-file-path-and-exception-message.cs](./catch-exceptions-during-svg-saving-and-record-file-path-and-exception-message.cs) |
| [convert-svg-to-bmp-using-an-indexed-color-palette-defined-in-bmpoptions.cs](./convert-svg-to-bmp-using-an-indexed-color-palette-defined-in-bmpoptions.cs) |
| [convert-svg-to-bmp-with-300-dpi-resolution-by-setting-bmpoptions-resolution-properties.cs](./convert-svg-to-bmp-with-300-dpi-resolution-by-setting-bmpoptions-resolution-properties.cs) |
| [convert-svg-to-png-with-high-compression-by-setting-pngoptions-compressionlevel-to-maximum.cs](./convert-svg-to-png-with-high-compression-by-setting-pngoptions-compressionlevel-to-maximum.cs) |
| [convert-svg-to-png-with-transparent-background-by-leaving-background-color-undefined.cs](./convert-svg-to-png-with-transparent-background-by-leaving-background-color-undefined.cs) |
| [create-an-asp-net-api-endpoint-that-accepts-uploaded-svg-and-returns-converted-png-as-file.cs](./create-an-asp-net-api-endpoint-that-accepts-uploaded-svg-and-returns-converted-png-as-file.cs) |
| [crop-png-raster-image-to-a-centered-square-region-after-conversion.cs](./crop-png-raster-image-to-a-centered-square-region-after-conversion.cs) |
| [disable-anti-aliasing-in-svgrasterizationoptions-before-saving-svg-to-png-to-improve-performance.cs](./disable-anti-aliasing-in-svgrasterizationoptions-before-saving-svg-to-png-to-improve-performance.cs) |
| [embed-the-bmp-raster-image-into-a-new-pdf-document-after-conversion.cs](./embed-the-bmp-raster-image-into-a-new-pdf-document-after-conversion.cs) |
| [embed-the-png-raster-image-into-an-html-email-body-after-conversion.cs](./embed-the-png-raster-image-into-an-html-email-body-after-conversion.cs) |
| [enable-anti-aliasing-in-svgrasterizationoptions-before-saving-svg-to-bmp-for-smoother-edges.cs](./enable-anti-aliasing-in-svgrasterizationoptions-before-saving-svg-to-bmp-for-smoother-edges.cs) |
| [enable-high-quality-vector-rasterization-by-setting-svgrasterizationoptions-vectorrasterizationquality-to-high.cs](./enable-high-quality-vector-rasterization-by-setting-svgrasterizationoptions-vectorrasterizationquality-to-high.cs) |
| [implement-a-using-block-to-ensure-proper-disposal-of-svgimage-and-option-objects.cs](./implement-a-using-block-to-ensure-proper-disposal-of-svgimage-and-option-objects.cs) |
| [implement-asynchronous-svg-loading-and-png-saving-using-async-await-pattern-for-non-blocking-i-o.cs](./implement-asynchronous-svg-loading-and-png-saving-using-async-await-pattern-for-non-blocking-i-o.cs) |
| [integrate-svg-to-bmp-conversion-into-an-asp-net-core-controller-action-returning-a-fileresult.cs](./integrate-svg-to-bmp-conversion-into-an-asp-net-core-controller-action-returning-a-fileresult.cs) |
| [load-an-svg-file-using-svgimage-class-and-configure-rasterization-dimensions-before-conversion.cs](./load-an-svg-file-using-svgimage-class-and-configure-rasterization-dimensions-before-conversion.cs) |
| [log-conversion-duration-in-milliseconds-and-output-file-size-after-each-svg-rasterization.cs](./log-conversion-duration-in-milliseconds-and-output-file-size-after-each-svg-rasterization.cs) |
| [overlay-another-image-onto-png-output-after-converting-svg-to-png-for-composite-result.cs](./overlay-another-image-onto-png-output-after-converting-svg-to-png-for-composite-result.cs) |
| [render-svg-to-bmp-with-white-background-color-defined-in-svgrasterizationoptions.cs](./render-svg-to-bmp-with-white-background-color-defined-in-svgrasterizationoptions.cs) |
| [render-svg-to-png-with-transparent-background-by-disabling-background-color-in-options.cs](./render-svg-to-png-with-transparent-background-by-disabling-background-color-in-options.cs) |
| [resize-bmp-raster-image-to-half-its-original-dimensions-after-conversion.cs](./resize-bmp-raster-image-to-half-its-original-dimensions-after-conversion.cs) |
| [retrieve-bmp-image-as-byte-array-after-conversion-for-storage-or-transmission.cs](./retrieve-bmp-image-as-byte-array-after-conversion-for-storage-or-transmission.cs) |
| [rotate-bmp-raster-image-ninety-degrees-clockwise-after-svg-conversion.cs](./rotate-bmp-raster-image-ninety-degrees-clockwise-after-svg-conversion.cs) |
| [save-converted-bmp-image-into-a-memorystream-for-further-in-memory-processing.cs](./save-converted-bmp-image-into-a-memorystream-for-further-in-memory-processing.cs) |
| [save-converted-png-image-into-a-memorystream-and-return-the-stream-to-the-caller.cs](./save-converted-png-image-into-a-memorystream-and-return-the-stream-to-the-caller.cs) |
| *...and 10 more files — [View all ↗](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-svg-to-raster-images)* |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet (`Aspose.Imaging`).  
- **.NET 9.0** or later.  

[← Back to Root README](../README.md)