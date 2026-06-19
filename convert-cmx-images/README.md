# CMX Image Conversion with Aspose.Imaging for .NET

Convert Corel Metafile (CMX) files to other formats using **Aspose.Imaging for .NET**. This collection shows how to load CMX images, inspect their pages, and export them—e.g., to TIFF—directly from C#.

## What's in This Category
- Load a CMX file from a local path using `Image.Load`.
- Detect whether a loaded CMX image contains multiple pages via `Image.IsMultiPage`.
- Convert a single‑page CMX image to a single‑page TIFF file with default compression.
- (Optional) Extend the pattern to convert CMX to PNG, JPEG, or other raster formats.

## Quick Start
The most common scenario is converting a CMX file to TIFF:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the CMX image
using (Image cmxImage = Image.Load(@"C:\Images\sample.cmx"))
{
    // Save as TIFF (default compression)
    cmxImage.Save(@"C:\Images\sample.tiff", new TiffOptions());
}
```

Add the Aspose.Imaging package to your project and run the snippet on .NET 9 or later.

## All Examples

| Example | Description |
|---|---|
| [load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs](./load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs) | Load a CMX file from a local path using the `Image.Load` method. |
| [detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs](./detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs) | Detect whether the loaded CMX image contains multiple pages using the `Image.IsMultiPage` property. |
| [convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs](./convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs) | Convert a single‑page CMX image to a single‑page TIFF file with default compression. |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** or later

[← Back to main README](../README.md)