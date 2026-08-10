// HOW-TO: Create SVG From PNG With Blue Border Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG as raster image
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                int width = rasterImage.Width;
                int height = rasterImage.Height;
                int dpi = 96;

                // Create SVG graphics canvas
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(rasterImage, new Aspose.Imaging.Point(0, 0));

                // Set stroke color to blue and draw a rectangle border
                graphics.DrawRectangle(new Pen(Color.Blue, 2), 0, 0, width, height);

                // Finalize SVG image and save
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
 * 1. When you need to embed a raster PNG into a scalable SVG for responsive web pages while adding a blue outline.
 * 2. When generating vector assets from user‑uploaded PNGs for print‑ready PDFs and you want a consistent blue frame.
 * 3. When converting product photos to SVG format for interactive diagrams and need a highlighted border to match branding.
 * 4. When automating batch processing of PNG icons into SVG icons with a uniform blue stroke for UI libraries.
 * 5. When creating SVG maps that overlay PNG textures and require a blue rectangle to indicate the image boundaries.
 */
