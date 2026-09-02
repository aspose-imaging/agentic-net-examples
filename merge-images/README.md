# Horizontal JPEG Merge with Semi‑Transparent Watermark in C#

Combine several JPEG files side‑by‑side, stamp a semi‑transparent text watermark on the result, and optionally export the merged image to PDF, PNG (inside an EMZ), or an animated GIF – all with Aspose.Imaging for .NET. The library is a UI‑agnostic backend API that runs in ASP.NET Core, console apps, Azure Functions, and Docker containers without any UI dependencies.

## What You Can Do
- **Horizontally merge multiple JPEG images** into a single bitmap.  
- **Add a semi‑transparent watermark text** to the merged JPEG image.  
- **Save the horizontally merged JPEG collection directly as a PDF** document.  
- **Convert a set of JPEG images to PSD format first, then combine them into a PDF** (preserves layer information).  
- **Merge JPEG images into a single PNG wrapped in an EMZ file** while keeping visual fidelity.  
- **Create a single animated GIF from multiple JPEG files** using a programmatic merging operation.

## Quick Start
The snippet below shows the most common scenario – merging JPEGs horizontally and applying a semi‑transparent watermark.

```csharp
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Input JPEG files (hard‑coded for demo)
        string[] inputs = { "input1.jpg", "input2.jpg", "input3.jpg" };

        // Load all images
        var images = inputs.Select(p => (RasterImage)Image.Load(p)).ToArray();

        // Calculate total width / max height for horizontal merge
        int totalWidth = images.Sum(img => img.Width);
        int maxHeight = images.Max(img => img.Height);

        // Create a blank canvas
        using var merged = new RasterImage(totalWidth, maxHeight, images[0].BitsPerPixel);
        int offsetX = 0;
        foreach (var img in images)
        {
            merged.SavePixels(offsetX, 0, img.Width, img.Height, img.LoadPixels(img.Bounds));
            offsetX += img.Width;
        }

        // Add semi‑transparent watermark text
        var watermark = new TextGraphicsOptions()
        {
            Antialiasing = true,
            Blend = new BlendOptions() { Alpha = 0.5f } // 50 % opacity
        };
        merged.Graphics.DrawString(
            "Sample Watermark",
            System.Drawing.FontFamily.GenericSansSerif,
            48,
            new System.Drawing.PointF(totalWidth / 2, maxHeight / 2),
            watermark,
            new SolidBrush(Color.FromArgb(255, 255, 255)));

        // Save as JPEG (or change to PdfOptions / PngOptions / GifOptions as needed)
        merged.Save("merged_watermarked.jpg", new JpegOptions { Quality = 90 });
    }
}
```

> Adjust the `inputs` array, watermark text, font size, and output format to fit your scenario.

## Requirements
- .NET 9.0 (or later)
- Aspose.Imaging for .NET  

Install the NuGet package:

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
[**View all 135 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/merge-images)
