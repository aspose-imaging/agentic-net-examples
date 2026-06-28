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

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [apply-a-custom-background-color-when-converting-transparent-emf-files-to-jpeg-format.cs](./apply-a-custom-background-color-when-converting-transparent-emf-files-to-jpeg-format.cs) |
| [apply-a-grayscale-filter-during-conversion-of-emf-to-bmp-to-produce-monochrome-output.cs](./apply-a-grayscale-filter-during-conversion-of-emf-to-bmp-to-produce-monochrome-output.cs) |
| [batch-convert-emf-files-to-tiff-applying-lzw-compression-and-setting-resolution-to-150-dpi.cs](./batch-convert-emf-files-to-tiff-applying-lzw-compression-and-setting-resolution-to-150-dpi.cs) |
| [batch-convert-wmf-files-to-png-jpeg-and-bmp-in-a-single-operation-using-format-enumeration.cs](./batch-convert-wmf-files-to-png-jpeg-and-bmp-in-a-single-operation-using-format-enumeration.cs) |
| [batch-process-a-folder-of-wmf-files-converting-each-to-bmp-while-preserving-original-dimensions.cs](./batch-process-a-folder-of-wmf-files-converting-each-to-bmp-while-preserving-original-dimensions.cs) |
| [convert-a-multi-page-emf-document-to-a-series-of-png-files-one-per-page.cs](./convert-a-multi-page-emf-document-to-a-series-of-png-files-one-per-page.cs) |
| [convert-a-wmf-file-to-png-and-apply-a-custom-scaling-factor-of-0-5-during-rasterization.cs](./convert-a-wmf-file-to-png-and-apply-a-custom-scaling-factor-of-0-5-during-rasterization.cs) |
| [convert-emf-to-gif-with-a-limited-color-palette-of-256-colors.cs](./convert-emf-to-gif-with-a-limited-color-palette-of-256-colors.cs) |
| [convert-emf-to-jpeg-and-embed-exif-metadata-for-camera-information.cs](./convert-emf-to-jpeg-and-embed-exif-metadata-for-camera-information.cs) |
| [convert-emf-to-png-and-embed-icc-color-profile-for-consistent-display-across-devices.cs](./convert-emf-to-png-and-embed-icc-color-profile-for-consistent-display-across-devices.cs) |
| [convert-emf-to-png-using-anti-aliasing-to-smooth-edges-and-improve-visual-fidelity.cs](./convert-emf-to-png-using-anti-aliasing-to-smooth-edges-and-improve-visual-fidelity.cs) |
| [convert-wmf-to-bmp-with-24-bit-color-depth-to-ensure-full-color-representation.cs](./convert-wmf-to-bmp-with-24-bit-color-depth-to-ensure-full-color-representation.cs) |
| [convert-wmf-to-jpeg-with-progressive-encoding-to-enable-incremental-loading-in-browsers.cs](./convert-wmf-to-jpeg-with-progressive-encoding-to-enable-incremental-loading-in-browsers.cs) |
| [convert-wmf-to-pdf-embedding-the-vector-data-to-retain-scalability-in-the-resulting-document.cs](./convert-wmf-to-pdf-embedding-the-vector-data-to-retain-scalability-in-the-resulting-document.cs) |
| [convert-wmf-to-png-while-preserving-metadata-such-as-author-and-creation-date.cs](./convert-wmf-to-png-while-preserving-metadata-such-as-author-and-creation-date.cs) |
| [convert-wmf-to-png-with-transparent-background-ensuring-the-alpha-channel-is-retained.cs](./convert-wmf-to-png-with-transparent-background-ensuring-the-alpha-channel-is-retained.cs) |
| [export-emf-as-a-high-quality-jpeg-using-a-quality-setting-of-95-percent.cs](./export-emf-as-a-high-quality-jpeg-using-a-quality-setting-of-95-percent.cs) |
| [export-emf-to-tiff-using-ccitt-group-4-compression-for-black-and-white-images.cs](./export-emf-to-tiff-using-ccitt-group-4-compression-for-black-and-white-images.cs) |
| [load-a-wmf-file-from-disk-and-save-it-as-a-high-resolution-png-image.cs](./load-a-wmf-file-from-disk-and-save-it-as-a-high-resolution-png-image.cs) |
| [load-an-emf-image-from-a-memory-stream-and-export-it-to-tiff-with-lzw-compression.cs](./load-an-emf-image-from-a-memory-stream-and-export-it-to-tiff-with-lzw-compression.cs) |
| [load-emf-from-a-network-stream-convert-to-png-and-write-output-directly-to-response-stream.cs](./load-emf-from-a-network-stream-convert-to-png-and-write-output-directly-to-response-stream.cs) |
| [load-wmf-from-a-compressed-zip-archive-and-convert-each-entry-to-bmp-format.cs](./load-wmf-from-a-compressed-zip-archive-and-convert-each-entry-to-bmp-format.cs) |
| [load-wmf-from-a-url-stream-and-save-it-directly-to-a-byte-array-in-bmp-format.cs](./load-wmf-from-a-url-stream-and-save-it-directly-to-a-byte-array-in-bmp-format.cs) |
| [perform-asynchronous-conversion-of-wmf-files-to-jpeg-using-a-task-based-programming-model.cs](./perform-asynchronous-conversion-of-wmf-files-to-jpeg-using-a-task-based-programming-model.cs) |
| [perform-parallel-conversion-of-multiple-wmf-files-to-jpeg-using-parallel-foreach-for-speed.cs](./perform-parallel-conversion-of-multiple-wmf-files-to-jpeg-using-parallel-foreach-for-speed.cs) |
| [resize-a-wmf-image-during-conversion-to-png-setting-width-and-height-to-800-pixels-each.cs](./resize-a-wmf-image-during-conversion-to-png-setting-width-and-height-to-800-pixels-each.cs) |
| [set-dpi-to-300-when-rasterizing-wmf-to-jpeg-to-improve-print-quality.cs](./set-dpi-to-300-when-rasterizing-wmf-to-jpeg-to-improve-print-quality.cs) |
| [set-image-rotation-angle-to-90-degrees-while-converting-emf-to-png.cs](./set-image-rotation-angle-to-90-degrees-while-converting-emf-to-png.cs) |
| [use-a-custom-color-profile-when-converting-emf-to-jpeg-to-maintain-color-accuracy.cs](./use-a-custom-color-profile-when-converting-emf-to-jpeg-to-maintain-color-accuracy.cs) |
[**View all 29 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/converting-wmf-and-emf)

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`  
- **.NET 9.0** or later  

[← Back to main README](../README.md)