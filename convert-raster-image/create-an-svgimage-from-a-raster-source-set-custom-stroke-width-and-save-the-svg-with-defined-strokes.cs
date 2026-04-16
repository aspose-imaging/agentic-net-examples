using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.bmp";
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
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics context with the same dimensions as the raster image
            int dpi = 96;
            SvgGraphics2D graphics = new SvgGraphics2D(raster.Width, raster.Height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(raster.Width, raster.Height));

            // Define a custom pen with a specific stroke width (e.g., 5 pixels) and color
            Pen customPen = new Pen(Color.Red, 5);

            // Draw a rectangle border around the image using the custom pen
            graphics.DrawRectangle(customPen, 0, 0, raster.Width, raster.Height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG to the output path
                svgImage.Save(outputPath);
            }
        }
    }
}