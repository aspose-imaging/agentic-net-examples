using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the PNG as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;

            // Create an SVG graphics canvas with the same dimensions
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, 96);

            // Set stroke color to blue and draw a border rectangle
            Pen bluePen = new Pen(Color.Blue, 2);
            graphics.DrawRectangle(bluePen, 0, 0, width, height);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}