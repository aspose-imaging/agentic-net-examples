# Raster Image Conversion C# with Aspose.Imaging

Convert raster images, apply transformations, and export them to different formats using Aspose.Imaging for .NET. These examples demonstrate common bitmap conversion dotnet scenarios such as filtering, resizing, cropping, and saving to PDF or SVG.

## What's in This Category
- Apply a median filter to a BMP and save the result as a PDF.  
- Resize a PNG to a specific resolution and export directly to PDF.  
- Crop a raster image to a central square region before converting it to SVG.  
- Load, manipulate, and re‑encode bitmap images to other raster or vector formats.  
- Combine multiple image‑processing steps in a single workflow.

## Quick Start
```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load a raster image (any supported format)
using (RasterImage image = (RasterImage)Image.Load("input.png"))
{
    // Example: resize to 800x600
    image.Resize(800, 600);

    // Save as JPEG
    var jpegOptions = new JpegOptions { Quality = 90 };
    image.Save("output.jpg", jpegOptions);
}
```
The snippet shows the most common raster image conversion: load → resize → save in a different format.

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [load-a-bmp-apply-a-median-filter-and-generate-a-pdf-with-the-filtered-image-centered-on-the-page.cs](./load-a-bmp-apply-a-median-filter-and-generate-a-pdf-with-the-filtered-image-centered-on-the-page.cs) |
| [batch-process-bmp-files-applying-a-uniform-border-of-5-pixels-and-convert-each-to-pdf.cs](./batch-process-bmp-files-applying-a-uniform-border-of-5-pixels-and-convert-each-to-pdf.cs) |
| [batch-process-bmp-files-applying-a-10-brightness-increase-and-convert-each-brightened-image-to-svg.cs](./batch-process-bmp-files-applying-a-10-brightness-increase-and-convert-each-brightened-image-to-svg.cs) |
| [apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs](./apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs) |
| [batch-convert-a-folder-of-raster-images-to-pdf-preserving-original-filenames-and-using-default-settings.cs](./batch-convert-a-folder-of-raster-images-to-pdf-preserving-original-filenames-and-using-default-settings.cs) |
| [batch-convert-bmp-files-to-pdf-naming-each-output-file-with-a-sequential-numeric-suffix.cs](./batch-convert-bmp-files-to-pdf-naming-each-output-file-with-a-sequential-numeric-suffix.cs) |
| [batch-convert-bmp-files-to-svg-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs](./batch-convert-bmp-files-to-svg-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs) |
| [batch-convert-bmp-images-to-pdf-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs](./batch-convert-bmp-images-to-pdf-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs) |
| [batch-convert-bmp-images-to-svg-adding-a-custom-xml-namespace-to-each-svg-for-downstream-processing.cs](./batch-convert-bmp-images-to-svg-adding-a-custom-xml-namespace-to-each-svg-for-downstream-processing.cs) |
| [batch-convert-png-files-to-pdf-using-a-shared-memorystream-to-aggregate-pdfs-for-later-compression.cs](./batch-convert-png-files-to-pdf-using-a-shared-memorystream-to-aggregate-pdfs-for-later-compression.cs) |
| [batch-convert-png-files-to-svg-preserving-original-filenames-and-storing-results-in-a-designated-folder.cs](./batch-convert-png-files-to-svg-preserving-original-filenames-and-storing-results-in-a-designated-folder.cs) |
| [batch-convert-png-files-to-svg-preserving-original-filenames-and-storing-results-in-a-separate-output-folder.cs](./batch-convert-png-files-to-svg-preserving-original-filenames-and-storing-results-in-a-separate-output-folder.cs) |
| [batch-convert-png-images-to-pdf-naming-each-output-file-with-a-sequential-numeric-suffix.cs](./batch-convert-png-images-to-pdf-naming-each-output-file-with-a-sequential-numeric-suffix.cs) |
| [batch-convert-png-images-to-pdf-using-a-shared-memorystream-to-collect-all-pdfs-for-zip-compression.cs](./batch-convert-png-images-to-pdf-using-a-shared-memorystream-to-collect-all-pdfs-for-zip-compression.cs) |
| [batch-convert-raster-images-to-pdf-adding-a-watermark-text-that-includes-the-current-date.cs](./batch-convert-raster-images-to-pdf-adding-a-watermark-text-that-includes-the-current-date.cs) |
| [batch-process-a-collection-of-bmp-images-applying-a-uniform-compression-level-before-converting-each-to-pdf.cs](./batch-process-a-collection-of-bmp-images-applying-a-uniform-compression-level-before-converting-each-to-pdf.cs) |
| [batch-process-a-folder-of-pngs-applying-a-median-filter-and-converting-each-filtered-image-to-pdf.cs](./batch-process-a-folder-of-pngs-applying-a-median-filter-and-converting-each-filtered-image-to-pdf.cs) |
| [batch-process-bmp-files-apply-a-median-filter-resize-to-300x300-and-convert-to-svg.cs](./batch-process-bmp-files-apply-a-median-filter-resize-to-300x300-and-convert-to-svg.cs) |
| [batch-process-bmp-files-applying-a-10-brightness-increase-and-convert-each-brightened-image-to-svg.cs](./batch-process-bmp-files-applying-a-10-brightness-increase-and-convert-each-brightened-image-to-svg.cs) |
| [batch-process-bmp-files-applying-a-uniform-border-of-5-pixels-and-convert-each-to-pdf.cs](./batch-process-bmp-files-applying-a-uniform-border-of-5-pixels-and-convert-each-to-pdf.cs) |
| [batch-process-bmp-files-resize-each-to-1024x768-and-convert-all-resized-images-to-svg-format.cs](./batch-process-bmp-files-resize-each-to-1024x768-and-convert-all-resized-images-to-svg-format.cs) |
| [batch-process-bmp-images-resize-each-to-800x800-apply-a-sharpening-filter-and-convert-to-pdf.cs](./batch-process-bmp-images-resize-each-to-800x800-apply-a-sharpening-filter-and-convert-to-pdf.cs) |
| [batch-process-images-cropping-each-to-a-16-9-aspect-ratio-before-converting-them-to-svg-files.cs](./batch-process-images-cropping-each-to-a-16-9-aspect-ratio-before-converting-them-to-svg-files.cs) |
| [batch-process-images-in-a-folder-converting-each-raster-file-to-svg-while-preserving-original-filenames.cs](./batch-process-images-in-a-folder-converting-each-raster-file-to-svg-while-preserving-original-filenames.cs) |
| [batch-process-png-images-apply-a-gaussian-blur-to-each-and-convert-all-blurred-images-to-svg-files.cs](./batch-process-png-images-apply-a-gaussian-blur-to-each-and-convert-all-blurred-images-to-svg-files.cs) |
| [batch-process-png-images-resize-each-to-640x480-apply-a-sharpening-filter-and-save-as-pdf.cs](./batch-process-png-images-resize-each-to-640x480-apply-a-sharpening-filter-and-save-as-pdf.cs) |
| [batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs](./batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs) |
| [batch-process-raster-images-resize-each-to-1024x1024-apply-a-median-filter-and-save-as-svg-files.cs](./batch-process-raster-images-resize-each-to-1024x1024-apply-a-median-filter-and-save-as-svg-files.cs) |
| [batch-process-raster-images-resize-each-to-800x800-apply-a-gaussian-blur-and-save-as-svg.cs](./batch-process-raster-images-resize-each-to-800x800-apply-a-gaussian-blur-and-save-as-svg.cs) |
| [convert-a-bmp-image-to-pdf-and-write-the-pdf-directly-to-an-http-response-stream.cs](./convert-a-bmp-image-to-pdf-and-write-the-pdf-directly-to-an-http-response-stream.cs) |
| *...and 111 more files — [View all ↗](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-raster-image)* |

## Requirements
- **Aspose.Imaging** NuGet package (`Install-Package Aspose.Imaging`)
- .NET 9.0 or later

[← Back to Root README](../README.md)