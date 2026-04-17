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

- `using System;` (102/102 files)
- `using System.IO;` (102/102 files)
- `using Aspose.Imaging;` (98/102 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (96/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (65/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (40/102 files) ← category-specific
- `using Aspose.Imaging.Sources;` (36/102 files) ← category-specific
- `using System.Collections.Generic;` (13/102 files)
- `using Aspose.Imaging.FileFormats.Gif;` (8/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (6/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (5/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (4/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (3/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (2/102 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (2/102 files) ← category-specific
- `using System.Diagnostics;` (1/102 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (1/102 files) ← category-specific
- `using System.Linq;` (1/102 files)
- `using Aspose.Imaging.Drawing;` (1/102 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png.Enums;` (1/102 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs](./load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load a PNG image and create an animated APNG with custom frame delays. |
| [generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs](./generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Generate an APNG from a single‑page PNG, specifying a 100 ms delay for each fram... |
| [load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs](./load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load multiple PNG images and assemble them into a single APNG animation with cus... |
| [create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs](./create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Create an APNG from a PNG sequence stored in a directory, using alphabetical fil... |
| [create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs](./create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Create an APNG from a series of PNGs, assigning each frame a random delay betwee... |
| [set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs](./set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs) |  | Set APNG background color to transparent and verify compatibility with standard ... |
| [preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs](./preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs) | `ApngOptions`, `PngOptions` | Preserve backward compatibility when saving APNG files that contain only a singl... |
| [set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs](./set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set APNG loop count to zero to indicate infinite looping for continuous animatio... |
| [set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs](./set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs) | `ApngOptions` | Set APNG loop count to 5 and test playback speed consistency across different im... |
| [set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs](./set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs) | `ApngOptions` | Set custom loop count and frame delay for an APNG using a configuration object b... |
| [adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs](./adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Adjust APNG frame delays based on external timing data stored in a JSON configur... |
| [set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs](./set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs) |  | Set APNG metadata “Software” field to indicate processing library version before... |
| [set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs](./set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set custom APNG metadata fields for author, description, and creation date befor... |
| [save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs](./save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs) | `ApngOptions`, `RasterImage` | Save an APNG image to disk with lossless compression and embed color profile inf... |
| [convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs](./convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs) | `ApngOptions` | Convert an animated WEBP file to an APNG while preserving original animation tim... |
| [load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs](./load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load an animated WEBP, modify frame order, and save as a new APNG file. |
| [load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs](./load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs) | `ApngOptions`, `ColorPalette`, `WebPImage` | Load an animated WEBP, change its color palette, and save the modified animation... |
| [load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs](./load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs) | `ApngOptions` | Load an animated WEBP, reduce its dimensions by half, and save the resized anima... |
| [load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs](./load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs) | `ApngOptions` | Load an animated WEBP, convert it to APNG, and verify that frame delays match th... |
| [batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs](./batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs) | `ApngOptions` | Batch convert a folder of WEBP files to APNG format, applying uniform frame dela... |
| [batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs](./batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs) | `ApngOptions` | Batch convert animated WEBP files to APNG, preserving original frame order and t... |
| [batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs](./batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs) | `ApngOptions` | Batch convert a set of animated WEBP files to APNG, generating a summary CSV of ... |
| [load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs](./load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load a vector SVG, animate its elements over time, and save the result as an APN... |
| [create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs](./create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Create an animated APNG using an SVG vector graphic, defining frame dimensions a... |
| [load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs](./load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load an SVG, rasterize it at different resolutions for each frame, and compile i... |
| [load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs](./load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load a vector SVG, animate its fill color gradient, and export the animation as ... |
| [load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs](./load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load a vector SVG, animate its rotation over time, and save the animation as an ... |
| [convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs](./convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs) | `ApngOptions` | Convert a batch of SVG files into individual APNG animations, each with default ... |
| [batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs](./batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Batch convert a collection of SVG files to APNG, assigning each SVG a random fra... |
| [load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs](./load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs) | `TiffImage` | Load a TIFF image with multiple pages and specify frame duration based on page r... |
| *...and 21 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.3.0/convert-apng) |

## Category Statistics
- Total examples: 102
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

## Version History

| Version | Examples Added | Total | Date |
|---------|---------------|-------|------|
| V1 | 51 | 102 | 2026-04-17 |

<!-- AUTOGENERATED:START -->
Updated: 2026-04-17 | Run: `20260417_144320` | Examples: 102
<!-- AUTOGENERATED:END -->