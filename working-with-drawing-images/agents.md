---
name: working-with-drawing-images
description: C# examples for Working With Drawing Images using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Working With Drawing Images

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Working With Drawing Images** category.
This folder contains standalone C# examples for Working With Drawing Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (242/401 files)
- `using System.IO;` (242/401 files)
- `using Aspose.Imaging.ImageOptions;` (234/401 files) ← category-specific
- `using Aspose.Imaging;` (199/401 files) ← category-specific
- `using Aspose.Imaging.Sources;` (136/401 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (61/401 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (37/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (25/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (22/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (21/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (14/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (12/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf;` (12/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Eps;` (12/401 files) ← category-specific
- `using System.Collections.Generic;` (8/401 files)
- `using Aspose.Imaging.FileFormats.Emf;` (7/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (6/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (5/401 files) ← category-specific
- `using System.Linq;` (3/401 files)
- `using Aspose.Imaging.FileFormats.Tiff;` (2/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Graphics;` (2/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf.Consts;` (1/401 files) ← category-specific
- `using Aspose.Imaging.CoreExceptions.ImageFormats;` (1/401 files) ← category-specific
- `using Aspose.Imaging.CoreExceptions;` (1/401 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (1/401 files) ← category-specific
- `using Aspose.Imaging.Masking;` (1/401 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (1/401 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (1/401 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs](./create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs) | `BmpOptions`, `Graphics`, `RasterImage` | Create a 200 × 200 BMP image, clear background to red, and save to file. |
| [generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs](./generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs) | `BmpOptions`, `Graphics`, `RasterImage` | Generate a 500 × 300 BMP canvas and draw a blue line from (50,50) to (450,250). |
| [initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs](./initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs) | `BmpOptions`, `Graphics` | Initialize a MemoryStream, create a BMP image, draw a green rectangle, and write... |
| [use-bmpoptions-with-a-filestream-source-to-produce-a-400-400-bmp-filled-with-yellow.cs](./use-bmpoptions-with-a-filestream-source-to-produce-a-400-400-bmp-filled-with-yellow.cs) | `BmpOptions`, `SolidBrush` | Use BmpOptions with a FileStream source to produce a 400 × 400 BMP filled with y... |
| [clear-a-bmp-image-to-light-gray-then-draw-multiple-red-lines-forming-a-grid.cs](./clear-a-bmp-image-to-light-gray-then-draw-multiple-red-lines-forming-a-grid.cs) | `BmpOptions` | Clear a BMP image to light gray, then draw multiple red lines forming a grid. |
| [create-a-bmp-image-set-background-to-white-then-draw-a-series-of-random-colored-lines.cs](./create-a-bmp-image-set-background-to-white-then-draw-a-series-of-random-colored-lines.cs) | `BmpOptions` | Create a BMP image, set background to white, then draw a series of random colore... |
| [clear-a-bmp-image-to-light-blue-then-draw-overlapping-semi-transparent-rectangles.cs](./clear-a-bmp-image-to-light-blue-then-draw-overlapping-semi-transparent-rectangles.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Clear a BMP image to light blue, then draw overlapping semi‑transparent rectangl... |
| [create-a-bmp-clear-to-dark-gray-then-draw-a-bright-yellow-diagonal-line.cs](./create-a-bmp-clear-to-dark-gray-then-draw-a-bright-yellow-diagonal-line.cs) | `BmpOptions` | Create a BMP, clear to dark gray, then draw a bright yellow diagonal line. |
| [create-a-bmp-clear-to-ivory-then-draw-diagonal-lines-forming-a-hatch-pattern.cs](./create-a-bmp-clear-to-ivory-then-draw-diagonal-lines-forming-a-hatch-pattern.cs) | `BmpOptions`, `Graphics` | Create a BMP, clear to ivory, then draw diagonal lines forming a hatch pattern. |
| [create-a-bmp-image-clear-to-teal-then-draw-a-white-ellipse-centered-in-the-canvas.cs](./create-a-bmp-image-clear-to-teal-then-draw-a-white-ellipse-centered-in-the-canvas.cs) | `BmpOptions` | Create a BMP image, clear to teal, then draw a white ellipse centered in the can... |
| [draw-a-filled-blue-rectangle-with-solidbrush-and-outline-it-using-a-thick-black-pen.cs](./draw-a-filled-blue-rectangle-with-solidbrush-and-outline-it-using-a-thick-black-pen.cs) | `Graphics`, `PngOptions`, `SolidBrush` | Draw a filled blue rectangle with SolidBrush and outline it using a thick black ... |
| [draw-an-ellipse-inside-a-300-200-rectangle-using-a-black-pen-and-save-the-bmp.cs](./draw-an-ellipse-inside-a-300-200-rectangle-using-a-black-pen-and-save-the-bmp.cs) | `BmpOptions` | Draw an ellipse inside a 300 × 200 rectangle using a black Pen and save the BMP. |
| [create-a-bmp-image-draw-a-filled-ellipse-with-solidbrush-then-outline-it-using-a-contrasting-pen.cs](./create-a-bmp-image-draw-a-filled-ellipse-with-solidbrush-then-outline-it-using-a-contrasting-pen.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Create a BMP image, draw a filled ellipse with SolidBrush, then outline it using... |
| [create-a-bmp-image-draw-a-90-degree-arc-within-a-defined-rectangle-and-save-file.cs](./create-a-bmp-image-draw-a-90-degree-arc-within-a-defined-rectangle-and-save-file.cs) | `BmpOptions`, `Graphics` | Create a BMP image, draw a 90‑degree arc within a defined rectangle, and save fi... |
| [draw-an-arc-starting-at-45-degrees-sweeping-180-degrees-inside-a-400-200-rectangle.cs](./draw-an-arc-starting-at-45-degrees-sweeping-180-degrees-inside-a-400-200-rectangle.cs) | `Graphics`, `PngOptions` | Draw an arc starting at 45 degrees, sweeping 180 degrees inside a 400 × 200 rect... |
| [generate-a-250-250-bmp-draw-a-bezier-curve-with-four-control-points-export-to-memorystream.cs](./generate-a-250-250-bmp-draw-a-bezier-curve-with-four-control-points-export-to-memorystream.cs) | `BmpOptions`, `Graphics` | Generate a 250 × 250 BMP, draw a Bezier curve with four control points, export t... |
| [draw-a-bezier-curve-that-approximates-a-circle-by-defining-appropriate-control-points-on-bmp.cs](./draw-a-bezier-curve-that-approximates-a-circle-by-defining-appropriate-control-points-on-bmp.cs) | `BmpOptions`, `Graphics` | Draw a Bezier curve that approximates a circle by defining appropriate control p... |
| [draw-a-series-of-bezier-curves-connecting-sequential-points-to-form-a-wave-pattern-on-bmp.cs](./draw-a-series-of-bezier-curves-connecting-sequential-points-to-form-a-wave-pattern-on-bmp.cs) | `BmpOptions`, `Graphics` | Draw a series of Bezier curves connecting sequential points to form a wave patte... |
| [render-a-diagonal-orange-line-across-a-600-600-bmp-using-graphics-drawline-overload-with-coordinates.cs](./render-a-diagonal-orange-line-across-a-600-600-bmp-using-graphics-drawline-overload-with-coordinates.cs) | `BmpOptions` | Render a diagonal orange line across a 600 × 600 BMP using Graphics.DrawLine ove... |
| [implement-a-loop-that-draws-ten-equally-spaced-vertical-lines-on-a-bmp-using-a-thin-pen.cs](./implement-a-loop-that-draws-ten-equally-spaced-vertical-lines-on-a-bmp-using-a-thin-pen.cs) | `BmpOptions`, `Graphics` | Implement a loop that draws ten equally spaced vertical lines on a BMP using a t... |
| [apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs](./apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs) | `BmpOptions` | Apply a custom dash style to a Pen and draw a dashed line across the BMP. |
| [use-a-pen-with-rounded-line-caps-to-draw-smooth-curves-on-a-bmp-canvas.cs](./use-a-pen-with-rounded-line-caps-to-draw-smooth-curves-on-a-bmp-canvas.cs) | `BmpOptions`, `Graphics` | Use a Pen with rounded line caps to draw smooth curves on a BMP canvas. |
| [use-a-pen-with-increased-width-to-draw-a-bold-rectangle-border-around-the-bmp-canvas.cs](./use-a-pen-with-increased-width-to-draw-a-bold-rectangle-border-around-the-bmp-canvas.cs) | `BmpOptions` | Use a Pen with increased width to draw a bold rectangle border around the BMP ca... |
| [create-a-bmp-image-clear-to-navy-and-draw-a-white-diagonal-cross-using-two-lines.cs](./create-a-bmp-image-clear-to-navy-and-draw-a-white-diagonal-cross-using-two-lines.cs) | `BmpImage`, `BmpOptions`, `Graphics` | Create a BMP image, clear to navy, and draw a white diagonal cross using two lin... |
| [use-graphics-drawrectangle-overload-with-location-and-size-parameters-to-outline-a-green-square.cs](./use-graphics-drawrectangle-overload-with-location-and-size-parameters-to-outline-a-green-square.cs) | `Graphics`, `PngOptions` | Use Graphics.DrawRectangle overload with location and size parameters to outline... |
| [use-graphics-drawrectangle-overload-with-a-rectanglef-structure-to-draw-a-floating-point-rectangle.cs](./use-graphics-drawrectangle-overload-with-a-rectanglef-structure-to-draw-a-floating-point-rectangle.cs) | `Graphics`, `PngOptions` | Use Graphics.DrawRectangle overload with a RectangleF structure to draw a floati... |
| [draw-an-ellipse-with-a-pen-that-has-a-custom-dash-pattern-on-a-bmp-background.cs](./draw-an-ellipse-with-a-pen-that-has-a-custom-dash-pattern-on-a-bmp-background.cs) | `BmpOptions` | Draw an ellipse with a Pen that has a custom dash pattern on a BMP background. |
| [create-a-bmp-draw-a-rectangle-using-a-pen-constructed-from-a-solidbrush-with-custom-color.cs](./create-a-bmp-draw-a-rectangle-using-a-pen-constructed-from-a-solidbrush-with-custom-color.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Create a BMP, draw a rectangle using a Pen constructed from a SolidBrush with cu... |
| [create-a-bmp-draw-a-rectangle-then-fill-its-interior-using-solidbrush-with-solid-color.cs](./create-a-bmp-draw-a-rectangle-then-fill-its-interior-using-solidbrush-with-solid-color.cs) | `BmpOptions`, `SolidBrush` | Create a BMP, draw a rectangle then fill its interior using SolidBrush with soli... |
| [generate-a-bmp-canvas-draw-multiple-arcs-to-compose-a-semi-circular-gauge-indicator.cs](./generate-a-bmp-canvas-draw-multiple-arcs-to-compose-a-semi-circular-gauge-indicator.cs) | `BmpOptions`, `Graphics` | Generate a BMP canvas, draw multiple arcs to compose a semi‑circular gauge indic... |
| *...and 371 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.8.0/working-with-drawing-images) |

## Category Statistics
- Total examples: 401
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngOptions`
- `BmpImage`
- `BmpOptions`
- `Color`
- `ConvolutionFilterOptions`
- `EmfImage`
- `EmfOptions`
- `EmfRasterizationOptions`
- `EpsImage`
- `EpsLoadOptions`
- `EpsRasterizationOptions`
- `GaussianBlurFilterOptions`
- `GifImage`
- `GifOptions`
- `Graphics`
- `HatchBrush`
- `IcoImage`
- `IcoOptions`
- `Jpeg2000Image`
- `Jpeg2000LoadOptions`
- `Jpeg2000Options`
- `JpegImage`
- `JpegOptions`
- `JsonSerializerOptions`
- `LinearGradientBrush`
- `LoadOptions`
- `MaskingOptions`
- `MetaImage`
- `MultiPageOptions`
- `PathGradientBrush`
- `PdfCoreOptions`
- `PdfOptions`
- `PngImage`
- `PngOptions`
- `RasterImage`
- `SharpenFilterOptions`
- `SolidBrush`
- `StringFormat`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `TextureBrush`
- `TiffFrame`
- `TiffImage`
- `TiffOptions`
- `VectorRasterizationOptions`
- `WmfImage`
- `WmfOptions`
- `WmfRasterizationOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- **Add custom vector graphics to a PNG thumbnail** – Use Aspose.Imaging’s `Graphics` object to draw a cubic Bézier curve (as shown in the *add‑a‑cubic‑bezier‑curve* sample) when you need to overlay smooth, scalable lines on a PNG image in a C# web service. This is a classic “draw on image C#” scenario that leverages the `Graphics` API for precise curve control.  

- **Create high‑resolution BMP assets with geometric shapes** – The *create‑a‑bmp‑image‑draw‑a‑90‑degree‑arc* example demonstrates how to generate a 24‑bpp BMP, draw a 90° arc inside a defined rectangle, and save it directly to disk, perfect for producing bitmap icons or background textures in desktop applications.  

- **Batch‑convert SVG icons to vector‑based PDF for print‑ready output** – By iterating through an input folder and using `PdfOptions` together with `Image.Load`, the *batch‑convert‑svg‑icons‑to‑pdf* script converts each SVG into a PDF that retains its vector fidelity, ideal for automating the preparation of scalable assets for marketing collateral.  

- **Produce multi‑page PDF reports from a series of SVG diagrams** – The *convert‑a‑multi‑page‑svg‑document‑to‑a‑single‑pdf* sample shows how to load a multi‑page SVG, preserve page order, and export a single PDF while keeping all vector information intact, a common requirement for generating technical documentation in .NET.  

- **Generate chart graphics on the fly and embed them in PDF reports** – Using `PngOptions` as a drawing surface, the *create‑a‑vector‑chart‑add‑data‑labels‑and‑export‑the‑chart‑as‑a‑pdf* example draws bars, labels, and colors, then saves the result as a PDF, enabling dynamic chart creation for dashboards or automated reporting pipelines.

## Related Categories
If you’re working with drawing primitives, the **Image Manipulation** category expands on pixel‑level edits such as filtering, resizing, and color adjustments that often precede or follow graphics drawing operations. For scenarios that require converting between raster and vector formats, explore the **Vector Graphics Conversion** section, which includes examples of SVG ↔ PDF and EPS handling. When you need to embed custom fonts or apply advanced text rendering, the **Text Rendering & Font Embedding** category provides code snippets that complement the graphics drawing workflow demonstrated here.

## Operations Covered
- Create PNG image canvas  
- Draw cubic Bezier curve on image  
- Batch convert SVG icons to PDF  
- Embed vector objects in PDF output  
- Embed fonts in generated PDF  
- Set PDF version to 1.6  
- Convert multi‑page SVG to single PDF preserving order  
- Preserve vector fidelity during SVG‑to‑PDF conversion  
- Create BMP image with 90‑degree arc  
- Generate bar chart with data labels  
- Export chart as PDF document  
- Draw Bezier curve and save to MemoryStream  

## Supported Formats
- **PNG** – used as the drawing surface and final output for raster graphics.  
- **BMP** – created with custom bit‑depth options and saved to disk or memory.  
- **SVG** – source vector graphics that are loaded and converted to PDF.  
- **PDF** – target format for vector‑based conversions, chart export, and embedded‑font PDFs.  

## API Classes Used
- `PngOptions` — defines settings (e.g., source, compression) for creating or saving PNG files.  
- `BmpOptions` — specifies BMP creation parameters such as bits‑per‑pixel and output source.  
- `FileCreateSource` — represents a file‑based stream used to write newly created images.  
- `Image` — core class for loading, creating, and manipulating images of any supported format.  
- `Graphics` — provides drawing primitives (lines, curves, arcs, etc.) to render shapes onto an image.  
- `PdfOptions` — configures PDF generation options, including version number and font embedding.  
- `Image.Load` — static method that loads an existing image file (e.g., SVG) into an `Image` object.  
- `Image.Create` — static method that creates a blank image with specified dimensions and options.  
- `Aspose.Imaging.Brushes` (e.g., `SolidBrush`) — supplies brush objects for filling shapes.  
- `Aspose.Imaging.Shapes` (e.g., `Bezier`, `Arc`) — contains shape classes used to draw curves and arcs.  
- `Aspose.Imaging.FileFormats.Pdf` — namespace providing PDF‑specific classes and utilities.  
- `Aspose.Imaging.FileFormats.Svg` — namespace offering SVG‑specific handling and conversion support.


## Get Started

Ready to try Working With Drawing Images conversions on your own files with Aspose.Imaging for .NET?

```bash
dotnet add package Aspose.Imaging
```

| Resource | Link |
|----------|------|
| 📖 Documentation | [docs.aspose.com/imaging/net](https://docs.aspose.com/imaging/net/) |
| 📦 NuGet Package | [nuget.org/packages/Aspose.Imaging](https://www.nuget.org/packages/aspose.imaging) |
| 🚀 Release Notes | [releases.aspose.com/imaging/net](https://releases.aspose.com/imaging/net/) |
| 🌐 Online Apps | [products.aspose.app/imaging](https://products.aspose.app/imaging/family/) |
| 🔑 Free Temporary License | [purchase.aspose.com/temporary-license](https://purchase.aspose.com/temporary-license) |
| 🤝 Consulting (paid implementation help) | [consulting.aspose.com](https://consulting.aspose.com/) |

<!-- AUTOGENERATED:START -->
Updated: 2026-08-20 | Run: `20260731_113931` | Examples: 401
<!-- AUTOGENERATED:END -->

## Developer Q&A

### Q: How can I draw a cubic Bezier curve on a PNG image using Aspose.Imaging in C#?  
Create a `GraphicsPath`, add a `BezierSegment` with the desired control points, and render it onto a `RasterImage` via a `Graphics` object. → See: `add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs`

### Q: How do I generate multiple BMP files each with a different background color and a centered black ellipse using Aspose.Imaging?  
Iterate over the color list, instantiate a new `BmpImage` with `ImageOptions`, fill the background with a `SolidBrush`, draw the centered ellipse using `Graphics`, and save each file. → See: `batch-generate-bmp-files-each-containing-a-different-background-color-and-a-centered-black-ellipse.cs`

### Q: How can I create a BMP image from raw ARGB pixel data with Aspose.Imaging?  
Use `BmpImage` (or `RasterImage.Create`) together with `ImageOptions` and a `MemorySource` to supply the integer pixel array, then save the image. → See: `generate-a-bmp-image-file-from-provided-pixel-data-using-the-library-s-image-creation-api.cs`

### Q: How do I apply a motion blur effect to an SVG and export it as a high‑quality JPEG using Aspose.Imaging?  
Load the SVG with `Image.Load`, apply `MotionBlurFilter` via `ImageProcessor`, and save the result with `JpegOptions` specifying the desired quality. → See: `load-a-vector-image-apply-a-motion-blur-effect-and-export-the-blurred-result-as-a-high-quality-jpeg.cs`

### Q: How can I clear all pixel data of an image while preserving its original dimensions in Aspose.Imaging?  
Call the `Clear` method on the `RasterImage` (or fill it with a transparent brush) to reset the canvas without changing width or height. → See: `reset-the-image-canvas-to-a-blank-state-by-clearing-all-pixel-data-while-preserving-its-dimensions.cs`