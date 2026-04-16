using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input raster image path
        string inputPath = @"C:\temp\input.png";

        // Hardcoded output SVG path
        string outputPath = @"C:\temp\output.svg";

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
            // Define custom SVG dimensions (viewbox) and DPI
            int svgWidth = 800;   // custom width in pixels
            int svgHeight = 600;  // custom height in pixels
            int dpi = 96;         // standard screen DPI

            // Create a graphics context for SVG drawing
            SvgGraphics2D graphics = new SvgGraphics2D(svgWidth, svgHeight, dpi);

            // Draw the raster image onto the SVG canvas, scaling to fit the custom size
            graphics.DrawImage(
                (RasterImage)rasterImage,
                new Point(0, 0),
                new Size(svgWidth, svgHeight));

            // Finalize recording and obtain the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG image to the specified output path
                svgImage.Save(outputPath);
            }
        }
    }
}