# Image Manipulation C# with Aspose.Imaging

A collection of concise, ready‑to‑run C# snippets that demonstrate **image manipulation** using Aspose.Imaging for .NET.  
These examples cover common **image editing** tasks such as loading PNG files, applying auto‑masking, customizing mask feathering, and saving the processed result—perfect for developers looking to integrate resize, crop, rotate, and advanced masking into their .NET applications.

## What's in This Category
- Load a PNG image and apply auto‑masking with default graph‑cut strokes.  
- Create `AutoMaskingGraphCutOptions` with a custom feathering radius.  
- Define a point array for manual masking and apply it to a PNG.  
- Export the processed image using `PngOptions`.  

## Quick Start

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;

// Load a PNG image
using (RasterImage image = (RasterImage)Image.Load("input.png"))
{
    // Apply auto‑masking with default graph‑cut options
    var autoMask = new AutoMaskingGraphCutOptions();
    image.ApplyAutoMasking(autoMask);

    // Save the result
    var pngOptions = new PngOptions();
    image.Save("output.png", pngOptions);
}
```

The snippet above shows the most common workflow: load → auto‑mask → save. Add resizing, cropping, or rotation by using the corresponding `Resize`, `Crop`, or `Rotate` methods on the `RasterImage` instance.

## All Examples

| Example | Description |
|---|---|
| [27872-load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs](./27872-load-a-png-image-apply-auto-masking-graph-cut-with-default-strokes-and-save-as-png.cs) | Load a PNG, apply auto‑masking with default graph‑cut strokes, and save as PNG. |
| [27873-create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs](./27873-create-automaskinggraphcutoptions-with-custom-feathering-radius-apply-to-a-png-then-export-result.cs) | Demonstrates custom feathering radius in `AutoMaskingGraphCutOptions` before exporting. |
| [define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs](./define-a-point-array-for-manual-masking-use-it-on-a-png-and-save-the-processed-image.cs) | Shows how to build a point array for manual masking and apply it to a PNG. |

## Requirements
- **Aspose.Imaging** NuGet package (latest version)  
- **.NET 9** or later  

```bash
dotnet add package Aspose.Imaging
```

## ↩️ Back to Main README
[← Return to the repository root README](../README.md)