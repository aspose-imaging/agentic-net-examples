// HOW-TO: Convert PNG to SVG with Matching ViewBox in C# (Aspose.Imaging for .NET)
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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access dimensions
                var raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The input file is not a raster image.");
                    return;
                }

                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // Standard screen DPI

                // Create an SVG graphics canvas with the same size as the PNG
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG file
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
 * 1. When you need to embed a raster PNG into a responsive web page as scalable SVG without losing the original dimensions.
 * 2. When converting legacy PNG assets to vector SVG files for better scalability in mobile apps using C#.
 * 3. When generating SVG placeholders from PNG thumbnails for print layouts that require precise viewbox settings.
 * 4. When automating batch processing of PNG logos into SVG format to maintain consistent DPI across design tools.
 * 5. When creating SVG graphics from PNG images for use in PDF reports where vector format ensures crisp rendering.
 */
