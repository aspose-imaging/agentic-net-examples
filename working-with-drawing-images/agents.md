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
- `using System.IO;` (241/401 files)
- `using Aspose.Imaging.ImageOptions;` (237/401 files) ← category-specific
- `using Aspose.Imaging;` (216/401 files) ← category-specific
- `using Aspose.Imaging.Sources;` (130/401 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (61/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (57/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (33/401 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (30/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (25/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (16/401 files) ← category-specific
- `using System.Collections.Generic;` (12/401 files)
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (12/401 files) ← category-specific
- `using System.Linq;` (9/401 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (7/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (7/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Eps;` (7/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf;` (3/401 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (2/401 files) ← category-specific
- `using System.Globalization;` (1/401 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs](./create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs) | `BmpImage`, `BmpOptions`, `Graphics` | Create a 200 × 200 BMP image, clear background to red, and save to file. |
| [generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs](./generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs) | `BmpOptions`, `Graphics`, `RasterImage` | Generate a 500 × 300 BMP canvas and draw a blue line from (50,50) to (450,250). |
| [initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs](./initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs) | `BmpOptions`, `Graphics` | Initialize a MemoryStream, create a BMP image, draw a green rectangle, and write... |
| [use-bmpoptions-with-a-filestream-source-to-produce-a-400-400-bmp-filled-with-yellow.cs](./use-bmpoptions-with-a-filestream-source-to-produce-a-400-400-bmp-filled-with-yellow.cs) | `BmpOptions`, `Graphics`, `RasterImage` | Use BmpOptions with a FileStream source to produce a 400 × 400 BMP filled with y... |
| [clear-a-bmp-image-to-light-gray-then-draw-multiple-red-lines-forming-a-grid.cs](./clear-a-bmp-image-to-light-gray-then-draw-multiple-red-lines-forming-a-grid.cs) | `BmpOptions`, `Graphics` | Clear a BMP image to light gray, then draw multiple red lines forming a grid. |
| [create-a-bmp-image-set-background-to-white-then-draw-a-series-of-random-colored-lines.cs](./create-a-bmp-image-set-background-to-white-then-draw-a-series-of-random-colored-lines.cs) | `BmpOptions`, `Graphics` | Create a BMP image, set background to white, then draw a series of random colore... |
| [clear-a-bmp-image-to-light-blue-then-draw-overlapping-semi-transparent-rectangles.cs](./clear-a-bmp-image-to-light-blue-then-draw-overlapping-semi-transparent-rectangles.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Clear a BMP image to light blue, then draw overlapping semi‑transparent rectangl... |
| [create-a-bmp-clear-to-dark-gray-then-draw-a-bright-yellow-diagonal-line.cs](./create-a-bmp-clear-to-dark-gray-then-draw-a-bright-yellow-diagonal-line.cs) | `BmpOptions`, `Graphics` | Create a BMP, clear to dark gray, then draw a bright yellow diagonal line. |
| [create-a-bmp-clear-to-ivory-then-draw-diagonal-lines-forming-a-hatch-pattern.cs](./create-a-bmp-clear-to-ivory-then-draw-diagonal-lines-forming-a-hatch-pattern.cs) | `BmpOptions`, `Graphics` | Create a BMP, clear to ivory, then draw diagonal lines forming a hatch pattern. |
| [create-a-bmp-image-clear-to-teal-then-draw-a-white-ellipse-centered-in-the-canvas.cs](./create-a-bmp-image-clear-to-teal-then-draw-a-white-ellipse-centered-in-the-canvas.cs) | `BmpOptions`, `Graphics` | Create a BMP image, clear to teal, then draw a white ellipse centered in the can... |
| [draw-a-filled-blue-rectangle-with-solidbrush-and-outline-it-using-a-thick-black-pen.cs](./draw-a-filled-blue-rectangle-with-solidbrush-and-outline-it-using-a-thick-black-pen.cs) | `Graphics`, `PngOptions`, `SolidBrush` | Draw a filled blue rectangle with SolidBrush and outline it using a thick black ... |
| [draw-an-ellipse-inside-a-300-200-rectangle-using-a-black-pen-and-save-the-bmp.cs](./draw-an-ellipse-inside-a-300-200-rectangle-using-a-black-pen-and-save-the-bmp.cs) | `BmpOptions`, `Graphics` | Draw an ellipse inside a 300 × 200 rectangle using a black Pen and save the BMP. |
| [create-a-bmp-image-draw-a-filled-ellipse-with-solidbrush-then-outline-it-using-a-contrasting-pen.cs](./create-a-bmp-image-draw-a-filled-ellipse-with-solidbrush-then-outline-it-using-a-contrasting-pen.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Create a BMP image, draw a filled ellipse with SolidBrush, then outline it using... |
| [create-a-bmp-image-draw-a-90-degree-arc-within-a-defined-rectangle-and-save-file.cs](./create-a-bmp-image-draw-a-90-degree-arc-within-a-defined-rectangle-and-save-file.cs) | `BmpOptions`, `Graphics` | Create a BMP image, draw a 90‑degree arc within a defined rectangle, and save fi... |
| [draw-an-arc-starting-at-45-degrees-sweeping-180-degrees-inside-a-400-200-rectangle.cs](./draw-an-arc-starting-at-45-degrees-sweeping-180-degrees-inside-a-400-200-rectangle.cs) | `Graphics`, `PngOptions` | Draw an arc starting at 45 degrees, sweeping 180 degrees inside a 400 × 200 rect... |
| [generate-a-250-250-bmp-draw-a-bezier-curve-with-four-control-points-export-to-memorystream.cs](./generate-a-250-250-bmp-draw-a-bezier-curve-with-four-control-points-export-to-memorystream.cs) | `BmpOptions`, `Graphics` | Generate a 250 × 250 BMP, draw a Bezier curve with four control points, export t... |
| [draw-a-bezier-curve-that-approximates-a-circle-by-defining-appropriate-control-points-on-bmp.cs](./draw-a-bezier-curve-that-approximates-a-circle-by-defining-appropriate-control-points-on-bmp.cs) | `BmpOptions`, `Graphics` | Draw a Bezier curve that approximates a circle by defining appropriate control p... |
| [draw-a-series-of-bezier-curves-connecting-sequential-points-to-form-a-wave-pattern-on-bmp.cs](./draw-a-series-of-bezier-curves-connecting-sequential-points-to-form-a-wave-pattern-on-bmp.cs) | `BmpOptions`, `Graphics` | Draw a series of Bezier curves connecting sequential points to form a wave patte... |
| [render-a-diagonal-orange-line-across-a-600-600-bmp-using-graphics-drawline-overload-with-coordinates.cs](./render-a-diagonal-orange-line-across-a-600-600-bmp-using-graphics-drawline-overload-with-coordinates.cs) | `BmpOptions`, `Graphics` | Render a diagonal orange line across a 600 × 600 BMP using Graphics.DrawLine ove... |
| [implement-a-loop-that-draws-ten-equally-spaced-vertical-lines-on-a-bmp-using-a-thin-pen.cs](./implement-a-loop-that-draws-ten-equally-spaced-vertical-lines-on-a-bmp-using-a-thin-pen.cs) | `BmpOptions`, `Graphics` | Implement a loop that draws ten equally spaced vertical lines on a BMP using a t... |
| [apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs](./apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs) | `BmpOptions`, `Graphics` | Apply a custom dash style to a Pen and draw a dashed line across the BMP. |
| [use-a-pen-with-rounded-line-caps-to-draw-smooth-curves-on-a-bmp-canvas.cs](./use-a-pen-with-rounded-line-caps-to-draw-smooth-curves-on-a-bmp-canvas.cs) | `BmpOptions`, `Graphics` | Use a Pen with rounded line caps to draw smooth curves on a BMP canvas. |
| [use-a-pen-with-increased-width-to-draw-a-bold-rectangle-border-around-the-bmp-canvas.cs](./use-a-pen-with-increased-width-to-draw-a-bold-rectangle-border-around-the-bmp-canvas.cs) | `BmpOptions`, `Graphics` | Use a Pen with increased width to draw a bold rectangle border around the BMP ca... |
| [create-a-bmp-image-clear-to-navy-and-draw-a-white-diagonal-cross-using-two-lines.cs](./create-a-bmp-image-clear-to-navy-and-draw-a-white-diagonal-cross-using-two-lines.cs) | `BmpOptions`, `Graphics` | Create a BMP image, clear to navy, and draw a white diagonal cross using two lin... |
| [use-graphics-drawrectangle-overload-with-location-and-size-parameters-to-outline-a-green-square.cs](./use-graphics-drawrectangle-overload-with-location-and-size-parameters-to-outline-a-green-square.cs) | `Graphics`, `PngOptions`, `RasterImage` | Use Graphics.DrawRectangle overload with location and size parameters to outline... |
| [use-graphics-drawrectangle-overload-with-a-rectanglef-structure-to-draw-a-floating-point-rectangle.cs](./use-graphics-drawrectangle-overload-with-a-rectanglef-structure-to-draw-a-floating-point-rectangle.cs) | `BmpOptions`, `Graphics` | Use Graphics.DrawRectangle overload with a RectangleF structure to draw a floati... |
| [draw-an-ellipse-with-a-pen-that-has-a-custom-dash-pattern-on-a-bmp-background.cs](./draw-an-ellipse-with-a-pen-that-has-a-custom-dash-pattern-on-a-bmp-background.cs) | `BmpOptions`, `Graphics` | Draw an ellipse with a Pen that has a custom dash pattern on a BMP background. |
| [create-a-bmp-draw-a-rectangle-using-a-pen-constructed-from-a-solidbrush-with-custom-color.cs](./create-a-bmp-draw-a-rectangle-using-a-pen-constructed-from-a-solidbrush-with-custom-color.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Create a BMP, draw a rectangle using a Pen constructed from a SolidBrush with cu... |
| [create-a-bmp-draw-a-rectangle-then-fill-its-interior-using-solidbrush-with-solid-color.cs](./create-a-bmp-draw-a-rectangle-then-fill-its-interior-using-solidbrush-with-solid-color.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Create a BMP, draw a rectangle then fill its interior using SolidBrush with soli... |
| [generate-a-bmp-canvas-draw-multiple-arcs-to-compose-a-semi-circular-gauge-indicator.cs](./generate-a-bmp-canvas-draw-multiple-arcs-to-compose-a-semi-circular-gauge-indicator.cs) | `BmpOptions`, `Graphics`, `RasterImage` | Generate a BMP canvas, draw multiple arcs to compose a semi‑circular gauge indic... |
| *...and 371 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.9.0/working-with-drawing-images) |

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
- `RasterCachedImage`
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
- When you need to add a smooth curve to a generated PNG, you can use `Graphics` together with `CubicBezierShape` to **draw a cubic bezier curve on PNG** exactly as shown in the “add‑a‑cubic‑bezier‑curve‑to‑the‑same‑figure‑using‑specified‑control‑points” example.  
- If your project ships a set of SVG icons and you must deliver them as a single, scalable PDF for printing, the “batch‑convert‑svg‑icons‑to‑pdf‑embedding‑each‑icon‑as‑a‑vector‑object‑for‑scalable‑printing” sample demonstrates how to **batch convert SVG icons to vector PDF in C#** with Aspose.Imaging.  
- For compliance‑driven reports that require all fonts to be embedded, the “batch‑process‑vector‑graphics‑converting‑each‑to‑pdf‑with‑embedded‑fonts‑and‑setting‑pdf‑version‑to‑1‑6” code shows how to **convert vector images to PDF with embedded fonts** using the `PdfOptions` API.  
- When you receive a multi‑page SVG (e.g., a multi‑sheet diagram) and must produce one PDF that keeps the original page sequence, the “convert‑a‑multi‑page‑svg‑document‑to‑a‑single‑pdf‑file‑preserving‑page‑order‑and‑vector‑fidelity” example illustrates how to **preserve page order when converting multi‑page SVG to a single PDF**.  
- To create a blank canvas and draw basic shapes such as rectangles, ellipses, or arcs before saving as PNG, the “create‑a‑bmp‑image‑draw‑a‑90‑degree‑arc‑within‑a‑defined‑rectangle‑and‑save‑file” snippet can be adapted to **create a PNG image and draw shapes using Aspose.Imaging Graphics**.

## Related Categories
If you need to turn raster drawings into other formats, the **[Convert Raster Image](../convert-raster-image/)** category provides examples for exporting PNG or BMP files to JPEG, TIFF, and more.  
When your workflow involves turning SVG files into raster graphics (e.g., thumbnails) before further processing, see **[Convert Svg To Raster Images](../convert-svg-to-raster-images/)** for straightforward conversions using Aspose.Imaging.  
For post‑processing tasks such as applying color corrections or filters to the images you create with drawing APIs, the **[Image And Photo Filters](../image-and-photo-filters/)** section offers a rich set of filter examples that can be chained after drawing operations.

<!-- AUTOGENERATED:START -->
Updated: 2026-10-07 | Run: `20261002_134755` | Examples: 401
<!-- AUTOGENERATED:END -->