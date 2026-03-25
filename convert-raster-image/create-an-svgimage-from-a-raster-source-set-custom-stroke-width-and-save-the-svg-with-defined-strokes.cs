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
        string inputPath = "sample.bmp";
        string outputPath = "output/output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96;

            // Create SVG graphics canvas
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Define a custom pen with specific stroke width
            Pen customPen = new Pen(Color.Blue, 5);
            // Draw a rectangle border using the custom pen
            graphics.DrawRectangle(customPen, 0, 0, width, height);

            // Embed the raster image into the SVG
            graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

            // Finalize SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}