# Draw Cubic Bézier Curve on PNG with Aspose.Imaging for .NET  

A collection of C# snippets that show how to use **Aspose.Imaging for .NET** – a UI‑agnostic backend API that works in ASP.NET Core, console apps, Azure Functions, and Docker – to draw vector graphics, generate raster images in batch, and work with image metadata.  
Examples include drawing a cubic Bézier curve on a PNG, creating BMP files with colored backgrounds and centered ellipses, building a JPEG‑metadata array, applying `Graphics.TranslateTransform` before drawing additional shapes, and saving a vector illustration with a radial gradient as a high‑resolution TIFF.

## What You Can Do  

- **Draw a cubic Bézier curve on a PNG** using `PngOptions` and `Aspose.Imaging.Shapes.CubicBezierShape`.  
- **Generate a batch of BMP files**, each with a different background color and a centered black ellipse.  
- **Collect JPEG metadata and raw pixel data** into a strongly‑typed `Figure` array (filename, dimensions, comment, image bytes).  
- **Create a BMP, draw a rectangle, translate the graphics origin, and draw another shape** (ellipse) with `Graphics.TranslateTransform`.  
- **Build a vector illustration, apply a radial gradient background, and export it as a high‑resolution TIFF**.

## Quick Start  

The most common operation in this set is drawing a cubic Bézier curve on a PNG:

```csharp
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        string outPath = "cubic-bezier.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outPath) ?? ".");

        using (var pngOptions = new PngOptions())
        {
            pngOptions.Source = new FileCreateSource(outPath, false);
            using (var image = (Aspose.Imaging.Image)Image.Create(pngOptions, 400, 300))
            {
                // Define the cubic Bézier curve control points
                var bezier = new CubicBezierShape(
                    startX: 50, startY: 250,
                    control1X: 150, control1Y: 50,
                    control2X: 250, control2Y: 450,
                    endX: 350, endY: 150)
                {
                    StrokeColor = Color.Black,
                    StrokeWidth = 3
                };

                // Add the shape to the image and save
                image.AddShape(bezier);
                image.Save();
            }
        }

        Console.WriteLine($"Cubic Bézier curve saved to {outPath}");
    }
}
```

## Requirements  

- .NET 9.0 SDK  
- Aspose.Imaging NuGet package  

```bash
dotnet add package Aspose.Imaging
```

## Resources  

| Link | Description |
|------|-------------|
| [Documentation](https://docs.aspose.com/imaging/net/) | Official Aspose.Imaging for .NET docs |
| [NuGet](https://www.nuget.org/packages/aspose.imaging) | Package repository |
| [Release Notes](https://releases.aspose.com/imaging/net/) | Latest version changes |
| [Online Apps](https://products.aspose.app/imaging/family/) | Try Aspose.Imaging features in the browser |
| [Free Temporary License](https://purchase.aspose.com/temporary-license) | Get a temporary license for evaluation |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs](./add-a-cubic-bezier-curve-to-the-same-figure-using-specified-control-points.cs) |
| [add-a-custom-figure-overlay-onto-a-gif-image-ensuring-proper-frame-alignment-and-animation-compatibility.cs](./add-a-custom-figure-overlay-onto-a-gif-image-ensuring-proper-frame-alignment-and-animation-compatibility.cs) |
| [add-a-rectangle-shape-to-a-figure-using-figure-addshape-with-defined-coordinates.cs](./add-a-rectangle-shape-to-a-figure-using-figure-addshape-with-defined-coordinates.cs) |
| [add-geometric-figures-to-an-array-using-graphicspath-on-a-jpeg-image-and-render-them.cs](./add-geometric-figures-to-an-array-using-graphicspath-on-a-jpeg-image-and-render-them.cs) |
| [add-geometric-figures-to-an-array-via-graphicspath-on-a-png-image-using-net-imaging-apis.cs](./add-geometric-figures-to-an-array-via-graphicspath-on-a-png-image-using-net-imaging-apis.cs) |
| [add-the-completed-figure-to-the-graphicspath-using-graphicspath-addfigure-method.cs](./add-the-completed-figure-to-the-graphicspath-using-graphicspath-addfigure-method.cs) |
| [add-the-polygon-figure-to-the-graphicspath-and-fill-it-using-a-hatchbrush-with-cross-pattern.cs](./add-the-polygon-figure-to-the-graphicspath-and-fill-it-using-a-hatchbrush-with-cross-pattern.cs) |
| [add-the-star-figure-to-the-graphicspath-and-fill-it-with-a-radial-gradient-brush.cs](./add-the-star-figure-to-the-graphicspath-and-fill-it-with-a-radial-gradient-brush.cs) |
| [adjust-the-opacity-of-a-filling-brush-by-setting-its-alpha-value-before-calling-fillpath.cs](./adjust-the-opacity-of-a-filling-brush-by-setting-its-alpha-value-before-calling-fillpath.cs) |
| [append-multiple-figure-objects-to-the-image-s-internal-array-collection-to-enable-further-manipulation-and-rendering.cs](./append-multiple-figure-objects-to-the-image-s-internal-array-collection-to-enable-further-manipulation-and-rendering.cs) |
| [apply-a-clipping-region-using-graphics-setclip-with-the-graphicspath-to-restrict-drawing-area.cs](./apply-a-clipping-region-using-graphics-setclip-with-the-graphicspath-to-restrict-drawing-area.cs) |
| [apply-a-custom-color-palette-to-a-loaded-svg-before-converting-it-to-an-8-bit-png-image.cs](./apply-a-custom-color-palette-to-a-loaded-svg-before-converting-it-to-an-8-bit-png-image.cs) |
| [apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs](./apply-a-custom-dash-style-to-a-pen-and-draw-a-dashed-line-across-the-bmp.cs) |
| [apply-a-custom-stroke-pattern-to-all-paths-in-an-svg-file-and-export-the-styled-image-as-pdf.cs](./apply-a-custom-stroke-pattern-to-all-paths-in-an-svg-file-and-export-the-styled-image-as-pdf.cs) |
| [apply-a-grayscale-color-matrix-to-a-loaded-svg-image-before-exporting-it-to-png-format.cs](./apply-a-grayscale-color-matrix-to-a-loaded-svg-image-before-exporting-it-to-png-format.cs) |
| [apply-a-solidbrush-with-semi-transparent-red-color-to-fill-the-graphicspath-for-overlay-effect.cs](./apply-a-solidbrush-with-semi-transparent-red-color-to-fill-the-graphicspath-for-overlay-effect.cs) |
| [apply-fill-operations-to-defined-vector-paths-within-a-bmp-image-preserving-image-fidelity.cs](./apply-fill-operations-to-defined-vector-paths-within-a-bmp-image-preserving-image-fidelity.cs) |
| [apply-fill-operations-to-defined-vector-paths-within-a-jpeg2000-image-preserving-pixel-fidelity.cs](./apply-fill-operations-to-defined-vector-paths-within-a-jpeg2000-image-preserving-pixel-fidelity.cs) |
| [apply-graphics-rotatetransform-to-rotate-the-path-45-degrees-around-its-center-point.cs](./apply-graphics-rotatetransform-to-rotate-the-path-45-degrees-around-its-center-point.cs) |
| [apply-the-full-graphicspath-source-to-render-vector-shapes-onto-an-image-programmatically-accurately.cs](./apply-the-full-graphicspath-source-to-render-vector-shapes-onto-an-image-programmatically-accurately.cs) |
| [batch-convert-a-collection-of-vector-drawings-to-high-resolution-tiffs-applying-a-uniform-compression-algorithm-for-storage-efficiency.cs](./batch-convert-a-collection-of-vector-drawings-to-high-resolution-tiffs-applying-a-uniform-compression-algorithm-for-storage-efficiency.cs) |
| [batch-convert-a-collection-of-vector-drawings-to-high-resolution-tiffs-applying-a-uniform-compression-algorithm.cs](./batch-convert-a-collection-of-vector-drawings-to-high-resolution-tiffs-applying-a-uniform-compression-algorithm.cs) |
| [batch-convert-a-set-of-emf-files-to-pdf-embedding-each-file-s-original-filename-as-a-pdf-bookmark.cs](./batch-convert-a-set-of-emf-files-to-pdf-embedding-each-file-s-original-filename-as-a-pdf-bookmark.cs) |
| [batch-convert-a-set-of-svg-icons-to-monochrome-pngs-for-use-in-dark-theme-applications.cs](./batch-convert-a-set-of-svg-icons-to-monochrome-pngs-for-use-in-dark-theme-applications.cs) |
| [batch-convert-all-emf-files-in-a-directory-to-png-applying-a-uniform-background-color-to-each-image.cs](./batch-convert-all-emf-files-in-a-directory-to-png-applying-a-uniform-background-color-to-each-image.cs) |
| [batch-convert-eps-drawings-to-png-applying-a-uniform-scaling-factor-of-2-and-preserving-transparency.cs](./batch-convert-eps-drawings-to-png-applying-a-uniform-scaling-factor-of-2-and-preserving-transparency.cs) |
| [batch-convert-svg-icons-to-pdf-embedding-each-icon-as-a-vector-object-for-scalable-printing.cs](./batch-convert-svg-icons-to-pdf-embedding-each-icon-as-a-vector-object-for-scalable-printing.cs) |
| [batch-convert-svg-illustrations-to-pdf-embedding-each-file-s-description-as-pdf-metadata-for-cataloging.cs](./batch-convert-svg-illustrations-to-pdf-embedding-each-file-s-description-as-pdf-metadata-for-cataloging.cs) |
| [batch-convert-svg-logos-to-ico-files-generating-windows-icon-sizes-of-16-32-48-and-256-pixels.cs](./batch-convert-svg-logos-to-ico-files-generating-windows-icon-sizes-of-16-32-48-and-256-pixels.cs) |
| [batch-convert-wmf-graphics-to-png-applying-a-uniform-background-color-to-replace-transparent-areas.cs](./batch-convert-wmf-graphics-to-png-applying-a-uniform-background-color-to-replace-transparent-areas.cs) |
[**View all 401 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/working-with-drawing-images)