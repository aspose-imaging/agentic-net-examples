---
name: merge-images
description: C# examples for Merge Images using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Merge Images

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Merge Images** category.
This folder contains standalone C# examples for Merge Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using Aspose.Imaging;` (41/135 files) ← category-specific
- `using System;` (40/135 files)
- `using System.IO;` (40/135 files)
- `using Aspose.Imaging.ImageOptions;` (40/135 files) ← category-specific
- `using System.Collections.Generic;` (38/135 files)
- `using Aspose.Imaging.Sources;` (35/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (33/135 files) ← category-specific
- `using System.Linq;` (32/135 files)
- `using Aspose.Imaging.FileFormats.Pdf;` (6/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (5/135 files) ← category-specific
- `using System.Net;` (1/135 files)
- `using System.Net.Sockets;` (1/135 files)
- `using System.Threading;` (1/135 files)
- `using Aspose.Imaging.Brushes;` (1/135 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs](./load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Load multiple JPEG files from a directory and merge them horizontally into a sin... |
| [load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs](./load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Load several JPEG pictures, arrange them vertically, and save the combined resul... |
| [combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs](./combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Combine a set of JPEG images horizontally and output the merged picture as a PDF... |
| [merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs](./merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs) | `PngOptions`, `RasterImage` | Merge multiple JPEG files side by side and store the final composition in PNG fo... |
| [resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs](./resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Resize each input JPEG to a uniform width before performing a horizontal merge a... |
| [rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs](./rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Rotate every JPEG image ninety degrees clockwise, then merge them vertically and... |
| [flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs](./flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs) | `PngOptions`, `RasterImage` | Flip each JPEG image horizontally, compose them in a horizontal layout, and expo... |
| [crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs](./crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Crop all JPEG pictures to a central square region, merge them vertically, and wr... |
| [apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs](./apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Apply a uniform background color to the canvas before merging JPEG images horizo... |
| [set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs](./set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Set the output DPI to 300 when merging JPEG files horizontally and saving the re... |
| [specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs](./specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Specify JPEG quality level of 85 while merging images vertically and storing the... |
| [use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs](./use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs) | `JpegImage`, `JpegOptions`, `LoadOptions` | Use ImageLoadOptions to limit memory usage while loading JPEG files for a horizo... |
| [create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs](./create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Create a memory stream, merge JPEG images horizontally, and write the combined o... |
| [read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs](./read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs) | `Graphics`, `JpegImage`, `JpegOptions` | Read JPEG images from a network stream, merge them vertically, and send the resu... |
| [process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs](./process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | Process a batch of JPEG folders, merging each folder's images horizontally into ... |
| [implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs](./implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs) | `PngOptions`, `RasterImage` | Implement parallel loading of JPEG files, then merge them vertically and save th... |
| [use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs](./use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Use a cancellation token to abort a long-running horizontal JPEG merge operation... |
| [log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs](./log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Log progress percentage after each JPEG image is added to the canvas during a ve... |
| [wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs](./wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs) | `PngOptions`, `RasterImage` | Wrap image loading and merging code in try‑catch blocks to handle file‑access ex... |
| [employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs](./employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs) | `PngOptions`, `RasterImage` | Employ using statements to ensure all Image objects are disposed after completin... |
| [generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs](./generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Generate output filenames by appending a timestamp to the original JPEG name for... |
| [save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs](./save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs) | `JpegOptions` | Save merged JPEG images to a temporary folder, then move them to the final desti... |
| [configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs](./configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | Configure PdfOptions to use A4 page size when saving a horizontally merged JPEG ... |
| [enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs](./enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs) | `PngOptions`, `RasterImage` | Enable PNG interlacing in PngOptions while merging JPEG images horizontally and ... |
| [set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs](./set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Set JPEG subsampling to 4:2:0 in JpegOptions during a vertical merge to reduce f... |
| [apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs](./apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | Apply a grayscale color conversion to each JPEG before merging them horizontally... |
| [convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs](./convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Convert each JPEG to CMYK color space prior to a vertical merge and save the res... |
| [add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) | `Graphics`, `JpegImage`, `JpegOptions` | Add a semi‑transparent watermark text to the merged image after completing a hor... |
| [overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs](./overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs) | `PngOptions`, `RasterImage` | Overlay a logo PNG on the bottom‑right corner of the merged JPEG image before sa... |
| [insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs](./insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Insert a 10‑pixel padding between each JPEG image during a vertical merge to imp... |
| *...and 105 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.8.0/merge-images) |

## Category Statistics
- Total examples: 135
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngImage`
- `ApngOptions`
- `BigTiffImage`
- `BigTiffOptions`
- `BmpOptions`
- `CmxImage`
- `DicomImage`
- `DicomOptions`
- `DjvuImage`
- `EmfOptions`
- `EmfRasterizationOptions`
- `GifImage`
- `GifOptions`
- `Graphics`
- `IcoImage`
- `IcoOptions`
- `Jpeg2000Image`
- `Jpeg2000Options`
- `JpegImage`
- `JpegLoadOptions`
- `JpegOptions`
- `LoadOptions`
- `OdgRasterizationOptions`
- `OtgRasterizationOptions`
- `PdfCoreOptions`
- `PdfOptions`
- `PngOptions`
- `PsdOptions`
- `RasterImage`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `TgaOptions`
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`
- `WebPImage`
- `WebPOptions`
- `WmfOptions`
- `WmfRasterizationOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- Building a photo‑gallery web app where you need to **merge images C#** to create thumbnail collages on the fly.  
- Developing a document generation service that **combines images dotnet** into a single banner for PDF reports.  
- Implementing an e‑commerce platform that stitches product photos into a panoramic view using **image stitching C#** for better visual presentation.  
- Creating a batch processing tool that merges scanned pages into a single multi‑page TIFF for archival purposes.  
- Designing a social‑media scheduler that automatically combines user‑uploaded stickers and backgrounds into one final image before posting.

## Related Categories  
The techniques demonstrated in the Merge Images examples often complement the **Resize & Crop** and **Watermark** categories, where you may need to adjust dimensions or add branding before stitching images together. Likewise, the **Format Conversion** examples can be useful when the combined output must be saved in a different file type, such as converting a stitched PNG into a compressed JPEG for web delivery. Exploring these adjacent sections can give you a complete workflow for advanced image manipulation in Aspose.Imaging for .NET.


## Operations Covered
- Merge JPEG images horizontally  
- Add semi‑transparent text watermark to merged image  
- Convert JPEG to TGA format  
- Combine TGA image into a PDF document  
- Convert JPEG to EMF while preserving vector fidelity  
- Merge multiple JPEGs into a single PDF via EMF  
- Merge multiple JPEGs into a PNG output applying JPEG compression settings  
- Merge multiple JPEGs vertically into a single JPEG file  
- Preserve image fidelity during JPEG merging  
- Convert JPEG to SVGZ before creating a PDF  

## Supported Formats
- **JPEG** – source images for all merge and conversion scenarios  
- **PNG** – output format when merging JPEGs with custom compression  
- **TGA** – intermediate raster format used before PDF generation  
- **PDF** – final document format produced from TGA, EMF, or SVGZ images  
- **EMF** – intermediate vector format that keeps vector fidelity during PDF creation  
- **SVGZ** – compressed SVG format used as an intermediate step before PDF  

## API Classes Used
- `Image` — base class for loading any image and saving it with specified options.  
- `RasterImage` — concrete class for raster images (e.g., JPEG) providing pixel‑level access.  
- `JpegOptions` — defines settings (quality, compression) when saving an image as JPEG.  
- `PngOptions` — defines settings when saving an image as PNG.  
- `TgaOptions` — defines settings for saving an image in TGA format.  
- `EmfOptions` – defines settings for saving an image as an EMF vector file.  
- `PdfOptions` – defines settings for saving images or documents as PDF files.  
- `SolidBrush` (from `Aspose.Imaging.Brushes`) – used to create a semi‑transparent brush for watermark text.  
- `ImageOptions` – base class for all format‑specific option classes.  
- `Directory` – creates output directories if they do not exist.  
- `File` – checks for the existence of input files.

<!-- AUTOGENERATED:START -->
Updated: 2026-08-20 | Run: `20260731_111727` | Examples: 135
<!-- AUTOGENERATED:END -->

## Developer Q&A

### Q: How do I add a semi‑transparent text watermark to a horizontally merged JPEG image using Aspose.Imaging in C#?  
Use **JpegImage** to load and merge the JPEGs, then draw the watermark with **Graphics.DrawString** using a **SolidBrush** with an alpha value, and finally save the image. → See: `add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs`

### Q: How can I combine several JPEG images side‑by‑side and export the merged result directly as a PDF with Aspose.Imaging for .NET?  
Load each JPEG as a **RasterImage**, merge them into one image, and save the result with **PdfOptions** via **Image.Save**. → See: `combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs`

### Q: How do I merge multiple JPG files into a single PNG and then package it into an EMZ file while preserving visual fidelity using Aspose.Imaging?  
Convert each JPG to a **RasterImage**, merge them into a PNG using **PngOptions**, then wrap the PNG stream in an **EmzImage** and save. → See: `combine-jpg-images-into-a-single-png-output-encapsulated-within-an-emz-file-while-preserving-visual-fidelity.cs`

### Q: How can I programmatically create an animated GIF from a collection of JPEG images with Aspose.Imaging in C#?  
Load the JPEGs as **ImageFrames**, add them to a **GifImage** with **GifImage.AddFrame** (setting frame delays as needed), and save using **GifOptions**. → See: `combine-multiple-jpg-images-into-a-single-gif-file-using-a-programmatic-merging-operation.cs`

### Q: How do I merge multiple JPEG images into one JPEG by first converting them to BMP format using Aspose.Imaging?  
Load each JPEG, save it temporarily as a **BmpImage**, merge the BMPs with **Image.Merge**, and finally save the combined image as JPEG via **JpegOptions**. → See: `programmatically-combine-multiple-jpeg-files-into-a-single-jpeg-output-by-converting-and-merging-through-bmp-format.cs`