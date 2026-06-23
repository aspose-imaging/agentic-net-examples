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

- `using System;` (242/397 files)
- `using System.IO;` (242/397 files)
- `using Aspose.Imaging.ImageOptions;` (231/397 files) ← category-specific
- `using Aspose.Imaging;` (215/397 files) ← category-specific
- `using Aspose.Imaging.Sources;` (120/397 files) ← category-specific
- `using Aspose.Imaging.Brushes;` (52/397 files) ← category-specific
- `using Aspose.Imaging.Shapes;` (34/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (24/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (23/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (17/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (10/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf;` (9/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Eps;` (9/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (8/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (7/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (6/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (6/397 files) ← category-specific
- `using System.Collections.Generic;` (5/397 files)
- `using Aspose.Imaging.FileFormats.Jpeg;` (4/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Graphics;` (3/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Ico;` (2/397 files) ← category-specific
- `using Aspose.Imaging.CoreExceptions;` (1/397 files) ← category-specific
- `using Aspose.Imaging.CoreExceptions.ImageFormats;` (1/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats;` (1/397 files) ← category-specific
- `using System.Linq;` (1/397 files)
- `using Aspose.Imaging.Xmp.Schemas.Pdf;` (1/397 files) ← category-specific
- `using System.Drawing.Drawing2D;` (1/397 files)
- `using Aspose.Imaging.FileFormats.Emf.Emf.Records;` (1/397 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf.Emf.Objects;` (1/397 files) ← category-specific
- `using Aspose.Imaging.Masking;` (1/397 files) ← category-specific
- `using Aspose.Imaging.Masking.Options;` (1/397 files) ← category-specific
- `using Aspose.Imaging.Masking.Result;` (1/397 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (1/397 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.Convolution;` (1/397 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs](./create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs) | `BmpImage`, `Graphics` | Create a 200 × 200 BMP image, clear background to red, and save to file. |
| [generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs](./generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs) | `BmpOptions` | Generate a 500 × 300 BMP canvas and draw a blue line from (50,50) to (450,250). |
| [initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs](./initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs) | `BmpOptions` | Initialize a MemoryStream, create a BMP image, draw a green rectangle, and write... |
| [use-bmpoptions-with-a-filestream-source-to-produce-a-400-400-bmp-filled-with-yellow.cs](./use-bmpoptions-with-a-filestream-source-to-produce-a-400-400-bmp-filled-with-yellow.cs) | `BmpOptions`, `Graphics` | Use BmpOptions with a FileStream source to produce a 400 × 400 BMP filled with y... |
| [clear-a-bmp-image-to-light-gray-then-draw-multiple-red-lines-forming-a-grid.cs](./clear-a-bmp-image-to-light-gray-then-draw-multiple-red-lines-forming-a-grid.cs) | `BmpImage`, `Graphics` | Clear a BMP image to light gray, then draw multiple red lines forming a grid. |
| [create-a-bmp-image-set-background-to-white-then-draw-a-series-of-random-colored-lines.cs](./create-a-bmp-image-set-background-to-white-then-draw-a-series-of-random-colored-lines.cs) | `BmpOptions` | Create a BMP image, set background to white, then draw a series of random colore... |
| [clear-a-bmp-image-to-light-blue-then-draw-overlapping-semi-transparent-rectangles.cs](./clear-a-bmp-image-to-light-blue-then-draw-overlapping-semi-transparent-rectangles.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Clear a BMP image to light blue, then draw overlapping semi‑transparent rectangl... |
| [create-a-bmp-clear-to-dark-gray-then-draw-a-bright-yellow-diagonal-line.cs](./create-a-bmp-clear-to-dark-gray-then-draw-a-bright-yellow-diagonal-line.cs) | `BmpImage`, `BmpOptions` | Create a BMP, clear to dark gray, then draw a bright yellow diagonal line. |
| [create-a-bmp-clear-to-ivory-then-draw-diagonal-lines-forming-a-hatch-pattern.cs](./create-a-bmp-clear-to-ivory-then-draw-diagonal-lines-forming-a-hatch-pattern.cs) | `BmpImage`, `BmpOptions` | Create a BMP, clear to ivory, then draw diagonal lines forming a hatch pattern. |
| [create-a-bmp-image-clear-to-teal-then-draw-a-white-ellipse-centered-in-the-canvas.cs](./create-a-bmp-image-clear-to-teal-then-draw-a-white-ellipse-centered-in-the-canvas.cs) | `BmpOptions`, `Graphics`, `RasterImage` | Create a BMP image, clear to teal, then draw a white ellipse centered in the can... |
| [draw-a-filled-blue-rectangle-with-solidbrush-and-outline-it-using-a-thick-black-pen.cs](./draw-a-filled-blue-rectangle-with-solidbrush-and-outline-it-using-a-thick-black-pen.cs) | `Graphics`, `PngOptions`, `SolidBrush` | Draw a filled blue rectangle with SolidBrush and outline it using a thick black ... |
| [draw-an-ellipse-inside-a-300-200-rectangle-using-a-black-pen-and-save-the-bmp.cs](./draw-an-ellipse-inside-a-300-200-rectangle-using-a-black-pen-and-save-the-bmp.cs) | `BmpOptions`, `Graphics` | Draw an ellipse inside a 300 × 200 rectangle using a black Pen and save the BMP. |
| [create-a-bmp-image-draw-a-filled-ellipse-with-solidbrush-then-outline-it-using-a-contrasting-pen.cs](./create-a-bmp-image-draw-a-filled-ellipse-with-solidbrush-then-outline-it-using-a-contrasting-pen.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Create a BMP image, draw a filled ellipse with SolidBrush, then outline it using... |
| [create-a-bmp-image-draw-a-90-degree-arc-within-a-defined-rectangle-and-save-file.cs](./create-a-bmp-image-draw-a-90-degree-arc-within-a-defined-rectangle-and-save-file.cs) | `BmpOptions`, `Graphics` | Create a BMP image, draw a 90‑degree arc within a defined rectangle, and save fi... |
| [draw-an-arc-starting-at-45-degrees-sweeping-180-degrees-inside-a-400-200-rectangle.cs](./draw-an-arc-starting-at-45-degrees-sweeping-180-degrees-inside-a-400-200-rectangle.cs) | `PngOptions` | Draw an arc starting at 45 degrees, sweeping 180 degrees inside a 400 × 200 rect... |
| [generate-a-250-250-bmp-draw-a-bezier-curve-with-four-control-points-export-to-memorystream.cs](./generate-a-250-250-bmp-draw-a-bezier-curve-with-four-control-points-export-to-memorystream.cs) | `BmpImage`, `BmpOptions`, `Graphics` | Generate a 250 × 250 BMP, draw a Bezier curve with four control points, export t... |
| [draw-a-bezier-curve-that-approximates-a-circle-by-defining-appropriate-control-points-on-bmp.cs](./draw-a-bezier-curve-that-approximates-a-circle-by-defining-appropriate-control-points-on-bmp.cs) | `BmpOptions` | Draw a Bezier curve that approximates a circle by defining appropriate control p... |
| [draw-a-series-of-bezier-curves-connecting-sequential-points-to-form-a-wave-pattern-on-bmp.cs](./draw-a-series-of-bezier-curves-connecting-sequential-points-to-form-a-wave-pattern-on-bmp.cs) | `BmpOptions`, `Graphics` | Draw a series of Bezier curves connecting sequential points to form a wave patte... |
| [render-a-diagonal-orange-line-across-a-600-600-bmp-using-graphics-drawline-overload-with-coordinates.cs](./render-a-diagonal-orange-line-across-a-600-600-bmp-using-graphics-drawline-overload-with-coordinates.cs) | `BmpOptions` | Render a diagonal orange line across a 600 × 600 BMP using Graphics.DrawLine ove... |
| [implement-a-loop-that-draws-ten-equally-spaced-vertical-lines-on-a-bmp-using-a-thin-pen.cs](./implement-a-loop-that-draws-ten-equally-spaced-vertical-lines-on-a-bmp-using-a-thin-pen.cs) | `BmpOptions`, `Graphics` | Implement a loop that draws ten equally spaced vertical lines on a BMP using a t... |
| [apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs](./apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs) | `BmpOptions`, `Graphics` | Apply a custom dash style to a Pen and draw a dashed line across the BMP. |
| [use-a-pen-with-rounded-line-caps-to-draw-smooth-curves-on-a-bmp-canvas.cs](./use-a-pen-with-rounded-line-caps-to-draw-smooth-curves-on-a-bmp-canvas.cs) | `BmpOptions`, `Graphics` | Use a Pen with rounded line caps to draw smooth curves on a BMP canvas. |
| [use-a-pen-with-increased-width-to-draw-a-bold-rectangle-border-around-the-bmp-canvas.cs](./use-a-pen-with-increased-width-to-draw-a-bold-rectangle-border-around-the-bmp-canvas.cs) | `BmpOptions`, `Graphics`, `RasterImage` | Use a Pen with increased width to draw a bold rectangle border around the BMP ca... |
| [create-a-bmp-image-clear-to-navy-and-draw-a-white-diagonal-cross-using-two-lines.cs](./create-a-bmp-image-clear-to-navy-and-draw-a-white-diagonal-cross-using-two-lines.cs) | `BmpImage`, `BmpOptions` | Create a BMP image, clear to navy, and draw a white diagonal cross using two lin... |
| [use-graphics-drawrectangle-overload-with-location-and-size-parameters-to-outline-a-green-square.cs](./use-graphics-drawrectangle-overload-with-location-and-size-parameters-to-outline-a-green-square.cs) | `Graphics`, `PngOptions` | Use Graphics.DrawRectangle overload with location and size parameters to outline... |
| [use-graphics-drawrectangle-overload-with-a-rectanglef-structure-to-draw-a-floating-point-rectangle.cs](./use-graphics-drawrectangle-overload-with-a-rectanglef-structure-to-draw-a-floating-point-rectangle.cs) | `Graphics` | Use Graphics.DrawRectangle overload with a RectangleF structure to draw a floati... |
| [draw-an-ellipse-with-a-pen-that-has-a-custom-dash-pattern-on-a-bmp-background.cs](./draw-an-ellipse-with-a-pen-that-has-a-custom-dash-pattern-on-a-bmp-background.cs) | `BmpOptions`, `Graphics` | Draw an ellipse with a Pen that has a custom dash pattern on a BMP background. |
| [create-a-bmp-draw-a-rectangle-using-a-pen-constructed-from-a-solidbrush-with-custom-color.cs](./create-a-bmp-draw-a-rectangle-using-a-pen-constructed-from-a-solidbrush-with-custom-color.cs) | `BmpOptions`, `Graphics`, `SolidBrush` | Create a BMP, draw a rectangle using a Pen constructed from a SolidBrush with cu... |
| [create-a-bmp-draw-a-rectangle-then-fill-its-interior-using-solidbrush-with-solid-color.cs](./create-a-bmp-draw-a-rectangle-then-fill-its-interior-using-solidbrush-with-solid-color.cs) | `BmpOptions`, `SolidBrush` | Create a BMP, draw a rectangle then fill its interior using SolidBrush with soli... |
| [generate-a-bmp-canvas-draw-multiple-arcs-to-compose-a-semi-circular-gauge-indicator.cs](./generate-a-bmp-canvas-draw-multiple-arcs-to-compose-a-semi-circular-gauge-indicator.cs) | `BmpOptions`, `Graphics` | Generate a BMP canvas, draw multiple arcs to compose a semi‑circular gauge indic... |
| *...and 367 more files* | | [View all](https://github.com/aspose-imaging/agentic-net-examples/tree/26.5.0/working-with-drawing-images) |

## Category Statistics
- Total examples: 397
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngOptions`
- `BmpImage`
- `BmpOptions`
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

- Adding watermarks or logos to product photos programmatically, allowing you to **draw on image C#** files without manual editing.  
- Generating dynamic charts or infographics on the fly in a web service, using **graphics drawing dotnet** capabilities to render shapes, text, and colors.  
- Creating custom thumbnails that include overlay text or icons for media libraries, leveraging **image drawing Aspose** to maintain quality across formats.  
- Automating the annotation of medical or engineering diagrams with measurement lines and labels, a common need for **graphics drawing dotnet** in enterprise applications.  
- Building a batch processor that stamps batch‑generated certificates with unique QR codes and signatures, demonstrating how to **draw on image C#** at scale.  

## Related Categories  

The drawing examples often complement the **Image Conversion** and **Image Manipulation** sections, where you might first convert a source file before applying graphics. Techniques shown here also pair well with the **Metadata Handling** category, enabling you to embed drawing results alongside updated EXIF data. Exploring the **Vector Graphics** examples can further extend your workflow, offering additional ways to create and edit scalable drawing elements before rasterizing them with Aspose.Imaging.


## Developer Q&A

### Q: How to create a 200 × 200 BMP image, clear the background to red, and save it to a file?  
Create a `BmpImage` with `BmpOptions` sized 200 × 200, use `Graphics.Clear(Color.Red)`, then call `image.Save("output.bmp")`. → See: `create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs`

### Q: How do I generate a 500 × 300 BMP canvas and draw a blue line from (50,50) to (450,250) in C#?  
Instantiate `BmpOptions` with width = 500 and height = 300, obtain a `Graphics` object from the image, and call `graphics.DrawLine(new Pen(Color.Blue), 50, 50, 450, 250)`. → See: `generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs`

### Q: How to draw a green rectangle on a BMP image and write it to a MemoryStream using Aspose.Imaging?  
Initialize a `MemoryStream`, create a BMP via `BmpOptions`, use `Graphics.FillRectangle(new SolidBrush(Color.Green), rect)`, then save with `image.Save(stream, new BmpOptions())`. → See: `initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs`

### Q: How do I fill a 400 × 400 BMP with yellow using a FileStream source in .NET?  
Open a `FileStream`, set it as `BmpOptions.Source`, clear the canvas with `graphics.Clear(Color.Yellow)`, and save the image back to the stream. → See: `use-bmpoptions-with-a-filestream-source-to-produce-a-400-400-bmp-filled-with-yellow.cs`

### Q: How to draw a series of Bezier curves that form a wave pattern on a BMP in C#?  
Create a `BmpImage`, get its `Graphics` object, and call `graphics.DrawBezier` repeatedly with calculated control points to produce the wave, then save the image. → See: `draw-a-series-of-bezier-curves-connecting-sequential-points-to-form-a-wave-pattern-on-bmp.cs`



### Q: How can I add a cubic Bézier curve with custom control points to a PNG image using Aspose.Imaging in C#?  
Create a `PngOptions` with a `FileCreateSource`, call `Image.Create` to get the canvas, then use `Graphics.DrawBezier` with the desired `PointF` control points. → See: `add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs`

### Q: How do I render vector shapes from a full `GraphicsPath` onto a PNG file accurately with Aspose.Imaging in C#?  
Build the shapes in a `GraphicsPath`, then call `Graphics.DrawPath` on an image created via `PngOptions` and `FileCreateSource`. → See: `apply-the-full-graphicspath-source-to-render-vector-shapes-onto-an-image-programmatically-accurately.cs`

### Q: How can I batch‑process multiple size specifications to create BMP images each containing a centered square using Aspose.Imaging in C#?  
Iterate over the width/height array, create each BMP with `BmpOptions` and `Image.Create`, and draw a centered square with `Graphics.DrawRectangle`. → See: `batch-process-a-collection-of-size-specifications-creating-bmps-each-containing-a-centered-square.cs`

### Q: How do I clear a BMP image to light gray and then draw a red grid of lines using Aspose.Imaging in C#?  
After creating a `BmpImage`, fill the background with a `SolidBrush` of light gray, and loop with `Graphics.DrawLine` using a red `Pen` to draw the grid. → See: `clear-a-bmp-image-to-light-gray-then-draw-multiple-red-lines-forming-a-grid.cs`

### Q: How can I flatten a `GraphicsPath` to line segments for simplified rendering with Aspose.Imaging in C#?  
Load the source image, call `GraphicsPath.Flatten()` to convert curves to straight segments, and then render the flattened path with `Graphics.DrawPath`. → See: `flatten-the-graphicspath-to-convert-curves-into-line-segments-for-simplified-rendering.cs`

### Q: How can I create a new PNG image with specific width and height using Aspose.Imaging and save it directly to a file path in C#?  
Use `PngOptions` with a `FileCreateSource` pointing to the desired path, then call `Image.Create(pngOptions, width, height)` to generate the image. → See: `add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs`

### Q: How do I render an entire `GraphicsPath` onto a PNG image accurately with Aspose.Imaging in C#?  
Load or create a `Graphics` object from the image, call `graphics.DrawPath(yourGraphicsPath)`, and save the image using the configured `PngOptions`. → See: `apply-the-full-graphic

### Q: How do I create a 600 × 400 PNG and draw a cubic Bézier curve with custom control points using Aspose.Imaging in C#?  
Create a `PngOptions` with a `FileCreateSource`, call `Image.Create(pngOptions, 600, 400)`, then use `Graphics.DrawShape(new CubicBezierShape(...))` to add the curve. → See: add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs  

### Q: How can I bind a PNG output file via `FileCreateSource` and render an entire `GraphicsPath` onto it with Aspose.Imaging?  
Set `pngOptions.Source = new FileCreateSource(path, false)`, create the image, and call `GraphicsPathRenderer.Render(image, graphicsPath)` to paint the vector shapes. → See: apply-the-full-graphicspath-source-to-render-vector-shapes-onto-an-image-programmatically-accurately.cs  

### Q: How do I batch‑process multiple width/height specifications to generate BMP files each containing a centered square using Aspose.Imaging?  
Iterate over an array of size pairs, create each BMP with `BmpOptions` and `FileCreateSource`, then draw a square positioned at the center of the canvas using `Graphics.DrawRectangle`. → See: batch-process-a-collection-of-size-specifications-creating-bmps-each-containing-a-centered-square.cs  

### Q: How can I rotate subsequent drawings after drawing a base rectangle on a BMP using `Graphics.RotateTransform` in Aspose.Imaging?  
After drawing the initial rectangle, call `graphics.RotateTransform(angle)`; all following drawing calls (lines, shapes, etc.) will be rendered with the applied rotation. → See: create-a-bmp-draw-a-rectangle-then-use-graphics-rotatetransform-to-rotate-subsequent-drawings.cs  

### Q: How do I render a `GraphicsPath` onto an ICO image file with Aspose.Imaging in C#?  
Configure `IcoOptions` with a `FileCreateSource`, create the ICO image, and invoke `GraphicsPathRenderer.Render(icoImage, graphicsPath)` to paint the vector path onto the icon. → See: create-and-configure-graphics-instances-using-a-graphicspath-to-render-onto-an-ico-image.cs
## Operations Covered
- Create a new PNG canvas and clear it with a color  
- Add a cubic‑bezier curve to a figure using control points  
- Convert a batch of SVG files to PDF documents  
- Embed each SVG file’s description as PDF metadata  
- Convert WMF files to SVG and apply a uniform fill color to all shapes  
- Preserve line widths when converting PDF vector diagrams to SVG  
- Generate a BMP image and draw concentric circles with alternating colors  
- Apply a radial gradient background to a vector illustration and save as high‑resolution TIFF  
- Draw multiple arcs to compose a semi‑circular gauge indicator  

## Supported Formats
- **PNG** – created as the output image in the first example.  
- **SVG** – source files for batch conversion to PDF and for WMF‑to‑SVG processing.  
- **PDF** – target format for SVG batch conversion; also source format for PDF‑to‑SVG conversion.  
- **WMF** – input format processed and converted to SVG.  
- **BMP** – canvas format for concentric‑circles and gauge‑indicator examples.  
- **TIFF** – high‑resolution output format for the radial‑gradient vector illustration.  

## API Classes Used
- `Image` — central class for loading, creating, and saving images.  
- `PngOptions` — specifies options (e.g., source) when creating a PNG image.  
- `BmpOptions` — defines BMP‑specific settings such as bits‑per‑pixel.  
- `TiffOptions` — configures TIFF parameters like photometric, compression, and bits per sample.  
- `FileCreateSource` — represents a file‑based image source for newly created images.  
- `Graphics` — provides drawing surface to render shapes, paths, and fills on an image.  
- `Color` — static class offering predefined colors and color creation utilities.  
- `GraphicsPath` — container for a series of drawing commands (lines, curves, arcs).  
- `Figure` — groups multiple shapes into a single drawable entity.  
- `Figure.AddShape` — method that adds a specific shape (e.g., cubic‑bezier) to a figure.  
- `Image.Load` — loads an existing image file (PDF, WMF, etc.) into an `Image` object.  
- `Aspose.Imaging.FileFormats.Pdf.PdfDocument` (implied via namespace) — used for PDF creation and metadata handling.  
- `Aspose.Imaging.FileFormats.Wmf.WmfImage` — represents WMF files for processing and conversion.  
- `RadialGradientBrush` (from `Aspose.Imaging.Brushes`) — creates a radial gradient fill for vector illustrations.  
- `Directory` / `Path` — .NET utilities used to ensure output folders exist (supporting the imaging workflow).

<!-- AUTOGENERATED:START -->
Updated: 2026-06-05 | Run: `20260605_073031` | Examples: 397
<!-- AUTOGENERATED:END -->