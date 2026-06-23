# Image Format Manipulation C# with Aspose.Imaging

Explore practical code samples that demonstrate **image format manipulation C#** using Aspose.Imaging for .NET. These examples cover common multi‑format imaging dotnet scenarios such as loading, converting, and preserving image attributes across BMP, PNG, and JPEG files.

## What's in This Category
- Load a BMP image from the file system and read its pixel dimensions.  
- Save a loaded BMP image as PNG while keeping the original color depth and transparency.  
- Convert BMP files to JPEG with configurable compression quality.  
- (Additional samples) Adjust image metadata during format conversion.  
- (Additional samples) Batch‑process multiple image formats in a single workflow.

## Quick Start
The most frequent task is converting a BMP to PNG while preserving its visual fidelity:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

string sourcePath = @"Images/input.bmp";
string destPath   = @"Images/output.png";

using (Image bmp = Image.Load(sourcePath))
{
    var pngOptions = new PngOptions
    {
        ColorType = PngColorType.TruecolorWithAlpha,
        BitDepth  = 8
    };
    bmp.Save(destPath, pngOptions);
}
```

Add the Aspose.Imaging package to your project:

```bash
dotnet add package Aspose.Imaging
```

## Files

Examples and tasks in this folder:

| Example | |
|---------|---|
| [access-clipping-paths-of-a-tiff-frame-via-pathresources-and-export-them-as-svg-files.cs](./access-clipping-paths-of-a-tiff-frame-via-pathresources-and-export-them-as-svg-files.cs) |
| [add-a-custom-thumbnail-to-the-exif-segment-of-a-jpeg-image-and-verify-metadata.cs](./add-a-custom-thumbnail-to-the-exif-segment-of-a-jpeg-image-and-verify-metadata.cs) |
| [add-a-custom-thumbnail-to-the-jfif-segment-of-a-jpeg-image-before-saving.cs](./add-a-custom-thumbnail-to-the-jfif-segment-of-a-jpeg-image-before-saving.cs) |
| [add-a-generated-thumbnail-to-both-jfif-and-exif-segments-of-a-jpeg-image-simultaneously.cs](./add-a-generated-thumbnail-to-both-jfif-and-exif-segments-of-a-jpeg-image-simultaneously.cs) |
| [add-a-new-frame-to-a-tiff-using-custom-compression-and-set-a-unique-description-tag.cs](./add-a-new-frame-to-a-tiff-using-custom-compression-and-set-a-unique-description-tag.cs) |
| [add-a-new-frame-to-an-existing-tiff-using-jpeg-compression-and-set-a-custom-comment-tag.cs](./add-a-new-frame-to-an-existing-tiff-using-jpeg-compression-and-set-a-custom-comment-tag.cs) |
| [add-a-new-tiff-frame-with-custom-dimensions-lzw-compression-and-specific-resolution-settings.cs](./add-a-new-tiff-frame-with-custom-dimensions-lzw-compression-and-specific-resolution-settings.cs) |
| [add-a-semi-transparent-watermark-text-to-a-dng-photo-and-save-as-png.cs](./add-a-semi-transparent-watermark-text-to-a-dng-photo-and-save-as-png.cs) |
| [add-a-textual-watermark-to-a-bmp-image-at-the-bottom-right-corner-with-configurable-opacity.cs](./add-a-textual-watermark-to-a-bmp-image-at-the-bottom-right-corner-with-configurable-opacity.cs) |
| [add-a-tiff-frame-with-custom-dimensions-ccitt-group-4-compression-and-specific-dpi-values-for-scanning-quality.cs](./add-a-tiff-frame-with-custom-dimensions-ccitt-group-4-compression-and-specific-dpi-values-for-scanning-quality.cs) |
| [add-a-tiff-frame-with-custom-photometric-interpretation-and-save-the-multi-frame-image-using-lzw-compression.cs](./add-a-tiff-frame-with-custom-photometric-interpretation-and-save-the-multi-frame-image-using-lzw-compression.cs) |
| [add-a-tiff-frame-with-custom-photometric-interpretation-and-save-the-updated-image-using-jpeg-compression.cs](./add-a-tiff-frame-with-custom-photometric-interpretation-and-save-the-updated-image-using-jpeg-compression.cs) |
| [add-a-tiff-frame-with-custom-tile-size-and-compression-then-save-the-multi-frame-image-to-disk.cs](./add-a-tiff-frame-with-custom-tile-size-and-compression-then-save-the-multi-frame-image-to-disk.cs) |
| [adjust-brightness-and-contrast-of-a-bmp-image-with-custom-parameters-and-save-the-modified-copy.cs](./adjust-brightness-and-contrast-of-a-bmp-image-with-custom-parameters-and-save-the-modified-copy.cs) |
| [adjust-dng-contrast-by-30-percent-and-save-the-result-as-tiff.cs](./adjust-dng-contrast-by-30-percent-and-save-the-result-as-tiff.cs) |
| [adjust-emfimage-dpix-and-dpiy-properties-before-exporting-to-a-raster-format.cs](./adjust-emfimage-dpix-and-dpiy-properties-before-exporting-to-a-raster-format.cs) |
| [adjust-the-gamma-of-a-dng-image-to-2-2-and-export-as-png.cs](./adjust-the-gamma-of-a-dng-image-to-2-2-and-export-as-png.cs) |
| [append-additional-frames-with-varying-parameters-to-an-existing-tiff-image-using-the-tiff-format.cs](./append-additional-frames-with-varying-parameters-to-an-existing-tiff-image-using-the-tiff-format.cs) |
| [apply-a-custom-scaling-factor-of-1-5-to-an-eps-image-and-export-it-as-a-high-quality-jpeg.cs](./apply-a-custom-scaling-factor-of-1-5-to-an-eps-image-and-export-it-as-a-high-quality-jpeg.cs) |
| [apply-a-gaussian-blur-effect-to-a-bmp-image-for-background-softening-in-design-mockups.cs](./apply-a-gaussian-blur-effect-to-a-bmp-image-for-background-softening-in-design-mockups.cs) |
| [apply-a-gaussian-blur-with-radius-five-to-an-emf-image-and-export-as-png.cs](./apply-a-gaussian-blur-with-radius-five-to-an-emf-image-and-export-as-png.cs) |
| [apply-a-grayscale-filter-to-a-bmp-image-and-export-the-result-as-tiff-for-archival-storage.cs](./apply-a-grayscale-filter-to-a-bmp-image-and-export-the-result-as-tiff-for-archival-storage.cs) |
| [apply-a-memory-saving-strategy-by-processing-each-webp-frame-individually-and-releasing-resources-after-saving.cs](./apply-a-memory-saving-strategy-by-processing-each-webp-frame-individually-and-releasing-resources-after-saving.cs) |
| [apply-a-memory-saving-strategy-by-processing-tiff-pages-one-at-a-time-using-sequential-export-mode.cs](./apply-a-memory-saving-strategy-by-processing-tiff-pages-one-at-a-time-using-sequential-export-mode.cs) |
| [apply-a-sepia-tone-effect-to-an-emf-illustration-and-export-as-png.cs](./apply-a-sepia-tone-effect-to-an-emf-illustration-and-export-as-png.cs) |
| [apply-a-sharpening-filter-with-strength-three-to-a-tga-texture-and-export-as-bmp.cs](./apply-a-sharpening-filter-with-strength-three-to-a-tga-texture-and-export-as-bmp.cs) |
| [apply-a-solid-background-color-to-a-png-image-with-transparency-replacing-its-alpha-channel-uniformly.cs](./apply-a-solid-background-color-to-a-png-image-with-transparency-replacing-its-alpha-channel-uniformly.cs) |
| [apply-a-vignette-effect-around-the-edges-of-a-tga-picture-and-save-as-jpeg.cs](./apply-a-vignette-effect-around-the-edges-of-a-tga-picture-and-save-as-jpeg.cs) |
| [apply-additional-resizing-operations-to-a-dicom-image-while-maintaining-full-dicom-format-compliance.cs](./apply-additional-resizing-operations-to-a-dicom-image-while-maintaining-full-dicom-format-compliance.cs) |
| [apply-coordinate-offsets-to-crop-a-dicom-image-outputting-the-result-as-a-dicom-file.cs](./apply-coordinate-offsets-to-crop-a-dicom-image-outputting-the-result-as-a-dicom-file.cs) |
| | [**View all 600 examples ↗**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/manipulate-different-image-file-formats) |

## Requirements
- **Aspose.Imaging** NuGet package (`dotnet add package Aspose.Imaging`)
- **.NET 9** or later

[← Back to main README](../README.md)