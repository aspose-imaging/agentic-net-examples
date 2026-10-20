# Aspose.Imaging for .NET 26.10 — Release Examples

Build-verified C# examples for the features, enhancements and fixes shipped in [Aspose.Imaging for .NET 26.10](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/). Each file is a standalone console program that compiled against Aspose.Imaging 26.10.0 (NuGet).

**Examples:** 13  
**Requires:** Aspose.Imaging for .NET 26.10 or later

## Examples

| Example | What it shows | Based on |
|---------|---------------|----------|
| [apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs](apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs) | Apply a blur convolution filter to an image with IgnoreAlpha set to true, then save the filtered image. | `ConvolutionFilterOptions` |
| [apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs](apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs) | Apply a sharpen convolution filter to an image with BordersProcessing enabled and IgnoreAlpha disabled, then save the result. | `ConvolutionFilterOptions` |
| [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs](blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs) | Blend a PNG overlay onto a JPEG background using ImageBlendingFilterOptions with BlendingMode.Multiply and save as PNG. | `BlendingMode` |
| [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs](blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs) | Blend a PNG overlay onto a JPEG background using ImageBlendingFilterOptions with BlendingMode.Overlay and save as PNG. | `BlendingMode` |
| [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs](blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs) | Blend a PNG overlay onto a JPEG background using ImageBlendingFilterOptions with BlendingMode.Screen and save as PNG. | `BlendingMode` |
| [blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs](blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs) | Blend an overlay image onto a base image at position (50,30) with 70% opacity using ImageBlendingFilterOptions and save as PNG. | `ImageBlendingFilterOptions` |
| [export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs](export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs) | Export a set of images to various formats using RasterImageExporter with a clipping rectangle of (10,15,100,100). | [IMAGINGNET-3868](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/) |
| [load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs](load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs) | Load a JPEG image and retrieve the value of the ExifProperties.DateTimeOriginal tag using GetTagValue. | `ExifData` |
| [load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs](load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs) | Load a JPEG image, read its ExifData XResolution and YResolution properties, and print the values. | `ExifData` |
| [load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs](load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs) | Load an AVIF image and save it as JPEG using JpegOptions. | [IMAGINGNET-7739](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/) |
| [load-an-avif-image-using-avifimage-and-save-it-as-png.cs](load-an-avif-image-using-avifimage-and-save-it-as-png.cs) | Load an AVIF image using AvifImage and save it as PNG. | [IMAGINGNET-8135](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/) |
| [load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs](load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs) | Load an image, call RemoveMetadata, and save the image without metadata. | [IMAGINGNET-8123](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/) |
| [load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs](load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs) | Load XIF and TIFF files with Image.Load and convert each to PNG. | [IMAGINGNET-8171](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/) |

## Tickets in this release

Examples are written from each ticket's summary and show the feature or API the ticket touches. They do not reproduce the original issue or prove the fix.

| Key | Summary | Category | Related examples |
|-----|---------|----------|------------------|
| IMAGINGNET-8135 | Improve AVIF processing performance and memory load | Feature | [load-an-avif-image-using-avifimage-and-save-it-as-png.cs](load-an-avif-image-using-avifimage-and-save-it-as-png.cs) |
| IMAGINGNET-8171 | Add proper checking if a given TIFF file is supported (including XIF) | Enhancement | [load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs](load-xif-and-tiff-files-with-image-load-and-convert-each-to-png.cs) |
| IMAGINGNET-8123 | Fix inconsistent metadata removal from Tiff: TiffOptions expose metadata properties apart from Exif and Xmp metadata | Enhancement | [load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs](load-an-image-call-removemetadata-and-save-the-image-without-metadata.cs) |
| IMAGINGNET-7739 | Exception on AVIF load | Enhancement | [load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs](load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs) |
| IMAGINGNET-3868 | Support the clipping operation in RasterImageExporter | Enhancement | [export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs](export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs) |

## New and changed APIs covered

| API | Examples |
|-----|----------|
| `Aspose.Imaging.Exif.ExifData` | [load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs](load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs), [load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs](load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs) |
| `Aspose.Imaging.ImageFilters.FilterOptions.BlendingMode` | [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs](blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs), [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs](blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs), [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs](blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs) |
| `Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions` | [apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs](apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs), [apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs](apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs) |
| `Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions` | [blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs](blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs) |

## For AI agents

- These examples target features introduced or changed in Aspose.Imaging for .NET 26.10; reference `Aspose.Imaging` 26.10 or later from NuGet.
- An example linked to a ticket is related to it (written from the ticket's summary). Do not cite it as a reproduction of the issue or as proof that the issue is fixed.
- Each file is self-contained: hardcoded input/output paths, missing input files reported to stderr, output directories created before saving.
- Category examples covering the same formats live in the root folders — see the root [agents.md](../../agents.md).


## Developer Q&A

### Q: Which Aspose.Imaging for .NET version supports applying a blur convolution filter while ignoring the alpha channel?  
A: In version 26.10 you can use **ConvolutionFilterOptions** and set **IgnoreAlpha = true** to blur the image without affecting its alpha channel. → See: [apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs](./apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs)

### Q: In Aspose.Imaging 26.10, how can I apply a sharpen convolution filter with border processing enabled and without ignoring alpha?  
A: Use **ConvolutionFilterOptions** with **BordersProcessing = true** and **IgnoreAlpha = false** to sharpen the image while preserving edge handling. → See: [apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs](./apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs)

### Q: Which Aspose.Imaging for .NET version introduced blending a PNG overlay onto a JPEG background using the Multiply blending mode?  
A: Version 26.10 adds **ImageBlendingFilterOptions** where you set **BlendingMode = BlendingMode.Multiply** to combine the images. → See: [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs)

### Q: How does Aspose.Imaging 26.10 allow blending a PNG overlay onto a JPEG background using the Overlay blending mode?  
A: Use **ImageBlendingFilterOptions** and set **BlendingMode = BlendingMode.Overlay** to achieve the overlay effect. → See: [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs)

### Q: How can I blend a PNG overlay onto a JPEG background using the Screen blending mode in Aspose.Imaging 26.10?  
A: Create an **ImageBlendingFilterOptions** instance and assign **BlendingMode = BlendingMode.Screen** before applying the filter. → See: [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs)

### Q: In Aspose.Imaging 26.10, how do I blend an overlay image onto a base image at a specific position with custom opacity?  
A: Configure **ImageBlendingFilterOptions** with **Position = new Point(50, 30)** and **Opacity = 0.7f** (70 %) and apply it to the base image. → See: [blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs](./blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs)

### Q: Which Aspose.Imaging for .NET version added clipping‑rectangle support when exporting images with RasterImageExporter?  
A: In version 26.10 you can set **RasterImageExporter.ClipRectangle = new Rectangle(10, 15, 100, 100)** to export only the defined region. → See: [export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs](./export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs)

### Q: How can I retrieve the DateTimeOriginal EXIF tag from a JPEG image using Aspose.Imaging 26.10?  
A: Call **ExifData.GetTagValue(ExifTagId.DateTimeOriginal)** on the loaded JPEG image to obtain the original capture date. → See: [load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs](./load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs)

### Q: In Aspose.Imaging 26.10, how do I read the XResolution and YResolution values from JPEG EXIF data?  
A: Access the **ExifData.XResolution** and **ExifData.YResolution** properties after loading the JPEG image. → See: [load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs](./load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs)

### Q: Which Aspose.Imaging for .NET version enables loading an AVIF image and saving it as JPEG using JpegOptions?  
A: Version 26.10 lets you load an AVIF file with **Image.Load** and then save it using **new JpegOptions()** to specify JPEG output settings. → See: [load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs](./load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs)

---
*Maintained by an [agentic example generation workflow](https://metrics.aspose.com/agents/product-families/imaging/) | For AI-friendly guidance, see [AGENTS.md](https://github.com/aspose-imaging/agentic-net-examples/blob/main/agents.md) | Last updated: 2026-10-20*
