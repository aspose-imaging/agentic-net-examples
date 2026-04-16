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

        // Load the PNG image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;

            // Create an SVG graphics canvas with the same dimensions
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, 96);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0));

            // Set stroke width to 2 pixels by drawing a rectangle border
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawRectangle(pen, 0, 0, width, height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}