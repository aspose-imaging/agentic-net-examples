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

        // Load the PNG raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics context with the same dimensions as the PNG
            int dpi = 96;
            SvgGraphics2D graphics = new SvgGraphics2D(raster.Width, raster.Height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0), new Size(raster.Width, raster.Height));

            // Set stroke color to black by drawing a rectangle border around the image
            Pen blackPen = new Pen(Color.Black, 1);
            graphics.DrawRectangle(blackPen, 0, 0, raster.Width, raster.Height);

            // Finalize the SVG image and save it
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}