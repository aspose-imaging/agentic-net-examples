# Merge Images C# – Aspose.Imaging for .NET

Combine images in .NET quickly with Aspose.Imaging. This collection shows how to **merge images C#**, **combine images dotnet**, and perform **image stitching C#** using simple, production‑ready code.

## What's in This Category
- Merge multiple JPEG files horizontally into a single image.  
- Arrange several JPEG pictures vertically and save the combined result.  
- Stitch a set of JPEG images side‑by‑side and output the merged picture as a PDF document.  
- Load images from a directory, calculate dimensions dynamically, and create a composite bitmap.  

## Quick Start
The most common scenario is merging a series of JPEG files horizontally:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using System.IO;
using System.Linq;

string[] files = Directory.GetFiles(@"C:\Images", "*.jpg");

// Load the first image to obtain height and total width
using var first = (JpegImage)Image.Load(files[0]);
int totalWidth = files.Sum(f => ((JpegImage)Image.Load(f)).Width);
int height = first.Height;

// Create a blank raster to hold the merged result
using var result = new RasterImage(totalWidth, height, PixelFormat.Format24bppRgb);
int offsetX = 0;

foreach (string file in files)
{
    using var img = (JpegImage)Image.Load(file);
    result.SavePixels(offsetX, 0, img.Width, height, img.LoadPixels(img.Bounds));
    offsetX += img.Width;
}

// Save the merged image
result.Save(@"C:\Output\merged.jpg", new JpegOptions());
```

Add the Aspose.Imaging NuGet package and run the snippet – you’ll get a single JPEG that contains all source images side‑by‑side.

## All Examples

| Example | Description |
|---|---|
| [load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs](./load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs) | Loads JPEG files from a folder and merges them horizontally into one JPEG. |
| [load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs](./load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs) | Arranges multiple JPEGs vertically and writes the combined image to disk. |
| [combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs](./combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs) | Merges JPEGs side‑by‑side and saves the result as a PDF document. |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`
- **.NET 9** or later

[← Back to main README](../README.md)