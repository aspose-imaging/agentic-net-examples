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
- `using Aspose.Imaging;` (51/51 files) ← category-specific
- `using Aspose.Imaging.ImageOptions;` (49/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (29/51 files) ← category-specific
- `using Aspose.Imaging.Sources;` (20/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (17/51 files) ← category-specific
- `using System.Collections.Generic;` (4/51 files)
- `using Aspose.Imaging.FileFormats.Gif;` (4/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (3/51 files) ← category-specific
- `using System.Linq;` (2/51 files)
- `using Aspose.Imaging.FileFormats.Svg;` (2/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (2/51 files) ← category-specific
- `using System.Diagnostics;` (1/51 files)
- `using Aspose.Imaging.Brushes;` (1/51 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (1/51 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs](./load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Load a PNG image and create an animated APNG with custom frame delays. |
| [generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs](./generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Generate an APNG from a single‑page PNG, specifying a 100 ms delay for each fram... |
| [load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs](./load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Load multiple PNG images and assemble them into a single APNG animation with cus... |
| [create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs](./create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Create an APNG from a PNG sequence stored in a directory, using alphabetical fil... |
| [create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs](./create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Create an APNG from a series of PNGs, assigning each frame a random delay betwee... |
| [set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs](./set-apng-background-color-to-transparent-and-verify-compatibility-with-standard-png-viewers.cs) | `ApngImage` | Set APNG background color to transparent and verify compatibility with standard ... |
| [preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs](./preserve-backward-compatibility-when-saving-apng-files-that-contain-only-a-single-static-frame.cs) | `ApngOptions` | Preserve backward compatibility when saving APNG files that contain only a singl... |
| [set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs](./set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs) | `ApngOptions` | Set APNG loop count to zero to indicate infinite looping for continuous animatio... |
| [set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs](./set-apng-loop-count-to-5-and-test-playback-speed-consistency-across-different-image-viewers.cs) | `ApngOptions` | Set APNG loop count to 5 and test playback speed consistency across different im... |
| [set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs](./set-custom-loop-count-and-frame-delay-for-an-apng-using-a-configuration-object-before-saving.cs) | `ApngOptions` | Set custom loop count and frame delay for an APNG using a configuration object b... |
| [adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs](./adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Adjust APNG frame delays based on external timing data stored in a JSON configur... |
| [set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs](./set-apng-metadata-software-field-to-indicate-processing-library-version-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set APNG metadata “Software” field to indicate processing library version before... |
| [set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs](./set-custom-apng-metadata-fields-for-author-description-and-creation-date-before-saving.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Set custom APNG metadata fields for author, description, and creation date befor... |
| [save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs](./save-an-apng-image-to-disk-with-lossless-compression-and-embed-color-profile-information.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Save an APNG image to disk with lossless compression and embed color profile inf... |
| [convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs](./convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs) | `ApngOptions` | Convert an animated WEBP file to an APNG while preserving original animation tim... |
| [load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs](./load-an-animated-webp-modify-frame-order-and-save-as-a-new-apng-file.cs) | `ApngImage`, `ApngOptions`, `IMultipageImage` | Load an animated WEBP, modify frame order, and save as a new APNG file. |
| [load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs](./load-an-animated-webp-change-its-color-palette-and-save-the-modified-animation-as-apng.cs) | `ApngOptions`, `ColorPalette`, `WebPImage` | Load an animated WEBP, change its color palette, and save the modified animation... |
| [load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs](./load-an-animated-webp-reduce-its-dimensions-by-half-and-save-the-resized-animation-as-apng.cs) | `ApngImage`, `ApngOptions` | Load an animated WEBP, reduce its dimensions by half, and save the resized anima... |
| [load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs](./load-an-animated-webp-convert-it-to-apng-and-verify-that-frame-delays-match-the-original.cs) | `ApngOptions` | Load an animated WEBP, convert it to APNG, and verify that frame delays match th... |
| [batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs](./batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs) | `ApngOptions` | Batch convert a folder of WEBP files to APNG format, applying uniform frame dela... |
| [batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs](./batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs) | `ApngOptions` | Batch convert animated WEBP files to APNG, preserving original frame order and t... |
| [batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs](./batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs) | `ApngOptions` | Batch convert a set of animated WEBP files to APNG, generating a summary CSV of ... |
| [load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs](./load-a-vector-svg-animate-its-elements-over-time-and-save-the-result-as-an-apng-file.cs) | `ApngFrame`, `ApngImage`, `ApngOptions` | Load a vector SVG, animate its elements over time, and save the result as an APN... |
| [create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs](./create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | Create an animated APNG using an SVG vector graphic, defining frame dimensions a... |
| [load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs](./load-an-svg-rasterize-it-at-different-resolutions-for-each-frame-and-compile-into-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load an SVG, rasterize it at different resolutions for each frame, and compile i... |
| [load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs](./load-a-vector-svg-animate-its-fill-color-gradient-and-export-the-animation-as-an-apng-file.cs) | `ApngImage`, `ApngOptions`, `Graphics` | Load a vector SVG, animate its fill color gradient, and export the animation as ... |
| [load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs](./load-a-vector-svg-animate-its-rotation-over-time-and-save-the-animation-as-an-apng.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | Load a vector SVG, animate its rotation over time, and save the animation as an ... |
| [convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs](./convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs) | `ApngOptions` | Convert a batch of SVG files into individual APNG animations, each with default ... |
| [batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs](./batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs) | `ApngOptions` | Batch convert a collection of SVG files to APNG, assigning each SVG a random fra... |
| [load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs](./load-a-tiff-image-with-multiple-pages-and-specify-frame-duration-based-on-page-resolution.cs) | `TiffImage` | Load a TIFF image with multiple pages and specify frame duration based on page r... |
| *...and 21 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.5.0/convert-apng) |

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


## Developer Q&A

### Q: How do I load a PNG image and create an animated APNG with custom frame delays in C# .NET?  
Load the PNG using `RasterImage.Load`, then instantiate an `ApngImage` and add `ApngFrame` objects, setting each frame’s `Delay` property as needed. → See: `load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs`

### Q: How to generate an APNG from a single‑page PNG and set a 100 ms delay for each frame in .NET?  
Load the source PNG with `RasterImage.Load`, create an `ApngImage` using `ApngOptions` where `DefaultFrameDelay = 100`, and save the result. → See: `generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs`

### Q: How do I set the APNG loop count to zero for infinite looping in C#?  
Assign `ApngOptions.LoopCount = 0` before calling `ApngImage.Save`. → See: `set-apng-loop-count-to-zero-to-indicate-infinite-looping-for-continuous-animation-playback.cs`

### Q: How to convert an animated WEBP file to an APNG while preserving the original animation timing using Aspose.Imaging for .NET?  
Load the WEBP with `Image.Load`, cast to `IMultipageImage`, copy its frames into a new `ApngImage`, and keep the original frame delays via `ApngOptions`. → See: `convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs`

### Q: How do I batch convert a folder of WEBP files to APNG format with a uniform frame delay in C#?  
Loop through the folder, load each WEBP with `Image.Load`, create an `ApngImage` setting `ApngOptions.DefaultFrameDelay` to the desired uniform value, and save each as an .apng file. → See: `batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs`



### Q: How can I set custom frame delays for an APNG using timing values stored in a JSON file with Aspose.Imaging for .NET?  
Parse the JSON, then create an `ApngImage` and assign each frame’s `Delay` via `ApngOptions.FrameDelay` based on the parsed values; load the source PNG with `Image.Load`. → See: adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs  

### Q: How do I generate an animated APNG from a directory of PNG images ordered alphabetically using Aspose.Imaging in C#?  
Retrieve PNG file names, sort them alphabetically, load each with `Image.Load`, add them as frames to an `ApngImage`, and save using `ApngOptions`. → See: create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs  

### Q: What is the simplest way to batch convert multiple SVG files into separate APNG files with the default frame delay using Aspose.Imaging for .NET?  
Iterate over the SVG paths, load each SVG via `Image.Load`, create an `ApngImage` with default `ApngOptions` (which applies the default frame delay), and save each output file. → See: convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs  

### Q: How can I export every frame of an animated APNG to individual BMP files using Aspose.Imaging in C#?  
Load the APNG with `Image.Load`, loop through its `Frames` collection, and save each frame using `BmpOptions` to a separate BMP file. → See: convert-an-apng-to-a-series-of-bmp-files-for-compatibility-with-legacy-imaging-systems.cs  

### Q: How do I preserve each frame of an APNG as separate pages in a multi‑page TIFF using Aspose.Imaging for .NET?  
Load the APNG, create a new `TiffImage`, add each APNG frame as a new page with `TiffOptions`, then save the combined TIFF. → See: convert-an-apng-to-a-series-of-tiff-images-preserving-each-frame-as-a-separate-page.cs

### Q: How can I extract the first frame of an animated APNG and save it as a static PNG using Aspose.Imaging for .NET?  
Load the APNG with `Image.Load`, cast to `ApngImage`, take `Frames[0]` and save it with `PngOptions`. → See: `convert-an-animated-apng-to-a-static-png-by-extracting-the-first-frame-and-saving-it.cs`

### Q: How do I convert an APNG into a series of BMP files for legacy imaging
## Operations Covered
- Adjust APNG frame delays using JSON timing data  
- Convert animated WebP files to APNG in batch  
- Record conversion times to a CSV summary file  
- Create APNG files from PNG sequences (alphabetical order)  
- Log each conversion’s success status to a report file  
- Convert multi‑page TIFF to APNG with lossless compression  
- Extract the first frame of an animated APNG and save as static PNG  
- Export each APNG frame to separate JPEG images with indexed filenames  

## Supported Formats
- **PNG** – source and destination for static images and PNG sequences  
- **APNG** – animated PNG format used for loading, modifying, and saving animations  
- **WebP** – animated WebP files converted to APNG  
- **TIFF** – multi‑page TIFF files converted to APNG  
- **JPEG** – individual frames exported from APNG as JPEG images  

## API Classes Used
- `Image` — base class for loading and saving any supported image type (`Image.Load`, `Image.Save`).  
- `ApngImage` — represents an animated PNG; provides access to frames via `Pages` and frame count via `PageCount`.  
- `RasterImage` — represents a raster image frame; used when extracting or converting individual frames.  
- `Image.Load` — static method that reads an image file into an `Image`‑derived object.  
- `Image.Save` — instance method that writes the image (or modified image) to a file.  
- `ApngImage.Pages` — collection property exposing each frame of the APNG for iteration or manipulation.  
- `ApngImage.PageCount` — property returning the total number of frames in the APNG.  
- `StreamWriter` (from `System.IO`) — used to write CSV logs of conversion times and status reports.

<!-- AUTOGENERATED:START -->
Updated: 2026-05-29 | Run: `20260529_141531` | Examples: 51
<!-- AUTOGENERATED:END -->