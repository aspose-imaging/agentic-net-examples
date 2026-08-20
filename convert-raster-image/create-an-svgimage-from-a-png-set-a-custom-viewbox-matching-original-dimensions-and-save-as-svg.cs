// HOW-TO: Convert PNG to SVG with Exact ViewBox Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image loadedImage = Image.Load(inputPath))
            {
                // Cast to RasterImage to access dimensions
                RasterImage raster = (RasterImage)loadedImage;
                int width = raster.Width;
                int height = raster.Height;

                // Create SVG graphics canvas with matching size
                var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, 96);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
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
 * 1. When you need to embed a raster PNG into a scalable SVG for responsive web design while preserving the original pixel dimensions.
 * 2. When generating vector assets from user‑uploaded PNG logos so they can be resized without loss of quality in a C# application.
 * 3. When converting PNG screenshots to SVG files for inclusion in documentation that requires precise viewbox coordinates.
 * 4. When automating batch processing of PNG icons into SVG format to maintain consistent sizing across a UI toolkit using Aspose.Imaging.
 * 5. When creating an SVG placeholder that displays a PNG image at its native resolution for dynamic image rendering in a .NET service.
 */
