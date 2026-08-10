// HOW-TO: Create SVG From PNG With Red Outline Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PNG and output SVG paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                // Create an SVG canvas with the same dimensions
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Draw a red outline around the image
                var redPen = new Pen(Color.Red, 1);
                graphics.DrawRectangle(redPen, 0, 0, width, height);

                // Finalize and save the SVG
                using (SvgImage svg = graphics.EndRecording())
                {
                    svg.Save(outputPath);
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
 * 1. When you need to embed a raster PNG into a scalable SVG for web graphics while highlighting its borders with a red stroke.
 * 2. When generating printable assets that require vector format but you only have PNG sources and want a visible red frame for branding.
 * 3. When creating thumbnails for a UI that must be scalable and you want to emphasize the image area with a red outline.
 * 4. When converting product photos to SVG for responsive design and need a red border to indicate selection or focus.
 * 5. When automating batch processing of PNG assets to SVG with consistent red outlines for use in documentation or reports.
 */
