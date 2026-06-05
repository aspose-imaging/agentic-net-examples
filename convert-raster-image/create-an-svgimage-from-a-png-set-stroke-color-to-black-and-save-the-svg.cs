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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                // Create an SVG graphics context with the same dimensions
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Set stroke color to black by drawing a rectangle border
                graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width, height);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Finalize the SVG image and save it
                using (SvgImage svg = graphics.EndRecording())
                {
                    svg.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}