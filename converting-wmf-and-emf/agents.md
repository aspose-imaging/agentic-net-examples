---
name: converting-wmf-and-emf
description: C# examples for Converting WMF and EMF using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Converting WMF and EMF

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Converting WMF and EMF** category.
This folder contains standalone C# examples for Converting WMF and EMF operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (29/29 files)
- `using System.IO;` (29/29 files)
- `using Aspose.Imaging;` (29/29 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (29/29 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf;` (7/29 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (3/29 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (3/29 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (3/29 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (2/29 files) ← category-specific
- `using System.Threading.Tasks;` (2/29 files)
- `using System.Net.Http;` (1/29 files)
- `using System.IO.Compression;` (1/29 files)
- `using Aspose.Imaging.Sources;` (1/29 files) ← category-specific
- `using Aspose.Imaging.Exif;` (1/29 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (1/29 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (1/29 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-wmf-file-from-disk-and-save-it-as-a-high-resolution-png-image.cs](./load-a-wmf-file-from-disk-and-save-it-as-a-high-resolution-png-image.cs) | `PngOptions` | Load a WMF file from disk and save it as a high‑resolution PNG image. |
| [load-an-emf-image-from-a-memory-stream-and-export-it-to-tiff-with-lzw-compression.cs](./load-an-emf-image-from-a-memory-stream-and-export-it-to-tiff-with-lzw-compression.cs) | `TiffOptions` | Load an EMF image from a memory stream and export it to TIFF with LZW compressio... |
| [load-wmf-from-a-url-stream-and-save-it-directly-to-a-byte-array-in-bmp-format.cs](./load-wmf-from-a-url-stream-and-save-it-directly-to-a-byte-array-in-bmp-format.cs) | `BmpOptions` | Load WMF from a URL stream and save it directly to a byte array in BMP format. |
| [load-wmf-from-a-compressed-zip-archive-and-convert-each-entry-to-bmp-format.cs](./load-wmf-from-a-compressed-zip-archive-and-convert-each-entry-to-bmp-format.cs) | `BmpOptions` | Load WMF from a compressed zip archive and convert each entry to BMP format. |
| [load-emf-from-a-network-stream-convert-to-png-and-write-output-directly-to-response-stream.cs](./load-emf-from-a-network-stream-convert-to-png-and-write-output-directly-to-response-stream.cs) | `PngOptions` | Load EMF from a network stream, convert to PNG, and write output directly to res... |
| [convert-wmf-to-png-while-preserving-metadata-such-as-author-and-creation-date.cs](./convert-wmf-to-png-while-preserving-metadata-such-as-author-and-creation-date.cs) | `PngOptions`, `WmfRasterizationOptions` | Convert WMF to PNG while preserving metadata such as author and creation date. |
| [convert-wmf-to-png-with-transparent-background-ensuring-the-alpha-channel-is-retained.cs](./convert-wmf-to-png-with-transparent-background-ensuring-the-alpha-channel-is-retained.cs) | `PngOptions`, `WmfRasterizationOptions` | Convert WMF to PNG with transparent background, ensuring the alpha channel is re... |
| [convert-a-wmf-file-to-png-and-apply-a-custom-scaling-factor-of-0-5-during-rasterization.cs](./convert-a-wmf-file-to-png-and-apply-a-custom-scaling-factor-of-0-5-during-rasterization.cs) | `PngOptions`, `WmfRasterizationOptions` | Convert a WMF file to PNG and apply a custom scaling factor of 0.5 during raster... |
| [resize-a-wmf-image-during-conversion-to-png-setting-width-and-height-to-800-pixels-each.cs](./resize-a-wmf-image-during-conversion-to-png-setting-width-and-height-to-800-pixels-each.cs) | `PngOptions`, `WmfImage` | Resize a WMF image during conversion to PNG, setting width and height to 800 pix... |
| [set-dpi-to-300-when-rasterizing-wmf-to-jpeg-to-improve-print-quality.cs](./set-dpi-to-300-when-rasterizing-wmf-to-jpeg-to-improve-print-quality.cs) | `JpegOptions`, `WmfRasterizationOptions` | Set DPI to 300 when rasterizing WMF to JPEG to improve print quality. |
| [convert-wmf-to-jpeg-with-progressive-encoding-to-enable-incremental-loading-in-browsers.cs](./convert-wmf-to-jpeg-with-progressive-encoding-to-enable-incremental-loading-in-browsers.cs) | `JpegOptions`, `WmfRasterizationOptions` | Convert WMF to JPEG with progressive encoding to enable incremental loading in b... |
| [convert-wmf-to-pdf-embedding-the-vector-data-to-retain-scalability-in-the-resulting-document.cs](./convert-wmf-to-pdf-embedding-the-vector-data-to-retain-scalability-in-the-resulting-document.cs) | `PdfOptions`, `WmfRasterizationOptions` | Convert WMF to PDF, embedding the vector data to retain scalability in the resul... |
| [convert-wmf-to-bmp-with-24-bit-color-depth-to-ensure-full-color-representation.cs](./convert-wmf-to-bmp-with-24-bit-color-depth-to-ensure-full-color-representation.cs) | `BmpOptions`, `WmfRasterizationOptions` | Convert WMF to BMP with 24‑bit color depth to ensure full color representation. |
| [convert-emf-to-png-using-anti-aliasing-to-smooth-edges-and-improve-visual-fidelity.cs](./convert-emf-to-png-using-anti-aliasing-to-smooth-edges-and-improve-visual-fidelity.cs) | `EmfRasterizationOptions`, `PngOptions` | Convert EMF to PNG using anti‑aliasing to smooth edges and improve visual fideli... |
| [convert-emf-to-png-and-embed-icc-color-profile-for-consistent-display-across-devices.cs](./convert-emf-to-png-and-embed-icc-color-profile-for-consistent-display-across-devices.cs) | `EmfRasterizationOptions`, `PngOptions` | Convert EMF to PNG and embed ICC color profile for consistent display across dev... |
| [use-a-custom-color-profile-when-converting-emf-to-jpeg-to-maintain-color-accuracy.cs](./use-a-custom-color-profile-when-converting-emf-to-jpeg-to-maintain-color-accuracy.cs) | `JpegOptions` | Use a custom color profile when converting EMF to JPEG to maintain color accurac... |
| [export-emf-as-a-high-quality-jpeg-using-a-quality-setting-of-95-percent.cs](./export-emf-as-a-high-quality-jpeg-using-a-quality-setting-of-95-percent.cs) | `EmfRasterizationOptions`, `JpegOptions` | Export EMF as a high‑quality JPEG using a quality setting of 95 percent. |
| [apply-a-custom-background-color-when-converting-transparent-emf-files-to-jpeg-format.cs](./apply-a-custom-background-color-when-converting-transparent-emf-files-to-jpeg-format.cs) | `EmfImage`, `EmfRasterizationOptions`, `JpegOptions` | Apply a custom background color when converting transparent EMF files to JPEG fo... |
| [convert-emf-to-gif-with-a-limited-color-palette-of-256-colors.cs](./convert-emf-to-gif-with-a-limited-color-palette-of-256-colors.cs) | `GifOptions`, `VectorRasterizationOptions` | Convert EMF to GIF with a limited color palette of 256 colors. |
| [convert-emf-to-jpeg-and-embed-exif-metadata-for-camera-information.cs](./convert-emf-to-jpeg-and-embed-exif-metadata-for-camera-information.cs) | `JpegOptions` | Convert EMF to JPEG and embed EXIF metadata for camera information. |
| [apply-a-grayscale-filter-during-conversion-of-emf-to-bmp-to-produce-monochrome-output.cs](./apply-a-grayscale-filter-during-conversion-of-emf-to-bmp-to-produce-monochrome-output.cs) | `BmpOptions`, `EmfRasterizationOptions` | Apply a grayscale filter during conversion of EMF to BMP to produce monochrome o... |
| [export-emf-to-tiff-using-ccitt-group-4-compression-for-black-and-white-images.cs](./export-emf-to-tiff-using-ccitt-group-4-compression-for-black-and-white-images.cs) | `TiffOptions` | Export EMF to TIFF using CCITT Group 4 compression for black‑and‑white images. |
| [batch-convert-emf-files-to-tiff-applying-lzw-compression-and-setting-resolution-to-150-dpi.cs](./batch-convert-emf-files-to-tiff-applying-lzw-compression-and-setting-resolution-to-150-dpi.cs) | `TiffOptions` | Batch convert EMF files to TIFF, applying LZW compression and setting resolution... |
| [batch-process-a-folder-of-wmf-files-converting-each-to-bmp-while-preserving-original-dimensions.cs](./batch-process-a-folder-of-wmf-files-converting-each-to-bmp-while-preserving-original-dimensions.cs) | `BmpOptions` | Batch process a folder of WMF files, converting each to BMP while preserving ori... |
| [batch-convert-wmf-files-to-png-jpeg-and-bmp-in-a-single-operation-using-format-enumeration.cs](./batch-convert-wmf-files-to-png-jpeg-and-bmp-in-a-single-operation-using-format-enumeration.cs) | `BmpOptions`, `JpegOptions`, `PngOptions` | Batch convert WMF files to PNG, JPEG, and BMP in a single operation using format... |
| [perform-parallel-conversion-of-multiple-wmf-files-to-jpeg-using-parallel-foreach-for-speed.cs](./perform-parallel-conversion-of-multiple-wmf-files-to-jpeg-using-parallel-foreach-for-speed.cs) | `JpegOptions` | Perform parallel conversion of multiple WMF files to JPEG using Parallel.ForEach... |
| [perform-asynchronous-conversion-of-wmf-files-to-jpeg-using-a-task-based-programming-model.cs](./perform-asynchronous-conversion-of-wmf-files-to-jpeg-using-a-task-based-programming-model.cs) | `JpegOptions` | Perform asynchronous conversion of WMF files to JPEG using a Task‑based programm... |
| [convert-a-multi-page-emf-document-to-a-series-of-png-files-one-per-page.cs](./convert-a-multi-page-emf-document-to-a-series-of-png-files-one-per-page.cs) | `PngOptions`, `VectorRasterizationOptions` | Convert a multi‑page EMF document to a series of PNG files, one per page. |
| [set-image-rotation-angle-to-90-degrees-while-converting-emf-to-png.cs](./set-image-rotation-angle-to-90-degrees-while-converting-emf-to-png.cs) | `PngOptions` | Set image rotation angle to 90 degrees while converting EMF to PNG. |

## Category Statistics
- Total examples: 29
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpImage`
- `BmpOptions`
- `EmfImage`
- `EmfRasterizationOptions`
- `GifOptions`
- `JpegOptions`
- `MultiPageOptions`
- `PdfOptions`
- `PngOptions`
- `TiffOptions`
- `VectorRasterizationOptions`
- `WmfImage`
- `WmfRasterizationOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- A desktop publishing tool needs to import legacy Windows Metafile (WMF) assets and export them as high‑resolution PNGs for web use, requiring reliable WMF → PNG conversion in C# with Aspose.Imaging.  
- An enterprise reporting system generates charts as EMF files and must batch‑convert them to PDF for archival, leveraging EMF → PDF conversion capabilities in a .NET environment.  
- A migration script for a legacy application extracts WMF icons from old resource files and converts them to SVG to support modern UI frameworks, using WMF conversion C# code.  
- A cloud‑based document processing service receives user‑uploaded EMF diagrams and needs to rasterize them to JPEG for thumbnail previews, employing Windows metafile conversion in dotnet.  
- A GIS application exports map overlays as EMF and requires automated conversion to TIFF for high‑precision printing, utilizing Aspose.Imaging’s EMF → TIFF conversion in C#.

## Related Categories  
The conversion utilities in this folder complement the **Image Format Conversion** examples, where you can see how to move between raster and vector formats beyond WMF and EMF. If you need to manipulate the visual content before conversion, the **Image Editing** category offers cropping, resizing, and color adjustments that can be applied to the metafile data. For scenarios that involve rendering WMF or EMF files onto other canvases, the **Graphics Rendering** examples demonstrate drawing metafiles onto PDFs or other image types, providing a natural next step after conversion. Together, these sections give a complete workflow for handling Windows metafiles in .NET applications.


## Developer Q&A

### Q: How to load a WMF file from disk and save it as a high‑resolution PNG in .NET C#?  
Use `Image.Load` to open the WMF file and call `image.Save` with `PngOptions` where you set the desired resolution. Aspose.Imaging for .NET (C#) handles the conversion in a single step. → See: `load-a-wmf-file-from-disk-and-save-it-as-a-high-resolution-png-image.cs`

### Q: How do I convert an EMF image from a memory stream to a TIFF with LZW compression using C#?  
Load the EMF via `Image.Load(memoryStream)` and then call `image.Save` with `TiffOptions` setting `Compression = TiffCompression.Lzw`. Aspose.Imaging for .NET performs the rasterization and compression automatically. → See: `load-an-emf-image-from-a-memory-stream-and-export-it-to-tiff-with-lzw-compression.cs`

### Q: How to preserve WMF metadata such as author and creation date when converting to PNG in .NET?  
After loading the WMF with `Image.Load`, assign its `Metadata` to the `PngOptions` before saving with `image.Save`. The metadata is retained in the resulting PNG file. → See: `convert-wmf-to-png-while-preserving-metadata-such-as-author-and-creation-date.cs`

### Q: How do I set DPI to 300 when rasterizing a WMF to JPEG in C#?  
Create a `WmfRasterizationOptions` object, set `ResolutionX` and `ResolutionY` to 300, assign it to `JpegOptions`, then call `image.Save`. This uses Aspose.Imaging for .NET to produce a high‑resolution JPEG. → See: `set-dpi-to-300-when-rasterizing-wmf-to-jpeg-to-improve-print-quality.cs`

### Q: How to embed an ICC color profile when converting an EMF to PNG using Asp



### Q: How can I set a custom background color when converting a transparent EMF to JPEG with Aspose.Imaging in C#?  
Use `JpegOptions` and set its `BackgroundColor` property before calling `image.Save(outputPath, jpegOptions)`. This fills transparent areas with the specified color during conversion. → See: `apply-a-custom-background-color-when-converting-transparent-emf-files-to-jpeg-format.cs`

### Q: How do I apply a grayscale filter while converting an EMF to BMP using Aspose.Imaging for .NET?  
Load the EMF with `Image.Load`, create a `BmpOptions` object, set `BmpOptions.ColorType = BmpColorType.Grayscale`, and save the image. The grayscale setting forces monochrome output. → See: `apply-a-grayscale-filter-during-conversion-of-emf-to-bmp-to-produce-monochrome-output.cs`

### Q: How can I batch‑convert EMF files to TIFF with LZW compression and a resolution of 150 dpi using Aspose.Imaging?  
Iterate over the EMF files, create a `TiffOptions` instance, set `Compression = TiffCompression.Lzw` and `Resolution = new Resolution(150)`, then call `image.Save(outputPath, tiffOptions)` for each file. This applies LZW compression and the desired DPI to all outputs. → See: `batch-convert-emf-files-to-tiff-applying-lzw-compression-and-setting-resolution-to-150-dpi.cs`

### Q: How do I convert a multi‑page EMF document into separate PNG files, one per page, with Aspose.Imaging in C#?  
Load the EMF as an `Image`, cast it to `IMultipageImage`, loop through `multipage.PageCount`, set `PngOptions` for each page, and call `multipage.Save(pagePath, pngOptions, pageIndex)`. Each iteration writes a single page to its own PNG file. → See: `convert-a-multi-page-emf-document-to-a-series-of-png-files-one-per-page.cs`

### Q: How can I rasterize a WMF to PNG at half its original size using Aspose.Imaging?  
Create `RasterizationOptions`, set `ScaleX = 0.5f` and `ScaleY = 0.5f`, assign them to `PngOptions`, then load the WMF and save with those options. The scaling factors reduce the rasterized image dimensions by 50 %. → See: `convert-a-wmf-file-to-png-and-apply-a-custom-scaling-factor-of-0-5-during-rasterization.cs`

### Q: How can I check for the existence of an EMF file and ensure the output directory is created before converting it to JPEG with Aspose.Imaging in C#?  
Use `File.Exists` to verify the source EMF and `Directory.CreateDirectory` for the target folder, then load the image with `Image.Load` and save it using `JpegOptions`. → See: apply-a-custom-background-color-when-converting-transparent-emf-files-to-jpeg-format.cs  

### Q: How do I set the JPEG quality to 90 when rasterizing a transparent EMF to JPEG using Aspose.Imaging in C#?  
Create a `JpegOptions` instance, set its `Quality = 90`, configure `RasterizationOptions` (e.g., background color), and call `image.Save(outputPath, jpegOptions)`. → See: apply-a-custom-background-color-when-converting-transparent-emf-files-to-jpeg-format.cs  

### Q: How can I limit the color palette to 256 colors when converting an EMF file to GIF with Aspose.Imaging in C#?  
Instantiate `GifOptions`, set `ColorCount = 256`

### Q: How can I batch convert WMF files to PNG, JPEG, and BMP in a single operation using Aspose.Imaging’s format enumeration in C#?  
Load each WMF with `Image.Load` and call `image.Save` inside a loop, passing the appropriate `ImageOptions` (e.g., `PngOptions`, `JpegOptions`, `BmpOptions`) selected via `ExportImageFormat`. → See: batch-convert-wmf-files-to-png-jpeg-and-bmp-in-a-single-operation-using-format-enumeration.cs  

### Q: How do I preserve the original dimensions when converting a folder of WMF files to BMP using Aspose.Imaging in C#?  
Simply load each WMF with `Image.Load` and save it using `BmpOptions`; without altering width or height the library retains the source size automatically. → See: batch-process-a-folder-of-wmf-files-converting-each-to-bmp-while-preserving-original-dimensions.cs  

### Q: How can I rasterize a WMF to PNG at half its original size using a custom scaling factor with Aspose.Imaging in C#?  
After loading the WMF, set `PngOptions.VectorRasterizationOptions.ScaleX` and `ScaleY` to `0.5` before calling `image.Save`. → See: convert-a-wmf-file-to-png-and-apply-a-custom-scaling-factor-of-0-5-during-rasterization.cs  

### Q: How do I embed EXIF camera metadata into a JPEG generated from an EMF file using Aspose.Imaging in C#?  
Create `JpegOptions`, populate its `ExifData` (e.g., `CameraModel`, `DateTime`) and then save the loaded
## Operations Covered
- Apply custom background color to transparent EMF  
- Convert EMF images to JPEG format  
- Apply grayscale filter during EMF‑to‑BMP conversion  
- Batch convert EMF files to TIFF with LZW compression  
- Set image resolution to 150 DPI while converting  
- Batch convert WMF files to PNG, JPEG, and BMP using format enumeration  
- Preserve original dimensions when converting WMF to BMP  
- Export each page of a multi‑page EMF document to separate PNG files  
- Rasterize WMF to PNG with a custom scaling factor of 0.5  

## Supported Formats
- **EMF** – source vector format used in several conversions  
- **WMF** – source vector format used in batch and single‑file conversions  
- **JPEG** – target format for EMF conversion with background handling  
- **BMP** – target format for EMF and WMF conversions, including grayscale output  
- **TIFF** – target format for EMF batch conversion with LZW compression and DPI settings  
- **PNG** – target format for WMF conversion and multi‑page EMF export  

## API Classes Used
- `Image` — base class for loading, manipulating, and saving images.  
- `EmfImage` — represents an EMF file; provides EMF‑specific properties after casting from `Image`.  
- `WmfImage` — represents a WMF file; gives access to WMF‑specific features.  
- `JpegOptions` — defines options for saving JPEG images, such as background color handling.  
- `BmpOptions` — defines options for saving BMP images, including grayscale processing.  
- `TiffOptions` — defines options for saving TIFF images, allowing compression type and resolution settings.  
- `PngOptions` — defines options for saving PNG images, supporting scaling factors during rasterization.  
- `IMultipageImage` — interface for images that contain multiple pages; provides `PageCount` and page‑wise access.  
- `TiffCompression` — enumeration that specifies TIFF compression algorithms (e.g., LZW).  
- `Image.Load(string path)` — static method that loads an image from the given file path.  
- `Image.Save(string path, ImageOptions options)` — instance method that saves the image using specified format options.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-27 | Run: `20260627_021954` | Examples: 29
<!-- AUTOGENERATED:END -->