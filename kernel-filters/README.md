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

## All Examples

| Example | Description |
|---|---|
| [load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs](./load-a-png-image-from-the-templates-folder-and-apply-a-predefined-5x5-blur-box-filter.cs) | Load a PNG image and apply a built‑in 5×5 blur box filter using `GaussianBlurFilterOptions`. |
| [create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs](./create-a-custom-3x3-convolution-matrix-and-apply-it-to-a-jpeg-image-loaded-from-disk.cs) | Build a custom 3×3 convolution matrix and apply it to a JPEG image with `ConvolutionFilterOptions`. |
| [validate-that-a-custom-7x7-kernel-has-odd-dimensions-before-applying-it-to-a-png-file.cs](./validate-that-a-custom-7x7-kernel-has-odd-dimensions-befo) | Demonstrates validation of a 7×7 kernel’s odd dimensions before using it on a PNG file. |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`
- **.NET 9.0** or later

[← Back to main README](../README.md)