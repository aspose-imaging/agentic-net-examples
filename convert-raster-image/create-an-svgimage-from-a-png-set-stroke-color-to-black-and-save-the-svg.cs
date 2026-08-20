// HOW-TO: Convert PNG to SVG with Black Border Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

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

            // Load the PNG raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Create an SVG graphics canvas with the same dimensions as the PNG
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // standard screen DPI

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Set stroke color to black by drawing a rectangle border
                graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width, height);

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
 * 1. When you need to embed a raster PNG into a scalable SVG for responsive web graphics while adding a visible black outline.
 * 2. When generating vector assets from existing PNG logos for print or UI design and you want a consistent border around the image.
 * 3. When automating batch conversion of product photos to SVG format for an online catalog that requires a uniform stroke for styling.
 * 4. When creating SVG placeholders that preserve the original PNG dimensions and need a black frame for visual separation in a UI mockup.
 * 5. When integrating image processing into a C# application that must output SVG files with a defined stroke color for downstream vector editing tools.
 */
