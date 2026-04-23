using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Cast to RasterImage for drawing
            var raster = rasterImage as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("The input file is not a raster image.");
                return;
            }

            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // Standard screen DPI

            // Create an SVG canvas with the same dimensions as the PNG
            var graphics = new SvgGraphics2D(width, height, dpi);

            // Embed the raster image into the SVG
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

            // Finalize the SVG recording
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // The viewbox is automatically set to match the canvas size (width x height)
                // Save the SVG to the output path
                svgImage.Save(outputPath);
            }
        }
    }
}