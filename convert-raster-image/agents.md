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

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_032229` | Examples: 141
<!-- AUTOGENERATED:END -->