# Draw on Image C# with Aspose.Imaging

Use Aspose.Imaging for .NET to draw on images directly from C#. The examples below demonstrate graphics drawing in .NET, covering basic shapes, lines, and background fills with the **image drawing Aspose** API.

## What's in This Category
- Create a BMP canvas and set a solid background color.  
- Draw straight lines with custom colors and thickness.  
- Render rectangles (filled or outlined) on an image.  
- Work with `MemoryStream` to generate images in memory.  
- Save the resulting image to file or stream.

## Quick Start
The most common scenario is creating a bitmap, clearing its background, drawing a line, and saving the result:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Drawing;

// Create a 500×300 BMP canvas
using var image = new Image<BmpOptions>(new BmpOptions(), 500, 300);
var graphics = new Graphics(image);

// Fill background with white
graphics.Clear(Color.White);

// Draw a blue line from (50,50) to (450,250)
graphics.DrawLine(new Pen(Color.Blue, 3), 50, 50, 450, 250);

// Save to file
image.Save("output.bmp");
```

## Files

Examples and tasks in this folder:

| Example | Notes |
|---------|-------|
| [add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs](./add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs) | |
| [add-a-custom-figure-overlay-onto-a-gif-image-ensuring-proper-frame-alignment-and-animation-compatibility.cs](./add-a-custom-figure-overlay-onto-a-gif-image-ensuring-proper-frame-alignment-and-animation-compatibility.cs) | |
| [add-a-rectangle-shape-to-a-figure-using-figure-addshape-with-defined-coordinates.cs](./add-a-rectangle-shape-to-a-figure-using-figure-addshape-with-defined-coordinates.cs) | |
| [add-geometric-figures-to-an-array-using-graphicspath-on-a-jpeg-image-and-render-them.cs](./add-geometric-figures-to-an-array-using-graphicspath-on-a-jpeg-image-and-render-them.cs) | |
| [add-geometric-figures-to-an-array-via-graphicspath-on-a-png-image-using-net-imaging-apis.cs](./add-geometric-figures-to-an-array-via-graphicspath-on-a-png-image-using-net-imaging-apis.cs) | |
| [add-the-completed-figure-to-the-graphicspath-using-graphicspath-addfigure-method.cs](./add-the-completed-figure-to-the-graphicspath-using-graphicspath-addfigure-method.cs) | |
| [add-the-polygon-figure-to-the-graphicspath-and-fill-it-using-a-hatchbrush-with-cross-pattern.cs](./add-the-polygon-figure-to-the-graphicspath-and-fill-it-using-a-hatchbrush-with-cross-pattern.cs) | |
| [add-the-star-figure-to-the-graphicspath-and-fill-it-with-a-radial-gradient-brush.cs](./add-the-star-figure-to-the-graphicspath-and-fill-it-with-a-radial-gradient-brush.cs) | |
| [adjust-the-opacity-of-a-filling-brush-by-setting-its-alpha-value-before-calling-fillpath.cs](./adjust-the-opacity-of-a-filling-brush-by-setting-its-alpha-value-before-calling-fillpath.cs) | |
| [append-multiple-figure-objects-to-the-image-s-internal-array-collection-to-enable-further-manipulation-and-rendering.cs](./append-multiple-figure-objects-to-the-image-s-internal-array-collection-to-enable-further-manipulation-and-rendering.cs) | |
| [apply-a-clipping-region-using-graphics-setclip-with-the-graphicspath-to-restrict-drawing-area.cs](./apply-a-clipping-region-using-graphics-setclip-with-the-graphicspath-to-restrict-drawing-area.cs) | |
| [apply-a-custom-color-palette-to-a-loaded-svg-before-converting-it-to-an-8-bit-png-image.cs](./apply-a-custom-color-palette-to-a-loaded-svg-before-converting-it-to-an-8-bit-png-image.cs) | |
| [apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs](./apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs) | |
| [apply-a-custom-stroke-pattern-to-all-paths-in-an-svg-file-and-export-the-styled-image-as-pdf.cs](./apply-a-custom-stroke-pattern-to-all-paths-in-an-svg-file-and-export-the-styled-image-as-pdf.cs) | |
| [apply-a-grayscale-color-matrix-to-a-loaded-svg-image-before-exporting-it-to-png-format.cs](./apply-a-grayscale-color-matrix-to-a-loaded-svg-image-before-exporting-it-to-png-format.cs) | |
| [apply-a-solidbrush-with-semi-transparent-red-color-to-fill-the-graphicspath-for-overlay-effect.cs](./apply-a-solidbrush-with-semi-transparent-red-color-to-fill-the-graphicspath-for-overlay-effect.cs) | |
| [apply-fill-operations-to-defined-vector-paths-within-a-bmp-image-preserving-image-fidelity.cs](./apply-fill-operations-to-defined-vector-paths-within-a-bmp-image-preserving-image-fidelity.cs) | |
| [apply-fill-operations-to-defined-vector-paths-within-a-jpeg2000-image-preserving-pixel-fidelity.cs](./apply-fill-operations-to-defined-vector-paths-within-a-jpeg2000-image-preserving-pixel-fidelity.cs) | |
| [apply-graphics-rotatetransform-to-rotate-the-path-45-degrees-around-its-center-point.cs](./apply-graphics-rotatetransform-to-rotate-the-path-45-degrees-around-its-center-point.cs) | |
| [apply-the-full-graphicspath-source-to-render-vector-shapes-onto-an-image-programmatically-accurately.cs](./apply-the-full-graphicspath-source-to-render-vector-shapes-onto-an-image-programmatically-accurately.cs) | |
| [batch-convert-a-collection-of-vector-drawings-to-high-resolution-tiffs-applying-a-uniform-compression-algorithm-for-storage-efficiency.cs](./batch-convert-a-collection-of-vector-drawings-to-high-resolution-tiffs-applying-a-uniform-compression-algorithm-for-storage-efficiency.cs) | |
| [batch-convert-a-set-of-emf-files-to-pdf-embedding-each-file-s-original-filename-as-a-pdf-bookmark.cs](./batch-convert-a-set-of-emf-files-to-pdf-embedding-each-file-s-original-filename-as-a-pdf-bookmark.cs) | |
| [batch-convert-a-set-of-svg-icons-to-monochrome-pngs-for-use-in-dark-theme-applications.cs](./batch-convert-a-set-of-svg-icons-to-monochrome-pngs-for-use-in-dark-theme-applications.cs) | |
| [batch-convert-all-emf-files-in-a-directory-to-png-applying-a-uniform-background-color-to-each-image.cs](./batch-convert-all-emf-files-in-a-directory-to-png-applying-a-uniform-background-color-to-each-image.cs) | |
| [batch-convert-eps-drawings-to-png-applying-a-uniform-scaling-factor-of-2-and-preserving-transparency.cs](./batch-convert-eps-drawings-to-png-applying-a-uniform-scaling-factor-of-2-and-preserving-transparency.cs) | |
| [batch-convert-svg-icons-to-pdf-embedding-each-icon-as-a-vector-object-for-scalable-printing.cs](./batch-convert-svg-icons-to-pdf-embedding-each-icon-as-a-vector-object-for-scalable-printing.cs) | |
| [batch-convert-svg-illustrations-to-pdf-embedding-each-file-s-description-as-pdf-metadata-for-cataloging.cs](./batch-convert-svg-illustrations-to-pdf-embedding-each-file-s-description-as-pdf-metadata-for-cataloging.cs) | |
| [batch-convert-svg-logos-to-ico-files-generating-windows-icon-sizes-of-16-32-48-and-256-pixels.cs](./batch-convert-svg-logos-to-ico-files-generating-windows-icon-sizes-of-16-32-48-and-256-pixels.cs) | |
| [batch-convert-wmf-graphics-to-png-applying-a-uniform-background-color-to-replace-transparent-areas.cs](./batch-convert-wmf-graphics-to-png-applying-a-uniform-background-color-to-replace-transparent-areas.cs) | |
| [batch-create-bmp-files-each-containing-a-rotated-version-of-the-same-base-shape.cs](./batch-create-bmp-files-each-containing-a-rotated-version-of-the-same-base-shape.cs) | |
| *...and 367 more files* | [View all ↗](https://github.com/aspose-imaging/agentic-net-examples/tree/main/working-with-drawing-images) |

## Requirements
- **Aspose.Imaging** NuGet package (latest version)  
- **.NET 9** or later  

[← Back to Root README](../README.md)