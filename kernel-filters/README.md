# Apply Gaussian Blur Filter in C# with Aspose.Imaging

A collection of ready‑to‑run C# examples that demonstrate how to use **Aspose.Imaging for .NET** to work with kernel‑based filters.  
The samples show how to rasterize an SVG to PNG and apply a Gaussian blur, run a custom convolution matrix on a PNG, perform deconvolution on an SVG (via a temporary PNG), chain a predefined blur with an edge‑detection kernel, and more. Aspose.Imaging is a UI‑agnostic backend API that runs everywhere – ASP.NET Core, console apps, Azure Functions, Docker containers, etc., without any UI dependencies.

## What You Can Do
- **Rasterize an SVG and apply a Gaussian blur** – load `input.svg`, render it to `intermediate.png`, blur it, and save `output.png`.  
- **Apply a custom convolution kernel** – define your own matrix coefficients and transform `input.png` into `output.png`.  
- **Run a deconvolution filter on an SVG** – convert `input.svg` to a temporary PNG, deconvolve it, and store the result as `output.png`.  
- **Use a predefined kernel blur filter** – apply a built‑in Gaussian blur to `sample.png` and write `sample.GaussianBlur.png`.  
- **Chain a Gaussian blur with a custom edge‑detection kernel** – first blur an SVG, then run an edge‑detection matrix on the same image.

## Quick Start

The most common scenario – rasterizing an SVG to PNG and applying a Gaussian blur – can be done in just a few lines:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

// Load the SVG
using (var image = Image.Load(@"C:\Images\input.svg"))
{
    // Rasterize to PNG
    var pngOptions = new PngOptions { Source = new FileCreateSource(@"C:\Images\intermediate.png", false) };
    image.Save(pngOptions);

    // Apply Gaussian blur
    var blurOptions = new GaussianBlurFilterOptions { Radius = 5 };
    image.Filter(blurOptions);

    // Save the blurred PNG
    image.Save(@"C:\Images\output.png");
}
```

Compile and run the snippet in any .NET 9.0 project (console app, ASP.NET Core, Azure Function, Docker, etc.).

## Requirements

- .NET 9.0 SDK
- Aspose.Imaging for .NET

Install the library via NuGet:

```bash
dotnet add package Aspose.Imaging
```

## Resources

| Resource | Link |
|----------|------|
| Documentation | https://docs.aspose.com/imaging/net/ |
| NuGet | https://www.nuget.org/packages/aspose.imaging |
| Release Notes | https://releases.aspose.com/imaging/net/ |
| Online Apps | https://products.aspose.app/imaging/family/ |
| Free Temporary License | https://purchase.aspose.com/temporary-license |

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
[**View all 465 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/kernel-filters)
