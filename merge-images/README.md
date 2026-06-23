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

## Files

Examples and tasks in this folder:

| Example | |
|---------|---|
| [add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) |
| [add-custom-author-metadata-to-the-merged-pdf-generated-from-a-horizontal-jpeg-merge-operation.cs](./add-custom-author-metadata-to-the-merged-pdf-generated-from-a-horizontal-jpeg-merge-operation.cs) |
| [align-all-merged-jpeg-images-to-the-top-left-corner-of-the-canvas-for-a-consistent-layout.cs](./align-all-merged-jpeg-images-to-the-top-left-corner-of-the-canvas-for-a-consistent-layout.cs) |
| [apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs](./apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs) |
| [apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs](./apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs) |
| [apply-a-uniform-border-of-five-pixels-around-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./apply-a-uniform-border-of-five-pixels-around-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) |
| [center-each-jpeg-image-on-the-canvas-while-merging-them-horizontally-to-create-a-balanced-composition.cs](./center-each-jpeg-image-on-the-canvas-while-merging-them-horizontally-to-create-a-balanced-composition.cs) |
| [combine-a-jpeg-image-into-a-pdf-document-by-first-converting-it-to-djvu-format-and-then-merging.cs](./combine-a-jpeg-image-into-a-pdf-document-by-first-converting-it-to-djvu-format-and-then-merging.cs) |
| [combine-a-jpeg-image-into-a-png-output-while-encapsulating-the-result-within-a-dicom-container.cs](./combine-a-jpeg-image-into-a-png-output-while-encapsulating-the-result-within-a-dicom-container.cs) |
| [combine-a-jpg-image-into-a-pdf-document-by-converting-it-through-the-tga-format.cs](./combine-a-jpg-image-into-a-pdf-document-by-converting-it-through-the-tga-format.cs) |
| [combine-a-jpg-image-into-a-pdf-document-by-first-converting-it-to-gif-format-before-merging.cs](./combine-a-jpg-image-into-a-pdf-document-by-first-converting-it-to-gif-format-before-merging.cs) |
| [combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs](./combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs) |
| [combine-jpeg-images-into-a-pdf-document-employing-the-jpeg2000-compression-format-while-maintaining-image-fidelity-and-document-integrity.cs](./combine-jpeg-images-into-a-pdf-document-employing-the-jpeg2000-compression-format-while-maintaining-image-fidelity-and-document-integrity.cs) |
| [combine-jpeg-images-into-a-single-pdf-document-utilizing-the-odg-format-as-the-intermediate-representation.cs](./combine-jpeg-images-into-a-single-pdf-document-utilizing-the-odg-format-as-the-intermediate-representation.cs) |
| [combine-jpeg-images-into-a-single-pdf-document-while-retaining-original-jpeg-quality-and-encoding.cs](./combine-jpeg-images-into-a-single-pdf-document-while-retaining-original-jpeg-quality-and-encoding.cs) |
| [combine-jpeg-images-into-a-single-png-output-employing-jpeg2000-encoding-for-intermediate-processing.cs](./combine-jpeg-images-into-a-single-png-output-employing-jpeg2000-encoding-for-intermediate-processing.cs) |
| [combine-jpeg-images-into-a-single-png-output-utilizing-the-dib-pixel-format-for-conversion.cs](./combine-jpeg-images-into-a-single-png-output-utilizing-the-dib-pixel-format-for-conversion.cs) |
| [combine-jpg-images-and-output-a-png-file-generated-through-the-webp-format-conversion-process.cs](./combine-jpg-images-and-output-a-png-file-generated-through-the-webp-format-conversion-process.cs) |
| [combine-jpg-images-into-a-pdf-document-by-converting-them-to-emf-format-while-preserving-vector-fidelity.cs](./combine-jpg-images-into-a-pdf-document-by-converting-them-to-emf-format-while-preserving-vector-fidelity.cs) |
| [combine-jpg-images-into-a-pdf-document-by-converting-them-to-emz-format-during-the-merging-process.cs](./combine-jpg-images-into-a-pdf-document-by-converting-them-to-emz-format-during-the-merging-process.cs) |
| [combine-jpg-images-into-a-pdf-document-by-converting-them-to-wmf-format-before-merging.cs](./combine-jpg-images-into-a-pdf-document-by-converting-them-to-wmf-format-before-merging.cs) |
| [combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-apng-format-and-embedding-them-accordingly.cs](./combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-apng-format-and-embedding-them-accordingly.cs) |
| [combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-psd-format.cs](./combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-psd-format.cs) |
| [combine-jpg-images-into-a-pdf-document-converting-each-image-to-png-format-before-merging.cs](./combine-jpg-images-into-a-pdf-document-converting-each-image-to-png-format-before-merging.cs) |
| [combine-jpg-images-into-a-pdf-document-embedding-an-ico-file-as-the-document-s-icon.cs](./combine-jpg-images-into-a-pdf-document-embedding-an-ico-file-as-the-document-s-icon.cs) |
| [combine-jpg-images-into-a-pdf-document-encoding-the-images-as-avif-format-to-optimize-size.cs](./combine-jpg-images-into-a-pdf-document-encoding-the-images-as-avif-format-to-optimize-size.cs) |
| [combine-jpg-images-into-a-pdf-document-using-dicom-formatting-while-maintaining-image-fidelity.cs](./combine-jpg-images-into-a-pdf-document-using-dicom-formatting-while-maintaining-image-fidelity.cs) |
| [combine-jpg-images-into-a-png-output-while-applying-jpeg-compression-settings-during-the-merge.cs](./combine-jpg-images-into-a-png-output-while-applying-jpeg-compression-settings-during-the-merge.cs) |
| [combine-jpg-images-into-a-single-pdf-document-employing-the-wmz-format-for-compression-and-packaging.cs](./combine-jpg-images-into-a-single-pdf-document-employing-the-wmz-format-for-compression-and-packaging.cs) |
| [combine-jpg-images-into-a-single-pdf-document-using-the-cmx-format-to-maintain-color-fidelity.cs](./combine-jpg-images-into-a-single-pdf-document-using-the-cmx-format-to-maintain-color-fidelity.cs) |
| | [**View all 135 examples ↗**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/merge-images) |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`
- **.NET 9** or later

[← Back to main README](../README.md)