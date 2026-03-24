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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics canvas with the same dimensions as the raster image
            SvgGraphics2D graphics = new SvgGraphics2D(raster.Width, raster.Height, 96);

            // Draw the raster image onto the SVG canvas at the origin (0,0)
            graphics.DrawImage(raster, new Point(0, 0));

            // Finalize the SVG image and save it
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}