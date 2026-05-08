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

- `using System;` (414/414 files)
- `using System.IO;` (414/414 files)
- `using Aspose.Imaging;` (407/414 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (373/414 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (106/414 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (102/414 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (49/414 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (36/414 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (26/414 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (17/414 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (17/414 files) ← category-specific
- `using Aspose.Imaging.Sources;` (12/414 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (10/414 files) ← category-specific
- `using System.Threading.Tasks;` (5/414 files)
- `using System.Collections.Generic;` (4/414 files)
- `using System.Linq;` (3/414 files)
- `using Aspose.Imaging.FileFormats;` (3/414 files) ← category-specific
- `using System.IO.Compression;` (2/414 files)
- `using System.Drawing;` (2/414 files)
- `using Aspose.Imaging.Export;` (1/414 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (1/414 files) ← category-specific
- `using Aspose.Imaging.Masking;` (1/414 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (1/414 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (1/414 files) ← category-specific
- `using System.Xml;` (1/414 files)
- `using System.Net;` (1/414 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs](./load-a-bmp-file-apply-a-median-filter-and-save-the-result-as-a-pdf-file.cs) | `MedianFilterOptions`, `PdfOptions`, `RasterImage` | Load a BMP file, apply a median filter, and save the result as a PDF file. |
| [resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs](./resize-a-png-image-to-1024-by-768-pixels-then-export-it-directly-to-pdf-format.cs) | `PdfOptions` | Resize a PNG image to 1024 by 768 pixels, then export it directly to PDF format. |
| [crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs](./crop-a-raster-image-to-a-central-square-region-before-converting-it-into-an-svg-document.cs) | `SvgOptions` | Crop a raster image to a central square region before converting it into an SVG ... |
| [load-multiple-bmp-files-from-a-directory-batch-convert-each-to-pdf-and-save-with-original-filenames.cs](./load-multiple-bmp-files-from-a-directory-batch-convert-each-to-pdf-and-save-with-original-filenames.cs) | `PdfOptions` | Load multiple BMP files from a directory, batch convert each to PDF, and save wi... |
| [create-an-svgimage-from-a-png-source-set-background-color-and-save-as-an-svg-file.cs](./create-an-svgimage-from-a-png-source-set-background-color-and-save-as-an-svg-file.cs) | `SvgImage`, `SvgOptions` | Create an SvgImage from a PNG source, set background color, and save as an SVG f... |
| [apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs](./apply-a-gaussian-blur-filter-to-a-raster-image-then-convert-the-filtered-image-to-pdf.cs) | `GaussianBlurFilterOptions`, `PdfOptions`, `RasterImage` | Apply a Gaussian blur filter to a raster image, then convert the filtered image ... |
| [load-a-generic-raster-image-resize-it-proportionally-and-export-the-resized-version-to-svg-format.cs](./load-a-generic-raster-image-resize-it-proportionally-and-export-the-resized-version-to-svg-format.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load a generic raster image, resize it proportionally, and export the resized ve... |
| [convert-a-bmp-image-to-pdf-using-image-save-with-exportformats-pdf-enumeration-for-explicit-format-control.cs](./convert-a-bmp-image-to-pdf-using-image-save-with-exportformats-pdf-enumeration-for-explicit-format-control.cs) | `PdfOptions` | Convert a BMP image to PDF using Image.Save with ExportFormats.Pdf enumeration f... |
| [read-a-png-file-apply-a-sharpening-filter-and-write-the-output-to-a-memorystream-as-pdf.cs](./read-a-png-file-apply-a-sharpening-filter-and-write-the-output-to-a-memorystream-as-pdf.cs) | `PdfOptions`, `RasterImage` | Read a PNG file, apply a sharpening filter, and write the output to a MemoryStre... |
| [load-a-raster-image-crop-the-top-left-quadrant-and-save-the-cropped-area-as-an-svg-file.cs](./load-a-raster-image-crop-the-top-left-quadrant-and-save-the-cropped-area-as-an-svg-file.cs) | `RasterImage`, `SvgOptions` | Load a raster image, crop the top-left quadrant, and save the cropped area as an... |
| [batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs](./batch-process-png-images-resizing-each-to-500x500-pixels-before-converting-all-to-individual-pdf-documents.cs) | `PdfOptions` | Batch process PNG images, resizing each to 500x500 pixels before converting all ... |
| [create-an-svgimage-from-a-raster-source-define-custom-viewbox-dimensions-and-save-the-svg-output.cs](./create-an-svgimage-from-a-raster-source-define-custom-viewbox-dimensions-and-save-the-svg-output.cs) |  | Create an SvgImage from a raster source, define custom viewbox dimensions, and s... |
| [read-bmp-files-from-a-share-convert-each-to-pdf-and-stream-the-pdfs-back-to-the-client.cs](./read-bmp-files-from-a-share-convert-each-to-pdf-and-stream-the-pdfs-back-to-the-client.cs) | `PdfOptions` | Read BMP files from a share, convert each to PDF, and stream the PDFs back to th... |
| [load-a-raster-image-apply-a-median-filter-resize-to-thumbnail-size-and-save-as-svg.cs](./load-a-raster-image-apply-a-median-filter-resize-to-thumbnail-size-and-save-as-svg.cs) | `MedianFilterOptions`, `RasterImage`, `SvgOptions` | Load a raster image, apply a median filter, resize to thumbnail size, and save a... |
| [load-a-raster-image-perform-a-color-inversion-operation-and-export-the-inverted-image-as-a-pdf.cs](./load-a-raster-image-perform-a-color-inversion-operation-and-export-the-inverted-image-as-a-pdf.cs) | `PdfOptions` | Load a raster image, perform a color inversion operation, and export the inverte... |
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
| [load-a-png-convert-it-to-an-svgimage-set-viewbox-to-match-original-dimensions-and-save-the-svg.cs](./load-a-png-convert-it-to-an-svgimage-set-viewbox-to-match-original-dimensions-and-save-the-svg.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load a PNG, convert it to an SvgImage, set viewbox to match original dimensions,... |
| *...and 108 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.4.0/convert-raster-image) |

## Category Statistics
- Total examples: 414
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpImage`
- `BmpOptions`
- `GaussianBlurFilterOptions`
- `Graphics`
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

<!-- AUTOGENERATED:START -->
Updated: 2026-05-04 | Run: `20260504_042215` | Examples: 414
<!-- AUTOGENERATED:END -->