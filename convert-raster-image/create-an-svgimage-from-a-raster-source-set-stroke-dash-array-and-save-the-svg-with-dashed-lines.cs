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
        string inputPath = @"C:\temp\sample.bmp";
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
            SvgGraphics2D graphics = new SvgGraphics2D(raster.Width, raster.Height, 96);

            // Create a pen with a dash pattern (5 units dash, 5 units gap)
            Pen dashPen = new Pen(Color.Black, 2);
            dashPen.DashPattern = new float[] { 5, 5 };

            // Draw a rectangle using the dashed pen
            graphics.DrawRectangle(dashPen, 0, 0, raster.Width, raster.Height);

            // Obtain the final SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}