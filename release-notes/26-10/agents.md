# Aspose.Imaging for .NET 26.10 — Release Examples

Build-verified C# examples for the features, enhancements and fixes shipped in [Aspose.Imaging for .NET 26.10](https://releases.aspose.com/imaging/net/release-notes/2026/aspose-imaging-for-net-26-10-release-notes/). Each file is a standalone console program that compiled against Aspose.Imaging 26.10.0 (NuGet).

**Examples:** 13  
**Requires:** Aspose.Imaging for .NET 26.10 or later

## Examples

| Example | What it shows | Source |
|---------|---------------|--------|
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

| Key | Summary | Category | Examples |
|-----|---------|----------|----------|
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
- Each file is self-contained: hardcoded input/output paths, missing input files reported to stderr, output directories created before saving.
- Category examples covering the same formats live in the root folders — see the root [agents.md](../../agents.md).

## Developer Q&A

### Q: Which Aspose.Imaging for .NET version supports applying a blur convolution filter while ignoring the alpha channel?  
A: In version 26.10 you can use **ConvolutionFilterOptions** with `IgnoreAlpha = true` and call `ApplyFilter` on the image. → See: [apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs](./apply-a-blur-convolution-filter-to-an-image-with-ignorealpha-set-to-true-then-save-the-filtered-image.cs)

### Q: How do I apply a sharpen convolution filter with border processing enabled and alpha not ignored in Aspose.Imaging 26.10?  
A: Set **ConvolutionFilterOptions** `BordersProcessing = true` and `IgnoreAlpha = false`, then invoke `ApplyFilter`. → See: [apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs](./apply-a-sharpen-convolution-filter-to-an-image-with-bordersprocessing-enabled-and-ignorealpha-disabled-then.cs)

### Q: Which Aspose.Imaging for .NET version introduced blending a PNG overlay onto a JPEG background using the Multiply mode?  
A: Use **ImageBlendingFilterOptions** with `BlendingMode = BlendingMode.Multiply` and apply it via `ApplyFilter`. → See: [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-multiply-and-save.cs)

### Q: How can I blend a PNG overlay onto a JPEG background using the Overlay blending mode in Aspose.Imaging 26.10?  
A: Create **ImageBlendingFilterOptions** and set `BlendingMode = BlendingMode.Overlay`, then call `ApplyFilter`. → See: [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-overlay-and-save.cs)

### Q: Which Aspose.Imaging for .NET version allows blending a PNG overlay onto a JPEG background with the Screen mode?  
A: Set **ImageBlendingFilterOptions** `BlendingMode = BlendingMode.Screen` and apply the filter to the base image. → See: [blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs](./blend-a-png-overlay-onto-a-jpeg-background-using-imageblendingfilteroptions-with-blendingmode-screen-and-save.cs)

### Q: How do I blend an overlay image onto a base image at position (50, 30) with 70 % opacity in Aspose.Imaging 26.10?  
A: Configure **ImageBlendingFilterOptions** with `Position = new Point(50,30)` and `Opacity = 0.7f`, then call `ApplyFilter`. → See: [blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs](./blend-an-overlay-image-onto-a-base-image-at-position-50-30-with-70-opacity-using-imageblendingfilteroptions-and.cs)

### Q: Which Aspose.Imaging for .NET version added clipping‑rectangle support to RasterImageExporter?  
A: In 26.10 you can set `RasterImageExporter.ClipRectangle = new Rectangle(10, 15, 100, 100)` before exporting. → See: [export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs](./export-a-set-of-images-to-various-formats-using-rasterimageexporter-with-a-clipping-rectangle-of-10-15-100-100.cs)

### Q: How can I retrieve the DateTimeOriginal EXIF tag from a JPEG image using Aspose.Imaging 26.10?  
A: Load the JPEG as **JpegImage** and call `image.ExifData.GetTagValue(ExifTagId.DateTimeOriginal)`. → See: [load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs](./load-a-jpeg-image-and-retrieve-the-value-of-the-exifproperties-datetimeoriginal-tag-using-gettagvalue.cs)

### Q: How do I read the XResolution and YResolution EXIF properties from a JPEG in Aspose.Imaging 26.10?  
A: Access `jpegImage.ExifData.XResolution` and `jpegImage.ExifData.YResolution` after loading the file. → See: [load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs](./load-a-jpeg-image-read-its-exifdata-xresolution-and-yresolution-properties-and-print-the-values.cs)

### Q: Which Aspose.Imaging for .NET version lets me convert an AVIF image to JPEG?  
A: Load the file as **AvifImage** and save it using **JpegOptions** with `image.Save("output.jpg", new JpegOptions())`. → See: [load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs](./load-an-avif-image-and-save-it-as-jpeg-using-jpegoptions.cs)


---
*Maintained by an [agentic example generation workflow](https://metrics.aspose.com/agents/product-families/imaging/) | For AI-friendly guidance, see [AGENTS.md](https://github.com/aspose-imaging/agentic-net-examples/blob/main/agents.md) | Last updated: 2026-10-13*
