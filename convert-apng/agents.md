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
- `using Aspose.Imaging.ImageOptions;` (49/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (29/51 files) ← category-specific
- `using Aspose.Imaging.Sources;` (20/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (19/51 files) ← category-specific
- `using System.Collections.Generic;` (3/51 files)
- `using Aspose.Imaging.FileFormats.Webp;` (3/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (2/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (2/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (2/51 files) ← category-specific
- `using System.Linq;` (1/51 files)
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
| [preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs](./preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs) | `ApngOptions` | Preserve backward compatibility when saving APNG files that contain only a singl... |
| [set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs](./set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs) | `ApngOptions` | Set APNG loop count to zero to indicate infinite looping for continuous animatio... |
| [set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs](./set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs) | `ApngOptions` | Set APNG loop count to 5 and test playback speed consistency across different im... |
| [set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs](./set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs) | `ApngOptions` | Set custom loop count and frame delay for an APNG using a configuration object b... |
| [adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs](./adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Adjust APNG frame delays based on external timing data stored in a JSON configur... |
| [set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs](./set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set APNG metadata “Software” field to indicate processing library version before... |
| [set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs](./set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set custom APNG metadata fields for author, description, and creation date befor... |
| [save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs](./save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs) | `ApngImage`, `ApngOptions` | Save an APNG image to disk with lossless compression and embed color profile inf... |
| [convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs](./convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs) | `ApngOptions` | Convert an animated WEBP file to an APNG while preserving original animation tim... |
| [load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs](./load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs) | `ApngImage`, `ApngOptions`, `IMultipageImage` | Load an animated WEBP, modify frame order, and save as a new APNG file. |
| [load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs](./load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs) | `ApngOptions`, `ColorPalette` | Load an animated WEBP, change its color palette, and save the modified animation... |
| [load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs](./load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs) | `ApngOptions`, `WebPImage` | Load an animated WEBP, reduce its dimensions by half, and save the resized anima... |
| [load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs](./load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs) | `ApngOptions` | Load an animated WEBP, convert it to APNG, and verify that frame delays match th... |
| [batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs](./batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs) | `ApngOptions` | Batch convert a folder of WEBP files to APNG format, applying uniform frame dela... |
| [batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs](./batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs) | `ApngOptions` | Batch convert animated WEBP files to APNG, preserving original frame order and t... |
| [batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs](./batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs) | `ApngOptions` | Batch convert a set of animated WEBP files to APNG, generating a summary CSV of ... |
| [load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs](./load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs) | `ApngImage`, `ApngOptions`, `BmpOptions` | Load a vector SVG, animate its elements over time, and save the result as an APN... |
| [create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs](./create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Create an animated APNG using an SVG vector graphic, defining frame dimensions a... |
| [load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs](./load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load an SVG, rasterize it at different resolutions for each frame, and compile i... |
| [load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs](./load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs) | `ApngImage`, `ApngOptions`, `Graphics` | Load a vector SVG, animate its fill color gradient, and export the animation as ... |
| [load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs](./load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs) | `ApngImage`, `ApngOptions`, `Graphics` | Load a vector SVG, animate its rotation over time, and save the animation as an ... |
| [convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs](./convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs) | `ApngOptions` | Convert a batch of SVG files into individual APNG animations, each with default ... |
| [batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs](./batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs) | `ApngOptions` | Batch convert a collection of SVG files to APNG, assigning each SVG a random fra... |
| [load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs](./load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs) | `TiffImage` | Load a TIFF image with multiple pages and specify frame duration based on page r... |
| *...and 21 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.8.0/convert-apng) |

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
- `IMultipageImage`
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
- `VectorRasterizationOptions`
- `WebPImage`

## Failed Tasks

All tasks passed ✅



## Use Cases  

- A web developer needs to **create APNG dotnet** files from a collection of PNG layers to deliver smooth, loss‑less animations on a product showcase page.  
- An e‑learning platform converts legacy GIF tutorials into **animated PNG C#** assets to reduce file size while keeping frame‑by‑frame fidelity.  
- A mobile game studio extracts individual frames from an **APNG animation** to apply custom filters before re‑packaging the sequence.  
- A UI designer overlays dynamic watermarks on each frame of an **animated PNG C#** file, then saves the result as a new APNG for branding purposes.  
- A performance‑focused app resizes and reduces the color palette of an existing APNG animation to optimize load times on low‑bandwidth devices.  

## Related Categories  

The Convert APNG examples share many of the same image‑processing fundamentals found in the Convert PNG and Convert GIF sections, such as handling pixel formats and managing streams. If you need to work with lossless compression or transparency, the PNG optimization category offers complementary techniques. For scenarios that involve converting video clips or sprite sheets into animated formats, the Convert WebP and Convert Video groups provide useful reference implementations that can be combined with APNG workflows. Together, these categories give a full picture of how Aspose.Imaging can handle static and animated image transformations across the .NET ecosystem.


## Operations Covered
- Set APNG frame delays from JSON configuration  
- Load a single PNG image for animation source  
- Create an animated PNG (APNG) from a sequence of frames  
- Save an APNG file to disk  
- Batch‑convert animated WebP files to APNG  
- Record conversion duration for each file in a CSV report  
- Batch‑convert PNG sequences to APNG with per‑file success logging  
- Convert multi‑page TIFF to lossless APNG (one frame per page)  
- Extract the first frame of an animated APNG and save as static PNG  
- Extract all frames of an APNG and save each as a JPEG file with index‑based names  
- Sort PNG files alphabetically before building the APNG animation  

## Supported Formats
- **PNG** – used as source frames and for static output images  
- **APNG** – animated PNG format created or read by the examples  
- **WebP** – animated WebP files that are converted to APNG in the batch example  
- **TIFF** – multi‑page TIFF files converted to APNG with lossless compression  
- **JPEG** – target format for extracting APNG frames in one example  

## API Classes Used
- **Image** – core Aspose.Imaging class that loads, manipulates, and saves images.  
- **ImageOptions** – base class for format‑specific save options (e.g., PNG, JPEG, APNG).  
- **PngOptions** – options class for saving PNG/APNG files (used when creating or saving PNG‑based images).  
- **JpegOptions** – options class for saving JPEG files (used when exporting APNG frames to JPEG).  
- **WebPOptions** – options class for loading or saving WebP images (used in the WebP‑to‑APNG batch conversion).  
- **TiffOptions** – options class for loading multi‑page TIFF images (used when converting TIFF to APNG).  
- **Image.Load** – static method that reads an image file (PNG, WebP, TIFF, etc.) into an `Image` object.  
- **Image.Save** – instance method that writes the `Image` (or its frames) to a file using the supplied `ImageOptions`.

<!-- AUTOGENERATED:START -->
Updated: 2026-08-18 | Run: `20260731_120536` | Examples: 51
<!-- AUTOGENERATED:END -->

## Developer Q&A

### Q: How can I set APNG frame delays based on timing data stored in a JSON file using Aspose.Imaging for .NET?  
Load the APNG with `ApngImage`, read the JSON, assign each frame’s `DelayTime` property, and save with `ApngOptions`. → See: `adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs`

### Q: What is the best way to batch convert animated WebP files to APNG while preserving original frame order and timing metadata in C#?  
For each file, load it as a `WebpImage`, copy its frames (including `FrameDelay`) into a new `ApngImage`, then save using `ApngOptions`. → See: `batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs`

### Q: How do I extract the first frame from an animated APNG and save it as a static PNG using Aspose.Imaging?  
Open the animation with `ApngImage`, access `Frames[0]`, and call `Save` with a `PngOptions` instance. → See: `convert-an-animated-apng-to-a-static-png-by-extracting-the-first-frame-and-saving-it.cs`

### Q: How can I convert an APNG into a multi‑page TIFF where each animation frame becomes a separate page in .NET?  
Load the APNG via `ApngImage`, iterate its `Frames`, add each to a `TiffImage` using `TiffOptions`, and then save the TIFF. → See: `convert-an-apng-to-a-series-of-tiff-images-preserving-each-frame-as-a-separate-page.cs`

### Q: How do I create an APNG from multiple PNG files and specify a custom loop count using Aspose.Imaging?  
Instantiate an `ApngImage`, add each `PngImage` as a frame, set `ApngOptions.LoopCount` to the desired value, and save the result. → See: `load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs`