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

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for drawing
            var rasterImage = (RasterImage)image;

            // Create an SVG graphics context with the same dimensions as the PNG
            var graphics = new SvgGraphics2D(rasterImage.Width, rasterImage.Height, 96);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(rasterImage, new Point(0, 0), new Size(rasterImage.Width, rasterImage.Height));

            // Set stroke color to blue by drawing a rectangle border
            graphics.DrawRectangle(new Pen(Color.Blue, 1), 0, 0, rasterImage.Width, rasterImage.Height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}