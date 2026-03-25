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

- `using System;` (51/51 files)
- `using System.IO;` (51/51 files)
- `using Aspose.Imaging;` (50/51 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (50/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (34/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (21/51 files) ← category-specific
- `using Aspose.Imaging.Sources;` (20/51 files) ← category-specific
- `using System.Collections.Generic;` (6/51 files)
- `using Aspose.Imaging.FileFormats.Gif;` (6/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (3/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (3/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (2/51 files) ← category-specific
- `using System.Diagnostics;` (1/51 files)
- `using Aspose.Imaging.FileFormats.Svg;` (1/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (1/51 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (1/51 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs](./load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load a PNG image and create an animated APNG with custom frame delays. |
| [generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs](./generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Generate an APNG from a single‑page PNG, specifying a 100 ms delay for each fram... |
| [load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs](./load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load multiple PNG images and assemble them into a single APNG animation with cus... |
| [create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs](./create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Create an APNG from a PNG sequence stored in a directory, using alphabetical fil... |
| [create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs](./create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Create an APNG from a series of PNGs, assigning each frame a random delay betwee... |
| [set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs](./set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set APNG background color to transparent and verify compatibility with standard ... |
| [preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs](./preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs) | `ApngOptions`, `PngOptions` | Preserve backward compatibility when saving APNG files that contain only a singl... |
| [set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs](./set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs) | `ApngOptions` | Set APNG loop count to zero to indicate infinite looping for continuous animatio... |
| [set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs](./set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs) | `ApngOptions` | Set APNG loop count to 5 and test playback speed consistency across different im... |
| [set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs](./set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs) | `ApngOptions` | Set custom loop count and frame delay for an APNG using a configuration object b... |
| [adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs](./adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Adjust APNG frame delays based on external timing data stored in a JSON configur... |
| [set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs](./set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs) | `ApngOptions`, `RasterImage` | Set APNG metadata “Software” field to indicate processing library version before... |
| [set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs](./set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set custom APNG metadata fields for author, description, and creation date befor... |
| [save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs](./save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Save an APNG image to disk with lossless compression and embed color profile inf... |
| [convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs](./convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs) | `ApngOptions` | Convert an animated WEBP file to an APNG while preserving original animation tim... |
| [load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs](./load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load an animated WEBP, modify frame order, and save as a new APNG file. |
| [load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs](./load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs) | `ApngOptions`, `ColorPalette`, `WebPImage` | Load an animated WEBP, change its color palette, and save the modified animation... |
| [load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs](./load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs) | `ApngOptions` | Load an animated WEBP, reduce its dimensions by half, and save the resized anima... |
| [load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs](./load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs) | `ApngOptions` | Load an animated WEBP, convert it to APNG, and verify that frame delays match th... |
| [batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs](./batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs) | `ApngOptions` | Batch convert a folder of WEBP files to APNG format, applying uniform frame dela... |
| [batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs](./batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs) | `ApngOptions` | Batch convert animated WEBP files to APNG, preserving original frame order and t... |
| [batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs](./batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs) | `ApngOptions` | Batch convert a set of animated WEBP files to APNG, generating a summary CSV of ... |
| [load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs](./load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Load a vector SVG, animate its elements over time, and save the result as an APN... |
| [create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs](./create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Create an animated APNG using an SVG vector graphic, defining frame dimensions a... |
| [load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs](./load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load an SVG, rasterize it at different resolutions for each frame, and compile i... |
| [load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs](./load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Load a vector SVG, animate its fill color gradient, and export the animation as ... |
| [load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs](./load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load a vector SVG, animate its rotation over time, and save the animation as an ... |
| [convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs](./convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs) | `ApngOptions` | Convert a batch of SVG files into individual APNG animations, each with default ... |
| [batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs](./batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Batch convert a collection of SVG files to APNG, assigning each SVG a random fra... |
| [load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs](./load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs) | `TiffImage` | Load a TIFF image with multiple pages and specify frame duration based on page r... |
| [transform-a-multi-page-tiff-into-an-animated-apng-setting-loop-count-to-infinite.cs](./transform-a-multi-page-tiff-into-an-animated-apng-setting-loop-count-to-infinite.cs) | `ApngOptions` | Transform a multi‑page TIFF into an animated APNG, setting loop count to infinit... |
| [convert-a-multi-page-tiff-to-apng-using-each-page-s-resolution-to-determine-frame-display-duration.cs](./convert-a-multi-page-tiff-to-apng-using-each-page-s-resolution-to-determine-frame-display-duration.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Convert a multi‑page TIFF to APNG, using each page's resolution to determine fra... |
| [convert-a-multi-page-tiff-to-apng-ensuring-each-frame-uses-lossless-compression-for-maximum-quality.cs](./convert-a-multi-page-tiff-to-apng-ensuring-each-frame-uses-lossless-compression-for-maximum-quality.cs) | `ApngOptions` | Convert a multi‑page TIFF to APNG, ensuring each frame uses lossless compression... |
| [batch-process-tiff-files-to-apng-adjusting-each-animation-s-frame-delay-based-on-image-dimensions.cs](./batch-process-tiff-files-to-apng-adjusting-each-animation-s-frame-delay-based-on-image-dimensions.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Batch process TIFF files to APNG, adjusting each animation's frame delay based o... |
| [batch-process-a-directory-of-tiff-files-converting-each-to-apng-with-a-default-loop-count-of-three.cs](./batch-process-a-directory-of-tiff-files-converting-each-to-apng-with-a-default-loop-count-of-three.cs) | `ApngOptions` | Batch process a directory of TIFF files, converting each to APNG with a default ... |
| [load-a-multi-page-tiff-assign-each-page-a-unique-frame-delay-and-compile-into-an-apng.cs](./load-a-multi-page-tiff-assign-each-page-a-unique-frame-delay-and-compile-into-an-apng.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load a multi‑page TIFF, assign each page a unique frame delay, and compile into ... |
| [convert-an-animated-apng-to-a-static-png-by-extracting-the-first-frame-and-saving-it.cs](./convert-an-animated-apng-to-a-static-png-by-extracting-the-first-frame-and-saving-it.cs) | `ApngImage`, `PngOptions`, `RasterImage` | Convert an animated APNG to a static PNG by extracting the first frame and savin... |
| [convert-an-animated-apng-to-a-series-of-png-files-one-per-frame-for-further-processing.cs](./convert-an-animated-apng-to-a-series-of-png-files-one-per-frame-for-further-processing.cs) | `PngOptions` | Convert an animated APNG to a series of PNG files, one per frame, for further pr... |
| [convert-an-apng-to-a-series-of-bmp-files-for-compatibility-with-legacy-imaging-systems.cs](./convert-an-apng-to-a-series-of-bmp-files-for-compatibility-with-legacy-imaging-systems.cs) | `ApngFrame`, `ApngImage`, `BmpOptions` | Convert an APNG to a series of BMP files for compatibility with legacy imaging s... |
| [convert-an-apng-to-a-series-of-jpeg-images-naming-each-file-with-its-frame-index.cs](./convert-an-apng-to-a-series-of-jpeg-images-naming-each-file-with-its-frame-index.cs) | `ApngImage`, `JpegOptions`, `RasterImage` | Convert an APNG to a series of JPEG images, naming each file with its frame inde... |
| [convert-an-apng-to-a-series-of-tiff-images-preserving-each-frame-as-a-separate-page.cs](./convert-an-apng-to-a-series-of-tiff-images-preserving-each-frame-as-a-separate-page.cs) | `ApngImage`, `RasterImage`, `TiffFrame` | Convert an APNG to a series of TIFF images, preserving each frame as a separate ... |
| [export-an-existing-apng-animation-to-an-animated-gif-maintaining-original-frame-order.cs](./export-an-existing-apng-animation-to-an-animated-gif-maintaining-original-frame-order.cs) | `GifOptions` | Export an existing APNG animation to an animated GIF, maintaining original frame... |
| [export-apng-animation-to-gif-format-while-reducing-color-palette-to-256-colors-for-compatibility.cs](./export-apng-animation-to-gif-format-while-reducing-color-palette-to-256-colors-for-compatibility.cs) | `GifOptions` | Export APNG animation to GIF format while reducing color palette to 256 colors f... |
| [export-an-apng-to-gif-and-embed-frame-delay-information-in-the-gif-comment-extension.cs](./export-an-apng-to-gif-and-embed-frame-delay-information-in-the-gif-comment-extension.cs) | `ApngImage`, `GifImage`, `GifOptions` | Export an APNG to GIF and embed frame delay information in the GIF comment exten... |
| [export-an-apng-to-gif-and-include-a-timestamp-comment-indicating-conversion-date-and-time.cs](./export-an-apng-to-gif-and-include-a-timestamp-comment-indicating-conversion-date-and-time.cs) | `GifOptions` | Export an APNG to GIF and include a timestamp comment indicating conversion date... |
| [export-an-apng-to-gif-and-embed-a-custom-application-identifier-in-the-gif-comment-block.cs](./export-an-apng-to-gif-and-embed-a-custom-application-identifier-in-the-gif-comment-block.cs) | `GifOptions` | Export an APNG to GIF and embed a custom application identifier in the GIF comme... |
| [export-an-apng-to-gif-and-include-frame-specific-comments-indicating-original-frame-indices.cs](./export-an-apng-to-gif-and-include-frame-specific-comments-indicating-original-frame-indices.cs) | `ApngImage`, `GifOptions`, `Graphics` | Export an APNG to GIF and include frame-specific comments indicating original fr... |
| [export-an-apng-animation-to-gif-and-compare-visual-fidelity-using-ssim-metric.cs](./export-an-apng-animation-to-gif-and-compare-visual-fidelity-using-ssim-metric.cs) | `ApngImage`, `GifImage`, `GifOptions` | Export an APNG animation to GIF and compare visual fidelity using SSIM metric. |
| [export-an-apng-animation-to-gif-and-verify-that-the-resulting-file-plays-correctly-in-major-browsers.cs](./export-an-apng-animation-to-gif-and-verify-that-the-resulting-file-plays-correctly-in-major-browsers.cs) | `GifOptions` | Export an APNG animation to GIF and verify that the resulting file plays correct... |
| [read-metadata-from-an-apng-file-and-display-loop-count-and-total-frame-count.cs](./read-metadata-from-an-apng-file-and-display-loop-count-and-total-frame-count.cs) |  | Read metadata from an APNG file and display loop count and total frame count. |
| [batch-process-png-sequences-into-apng-files-logging-each-conversion-s-success-status-to-a-report.cs](./batch-process-png-sequences-into-apng-files-logging-each-conversion-s-success-status-to-a-report.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Batch process PNG sequences into APNG files, logging each conversion’s success s... |

## Category Statistics
- Total examples: 51
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
- `JpegOptions`
- `PngOptions`
- `RasterImage`
- `SolidBrush`
- `SvgRasterizationOptions`
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `WebPImage`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-03-25 | Run: `20260325_061231` | Examples: 51
<!-- AUTOGENERATED:END -->