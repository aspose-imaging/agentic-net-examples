---
name: convert-raster-image
description: C# examples for Convert Raster Image using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Convert Raster Image

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Convert Raster Image** category.
This folder contains standalone C# examples for Convert Raster Image operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using Aspose.Imaging;` (140/141 files) ← category-specific
- `using System;` (138/141 files)
- `using System.IO;` (138/141 files)
- `using Aspose.Imaging.ImageOptions;` (123/141 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (37/141 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (34/141 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (17/141 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (10/141 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (9/141 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (9/141 files) ← category-specific
- `using Aspose.Imaging.Sources;` (5/141 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (4/141 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (3/141 files) ← category-specific
- `using System.Threading.Tasks;` (2/141 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (2/141 files) ← category-specific
- `using Aspose.Imaging.FileFormats;` (2/141 files) ← category-specific
- `using System.Net;` (1/141 files)
- `using System.IO.Compression;` (1/141 files)
- `using System.Text;` (1/141 files)
- `using System.Xml.Linq;` (1/141 files)
- `using System.Collections.Generic;` (1/141 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs](./load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs) | `MedianFilterOptions`, `PdfOptions`, `RasterImage` | load a bmp file apply a median filter and save the result as a pdf file |
| [resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs](./resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs) | `PdfOptions` | resize a png image to 1024 by 768 pixels then export it directly to pdf format |
| [crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs](./crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs) | `RasterImage`, `SvgOptions` | crop a raster image to a central square region before converting it into an svg ... |
| [load-multiple-bmp-files-from-a-directory-batch-convert-each-to-pdf-and-save-with-original-filenames.cs](./load-multiple-bmp-files-from-a-directory-batch-convert-each-to-pdf-and-save-with-original-filenames.cs) | `PdfOptions` | load multiple bmp files from a directory batch convert each to pdf and save with... |
| [create-an-svgimage-from-a-png-source-set-background-color-and-save-as-an-svg-file.cs](./create-an-svgimage-from-a-png-source-set-background-color-and-save-as-an-svg-file.cs) | `SvgOptions`, `SvgRasterizationOptions` | create an svgimage from a png source set background color and save as an svg fil... |
| [apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs](./apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs) | `GaussianBlurFilterOptions`, `PdfOptions`, `RasterImage` | apply a gaussian blur filter to a raster image then convert the filtered image t... |
| [load-a-generic-raster-image-resize-it-proportionally-and-export-the-resized-version-to-svg-format.cs](./load-a-generic-raster-image-resize-it-proportionally-and-export-the-resized-version-to-svg-format.cs) | `SvgOptions`, `SvgRasterizationOptions` | load a generic raster image resize it proportionally and export the resized vers... |
| [convert-a-bmp-image-to-pdf-using-image-save-with-exportformats-pdf-enumeration-for-explicit-format-control.cs](./convert-a-bmp-image-to-pdf-using-image-save-with-exportformats-pdf-enumeration-for-explicit-format-control.cs) | `PdfOptions` | convert a bmp image to pdf using image save with exportformats pdf enumeration f... |
| [read-a-png-file-apply-a-sharpening-filter-and-write-the-output-to-a-memorystream-as-pdf.cs](./read-a-png-file-apply-a-sharpening-filter-and-write-the-output-to-a-memorystream-as-pdf.cs) | `PdfOptions`, `RasterImage` | read a png file apply a sharpening filter and write the output to a memorystream... |
| [load-a-raster-image-crop-the-top-left-quadrant-and-save-the-cropped-area-as-an-svg-file.cs](./load-a-raster-image-crop-the-top-left-quadrant-and-save-the-cropped-area-as-an-svg-file.cs) | `SvgOptions` | load a raster image crop the top left quadrant and save the cropped area as an s... |
| [batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs](./batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs) | `PdfOptions`, `PngImage` | batch process png images resizing each to 500x500 pixels before converting all t... |
| [create-an-svgimage-from-a-raster-source-define-custom-viewbox-dimensions-and-save-the-svg-output.cs](./create-an-svgimage-from-a-raster-source-define-custom-viewbox-dimensions-and-save-the-svg-output.cs) | `RasterImage` | create an svgimage from a raster source define custom viewbox dimensions and sav... |
| [read-bmp-files-from-a-share-convert-each-to-pdf-and-stream-the-pdfs-back-to-the-client.cs](./read-bmp-files-from-a-share-convert-each-to-pdf-and-stream-the-pdfs-back-to-the-client.cs) | `PdfOptions` | read bmp files from a share convert each to pdf and stream the pdfs back to the ... |
| [load-a-raster-image-apply-a-median-filter-resize-to-thumbnail-size-and-save-as-svg.cs](./load-a-raster-image-apply-a-median-filter-resize-to-thumbnail-size-and-save-as-svg.cs) | `MedianFilterOptions`, `RasterImage`, `SvgOptions` | load a raster image apply a median filter resize to thumbnail size and save as s... |
| [load-a-raster-image-perform-a-color-inversion-operation-and-export-the-inverted-image-as-a-pdf.cs](./load-a-raster-image-perform-a-color-inversion-operation-and-export-the-inverted-image-as-a-pdf.cs) | `PdfOptions`, `RasterImage` | load a raster image perform a color inversion operation and export the inverted ... |
| [resize-a-png-image-using-high-quality-bicubic-interpolation-before-saving-it-as-an-svg-file.cs](./resize-a-png-image-using-high-quality-bicubic-interpolation-before-saving-it-as-an-svg-file.cs) | `SvgOptions`, `SvgRasterizationOptions` | resize a png image using high quality bicubic interpolation before saving it as ... |
| [create-an-svgimage-from-a-bmp-set-stroke-width-for-vector-paths-and-save-the-customized-svg.cs](./create-an-svgimage-from-a-bmp-set-stroke-width-for-vector-paths-and-save-the-customized-svg.cs) | `RasterImage` | create an svgimage from a bmp set stroke width for vector paths and save the cus... |
| [load-multiple-raster-images-apply-a-uniform-resize-to-1024x1024-and-batch-save-them-as-individual-svg-files.cs](./load-multiple-raster-images-apply-a-uniform-resize-to-1024x1024-and-batch-save-them-as-individual-svg-files.cs) | `SvgOptions`, `SvgRasterizationOptions` | load multiple raster images apply a uniform resize to 1024x1024 and batch save t... |
| [convert-a-bmp-image-to-pdf-and-write-the-pdf-directly-to-an-http-response-stream.cs](./convert-a-bmp-image-to-pdf-and-write-the-pdf-directly-to-an-http-response-stream.cs) | `PdfOptions` | convert a bmp image to pdf and write the pdf directly to an http response stream |
| [batch-process-images-in-a-folder-converting-each-raster-file-to-svg-while-preserving-original-filenames.cs](./batch-process-images-in-a-folder-converting-each-raster-file-to-svg-while-preserving-original-filenames.cs) | `SvgOptions`, `SvgRasterizationOptions` | batch process images in a folder converting each raster file to svg while preser... |
| [load-a-raster-image-apply-a-median-filter-then-convert-and-embed-the-result-into-a-pdf-page.cs](./load-a-raster-image-apply-a-median-filter-then-convert-and-embed-the-result-into-a-pdf-page.cs) | `MedianFilterOptions`, `PdfOptions`, `RasterImage` | load a raster image apply a median filter then convert and embed the result into... |
| [resize-a-bmp-image-to-half-its-original-dimensions-and-export-the-downsized-image-as-an-svg-file.cs](./resize-a-bmp-image-to-half-its-original-dimensions-and-export-the-downsized-image-as-an-svg-file.cs) | `SvgOptions`, `SvgRasterizationOptions` | resize a bmp image to half its original dimensions and export the downsized imag... |
| [load-a-raster-image-perform-a-center-crop-of-400x400-pixels-and-save-the-cropped-area-as-pdf.cs](./load-a-raster-image-perform-a-center-crop-of-400x400-pixels-and-save-the-cropped-area-as-pdf.cs) | `PdfOptions` | load a raster image perform a center crop of 400x400 pixels and save the cropped... |
| [batch-convert-png-images-to-pdf-using-a-shared-memorystream-to-collect-all-pdfs-for-zip-compression.cs](./batch-convert-png-images-to-pdf-using-a-shared-memorystream-to-collect-all-pdfs-for-zip-compression.cs) | `PdfOptions` | batch convert png images to pdf using a shared memorystream to collect all pdfs ... |
| [resize-a-bmp-image-using-nearest-neighbor-interpolation-then-export-the-resized-image-as-an-svg-document.cs](./resize-a-bmp-image-using-nearest-neighbor-interpolation-then-export-the-resized-image-as-an-svg-document.cs) | `SvgOptions` | resize a bmp image using nearest neighbor interpolation then export the resized ... |
| [batch-process-a-folder-of-pngs-applying-a-median-filter-and-converting-each-filtered-image-to-pdf.cs](./batch-process-a-folder-of-pngs-applying-a-median-filter-and-converting-each-filtered-image-to-pdf.cs) | `MedianFilterOptions`, `PdfOptions`, `RasterImage` | batch process a folder of pngs applying a median filter and converting each filt... |
| [load-a-raster-image-set-its-background-to-transparent-and-export-it-as-an-svg-with-background-fill.cs](./load-a-raster-image-set-its-background-to-transparent-and-export-it-as-an-svg-with-background-fill.cs) | `SvgOptions`, `SvgRasterizationOptions` | load a raster image set its background to transparent and export it as an svg wi... |
| [load-a-raster-image-apply-a-gaussian-blur-resize-to-200x200-and-export-as-pdf-for-thumbnail-preview.cs](./load-a-raster-image-apply-a-gaussian-blur-resize-to-200x200-and-export-as-pdf-for-thumbnail-preview.cs) | `GaussianBlurFilterOptions`, `PdfOptions`, `RasterImage` | load a raster image apply a gaussian blur resize to 200x200 and export as pdf fo... |
| [batch-convert-bmp-images-to-pdf-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs](./batch-convert-bmp-images-to-pdf-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs) | `PdfOptions` | batch convert bmp images to pdf naming each output file with a timestamp prefix ... |
| [load-a-png-convert-it-to-an-svgimage-set-viewbox-to-match-original-dimensions-and-save-the-svg.cs](./load-a-png-convert-it-to-an-svgimage-set-viewbox-to-match-original-dimensions-and-save-the-svg.cs) | `SvgOptions`, `SvgRasterizationOptions` | load a png convert it to an svgimage set viewbox to match original dimensions an... |
| *...and 111 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.5.0/convert-raster-image) |

## Category Statistics
- Total examples: 141
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpImage`
- `BmpOptions`
- `GaussianBlurFilterOptions`
- `Graphics`
- `JpegImage`
- `JpegOptions`
- `LinearGradientBrush`
- `LoadOptions`
- `MaskingOptions`
- `MedianFilterOptions`
- `OtgRasterizationOptions`
- `PdfOptions`
- `PngImage`
- `PngOptions`
- `RasterImage`
- `SharpenFilterOptions`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅


## Use Cases
- A web service needs to accept user‑uploaded photos and store them as PNG bitmaps; the raster image conversion C# examples show how to read JPEG or BMP files and perform a bitmap conversion dotnet before saving.  
- An automated reporting tool generates charts as BMP files and must embed them into PDF documents, requiring raster image conversion C# code to convert the bitmap to a high‑resolution PNG.  
- A desktop application processes scanned documents and needs to normalize all pages to a single raster format, using the bitmap conversion dotnet snippets to transform TIFF or GIF inputs into a consistent PNG output.  
- A game development pipeline imports legacy sprite sheets in various raster formats and needs to batch‑convert them to a uniform bitmap for Unity, leveraging the raster image conversion C# examples for fast, programmatic conversion.  
- An e‑commerce platform creates product thumbnails on the fly; the bitmap conversion dotnet examples demonstrate how to resize and convert incoming JPEG images to optimized WebP raster files for faster page loads.

## Related Categories  
The Convert Raster Image category works hand‑in‑hand with the Image Format Conversion examples, where you’ll find additional code for switching between JPEG, PNG, TIFF, and WebP beyond simple bitmap handling. If you need to change image dimensions after conversion, the Image Resizing agents provide seamless integration with the raster conversion workflow. For projects that require applying visual effects after a bitmap conversion, the Image Filtering agents offer filters and adjustments that can be chained directly after the conversion step. Together, these neighboring categories give you a complete toolkit for end‑to‑end image processing in .NET.


## Developer Q&A

### Q: How do I load a BMP file, apply a median filter, and save the result as a PDF in C#?
Use `RasterImage.Load` to open the BMP, apply `MedianFilterOptions` via `image.Filter`, then call `image.Save` with a `PdfOptions` instance to create the PDF.  
→ See: `load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs`

### Q: How to resize a PNG image to 1024 × 768 pixels and export it directly to PDF using .NET?
Load the PNG with `RasterImage.Load`, call `image.Resize(new Size(1024, 768), InterpolationMode.HighQualityBicubic)`, and save using `PdfOptions` with `image.Save`.  
→ See: `resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs`

### Q: How do I crop a raster image to a central square region before converting it to an SVG document in C#?
After loading the image via `RasterImage.Load`, compute the central square `Rectangle` and call `image.Crop`, then save the cropped image using `SvgOptions` with `image.Save`.  
→ See: `crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs`

### Q: How to convert a BMP image to PDF using the ExportFormats enumeration for explicit format control in Aspose.Imaging for .NET?
Load the BMP with `Image.Load`, then invoke `image.Save("output.pdf", ExportFormats.Pdf)` to specify the PDF format directly.  
→ See: `convert-a-bmp-image-to-pdf-using-image-save-with-exportformats-pdf-enumeration-for-explicit-format-control.cs`

### Q: How do I batch‑process PNG images, resize each to 500 × 500 pixels, and convert all of them to individual PDF files in C#?
Iterate through the PNG files, load each with `RasterImage.Load`, resize via `image.Resize(new Size(500, 500))`, and save each using `PdfOptions` with `image.Save`.  
→ See: `batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs`



### Q: How can I apply a median filter to a BMP image and export the filtered result centered on a PDF page using Aspose.Imaging for .NET?  
Load the BMP with `Image.Load`, apply `MedianFilter` via `image.ApplyFilter`, then create a `PdfOptions` object and set its `PageOptions` to center the image before saving with `image.Save(outputPath, pdfOptions)`. → See: 28506-load-a-bmp-apply-a-median-filter-and-generate-a-pdf-with-the-filtered-image-centered-on-the-page.cs  

### Q: How do I batch‑convert all BMP files in a folder to PDF and prepend each output filename with a timestamp for uniqueness using Aspose.Imaging for .NET?  
Enumerate BMP files, generate a timestamp string, build the output name, and for each file load it with `Image.Load` and save as PDF using `PdfOptions`. → See: batch-convert-bmp-images-to-pdf-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs  

### Q: How can I add a watermark that includes the current date to PDFs generated from raster images in a batch process with Aspose.Imaging for .NET?  
After loading each raster image and creating a `PdfOptions`, use

### Q: How do I apply a custom color filter to a BMP image and export the filtered result as a PDF using Aspose.Imaging for .NET?  
Use `RasterImage.Load` to open the BMP, call `image.ApplyFilter(new CustomColorFilterOption(...))`, and save with `PdfOptions` via `image.Save(outputPath, new PdfOptions())`. → See: `load-a-bmp-apply-a-custom-color-filter-then-export-the-filtered-image-as-pdf.cs`

### Q: How can I invert the colors of a BMP image and save the output as an SVG file with Aspose.Imaging for .NET?  
Load the BMP with `RasterImage.Load`, apply `new ColorInversionFilterOption()` using `image.ApplyFilter`, then export using `SvgOptions` in `image.Save(outputPath, new SvgOptions())`. → See: `load-a-bmp-image-apply-a-color-inversion-filter-then-export-the-inverted-image-as-svg.cs`

### Q: How do I batch‑resize raster images to 800 × 800, apply a Gaussian blur, and generate SVG files for each using Aspose.Imaging for .NET?  
Iterate over files, load each with `RasterImage.Load`, call `image.Resize(800, 800)` and `image.ApplyFilter(new GaussianBlurFilterOption(radius))`, then save using `SvgOptions` (`image.Save(outputPath, new SvgOptions())`). → See: `batch-process-raster-images-resize-each-to-800x800-apply-a-gaussian-blur-and-save-as-svg.cs`

### Q: How can I set a dash pattern for lines when converting a BMP to SVG with Aspose.Imaging for .NET?  
Create an `SvgImage` from the BMP, obtain its `Graphics` object, configure a `Pen` with `DashPattern` (e.g., `pen.DashPattern = new float[] {5, 2}`), draw the raster content, and save the SVG via `svgImage.Save(outputPath)`. → See: `create-an-svgimage-from-a-bmp-set-stroke-dash-array-for-lines-and-save-the-svg-with-dashed-strokes.cs`

### Q: How do I change the stroke width to 2 pixels for vector lines when generating an SVG from a PNG using Aspose.Imaging for .NET?  
Load the PNG, create an `SvgImage`, use its `Graphics` to set `Pen.Width = 2` before drawing, and save the result with `svgImage.Save(outputPath)`. → See: `create-an-svgimage-from-a-p
## Operations Covered
- Load BMP image from file  
- Apply median filter to image  
- Increase image brightness by 10  
- Increase image contrast by 15  
- Resize raster image to 1024 × 1024 pixels  
- Convert raster image to SVG format  
- Convert PNG images to PDF documents  
- Aggregate multiple PDFs using a shared MemoryStream  
- Center filtered image on PDF page  
- Set stroke width for SVG vector paths  
- Embed base64‑encoded raster image into SVG  

## Supported Formats
- **BMP** – source raster format used for loading and processing  
- **PNG** – source raster format used in batch conversion to PDF  
- **JPEG** – source raster format used in resize‑and‑filter example  
- **PDF** – target format for converted images and aggregated documents  
- **SVG** – target format for vector output, customization, and self‑contained files  

## API Classes Used
- `Image` — base class that loads images from disk and provides saving capabilities.  
- `RasterImage` — concrete class representing raster images (BMP, PNG, JPEG) for manipulation.  
- `ImageOptions` — abstract options class that defines common settings for saving images.  
- `PdfOptions` — options class used to configure PDF output when saving an image as a PDF.  
- `SvgOptions` — options class used to configure SVG output when saving an image as an SVG file.  
- `MedianFilterOptions` — filter options class that specifies parameters for applying a median filter to a raster image.

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_032229` | Examples: 141
<!-- AUTOGENERATED:END -->