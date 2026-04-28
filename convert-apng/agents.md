---
name: convert-apng
description: C# examples for Convert APNG using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Convert APNG

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Convert APNG** category.
This folder contains standalone C# examples for Convert APNG operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (204/204 files)
- `using System.IO;` (204/204 files)
- `using Aspose.Imaging;` (199/204 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (193/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (125/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (74/204 files) ← category-specific
- `using Aspose.Imaging.Sources;` (74/204 files) ← category-specific
- `using System.Collections.Generic;` (20/204 files)
- `using Aspose.Imaging.FileFormats.Gif;` (14/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (11/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (11/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (8/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (5/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (4/204 files) ← category-specific
- `using System.Linq;` (4/204 files)
- `using System.Diagnostics;` (3/204 files)
- `using Aspose.Imaging.Brushes;` (2/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (1/204 files) ← category-specific
- `using Aspose.Imaging.Drawing;` (1/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png.Enums;` (1/204 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (1/204 files) ← category-specific
- `using System.Text;` (1/204 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs](./load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | load a png image and create an animated apng with custom frame delays |
| [generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs](./generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | generate an apng from a single page png specifying a 100 ms delay for each frame |
| [load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs](./load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | load multiple png images and assemble them into a single apng animation with cus... |
| [create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs](./create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | create an apng from a png sequence stored in a directory using alphabetical file... |
| [create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs](./create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | create an apng from a series of pngs assigning each frame a random delay between... |
| [set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs](./set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs) | `ApngOptions` | set apng background color to transparent and verify compatibility with standard ... |
| [preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs](./preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs) | `ApngOptions`, `PngOptions` | preserve backward compatibility when saving apng files that contain only a singl... |
| [set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs](./set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs) | `ApngOptions` | set apng loop count to zero to indicate infinite looping for continuous animatio... |
| [set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs](./set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs) | `ApngOptions` | set apng loop count to 5 and test playback speed consistency across different im... |
| [set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs](./set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs) | `ApngOptions` | set custom loop count and frame delay for an apng using a configuration object b... |
| [adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs](./adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | adjust apng frame delays based on external timing data stored in a json configur... |
| [28121-set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs](./28121-set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | set apng metadata software field to indicate processing library version before s... |
| [set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs](./set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | set custom apng metadata fields for author description and creation date before ... |
| [28123-save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs](./28123-save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | save an apng image to disk with lossless compression and embed color profile inf... |
| [convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs](./convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs) | `ApngOptions` | convert an animated webp file to an apng while preserving original animation tim... |
| [load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs](./load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs) | `ApngImage`, `ApngOptions`, `WebPImage` | load an animated webp modify frame order and save as a new apng file |
| [load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs](./load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs) | `ApngOptions`, `WebPImage` | load an animated webp change its color palette and save the modified animation a... |
| [load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs](./load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs) | `ApngOptions` | load an animated webp reduce its dimensions by half and save the resized animati... |
| [load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs](./load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs) | `ApngOptions` | load an animated webp convert it to apng and verify that frame delays match the ... |
| [batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs](./batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs) | `ApngOptions` | batch convert a folder of webp files to apng format applying uniform frame delay |
| [batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs](./batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs) | `ApngOptions` | batch convert animated webp files to apng preserving original frame order and ti... |
| [batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs](./batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs) | `ApngOptions` | batch convert a set of animated webp files to apng generating a summary csv of c... |
| [load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs](./load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs) | `ApngImage`, `ApngOptions`, `Graphics` | load a vector svg animate its elements over time and save the result as an apng ... |
| [create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs](./create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs) | `ApngImage`, `ApngOptions`, `BmpOptions` | create an animated apng using an svg vector graphic defining frame dimensions an... |
| [load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs](./load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | load an svg rasterize it at different resolutions for each frame and compile int... |
| [load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs](./load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | load a vector svg animate its fill color gradient and export the animation as an... |
| [load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs](./load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | load a vector svg animate its rotation over time and save the animation as an ap... |
| [convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs](./convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs) | `ApngOptions` | convert a batch of svg files into individual apng animations each with default f... |
| [batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs](./batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs) | `ApngOptions` | batch convert a collection of svg files to apng assigning each svg a random fram... |
| [load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs](./load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs) | `TiffImage` | load a tiff image with multiple pages and specify frame duration based on page r... |
| *...and 23 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.4.0/convert-apng) |

## Category Statistics
- Total examples: 204
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngFrame`
- `ApngImage`
- `ApngOptions`
- `BmpOptions`
- `ColorPalette`
- `GifImage`
- `GifOptions`
- `Graphics`
- `Image`
- `ImageComparisonOptions`
- `JpegOptions`
- `PngOptions`
- `RasterImage`
- `SolidBrush`
- `SvgImage`
- `SvgRasterizationOptions`
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `WebPImage`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-04-28 | Run: `20260428_051715` | Examples: 204
<!-- AUTOGENERATED:END -->