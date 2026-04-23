using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input raster image path and output SVG path
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // standard screen DPI

            // Create an SVG graphics canvas with the same dimensions as the raster image
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0));

            // Set stroke width to 3 pixels and draw a rectangle border around the image
            Pen borderPen = new Pen(Color.Black, 3);
            graphics.DrawRectangle(borderPen, 0, 0, width, height);

            // Finalize the SVG image and save it
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}