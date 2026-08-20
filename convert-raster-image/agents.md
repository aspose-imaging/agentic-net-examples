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

- `using Aspose.Imaging;` (139/139 files) ← category-specific
- `using System;` (138/139 files)
- `using System.IO;` (138/139 files)
- `using Aspose.Imaging.ImageOptions;` (122/139 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (38/139 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (36/139 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (14/139 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (7/139 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (7/139 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (5/139 files) ← category-specific
- `using Aspose.Imaging.Sources;` (5/139 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (4/139 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (3/139 files) ← category-specific
- `using System.Threading.Tasks;` (2/139 files)
- `using Aspose.Imaging.FileFormats;` (1/139 files) ← category-specific
- `using System.IO.Compression;` (1/139 files)
- `using System.Xml.Linq;` (1/139 files)
- `using System.Collections.Generic;` (1/139 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs](./load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs) | `MedianFilterOptions`, `PdfOptions`, `RasterImage` | Load a BMP file, apply a median filter, and save the result as a PDF file. |
| [resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs](./resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs) | `PdfOptions` | Resize a PNG image to 1024 by 768 pixels, then export it directly to PDF format. |
| [crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs](./crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs) | `RasterImage`, `SvgOptions` | Crop a raster image to a central square region before converting it into an SVG ... |
| [load-multiple-bmp-files-from-a-directory-batch-convert-each-to-pdf-and-save-with-original-filenames.cs](./load-multiple-bmp-files-from-a-directory-batch-convert-each-to-pdf-and-save-with-original-filenames.cs) | `PdfOptions` | Load multiple BMP files from a directory, batch convert each to PDF, and save wi... |
| [create-an-svgimage-from-a-png-source-set-background-color-and-save-as-an-svg-file.cs](./create-an-svgimage-from-a-png-source-set-background-color-and-save-as-an-svg-file.cs) | `SvgImage`, `SvgOptions` | Create an SvgImage from a PNG source, set background color, and save as an SVG f... |
| [apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs](./apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs) | `GaussianBlurFilterOptions`, `PdfOptions`, `RasterImage` | Apply a Gaussian blur filter to a raster image, then convert the filtered image ... |
| [load-a-generic-raster-image-resize-it-proportionally-and-export-the-resized-version-to-svg-format.cs](./load-a-generic-raster-image-resize-it-proportionally-and-export-the-resized-version-to-svg-format.cs) | `SvgOptions` | Load a generic raster image, resize it proportionally, and export the resized ve... |
| [convert-a-bmp-image-to-pdf-using-image-save-with-exportformats-pdf-enumeration-for-explicit-format-control.cs](./convert-a-bmp-image-to-pdf-using-image-save-with-exportformats-pdf-enumeration-for-explicit-format-control.cs) | `PdfOptions` | Convert a BMP image to PDF using Image.Save with ExportFormats.Pdf enumeration f... |
| [read-a-png-file-apply-a-sharpening-filter-and-write-the-output-to-a-memorystream-as-pdf.cs](./read-a-png-file-apply-a-sharpening-filter-and-write-the-output-to-a-memorystream-as-pdf.cs) | `PdfOptions`, `RasterImage`, `SharpenFilterOptions` | Read a PNG file, apply a sharpening filter, and write the output to a MemoryStre... |
| [load-a-raster-image-crop-the-top-left-quadrant-and-save-the-cropped-area-as-an-svg-file.cs](./load-a-raster-image-crop-the-top-left-quadrant-and-save-the-cropped-area-as-an-svg-file.cs) | `RasterImage`, `SvgOptions` | Load a raster image, crop the top-left quadrant, and save the cropped area as an... |
| [batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs](./batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs) | `PdfOptions` | Batch process PNG images, resizing each to 500x500 pixels before converting all ... |
| [create-an-svgimage-from-a-raster-source-define-custom-viewbox-dimensions-and-save-the-svg-output.cs](./create-an-svgimage-from-a-raster-source-define-custom-viewbox-dimensions-and-save-the-svg-output.cs) | `RasterImage` | Create an SvgImage from a raster source, define custom viewbox dimensions, and s... |
| [read-bmp-files-from-a-share-convert-each-to-pdf-and-stream-the-pdfs-back-to-the-client.cs](./read-bmp-files-from-a-share-convert-each-to-pdf-and-stream-the-pdfs-back-to-the-client.cs) | `PdfOptions` | Read BMP files from a share, convert each to PDF, and stream the PDFs back to th... |
| [load-a-raster-image-apply-a-median-filter-resize-to-thumbnail-size-and-save-as-svg.cs](./load-a-raster-image-apply-a-median-filter-resize-to-thumbnail-size-and-save-as-svg.cs) | `MedianFilterOptions`, `RasterImage`, `SvgOptions` | Load a raster image, apply a median filter, resize to thumbnail size, and save a... |
| [load-a-raster-image-perform-a-color-inversion-operation-and-export-the-inverted-image-as-a-pdf.cs](./load-a-raster-image-perform-a-color-inversion-operation-and-export-the-inverted-image-as-a-pdf.cs) | `PdfOptions`, `RasterImage` | Load a raster image, perform a color inversion operation, and export the inverte... |
| [resize-a-png-image-using-high-quality-bicubic-interpolation-before-saving-it-as-an-svg-file.cs](./resize-a-png-image-using-high-quality-bicubic-interpolation-before-saving-it-as-an-svg-file.cs) | `SvgOptions` | Resize a PNG image using high‑quality bicubic interpolation before saving it as ... |
| [create-an-svgimage-from-a-bmp-set-stroke-width-for-vector-paths-and-save-the-customized-svg.cs](./create-an-svgimage-from-a-bmp-set-stroke-width-for-vector-paths-and-save-the-customized-svg.cs) | `RasterImage` | Create an SvgImage from a BMP, set stroke width for vector paths, and save the c... |
| [load-multiple-raster-images-apply-a-uniform-resize-to-1024x1024-and-batch-save-them-as-individual-svg-files.cs](./load-multiple-raster-images-apply-a-uniform-resize-to-1024x1024-and-batch-save-them-as-individual-svg-files.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load multiple raster images, apply a uniform resize to 1024x1024, and batch save... |
| [convert-a-bmp-image-to-pdf-and-write-the-pdf-directly-to-an-http-response-stream.cs](./convert-a-bmp-image-to-pdf-and-write-the-pdf-directly-to-an-http-response-stream.cs) | `PdfOptions` | Convert a BMP image to PDF and write the PDF directly to an HTTP response stream... |
| [batch-process-images-in-a-folder-converting-each-raster-file-to-svg-while-preserving-original-filenames.cs](./batch-process-images-in-a-folder-converting-each-raster-file-to-svg-while-preserving-original-filenames.cs) | `SvgOptions`, `SvgRasterizationOptions` | Batch process images in a folder, converting each raster file to SVG while prese... |
| [load-a-raster-image-apply-a-median-filter-then-convert-and-embed-the-result-into-a-pdf-page.cs](./load-a-raster-image-apply-a-median-filter-then-convert-and-embed-the-result-into-a-pdf-page.cs) | `MedianFilterOptions`, `PdfOptions`, `RasterImage` | Load a raster image, apply a median filter, then convert and embed the result in... |
| [resize-a-bmp-image-to-half-its-original-dimensions-and-export-the-downsized-image-as-an-svg-file.cs](./resize-a-bmp-image-to-half-its-original-dimensions-and-export-the-downsized-image-as-an-svg-file.cs) | `SvgOptions`, `SvgRasterizationOptions` | Resize a BMP image to half its original dimensions and export the downsized imag... |
| [load-a-raster-image-perform-a-center-crop-of-400x400-pixels-and-save-the-cropped-area-as-pdf.cs](./load-a-raster-image-perform-a-center-crop-of-400x400-pixels-and-save-the-cropped-area-as-pdf.cs) | `PdfOptions` | Load a raster image, perform a center crop of 400x400 pixels, and save the cropp... |
| [batch-convert-png-images-to-pdf-using-a-shared-memorystream-to-collect-all-pdfs-for-zip-compression.cs](./batch-convert-png-images-to-pdf-using-a-shared-memorystream-to-collect-all-pdfs-for-zip-compression.cs) | `PdfOptions` | Batch convert PNG images to PDF, using a shared MemoryStream to collect all PDFs... |
| [resize-a-bmp-image-using-nearest-neighbor-interpolation-then-export-the-resized-image-as-an-svg-document.cs](./resize-a-bmp-image-using-nearest-neighbor-interpolation-then-export-the-resized-image-as-an-svg-document.cs) | `SvgOptions` | Resize a BMP image using nearest‑neighbor interpolation, then export the resized... |
| [batch-process-a-folder-of-pngs-applying-a-median-filter-and-converting-each-filtered-image-to-pdf.cs](./batch-process-a-folder-of-pngs-applying-a-median-filter-and-converting-each-filtered-image-to-pdf.cs) | `MedianFilterOptions`, `PdfOptions`, `RasterImage` | Batch process a folder of PNGs, applying a median filter and converting each fil... |
| [load-a-raster-image-set-its-background-to-transparent-and-export-it-as-an-svg-with-background-fill.cs](./load-a-raster-image-set-its-background-to-transparent-and-export-it-as-an-svg-with-background-fill.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load a raster image, set its background to transparent, and export it as an SVG ... |
| [load-a-raster-image-apply-a-gaussian-blur-resize-to-200x200-and-export-as-pdf-for-thumbnail-preview.cs](./load-a-raster-image-apply-a-gaussian-blur-resize-to-200x200-and-export-as-pdf-for-thumbnail-preview.cs) | `GaussianBlurFilterOptions`, `PdfOptions`, `RasterImage` | Load a raster image, apply a Gaussian blur, resize to 200x200, and export as PDF... |
| [batch-convert-bmp-images-to-pdf-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs](./batch-convert-bmp-images-to-pdf-naming-each-output-file-with-a-timestamp-prefix-for-uniqueness.cs) | `PdfOptions` | Batch convert BMP images to PDF, naming each output file with a timestamp prefix... |
| [load-a-png-convert-it-to-an-svgimage-set-viewbox-to-match-original-dimensions-and-save-the-svg.cs](./load-a-png-convert-it-to-an-svgimage-set-viewbox-to-match-original-dimensions-and-save-the-svg.cs) |  | Load a PNG, convert it to an SvgImage, set viewbox to match original dimensions,... |
| *...and 109 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.8.0/convert-raster-image) |

## Category Statistics
- Total examples: 139
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpImage`
- `BmpOptions`
- `ConvolutionFilterOptions`
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
- `RasterCachedImage`
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


## Operations Covered
- Apply Gaussian blur to PNG images  
- Apply Gaussian blur to BMP images  
- Convert blurred raster image to PDF  
- Batch convert PNG files to PDF with sequential naming  
- Resize BMP images to 800 × 800 pixels  
- Apply sharpening filter to BMP images  
- Convert BMP image to PDF using explicit format enumeration  
- Create SVG from PNG and set black stroke color  
- Create SVG from BMP and set custom stroke width  

## Supported Formats
- **PNG** – source raster format for blur, batch conversion, and SVG creation  
- **BMP** – source raster format for blur, resize, sharpen, and PDF conversion  
- **PDF** – target format for saving processed raster images  
- **SVG** – target vector format generated from PNG or BMP sources  

## API Classes Used
- `Image` — static class that loads and saves images from/to files.  
- `RasterImage` — represents a raster image (e.g., PNG, BMP) and provides pixel‑level operations.  
- `GaussianBlurFilterOption` — defines the radius and sigma for a Gaussian blur filter.  
- `SharpenFilterOption` — defines parameters for a sharpening filter (used in BMP batch processing).  
- `PdfOptions` — options object that controls how a raster image is exported to PDF.  
- `ExportFormats` — enumeration that includes `Pdf` for explicit format selection when calling `Save`.  
- `SvgImage` — creates an SVG document from a raster source.  
- `SvgGraphics` — drawing surface used to render shapes and strokes into an SVG image.  
- `SolidBrush` — defines a solid fill color (used for setting stroke color to black).  
- `RectangleShape` (from `Aspose.Imaging.Shapes`) — represents a rectangular shape with customizable stroke width.  
- `File` / `Directory` (System.IO) — used to verify file existence and ensure output directories exist.

<!-- AUTOGENERATED:START -->
Updated: 2026-08-20 | Run: `20260626_070336` | Examples: 139
<!-- AUTOGENERATED:END -->

## Developer Q&A

### Q: How can I resize a JPEG to 800x600 using Lanczos resampling in C# with Aspose.Imaging?  
Use `RasterImage` to load the JPEG and call its `Resize` method with `new Size(800, 600)` while setting `ResampleFilter` to `ResampleFilter.Lanczos`. → See: `resize-a-raster-image-using-lanczos-resampling-then-convert-the-high-quality-result-to-pdf.cs`

### Q: How do I convert a resized raster image to PDF in C# using Aspose.Imaging?  
Create a `PdfOptions` object and pass it to `image.Save(outputPath, pdfOptions)` after resizing the image. → See: `resize-a-raster-image-using-lanczos-resampling-then-convert-the-high-quality-result-to-pdf.cs`

### Q: Which Aspose.Imaging class provides Lanczos resampling for image resizing in .NET?  
The `ResampleFilter` enumeration includes `Lanczos`, which you supply to the `Resize` method of a `RasterImage`. → See: `resize-a-raster-image-using-lanczos-resampling-then-convert-the-high-quality-result-to-pdf.cs`

### Q: How should I handle exceptions when resizing and converting images with Aspose.Imaging in C#?  
Wrap the processing code in a `try‑catch` block and catch `Exception` (or `ImageProcessingException`) to capture any errors from Aspose.Imaging operations. → See: `resize-a-raster-image-using-lanczos-resampling-then-convert-the-high-quality-result-to-pdf.cs`

### Q: Can I resize a JPEG and directly save it as PDF without creating an intermediate file using Aspose.Imaging for .NET?  
Yes—load the JPEG into a `RasterImage`, resize it, then call `Save` with a `PdfOptions` instance to output the PDF in a single step. → See: `resize-a-raster-image-using-lanczos-resampling-then-convert-the-high-quality-result-to-pdf.cs`