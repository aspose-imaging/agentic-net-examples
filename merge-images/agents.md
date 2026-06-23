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

- `using System;` (40/135 files)
- `using System.IO;` (40/135 files)
- `using Aspose.Imaging.ImageOptions;` (40/135 files) ← category-specific
- `using System.Collections.Generic;` (38/135 files)
- `using Aspose.Imaging;` (38/135 files) ← category-specific
- `using Aspose.Imaging.Sources;` (36/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (35/135 files) ← category-specific
- `using System.Linq;` (24/135 files)
- `using Aspose.Imaging.FileFormats.Pdf;` (6/135 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (4/135 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (1/135 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs](./load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs) | `JpegImage`, `JpegOptions` | load multiple jpeg files from a directory and merge them horizontally into a sin... |
| [load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs](./load-several-jpeg-pictures-arrange-them-vertically-and-save-the-combined-result-as-a-jpeg-file.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | load several jpeg pictures arrange them vertically and save the combined result ... |
| [combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs](./combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | combine a set of jpeg images horizontally and output the merged picture as a pdf... |
| [merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs](./merge-multiple-jpeg-files-side-by-side-and-store-the-final-composition-in-png-format.cs) | `Graphics`, `JpegImage`, `PngOptions` | merge multiple jpeg files side by side and store the final composition in png fo... |
| [resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs](./resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | resize each input jpeg to a uniform width before performing a horizontal merge a... |
| [rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs](./rotate-every-jpeg-image-ninety-degrees-clockwise-then-merge-them-vertically-and-save-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | rotate every jpeg image ninety degrees clockwise then merge them vertically and ... |
| [flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs](./flip-each-jpeg-image-horizontally-compose-them-in-a-horizontal-layout-and-export-the-result-as-png.cs) | `PngOptions`, `RasterImage` | flip each jpeg image horizontally compose them in a horizontal layout and export... |
| [crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs](./crop-all-jpeg-pictures-to-a-central-square-region-merge-them-vertically-and-write-the-output-as-pdf.cs) | `JpegImage`, `PdfOptions`, `PngOptions` | crop all jpeg pictures to a central square region merge them vertically and writ... |
| [apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs](./apply-a-uniform-background-color-to-the-canvas-before-merging-jpeg-images-horizontally-and-saving-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | apply a uniform background color to the canvas before merging jpeg images horizo... |
| [set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs](./set-the-output-dpi-to-300-when-merging-jpeg-files-horizontally-and-saving-the-result-as-pdf.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | set the output dpi to 300 when merging jpeg files horizontally and saving the re... |
| [specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs](./specify-jpeg-quality-level-of-85-while-merging-images-vertically-and-storing-the-final-file-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | specify jpeg quality level of 85 while merging images vertically and storing the... |
| [use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs](./use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs) | `JpegImage`, `JpegOptions`, `LoadOptions` | use imageloadoptions to limit memory usage while loading jpeg files for a horizo... |
| [create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs](./create-a-memory-stream-merge-jpeg-images-horizontally-and-write-the-combined-output-directly-to-the-stream.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | create a memory stream merge jpeg images horizontally and write the combined out... |
| [read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs](./read-jpeg-images-from-a-network-stream-merge-them-vertically-and-send-the-resulting-jpeg-back.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | read jpeg images from a network stream merge them vertically and send the result... |
| [process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs](./process-a-batch-of-jpeg-folders-merging-each-folder-s-images-horizontally-into-separate-pdf-files.cs) | `JpegOptions`, `PdfOptions`, `RasterImage` | process a batch of jpeg folders merging each folder s images horizontally into s... |
| [implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs](./implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs) | `PngOptions`, `RasterImage` | implement parallel loading of jpeg files then merge them vertically and save the... |
| [use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs](./use-a-cancellation-token-to-abort-a-long-running-horizontal-jpeg-merge-operation-when-requested.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | use a cancellation token to abort a long running horizontal jpeg merge operation... |
| [log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs](./log-progress-percentage-after-each-jpeg-image-is-added-to-the-canvas-during-a-vertical-merge.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | log progress percentage after each jpeg image is added to the canvas during a ve... |
| [wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs](./wrap-image-loading-and-merging-code-in-try-catch-blocks-to-handle-file-access-exceptions-gracefully.cs) | `JpegImage`, `JpegOptions` | wrap image loading and merging code in try catch blocks to handle file access ex... |
| [employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs](./employ-using-statements-to-ensure-all-image-objects-are-disposed-after-completing-a-jpeg-to-png-merge.cs) | `PngOptions`, `RasterImage` | employ using statements to ensure all image objects are disposed after completin... |
| [generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs](./generate-output-filenames-by-appending-a-timestamp-to-the-original-jpeg-name-for-each-merged-result.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | generate output filenames by appending a timestamp to the original jpeg name for... |
| [save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs](./save-merged-jpeg-images-to-a-temporary-folder-then-move-them-to-the-final-destination-after-verification.cs) | `JpegOptions` | save merged jpeg images to a temporary folder then move them to the final destin... |
| [configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs](./configure-pdfoptions-to-use-a4-page-size-when-saving-a-horizontally-merged-jpeg-collection-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | configure pdfoptions to use a4 page size when saving a horizontally merged jpeg ... |
| [enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs](./enable-png-interlacing-in-pngoptions-while-merging-jpeg-images-horizontally-and-saving-the-output-as-png.cs) | `PngOptions`, `RasterImage` | enable png interlacing in pngoptions while merging jpeg images horizontally and ... |
| [set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs](./set-jpeg-subsampling-to-4-2-0-in-jpegoptions-during-a-vertical-merge-to-reduce-file-size.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | set jpeg subsampling to 4 2 0 in jpegoptions during a vertical merge to reduce f... |
| [apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs](./apply-a-grayscale-color-conversion-to-each-jpeg-before-merging-them-horizontally-and-exporting-as-pdf.cs) | `JpegImage`, `JpegOptions`, `PdfOptions` | apply a grayscale color conversion to each jpeg before merging them horizontally... |
| [convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs](./convert-each-jpeg-to-cmyk-color-space-prior-to-a-vertical-merge-and-save-the-result-as-jpeg.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Convert each JPEG to CMYK color space prior to a vertical merge and save the res... |
| [add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs](./add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs) | `Graphics`, `JpegImage`, `JpegOptions` | add a semi transparent watermark text to the merged image after completing a hor... |
| [overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs](./overlay-a-logo-png-on-the-bottom-right-corner-of-the-merged-jpeg-image-before-saving-as-png.cs) | `PngOptions`, `RasterImage` | Overlay a logo PNG on the bottom‑right corner of the merged JPEG image before sa... |
| [insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs](./insert-a-10-pixel-padding-between-each-jpeg-image-during-a-vertical-merge-to-improve-visual-separation.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | Insert a 10‑pixel padding between each JPEG image during a vertical merge to imp... |
| *...and 105 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.5.0/merge-images) |

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


## Developer Q&A

### Q: How to load multiple JPEG files from a directory and merge them horizontally into a single JPEG image using Aspose.Imaging for .NET?
Load each file with `JpegImage.Load`, create a wide `RasterImage` canvas, draw the images side‑by‑side with `Graphics.DrawImage`, and save the result with `JpegOptions`.  
→ See: `load-multiple-jpeg-files-from-a-directory-and-merge-them-horizontally-into-a-single-jpeg-image.cs`

### Q: How do I combine a set of JPEG images horizontally and output the merged picture as a PDF document in C#?
Open each JPEG with `JpegImage`, compose them on a `RasterImage` canvas, then call `Save` on the canvas using `PdfOptions`.  
→ See: `combine-a-set-of-jpeg-images-horizontally-and-output-the-merged-picture-as-a-pdf-document.cs`

### Q: How to resize each input JPEG to a uniform width before performing a horizontal merge and saving as JPEG in .NET 6?
Use `JpegImage.Load` for each file, call `Resize` on the `RasterImage` to the target width, merge the resized images, and save with `JpegOptions`.  
→ See: `resize-each-input-jpeg-to-a-uniform-width-before-performing-a-horizontal-merge-and-saving-as-jpeg.cs`

### Q: How do I limit memory usage while loading JPEG files for a horizontal merge with Aspose.Imaging in C#?
Create an `ImageLoadOptions` instance (e.g., set `BufferSize`), pass it to `JpegImage.Load` for each file, then merge as usual.  
→ See: `use-imageloadoptions-to-limit-memory-usage-while-loading-jpeg-files-for-a-horizontal-merge.cs`

### Q: How to implement parallel loading of JPEG files, then merge them vertically and save the composition as PNG in .NET 7?
Use `Parallel.ForEach` to load each image with `JpegImage.Load`, draw them onto a tall `RasterImage` using `Graphics.DrawImage`, and finally save with `PngOptions`.  
→ See: `implement-parallel-loading-of-jpeg-files-then-merge-them-vertically-and-save-the-composition-as-png.cs`



### Q: How can I add a semi‑transparent watermark text to a horizontally merged JPEG using Aspose.Imaging for .NET?  
Use a `Graphics` object with a `SolidBrush` whose `Opacity` is set (e.g., 0.5) to draw the watermark text after merging the images, then save the result with `JpegOptions`. → See: add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs  

### Q: How do I center each JPEG on the canvas while performing a horizontal merge with Aspose.Imaging in C#?  
Calculate the vertical offset for each source `RasterImage` based on the canvas height and draw the image at that Y‑position using `Graphics.DrawImage`, ensuring each picture is centered. → See: center-each-jpeg-image-on-the-canvas-while-merging-them-horizontally-to-create-a-balanced-composition.cs  

### Q: How can I create a PDF from multiple JPEGs using JPEG2000 compression with Aspose.Imaging for .NET?  
Load each JPEG into a `RasterImage`, add them as pages to a `PdfDocument`, and set `PdfOptions.Jpeg2000CompressionOptions` before calling `PdfDocument.Save`. → See: combine-jpeg-images-into-a-pdf-document-employing-the-jpeg2000-compression-format-while-maintaining-image-fidelity-and-document-integrity.cs  

### Q: How do I embed an ICO file as the document icon when generating a PDF from JPEG images with Aspose.Imaging in C#?  
Load the ICO file into an `Image` and assign it to `PdfDocumentOptions.Icon` on the `PdfDocument` before saving the PDF. → See: combine-jpg-images-into-a-pdf-document-embedding-an-ico-file-as-the-document-s-icon.cs  

### Q: How can I convert a series of JPEG images to EMF format before merging them into a PDF using Aspose.Imaging for .NET?  
Save each JPEG as an `EmfImage` using `EmfOptions`, then add the resulting EMF pages to a `PdfDocument` and call `PdfDocument.Save`. → See: combine-jpg-images-into-a-pdf-document-by-converting-them-to-emf-format-while-preserving-vector-fidelity.cs

### Q: How can I combine several JPEG files into a single PNG image using the WMZ container format with Aspose.Imaging for .NET?  
Load each JPEG, create a `WmfImage` with `WmzContainerFormat` set, draw the JPEGs onto it, and save the result with `PngOptions`. → See: `combine-jpg-images-into-a-single-png-file-efficiently-utilizing-the-wmz-container-format.cs`

### Q: How do I vertically stack multiple JPEG images while preserving their original order and quality using Asp

### Q: How can I specify the JPEG compression quality when saving a horizontally merged image with Aspose.Imaging in C#?  
Set the `Quality` property on a `JpegOptions` instance and pass it to `Image.Save(outputPath, jpegOptions)`. This controls the output JPEG quality after the merge. → See: add-a-semi-transparent-watermark-text-to-the-merged-image-after-completing-a-horizontal-jpeg-merge.cs  

### Q: How do I embed JPEG2000 images into a PDF document while preserving fidelity using Aspose.Imaging for .NET?  
Load each source JPEG as a `Jpeg2000Image`, then add the image to a `PdfDocument` using `PdfOptions` with `Compression = Jpeg2000Compression`. The PDF pages will contain the JPEG2000‑compressed images. → See: combine-jpeg-images-into-a-pdf-document-employing-the-jpeg2000-compression-format-while-maintaining-image-fidelity-and-document-integrity.cs  

### Q: What is the process to convert JPEG files to EMF format before creating a PDF with Aspose.Imaging in C#?  
Load each JPEG, save it to an EMF file using `EmfOptions`, then add the resulting EMF images to a `PdfDocument` via `PdfOptions`. This preserves vector fidelity in the final PDF. → See: combine-jpg-images-into-a-pdf-document-by-converting-them-to-emf-format-while-preserving-vector-fidelity.cs  

### Q: How can I set a custom ICO file as the document icon for a PDF generated from JPEG images using Aspose.Imaging for .NET?  
Load the ICO with `Image.Load`, assign it to `PdfDocumentInfo.Icon`, and attach the `PdfDocumentInfo` to `PdfOptions` before saving the PDF. The resulting PDF will display the specified icon. → See: combine-jpg-images-into-a-pdf-document-embedding-an-ico-file-as-the-document-s-icon.cs  

### Q: How do I convert a series of JPEG images to a multi‑page TIFF and then generate a PDF from that TIFF using Aspose.Imaging in C#?  
Create a `TiffImage` by adding each loaded JPEG as a new frame using `TiffOptions`, then open the TIFF and export it to PDF with `PdfOptions`. This two‑step conversion yields a PDF that
## Operations Covered
- Merge multiple JPEG images horizontally  
- Merge multiple JPEG images vertically preserving order  
- Add semi‑transparent text watermark to a merged image  
- Apply custom JPEG compression settings during merge  
- Convert JPEG image to TGA format  
- Convert TGA image to PDF document  
- Convert JPEG images to EMF while preserving vector fidelity  
- Convert JPEG images to PDF via EMF or SVGZ intermediate formats  
- Validate existence of input image files  
- Ensure output directory is created before saving  

## Supported Formats
- **JPEG** – source images for merging and conversion  
- **PNG** – final merged image output in one example  
- **TGA** – intermediate format when converting JPEG to PDF  
- **PDF** – final document produced from JPEG/TGA/EMF/SVGZ conversions  
- **EMF** – intermediate vector format preserving fidelity  
- **SVGZ** – intermediate vector format used for PDF conversion  

## API Classes Used
- `Image` — base class for loading any image file (`Image.Load`).  
- `RasterImage` — concrete image type for raster operations, used after loading JPEG.  
- `JpegOptions` — (implied via `using Aspose.Imaging.FileFormats.Jpeg`) configures JPEG‑specific save settings such as compression quality.  
- `PngOptions` — (implied via `using Aspose.Imaging.ImageOptions`) configures PNG‑specific save settings for the merged output.  
- `TgaOptions` — (implied via `using Aspose.Imaging.FileFormats.Tga`) configures TGA‑specific save settings for the temporary conversion step.  
- `PdfOptions` — (implied via `using Aspose.Imaging.ImageOptions`) configures PDF‑specific save settings when creating the final document.  
- `EmfOptions` — (implied via `using Aspose.Imaging.FileFormats.Emf`) configures EMF‑specific save settings for vector‑preserving conversion.  
- `Brushes` / `SolidBrush` — used to create a semi‑transparent brush for drawing watermark text.  
- `Sources` — (implied via `using Aspose.Imaging.Sources`) provides image source abstractions for loading/saving streams.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_084830` | Examples: 135
<!-- AUTOGENERATED:END -->