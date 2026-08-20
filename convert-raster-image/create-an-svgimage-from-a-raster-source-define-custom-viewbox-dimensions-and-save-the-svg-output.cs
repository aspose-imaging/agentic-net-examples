// HOW-TO: Create SVG From PNG With Custom ViewBox In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.png";
        string outputPath = @"C:\temp\output.svg";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster source image
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Define custom viewbox dimensions (width, height, dpi)
                int viewBoxWidth = 800;   // custom width in pixels
                int viewBoxHeight = 600;  // custom height in pixels
                int dpi = 96;             // typical screen DPI

                // Create an SVG graphics context with the custom viewbox
                SvgGraphics2D graphics = new SvgGraphics2D(viewBoxWidth, viewBoxHeight, dpi);

                // Draw the raster image onto the SVG canvas, scaling to fit the viewbox
                graphics.DrawImage((RasterImage)rasterImage,
                                   new Aspose.Imaging.Point(0, 0),
                                   new Aspose.Imaging.Size(viewBoxWidth, viewBoxHeight));

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG output
                    svgImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed a high‑resolution PNG into a scalable SVG for responsive web design, this code converts the raster image and sets a specific viewbox size.
 * 2. When generating vector graphics for print layouts that require exact dimensions and DPI, the example creates an SVG with a custom viewbox matching the desired output size.
 * 3. When automating batch conversion of product photos to SVG icons with consistent width and height, the code demonstrates how to draw and scale each raster image onto an SVG canvas.
 * 4. When integrating Aspose.Imaging into a C# application that must produce SVG assets for mobile apps, the snippet shows how to load a PNG, define viewbox parameters, and save the result.
 * 5. When you need to programmatically create SVG placeholders that reference existing raster images while preserving aspect ratio, this example illustrates drawing the image onto an SVG graphics context with custom scaling.
 */
