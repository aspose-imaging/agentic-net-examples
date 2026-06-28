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
        string inputPath = @"C:\temp\input.png";
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

            // Load the raster image
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Cast to RasterImage for drawing
                RasterImage raster = rasterImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The input file is not a raster image.");
                    return;
                }

                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // Standard screen DPI

                // Create an SVG graphics context with custom dimensions (viewbox)
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

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
 * 1. When a web developer needs to convert a PNG logo into a scalable SVG for responsive design while preserving the original dimensions and DPI.
 * 2. When an e‑learning platform wants to embed high‑resolution raster diagrams as vector graphics in HTML5 courses to reduce page load and enable zoom without pixelation.
 * 3. When a desktop application generates printable reports and must embed raster charts as SVG to ensure they scale correctly on different paper sizes.
 * 4. When a CI/CD pipeline automates asset optimization by turning raster icons into SVG files with a defined viewbox so they can be styled with CSS.
 * 5. When a GIS tool needs to overlay a raster map tile onto an SVG canvas with custom viewbox coordinates before exporting the result for vector‑based mapping applications.
 */