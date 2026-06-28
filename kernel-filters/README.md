# Kernel Filter C# Examples for Aspose.Imaging

Explore how to perform **image kernel processing** with Aspose.Imaging for .NET. These samples demonstrate using convolution filters, custom kernels, and built‑in blur filters in C#. Learn to apply a convolution filter dotnet style, validate kernel dimensions, and integrate kernel filter C# code into your projects.

## What's in This Category
- Apply a predefined 5×5 blur (box) filter to a PNG image.  
- Create and use a custom 3×3 convolution matrix on a JPEG file.  
- Validate that a custom 7×7 kernel has odd dimensions before processing a PNG.  
- Work with `GaussianBlurFilterOptions` for smooth blur effects.  
- Inspect and modify `ConvolutionFilterOptions` for advanced image kernel processing.

## Quick Start

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Filters;

// Load a PNG from the Templates folder
using (RasterImage image = (RasterImage)Image.Load("Templates/sample.png"))
{
    // Apply the built‑in 5×5 blur box filter
    var blurOptions = new GaussianBlurFilterOptions
    {
        Radius = 2.5f,          // radius defines the blur strength
        KernelSize = 5          // 5×5 kernel
    };
    image.ApplyFilter(blurOptions);
    image.Save("output/blurred.png");
}
```

The snippet loads an image, applies a predefined blur kernel, and saves the result— the most common kernel filter operation.

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-a-readme-example-that-walks-through-loading-an-svg-applying-gaussian-blur-and-saving.cs](./add-a-readme-example-that-walks-through-loading-an-svg-applying-gaussian-blur-and-saving.cs) |
| [adjust-kernel-coefficients-dynamically-based-on-user-input-in-a-desktop-ui-before-filtering.cs](./adjust-kernel-coefficients-dynamically-based-on-user-input-in-a-desktop-ui-before-filtering.cs) |
| [adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs](./adjust-kernel-coefficients-to-increase-brightness-while-applying-a-5x5-blur-to-a-bmp-image.cs) |
| [adjust-the-coefficients-of-the-emboss3x3-kernel-to-increase-edge-enhancement-strength-on-a-png-image.cs](./adjust-the-coefficients-of-the-emboss3x3-kernel-to-increase-edge-enhancement-strength-on-a-png-image.cs) |
| [adjust-the-coefficients-of-the-emboss5x5-kernel-to-reduce-emboss-intensity-on-an-svg-image.cs](./adjust-the-coefficients-of-the-emboss5x5-kernel-to-reduce-emboss-intensity-on-an-svg-image.cs) |
| [adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs](./adjust-the-size-of-a-blur-box-kernel-from-3x3-to-7x7-to-increase-smoothing-on-bmp-file.cs) |
| [apply-a-3-3-high-pass-kernel-to-emphasize-edges-in-a-png-image.cs](./apply-a-3-3-high-pass-kernel-to-emphasize-edges-in-a-png-image.cs) |
| [apply-a-3-3-laplacian-kernel-for-edge-detection-to-a-png-image.cs](./apply-a-3-3-laplacian-kernel-for-edge-detection-to-a-png-image.cs) |
| [apply-a-blur-box-kernel-filter-to-the-image-to-achieve-uniform-smoothing-across-all-pixels.cs](./apply-a-blur-box-kernel-filter-to-the-image-to-achieve-uniform-smoothing-across-all-pixels.cs) |
| [apply-a-blur-filter-to-a-bigtiff-image-and-store-the-processed-output-to-a-file.cs](./apply-a-blur-filter-to-a-bigtiff-image-and-store-the-processed-output-to-a-file.cs) |
| [apply-a-blur-filter-to-a-bmp-image-and-store-the-processed-output-to-a-new-file.cs](./apply-a-blur-filter-to-a-bmp-image-and-store-the-processed-output-to-a-new-file.cs) |
| [apply-a-blur-filter-to-a-cdr-image-and-write-the-processed-output-to-a-file.cs](./apply-a-blur-filter-to-a-cdr-image-and-write-the-processed-output-to-a-file.cs) |
| [apply-a-blur-filter-to-a-dib-image-and-persist-the-modified-image-to-storage.cs](./apply-a-blur-filter-to-a-dib-image-and-persist-the-modified-image-to-storage.cs) |
| [apply-a-blur-filter-to-a-dicom-image-and-write-the-processed-image-to-a-new-file.cs](./apply-a-blur-filter-to-a-dicom-image-and-write-the-processed-image-to-a-new-file.cs) |
| [apply-a-blur-filter-to-a-djvu-image-and-persist-the-processed-output-to-a-file.cs](./apply-a-blur-filter-to-a-djvu-image-and-persist-the-processed-output-to-a-file.cs) |
| [apply-a-blur-filter-to-a-dng-image-and-write-the-processed-output-to-a-new-file.cs](./apply-a-blur-filter-to-a-dng-image-and-write-the-processed-output-to-a-new-file.cs) |
| [apply-a-blur-filter-to-a-gif-image-and-write-the-processed-image-back-to-storage.cs](./apply-a-blur-filter-to-a-gif-image-and-write-the-processed-image-back-to-storage.cs) |
| [apply-a-blur-filter-to-a-jpeg-image-and-save-the-processed-output-file.cs](./apply-a-blur-filter-to-a-jpeg-image-and-save-the-processed-output-file.cs) |
| [apply-a-blur-filter-to-a-jpeg2000-image-and-write-the-processed-output-to-a-new-file.cs](./apply-a-blur-filter-to-a-jpeg2000-image-and-write-the-processed-output-to-a-new-file.cs) |
| [apply-a-blur-filter-to-a-png-image-and-write-the-processed-output-to-a-new-file.cs](./apply-a-blur-filter-to-a-png-image-and-write-the-processed-output-to-a-new-file.cs) |
| [apply-a-blur-filter-to-a-psd-image-and-write-the-processed-image-back-to-storage.cs](./apply-a-blur-filter-to-a-psd-image-and-write-the-processed-image-back-to-storage.cs) |
| [apply-a-blur-filter-to-a-tga-image-and-export-the-processed-file-preserving-its-original-format.cs](./apply-a-blur-filter-to-a-tga-image-and-export-the-processed-file-preserving-its-original-format.cs) |
| [apply-a-blur-filter-to-a-tiff-image-and-write-the-processed-image-to-storage.cs](./apply-a-blur-filter-to-a-tiff-image-and-write-the-processed-image-to-storage.cs) |
| [apply-a-blur-filter-to-a-webp-image-and-write-the-processed-image-to-a-new-file.cs](./apply-a-blur-filter-to-a-webp-image-and-write-the-processed-image-to-a-new-file.cs) |
| [apply-a-blur-filter-to-a-wmf-image-and-save-the-processed-output-image.cs](./apply-a-blur-filter-to-a-wmf-image-and-save-the-processed-output-image.cs) |
| [apply-a-blur-filter-to-a-wmz-image-and-save-the-processed-file-to-the-desired-location.cs](./apply-a-blur-filter-to-a-wmz-image-and-save-the-processed-file-to-the-desired-location.cs) |
| [apply-a-blur-filter-to-an-apng-image-then-write-the-processed-output-to-disk.cs](./apply-a-blur-filter-to-an-apng-image-then-write-the-processed-output-to-disk.cs) |
| [apply-a-blur-filter-to-an-avif-image-and-write-the-processed-image-back-to-storage.cs](./apply-a-blur-filter-to-an-avif-image-and-write-the-processed-image-back-to-storage.cs) |
| [apply-a-blur-filter-to-an-emf-image-and-persist-the-processed-output-to-a-file.cs](./apply-a-blur-filter-to-an-emf-image-and-persist-the-processed-output-to-a-file.cs) |
| [apply-a-blur-filter-to-an-emz-image-and-store-the-processed-output-file.cs](./apply-a-blur-filter-to-an-emz-image-and-store-the-processed-output-file.cs) |
[**View all 464 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/kernel-filters)

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`
- **.NET 9.0** or later

[← Back to main README](../README.md)