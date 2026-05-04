using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input raster image path
            string inputPath = @"C:\temp\source.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output SVG path
            string outputPath = @"C:\temp\output.svg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image to obtain its dimensions
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Create an SVG graphics canvas with the same size as the raster image
                int width = rasterImage.Width;
                int height = rasterImage.Height;
                int dpi = 96; // standard screen DPI

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage((RasterImage)rasterImage, new Point(0, 0), new Size(width, height));

                // Draw a rectangle border around the image with a 3‑pixel stroke
                Pen borderPen = new Pen(Color.Black, 3);
                graphics.DrawRectangle(borderPen, 0, 0, width, height);

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