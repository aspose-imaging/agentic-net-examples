using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image bmpImage = Image.Load(inputPath))
            {
                RasterImage raster = bmpImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load BMP as raster image.");
                    return;
                }

                // Define custom viewbox dimensions
                int viewBoxWidth = 200;
                int viewBoxHeight = 200;
                int dpi = 96;

                // Create SVG canvas with custom size
                var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(viewBoxWidth, viewBoxHeight, dpi);

                // Draw the raster image onto the SVG canvas, scaling to fit the viewbox
                graphics.DrawImage(raster, new Point(0, 0), new Size(viewBoxWidth, viewBoxHeight));

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG image
                    svgImage.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}