using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input GIF path and output SVG path
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF as a raster image
        using (RasterImage gifImage = (RasterImage)Image.Load(inputPath))
        {
            int width = gifImage.Width;
            int height = gifImage.Height;
            int dpi = 96; // Standard screen DPI

            // Create an SVG graphics canvas with the same dimensions as the GIF
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster GIF onto the SVG canvas
            graphics.DrawImage(gifImage, new Point(0, 0));

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}